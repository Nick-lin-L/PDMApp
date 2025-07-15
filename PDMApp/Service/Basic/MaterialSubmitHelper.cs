using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using PDMApp.Models;
using PDMApp.Parameters.Basic;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using PDMApp.Dtos.Basic;

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

        // 輔助查詢
        private static IQueryable<MaterialDto> GetMaterialBaseQuery(pcms_pdm_testContext _pcms_Pdm_TestContext)
        {
            var baseQuery = from m in _pcms_Pdm_TestContext.matm

                                // Join attyp name
                            join attypName in _pcms_Pdm_TestContext.sys_namevalue
                                on new { Key = m.attyp, Group = "attyp" }
                                equals new { Key = attypName.data_no, Group = attypName.group_key }
                                into attypJoin
                            from attypName in attypJoin.DefaultIfEmpty()

                                // Join order_status name
                            join orderStatusName in _pcms_Pdm_TestContext.sys_namevalue
                                on new { Key = m.order_status, Group = "mat_status" }
                                equals new { Key = orderStatusName.data_no, Group = orderStatusName.group_key }
                                into orderStatusJoin
                            from orderStatusName in orderStatusJoin.DefaultIfEmpty()

                                // Join UOM name
                            join uomName in _pcms_Pdm_TestContext.sys_namevalue
                                on new { Key = m.uom, Group = "uom" }
                                equals new { Key = uomName.data_no, Group = uomName.group_key }
                                into uomJoin
                            from uomName in uomJoin.DefaultIfEmpty()

                                // Join sys_material_large_class (ScmBclassNoName)
                            join bclass in _pcms_Pdm_TestContext.sys_material_large_class
                                on m.scm_bclass_no equals bclass.class_l_no
                                into bclassJoin
                            from bclass in bclassJoin.DefaultIfEmpty()

                                // Join sys_material_medium_class (ScmMclassNoName)
                            join mclass in _pcms_Pdm_TestContext.sys_material_medium_class
                                on new { L = m.scm_bclass_no, M = m.scm_mclass_no }
                                equals new { L = mclass.class_l_no, M = mclass.class_m_no }
                                into mclassJoin
                            from mclass in mclassJoin.DefaultIfEmpty()

                                // Join sys_material_small_class (ScmSclassNoName)
                            join sclass in _pcms_Pdm_TestContext.sys_material_small_class
                                on new { L = m.scm_bclass_no, M = m.scm_mclass_no, S = m.scm_sclass_no }
                                equals new { L = sclass.class_l_no, M = sclass.class_m_no, S = sclass.class_s_no }
                                into sclassJoin
                            from sclass in sclassJoin.DefaultIfEmpty()

                                // Join pdm_users to get ModifyUserName
                            join user in _pcms_Pdm_TestContext.pdm_users
                                on m.modify_user equals user.pccuid.ToString()
                                into userJoin
                            from user in userJoin.DefaultIfEmpty()

                            select new MaterialDto
                            {
                                FactNo = m.fact_no,
                                MatId = m.mat_id,
                                Attyp = (!string.IsNullOrWhiteSpace(m.attyp) && !string.IsNullOrWhiteSpace(attypName.text))
                                        ? m.attyp + "-" + attypName.text
                                        : null,
                                SerpMatNo = m.serp_mat_no,
                                MatNo = m.mat_no,
                                MatNm = m.mat_nm,
                                MatFullNm = m.mat_full_nm,
                                Uom = (!string.IsNullOrWhiteSpace(m.uom) && !string.IsNullOrWhiteSpace(uomName.text))
                                        ? m.uom + "-" + uomName.text
                                        : null,
                                ColorNo = m.color_no,
                                ColorNm = m.color_nm,
                                Standard = m.standard,
                                CustNo = m.cust_no,
                                Matnr = m.matnr,
                                ScmBclassNo = (!string.IsNullOrWhiteSpace(m.scm_bclass_no) && !string.IsNullOrWhiteSpace(bclass.class_name_zh_tw))
                                                ? m.scm_bclass_no + "-" + bclass.class_name_zh_tw
                                                : null,
                                ScmMclassNo = (!string.IsNullOrWhiteSpace(m.scm_mclass_no) && !string.IsNullOrWhiteSpace(mclass.class_name_zh_tw))
                                                ? m.scm_mclass_no + "-" + mclass.class_name_zh_tw
                                                : null,
                                ScmSclassNo = (!string.IsNullOrWhiteSpace(m.scm_sclass_no) && !string.IsNullOrWhiteSpace(sclass.class_name_zh_tw))
                                                ? m.scm_sclass_no + "-" + sclass.class_name_zh_tw
                                                : null,
                                Status = m.status,
                                StopDate = m.stop_date.HasValue
                                        ? DateTimeOffset.FromUnixTimeMilliseconds((long)m.stop_date.Value).ToString("yyyy-MM-dd")
                                        : null,
                                Memo = m.memo,
                                ModifyTime = m.modify_tm,
                                ModifyUser = user != null ? user.username : m.modify_user,
                                Locked = m.locked,
                                OrderStatus = (!string.IsNullOrWhiteSpace(m.order_status) && !string.IsNullOrWhiteSpace(orderStatusName.text))
                                                ? m.order_status + "-" + orderStatusName.text
                                                : null,
                                TransMsg = m.trans_msg
                            };
            return baseQuery;
        }

        public static async Task<(bool isSuccess, string message, List<MaterialDto> updatedMaterialDtos)> SubmitMultipleToSerpAsync(pcms_pdm_testContext context, List<MaterialSubmitParameter> requestList)
        {
            using var transaction = await context.Database.BeginTransactionAsync();

            // 定義 finalMaterialDtos，預設為 null，只在成功時或特定需要時賦值
            List<MaterialDto> finalMaterialDtos = null;

            try
            {
                var now = DateTime.Now;
                string timestamp = now.ToString("yyyyMMddHHmmssfff") + now.ToString("ffffff").Substring(3, 3); // 單一 trans_id

                var updatedMaterials = new List<matm>();
                var updatedSeqRows = new List<sys_namevalue>();

                // 收集所有 MatId，以便後續查詢
                var matIds = requestList.Select(r => r.MatId).ToList();

                foreach (var req in requestList)
                {
                    var material = await context.matm.FirstOrDefaultAsync(m => m.mat_id == req.MatId);
                    if (material == null)
                        return (false, $"找不到指定的物料資料{material.mat_no}。", null);

                    if (!string.IsNullOrEmpty(material.trans_id))
                        return (false, $"料號{material.mat_no}已送出過，請勿重複送出。", null);
                }

                // 所有資料都合法，開始處理送出
                foreach (var req in requestList)
                {
                    var material = await context.matm.FirstOrDefaultAsync(m => m.mat_id == req.MatId);

                    if (string.IsNullOrEmpty(material.mat_no))
                    {
                        var (newMatNo, generateErrMsg, updatedSeqRow) = await GenerateMatNoWithoutSaveAsync(context);
                        if (newMatNo == null)
                            return (false, generateErrMsg, null);

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
                    // SERP 呼叫失敗，需要回滾資料庫狀態
                    foreach (var material in updatedMaterials)
                    {
                        material.order_status = "REJD";
                        material.trans_proc_mk = 'E';
                        material.trans_id = null;
                    }

                    context.matm.UpdateRange(updatedMaterials);
                    await context.SaveChangesAsync(); // 儲存回滾後的狀態

                    return (false, $"送出失敗：{apiErrorMsg}", null);
                }


                // SERP 呼叫成功，查詢並返回成功訊息和更新後的資料
                var materialQuery = GetMaterialBaseQuery(context).Where(m => matIds.Contains(m.MatId));
                finalMaterialDtos = await materialQuery.ToListAsync();
                return (true, "送出成功", finalMaterialDtos);

            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return (false, $"處理過程中發生錯誤: {ex.Message}", null);
            }
        }
    }
}