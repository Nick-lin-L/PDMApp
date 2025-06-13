using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MiniExcelLibs;
using MiniExcelLibs.OpenXml;
using Npgsql;
using PDMApp.Extensions;
using PDMApp.Models;
using PDMApp.Utils;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

namespace PDMApp.Controllers.ProductionOrder
{
    [ApiController]
    [Route("api/v1/ProductionOrder/[controller]/[action]")]
    public class ArtnoPoController : ControllerBase
    {
        private readonly ILogger<ArtnoPoController> _logger;
        private readonly pcms_pdm_testContext _Context;
        private readonly Service.IComboService _icomboService;
        private readonly Service.ProductionOrder.IArtnoPoService _artnoPoService;
        public ArtnoPoController(pcms_pdm_testContext pcms_Pdm_testContext,
                                  ILogger<ArtnoPoController> logger,
                                  Service.IComboService icomboService,
                                  Service.ProductionOrder.IArtnoPoService artnoPoService)
        {
            _logger = logger;
            _Context = pcms_Pdm_testContext;
            _icomboService = icomboService;
            _artnoPoService = artnoPoService;
        }

        [HttpPost]
        public async Task<ActionResult<APIStatusResponse<object>>> Initial(Parameters.ProductionOrder.ArtPoParameter.InitialParameter value)
        {
            var response = new APIStatusResponse<object>();
            try
            {
                var resultData = new Dictionary<string, object>();
                response.Data = resultData;
                response.Message = "OK";
                response.ErrorCode = "OK";
                resultData["BrandCombo"] = await _icomboService.BrandNo(value.DevFactoryNo);
                resultData["OrderStatusCombo"] = await _icomboService.OrderStatus();
                resultData["StageCombo"] = await _icomboService.Stage();
                resultData["SeasonCombo"] = await _artnoPoService.GetSeason(value.DevFactoryNo);
                resultData["FGTypeCombo"] = await _icomboService.FGType(value.DevFactoryNo);
                resultData["ShoeKindCombo"] = await _artnoPoService.GetShoeKind(value.DevFactoryNo);
                resultData["OrderKindCombo"] = (await _artnoPoService.GetNameValueByKey(value.DevFactoryNo, "order_kind")).Select(x => new { Text = x.text, Value = x.value_desc }).ToList();
                // 封裝結果並回傳
                return response;
                // return APIResponseHelper.HandleDynamicMultiPageResponse(resultData);
            }
            catch (DbUpdateException ex) when (ex.InnerException is PostgresException pgEx)
            {
                string errmsg = "";
                switch (pgEx.SqlState)
                {
                    case PostgresErrorCodes.UniqueViolation:
                        errmsg = "違反唯一約束";
                        Console.WriteLine("");
                        break;
                    case PostgresErrorCodes.ForeignKeyViolation:
                        errmsg = "違反外鍵約束";
                        Console.WriteLine("違反外鍵約束");
                        break;
                    default:
                        errmsg = $"Postgres 錯誤代碼: {pgEx.SqlState}, 訊息: {pgEx.Message}";
                        Console.WriteLine();
                        break;
                }

                return StatusCode(200, new
                {
                    ErrorCode = "21001",
                    Message = errmsg,
                    Data = ""
                });
            }
            catch (Exception e)
            {
                return StatusCode(200, new
                {
                    ErrorCode = "21001",
                    Message = e.Message,
                    Data = ""
                });
            }
        }


        [HttpPost]
        public async Task<ActionResult<APIStatusResponse<Utils.PagedResult<Dtos.ProductionOrder.ArtPoDto.QueryDto>>>> Query(Parameters.ProductionOrder.ArtPoParameter.QueryParameter parameter)
        {
            try
            {
                //至少需輸入3個條件
                if (!parameter.ValidationParameter(2))
                {
                    throw new Exception("查詢條件不可以都為空");
                }
                if (string.IsNullOrWhiteSpace(parameter.ArticleNo) &&
                    string.IsNullOrWhiteSpace(parameter.OrderNo) &&
                    string.IsNullOrWhiteSpace(parameter.ModelName) &&
                    string.IsNullOrWhiteSpace(parameter.DevelopmentNo))
                {
                    throw new Exception("ORDER NO、MODEL NAME、DEVELOPMENT NO、ARTICLE NO需擇一有值");
                }
                var query = await _artnoPoService.Search(parameter);
                var data = await query.ToPagedResultAsync(parameter.Pagination.PageNumber, parameter.Pagination.PageSize);
                return APIResponseHelper.HandlePagedApiResponse(data);
            }
            catch (Exception e)
            {
                return StatusCode(200, new
                {
                    ErrorCode = "21001",
                    Message = e.Message,
                    Details = ""
                });

            }
        }
        [HttpPost]
        public async Task<ActionResult<APIStatusResponse<object>>> QueryDetail(Parameters.ProductionOrder.ArtPoParameter.QueryDetailParameter parameter)
        {
            var response = new APIStatusResponse<object>();
            try
            {
                var query = await _artnoPoService.SearchDetail(parameter);
                response.Data = query;
                response.ErrorCode = "OK";
                return response;
            }
            catch (Exception e)
            {
                return StatusCode(200, new
                {
                    ErrorCode = "21001",
                    Message = e.Message,
                    Details = ""
                });

            }
        }

        [HttpPost]
        public async Task<ActionResult<APIStatusResponse<object>>> GetUpdateMainData(Parameters.ProductionOrder.ArtPoParameter.DetailDataParameter parameter)
        {
            var response = new APIStatusResponse<object>();
            try
            {
                var data = await _artnoPoService.GetDataById(parameter.DevFactoryNo, parameter.WkMId);
                response.Data = data;
                response.ErrorCode = "OK";
                return response;
            }
            catch (Exception e)
            {
                return StatusCode(200, new
                {
                    ErrorCode = "21001",
                    Message = e.Message,
                    Details = ""
                });
            }
        }
        [HttpPost]
        public async Task<ActionResult<APIStatusResponse<object>>> GetUpdateDetail(Parameters.ProductionOrder.ArtPoParameter.DetailDataParameter parameter)
        {
            var response = new APIStatusResponse<object>();
            try
            {
                var data = await _artnoPoService.GetDetailById(parameter.WkMId);
                response.Data = data;
                response.ErrorCode = "OK";
                return response;
            }
            catch (Exception e)
            {
                return StatusCode(200, new
                {
                    ErrorCode = "21001",
                    Message = e.Message,
                    Details = ""
                });
            }
        }
        [HttpPost]
        public async Task<ActionResult<APIStatusResponse<object>>> CreateMainData(Parameters.ProductionOrder.ArtPoParameter.MainDataParameter parameter)
        {
            var response = new APIStatusResponse<object>();
            try
            {
                var data = await _artnoPoService.CreateMainData(parameter);
                response.Data = data;
                response.ErrorCode = "OK";
                return response;
            }
            catch (Exception e)
            {
                return StatusCode(200, new
                {
                    ErrorCode = "21001",
                    Message = e.Message,
                    Details = ""
                });
            }
        }
        [HttpPost]
        public async Task<ActionResult<APIStatusResponse<object>>> UpdateMainData(Parameters.ProductionOrder.ArtPoParameter.MainDataParameter parameter)
        {
            var response = new APIStatusResponse<object>();
            try
            {
                var data = await _artnoPoService.UpdateMainData(parameter);
                response.Data = data;
                response.ErrorCode = "OK";
                return response;
            }
            catch (Exception e)
            {
                return StatusCode(200, new
                {
                    ErrorCode = "21001",
                    Message = e.Message,
                    Details = ""
                });

            }
        }
        [HttpPost]
        public async Task<ActionResult<APIStatusResponse<object>>> UpdateDetailData(Parameters.ProductionOrder.ArtPoParameter.DetailDataParameter parameter)
        {
            var response = new APIStatusResponse<object>();
            try
            {
                var data = await _artnoPoService.UpdateDetailData(parameter);
                response.Data = data;
                response.ErrorCode = "OK";
                return response;
            }
            catch (Exception e)
            {
                return StatusCode(200, new
                {
                    ErrorCode = "21001",
                    Message = e.Message,
                    Details = ""
                });

            }
        }
        [HttpPost]
        public async Task<ActionResult<APIStatusResponse<object>>> ProcessPo(List<Parameters.ProductionOrder.ArtPoParameter.ProcessParameter> parameter)
        {
            var response = new APIStatusResponse<object>();
            try
            {
                var data = await _artnoPoService.ProcessPo(parameter);
                response.Data = data;
                response.ErrorCode = "OK";
                return response;
            }
            catch (Exception e)
            {
                return StatusCode(200, new
                {
                    ErrorCode = "21001",
                    Message = e.Message,
                    Details = ""
                });
            }
        }
        [HttpPost]
        public async Task<ActionResult<APIStatusResponse<object>>> SubmitToSerp([FromBody] List<Parameters.ProductionOrder.ArtPoParameter.SubmitParameter> parameter)
        {
            try
            {
                var data = await _artnoPoService.SubmitToSerp(parameter);
                if (data.ToString() != "OK")
                {
                    return StatusCode(200, new
                    {
                        ErrorCode = "Error",
                        Message = data
                    });
                }
                else
                {
                    return StatusCode(200, new
                    {
                        ErrorCode = "OK",
                        Message = data
                    });
                }

            }
            catch (Exception e)
            {
                return StatusCode(200, new
                {
                    ErrorCode = "Error",
                    Message = e.Message
                });
            }
        }
        [HttpPost]
        public async Task<object> QueryPicker(Parameters.ProductionOrder.ArtPoParameter.QueryPickerParameter parameter)
        {
            try
            {
                // 至少需輸入3個條件
                if (!parameter.ValidationParameter(2))
                {
                    throw new Exception("查詢條件不可以都為空");
                }
                var response = new APIStatusResponse<object>();
                response.Data = await _artnoPoService.QueryPicker(parameter);
                response.ErrorCode = "OK";
                return response;

            }
            catch (Exception e)
            {
                return StatusCode(200, new
                {
                    ErrorCode = "21001",
                    Message = e.Message,
                    Details = ""
                });

            }
        }
        [HttpPost]
        public async Task<ActionResult<Utils.APIStatusResponse<Dtos.ExportFileResponseDto>>> Export([FromBody] List<Parameters.ProductionOrder.ArtPoParameter.SubmitParameter> parameter)
        // public async Task<ActionResult<object>> Export(List<Parameters.ProductionOrder.ArtPoParameter.SubmitParameter> parameter)
        {
            try
            {
                var response = new APIStatusResponse<object>();
                var excelData = await _artnoPoService.ExportData(parameter);
                var tempStreams = new List<(string SheetName, MemoryStream Stream)>();
                foreach (var item in excelData)
                {
                    string sheetName = item.OrderNo;
                    // 讓樣板渲染該筆資料
                    var ms = new MemoryStream();
                    MiniExcel.SaveAsByTemplate(ms, @"ExportedFiles\SampleProductionOrderTemplate.xlsx", item);
                    ms.Position = 0;
                    tempStreams.Add((sheetName, ms));
                }
                _logger.LogInformation($"tempStreams.Count: {tempStreams.Count}");
                var finalStream = MergeSheetsWithNPOI(tempStreams);
                finalStream.Position = 0;
                string base64File = Convert.ToBase64String(finalStream.ToArray());
                var file = new Dtos.ExportFileResponseDto
                {
                    FileName = $"Report_{DateTime.Now:yyyyMMddHHmmss}.xlsx",
                    FileContent = base64File
                };

                return StatusCode(200, new
                {
                    ErrorCode = "OK",
                    Message = "",
                    Data = file
                });

                // return File(finalStream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Report_{DateTime.Now:yyyyMMddHHmmss}.xlsx");
                // response.ErrorCode = "OK";
                // return response;
            }
            catch (Exception e)
            {
                _logger.LogError($"Exception : {e.Message}");
                return StatusCode(200, new
                {
                    ErrorCode = "21001",
                    Message = e.Message,
                    Details = ""
                });
            }

        }
        private MemoryStream MergeSheetsWithNPOI(List<(string SheetName, MemoryStream Stream)> sheets)
        {
            var finalWorkbook = new XSSFWorkbook();

            foreach (var (sheetName, stream) in sheets)
            {
                stream.Position = 0;
                var tempWorkbook = new XSSFWorkbook(stream);
                var tempSheet = tempWorkbook.GetSheetAt(0);
                var newSheet = finalWorkbook.CreateSheet(sheetName);
                CopySheet(tempSheet, newSheet, finalWorkbook, tempWorkbook);
            }

            var outputStream = new MemoryStream();
            finalWorkbook.Write(outputStream, leaveOpen: true);
            outputStream.Position = 0;
            return outputStream;
        }

        private void CopySheet(ISheet source, ISheet target, IWorkbook targetWb, IWorkbook sourceWb)
        {
            // 複製列寬
            for (int i = 0; i < 100; i++) // 假設最多100列,可以依需求調整
            {
                target.SetColumnWidth(i, source.GetColumnWidth(i));
            }

            // 複製合併區域
            foreach (var mergedRegion in source.MergedRegions)
            {
                target.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(
                    mergedRegion.FirstRow,
                    mergedRegion.LastRow,
                    mergedRegion.FirstColumn,
                    mergedRegion.LastColumn
                ));
            }

            // 複製列高和儲存格內容
            for (int i = 0; i <= source.LastRowNum; i++)
            {
                var srcRow = source.GetRow(i);
                if (srcRow == null) continue;

                var newRow = target.CreateRow(i);
                newRow.Height = srcRow.Height;

                // 複製列格式
                if (srcRow.RowStyle != null)
                {
                    var newRowStyle = targetWb.CreateCellStyle();
                    newRowStyle.CloneStyleFrom(srcRow.RowStyle);
                    newRow.RowStyle = newRowStyle;
                }

                for (int j = 0; j < srcRow.LastCellNum; j++)
                {
                    var srcCell = srcRow.GetCell(j);
                    if (srcCell == null) continue;

                    var newCell = newRow.CreateCell(j);

                    // 複製儲存格格式
                    if (srcCell.CellStyle != null)
                    {
                        var newStyle = targetWb.CreateCellStyle();
                        newStyle.CloneStyleFrom(srcCell.CellStyle);

                        // 複製字型
                        if (srcCell.CellStyle.GetFont(sourceWb) != null)
                        {
                            var srcFont = srcCell.CellStyle.GetFont(sourceWb);
                            var newFont = targetWb.CreateFont();
                            newFont.FontName = srcFont.FontName;
                            newFont.FontHeightInPoints = srcFont.FontHeightInPoints;
                            newFont.IsBold = srcFont.IsBold;
                            newFont.IsItalic = srcFont.IsItalic;
                            newFont.Color = srcFont.Color;
                            newStyle.SetFont(newFont);
                        }

                        newCell.CellStyle = newStyle;
                    }

                    // 複製儲存格值
                    CopyCellValue(srcCell, newCell);
                }
            }

            // 複製列印設定
            if (source.PrintSetup != null)
            {
                target.PrintSetup.Landscape = source.PrintSetup.Landscape;
                target.PrintSetup.PaperSize = source.PrintSetup.PaperSize;
                target.PrintSetup.Scale = source.PrintSetup.Scale;
                target.PrintSetup.FitHeight = source.PrintSetup.FitHeight;
                target.PrintSetup.FitWidth = source.PrintSetup.FitWidth;
            }

            // 複製工作表屬性
            target.DisplayGridlines = source.DisplayGridlines;
            target.DisplayRowColHeadings = source.DisplayRowColHeadings;

        }


        private void CopyCellValue(ICell srcCell, ICell newCell)
        {
            switch (srcCell.CellType)
            {
                case CellType.String: newCell.SetCellValue(srcCell.StringCellValue); break;
                case CellType.Numeric: newCell.SetCellValue(srcCell.NumericCellValue); break;
                case CellType.Boolean: newCell.SetCellValue(srcCell.BooleanCellValue); break;
                case CellType.Formula: newCell.SetCellFormula(srcCell.CellFormula); break;
                default: newCell.SetCellValue(srcCell.ToString()); break;
            }
        }


    }
}