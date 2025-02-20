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
        /// 檢查資料是否包含全型字元並返回錯誤訊息
        /// </summary>
        private static string GetFullWidthCharacterError(SpecItemUpdateParameter item)
        {
            var properties = new[]
            {
                new { Field = "Material", Value = item.Material },
                new { Field = "Agent", Value = item.Agent },
                new { Field = "Sec", Value = item.Sec },
                new { Field = "Hcha", Value = item.Hcha },
                new { Field = "Parts", Value = item.Parts },
                new { Field = "No", Value = item.No },
                new { Field = "Type", Value = item.Type },
                new { Field = "Recycle", Value = item.Recycle },
                new { Field = "Standard", Value = item.Standard },
                new { Field = "Supplier", Value = item.Supplier },
                new { Field = "QuoteSupplier", Value = item.QuoteSupplier },
                new { Field = "Colors", Value = item.Colors },
                new { Field = "Memo", Value = item.Memo },
                new { Field = "ColorComment", Value = item.ColorComment },
                new { Field = "Detail", Value = item.Detail },
                new { Field = "ProcessMk", Value = item.ProcessMk }
            };

            foreach (var property in properties)
            {
                if (!string.IsNullOrEmpty(property.Value) && property.Value.Any(c => c >= 0xFF01 && c <= 0xFF5E)) // 全型字元範圍
                {
                    return $"欄位：{property.Field} 的資料 '{property.Value}' 含有全型字元，請移除";
                }
            }

            return null;
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
                headEntity.pgt_color_name = headData.PgtColorName?.Trim();
                headEntity.ref_dev_no = headData.RefDevNo?.Trim();
                headEntity.mold_no1 = headData.MoldNo1?.Trim();
                headEntity.mold_no2 = headData.MoldNo2?.Trim();
                headEntity.mold_no3 = headData.MoldNo3?.Trim();
                headEntity.remarks_spec = headData.RemarksSpec?.Trim();
                headEntity.remarks_prohibit = headData.RemarksProhibit?.Trim();
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
                    // 先清除前後空格
                    item.Material = item.Material?.Trim();
                    item.Agent = item.Agent?.Trim();
                    item.Sec = item.Sec?.Trim();
                    item.Hcha = item.Hcha?.Trim();
                    item.Parts = item.Parts?.Trim();
                    item.No = item.No?.Trim();
                    item.Type = item.Type?.Trim();
                    item.Recycle = item.Recycle?.Trim();
                    item.Standard = item.Standard?.Trim();
                    item.Supplier = item.Supplier?.Trim();
                    item.QuoteSupplier = item.QuoteSupplier?.Trim();
                    item.Colors = item.Colors?.Trim();
                    item.Memo = item.Memo?.Trim();
                    item.ColorComment = item.ColorComment?.Trim();
                    item.Detail = item.Detail?.Trim();
                    item.ProcessMk = item.ProcessMk?.Trim();

                    // 2.1 檢查 MATERIAL 是否有值
                    if (string.IsNullOrWhiteSpace(item.Material))
                    {
                        throw new Exception($"物料：{item.Parts} 的 MATERIAL 不能為空");
                    }

                    // 2.3 檢查是否有全型字元
                    var fullWidthError = GetFullWidthCharacterError(item);
                    if (!string.IsNullOrEmpty(fullWidthError))
                    {
                        throw new Exception(fullWidthError);
                    }

                    // 準備新增 SPEC_ITEM 資料
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
