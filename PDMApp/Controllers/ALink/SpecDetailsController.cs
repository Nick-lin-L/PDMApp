using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDMApp.Dtos.Spec;
using PDMApp.Models;
using PDMApp.Parameters.ALink;
using PDMApp.Utils;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PDMApp.Controllers.ALink
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SpecDetailsController : ControllerBase
    {

        private readonly pcms_pdm_testContext _pcms_Pdm_TestContext;

        public SpecDetailsController(pcms_pdm_testContext pcms_Pdm_testContext)
        {
            _pcms_Pdm_TestContext = pcms_Pdm_testContext;
        }



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
        public async Task<ActionResult<APIStatusResponse<PagedResult<pdm_spec_itemDto>>>> Post([FromBody] SpecMIdParameter value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                // 驗證輸入參數
                if (string.IsNullOrWhiteSpace(value.SpecMId))
                {
                    return BadRequest(new
                    {
                        ErrorCode = "Invalid_Input",
                        Message = "Specmid is required."
                    });
                }

                // 查詢所有資料
                var query = _pcms_Pdm_TestContext.pdm_spec_item
                    .Where(si => si.spec_m_id == value.SpecMId) // 過濾 SpecMId
                    .OrderBy(si => Convert.ToInt32(si.act_no))
                    .ThenBy(si => si.seqno)
                    .Select(si => new pdm_spec_itemDto
                    {
                        SpecMId = si.spec_m_id,
                        ActNo = si.act_no,
                        SeqNo = si.seqno,
                        Parts = si.parts, // 預設 Parts 值
                        MoldNo = si.material,
                        MaterialNo = si.materialno,
                        Material = si.material,
                        SubMaterial = si.submaterial,
                        Standard = si.standard,
                        Supplier = si.supplier,
                        Colors = si.colors,
                        Memo = si.memo,
                        Hcha = si.hcha,
                        Sec = si.sec,
                        Width = si.width
                    })
                    .AsQueryable();

                // 分頁處理
                var pagedResult = await query.ToPagedResultAsync(value.Pagination.PageNumber, value.Pagination.PageSize);

                // 處理null的Parts
                var actNoToPartsMap = _pcms_Pdm_TestContext.pdm_spec_item
                    .Where(si => si.spec_m_id == value.SpecMId && !string.IsNullOrWhiteSpace(si.parts))
                    .AsEnumerable()
                    .GroupBy(si => si.act_no) // 根據 act_no 分組
                    .ToDictionary(
                        g => g.Key,
                        g => g.First().parts // 取得第一筆非空 Parts 值
                    );

                // 更新 DTO Parts 欄位
                foreach (var item in pagedResult.Results)
                {
                    if (actNoToPartsMap.ContainsKey(item.ActNo) && string.IsNullOrWhiteSpace(item.Parts))
                    {
                        item.Parts = actNoToPartsMap[item.ActNo];
                    }
                }

                // 回傳分頁結果
                return APIResponseHelper.HandlePagedApiResponse(pagedResult);
            }
            catch (DbException ex)
            {
                // **優化 3: 加強錯誤處理與日誌記錄**
                return StatusCode(500, new
                {
                    ErrorCode = "Server_ERROR",
                    Message = $"資料處理錯誤: {ex.Message}",
                    Details = ex.InnerException?.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ErrorCode = "Unknown_ERROR",
                    Message = $"系統異常: {ex.Message}",
                    Details = ex.StackTrace
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
