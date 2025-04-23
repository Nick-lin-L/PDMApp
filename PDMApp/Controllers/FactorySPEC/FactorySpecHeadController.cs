using Dtos.FactorySpec;
using Microsoft.AspNetCore.Mvc;
using PDMApp.Models;
using PDMApp.Parameters.FactorySpec;
using PDMApp.Utils;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PDMApp.Service.FactorySpec;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PDMApp.Controllers.FactorySPEC
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FactorySpecHeadController : ControllerBase
    {
        private readonly pcms_pdm_testContext _pcms_Pdm_TestContext;

        public FactorySpecHeadController(pcms_pdm_testContext pcms_Pdm_testContext)
        {
            _pcms_Pdm_TestContext = pcms_Pdm_testContext;
        }

        // GET: api/<FactorySpecHeadController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FactorySpecHeadController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FactorySpecHeadController>
        // 以下方法為綜合應用「泛型、非同步處理、回傳值與參數不同」
        [HttpPost]
        public async Task<ActionResult<APIStatusResponse<PagedResult<FactorySpecHeaderDto>>>> Post([FromBody] FactorySearchParameter value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // 預先檢查 Item No 或 Dev No 是否同時為空
            if (string.IsNullOrWhiteSpace(value.ItemNo) && string.IsNullOrWhiteSpace(value.DevNo))
            {
                return StatusCode(200, new
                {
                    ErrorCode = "BUSINESS_ERROR",
                    Message = "Item No 或 Dev No 必須至少填寫一個"
                });
            }

            try
            {
                var (isSuccess, message, query) = FactorySpecQueryHelper.QuerySpecHead(_pcms_Pdm_TestContext);

                if (!isSuccess)
                {
                    return StatusCode(200, new { ErrorCode = "BUSINESS_ERROR", Message = message });
                }

                var filters = new List<Expression<Func<FactorySpecHeaderDto, bool>>>();

                // Factory（完全匹配）
                if (!string.IsNullOrWhiteSpace(value.Factory))
                {
                    var factoryKeywords = value.Factory
                        .TrimEnd(',')
                        .Split(',', StringSplitOptions.RemoveEmptyEntries)
                        .Select(f => f.Trim())
                        .ToList();

                    query = query.Where(ph => factoryKeywords.Contains(ph.Factory));
                }

                // EntryMode（完全匹配）
                if (!string.IsNullOrWhiteSpace(value.EntryMode))
                    filters.Add(ph => ph.EntryMode == value.EntryMode);

                // Season（完全匹配）
                if (!string.IsNullOrWhiteSpace(value.Season))
                    filters.Add(ph => ph.Season == value.Season);

                // Year（LIKE）
                if (!string.IsNullOrWhiteSpace(value.Year))
                    filters.Add(ph => ph.Year.Contains(value.Year));

                // Item No（LIKE）
                if (!string.IsNullOrWhiteSpace(value.ItemNo))
                    filters.Add(ph => ph.ItemNo.Contains(value.ItemNo));

                // Dev No（LIKE）
                if (!string.IsNullOrWhiteSpace(value.DevNo))
                    filters.Add(ph => ph.DevNo.Contains(value.DevNo));

                // Dev Color（LIKE）
                if (!string.IsNullOrWhiteSpace(value.Devcolorno))
                    filters.Add(ph => ph.DevColorDispName.Contains(value.Devcolorno));

                // Stage（完全匹配）
                if (!string.IsNullOrWhiteSpace(value.Stage))
                    filters.Add(ph => ph.Stage == value.Stage);

                // Color No（LIKE）
                if (!string.IsNullOrWhiteSpace(value.ColorNo))
                    filters.Add(ph => ph.ColorNo.Contains(value.ColorNo));

                // 加入所有篩選條件
                foreach (var filter in filters)
                {
                    query = query.Where(filter);
                }

                // 排序：DevNo -> DevColorDispName -> Stage
                query = query
                    .OrderBy(ph => ph.DevNo)
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

        // PUT api/<FactorySpecHeadController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FactorySpecHeadController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
