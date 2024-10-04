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

namespace PDMApp.Controllers
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
            var result = QuerySpecHead();

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
                result = result.Where(ph => ph.Item_no.Contains(value.Item_No));
            if (!string.IsNullOrWhiteSpace(value.Color_No))
                result = result.Where(ph => ph.Color_no == value.Color_No);
            if (!string.IsNullOrWhiteSpace(value.Dev_No))
                result = result.Where(ph => ph.Dev_no == value.Dev_No);
            if (!string.IsNullOrWhiteSpace(value.Devcolorno))
                result = result.Where(ph => ph.Dev_color_disp_name.Contains(value.Devcolorno));
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
                        Act_no = si.act_no,
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
                    }).OrderBy(si => Convert.ToInt32(si.Act_no))
                    .ToList();
            }

            return finalResult;
        }

        // GET api/SPECv1/<SPECHeadController>/5
        [HttpGet("{id}")]
        public pdm_spec_headDto Get(string id)
        {
            return QuerySpecHead().FirstOrDefault(sh => sh.Spec_m_id == id);
        }

        // POST api/SPECv1/<SPECHeadController>
        // 以下方法為綜合應用「泛型、非同步處理、回傳值與參數不同」
        [HttpPost]
        public async Task<ActionResult<APIStatusResponse<IEnumerable<pdm_spec_headDto>>>> Post([FromBody] SpecSearchParameter value)
        {
            var query = QuerySpecHead();
            //var query = QueryHelper.QuerySpecHead(_pcms_Pdm_TestContext);

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
                query = query.Where(ph => ph.Item_no.Contains(value.Item_No));
            if (!string.IsNullOrWhiteSpace(value.Color_No))
                query = query.Where(ph => ph.Color_no == value.Color_No);
            if (!string.IsNullOrWhiteSpace(value.Dev_No))
                query = query.Where(ph => ph.Dev_no == value.Dev_No);
            if (!string.IsNullOrWhiteSpace(value.Devcolorno))
                query = query.Where(ph => ph.Dev_color_disp_name.Contains(value.Devcolorno));
            if (!string.IsNullOrWhiteSpace(value.Stage))
                query = query.Where(ph => ph.Stage.Contains(value.Stage));

            // 透過 LINQ 選擇結果
            var result = await query.Distinct().ToListAsync();

            // 處理每個 pdm_spec_headDto 的 pdm_Spec_ItemDtos
            foreach (var item in result)
            {
                item.pdm_Spec_ItemDtos = await _pcms_Pdm_TestContext.pdm_spec_item
                    .Where(si => si.spec_m_id == item.Spec_m_id)
                    .Select(si => new pdm_spec_itemDto
                    {
                        Act_no = si.act_no,
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
                    }).OrderBy(si => Convert.ToInt32(si.Act_no))
                    .ThenBy(si => si.Seqno)
                    .ToListAsync();
            }

            // 處理返回結果為空的情況
            if (result == null || result.Count == 0)
            {
                // 返回帶有錯誤代碼和訊息的 API 狀態回應
                return Ok(new APIStatusResponse<IEnumerable<pdm_spec_headDto>>
                {
                    Data = Enumerable.Empty<pdm_spec_headDto>(), // 空集合，表示沒有資料
                    ErrorCode = "10000",
                    Message = "查無資料"
                });
            }

            // 正常返回資料的情況
            return Ok(new APIStatusResponse<IEnumerable<pdm_spec_headDto>>
            {
                Data = result,
                ErrorCode = "10001",
                Message = "成功取得資料"
            });
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


        private IQueryable<pdm_spec_headDto> QuerySpecHead()
        {
            // 使用多表 Join 查詢來組合所需欄位
            return (from ph in _pcms_Pdm_TestContext.pdm_product_head
                    join pi in _pcms_Pdm_TestContext.pdm_product_item on ph.product_m_id equals pi.product_m_id
                    join sh in _pcms_Pdm_TestContext.pdm_spec_head on pi.product_d_id equals sh.product_d_id
                    join si in _pcms_Pdm_TestContext.pdm_spec_item on sh.spec_m_id equals si.spec_m_id
                    select new pdm_spec_headDto
                    {
                        Year = ph.year,
                        Season = ph.season,
                        Entrymode = sh.entrymode,
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
                        Spec_m_id = sh.spec_m_id,
                        Cbdlockmk = sh.cbdlockmk,
                        Product_m_id = ph.product_m_id,
                        Product_d_id = pi.product_d_id,
                        pdm_Spec_ItemDtos = new List<pdm_spec_itemDto>() // 初始化空的 Spec_ItemDtos 列表
                    });
        }
    }
}
