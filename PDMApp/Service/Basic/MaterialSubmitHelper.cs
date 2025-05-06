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

        // 無立即 SaveChanges 的版本，用來累積流水號更新
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

            // 更新 seqRow 的值，但不儲存
            seqRow.data_no = (matSeq + 1).ToString();
            return (newMatNo, null, seqRow);
        }

        public static async Task<(bool isSuccess, string message, string failMatId)> SubmitMultipleToSerpAsync(pcms_pdm_testContext context,List<MaterialSubmitParameter> requestList)
        {
            using var transaction = await context.Database.BeginTransactionAsync();

            try
            {
                var now = DateTime.Now;
                string timestamp = now.ToString("yyyyMMddHHmmssfff") + now.ToString("ffffff").Substring(3, 3);

                var updatedMaterials = new List<matm>();
                var updatedSeqRows = new List<sys_namevalue>();

                foreach (var req in requestList)
                {
                    var material = await context.matm.FirstOrDefaultAsync(m => m.mat_id == req.MatId && m.fact_no == req.DevFactoryNo);
                    if (material == null)
                        return (false, "找不到指定的物料資料。", req.MatId);

                    if (string.IsNullOrEmpty(material.mat_no))
                    {
                        var (newMatNo, generateErrMsg, updatedSeqRow) = await GenerateMatNoWithoutSaveAsync(context);
                        if (newMatNo == null)
                            return (false, generateErrMsg, req.MatId);

                        material.mat_no = newMatNo;
                        updatedSeqRows.Add(updatedSeqRow); // 收集要更新的流水號設定
                    }

                    material.order_status = "INPRG";
                    material.trans_proc_mk = 'N';
                    material.trans_id = timestamp;

                    updatedMaterials.Add(material);
                }

                // 更新資料庫（包含 material 和 sys_namevalue）
                context.matm.UpdateRange(updatedMaterials);
                context.sys_namevalue.UpdateRange(updatedSeqRows);
                await context.SaveChangesAsync();

                // 呼叫 SERP Web API（逐筆）
                foreach (var material in updatedMaterials)
                {
                    string apiUrl = $"https://esb6test.pouchen.com/services/PCMS_PDM_BASIC_MATL_I_QAS?FACT_NO={material.fact_no}&TRANS_ID={material.trans_id}";
                    var response = await _httpClient.GetAsync(apiUrl);
                    var apiResult = await response.Content.ReadAsStringAsync();

                    var apiJson = JObject.Parse(apiResult);
                    var status = apiJson["STATUS"]?.ToString();
                    var apiErrorMsg = apiJson["ERROR_MSG"]?.ToString();

                    if (status != "Y")
                    {
                        await transaction.RollbackAsync();
                        return (false, $"送出失敗：{apiErrorMsg}", material.mat_id);
                    }
                }

                await transaction.CommitAsync();
                return (true, "全部送出成功", null);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return (false, $"處理過程中發生錯誤: {ex.Message}", null);
            }
        }
    }
}
