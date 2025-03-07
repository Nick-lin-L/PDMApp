using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDMApp.Dtos.Cbd;
using PDMApp.Models;
using PDMApp.Parameters.Spec;
using PDMApp.Utils;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PDMApp.Controllers.CBD
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class Cbd5SheetsController : ControllerBase
    {

        private readonly pcms_pdm_testContext _pcms_Pdm_TestContext;

        public Cbd5SheetsController(pcms_pdm_testContext pcms_Pdm_testContext)
        {
            _pcms_Pdm_TestContext = pcms_Pdm_testContext;
        }





        // GET: api/<Cbd5SheetsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Cbd5SheetsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Cbd5SheetsController>
        [HttpPost]
        public async Task<ActionResult<APIStatusResponse<IDictionary<string, object>>>> Post([FromBody] SpecMIdParameter value)
        {
            try
            {
                // 創建 MultiPageResultDTO
                var resultData = new MultiCdb5SheetsDto();

                // BasicData 查詢
                var basic_query = QueryHelper.GetSpecBasicResponse(_pcms_Pdm_TestContext)
                    .Where(ph => string.IsNullOrWhiteSpace(value.SpecMId) || ph.SpecMId.Equals(value.SpecMId));
                var resultBasic = await basic_query.Distinct().ToListAsync();
                resultData.BasicData = resultBasic;

                // Upper, Sole, Other 查詢
                var upper_query = QueryHelper.CbdUpperResponse(_pcms_Pdm_TestContext)
                    .Where(si => string.IsNullOrWhiteSpace(value.SpecMId) || si.SpecMId.Equals(value.SpecMId));
                var allUpperData = await upper_query.ToListAsync();
                resultData.UpperData = allUpperData.Where(si => si.PartClass == "A").ToList();
                resultData.SoleData = allUpperData.Where(si => si.PartClass == "B").ToList();
                resultData.OtherData = allUpperData.Where(si => si.PartClass == "C").ToList();

                // ExpenseData 查詢
                var expense_query = QueryHelper.CbdExpenseResponse(_pcms_Pdm_TestContext)
                    .Where(st => string.IsNullOrWhiteSpace(value.SpecMId) || st.SpecMId.Equals(value.SpecMId));

                resultData.ExpenseData = await expense_query.Distinct().ToListAsync();

                // 手動轉換為字典
                var dynamicData = new Dictionary<string, object>
                {
                    { "BasicData", resultData.BasicData },
                    { "UpperData", resultData.UpperData },
                    { "SoleData", resultData.SoleData },
                    { "OtherData", resultData.OtherData },
                    { "ExpenseData", resultData.ExpenseData }
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

        // PUT api/<Cbd5SheetsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Cbd5SheetsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
