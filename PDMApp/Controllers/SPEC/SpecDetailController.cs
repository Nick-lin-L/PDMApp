using ClosedXML.Excel;
using Dtos.SPEC;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDMApp.Models;
using PDMApp.Parameters.SPEC;
using PDMApp.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PDMApp.Controllers.SPEC
{
    [Route("api/v1/SPEC/[controller]")]
    [ApiController]
    public class SpecDetailController : ControllerBase
    {
        private readonly pcms_pdm_testContext _pcms_Pdm_TestContext;

        public SpecDetailController(pcms_pdm_testContext pcms_Pdm_TestContext)
        {
            _pcms_Pdm_TestContext = pcms_Pdm_TestContext;
        }

        // POST api/v1/SPEC/<SpecDetailController>
        [HttpPost]
        public async Task<ActionResult<APIStatusResponse<PagedResult<SPECDetailDto>>>> Post([FromBody] SPECDetailSearchParameter value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                // **將篩選條件直接傳遞到 QuerySpecDetail**
                var query = Service.SPEC.SPECQueryHelper.QuerySpecDetail(_pcms_Pdm_TestContext, value);

                // 分頁
                var pagedResult = await query.ToPagedResultAsync(value.Pagination.PageNumber, value.Pagination.PageSize);

                return APIResponseHelper.HandlePagedApiResponse(pagedResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ErrorCode = "Server_ERROR",
                    Message = "ServerError",
                    Details = ex.Message
                });
            }
        }

        [HttpPost("export")]
        public async Task<ActionResult<APIStatusResponse<IEnumerable<Dtos.ExportFileResponseDto>>>> ExportToExcel([FromBody] SPECExportSearchParameter value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var data = await Service.SPEC.SPECQueryHelper.QuerySpecExport(_pcms_Pdm_TestContext, value).ToListAsync();

                using var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("SPEC Export");

                // 設定標題
                string[] headers = { "SEASON", "STAGE", "SAMPLE FACTORY", "ITEM NO", "DEVELOPMENT NO", "COLOR CODE", "COLORWAY", "LAST", "ARTICLE DESCRIPTION", "PARTS NO", "PARTS", "DETAIL", "PROCESS MK", "MATERIAL", "MAT COMMENT", "AGENT", "STANDARD", "SUPPLIER", "MATERIAL COLOR", "COLOR COMMENT", "MEMO", "HC/HA", "SEC" };
                for (int col = 0; col < headers.Length; col++)
                {
                    worksheet.Cell(1, col + 1).Value = headers[col];
                    worksheet.Cell(1, col + 1).Style.Font.Bold = true;
                    worksheet.Cell(1, col + 1).Style.Fill.BackgroundColor = XLColor.LightGray;
                }

                // 填入資料
                int row = 2;
                foreach (var item in data)
                {
                    worksheet.Cell(row, 1).Value = item.Season;
                    worksheet.Cell(row, 2).Value = item.Stage;
                    worksheet.Cell(row, 3).Value = item.SampleFactory;
                    worksheet.Cell(row, 4).Value = item.ItemNo;
                    worksheet.Cell(row, 5).Value = item.DevelopmentNo;
                    worksheet.Cell(row, 6).Value = item.ColorCode;
                    worksheet.Cell(row, 7).Value = item.Colorway;
                    worksheet.Cell(row, 8).Value = item.Last;
                    worksheet.Cell(row, 9).Value = item.ArticleDescription;
                    worksheet.Cell(row, 10).Value = item.PartsNo;
                    worksheet.Cell(row, 11).Value = item.Parts;
                    worksheet.Cell(row, 12).Value = item.Detail;
                    worksheet.Cell(row, 13).Value = item.ProcessMk;
                    worksheet.Cell(row, 14).Value = item.Material;
                    worksheet.Cell(row, 15).Value = item.MatComment;
                    worksheet.Cell(row, 16).Value = item.Agent;
                    worksheet.Cell(row, 17).Value = item.Standard;
                    worksheet.Cell(row, 18).Value = item.Supplier;
                    worksheet.Cell(row, 19).Value = item.MaterialColor;
                    worksheet.Cell(row, 20).Value = item.ColorComment;
                    worksheet.Cell(row, 21).Value = item.Memo;
                    worksheet.Cell(row, 22).Value = item.HCHA;
                    worksheet.Cell(row, 23).Value = item.Sec;
                    row++;
                }

                // 自動調整欄位寬度
                worksheet.Columns().AdjustToContents();

                using var stream = new MemoryStream();
                workbook.SaveAs(stream);
                stream.Position = 0;

                string fileName = $"SpecDetail_{DateTime.Now:yyyyMMddHHmmss}.xlsx";
                string base64File = Convert.ToBase64String(stream.ToArray());

                var response = new Dtos.ExportFileResponseDto
                {
                    FileName = fileName,
                    FileContent = base64File
                };

                return APIResponseHelper.HandleApiResponse(new[] { response }, "OK", "");     
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ErrorCode = "Server_ERROR",
                    Message = "ServerError",
                    Details = ex.Message
                });
            }
        }
    }
}
