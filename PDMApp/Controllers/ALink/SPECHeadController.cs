using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDMApp.Dtos;
using PDMApp.Dtos.Spec;
using PDMApp.Models;
using PDMApp.Parameters.ALink;
using PDMApp.Utils;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PDMApp.Controllers.ALink
{
    [Route("api/v1/[controller]")]
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

            if (!string.IsNullOrWhiteSpace(value.SpecMId))
                result = result.Where(ph => ph.SpecMId.Contains(value.SpecMId));
            if (!string.IsNullOrWhiteSpace(value.Factory))
                result = result.Where(ph => ph.Factory == value.Factory);
            if (!string.IsNullOrWhiteSpace(value.EntryMode))
                result = result.Where(ph => ph.EntryMode == value.EntryMode);
            if (!string.IsNullOrWhiteSpace(value.Season))
                result = result.Where(ph => ph.Season == value.Season);
            if (!string.IsNullOrWhiteSpace(value.Year))
                result = result.Where(ph => ph.Year == value.Year);
            if (!string.IsNullOrWhiteSpace(value.ItemNo))
                result = result.Where(ph => ph.ItemNo.Contains(value.ItemNo));
            if (!string.IsNullOrWhiteSpace(value.ColorNo))
                result = result.Where(ph => ph.ColorNo == value.ColorNo);
            if (!string.IsNullOrWhiteSpace(value.DevNo))
                result = result.Where(ph => ph.DevNo == value.DevNo);
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
                    .Where(si => si.spec_m_id == item.SpecMId)
                    .Select(si => new pdm_spec_itemDto
                    {
                        ActNo = si.act_no,
                        //Parts = si.parts,
                        Parts = si.parts ?? _pcms_Pdm_TestContext.pdm_spec_item
                        .Where(x => x.spec_m_id == si.spec_m_id && x.act_no == si.act_no && x.parts != null)
                        .Select(x => x.parts)
                        .FirstOrDefault(),
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
                    }).OrderBy(si => Convert.ToInt32(si.ActNo))
                    .ToList();
            }

            return finalResult;
        }

        // GET api/SPECv1/<SPECHeadController>/5
        [HttpGet("{id}")]
        public pdm_spec_headDto Get(string id)
        {
            return QueryHelper.QuerySpecHead(_pcms_Pdm_TestContext).FirstOrDefault(sh => sh.SpecMId == id);
        }

        // POST api/SPECv1/<SPECHeadController>
        // 以下方法為綜合應用「泛型、非同步處理、回傳值與參數不同」
        [HttpPost]
        public async Task<ActionResult<APIStatusResponse<IEnumerable<pdm_spec_headDto>>>> Post([FromBody] SpecSearchParameter value)
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


                foreach (var filter in filters)
                {
                    query = query.Where(filter);
                }


                // 透過 LINQ 查詢結果
                var result = await query.Distinct()
                    .OrderBy(ph=>ph.DevNo)
                    .ThenBy(ph=>ph.DevColorDispName)
                    .ThenBy(ph=>ph.Stage)
                    .ToListAsync();

                // 提前查出子資料
                var specMIds = result.Select(r => r.SpecMId).Distinct().ToList();
                var allSpecItems = await _pcms_Pdm_TestContext.pdm_spec_item
                    .Where(si => specMIds.Contains(si.spec_m_id))
                    .OrderBy(si => Convert.ToInt32(si.act_no))
                    .ThenBy(si => si.seqno)
                    .ToListAsync();

                // 處理每個 act_no 的 Parts 欄位
                var actNoToPartsMap = allSpecItems
                    .GroupBy(si => si.act_no) // 根據 act_no 分組
                    .ToDictionary(
                        g => g.Key,
                        g => g.FirstOrDefault(si => !string.IsNullOrWhiteSpace(si.parts))?.parts // 取第一個非空的 Parts 值
                    );

                // 更新所有子檔資料的 Parts
                foreach (var item in allSpecItems)
                {
                    if (actNoToPartsMap.ContainsKey(item.act_no) && string.IsNullOrWhiteSpace(item.parts))
                    {
                        item.parts = actNoToPartsMap[item.act_no]; // 將該 act_no 的第一筆 Parts 值分配給所有資料
                    }
                }


                // 處理每個主檔的明細
                foreach (var item in result)
                {
                    item.pdm_Spec_ItemDtos = allSpecItems
                        .Where(si => si.spec_m_id == item.SpecMId)
                        .Select(si => new pdm_spec_itemDto
                        {
                            SpecMId = si.spec_m_id,
                            ActNo = si.act_no,
                            SeqNo = si.seqno,
                            Parts = si.parts,
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
                        .ToList();
                }
                return APIResponseHelper.HandleApiResponse(result);// 使用共用的 APIResponseHelper.HandleApiResponse 來處理結果
            }
            catch (DbException ex)
            {
                return StatusCode(500,new
                {
                    ErrorCode = "Server_ERROR",
                    Message = "ServerError",
                    Details = ex.Message
                });

            }
        }


        [HttpPost("Export")]
        public async Task<IActionResult> ExportMasterDetail([FromBody] SpecSearchParameter value)
        {
            try
            {
                // 1. 查詢主檔資料
                var query = QueryHelper.QuerySpecHead(_pcms_Pdm_TestContext);

                // 動態篩選條件
                if (!string.IsNullOrWhiteSpace(value.SpecMId))
                    query = query.Where(ph => ph.SpecMId.Contains(value.SpecMId));
                if (!string.IsNullOrWhiteSpace(value.Factory))
                    query = query.Where(ph => ph.Factory == value.Factory);
                if (!string.IsNullOrWhiteSpace(value.EntryMode))
                    query = query.Where(ph => ph.EntryMode == value.EntryMode);
                if (!string.IsNullOrWhiteSpace(value.Year))
                    query = query.Where(ph => ph.Year == value.Year);
                if (!string.IsNullOrWhiteSpace(value.Stage))
                    query = query.Where(ph => ph.Stage.Contains(value.Stage));

                // 取得主檔資料
                var masterData = await query.ToListAsync();

                // 2. 查詢所有子檔資料
                var specMIds = masterData.Select(m => m.SpecMId).Distinct().ToList();

                var allSpecItems = await _pcms_Pdm_TestContext.pdm_spec_item
                    .Where(si => specMIds.Contains(si.spec_m_id))
                    .OrderBy(si => Convert.ToInt32(si.act_no))
                    .ThenBy(si => si.seqno)
                    .ToListAsync();

                // 3. 建立子檔 Parts 對應關係
                var actNoToPartsMap = allSpecItems
                    .GroupBy(si => si.act_no) // 根據 act_no 分組
                    .ToDictionary(
                        g => g.Key,
                        g => g.FirstOrDefault(si => !string.IsNullOrWhiteSpace(si.parts))?.parts // 取第一個非空的 Parts 值
                    );

                foreach (var item in allSpecItems)
                {
                    if (actNoToPartsMap.ContainsKey(item.act_no))
                    {
                        item.parts = actNoToPartsMap[item.act_no];
                    }
                }

                // 4. 組合主子檔資料
                foreach (var item in masterData)
                {
                    item.pdm_Spec_ItemDtos = allSpecItems
                        .Where(si => si.spec_m_id == item.SpecMId)
                        .Select(si => new pdm_spec_itemDto
                        {
                            SpecMId = si.spec_m_id,
                            ActNo = si.act_no,
                            SeqNo = si.seqno,
                            Parts = si.parts,
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
                        .ToList();
                }

                // 5. 呼叫匯出工具 ExportExcel_NPOI
                var exporter = new ExportExcel_NPOI();
                var fileContent = exporter.ExportMasterDetailToExcel(masterData);

                // 6. 回傳 Excel 檔案
                return File(fileContent, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MasterDetail.xlsx");
            }
            catch (Exception ex)
            {
                // 錯誤處理
                return StatusCode(500, $"匯出過程中發生錯誤: {ex.Message}");
            }
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
