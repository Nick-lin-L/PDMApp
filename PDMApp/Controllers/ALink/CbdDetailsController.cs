﻿using Microsoft.AspNetCore.Mvc;
using PDMApp.Dtos;
using PDMApp.Dtos.BasicProgram;
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
    public class CbdDetailsController : ControllerBase
    {
        private readonly pcms_pdm_testContext _pcms_Pdm_TestContext;

        public CbdDetailsController(pcms_pdm_testContext pcms_Pdm_testContext)
        {
            _pcms_Pdm_TestContext = pcms_Pdm_testContext;
        }


        // GET: api/<CbdDetailsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CbdDetailsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CbdDetailsController>
        [HttpPost]
        public async Task<ActionResult<APIStatusResponse<PagedResult<pdm_cdbspec_itemDto>>>> Post([FromBody] SpecMIdParameter value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                // 驗證輸入參數是否正確
                if (string.IsNullOrWhiteSpace(value.SpecMId))
                {
                    return BadRequest(new
                    {
                        ErrorCode = "Invalid_Input",
                        Message = "Specmid is required."
                    });
                }

                // 查詢子表資料 (使用 IQueryable 支持分頁查詢)
                var query = _pcms_Pdm_TestContext.pdm_spec_item
                    .Where(si => si.spec_m_id == value.SpecMId)
                    .Where(si => string.IsNullOrEmpty(value.PartNo) || si.act_no.Contains(value.PartNo))
                    .Where(si => string.IsNullOrEmpty(value.PartName) || si.parts.Contains(value.PartName))
                    .Where(si => string.IsNullOrEmpty(value.MatColor) || si.colors.Contains(value.MatColor))
                    .Where(si => string.IsNullOrEmpty(value.Material) || si.material.Contains(value.Material))
                    .Where(si => string.IsNullOrEmpty(value.SubMaterial) || si.submaterial.Contains(value.SubMaterial))
                    .Where(si => string.IsNullOrEmpty(value.Supplier) || si.supplier.Contains(value.Supplier))
                    .Where(si => string.IsNullOrEmpty(value.Width) || si.width.Contains(value.Width))
                    .OrderBy(si => Convert.ToInt32(si.act_no))
                    .ThenBy(si => si.seqno)
                    .AsQueryable();

                // 分頁處理
                var pagedResult = await query.ToPagedResultAsync(value.Pagination.PageNumber, value.Pagination.PageSize);

                // 取出當前分頁的資料
                var currentPageItems = pagedResult.Results.ToList();

                // 處理 Parts 欄位
                var actNoToPartsMap = currentPageItems
                    .GroupBy(si => si.act_no) // 根據 act_no 分組
                    .ToDictionary(
                        g => g.Key,
                        g => g.FirstOrDefault(si => !string.IsNullOrWhiteSpace(si.parts))?.parts // 取第一個非空的 Parts 值
                    );

                foreach (var item in currentPageItems)
                {
                    if (actNoToPartsMap.ContainsKey(item.act_no))
                    {
                        item.parts = actNoToPartsMap[item.act_no]; // 更新 Parts 值
                    }
                }

                // 將資料轉換為 DTO 格式
                var dtoResult = currentPageItems.Select(si => new pdm_cdbspec_itemDto
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
                    Width = si.width,
                    Usage = si.usage2,
                    Price = si.pricenttur,
                    CostUS = si.cost
                }).ToList();

                // 基於 DTO 類型構建分頁結果
                var pagedDtoResult = new PagedResult<pdm_cdbspec_itemDto>(
                    results: dtoResult, // 傳入 DTO 資料
                    totalCount: pagedResult.Pagination.TotalCount, // 使用原分頁結果的總筆數
                    pageNumber: value.Pagination.PageNumber,
                    pageSize: value.Pagination.PageSize
                );

                // 回傳分頁結果
                return APIResponseHelper.HandlePagedApiResponse(pagedDtoResult);
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

        // PUT api/<CbdDetailsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CbdDetailsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
