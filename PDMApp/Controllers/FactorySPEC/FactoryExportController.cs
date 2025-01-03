using Microsoft.AspNetCore.Mvc;
using PDMApp.Models;
using PDMApp.Parameters.FactorySpec;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Utils.FactorySpec;

namespace PDMApp.Controllers.FactorySPEC
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FactoryExportController : ControllerBase
    {
        private readonly pcms_pdm_testContext _pcms_Pdm_TestContext;

        public FactoryExportController(pcms_pdm_testContext pcms_Pdm_testContext)
        {
            _pcms_Pdm_TestContext = pcms_Pdm_testContext;
        }

        // POST: api/v1/FactoryExport
        [HttpPost]
        public async Task<IActionResult> ExportToExcel([FromBody] FactorySpec5SheetsSearchParameter value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                // ItemSheet 查詢
                var itemSheetData = Utils.FactorySpec.FactorySpecQueryHelper.GetItemSheetResponse(_pcms_Pdm_TestContext)
                    .Where(ph => string.IsNullOrWhiteSpace(value.SpecMId) || ph.SpecMId.Equals(value.SpecMId))
                    .ToList(); // 執行查詢，轉為 List

                // standardSheet 查詢
                var standardSheetData = Utils.FactorySpec.FactorySpecQueryHelper.GetSpecStandardSheetResponse(_pcms_Pdm_TestContext)
                    .Where(ph => string.IsNullOrWhiteSpace(value.SpecMId) || ph.SpecMId.Equals(value.SpecMId))
                    .ToList(); // 執行查詢，轉為 List

                string devNo = itemSheetData.FirstOrDefault()?.DevNo;  
                string itemNo = itemSheetData.FirstOrDefault()?.ItemNo;  
                string colorNo = itemSheetData.FirstOrDefault()?.ColorNo;

                // 生成檔案名稱
                string fileName = $"PCC.{devNo}({itemNo})_{colorNo}_量產中文.xlsx";

                // 使用 HttpUtility.UrlEncode 進行 UTF-8 編碼
                string encodedFileName = System.Web.HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8);

                // 使用 FactoryExportHelper 匯出資料
                var fileContent = FactoryExportHelper.ExportToExcel(itemSheetData, standardSheetData);

                // 回傳 Excel 檔案
                return File(fileContent, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", encodedFileName);
            }
            catch (DbException ex)
            {
                return StatusCode(500, new
                {
                    ErrorCode = "Server_ERROR",
                    Message = "ServerError",
                    Details = ex.Message
                });
            }

        }
    }
}
