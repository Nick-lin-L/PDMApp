using Microsoft.EntityFrameworkCore;
using PDMApp.Models;
using PDMApp.Parameters.Basic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Service.Basic
{
    public static class MaterialInsertHelper
    {
        // 欄位顯示名稱對照表
        private static readonly Dictionary<string, string> FieldDisplayNames = new()
        {
            { "Attyp", "MATL Type" },
            { "MatNm", "MATL Info" },
            { "MatFullNm", "MATL Full Info" },
            { "Uom", "UOM" },
            { "Status", "Activate" },
            { "ColorNo", "Color No" },
            { "ColorNm", "Color Info" },
            { "Memo", "MATL Note" },
            { "ScmBclassNo", "Primary Cat" },
            { "ScmMclassNo", "Secondary Cat" },
            { "ScmSclassNo", "Minor Cat" },
            { "SerpMatNo", "SERP MATL No." },
            { "MatNo", "PDM MATL NO" },
            { "CustNo", "Cust. MATL No." },
            { "Matnr", "MDA MATL No." },
            { "StopDate", "Close Date" },
            { "OrderStatus", "State" }
        };
        // 將字串轉為駝峰式命名
        private static string ToCamelCase(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            input = input.Replace("_", " "); // 暫時空白避免干擾
            TextInfo textInfo = CultureInfo.InvariantCulture.TextInfo;
            var result = textInfo.ToTitleCase(input).Replace(" ", "");
            return char.ToUpperInvariant(result[0]) + result.Substring(1);
        }

        private static bool ContainsFullWidthOrSpecialChar(string input, List<int> specialChars, out string? reason)
        {
            foreach (var ch in input)
            {
                if (specialChars.Contains((int)ch))
                {
                    reason = "不可含有特殊字元";
                    return true;
                }
                if (ch == '\u3000')
                {
                    reason = "不可含有全形空格";
                    return true;
                }
                if (ch >= '\uFF00' && ch <= '\uFFEF')
                {
                    reason = "不可含有全形標點符號";
                    return true;
                }
            }
            reason = null;
            return false;
        }

        public static async Task<(bool, string)> InsertMaterialAsync(pcms_pdm_testContext _context, MaterialCreateParameter value, string pccuid)
        {
            try
            {
                var missingFields = new List<string>();

                // 固定欄位檢查
                if (string.IsNullOrWhiteSpace(value.Attyp)) missingFields.Add(nameof(value.Attyp));
                if (string.IsNullOrWhiteSpace(value.MatNm)) missingFields.Add(nameof(value.MatNm));
                if (string.IsNullOrWhiteSpace(value.MatFullNm)) missingFields.Add(nameof(value.MatFullNm));
                if (string.IsNullOrWhiteSpace(value.Uom)) missingFields.Add(nameof(value.Uom));
                if (string.IsNullOrWhiteSpace(value.Status)) missingFields.Add(nameof(value.Status));

                // 取得動態必填欄位（根據工廠定義）
                var requiredCoreFields = await _context.pdm_namevalue_new
                    .Where(x => x.fact_no == value.DevFactoryNo && x.group_key.Trim() == "mat_key" && x.status == "Y")
                    .Select(x => x.value_desc.Trim().ToLower())
                    .ToListAsync();

                foreach (var field in requiredCoreFields)
                {
                    string camelCaseField = ToCamelCase(field);  // 轉為駝峰命名格式
                    var prop = typeof(MaterialCreateParameter).GetProperties()
                        .FirstOrDefault(p => p.Name.Equals(camelCaseField, StringComparison.OrdinalIgnoreCase));
                    var fieldValue = prop?.GetValue(value)?.ToString();

                    if (string.IsNullOrWhiteSpace(fieldValue))
                    {
                        missingFields.Add(camelCaseField);
                    }
                }

                if (missingFields.Any())
                {
                    var displayNames = missingFields
                        .Select(f => FieldDisplayNames.ContainsKey(f) ? FieldDisplayNames[f] : f);
                    return (false, $"缺少必填欄位或工廠核心值欄位：{string.Join(", ", displayNames)}");
                }

                // 查詢特殊字元清單（需先轉成 List<string> 再 TryParse）
                var dataNoList = await _context.sys_namevalue
                    .Where(x => x.group_key == "spl_char" && x.status == "Y")
                    .Select(x => x.data_no)
                    .ToListAsync();

                var specialCharList = dataNoList
                    .Select(x => int.TryParse(x, out var n) ? n : -1)
                    .Where(n => n != -1)
                    .ToList();

                // 欄位特殊字元 & 全形符號檢查
                var fieldsToCheck = new Dictionary<string, string?>
                {
                    { nameof(value.MatNm), value.MatNm?.Trim() },
                    { nameof(value.MatFullNm), value.MatFullNm?.Trim() },
                    { nameof(value.Memo), value.Memo?.Trim() },
                    { nameof(value.ColorNm), value.ColorNm?.Trim() }
                };

                foreach (var (fieldName, fieldValue) in fieldsToCheck)
                {
                    if (!string.IsNullOrEmpty(fieldValue) &&
                        ContainsFullWidthOrSpecialChar(fieldValue, specialCharList, out var reason))
                    {
                        var displayName = FieldDisplayNames.ContainsKey(fieldName) ? FieldDisplayNames[fieldName] : fieldName;
                        return (false, $"{displayName} 欄位{reason}。");
                    }
                }

                // 新增判斷：ColorNo 與 ColorNm 需同時有值或同時為空
                if (!string.IsNullOrWhiteSpace(value.ColorNo) ^ !string.IsNullOrWhiteSpace(value.ColorNm))
                {
                    return (false, "顏色代號 (ColorNo) 與顏色說明 (ColorNm) 必須同時填寫或同時留空。");
                }

                // 判斷有填 MatNo 時，檢查是否已存在
                if (!string.IsNullOrWhiteSpace(value.MatNo))
                {
                    var existsMaterial = await _context.matm
                        .Where(x => x.mat_no == value.MatNo)
                        .Select(x => new { x.mat_no, x.mat_full_nm })
                        .FirstOrDefaultAsync();

                    if (existsMaterial != null)
                    {
                        return (false, $"已存在物料 PDM 料號 [{existsMaterial.mat_no}]，物料完整說明：[{existsMaterial.mat_full_nm}]");
                    }
                }

                // 新增資料
                var newMaterial = new matm
                {
                    attyp = value.Attyp?.Split('-')[0],
                    mat_no = value.MatNo,
                    mat_nm = value.MatNm,
                    mat_full_nm = value.MatFullNm,
                    uom = value.Uom?.Split('-')[0]?.Trim(),
                    color_no = value.ColorNo,
                    color_nm = value.ColorNm,
                    standard = value.Standard,
                    cust_no = value.CustNo,
                    matnr = value.Matnr,
                    scm_bclass_no = value.ScmBclassNo?.Split('-')[0]?.Trim(),
                    scm_mclass_no = value.ScmMclassNo?.Split('-')[0]?.Trim(),
                    scm_sclass_no = value.ScmSclassNo?.Split('-')[0]?.Trim(),
                    memo = value.Memo,
                    order_status = "OPEN", // 預設給 OPEN
                    create_user = pccuid,
                    modify_user = pccuid,
                    fact_no = value.DevFactoryNo,
                };

                _context.matm.Add(newMaterial);
                await _context.SaveChangesAsync();

                return (true, "Insert success.");
            }
            catch (DbUpdateException dbEx)
            {
                var errorMessage = dbEx.InnerException?.Message ?? dbEx.Message;
                return (false, $"資料儲存錯誤，可能是欄位長度限制問題{errorMessage}");
            }
            catch (Exception ex)
            {
                return (false, $"Unhandled error: {ex.Message}");
            }
        }
    }
}
