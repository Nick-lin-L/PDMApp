using Microsoft.AspNetCore.Mvc;
using PDMApp.Dtos;
using PDMApp.Parameters.Spec;
using PDMApp.Utils;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PDMApp.Controllers.SPEC
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecDetailsController : ControllerBase
    {
        // GET: api/<SpecDetailsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SpecDetailsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SpecDetailsController>
        [HttpPost]
        public async Task<ActionResult<APIStatusResponse<PagedResult<pdm_spec_itemDto>>>> Post([FromBody] SpecSearchParameter value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {

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

        // PUT api/<SpecDetailsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SpecDetailsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
