using Microsoft.AspNetCore.Mvc;
using PDMApp.Dtos;
using PDMApp.Models;
using PDMApp.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PDMApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SPECHeadController : ControllerBase
    {
        private readonly pcms_pdm_testContext _pcms_Pdm_TestContext;

        public SPECHeadController(pcms_pdm_testContext pcms_Pdm_testContext) 
        {
            _pcms_Pdm_TestContext = pcms_Pdm_testContext;
        }


        // GET: api/<SPECHeadController>
        [HttpGet]
        public IEnumerable<pdm_spec_headDto> Get([FromQuery]SpecSearchParameter value)
        {
            //SPEC綜合查詢-查詢功能
            var result = (from ph in _pcms_Pdm_TestContext.pdm_product_head
                          join pi in _pcms_Pdm_TestContext.pdm_product_item on ph.product_m_id equals pi.product_m_id
                          join sh in _pcms_Pdm_TestContext.pdm_spec_head on pi.product_d_id equals sh.product_d_id
                          join si in _pcms_Pdm_TestContext.pdm_spec_item on sh.spec_m_id equals si.spec_m_id
                          select new pdm_spec_headDto
                          {
                              Year = ph.year,
                              Season = ph.season,
                              Stage = sh.stage,
                              out_mold_no = ph.out_mold_no,
                              Mold_no = (ph.out_mold_no + "/" + ph.mid_mold_no + "/" + ph.etc_mold_no).Trim('/'),
                              Shfactory = sh.factory,
                              Factory = (ph.factory1 + "," + ph.factory2 + "," + ph.factory3).Replace(",,", ","),
                              Item_name_eng = ph.item_name_eng,
                              Item_name_jpn = ph.item_name_jpn,
                              Item_no = ph.item_no,
                              Dev_no = ph.dev_no,
                              Dev_color_disp_name = pi.dev_color_disp_name,
                              Color_no = pi.color_no,
                              //以下是不需要的
                              Spec_m_id = sh.spec_m_id,
                              Cbdlockmk = sh.cbdlockmk,
                              Product_m_id = ph.product_m_id,
                              Product_d_id = pi.product_d_id,
                          }).Distinct();

            if (!string.IsNullOrWhiteSpace(value.Spec_m_id))
            {
                result = result.Where(ph => ph.Spec_m_id.Contains(value.Spec_m_id));

            }

            if (!string.IsNullOrWhiteSpace(value.Factory)){
                result = result.Where(ph => ph.Factory == value.Factory);
            }
            return result;
        }

            // GET api/<SPECHeadController>/5
            [HttpGet("{id}")]
        public pdm_spec_headDto Get(string id)
        {
            var result = (from ph in _pcms_Pdm_TestContext.pdm_product_head
                          join pi in _pcms_Pdm_TestContext.pdm_product_item on ph.product_m_id equals pi.product_m_id
                          join sh in _pcms_Pdm_TestContext.pdm_spec_head on pi.product_d_id equals sh.product_d_id
                          join si in _pcms_Pdm_TestContext.pdm_spec_item on sh.spec_m_id equals si.spec_m_id
                          where sh.spec_m_id == id
                          select new pdm_spec_headDto
                          {
                              Year = ph.year,
                              Season = ph.season,
                              Stage = sh.stage,
                              out_mold_no = ph.out_mold_no,
                              Mold_no = (ph.out_mold_no + "/" + ph.mid_mold_no + "/" + ph.etc_mold_no).Trim('/'),
                              Shfactory = sh.factory,
                              Factory = (ph.factory1 + "," + ph.factory2 + "," + ph.factory3).Replace(",,", ","),
                              Item_name_eng = ph.item_name_eng,
                              Item_name_jpn = ph.item_name_jpn,
                              Item_no = ph.item_no,
                              Dev_no = ph.dev_no,
                              Dev_color_disp_name = pi.dev_color_disp_name,
                              Color_no = pi.color_no,
                              //以下是不需要的
                              Spec_m_id = sh.spec_m_id, 
                              Cbdlockmk = sh.cbdlockmk,
                              Product_m_id = ph.product_m_id,
                              Product_d_id = pi.product_d_id,
                          }).FirstOrDefault();
            return result;
        }

        // POST api/<SPECHeadController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SPECHeadController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SPECHeadController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


        
    }
}
