using Dtos.FactorySpec;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClosedXML.Excel; // ClosedXML 命名空間
using PDMApp.Models;
using PDMApp.Parameters.FactorySpec;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Utils.FactorySpec;

namespace PDMApp.Controllers.FactorySPEC
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FactoryTestController : ControllerBase
    {
        private readonly pcms_pdm_testContext _pcms_Pdm_TestContext;

        public FactoryTestController(pcms_pdm_testContext pcms_Pdm_testContext)
        {
            _pcms_Pdm_TestContext = pcms_Pdm_testContext;
        }

        // POST: api/v1/FactoryTest/export
        [HttpPost("export")]
        public async Task<IActionResult> ExportToExcel([FromBody] FactorySpec5SheetsSearchParameter value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                // ItemSheet 查詢
                var query = Utils.FactorySpec.FactorySpecQueryHelper.GetItemSheetResponse(_pcms_Pdm_TestContext)
                    .Where(ph => string.IsNullOrWhiteSpace(value.SpecMId) || ph.SpecMId.Equals(value.SpecMId))
                    .ToList(); // 執行查詢，轉為 List

                // 使用 FactoryExportHelper 匯出資料
                var fileContent = FactoryExportHelper.ExportToExcel(query);

                // 回傳 Excel 檔案
                return File(fileContent, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "FactorySpecData.xlsx");
            }
            catch (DbException ex)
            {
                return StatusCode(500, new
                {
                    ErrorCode = "Server_ERROR",
                    Message = "Database Error",
                    Details = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ErrorCode = "GENERAL_ERROR",
                    Message = "An error occurred while processing your request.",
                    Details = ex.Message
                });
            }
        }

        



    }
}
