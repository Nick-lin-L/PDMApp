using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using PDMApp.Models;
using PDMApp.Parameters.Basic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PDMApp.Service.Basic
{
    public static class MaterialImportPurchaseHelper
    {
        // 將欄位顯示名稱獨立成靜態字典
        private static readonly Dictionary<string, string> PropertyDisplayNames = new(StringComparer.OrdinalIgnoreCase)
        {
            ["SerpMatNo"] = "MATL No.",
            ["MatNo"] = "PLM MATL No.",
            ["OrderQty"] = "Order Qty.",
            ["Price"] = "Price",
            ["RequiredDate"] = "Required Date",
            ["Season"] = "Season",
            ["Stage"] = "Stage",
            ["Model"] = "Model",
            ["ArticleNo"] = "Article No.",
            ["Purpose"] = "Purpose",
            ["SrDetails"] = "SR Details",
            ["BuyerNote"] = "Buyer note",
            ["MaterialCategory"] = "Material Category",
            ["ColorSource"] = "Color Source",
            ["SampleOrder"] = "Sample Order",
            ["SoVersion"] = "SO Version",
            ["PartType"] = "Part Type",
            ["PartNo"] = "Part No.",
            ["PartName"] = "Part Name",
            ["PartNameZhTw"] = "Part Name (ZH_TW)",
            ["Gender"] = "Gender",
            ["SizeMap"] = "Size Map",
            ["McsNo"] = "MCS#",
            ["OneCOneSNo"] = "1C1S#",
            ["Memo"] = "Material Note",
            ["ProcNote"] = "Proc Note",
            ["TypeDefinition"] = "Type Definition",
            ["Category"] = "Category",
            ["DevStyle"] = "DevStyle",
            ["MoldNo"] = "Mold No.",
            ["Size"] = "Size",
            ["LastNo"] = "Last No.",
            ["Brand"] = "Brand",
            ["ProdCode"] = "Prod Code",
            ["MainFactory"] = "Main Factory",
            ["Team"] = "Team",
            ["Pm"] = "PM",
            ["MatNm"] = "MATL INFO",
            ["ColorNo"] = "COLOR NO",
            ["ColorNm"] = "COLOR INFO",
            ["Uom"] = "UOM",
            ["ScmBclassNo"] = "B CLASS",
            ["ScmMclassNo"] = "M CLASS",
            ["DevFactoryNo"] = "Dev Factory No."
        };

        private static readonly Dictionary<string, string> PropertyDisplayNamesZhTw = new(StringComparer.OrdinalIgnoreCase)
        {
            ["SerpMatNo"] = "物料編號",
            ["MatNo"] = "PLM物料編號",
            ["OrderQty"] = "採購數量",
            ["Price"] = "單價",
            ["RequiredDate"] = "需求日期",
            ["Season"] = "季節",
            ["Stage"] = "開發階段",
            ["Model"] = "Model",
            ["ArticleNo"] = "Article No.",
            ["Purpose"] = "開發目的",
            ["SrDetails"] = "樣品需求明細",
            ["BuyerNote"] = "採購備註",
            ["MaterialCategory"] = "材料類別",
            ["ColorSource"] = "色卡依據",
            ["SampleOrder"] = "樣品單號",
            ["SoVersion"] = "樣品單版本",
            ["PartType"] = "部位類型",
            ["PartNo"] = "部位代號",
            ["PartName"] = "部位名稱",
            ["PartNameZhTw"] = "部位中文名稱",
            ["Gender"] = "鞋性",
            ["SizeMap"] = "Size Map",
            ["McsNo"] = "物性標準",
            ["OneCOneSNo"] = "1C1S#",
            ["Memo"] = "材料備註",
            ["ProcNote"] = "加工備註",
            ["TypeDefinition"] = "困難度",
            ["Category"] = "Category",
            ["DevStyle"] = "DevStyle",
            ["MoldNo"] = "模號",
            ["Size"] = "SIZE",
            ["LastNo"] = "楦頭",
            ["Brand"] = "品牌",
            ["ProdCode"] = "量產代號",
            ["MainFactory"] = "量產工廠",
            ["Team"] = "Team",
            ["Pm"] = "開發員",
            ["MatNm"] = "物料說明",
            ["ColorNo"] = "顏色代號",
            ["ColorNm"] = "顏色說明",
            ["Uom"] = "單位",
            ["ScmBclassNo"] = "大分類",
            ["ScmMclassNo"] = "中分類",
            ["DevFactoryNo"] = "開發廠別"
        };


        // 必填欄位清單獨立成靜態 HashSet
        private static readonly HashSet<string> CheckFields = new(StringComparer.OrdinalIgnoreCase)
        {
            "SerpMatNo",
            "MatNo",
            "Memo",
            "MatNm",
            "ColorNo",
            "ColorNm",
            "Uom",
            "ScmBclassNo",
            "ScmMclassNo"
        };

        private static string SnakeToPascalCase(string snake)
        {
            if (string.IsNullOrEmpty(snake)) return snake;

            var parts = snake.Split('_');
            var pascal = string.Concat(parts.Select(p => char.ToUpperInvariant(p[0]) + p.Substring(1).ToLowerInvariant()));

            return pascal;
        }

        public static async Task<(bool isSuccess, MemoryStream stream)> GenerateMaterialPurchasePreviewExcelAsync(pcms_pdm_testContext _context, List<MaterialPurchaseParameter> parameters)
        {
            var ms = new MemoryStream();
            const string errorColumnName = "ErrorMessage";
            const string errorColumnZhTw = "錯誤訊息";

            using var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Preview");

            // 取得所有屬性，排除 DevFactoryNo（僅供查詢）
            var allProps = typeof(MaterialPurchaseParameter)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.Name != "DevFactoryNo")
                .ToArray();

            // 英文欄名列
            int colIdx = 1;
            foreach (var prop in allProps)
            {
                var name = PropertyDisplayNames.TryGetValue(prop.Name, out var display) ? display : prop.Name;
                ws.Cell(1, colIdx).Value = name;
                ws.Cell(1, colIdx).Style.Font.Bold = true;
                ws.Cell(1, colIdx).Style.Fill.BackgroundColor = XLColor.LightBlue;
                colIdx++;
            }
            ws.Cell(1, colIdx).Value = errorColumnName;
            ws.Cell(1, colIdx).Style.Font.Bold = true;
            ws.Cell(1, colIdx).Style.Fill.BackgroundColor = XLColor.LightBlue;

            // 中文欄名列
            colIdx = 1;
            foreach (var prop in allProps)
            {
                var nameZh = PropertyDisplayNamesZhTw.TryGetValue(prop.Name, out var displayZh) ? displayZh : prop.Name;
                ws.Cell(2, colIdx).Value = nameZh;
                ws.Cell(2, colIdx).Style.Font.Bold = true;
                ws.Cell(2, colIdx).Style.Fill.BackgroundColor = XLColor.LightGray;
                colIdx++;
            }
            ws.Cell(2, colIdx).Value = errorColumnZhTw;
            ws.Cell(2, colIdx).Style.Font.Bold = true;
            ws.Cell(2, colIdx).Style.Fill.BackgroundColor = XLColor.LightGray;

            // 預先驗證全部資料，若有錯誤則不補值
            var validated = new List<(MaterialPurchaseParameter item, List<string> errors)>();

            foreach (var item in parameters)
            {
                List<string> errors = new();
                string? devFactoryNo = item.DevFactoryNo?.Trim();

                // 取得該工廠設定的核心值 (snake_case)
                var requiredFieldsRaw = await _context.pdm_namevalue_new
                    .Where(nv => nv.fact_no == devFactoryNo && nv.group_key == "mat_key" && nv.status == "Y")
                    .Select(nv => nv.value_desc.Trim())
                    .ToListAsync();

                // 轉 PascalCase
                var requiredFieldsPascal = requiredFieldsRaw
                    .Select(SnakeToPascalCase)
                    .ToList();

                // MatNm 與 Uom 為必填
                if (string.IsNullOrWhiteSpace(item.MatNm))
                    errors.Add($"必填欄位[{PropertyDisplayNames.GetValueOrDefault("MatNm", "MatNm")}]缺少資料");
                if (string.IsNullOrWhiteSpace(item.Uom))
                    errors.Add($"必填欄位[{PropertyDisplayNames.GetValueOrDefault("Uom", "Uom")}]缺少資料");

                // 檢查核心值是否填寫
                foreach (var fieldPascal in requiredFieldsPascal)
                {
                    var prop = allProps.FirstOrDefault(p => p.Name.Equals(fieldPascal, StringComparison.OrdinalIgnoreCase));
                    if (prop == null) continue;

                    var val = prop.GetValue(item)?.ToString()?.Trim() ?? "";
                    if (string.IsNullOrWhiteSpace(val))
                    {
                        errors.Add($"必填欄位[{PropertyDisplayNames.GetValueOrDefault(fieldPascal, fieldPascal)}]缺少資料");
                    }
                }

                validated.Add((item, errors));
            }

            bool allValid = validated.All(x => x.errors.Count == 0);

            // 補資料（僅當整批皆有效）
            if (allValid)
            {
                foreach (var (item, _) in validated)
                {
                    string? devFactoryNo = item.DevFactoryNo?.Trim();

                    var requiredFieldsRaw = await _context.pdm_namevalue_new
                        .Where(nv => nv.fact_no == devFactoryNo && nv.group_key == "mat_key" && nv.status == "Y")
                        .Select(nv => nv.value_desc.Trim())
                        .ToListAsync();

                    IQueryable<matm> query = _context.matm
                        .Where(m => m.mat_nm == item.MatNm && m.uom == item.Uom);

                    foreach (var coreSnake in requiredFieldsRaw)
                    {
                        var corePascal = SnakeToPascalCase(coreSnake);
                        var propCore = typeof(MaterialPurchaseParameter).GetProperty(corePascal);
                        if (propCore == null) continue;

                        var valCore = propCore.GetValue(item)?.ToString();
                        if (!string.IsNullOrWhiteSpace(valCore))
                        {
                            query = query.Where(m => EF.Property<string>(m, coreSnake) == valCore);
                        }
                    }

                    var matmData = await query.FirstOrDefaultAsync();
                    if (matmData != null)
                    {
                        item.SerpMatNo = matmData.serp_mat_no ?? "";
                        item.MatNo = matmData.mat_no ?? "";
                        item.Memo = matmData.memo ?? "";
                    }
                    else
                    {
                        var errorRecord = validated.First(v => v.item == item);
                        errorRecord.errors.Add("無法在資料庫找到對應資料");
                        allValid = false;
                    }
                }
            }

            // 寫入 Excel
            int rowIdx = 3;
            foreach (var (item, errors) in validated)
            {
                colIdx = 1;
                foreach (var prop in allProps)
                {
                    var val = prop.GetValue(item)?.ToString() ?? "";
                    ws.Cell(rowIdx, colIdx).Value = val;
                    colIdx++;
                }
                // 寫入錯誤訊息
                ws.Cell(rowIdx, colIdx).Value = string.Join("；", errors);
                rowIdx++;
            }

            // 調整欄寬
            ws.Columns().AdjustToContents();
            wb.SaveAs(ms);
            ms.Position = 0;

            return (allValid, ms);
        }

    }
}
