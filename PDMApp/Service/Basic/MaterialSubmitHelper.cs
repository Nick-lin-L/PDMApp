using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using PDMApp.Models;
using PDMApp.Parameters.Basic;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PDMApp.Service.Basic
{
    public static class MaterialSubmitHelper
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        private static async Task<(string newMatNo, string errorMsg, sys_namevalue updatedSeqRow)> GenerateMatNoWithoutSaveAsync(pcms_pdm_testContext context)
        {
            var titleRow = await context.sys_namevalue.FirstOrDefaultAsync(n => n.group_key == "mat_title" && n.status == "Y");
            if (titleRow == null || string.IsNullOrWhiteSpace(titleRow.data_no))
                return (null, "找不到 group_key 為 'mat_title' 的料號前綴設定。", null);

            var seqRow = await context.sys_namevalue.FirstOrDefaultAsync(n => n.group_key == "mat_seq" && n.status == "Y");
            if (seqRow == null || string.IsNullOrWhiteSpace(seqRow.data_no))
                return (null, "找不到 group_key 為 'mat_seq' 的流水號設定。", null);

            if (!long.TryParse(seqRow.data_no.Trim(), out var matSeq))
                return (null, "mat_seq 資料格式錯誤，無法轉為整數。", null);

            var paddedSeq = matSeq.ToString().PadLeft(15, '0');
            var newMatNo = titleRow.data_no.Trim() + paddedSeq;

            seqRow.data_no = (matSeq + 1).ToString();
            return (newMatNo, null, seqRow);
        }

        public static async Task<(bool isSuccess, string message)> SubmitMultipleToSerpAsync(pcms_pdm_testContext context, List<MaterialSubmitParameter> requestList)
        {
            using var transaction = await context.Database.BeginTransactionAsync();

            try
            {
                var now = DateTime.Now;
                string timestamp = now.ToString("yyyyMMddHHmmssfff") + now.ToString("ffffff").Substring(3, 3); // 單一 trans_id

                var updatedMaterials = new List<matm>();
                var updatedSeqRows = new List<sys_namevalue>();

                // 先檢查是否有任何一筆已送出過
                foreach (var req in requestList)
                {
                    var material = await context.matm.FirstOrDefaultAsync(m => m.mat_id == req.MatId && m.fact_no == req.DevFactoryNo);
                    if (material == null)
                        return (false, $"找不到指定的物料資料{material.mat_no}。");

                    if (!string.IsNullOrEmpty(material.trans_id))
                        return (false, $"料號{material.mat_no}已送出過，請勿重複送出。");
                }

                // 所有資料都合法，開始處理送出
                foreach (var req in requestList)
                {
                    var material = await context.matm.FirstOrDefaultAsync(m => m.mat_id == req.MatId && m.fact_no == req.DevFactoryNo);

                    if (string.IsNullOrEmpty(material.mat_no))
                    {
                        var (newMatNo, generateErrMsg, updatedSeqRow) = await GenerateMatNoWithoutSaveAsync(context);
                        if (newMatNo == null)
                            return (false, generateErrMsg);

                        material.mat_no = newMatNo;
                        updatedSeqRows.Add(updatedSeqRow); // 收集更新的流水號設定
                    }

                    material.order_status = "INPRG";
                    material.trans_proc_mk = 'N';
                    material.trans_id = timestamp;

                    updatedMaterials.Add(material);
                }

                context.matm.UpdateRange(updatedMaterials);
                context.sys_namevalue.UpdateRange(updatedSeqRows);
                await context.SaveChangesAsync();
                await transaction.CommitAsync(); // 提交更新資料與 trans_id

                // 呼叫 SERP API：只呼叫一次
                string factNo = updatedMaterials[0].fact_no;
                string apiUrl = $"https://esb6test.pouchen.com/services/PCMS_PDM_BASIC_MATL_I_QAS?FACT_NO={factNo}&TRANS_ID={timestamp}";

                var response = await _httpClient.GetAsync(apiUrl);
                var apiResult = await response.Content.ReadAsStringAsync();

                var apiJson = JObject.Parse(apiResult);
                var status = apiJson["STATUS"]?.ToString();
                var apiErrorMsg = apiJson["ERROR_MSG"]?.ToString();

                if (status != "Y")
                {
                    foreach (var material in updatedMaterials)
                    {
                        material.order_status = "OPEN";
                        material.trans_proc_mk = 'Y';
                        material.trans_id = null;
                    }

                    context.matm.UpdateRange(updatedMaterials);
                    await context.SaveChangesAsync();

                    return (false, $"送出失敗：{apiErrorMsg}");
                }

                return (true, "送出成功");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return (false, $"處理過程中發生錯誤: {ex.Message}");
            }
        }
    }
}
