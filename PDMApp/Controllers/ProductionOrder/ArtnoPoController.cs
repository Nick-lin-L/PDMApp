using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Npgsql;
using PDMApp.Extensions;
using PDMApp.Models;
using PDMApp.Utils;

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
        public async Task<ActionResult<APIStatusResponse<IDictionary<string, object>>>> Initial(Parameters.ProductionOrder.ArtPoParameter.InitialParameter value)
        {
            var response = new APIStatusResponse<object>();
            try
            {
                var resultData = new Dictionary<string, object>();
                resultData["BrandCombo"] = await _icomboService.BrandNo(value.DevFactoryNo);
                resultData["OrderStatusCombo"] = await _icomboService.OrderStatus();
                resultData["StageCombo"] = await _icomboService.Stage();
                resultData["SeasonCombo"] = await _artnoPoService.GetSeason(value.DevFactoryNo);
                resultData["ShoeKindCombo"] = await _artnoPoService.GetShoeKind(value.DevFactoryNo);
                resultData["OrderKindCombo"] = (await _artnoPoService.GetNameValueByKey(value.DevFactoryNo, "order_kind")).Select(x => new { Text = x.text, Value = x.value_desc }).ToList();
                // 封裝結果並回傳
                return APIResponseHelper.HandleDynamicMultiPageResponse(resultData);
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
                // if (!parameter.ValidationParameter(3))
                // {
                //     throw new Exception("查詢條件不可以都為空");
                // }
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
        public async Task<ActionResult<APIStatusResponse<object>>> CreateDetailData(Parameters.ProductionOrder.ArtPoParameter.DetailDataParameter parameter)
        {
            var response = new APIStatusResponse<object>();
            try
            {
                var data = await _artnoPoService.CreateDetailData(parameter);
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
        public async Task<ActionResult<APIStatusResponse<object>>> DetleteDetailData(Parameters.ProductionOrder.ArtPoParameter.DetailDataParameter parameter)
        {
            var response = new APIStatusResponse<object>();
            try
            {
                var data = await _artnoPoService.DeleteDetailData(parameter);
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
        public async Task<object> QueryPicker(Parameters.ProductionOrder.ArtPoParameter.QueryPickerParameter parameter)
        {
            try
            {
                var response = new APIStatusResponse<object>();
                response.Data = await _artnoPoService.QueryPicker(parameter);
                response.ErrorCode = "OK";
                return response;
                //至少需輸入3個條件
                // if (!parameter.ValidationParameter(3))
                // {
                //     throw new Exception("查詢條件不可以都為空");
                // }
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


        [HttpGet]
        public async Task<ActionResult<APIStatusResponse<object>>> GetGlobalUser()
        {
            var response = new APIStatusResponse<object>();
            try
            {
                response.Data = await _Context.global_users.FirstAsync();

            }
            catch (DbUpdateConcurrencyException ex)
            {
                response.Message = ex.Message;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            finally
            {

            }
            return response;
        }
        [HttpPost]
        public async Task<ActionResult<APIStatusResponse<object>>> GlobalUser(global_users Parameter)
        {
            var response = new APIStatusResponse<object>();
            try
            {
                using (var transaction = await _Context.Database.BeginTransactionAsync())
                {
                    var global_user = await _Context.global_users.Where(x => x.pccuid == Parameter.pccuid).FirstOrDefaultAsync();

                    global_user.chinese_nm = "Dennis";
                    _Context.Update(global_user);
                    await _Context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }

            }
            catch (DbUpdateConcurrencyException ex)
            {
                response.Message = ex.Message;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            finally
            {

            }
            return response;
        }

    }
}