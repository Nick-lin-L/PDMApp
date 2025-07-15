using ClosedXML.Excel;
using System.Collections.Generic;
using System.IO;

namespace PDMApp.Service.FactorySpec
{
    public static class FactoryExportHelper
    {
        public static byte[] ExportToExcel<T1, T2>(IEnumerable<T1> itemData, IEnumerable<T2> standardData)
        {
            // 初始化 Excel Workbook
            using var workbook = new XLWorkbook();

            // 動態生成 "Item" 工作表
            var itemGenerator = new SheetGenerators.ItemSheetGenerator<T1>();
            itemGenerator.GenerateSheet(workbook, "Item", itemData);

            // 動態生成 "Standard" 工作表
            var standardGenerator = new SheetGenerators.StandardSheetGenerator<T2>();
            standardGenerator.GenerateSheet(workbook, "Standard", standardData);

            // 動態生成 "UPPER figure" 工作表
            var upperFigureGenerator = new SheetGenerators.UpperFigureSheetGenerator<object>();
            upperFigureGenerator.GenerateSheet(workbook, "UPPER figure", new List<object>());

            // 動態生成 "SKIVE" 工作表
            var skiveGenerator = new SheetGenerators.SkiveSheetGenerator<object>();
            skiveGenerator.GenerateSheet(workbook, "SKIVE", new List<object>());

            // 動態生成 "SOLE figure" 工作表
            var soleFigureGenerator = new SheetGenerators.SoleFigureSheetGenerator<object>();
            soleFigureGenerator.GenerateSheet(workbook, "SOLE figure", new List<object>());

            // 將 Excel 寫入記憶體流
            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray(); // 回傳 Excel byte array
        }

    }
}
