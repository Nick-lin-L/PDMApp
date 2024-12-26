using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using PDMApp.Models;
using System.IO;

namespace PDMApp.Utils
{
    public class ImportExcel_NPOI
    {

        private readonly pcms_pdm_testContext _pcms_Pdm_TestContext;

        public ImportExcel_NPOI (pcms_pdm_testContext pcms_Pdm_testContext)
        {
            _pcms_Pdm_TestContext = pcms_Pdm_testContext;
        }


        public void ProcessExcel(Stream fileStream, string fileName)
        {
            IWorkbook workbook;
            // 參考至https://medium.com/selectprogram/c-npoi-上傳excel檔案-並新增至資料庫-3fd6da9bb439
            // xls or xlsx
            if (fileName.EndsWith(".xlsx"))
                workbook = new XSSFWorkbook(fileStream);
            else if (fileName.EndsWith(".xls"))
                workbook = new HSSFWorkbook(fileStream);
            else
                throw new Exception("不支援的檔案格式");

            // 實體化 Table
            var tableAList = new List<pdm_spec_head_test>();
            var tableBList = new List<pdm_spec_head>();

            // 解析每個 Sheet
            for (int sheetIndex = 0; sheetIndex < workbook.NumberOfSheets; sheetIndex++)
            {
                ISheet sheet = workbook.GetSheetAt(sheetIndex);

                for (int rowIndex = sheet.FirstRowNum + 1; rowIndex <= sheet.LastRowNum; rowIndex++) // 假設第一行是標題
                {
                    IRow row = sheet.GetRow(rowIndex);
                    if (row == null) continue;

                    // 解析每一行的欄位，合併儲存格會被自動略過該欄位
                    var column1 = row.GetCell(0)?.ToString();
                    var column2 = row.GetCell(1)?.ToString();
                    var column3 = row.GetCell(2)?.ToString();
                    var column4 = row.GetCell(3)?.ToString();
                    var column5 = row.GetCell(4)?.ToString();
                    var column6 = row.GetCell(5)?.ToString();
                    // 建立 TableA 資料
                    var Pdm_spec_head_test = new pdm_spec_head_test
                    {
                        spec_m_id = column1,
                        devno = column3,
                        devcolorno = column2,
                        factory =column4,
                        stage = column5,
                        lasting = column6,
                    };
                    tableAList.Add(Pdm_spec_head_test);

                    /* 這段是手動SQL寫傳入變數
                       string sql = "INSERT INTO pdm_spec_head_test (spec_m_id, devno, devcolorno) VALUES ({0}, {1}, {2})";
                       _pcms_Pdm_TestContext.Database.ExecuteSqlRaw(sql, column1, column3, column2);
                       
                     
                      
                    // 多表寫入-TableB 資料
                    var Pdm_spec_head = new pdm_spec_head
                    {
                        devno = column2,
                        spec_m_id = column4
                    };
                    tableBList.Add(Pdm_spec_head);
                    */
                }
            }

            // 新增到資料庫
            _pcms_Pdm_TestContext.pdm_spec_head_test.AddRange(tableAList);
            //_pcms_Pdm_TestContext.pdm_spec_head.AddRange(tableBList);

            _pcms_Pdm_TestContext.SaveChanges();
        }


        // 取得合併儲存格的值
        private string GetCellValue(ISheet sheet, ICell cell)
        {
            // 檢查是否是合併儲存格
            foreach (var range in sheet.MergedRegions)
            {
                if (range.IsInRange(cell.RowIndex, cell.ColumnIndex))
                {
                    IRow firstRow = sheet.GetRow(range.FirstRow);
                    ICell firstCell = firstRow.GetCell(range.FirstColumn);
                    return firstCell?.ToString() ?? "";
                }
            }

            return cell.ToString();
        }
    }
}

