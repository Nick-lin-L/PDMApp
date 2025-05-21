using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using PDMApp.Dtos.Basic;
using PDMApp.Models;
using PDMApp.Parameters.Basic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Service.Basic
{
    public static class MaterialImportCreateHelper
    {
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

        public static MemoryStream ExportCreateErrorExcel(List<(MaterialCreateParameter Item, string ErrorMessage)> errorList)
        {
            using var workbook = new XLWorkbook();
            var ws = workbook.Worksheets.Add("CreateImportError");

            string[] headers = new[]
            {
                "Attyp", "MatNo", "MatFullNm", "ColorNo", "ColorNm", "Standard", "Uom",
                "Memo", "Matnr", "ScmBclassNo", "ScmMclassNo", "ScmSclassNo", "ERROR MESSAGE"
            };

            for (int i = 0; i < headers.Length; i++)
            {
                ws.Cell(1, i + 1).Value = headers[i];
                ws.Cell(1, i + 1).Style.Font.Bold = true;
                ws.Cell(1, i + 1).Style.Fill.BackgroundColor = XLColor.LightGray;
            }

            int row = 2;
            foreach (var (item, error) in errorList)
            {
                ws.Cell(row, 1).Value = item.Attyp;
                ws.Cell(row, 2).Value = item.MatNo;
                ws.Cell(row, 3).Value = item.MatFullNm;
                ws.Cell(row, 4).Value = item.ColorNo;
                ws.Cell(row, 5).Value = item.ColorNm;
                ws.Cell(row, 6).Value = item.Standard;
                ws.Cell(row, 7).Value = item.Uom;
                ws.Cell(row, 8).Value = item.Memo;
                ws.Cell(row, 9).Value = item.Matnr;
                ws.Cell(row, 10).Value = item.ScmBclassNo;
                ws.Cell(row, 11).Value = item.ScmMclassNo;
                ws.Cell(row, 12).Value = item.ScmSclassNo;
                ws.Cell(row, 13).Value = error;
                row++;
            }

            ws.Columns().AdjustToContents();
            var stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;
            return stream;
        }

        public static async Task<(bool isSuccess, List<MaterialDto> successList, List<(MaterialCreateParameter Item, string ErrorMessage)> errorList)> TryImportCreateAsync(pcms_pdm_testContext _context, List<MaterialCreateParameter> importList, string pccuid)
        {
            var successList = new List<MaterialDto>();
            var errorList = new List<(MaterialCreateParameter, string)>();
            var insertList = new List<matm>();

            // ────────────────────────────────────────────────
            // 🔸 預先載入字典資料（特殊字元列表 + 工廠核心欄位）
            // ────────────────────────────────────────────────
            var splCharCodes = await _context.sys_namevalue
                .Where(x => x.group_key == "spl_char" && x.status == "Y")
                .Select(x => x.data_no)
                .ToListAsync();

            var specialCharList = splCharCodes
                .Select(x => int.TryParse(x, out var n) ? n : -1)
                .Where(n => n != -1)
                .ToList();

            var allFactoryCoreFields = await _context.pdm_namevalue_new
                .Where(x => x.group_key.Trim() == "mat_key" && x.status == "Y")
                .ToListAsync();

            // ────────────────────────────────────────────────
            // 🔸 逐筆驗證與新增
            // ────────────────────────────────────────────────
            foreach (var value in importList)
            {
                try
                {
                    var missingFields = new List<string>();

                    // 固定必填欄位檢查
                    if (string.IsNullOrWhiteSpace(value.Attyp)) missingFields.Add(nameof(value.Attyp));
                    if (string.IsNullOrWhiteSpace(value.MatFullNm)) missingFields.Add(nameof(value.MatFullNm));
                    if (string.IsNullOrWhiteSpace(value.Uom)) missingFields.Add(nameof(value.Uom));

                    // 工廠定義的必填欄位
                    var requiredCoreFields = allFactoryCoreFields
                        .Where(x => x.fact_no == value.DevFactoryNo)
                        .Select(x => x.value_desc.Trim().ToLower())
                        .ToList();

                    foreach (var field in requiredCoreFields)
                    {
                        string camelCaseField = ToCamelCase(field); // 轉為駝峰命名格式
                        var prop = typeof(MaterialCreateParameter).GetProperties()
                            .FirstOrDefault(p => p.Name.Equals(camelCaseField, StringComparison.OrdinalIgnoreCase));
                        var fieldValue = prop?.GetValue(value)?.ToString();

                        if (string.IsNullOrWhiteSpace(fieldValue))
                            missingFields.Add(camelCaseField);
                    }

                    if (missingFields.Any())
                    {
                        errorList.Add((value, $"缺少必填欄位或工廠核心欄位：{string.Join(", ", missingFields)}"));
                        continue;
                    }

                    // 特殊字元與全形字元檢查
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
                            errorList.Add((value, $"{fieldName} 欄位{reason}。"));
                            goto ContinueNext;
                        }
                    }

                    // 顏色欄位需同時有值或同時為空
                    if (!string.IsNullOrWhiteSpace(value.ColorNo) ^ !string.IsNullOrWhiteSpace(value.ColorNm))
                    {
                        errorList.Add((value, "顏色代號 (ColorNo) 與顏色說明 (ColorNm) 必須同時填寫或同時留空。"));
                        continue;
                    }

                    // MatNo 不可重複
                    if (!string.IsNullOrWhiteSpace(value.MatNo))
                    {
                        var existsMaterial = await _context.matm
                            .AsNoTracking()
                            .FirstOrDefaultAsync(x => x.mat_no == value.MatNo);

                        if (existsMaterial != null)
                        {
                            errorList.Add((value, $"已存在物料 PDM 料號 [{value.MatNo}] 已存在，物料完整說明：[{existsMaterial.mat_full_nm}]"));
                            continue;
                        }
                    }

                    // 加入待新增清單（不立即存）
                    var newMaterial = new matm
                    {
                        attyp = value.Attyp?.Split('-')[0],
                        mat_no = value.MatNo?.Trim(),
                        mat_nm = value.MatFullNm?.Trim(),
                        mat_full_nm = value.MatFullNm?.Trim(),
                        uom = value.Uom?.Split('-')[0]?.Trim(),
                        color_no = value.ColorNo?.Trim(),
                        color_nm = value.ColorNm?.Trim(),
                        standard = value.Standard?.Trim(),
                        matnr = value.Matnr?.Trim(),
                        scm_bclass_no = value.ScmBclassNo?.Split('-')[0]?.Trim(),
                        scm_mclass_no = value.ScmMclassNo?.Split('-')[0]?.Trim(),
                        scm_sclass_no = value.ScmSclassNo?.Split('-')[0]?.Trim(),
                        memo = value.Memo?.Trim(),
                        order_status = "OPEN",
                        create_user = pccuid,
                        modify_user = pccuid,
                        fact_no = value.DevFactoryNo,
                    };

                    insertList.Add(newMaterial);
                }
                catch (Exception ex)
                {
                    errorList.Add((value, $"未預期錯誤：{ex.Message}"));
                }

            ContinueNext:
                continue;
            }

            // 若有錯誤，整批不寫入
            if (errorList.Any())
                return (false, new(), errorList);

            // 全部無誤，才寫入資料庫
            try
            {
                await _context.matm.AddRangeAsync(insertList);
                await _context.SaveChangesAsync();

                // 把成功匯入的資料轉為 MaterialDto 並補上 MatId
                var dtos = insertList.Select(item => new MaterialDto
                {
                    MatId = item.mat_id,
                    Attyp = item.attyp,
                    MatNo = item.mat_no,
                    MatNm = item.mat_nm,
                    MatFullNm = item.mat_full_nm,
                    Uom = item.uom,
                    ColorNo = item.color_no,
                    ColorNm = item.color_nm,
                    Standard = item.standard,
                    Matnr = item.matnr,
                    CustNo = item.cust_no,
                    ScmBclassNo = item.scm_bclass_no,
                    ScmMclassNo = item.scm_mclass_no,
                    ScmSclassNo = item.scm_sclass_no,
                    Memo = item.memo,
                    ModifyUser = item.modify_user,
                    ModifyTime = item.modify_tm,
                    Status = item.status,
                    Locked = item.locked,
                    OrderStatus = item.order_status,
                    TransMsg = item.trans_msg,
                    FactNo = item.fact_no,
                    SerpMatNo = item.serp_mat_no,
                    StopDate = item.stop_date?.ToString("yyyy-MM-dd")
                }).ToList();

                return (true, dtos, new());
            }
            catch (Exception ex)
            {
                var message = ex.InnerException?.Message ?? ex.Message;
                return (false, new(), insertList.Select(i => (
                    new MaterialCreateParameter { MatNo = i.mat_no, MatFullNm = i.mat_full_nm },
                    $"整批寫入失敗：{message}"
                )).ToList());
            }
        }
    }
}
