using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using PDMApp.Dtos.Spec;

namespace PDMApp.Utils
{
    public class ExportExcel_NPOI
    {
        public byte[] ExportMasterDetailToExcel(IEnumerable<pdm_spec_headDto> masterData)
        {
            using var workbook = new XSSFWorkbook();
            var sheet = workbook.CreateSheet("SpecSearch");
            int rowIndex = 0;

            // 1. 主檔標題
            var headerRow = sheet.CreateRow(rowIndex++);
            headerRow.CreateCell(0).SetCellValue("YEAR");
            headerRow.CreateCell(1).SetCellValue("SEASON");
            headerRow.CreateCell(2).SetCellValue("STAGE");
            headerRow.CreateCell(3).SetCellValue("MOLD_NO");
            headerRow.CreateCell(4).SetCellValue("FACTORY1/2/3");
            headerRow.CreateCell(5).SetCellValue("ITEM_NAME_ENG");
            headerRow.CreateCell(6).SetCellValue("ITEM_NAME_JPN");
            headerRow.CreateCell(7).SetCellValue("ITEM_NO");
            headerRow.CreateCell(8).SetCellValue("DEV_NO");
            headerRow.CreateCell(9).SetCellValue("DEV_COLOR");
            headerRow.CreateCell(10).SetCellValue("COLOR_NO");
            headerRow.CreateCell(11).SetCellValue("PART_NO");
            headerRow.CreateCell(12).SetCellValue("PARTS");
            headerRow.CreateCell(13).SetCellValue("MOLDNO");
            headerRow.CreateCell(14).SetCellValue("MATERIAL NO");
            headerRow.CreateCell(15).SetCellValue("MATERIAL");
            headerRow.CreateCell(16).SetCellValue("Sub Material/Remarks");
            headerRow.CreateCell(17).SetCellValue("STANDARD");
            headerRow.CreateCell(18).SetCellValue("SUPPLIER");
            headerRow.CreateCell(19).SetCellValue("COLORS");
            headerRow.CreateCell(20).SetCellValue("MEMO");
            headerRow.CreateCell(21).SetCellValue("HC/HA");
            headerRow.CreateCell(22).SetCellValue("SEC");
            headerRow.CreateCell(23).SetCellValue("WIDTH");

            // 2. 填入主檔資料
            foreach (var master in masterData)
            {
                //var row = sheet.CreateRow(rowIndex++);
                // 4. 填入子檔資料
                foreach (var detail in master.pdm_Spec_ItemDtos)
                {
                    var row = sheet.CreateRow(rowIndex++);
                    //var detailRow = row1;
                    row.CreateCell(0).SetCellValue(master.Year);
                    row.CreateCell(1).SetCellValue(master.Season);
                    row.CreateCell(2).SetCellValue(master.Stage);
                    row.CreateCell(3).SetCellValue(master.MoldNo);
                    row.CreateCell(4).SetCellValue(master.Factory);
                    row.CreateCell(5).SetCellValue(master.ItemNameEng);
                    row.CreateCell(6).SetCellValue(master.ItemNameJpn);
                    row.CreateCell(7).SetCellValue(master.ItemNo);
                    row.CreateCell(8).SetCellValue(master.DevNo);
                    row.CreateCell(9).SetCellValue(master.DevColorDispName);
                    row.CreateCell(10).SetCellValue(master.ColorNo);
                    row.CreateCell(11).SetCellValue(detail.ActNo);
                    row.CreateCell(12).SetCellValue(detail.Parts);
                    row.CreateCell(13).SetCellValue(detail.MoldNo);
                    row.CreateCell(14).SetCellValue(detail.MaterialNo);
                    row.CreateCell(15).SetCellValue(detail.Material);
                    row.CreateCell(16).SetCellValue(detail.SubMaterial);
                    row.CreateCell(17).SetCellValue(detail.Standard);
                    row.CreateCell(18).SetCellValue(detail.Supplier);
                    row.CreateCell(19).SetCellValue(detail.Colors);
                    row.CreateCell(20).SetCellValue(detail.Memo);
                    row.CreateCell(21).SetCellValue(detail.Hcha);
                    row.CreateCell(22).SetCellValue(detail.Sec);
                    row.CreateCell(23).SetCellValue(detail.Width);
                }
            }

            // 5. 將 Excel 輸出到記憶體
            using var memoryStream = new MemoryStream();
            workbook.Write(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
