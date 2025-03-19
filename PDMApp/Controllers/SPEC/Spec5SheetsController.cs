using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDMApp.Dtos;
using PDMApp.Models;
using PDMApp.Parameters.Spec;
using PDMApp.Utils;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PDMApp.Controllers.SPEC
{
    [Route("api/SPECv1/[controller]")]
    [ApiController]
    public class Spec5SheetsController : ControllerBase
    {
        private readonly pcms_pdm_testContext _pcms_Pdm_TestContext;

        public Spec5SheetsController(pcms_pdm_testContext pcms_Pdm_testContext)
        {
            _pcms_Pdm_TestContext = pcms_Pdm_testContext;
        }








        // GET: api/<GetSpec5SheetRequestController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<GetSpec5SheetRequestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        /*
        // POST api/<GetSpec5SheetRequestController>
        [HttpPost]
        public async Task<ActionResult<APIStatusResponse<MultiPageResultDTO>>> Post([FromBody] SpecSearchParameter value)
        {
            // 創建 MultiPageResultDTO 來存放結果
            var resultData = new MultiPageResultDTO();

            // Basic 查詢
            var basic_query = QueryHelper.GetSpecBasicResponse(_pcms_Pdm_TestContext).Where(ph => string.IsNullOrWhiteSpace(value.SpecMId) || ph.SpecMId.Equals(value.SpecMId));
            var resultBasic = await basic_query.Distinct().ToListAsync();  // 等待查詢完成
            resultData.BasicData = resultBasic;

            // Upper,Sole,Other 查詢是同一個。但條件值不同
            var upper_query = QueryHelper.GetSpecUpperResponse(_pcms_Pdm_TestContext).Where(si => string.IsNullOrWhiteSpace(value.SpecMId) || si.SpecMId.Equals(value.SpecMId));
            var allUpperData = await upper_query.ToListAsync();  // 等待查詢完成

            // 賦予不同頁面資料
            resultData.UpperData = allUpperData.Where(si => si.PartClass == "A").ToList();
            resultData.SoleData = allUpperData.Where(si => si.PartClass == "B").ToList();
            resultData.OtherData = allUpperData.Where(si => si.PartClass == "C").ToList();

            // Standard 查詢
            var standard_query = QueryHelper.GetSpecStandardResponse(_pcms_Pdm_TestContext).Where(st => string.IsNullOrWhiteSpace(value.SpecMId) || st.SpecMId.Equals(value.SpecMId));
            var resultStandard = await standard_query.Distinct().ToListAsync();  // 等待查詢完成
            resultData.StandardData = resultStandard;

            return APIResponseHelper.HandleMultiPageResponse(resultData);
        }
        */

        // POST api/<GetSpec5SheetRequestController>
        [HttpPost]
        public async Task<ActionResult<APIStatusResponse<IDictionary<string, object>>>> Post([FromBody] SpecSearchParameter value)
        {
            try
            {
                // 創建 MultiPageResultDTO
                var resultData = new MultiPageResultDTO();

                // BasicData 查詢
                var basic_query = QueryHelper.GetSpecBasicResponse(_pcms_Pdm_TestContext)
                    .Where(ph => string.IsNullOrWhiteSpace(value.SpecMId) || ph.SpecMId.Equals(value.SpecMId));
                var resultBasic = await basic_query.Distinct().ToListAsync();
                resultData.BasicData = resultBasic;

                // Upper, Sole, Other 查詢
                var upper_query = QueryHelper.GetSpecUpperResponse(_pcms_Pdm_TestContext)
                    .Where(si => string.IsNullOrWhiteSpace(value.SpecMId) || si.SpecMId.Equals(value.SpecMId));
                var allUpperData = await upper_query.ToListAsync();
                resultData.UpperData = allUpperData.Where(si => si.PartClass == "A").ToList();
                resultData.SoleData = allUpperData.Where(si => si.PartClass == "B").ToList();
                resultData.OtherData = allUpperData.Where(si => si.PartClass == "C").ToList();

                // StandardData 查詢
                var standard_query = QueryHelper.GetSpecStandardResponse(_pcms_Pdm_TestContext)
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

                return APIResponseHelper.HandleDynamicMultiPageResponse(dynamicData);
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



        // PUT api/<GetSpec5SheetRequestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GetSpec5SheetRequestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
