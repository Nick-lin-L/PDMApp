using Microsoft.AspNetCore.Mvc;
using PDMApp.Dtos.Spec;
using PDMApp.Models;
using PDMApp.Parameters.Cbd;
using PDMApp.Utils;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PDMApp.Controllers.CBD
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CbdHeadsController : ControllerBase
    {

        private readonly pcms_pdm_testContext _pcms_Pdm_TestContext;

        public CbdHeadsController(pcms_pdm_testContext pcms_Pdm_testContext)
        {
            _pcms_Pdm_TestContext = pcms_Pdm_testContext;
        }



        // GET: api/<CbdHeadsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CbdHeadsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/v1/<CbdHeadsController>
        [HttpPost]
        public async Task<ActionResult<APIStatusResponse<PagedResult<pdm_spec_headDto>>>> Post([FromBody] CbdSearchParameter value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var query = QueryHelper.QuerySpecHead(_pcms_Pdm_TestContext);
                // 動態篩選條件
                var filters = new List<Expression<Func<pdm_spec_headDto, bool>>>();

                if (!string.IsNullOrWhiteSpace(value.SpecMId))
                    filters.Add(ph => ph.SpecMId == value.SpecMId);
                if (!string.IsNullOrWhiteSpace(value.Factory))
                    filters.Add(ph => ph.Factory == value.Factory);
                if (!string.IsNullOrWhiteSpace(value.EntryMode))
                    filters.Add(ph => ph.EntryMode == value.EntryMode);
                if (!string.IsNullOrWhiteSpace(value.Season))
                    filters.Add(ph => ph.Season == value.Season);
                if (!string.IsNullOrWhiteSpace(value.Year))
                    filters.Add(ph => ph.Year == value.Year);
                if (!string.IsNullOrWhiteSpace(value.ItemNo))
                    filters.Add(ph => ph.ItemNo.Contains(value.ItemNo));
                if (!string.IsNullOrWhiteSpace(value.ColorNo))
                    filters.Add(ph => ph.ColorNo == value.ColorNo);
                if (!string.IsNullOrWhiteSpace(value.DevNo))
                    filters.Add(ph => ph.DevNo == value.DevNo);
                if (!string.IsNullOrWhiteSpace(value.Devcolorno))
                    filters.Add(ph => ph.DevColorDispName.Contains(value.Devcolorno));
                if (!string.IsNullOrWhiteSpace(value.Stage))
                    filters.Add(ph => ph.Stage.Equals(value.Stage));
                if (!string.IsNullOrWhiteSpace(value.CustomerKbn))
                    filters.Add(ph => ph.CustomerKbn.Contains(value.CustomerKbn));
                if (!string.IsNullOrWhiteSpace(value.ModeName))
                    filters.Add(ph => ph.Mode.Contains(value.ModeName));
                if (!string.IsNullOrWhiteSpace(value.OutMoldNo))
                    filters.Add(ph => ph.OutMoldNo.Contains(value.OutMoldNo));

                // 加上上面所有的篩選條件
                foreach (var filter in filters)
                {
                    query = query.Where(filter);
                }

                // 排序,如果需要多重排序的話後面接.ThenBy(條件)即可
                query = query.OrderBy(ph => ph.DevNo)
                    .ThenBy(ph => ph.DevColorDispName)
                    .ThenBy(ph => ph.Stage);

                // 分頁
                var pagedResult = await query.Distinct().ToPagedResultAsync(value.Pagination.PageNumber, value.Pagination.PageSize);

                // 回傳分頁+網頁識別碼結果
                return APIResponseHelper.HandlePagedApiResponse(pagedResult);

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

        // PUT api/<CbdHeadsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CbdHeadsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
