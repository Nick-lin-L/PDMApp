using ClosedXML.Excel;
using System.Collections.Generic;

namespace PDMApp.Service.FactorySpec.SheetGenerators
{
    public class UpperFigureSheetGenerator<T>
    {
        public void GenerateSheet(XLWorkbook workbook, string sheetName, IEnumerable<T> data)
        {
            var worksheet = workbook.Worksheets.Add(sheetName);

            int row = 1; // 起始行
            int pageLimit = 47; // 每頁行數限制

            // 添加表頭
            row = AddSheetHeader(worksheet, data, row, pageLimit);

            // 添加表身
            row = AddSheetBody(worksheet, data, row, pageLimit);

            // 添加表尾
            //row = AddSheetFooter(worksheet, data, row);

            // 關閉整個工作表的網格線
            worksheet.ShowGridLines = false;
        }

        private int AddSheetHeader(IXLWorksheet worksheet, IEnumerable<T> data, int startRow, int pageLimit)
        {

            // 設定頁面為直向 A4 紙張
            worksheet.PageSetup.PageOrientation = XLPageOrientation.Portrait; // 直向
            worksheet.PageSetup.PaperSize = XLPaperSize.A4Paper; // 設定為 A4 紙張

            // 設定欄的寬度
            worksheet.Column("A").Width = 10;   
            worksheet.Column("B").Width = 10;   
            worksheet.Column("C").Width = 10;    
            worksheet.Column("D").Width = 10;  
            worksheet.Column("E").Width = 9;   
            worksheet.Column("F").Width = 9;   
            worksheet.Column("G").Width = 11;   
            worksheet.Column("H").Width = 30;   
            worksheet.Column("I").Width = 15;  
            worksheet.Column("J").Width = 6;    
            worksheet.Column("K").Width = 6;    
            worksheet.Column("L").Width = 6;    
            worksheet.Column("M").Width = 6;   

            worksheet.PageSetup.FitToPages(1, 1); // 將工作表內容縮放到單一頁面

            // 動態行起點
            int row = startRow;

            // 第一行: 
            row++;

            // 第二行: 鞋型說明書
            worksheet.Cell(row, 1).Value = "鞋 型 說 明 書";
            worksheet.Range(row, 1, row, 11).Merge();
            worksheet.Cell(row, 1).Style.Font.FontSize = 20;
            worksheet.Cell(row, 1).Style.Font.Bold = true;
            worksheet.Cell(row, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell(row, 1).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Row(row).Height = 27.75; // 調整行高

            // 第二行: 
            worksheet.Range(row, 12, row, 13).Merge();
            row++;

            // 第三行: 
            worksheet.Range(row, 1, row, 12).Merge(); // 合併第 1 到第 12 列的儲存格
            row++;

            // 第四列: 添加開發資訊
            startRow = row; // 使用動態 row 起點
            int endRow = startRow + 4;
            worksheet.Range(startRow, 1, endRow, 3).Merge(); // 合併 A4 到 C8

            worksheet.Cell(row, 4).Value = "型體代號"; // 型體代號
            worksheet.Cell(row, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell(row, 4).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Cell(row, 5).Value = "正式色號"; // 正式色號
            worksheet.Cell(row, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell(row, 5).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Cell(row, 6).Value = "配色";
            worksheet.Range(row, 6, row, 7).Merge(); // 合併 F4 到 G4
            worksheet.Range(row, 6, row, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Range(row, 6, row, 7).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            // H4 底模代號
            worksheet.Cell(row, 8).Value = "底模代號";
            worksheet.Cell(row, 8).Style.Font.FontSize = 10;
            worksheet.Cell(row, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell(row, 8).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            // I4 楦頭代號
            worksheet.Cell(row, 9).Value = "楦頭代號";
            worksheet.Cell(row, 9).Style.Font.FontSize = 10;
            worksheet.Cell(row, 9).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell(row, 9).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            // J4 主管簽署
            worksheet.Cell(row, 10).Value = "主管簽署";
            worksheet.Range(row, 10, row, 11).Merge();
            worksheet.Cell(row, 10).Style.Font.FontSize = 10;
            worksheet.Cell(row, 10).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell(row, 10).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Cell(row, 12).Value = "製表者"; // 製表者
            worksheet.Range(row, 12, row, 13).Merge();
            worksheet.Cell(row, 12).Style.Font.FontSize = 10;
            worksheet.Cell(row, 12).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell(row, 12).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            row++;

            // 第五列: 
            startRow = row;
            endRow = startRow + 2;
            worksheet.Range(startRow, 6, endRow, 7).Merge(); 
            endRow = startRow + 3;
            worksheet.Range(startRow, 10, endRow, 11).Merge();
            endRow = startRow + 3;
            worksheet.Range(startRow, 12, endRow, 13).Merge();
            row++;

            // 第六列 
            startRow = row;
            endRow = startRow + 1;
            worksheet.Range(startRow, 4, endRow, 5).Merge();
            row++;
            row++;

            // 第八列: 
            worksheet.Range(row, 4, row, 5).Merge();
            worksheet.Cell(row, 4).Style.Font.FontSize = 10;

            // 第八列:     
            worksheet.Range(row, 6, row, 7).Merge();
            worksheet.Range(row, 8, row, 9).Merge();

            // 劃框線，樣式為雙線
            var range = worksheet.Range(row - 4, 1, row, 13);
            range.Style.Border.OutsideBorder = XLBorderStyleValues.Double; // 外框邊界
            range.Style.Border.InsideBorder = XLBorderStyleValues.Thin;  // 內部邊界
            row++;

            return row;
        }

        private int AddSheetBody(IXLWorksheet worksheet, IEnumerable<T> data, int startRow, int pageLimit)
        {
            int row = startRow;

            // 添加整體外框
            worksheet.Range(startRow, 1, row + 74, 13).Style.Border.OutsideBorder = XLBorderStyleValues.Double;

            return row; // 返回下一行的索引
        }

        private int AddSheetFooter(IXLWorksheet worksheet, IEnumerable<T> data, int startRow)
        {
            int row = startRow;

            // 添加一些表尾範例數據
           
            row++;
            return row;
        }
    }
}
