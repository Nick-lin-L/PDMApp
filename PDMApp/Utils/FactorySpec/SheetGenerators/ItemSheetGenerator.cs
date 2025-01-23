using ClosedXML.Excel;
using Dtos.FactorySpec;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Utils.FactorySpec.SheetGenerators
{
    public class ItemSheetGenerator<T>
    {
        public void GenerateSheet(XLWorkbook workbook, string sheetName, IEnumerable<T> data)
        {
            var worksheet = workbook.Worksheets.Add(sheetName);

            int row = 1; // 起始行       
            int pageLimit = 42; // 每頁行數限制

            // 添加表頭
            row = AddSheetHeader(worksheet, data, row, pageLimit);

            // 添加表身
            row = AddSheetBody(worksheet, data, row, pageLimit);

            // 添加表尾
            row = AddSheetFooter(worksheet, data, row);

            // 關閉整個工作表的網格線
            worksheet.ShowGridLines = false;
        }

        private int AddSheetHeader(IXLWorksheet worksheet, IEnumerable<T> data, int startRow, int pageLimit)
        {
            // 從 query (data.First) 提取 MailTo, MailCC, Stage 值
            var firstItem = data.First(); // 假設數據至少有一筆                
            var mailTo = firstItem.GetType().GetProperty("MailTo")?.GetValue(firstItem, null)?.ToString() ?? "";
            var mailCC = firstItem.GetType().GetProperty("MailCC")?.GetValue(firstItem, null)?.ToString() ?? "";
            var stage = firstItem.GetType().GetProperty("Stage")?.GetValue(firstItem, null)?.ToString() ?? "";
            var createTime = firstItem.GetType().GetProperty("CreateTime")?.GetValue(firstItem, null)?.ToString() ?? "";
            var devNo = firstItem.GetType().GetProperty("DevNo")?.GetValue(firstItem, null)?.ToString() ?? "";
            var refDevNo = firstItem.GetType().GetProperty("RefDevNo")?.GetValue(firstItem, null)?.ToString() ?? ""; // 開發代號
            var itemNo = firstItem.GetType().GetProperty("ItemNo")?.GetValue(firstItem, null)?.ToString() ?? ""; // 型體代號
            var colorNo = firstItem.GetType().GetProperty("ColorNo")?.GetValue(firstItem, null)?.ToString() ?? ""; // 正式色號
            var colorNameChn = firstItem.GetType().GetProperty("ColorNameChn")?.GetValue(firstItem, null)?.ToString() ?? ""; // 配色中文名稱
            var factoryMoldNo1 = firstItem.GetType().GetProperty("FactoryMoldNo1")?.GetValue(firstItem, null)?.ToString() ?? ""; // 底模代號
            var lastNo1 = firstItem.GetType().GetProperty("LastNo1")?.GetValue(firstItem, null)?.ToString() ?? ""; // 楦頭代號
            var createUser = firstItem.GetType().GetProperty("CreateUser")?.GetValue(firstItem, null)?.ToString() ?? ""; // 製表者
            var itemNameEng = firstItem.GetType().GetProperty("ItemNameEng")?.GetValue(firstItem, null)?.ToString() ?? "";
            var sampleSize = firstItem.GetType().GetProperty("SampleSize")?.GetValue(firstItem, null)?.ToString() ?? "";
            var heelHeight = firstItem.GetType().GetProperty("HeelHeight")?.GetValue(firstItem, null)?.ToString() ?? "";
            var colorNameEng = firstItem.GetType().GetProperty("ColorEng")?.GetValue(firstItem, null)?.ToString() ?? "";

            int dataCount = data.Count();// 計算筆數

            // 計算總頁數
            int totalPages = (int)Math.Ceiling((double)dataCount / pageLimit);

            // 用於支持多頁格式的頁碼
            int currentPage = (startRow / pageLimit) + 1; // 計算當前頁數
            string page = $"P.{currentPage}/{totalPages}";

            // 設定頁面為直向 A4 紙張
            worksheet.PageSetup.PageOrientation = XLPageOrientation.Portrait; // 直向
            worksheet.PageSetup.PaperSize = XLPaperSize.A4Paper; // 設定為 A4 紙張

            // 調整頁邊距
            worksheet.PageSetup.Margins.Left = 0.3;
            worksheet.PageSetup.Margins.Right = 0.3;
            worksheet.PageSetup.Margins.Top = 0.5;
            worksheet.PageSetup.Margins.Bottom = 1.0;
            worksheet.PageSetup.PagesWide = 1; // 確保一頁寬

            // 設定欄的寬度
            worksheet.Column("A").Width = 4;    // 代號
            worksheet.Column("B").Width = 11;   // 部位名稱
            worksheet.Column("C").Width = 4;    // No
            worksheet.Column("D").Width = 10;   // 材質說明
            worksheet.Column("E").Width = 9;   // 材質說明
            worksheet.Column("F").Width = 9;   // 材質說明
            worksheet.Column("G").Width = 11;   // 材質說明
            worksheet.Column("H").Width = 15;   // 材質說明
            worksheet.Column("I").Width = 15;   // A
            worksheet.Column("J").Width = 6;    // 規格
            worksheet.Column("K").Width = 6;    // hc/ha
            worksheet.Column("L").Width = 6;    // sec
            worksheet.Column("M").Width = 6;    // 供應商

            // 動態行起點
            int row = startRow;

            // 第一行: TO 和 CC
            worksheet.Cell(row, 1).Value = $"TO: {mailTo}    CC: {mailCC}";
            worksheet.Range(row, 1, row, 13).Merge();
            worksheet.Cell(row, 1).Style.Font.FontSize = 10;
            worksheet.Cell(row, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            worksheet.Cell(row, 1).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            row++;

            // 第二行: 鞋型說明書
            worksheet.Cell(row, 1).Value = "鞋 型 說 明 書";
            worksheet.Range(row, 1, row, 11).Merge();
            worksheet.Cell(row, 1).Style.Font.FontSize = 20;
            worksheet.Cell(row, 1).Style.Font.Bold = true;
            worksheet.Cell(row, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell(row, 1).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Row(row).Height = 27.75; // 調整行高

            // 第二行: Stage
            worksheet.Cell(row, 12).Value = stage;
            worksheet.Range(row, 12, row, 13).Merge();
            worksheet.Cell(row, 12).Style.Font.FontSize = 16;
            worksheet.Cell(row, 12).Style.Font.Bold = true;
            worksheet.Cell(row, 12).Style.Font.FontColor = XLColor.Red;
            worksheet.Cell(row, 12).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell(row, 12).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            row++;

            // 第三行: CreateTime 和 Page
            worksheet.Cell(row, 1).Value = createTime;
            worksheet.Range(row, 1, row, 12).Merge(); // 合併第 1 到第 12 列的儲存格
            worksheet.Cell(row, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left; // CreateTime 靠左對齊
            worksheet.Cell(row, 1).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;  // 垂直置中
            worksheet.Cell(row, 1).Style.Font.FontSize = 10;

            // 設定第 13 列放置 Page 資料
            worksheet.Cell(row, 13).Value = page;
            worksheet.Cell(row, 13).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right; // Page 靠右對齊
            worksheet.Cell(row, 13).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;   // 垂直置中
            worksheet.Cell(row, 13).Style.Font.FontSize = 10;
            row++;

            // 第四列: 添加開發資訊
            startRow = row; // 使用動態 row 起點
            int endRow = startRow + 4;
            worksheet.Cell(startRow, 1).Value = $"開發NO.{devNo}\n({refDevNo})\n鞋型ART_NAME:\n{itemNameEng}"; // 顯示多行內容
            worksheet.Cell(startRow, 1).Style.Alignment.WrapText = true; // 啟用自動換行
            worksheet.Range(startRow, 1, endRow, 3).Merge(); 
            worksheet.Range(startRow, 1, endRow, 3).Style.Font.FontSize = 10;
            worksheet.Range(startRow, 1, endRow, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            worksheet.Range(startRow, 1, endRow, 3).Style.Alignment.Vertical = XLAlignmentVerticalValues.Top;

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

            // 第五列: 設定 RefDevNo、ItemNo、ColorNo、配色、FactoryMoldNo1、LastNo1、create_user

            worksheet.Cell(row, 4).Value = itemNo; // ItemNo
            worksheet.Cell(row, 4).Style.Font.FontSize = 10;
            worksheet.Cell(row, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell(row, 5).Value = colorNo; // ColorNo
            worksheet.Cell(row, 5).Style.Font.FontSize = 10;
            worksheet.Cell(row, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            // F5:G5 放 ColorNameChn，並替換 ; 為換行符號         
            worksheet.Cell(row, 6).Value = colorNameChn.Replace(";", "\n"); // 換行符號處理
            startRow = row;
            endRow = startRow + 2;
            worksheet.Range(startRow, 6, endRow, 7).Merge(); // 合併 F5 到 G7
            worksheet.Cell(startRow, 6).Style.Font.FontSize = 10;
            worksheet.Range(startRow, 6, endRow, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Range(startRow, 6, endRow, 7).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            //worksheet.Range("F5:G5").Style.Alignment.WrapText = true; // 啟用自動換行

            worksheet.Cell(row, 8).Value = factoryMoldNo1; // FactoryMoldNo1
            worksheet.Cell(row, 8).Style.Font.FontSize = 10;
            worksheet.Cell(row, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell(row, 9).Value = lastNo1; // LastNo1
            worksheet.Cell(row, 9).Style.Font.FontSize = 10;
            worksheet.Cell(row, 9).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            endRow = startRow + 3;
            worksheet.Range(startRow, 10, endRow, 11).Merge();

            // 合併 L5 到 M8
            worksheet.Cell(row, 12).Value = createUser; // 在合併後的儲存格中顯示值
            endRow = startRow + 3;
            worksheet.Range(startRow, 12, endRow, 13).Merge();
            worksheet.Cell(startRow, 12).Style.Font.FontSize = 10;
            worksheet.Range(startRow, 12, endRow, 13).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Range(startRow, 12, endRow, 13).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            row++;

            // 第六列
            worksheet.Cell(row, 4).Value = $"SIZE: {sampleSize}";
            startRow = row;
            endRow = startRow + 1;
            worksheet.Range(startRow, 4, endRow, 5).Merge();
            worksheet.Cell(startRow, 4).Style.Font.FontSize = 10;
            worksheet.Range(startRow, 4, endRow, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Range(startRow, 4, endRow, 5).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            row++;
            row++;

            // 第八列: D8:E8 合併並放 "後高:+{HeelHeight}+mm"
            worksheet.Cell(row, 4).Value = $"後高:{heelHeight}mm"; // 替換 {heelHeight} 為實際變數值
            worksheet.Range(row, 4, row, 5).Merge();
            worksheet.Cell(row, 4).Style.Font.FontSize = 10;
            worksheet.Range(row, 4, row, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Range(row, 4, row, 5).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            // 第八列: F8:G8 合併並放英文配色
            worksheet.Cell(row, 6).Value = "英文配色";
            worksheet.Range(row, 6, row, 7).Merge();
            worksheet.Cell(row, 6).Style.Font.FontSize = 10;
            worksheet.Range(row, 6, row, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Range(row, 6, row, 7).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell(row, 8).Value = colorNameEng;
            worksheet.Range(row, 8, row, 9).Merge();
            worksheet.Cell(row, 8).Style.Font.FontSize = 10;

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

            // 將泛型資料轉型為具體型別，先根據 PartClass 排序，再根據 Seqno 排序
            var specificData = data.Cast<ItemSheetDTO>().OrderBy(item => item.PartClass).ThenBy(item => item.Seqno);

            int defaultFontSize = 10; // 預設字體大小為 10
            int mergeStartRow = -1;   // 用於追蹤合併的起始行
            string previousParts = null; // 用於記錄上一行的 Parts 值

            // 定義欄位名稱
            worksheet.Cell(row, 1).Value = "代號";        // Type
            worksheet.Cell(row, 2).Value = "部位名稱";   // Parts
            worksheet.Cell(row, 3).Value = "NO.";        // No
            worksheet.Range(row, 4, row, 8).Merge();     // 合併儲存格
            worksheet.Cell(row, 4).Value = "材質說明";  // Material
            worksheet.Cell(row, 9).Value = "A";          // Colors
            worksheet.Cell(row, 10).Value = "規格";      // Standard
            worksheet.Cell(row, 11).Value = "hc/ha";     // Hcha
            worksheet.Cell(row, 12).Value = "sec";       // Sec
            worksheet.Cell(row, 13).Value = "供應商";    // Supplier

            // 設定標題字體大小
            worksheet.Row(row).Style.Font.FontSize = 10;

            // 整行置中對齊
            worksheet.Row(row).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            row++; // 下一行開始填充資料

            // 填充資料
            foreach (var item in specificData)
            {
                // 檢查是否需要分頁
                if ((row - startRow) % pageLimit == 0)
                {
                    // 結束未完成的合併範圍
                    if (mergeStartRow != -1)
                    {
                        worksheet.Range(mergeStartRow, 1, row - 1, 1).Merge();
                        worksheet.Range(mergeStartRow, 2, row - 1, 2).Merge();
                        worksheet.Range(mergeStartRow, 3, row - 1, 3).Merge();
                        mergeStartRow = -1;
                    }

                    // 在換頁之前先添加整體外框
                    worksheet.Range(startRow, 1, row - 1, 13).Style.Border.OutsideBorder = XLBorderStyleValues.Double;
                    worksheet.Range(startRow, 1, row - 1, 13).Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    //分頁
                    worksheet.PageSetup.AddHorizontalPageBreak(row - 1);

                    // 添加表頭   
                    row = AddSheetHeader(worksheet, data, row, pageLimit);
                    worksheet.Cell(row, 1).Value = "代號";        // Type
                    worksheet.Cell(row, 2).Value = "部位名稱";   // Parts
                    worksheet.Cell(row, 3).Value = "NO.";        // No
                    worksheet.Range(row, 4, row, 8).Merge();     // 合併儲存格
                    worksheet.Cell(row, 4).Value = "材質說明";  // Material
                    worksheet.Cell(row, 9).Value = "A";          // Colors
                    worksheet.Cell(row, 10).Value = "規格";      // Standard
                    worksheet.Cell(row, 11).Value = "hc/ha";     // Hcha
                    worksheet.Cell(row, 12).Value = "sec";       // Sec
                    worksheet.Cell(row, 13).Value = "供應商";    // Supplier

                    // 設定標題字體大小
                    worksheet.Row(row).Style.Font.FontSize = 10;
                    worksheet.Row(row).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    startRow = row; // 更新起始行
                    row++; // 下一行

                }

                // 確定當前行的合併條件
                if (!string.IsNullOrEmpty(previousParts) && string.IsNullOrEmpty(item.Parts) && string.IsNullOrEmpty(item.No) && worksheet.Cell(row - 1, 1).Value.ToString() != "代號")
                {
                    // 如果上一行有值且當前行為 null，開始合併
                    if (mergeStartRow == -1)
                    {
                        mergeStartRow = row - 1; // 記錄上一行為起始行
                    }

                    // 合併範圍
                    worksheet.Range(mergeStartRow, 1, row, 1).Merge(); // 合併 Type
                    worksheet.Range(mergeStartRow, 2, row, 2).Merge(); // 合併 Parts
                    worksheet.Range(mergeStartRow, 3, row, 3).Merge(); // 合併 No
                }
                else if (string.IsNullOrEmpty(previousParts) && string.IsNullOrEmpty(item.Parts) && worksheet.Cell(row - 1, 1).Value.ToString() != "代號")
                {
                    // 當前行和上一行都是 null，擴展合併範圍
                    if (mergeStartRow == -1)
                    {
                        mergeStartRow = row - 1; // 記錄上一行為起始行
                    }

                    // 合併範圍
                    worksheet.Range(mergeStartRow, 1, row, 1).Merge(); // 合併 Type
                    worksheet.Range(mergeStartRow, 2, row, 2).Merge(); // 合併 Parts
                    worksheet.Range(mergeStartRow, 3, row, 3).Merge(); // 合併 No
                }
                else
                {
                    // 如果條件不符合，重置合併範圍
                    mergeStartRow = -1;
                }

                // 更新上一行的 Parts 值
                previousParts = item.Parts;

                // 填充資料
                worksheet.Cell(row, 1).Value = item.Type; // 代號
                worksheet.Cell(row, 1).Style.Font.FontSize = 12; // 字體放大到 15

                // 部位名稱超過 13 個字元字體變 8
                if (!string.IsNullOrEmpty(item.Parts) && item.Parts.Length > 7)
                {
                    worksheet.Cell(row, 2).Style.Font.FontSize = 6; // 設定字體大小為 6
                }
                else
                {
                    worksheet.Cell(row, 2).Style.Font.FontSize = defaultFontSize; // 預設字體大小
                }
                worksheet.Cell(row, 2).Value = item.Parts; // 部位名稱
                worksheet.Cell(row, 3).Value = item.No;    // No

                // 材質說明 (合併儲存格並靠左對齊)
                worksheet.Range(row, 4, row, 8).Merge();
                worksheet.Cell(row, 4).Value = item.Material;
                worksheet.Cell(row, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left; // 靠左對齊

                // Material 超過 66 個字元字體變 8
                if (!string.IsNullOrEmpty(item.Material) && item.Material.Length > 66)
                {
                    worksheet.Cell(row, 4).Style.Font.FontSize = 8; // 設定字體大小為 8
                }
                else
                {
                    worksheet.Cell(row, 4).Style.Font.FontSize = defaultFontSize; // 預設字體大小
                }

                worksheet.Cell(row, 9).Value = item.Colors; // A
                worksheet.Cell(row, 10).Value = item.Standard; // 規格

                // 如果“規格”內容長度超過 6 個字，字體大小變 6
                if (!string.IsNullOrEmpty(item.Standard) && item.Standard.Length > 6)
                {
                    worksheet.Cell(row, 10).Style.Font.FontSize = 6; // 設定字體大小為 6
                }
                else
                {
                    worksheet.Cell(row, 10).Style.Font.FontSize = defaultFontSize; // 預設字體大小
                }

                worksheet.Cell(row, 11).Value = item.Hcha; // hc/ha
                worksheet.Cell(row, 12).Value = item.Sec;  // Sec

                worksheet.Cell(row, 13).Value = item.Supplier; // 供應商

                // Supplier 超過 3 個字元字體變 8
                if (!string.IsNullOrEmpty(item.Supplier) && item.Supplier.Length > 3)
                {
                    worksheet.Cell(row, 13).Style.Font.FontSize = 7; // 設定字體大小為 7
                }
                else
                {
                    worksheet.Cell(row, 13).Style.Font.FontSize = defaultFontSize; // 預設字體大小
                }

                // Colors 超過 13 個字元字體變 8
                if (!string.IsNullOrEmpty(item.Colors) && item.Colors.Length > 13)
                {
                    worksheet.Cell(row, 9).Style.Font.FontSize = 6; // 設定字體大小為 6
                }
                else
                {
                    worksheet.Cell(row, 9).Style.Font.FontSize = defaultFontSize; // 預設字體大小
                }

                // 為每個儲存格單獨設定屬性（僅設置對齊，不影響字體大小）
                for (int col = 1; col <= 13; col++) // 遍歷每一列
                {
                    if (col != 4) // 除了材質說明欄位外
                    {
                        worksheet.Cell(row, col).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    }

                    // 針對未特殊處理的欄位設置預設字體大小
                    if (col != 1 && col != 2 && col != 4 && col != 9 && col != 10 && col != 13) // 跳過已特殊處理的欄位
                    {
                        worksheet.Cell(row, col).Style.Font.FontSize = defaultFontSize;
                    }
                }

                row++; // 移動到下一行
            }

            // 添加整體外框
            worksheet.Range(startRow, 1, row - 1, 13).Style.Border.OutsideBorder = XLBorderStyleValues.Double;
            worksheet.Range(startRow, 1, row - 1, 13).Style.Border.InsideBorder = XLBorderStyleValues.Thin;

            return row; // 返回下一行的索引
        }

        private int AddSheetFooter(IXLWorksheet worksheet, IEnumerable<T> data, int startRow)
        {
            int row = startRow;

            var firstItem = data.First(); // 假設數據至少有一筆                
            var remarksProhibit = firstItem.GetType().GetProperty("RemarksProhibit")?.GetValue(firstItem, null)?.ToString() ?? "";

            // 添加一些表尾範例數據
            worksheet.Cell(row, 1).Value = remarksProhibit;
            worksheet.Range(row, 1, row+5, 13).Merge();     // 合併儲存格

            // 設置樣式
            worksheet.Row(row).Style.Font.Bold = true; // 設定粗體
            worksheet.Row(row).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            worksheet.Row(row).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            // 清除原有的邊框
            worksheet.Range(row - 1, 1, row + 5, 13).Style.Border.BottomBorder = XLBorderStyleValues.None;

            // 設置外框樣式
            worksheet.Range(row, 1, row + 5, 13).Style.Border.OutsideBorder = XLBorderStyleValues.Double;
            worksheet.Range(row, 1, row + 5, 13).FirstRow().Style.Border.TopBorder = XLBorderStyleValues.Thin;
            row++;
            return row;
        }
    }
}
