using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dtos.FactorySpec;
using PDMApp.Models;
using PDMApp.Parameters.FactorySpec;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Utils.FactorySpec;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PDMApp.Controllers.SPEC
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FactorySpec5SheetsController : ControllerBase
    {
        private readonly pcms_pdm_testContext _pcms_Pdm_TestContext;

        public FactorySpec5SheetsController(pcms_pdm_testContext pcms_Pdm_testContext)
        {
            _pcms_Pdm_TestContext = pcms_Pdm_testContext;
        }


        // POST api/<GetSpec5SheetRequestController>
        [HttpPost]
        public async Task<ActionResult<Utils.APIStatusResponse<IDictionary<string, object>>>> Post([FromBody] FactorySpec5SheetsSearchParameter value)
        {
            try
            {
                // 創建 MultiPageResultDTO
                var resultData = new MultiPageResultDTO();

                // BasicData 查詢
                var basic_query = Utils.FactorySpec.FactorySpecQueryHelper.GetSpecBasicResponse(_pcms_Pdm_TestContext)
                    .Where(ph => string.IsNullOrWhiteSpace(value.SpecMId) || ph.SpecMId.Equals(value.SpecMId));
                var resultBasic = await basic_query.Distinct().ToListAsync();
                resultData.BasicData = resultBasic;

                // Upper, Sole, Other 查詢
                var upper_query = Utils.FactorySpec.FactorySpecQueryHelper.GetSpecUpperResponse(_pcms_Pdm_TestContext)
                    .Where(si => string.IsNullOrWhiteSpace(value.SpecMId) || si.SpecMId.Equals(value.SpecMId));

                var allUpperData = await upper_query.ToListAsync();

                // 直接按 SeqNo 排序
                resultData.UpperData = allUpperData
                    .Where(si => si.PartClass == "A")
                    .OrderBy(si => si.SeqNo)
                    .ToList();

                resultData.SoleData = allUpperData
                    .Where(si => si.PartClass == "B")
                    .OrderBy(si => si.SeqNo)
                    .ToList();

                resultData.OtherData = allUpperData
                    .Where(si => si.PartClass == "C")
                    .OrderBy(si => si.SeqNo)
                    .ToList();

                // StandardData 查詢
                var standard_query = Utils.FactorySpec.FactorySpecQueryHelper.GetSpecStandardResponse(_pcms_Pdm_TestContext)
                    .Where(st => string.IsNullOrWhiteSpace(value.SpecMId) || st.SpecMId.Equals(value.SpecMId));
                resultData.StandardData = await standard_query.Distinct().ToListAsync();

                // 手動轉換為字典
                var dynamicData = new Dictionary<string, object>
                {
                    { "BasicData", resultData.BasicData },
                    { "UpperData", resultData.UpperData },
                    { "SoleData", resultData.SoleData },
                    { "OtherData", resultData.OtherData },
                    { "StandardData", resultData.StandardData }
                };

                return Utils.APIResponseHelper.HandleDynamicMultiPageResponse(dynamicData);
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


        // POST: api/v1/FactorySpec5Sheets/Export
        [HttpPost("Export")]
        public async Task<ActionResult<Utils.APIStatusResponse<IEnumerable<Dtos.ExportFileResponseDto>>>> ExportToExcel([FromBody] FactorySpec5SheetsSearchParameter value)
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

                string base64File = Convert.ToBase64String(fileContent); // 轉 Base64

                var response = new Dtos.ExportFileResponseDto
                {
                    FileName = fileName,
                    FileContent = base64File
                };

                return Utils.APIResponseHelper.HandleApiResponse(new[] { response }, "OK", "");
            }
            catch (DbException ex)
            {
                return new ObjectResult(Utils.APIResponseHelper.HandleApiError<object>(
                    errorCode: "10001",
                    message: $"匯出過程中發生錯誤: {ex.Message}",
                    data: null
                ));
            }

        }
       
    }
}
