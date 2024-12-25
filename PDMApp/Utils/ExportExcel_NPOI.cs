using NPOI.SS.UserModel;
using NPOI.XSSF.Streaming;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using PDMApp.Dtos.Spec;
using NPOI.XSSF.UserModel;

namespace PDMApp.Utils
{
    public class ExportExcel_NPOI
    {
        public byte[] ExportMasterDetailToExcel(IEnumerable<pdm_spec_headDto> masterData)
        {
            using var workbook = new XSSFWorkbook();
            //using var workbook = new SXSSFWorkbook(100); // 設置快取大小 100 行，此宣告查詢速度快，但不知支援圖表與讀取只能匯出
            var sheet = workbook.CreateSheet("SpecSearch");
            int rowIndex = 0;

            // 主檔標題
            var headerRow = sheet.CreateRow(rowIndex++);
            string[] headers = {
                "YEAR", "SEASON", "STAGE", "MOLD_NO", "FACTORY1/2/3", "ITEM_NAME_ENG",
                "ITEM_NAME_JPN", "ITEM_NO", "DEV_NO", "DEV_COLOR", "COLOR_NO", "PART_NO",
                "PARTS", "MOLDNO", "MATERIAL NO", "MATERIAL", "Sub Material/Remarks", "STANDARD",
                "SUPPLIER", "COLORS", "MEMO", "HC/HA", "SEC", "WIDTH"
            };

            // 設置標題行樣式style
            var headerStyle = workbook.CreateCellStyle();
            headerStyle.Alignment = HorizontalAlignment.Center; // 置中對齊
            var font = workbook.CreateFont();
            font.IsBold = true; // 粗體字
            headerStyle.SetFont(font);

            // 套用style到標題並設置欄位寬度
            var columnWidths = new int[headers.Length];
            for (int i = 0; i < headers.Length; i++)
            {
                var cell = headerRow.CreateCell(i);
                cell.SetCellValue(headers[i]);
                cell.CellStyle = headerStyle; // 套用style
                columnWidths[i] = headers[i].Length; // 初始寬度設定為標題長度
            }

            // 寫入資料
            foreach (var master in masterData)
            {
                foreach (var detail in master.pdm_Spec_ItemDtos)
                {
                    var row = sheet.CreateRow(rowIndex++);
                    WithRowData(row, master, detail, columnWidths); // 呼叫函數填入資料、與調整欄位寬度
                }
            }

            // 設置每欄固定寬度
            for (int i = 0; i < columnWidths.Length; i++)
            {
                int adjustedWidth = System.Math.Min(255 * 256, (columnWidths[i] + 2) * 256); // 限制最大寬度
                sheet.SetColumnWidth(i, adjustedWidth); // 調整至Excel單位
            }

            // 匯出到記憶體
            using var memoryStream = new MemoryStream();
            workbook.Write(memoryStream, leaveOpen: false);
            workbook.Dispose(); // 關閉流式處理的快取
            return memoryStream.ToArray();
        }

        private static void WithRowData(IRow row, pdm_spec_headDto master, pdm_spec_itemDto detail, int[] columnWidths)
        {
            string[] values = {
                master.Year, master.Season, master.Stage, master.MoldNo, master.Factory,
                master.ItemNameEng, master.ItemNameJpn, master.ItemNo, master.DevNo,
                master.DevColorDispName, master.ColorNo, 
                
                detail.ActNo, detail.Parts, detail.MoldNo, detail.MaterialNo, 
                detail.Material, detail.SubMaterial, detail.Standard, 
                detail.Supplier, detail.Colors, detail.Memo, detail.Hcha, 
                detail.Sec, detail.Width
            };

            for (int i = 0; i < values.Length; i++)
            {
                row.CreateCell(i).SetCellValue(values[i]); // 寫入資料
                if (!string.IsNullOrEmpty(values[i]))
                {
                    columnWidths[i] = System.Math.Max(columnWidths[i], values[i].Length); // 更新欄位最大寬度
                }
            }
        }
    }
}
