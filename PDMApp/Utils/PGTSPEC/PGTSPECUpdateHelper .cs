using Microsoft.EntityFrameworkCore;
using PDMApp.Models;
using PDMApp.Parameters.PGTSPEC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Utils.PGTSPEC
{
    public static class PGTSPECUpdateHelper
    {
        /// <summary>
        /// 取得 ActPartNo，依據 No、Parts 或前一筆有效資料。
        /// </summary>
        private static string GetActPartNo(SpecItemUpdateParameter currentItem, List<SpecItemUpdateParameter> allItems)
        {
            if (!string.IsNullOrWhiteSpace(currentItem.No))
            {
                return currentItem.No;
            }

            if (!string.IsNullOrWhiteSpace(currentItem.Parts))
            {
                var matchingItem = allItems.FirstOrDefault(i => i.Parts == currentItem.Parts && !string.IsNullOrWhiteSpace(i.No));
                if (matchingItem != null)
                {
                    return matchingItem.No;
                }
                throw new Exception($"物料：{currentItem.Material} 需有 NO、PARTS 資訊。");
            }

            var previousItem = allItems
                .TakeWhile(i => i != currentItem)
                .Reverse()
                .FirstOrDefault(i => !string.IsNullOrWhiteSpace(i.No) || !string.IsNullOrWhiteSpace(i.ActPartNo));

            if (previousItem != null)
            {
                return !string.IsNullOrWhiteSpace(previousItem.ActPartNo) ? previousItem.ActPartNo : previousItem.No;
            }

            throw new Exception($"物料：{currentItem.Material} 需有 NO、PARTS 資訊。");
        }

        /// <summary>
        /// 更新 SPEC_HEAD 和 SPEC_ITEM (確保整體一致性)
        /// </summary>
        public static async Task<(bool, string)> UpdateSpecAsync(pcms_pdm_testContext context, PGTSpec5SheetsUpdateParameter value)
        {
            using var transaction = await context.Database.BeginTransactionAsync();
            try
            {
                var headData = value.HeadData.FirstOrDefault();
                if (headData == null)
                {
                    return (false, "請提供有效的 HeadData");
                }
                // 取得 SPEC_HEAD
                var headEntity = await context.pcg_spec_head.FirstOrDefaultAsync(h => h.spec_m_id == headData.SpecMId);
                if (headEntity == null)
                {
                    return (false, "SpecMId 不存在，無法處理 SpecHead");
                }

                // 更新 SPEC_HEAD 相關欄位
                headEntity.pgt_color_name = headData.PgtColorName;
                headEntity.ref_dev_no = headData.RefDevNo;
                headEntity.mold_no1 = headData.MoldNo1;
                headEntity.mold_no2 = headData.MoldNo2;
                headEntity.mold_no3 = headData.MoldNo3;
                headEntity.remarks_spec = headData.RemarksSpec;
                headEntity.remarks_prohibit = headData.RemarksProhibit;
                headEntity.update_user_id = "20211200037074"; // 這裡應該改為 USER ID
                headEntity.update_user_nm = "鄭名硯"; // 這裡應該改為 USER_NAME
                headEntity.update_date = DateTime.Now;

                // 取得現有的 SPEC_ITEM
                var existingItems = await context.pcg_spec_item
                    .Where(si => si.spec_m_id == headData.SpecMId)
                    .ToListAsync();

                // 刪除現有的 SPEC_ITEM（但還未 SaveChanges）
                if (existingItems.Any())
                {
                    context.pcg_spec_item.RemoveRange(existingItems);
                }

                // 準備新增新的 SPEC_ITEM
                var allItems = new List<SpecItemUpdateParameter>();
                allItems.AddRange(value.UpperData ?? new List<SpecItemUpdateParameter>());
                allItems.AddRange(value.SoleData ?? new List<SpecItemUpdateParameter>());
                allItems.AddRange(value.OtherData ?? new List<SpecItemUpdateParameter>());

                var newItems = new List<pcg_spec_item>();
                foreach (var item in allItems)
                {
                    var newItem = new pcg_spec_item
                    {
                        spec_d_id = Guid.NewGuid().ToString(), // 產生新的 UUID
                        spec_m_id = headData.SpecMId,
                        material_sort = item.Sort,
                        parts_no = item.No,
                        parts = item.Parts,
                        detail = item.Detail,
                        process_mk = item.ProcessMk,
                        material = item.Material,
                        recycle = item.Recycle,
                        mat_comment = item.MaterialComment,
                        standard = item.Standard,
                        agent = item.Agent,
                        supplier = item.Supplier,
                        quote_supplier = item.QuoteSupplier,
                        hcha = item.Hcha,
                        sec = item.Sec,
                        material_color = item.Colors,
                        clr_comment = item.ColorComment,
                        memo = item.Memo,
                        act_part_no = GetActPartNo(item, allItems), // 計算 ActPartNo
                        material_new = item.Type,
                        // 設定 material_group
                        material_group = value.UpperData.Contains(item) ? "A" :
                                         value.SoleData.Contains(item) ? "B" :
                                         value.OtherData.Contains(item) ? "C" : ""
                    };
                    newItems.Add(newItem);
                }

                // 確保所有 `SPEC_ITEM` 沒有錯誤後才新增
                context.pcg_spec_item.AddRange(newItems);

                // 儲存所有變更 (SPEC_HEAD & SPEC_ITEM)
                await context.SaveChangesAsync();

                // 成功後提交交易
                await transaction.CommitAsync();

                return (true, "更新成功");
            }
            catch (Exception ex)
            {
                // 若發生錯誤則回滾
                await transaction.RollbackAsync();
                return (false, $"錯誤: {ex.Message}");
            }
        }
    }
}
