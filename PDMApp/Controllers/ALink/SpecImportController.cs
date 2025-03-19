using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PDMApp.Models;
using PDMApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PDMApp.Controllers.ALink
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecImportController : ControllerBase
    {

        private readonly pcms_pdm_testContext _pcms_Pdm_TestContext;

        public SpecImportController(pcms_pdm_testContext pcms_Pdm_testContext)
        {
            _pcms_Pdm_TestContext = pcms_Pdm_testContext;
        }

        // GET: api/<SpecImportController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SpecImportController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SpecImportController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }


        [HttpPost("Upload")]
        public IActionResult UploadExcel([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("請上傳有效的 Excel 檔案");

            try
            {
                using (var stream = file.OpenReadStream())
                {
                    var importExcel_NPOI = new ImportExcel_NPOI(_pcms_Pdm_TestContext);
                    importExcel_NPOI.ProcessExcel(stream, file.FileName);
                }
                return Ok("Excel 資料已成功匯入資料庫");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"發生錯誤: {ex.Message}");
            }
        }




        // PUT api/<SpecImportController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SpecImportController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
