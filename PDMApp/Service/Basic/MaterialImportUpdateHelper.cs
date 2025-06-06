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
    public static class MaterialImportUpdateHelper
    {
        // 將字串轉為駝峰式命名
        private static string ToCamelCase(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            input = input.Replace("_", " ");
            TextInfo textInfo = CultureInfo.InvariantCulture.TextInfo;
            var result = textInfo.ToTitleCase(input).Replace(" ", "");
            return char.ToUpperInvariant(result[0]) + result.Substring(1);
        }

        // 檢查是否含有特殊字元或全形字
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

        public static MemoryStream ExportUpdateErrorExcel(List<(MaterialUpdateParameter Item, string ErrorMessage)> errorList)
        {
            using var workbook = new XLWorkbook();
            var ws = workbook.Worksheets.Add("UpdateImportError");

            string[] headers = new[]
            {
                "MatNo", "SerpMatNo", "MatFullNm", "ColorNo", "ColorNm", "Standard",
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
                ws.Cell(row, 1).Value = item.MatNo;
                ws.Cell(row, 2).Value = item.SerpMatNo;
                ws.Cell(row, 3).Value = item.MatFullNm;
                ws.Cell(row, 4).Value = item.ColorNo;
                ws.Cell(row, 5).Value = item.ColorNm;
                ws.Cell(row, 6).Value = item.Standard;
                ws.Cell(row, 7).Value = item.Memo;
                ws.Cell(row, 8).Value = item.Matnr;
                ws.Cell(row, 9).Value = item.ScmBclassNo;
                ws.Cell(row, 10).Value = item.ScmMclassNo;
                ws.Cell(row, 11).Value = item.ScmSclassNo;
                ws.Cell(row, 12).Value = error;
                row++;
            }

            ws.Columns().AdjustToContents();
            var stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;
            return stream;
        }

        public static async Task<(bool isSuccess, List<MaterialDto> successList, List<(MaterialUpdateParameter Item, string ErrorMessage)> errorList)> TryImportUpdateAsync(pcms_pdm_testContext _context, List<MaterialUpdateParameter> items, string pccuid)
        {
            var errorList = new List<(MaterialUpdateParameter, string)>();
            var updateList = new List<matm>();
            var updatedDtos = new List<MaterialDto>();

            // 取得特殊字元清單
            var dataNoList = await _context.sys_namevalue
                .Where(x => x.group_key == "spl_char" && x.status == "Y")
                .Select(x => x.data_no)
                .ToListAsync();

            var specialCharList = dataNoList
                .Select(x => int.TryParse(x, out var n) ? n : -1)
                .Where(n => n != -1)
                .ToList();

            foreach (var value in items)
            {
                try
                {
                    var missingFields = new List<string>();

                    if (string.IsNullOrWhiteSpace(value.MatNo) && string.IsNullOrWhiteSpace(value.SerpMatNo))
                    {
                        errorList.Add((value, "MatNo 與 SerpMatNo 至少需填寫一項。"));
                        continue;
                    }

                    matm? material = null;

                    // 根據 MatNo 或 SerpMatNo 查詢對應的物料
                    if (!string.IsNullOrWhiteSpace(value.MatNo) && !string.IsNullOrWhiteSpace(value.SerpMatNo))
                    {
                        material = await _context.matm
                            .FirstOrDefaultAsync(x => x.mat_no == value.MatNo && x.serp_mat_no == value.SerpMatNo);

                        if (material == null)
                        {
                            errorList.Add((value, "找不到符合 MatNo 與 SerpMatNo 的物料資料。"));
                            continue;
                        }
                    }
                    else if (!string.IsNullOrWhiteSpace(value.MatNo))
                    {
                        material = await _context.matm.FirstOrDefaultAsync(x => x.mat_no == value.MatNo);

                        if (material == null)
                        {
                            errorList.Add((value, "找不到符合 MatNo 的物料資料。"));
                            continue;
                        }
                    }
                    else if (!string.IsNullOrWhiteSpace(value.SerpMatNo))
                    {
                        material = await _context.matm.FirstOrDefaultAsync(x => x.serp_mat_no == value.SerpMatNo);

                        if (material == null)
                        {
                            errorList.Add((value, "找不到符合 SerpMatNo 的物料資料。"));
                            continue;
                        }
                    }


                    // 動態必填欄位（用於檢查與避免更新）
                    var requiredCoreFields = await _context.pdm_namevalue_new
                        .Where(x => x.fact_no == value.DevFactoryNo && x.group_key.Trim() == "mat_key" && x.status == "Y")
                        .Select(x => x.value_desc.Trim().ToLower())
                        .ToListAsync();

                    var coreFieldSet = new HashSet<string>(requiredCoreFields.Select(f => ToCamelCase(f)));

                    foreach (var field in requiredCoreFields)
                    {
                        string camelCaseField = ToCamelCase(field);
                        var prop = typeof(MaterialUpdateParameter).GetProperties()
                            .FirstOrDefault(p => p.Name.Equals(camelCaseField, StringComparison.OrdinalIgnoreCase));
                        var fieldValue = prop?.GetValue(value)?.ToString();

                        if (string.IsNullOrWhiteSpace(fieldValue))
                            missingFields.Add(camelCaseField);
                    }

                    if (missingFields.Any())
                    {
                        errorList.Add((value, $"缺少必填欄位或工廠核心值欄位：{string.Join(", ", missingFields)}"));
                        continue;
                    }

                    // 驗證：SERP 異動中
                    if (!string.IsNullOrWhiteSpace(material.trans_id) || material.order_status == "INPRG")
                    {
                        errorList.Add((value, "該筆資料 SERP 異動尚未處理完畢不可修改。"));
                        continue;
                    }

                    // 驗證：locked == Y
                    if (material.locked == 'Y')
                    {
                        if (value.ScmBclassNo?.Split('-')[0]?.Trim() != material.scm_bclass_no ||
                            value.ScmMclassNo?.Split('-')[0]?.Trim() != material.scm_mclass_no)
                        {
                            errorList.Add((value, "該筆資料為鎖定狀態，ScmBclassNo、ScmMclassNo 不可修改。"));
                            continue;
                        }
                    }

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
                            errorList.Add((value, $"{fieldName} 欄位{reason}"));
                            goto SkipUpdate;
                        }
                    }

                    // 顏色欄位互斥檢查
                    if (!string.IsNullOrWhiteSpace(value.ColorNo) ^ !string.IsNullOrWhiteSpace(value.ColorNm))
                    {
                        errorList.Add((value, "ColorNo 與 ColorNm 必須同時填寫或同時留空。"));
                        continue;
                    }

                    // 重複 mat_no（排除自身）
                    if (!string.IsNullOrWhiteSpace(value.MatNo))
                    {
                        var exists = await _context.matm
                            .Where(x => x.mat_no == value.MatNo && x.mat_id != material.mat_id)
                            .Select(x => new { x.mat_no, x.mat_full_nm })
                            .FirstOrDefaultAsync();

                        if (exists != null)
                        {
                            errorList.Add((value, $"已存在物料 PDM 料號 [{exists.mat_no}]，物料完整說明：[{exists.mat_full_nm}]"));
                            continue;
                        }
                    }

                    // 更新欄位（避開核心欄位）
                    if (!coreFieldSet.Contains(nameof(value.MatFullNm))) material.mat_full_nm = value.MatFullNm?.Trim();
                    if (!coreFieldSet.Contains(nameof(value.ColorNo))) material.color_no = value.ColorNo?.Trim();
                    if (!coreFieldSet.Contains(nameof(value.ColorNm))) material.color_nm = value.ColorNm?.Trim();
                    if (!coreFieldSet.Contains(nameof(value.Standard))) material.standard = value.Standard?.Trim();
                    if (!coreFieldSet.Contains(nameof(value.Matnr))) material.matnr = value.Matnr?.Trim();
                    if (!coreFieldSet.Contains(nameof(value.ScmBclassNo))) material.scm_bclass_no = value.ScmBclassNo?.Split('-')[0]?.Trim();
                    if (!coreFieldSet.Contains(nameof(value.ScmMclassNo))) material.scm_mclass_no = value.ScmMclassNo?.Split('-')[0]?.Trim();
                    if (!coreFieldSet.Contains(nameof(value.ScmSclassNo))) material.scm_sclass_no = value.ScmSclassNo?.Split('-')[0]?.Trim();
                    if (!coreFieldSet.Contains(nameof(value.Memo))) material.memo = value.Memo?.Trim();

                    material.modify_user = pccuid;
                    material.modify_tm = DateTime.Now;

                    // 停用時間處理
                    if (!coreFieldSet.Contains(nameof(value.Status)) && material.status != value.Status)
                    {
                        if (value.Status == "N")
                            material.stop_date = new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds();
                        else if (value.Status == "Y")
                            material.stop_date = null;
                    }

                    updateList.Add(material);
                }
                catch (Exception ex)
                {
                    errorList.Add((value, $"系統錯誤：{ex.Message}"));
                }

            SkipUpdate:
                continue;
            }

            // 若有錯誤，整批不寫入
            if (errorList.Any())
                return (false, new(), errorList);

            // 全部無誤，才寫入資料庫
            try
            {
                await _context.SaveChangesAsync();

                var updatedIds = updateList.Select(x => x.mat_id).ToList();

                var dtos = await (from m in _context.matm
                                  where updatedIds.Contains(m.mat_id)

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
                                  }).ToListAsync();


                return (true, dtos, new());
            }
            catch (Exception ex)
            {
                var message = ex.InnerException?.Message ?? ex.Message;

                var failed = updateList.Select(i => (
                    new MaterialUpdateParameter { MatNo = i.mat_no, MatFullNm = i.mat_full_nm },
                    $"整批更新失敗：{message}"
                )).ToList();

                return (false, new(), failed);
            }
        }
    }
}
