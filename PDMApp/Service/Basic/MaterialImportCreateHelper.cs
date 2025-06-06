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
using System.Linq.Expressions;
using System.Reflection;
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

        // 泛型動態屬性條件 where，接受 PascalCase 屬性名，轉 snake_case EF Model 屬性名
        private static IQueryable<T> WhereDynamicEqual<T>(this IQueryable<T> source, string pascalPropertyName, string? value)
        {
            if (string.IsNullOrWhiteSpace(value)) return source;

            var snakePropertyName = PascalCaseToSnakeCase(pascalPropertyName);

            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.PropertyOrField(parameter, snakePropertyName);
            var constant = Expression.Constant(value);
            var equality = Expression.Equal(property, constant);
            var lambda = Expression.Lambda<Func<T, bool>>(equality, parameter);

            return source.Where(lambda);
        }

        // PascalCase → snake_case
        private static string PascalCaseToSnakeCase(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            var builder = new System.Text.StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                var c = input[i];
                if (char.IsUpper(c))
                {
                    if (i > 0) builder.Append('_');
                    builder.Append(char.ToLowerInvariant(c));
                }
                else
                {
                    builder.Append(c);
                }
            }
            return builder.ToString();
        }

        // snake_case → PascalCase (已存在的函式，供動態必填核心欄位用)
        private static string ToPascalCase(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            var words = input.Split('_', StringSplitOptions.RemoveEmptyEntries);
            return string.Concat(words.Select(w => char.ToUpperInvariant(w[0]) + w.Substring(1)));
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
                    else
                    {
                        // MatNo 沒填 → 使用 MatFullNm + Uom [+ 核心欄位] 查重
                        var coreKeyProps = requiredCoreFields.Select(ToPascalCase).ToList();
                        var query = _context.matm.AsQueryable()
                            .Where(x => x.mat_nm == value.MatFullNm && x.uom == value.Uom);

                        foreach (var key in coreKeyProps)
                        {
                            var prop = typeof(MaterialCreateParameter).GetProperty(key, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                            var val = prop?.GetValue(value)?.ToString()?.Trim();
                            query = query.WhereDynamicEqual(key, val); // 會自動轉 snake_case
                        }

                        var duplicate = await query.FirstOrDefaultAsync();
                        if (duplicate != null)
                        {
                            errorList.Add((value, $"已有相同的資料，禁止重複新增。"));
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

                var matIds = insertList.Select(x => x.mat_id).ToList();

                // 直接重查資料並帶 join（格式與 QueryMaterial 相同）
                var dtos = await (
                    from m in _context.matm
                    where matIds.Contains(m.mat_id)

                    join attypName in _context.sys_namevalue
                        on new { Key = m.attyp, Group = "attyp" }
                        equals new { Key = attypName.data_no, Group = attypName.group_key }
                        into attypJoin
                    from attypName in attypJoin.DefaultIfEmpty()

                    join orderStatusName in _context.sys_namevalue
                        on new { Key = m.order_status, Group = "mat_status" }
                        equals new { Key = orderStatusName.data_no, Group = orderStatusName.group_key }
                        into orderStatusJoin
                    from orderStatusName in orderStatusJoin.DefaultIfEmpty()

                    join uomName in _context.sys_namevalue
                        on new { Key = m.uom, Group = "uom" }
                        equals new { Key = uomName.data_no, Group = uomName.group_key }
                        into uomJoin
                    from uomName in uomJoin.DefaultIfEmpty()

                    join bclass in _context.sys_material_large_class
                        on m.scm_bclass_no equals bclass.class_l_no
                        into bclassJoin
                    from bclass in bclassJoin.DefaultIfEmpty()

                    join mclass in _context.sys_material_medium_class
                        on new { L = m.scm_bclass_no, M = m.scm_mclass_no }
                        equals new { L = mclass.class_l_no, M = mclass.class_m_no }
                        into mclassJoin
                    from mclass in mclassJoin.DefaultIfEmpty()

                    join sclass in _context.sys_material_small_class
                        on new { L = m.scm_bclass_no, M = m.scm_mclass_no, S = m.scm_sclass_no }
                        equals new { L = sclass.class_l_no, M = sclass.class_m_no, S = sclass.class_s_no }
                        into sclassJoin
                    from sclass in sclassJoin.DefaultIfEmpty()

                    join user in _context.pdm_users
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
                    }
                ).ToListAsync();


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
