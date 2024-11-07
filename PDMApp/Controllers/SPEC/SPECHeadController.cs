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
    public class SPECHeadController : ControllerBase
    {
        private readonly pcms_pdm_testContext _pcms_Pdm_TestContext;

        public SPECHeadController(pcms_pdm_testContext pcms_Pdm_testContext)
        {
            _pcms_Pdm_TestContext = pcms_Pdm_testContext;
        }


        // GET: api/SPECv1/<SPECHeadController>
        [HttpGet]
        public IEnumerable<pdm_spec_headDto> Get([FromQuery] SpecSearchParameter value)
        {
            var result = QueryHelper.QuerySpecHead(_pcms_Pdm_TestContext);

            if (!string.IsNullOrWhiteSpace(value.Spec_m_id))
                result = result.Where(ph => ph.Spec_m_id.Contains(value.Spec_m_id));
            if (!string.IsNullOrWhiteSpace(value.Factory))
                result = result.Where(ph => ph.Factory == value.Factory);
            if (!string.IsNullOrWhiteSpace(value.EntryMode))
                result = result.Where(ph => ph.Entrymode == value.EntryMode);
            if (!string.IsNullOrWhiteSpace(value.Season))
                result = result.Where(ph => ph.Season == value.Season);
            if (!string.IsNullOrWhiteSpace(value.Year))
                result = result.Where(ph => ph.Year == value.Year);
            if (!string.IsNullOrWhiteSpace(value.Item_No))
                result = result.Where(ph => ph.ItemNo.Contains(value.Item_No));
            if (!string.IsNullOrWhiteSpace(value.Color_No))
                result = result.Where(ph => ph.ColorNo == value.Color_No);
            if (!string.IsNullOrWhiteSpace(value.Dev_No))
                result = result.Where(ph => ph.DevNo == value.Dev_No);
            if (!string.IsNullOrWhiteSpace(value.Devcolorno))
                result = result.Where(ph => ph.DevColorDispName.Contains(value.Devcolorno));
            if (!string.IsNullOrWhiteSpace(value.Stage))
                result = result.Where(ph => ph.Stage.Contains(value.Stage));

            //return result.ToList();
            // 先將資料庫查詢結果加載到記憶體中，再進行投影
            var finalResult = result.ToList();

            // 在記憶體中處理每個 pdm_spec_headDto 並加載對應的 Spec_ItemDtos
            foreach (var item in finalResult)
            {
                item.pdm_Spec_ItemDtos = _pcms_Pdm_TestContext.pdm_spec_item
                    .Where(si => si.spec_m_id == item.Spec_m_id)
                    .Select(si => new pdm_spec_itemDto
                    {
                        ActNo = si.act_no,
                        //Parts = si.parts,
                        Parts = si.parts ?? _pcms_Pdm_TestContext.pdm_spec_item
                        .Where(x => x.spec_m_id == si.spec_m_id && x.act_no == si.act_no && x.parts != null)
                        .Select(x => x.parts)
                        .FirstOrDefault(),
                        Moldno = si.material,
                        Materialno = si.materialno,
                        Material = si.material,
                        Submaterial = si.submaterial,
                        Standard = si.standard,
                        Supplier = si.supplier,
                        Colors = si.colors,
                        Memo = si.memo,
                        Hcha = si.hcha,
                        Sec = si.sec,
                        Width = si.width
                    }).OrderBy(si => Convert.ToInt32(si.ActNo))
                    .ToList();
            }

            return finalResult;
        }

        // GET api/SPECv1/<SPECHeadController>/5
        [HttpGet("{id}")]
        public pdm_spec_headDto Get(string id)
        {
            return QueryHelper.QuerySpecHead(_pcms_Pdm_TestContext).FirstOrDefault(sh => sh.Spec_m_id == id);
        }

        // POST api/SPECv1/<SPECHeadController>
        // 以下方法為綜合應用「泛型、非同步處理、回傳值與參數不同」
        [HttpPost]
        public async Task<ActionResult<APIStatusResponse<IEnumerable<pdm_spec_headDto>>>> Post([FromBody] SpecSearchParameter value)
        {
            //var query = QuerySpecHead();
            var query = QueryHelper.QuerySpecHead(_pcms_Pdm_TestContext);

            // 動態篩選條件
            if (!string.IsNullOrWhiteSpace(value.Spec_m_id))
                query = query.Where(ph => ph.Spec_m_id.Contains(value.Spec_m_id));
            if (!string.IsNullOrWhiteSpace(value.Factory))
                query = query.Where(ph => ph.Factory == value.Factory);
            if (!string.IsNullOrWhiteSpace(value.EntryMode))
                query = query.Where(ph => ph.Entrymode == value.EntryMode);
            if (!string.IsNullOrWhiteSpace(value.Season))
                query = query.Where(ph => ph.Season == value.Season);
            if (!string.IsNullOrWhiteSpace(value.Year))
                query = query.Where(ph => ph.Year == value.Year);
            if (!string.IsNullOrWhiteSpace(value.Item_No))
                query = query.Where(ph => ph.ItemNo.Contains(value.Item_No));
            if (!string.IsNullOrWhiteSpace(value.Color_No))
                query = query.Where(ph => ph.ColorNo == value.Color_No);
            if (!string.IsNullOrWhiteSpace(value.Dev_No))
                query = query.Where(ph => ph.DevNo == value.Dev_No);
            if (!string.IsNullOrWhiteSpace(value.Devcolorno))
                query = query.Where(ph => ph.DevColorDispName.Contains(value.Devcolorno));
            if (!string.IsNullOrWhiteSpace(value.Stage))
                query = query.Where(ph => ph.Stage.Equals(value.Stage));
            if (!string.IsNullOrWhiteSpace(value.Customer_kbn))
                query = query.Where(ph => ph.Stage.Contains(value.Customer_kbn));
            if (!string.IsNullOrWhiteSpace(value.Out_mold_no))
                query = query.Where(ph => ph.Stage.Contains(value.Out_mold_no));



            // 透過 LINQ 選擇結果
            var result = await query.Distinct().ToListAsync();

            // 處理每個 pdm_spec_headDto 的 pdm_Spec_ItemDtos
            foreach (var item in result)
            {
                item.pdm_Spec_ItemDtos = new List<pdm_spec_itemDto>
                {
                    await _pcms_Pdm_TestContext.pdm_spec_item
                        .Where(si => si.spec_m_id == item.Spec_m_id)
                        .OrderBy(si => Convert.ToInt32(si.act_no))
                        .ThenBy(si => si.seqno)
                        .Select(si => new pdm_spec_itemDto
                        {
                            ActNo = si.act_no,
                            Seqno = si.seqno,
                            Parts = si.parts,
                            Moldno = si.material,
                            Materialno = si.materialno,
                            Material = si.material,
                            Submaterial = si.submaterial,
                            Standard = si.standard,
                            Supplier = si.supplier,
                            Colors = si.colors,
                            Memo = si.memo,
                            Hcha = si.hcha,
                            Sec = si.sec,
                            Width = si.width
                        })
                        .FirstOrDefaultAsync()
                };
            }
            return APIResponseHelper.HandleApiResponse(result);// 使用共用的 APIResponseHelper 來處理結果
        }

        // PUT api/SPECv1/<SPECHeadController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/SPECv1/<SPECHeadController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
