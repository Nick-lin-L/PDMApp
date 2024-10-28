using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDMApp.Dtos;
using PDMApp.Models;
using PDMApp.Parameters;
using PDMApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PDMApp.Controllers.SPEC
{
    [Route("api/SPECv1/[controller]")]
    [ApiController]
    public class GetSpec5SheetRequestController : ControllerBase
    {
        private readonly pcms_pdm_testContext _pcms_Pdm_TestContext;

        public GetSpec5SheetRequestController(pcms_pdm_testContext pcms_Pdm_testContext)
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

        // POST api/<GetSpec5SheetRequestController>
        [HttpPost]
        public async Task<ActionResult<APIStatusResponse<MultiPageResultDTO>>> Post([FromBody] SpecSearchParameter value)
        {
            // 創建 MultiPageResultDTO 來存放結果
            var resultData = new MultiPageResultDTO();

            // Basic
            var basic_query = QueryHelper.GetSpecBasicResponse(_pcms_Pdm_TestContext);
            if (!string.IsNullOrWhiteSpace(value.Spec_m_id))
                basic_query = basic_query.Where(ph => ph.Spec_m_id.Contains(value.Spec_m_id));
            var resultBasic = await basic_query.Distinct().ToListAsync();
            resultData.BasicData = resultBasic;  // 將結果賦值給 MultiPageResultDTO 的 BasicData 屬性

            // Upper,Sole,Other
            var upper_query = QueryHelper.GetSpecUpperResponse(_pcms_Pdm_TestContext);
            if (!string.IsNullOrWhiteSpace(value.Spec_m_id))
                upper_query = upper_query.Where(si => si.Spec_m_id.Contains(value.Spec_m_id));
            var allUpperData = await upper_query.ToListAsync();

            // 賦予不同頁面資料
            resultData.UpperData = allUpperData.Where(si => si.PartClass == "A").ToList();
            resultData.SoleData = allUpperData.Where(si => si.PartClass == "B").ToList();
            resultData.OtherData = allUpperData.Where(si => si.PartClass == "C").ToList();
            
            var standard_query = QueryHelper.GetSpecStandardResponse(_pcms_Pdm_TestContext);
            if (!string.IsNullOrWhiteSpace(value.Spec_m_id))
                standard_query = standard_query.Where(st => st.Spec_m_id.Contains(value.Spec_m_id));
            var resultStandard = await standard_query.Distinct().ToListAsync();
            resultData.StandardData = resultStandard;
            
            return APIResponseHelper.HandleMultiPageResponse(resultData);
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
