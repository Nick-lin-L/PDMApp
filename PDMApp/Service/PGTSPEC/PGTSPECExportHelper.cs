using ClosedXML.Excel;
using System.Collections.Generic;
using System.IO;

namespace Service.PGTSPEC
{
    public static class PGTSPECExportHelper
    {
        public static byte[] ExportToExcel<T1>(IEnumerable<T1> itemData)
        {
            // 初始化 Excel Workbook
            using var workbook = new XLWorkbook();

            // 動態生成 "Item" 工作表
            var itemGenerator = new SheetGenerators.ItemSheetGenerator<T1>();
            itemGenerator.GenerateSheet(workbook, "Item", itemData);

            // 將 Excel 寫入記憶體流
            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray(); // 回傳 Excel byte array
        }

    }
}
