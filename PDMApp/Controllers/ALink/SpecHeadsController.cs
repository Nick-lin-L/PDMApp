using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDMApp.Dtos;
using PDMApp.Dtos.BasicProgram;
using PDMApp.Models;
using PDMApp.Parameters.ALink;
using PDMApp.Utils;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PDMApp.Controllers.ALink
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SpecHeadsController : ControllerBase
    {

        private readonly pcms_pdm_testContext _pcms_Pdm_TestContext;

        public SpecHeadsController(pcms_pdm_testContext pcms_Pdm_testContext)
        {
            _pcms_Pdm_TestContext = pcms_Pdm_testContext;
        }

        // GET: api/<SpecHeadsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SpecHeadsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SpecHeadsController>
        // 以下方法為綜合應用「泛型、非同步處理、回傳值與參數不同」
        public async Task<ActionResult<APIStatusResponse<PagedResult<pdm_spec_headDto>>>> Post([FromBody] SpecSearchParameter value)
        {
            try
            {
                if (!ValidateSearchParams(value))
                {
                    return Ok(new APIStatusResponse<object>
                    {
                        ErrorCode = "50001",
                        Message = "Please enter at least one search condition."
                    });
                }

                // Step 1：查詢 + 分頁（EF 查 DB）
                var pagedResult = await QueryHelper.QuerySpecHead2(_pcms_Pdm_TestContext, value)
                                                   .Distinct()
                                                   .ToPagedResultAsync(value.Pagination.PageNumber, value.Pagination.PageSize);

                // Step 2：在記憶體中組合 Factory 字串
                foreach (var item in pagedResult.Results)
                {
                    item.Factory = string.Join(",", new[] { item.Factory1, item.Factory2, item.Factory3 }
                                                .Where(f => !string.IsNullOrWhiteSpace(f)));
                }

                return APIResponseHelper.HandlePagedApiResponse(pagedResult);
            }
            catch (Exception ex)
            {
                return APIResponseHelper.HandleApiError<PagedResult<pdm_spec_headDto>>(
                    errorCode: "50001",
                    message: $"權限查詢過程中發生錯誤: {ex.Message}",
                    data: null
                );
            }
        }

        // POST api/<SpecHeadsController>
        // 以下方法為綜合應用「泛型、非同步處理、回傳值與參數不同」
        [HttpPost("post2")]
        public async Task<ActionResult<APIStatusResponse<PagedResult<pdm_spec_headDto>>>> Post2([FromBody] SpecSearchParameter value)
        {
            // 使用反射來檢查所有字串屬性
            var searchProperties = typeof(SpecSearchParameter)
                .GetProperties()
                .Where(p => p.PropertyType == typeof(string))
                .Select(p => p.GetValue(value) as string)
                .Any(v => !string.IsNullOrWhiteSpace(v));

            if (!searchProperties)
            {
                return Ok(new APIStatusResponse<object>
                {
                    ErrorCode = "10001",
                    Message = "Please enter at least one search condition."
                });
            }

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
                {
                    var years = value.Year.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                               .Select(y => y.Trim())
                                               .ToArray();
                    query = query.Where(ph => years.Contains(ph.Year));
                }
                if (!string.IsNullOrWhiteSpace(value.ItemNo))
                    filters.Add(ph => ph.ItemNo.Contains(value.ItemNo));
                if (!string.IsNullOrWhiteSpace(value.ColorNo))
                    filters.Add(ph => ph.ColorNo.Contains(value.ColorNo));
                if (!string.IsNullOrWhiteSpace(value.DevNo))
                    filters.Add(ph => ph.DevNo.Contains(value.DevNo));
                if (!string.IsNullOrWhiteSpace(value.Devcolorno))
                    filters.Add(ph => ph.DevColorDispName.Contains(value.Devcolorno));
                if (!string.IsNullOrWhiteSpace(value.Stage))
                    filters.Add(ph => ph.Stage == value.Stage);
                if (!string.IsNullOrWhiteSpace(value.CustomerKbn))
                    filters.Add(ph => ph.CustomerKbn == value.CustomerKbn);
                if (!string.IsNullOrWhiteSpace(value.ModeName))
                    filters.Add(ph => ph.Mode == value.ModeName);
                if (!string.IsNullOrWhiteSpace(value.OutMoldNo))
                    filters.Add(ph => ph.OutMoldNo.Contains(value.OutMoldNo));
                if (!string.IsNullOrWhiteSpace(value.LastNo))
                    filters.Add(ph => ph.LastNo1.Contains(value.LastNo) || ph.LastNo2.Contains(value.LastNo) || ph.LastNo3.Contains(value.LastNo));
                if (!string.IsNullOrWhiteSpace(value.ItemNameENG))
                    filters.Add(ph => ph.ItemNameEng.Contains(value.ItemNameENG));
                if (!string.IsNullOrWhiteSpace(value.ItemNameJPN))
                    filters.Add(ph => ph.ItemNameJpn.Contains(value.ItemNameJPN));
                /*
                if (!string.IsNullOrWhiteSpace(value.PartName))
                    filters.Add(ph => ph.PartName.Contains(value.PartName));
                if (!string.IsNullOrWhiteSpace(value.PartNo))
                    filters.Add(ph => ph.PartNo.Contains(value.PartNo));
                if (!string.IsNullOrWhiteSpace(value.MatColor))
                    filters.Add(ph => ph.MatColor.Contains(value.MatColor));
                if (!string.IsNullOrWhiteSpace(value.Material))
                    filters.Add(ph => ph.Material.Contains(value.Material));
                if (!string.IsNullOrWhiteSpace(value.SubMaterial))
                    filters.Add(ph => ph.SubMaterial.Contains(value.SubMaterial));
                if (!string.IsNullOrWhiteSpace(value.Supplier))
                    filters.Add(ph => ph.Supplier.Contains(value.Supplier));
                if (!string.IsNullOrWhiteSpace(value.Width))
                    filters.Add(ph => ph.Width.Contains(value.Width));
                */
                if (!string.IsNullOrWhiteSpace(value.HeelHeight))
                    filters.Add(ph => ph.HeelHeight.Contains(value.HeelHeight));


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
                //var pagedResult = await query.Distinct().ToPagedResultAsync(value.paginationParameter);
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
                    Details = ex.Message,
                    ex.StackTrace,
                    InnerException = ex.InnerException?.Message
                });

            }
        }

        [HttpPost("Upload")]
        public IActionResult UploadExcel([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("請上傳有效的 Excel 檔案");

            try
            {
                using (var stream = file.OpenReadStream())
                {
                    var importExcel_NPOI = new ImportExcel_NPOI(_pcms_Pdm_TestContext);
                    importExcel_NPOI.ProcessExcel(stream, file.FileName);
                }
                return Ok("Excel 資料已成功匯入資料庫");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"發生錯誤: {ex.Message}");
            }
        }

        [HttpPost("Export")]
        //public async Task<IActionResult> ExportMasterDetail([FromBody] SpecSearchParameter value)
        public async Task<ActionResult<APIStatusResponse<IEnumerable<ExportFileResponseDto>>>> ExportMasterDetail([FromBody] SpecSearchParameter value)
        {
            try
            {
                // 查詢主檔資料
                var query = QueryHelper.QuerySpecHead(_pcms_Pdm_TestContext);


                var filters = new List<Expression<Func<pdm_spec_headDto, bool>>>();
                // 動態篩選條件
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
                    .OrderBy(ph => ph.DevNo)
                    .ThenBy(ph => ph.DevColorDispName)
                    .ThenBy(ph => ph.Stage)
                    .ToListAsync();

                // 提前查出子資料
                var specMIds = result.Select(r => r.SpecMId).Distinct().ToList();
                var allSpecItems = await _pcms_Pdm_TestContext.pdm_spec_item
                    .Where(si => specMIds.Contains(si.spec_m_id))
                    .OrderBy(si => Convert.ToInt32(si.act_no))
                    .ThenBy(si => si.seqno)
                    .ToListAsync();

                // 建立子檔 Parts 對應關係
                var actNoToPartsMap = allSpecItems
                    .Where(si => !string.IsNullOrWhiteSpace(si.parts))
                    .GroupBy(si => si.act_no)
                    .ToDictionary(g => g.Key, g => g.First().parts);

                foreach (var item in allSpecItems)
                {
                    if (actNoToPartsMap.TryGetValue(item.act_no, out var part) && string.IsNullOrWhiteSpace(item.parts))
                    {
                        item.parts = part;
                    }
                }

                // 組合主子檔資料
                var specItemDtos = allSpecItems.Select(si => new pdm_spec_itemDto
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
                }).ToList();

                foreach (var item in result)
                {
                    item.pdm_Spec_ItemDtos = specItemDtos.Where(si => si.SpecMId == item.SpecMId).ToList();
                }

                // call ExportExcel_NPOI
                //var exporter = new ExportExcel_NPOI();
                var exporter = new ExportExcel_MiniExcel();
                var fileContent = exporter.ExportMasterDetailToExcel(result);

                // download file
                var base64Content = Convert.ToBase64String(fileContent);
                var fileName = $"SpecHeads_{DateTime.Now:yyyyMMddHHmmss}.xlsx"; // 檔案名稱
                //Response.Headers.Add("Message", "Import ok");
                //Response.Headers.Add("FileName", fileName);
                //return File(fileContent, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);

                var response = new ExportFileResponseDto
                {
                    FileName = fileName,
                    FileContent = base64Content
                };

                return APIResponseHelper.HandleApiResponse(
                    new[] { response }, // IEnumerable<ExportFileResponseDto>
                    successCode: "OK"
                );
                /*
                // 儲存檔案到C槽
                var filePath = @"C:\ExportedFiles"; // 指定存放資料夾
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath); // 若資料夾不在則建立
                }

                var fileName = $"SpecHeads_{DateTime.Now:yyyyMMddHHmmss}.xlsx"; //檔案名稱
                var fullPath = Path.Combine(filePath, fileName); // 路徑

                System.IO.File.WriteAllBytes(fullPath, fileContent); //將內容寫入檔案
                
                // download file
                return Ok(new
                {
                    Message = "檔案匯出成功",
                    DownloadUrl = $"http://localhost:5000/ExportedFiles/{fileName}"
                });
                */
            }
            catch (Exception ex)
            {
                return new ObjectResult(APIResponseHelper.HandleApiError<object>(
                    errorCode: "10001",
                    message: $"匯出過程中發生錯誤: {ex.Message}",
                    data: null
                ));
            }
        }


        // PUT api/<SpecHeadsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SpecHeadsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        private bool ValidateSearchParams(SpecSearchParameter value)
        {
            return typeof(SpecSearchParameter)
                .GetProperties()
                .Where(p => p.Name != "Pagination")
                .Any(p => {
                    var propertyValue = p.GetValue(value);
                    return propertyValue != null && !string.IsNullOrWhiteSpace(propertyValue.ToString());
                });
        }
    }
}
