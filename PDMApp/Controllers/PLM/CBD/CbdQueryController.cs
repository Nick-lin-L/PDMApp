using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Npgsql;
using Npgsql.TypeHandlers.NetworkHandlers;
using PDMApp.Extensions;
using PDMApp.Models;
using PDMApp.Utils;
using static PDMApp.Dtos.PLM.CBD.CbdQueryDto;

namespace PDMApp.Controllers.PLM.CBD
{
    [Route("api/v1/PLM/[controller]/[action]")]
    [ApiController]
    public class CbdQueryController : ControllerBase
    {
        private readonly ILogger<CbdQueryController> _logger;
        private readonly pcms_pdm_testContext _pcms_Pdm_TestContext;
        public CbdQueryController(pcms_pdm_testContext pcms_Pdm_testContext, ILogger<CbdQueryController> logger)
        {
            _logger = logger;
            _pcms_Pdm_TestContext = pcms_Pdm_testContext;
        }
        [HttpGet]
        public async Task<ActionResult<APIStatusResponse<object>>> Development_nos()
        {
            var response = new APIStatusResponse<object>();
            try
            {

                response.Data = await _pcms_Pdm_TestContext.plm_product_head.Where(x => !string.IsNullOrWhiteSpace(x.development_no)).
                                                                             Select(x => x.development_no).
                                                                             Distinct().
                                                                             ToArrayAsync();
                response.Message = "OK";
                return response;
            }
            catch (Exception e)
            {
                var Data = new Dictionary<string, object>();
                response.ErrorCode = "20001";
                response.Message = e.Message;
                return response;
            }
        }
        [HttpGet("{Parameter}")]
        public async Task<ActionResult<APIStatusResponse<object>>> Development_nos(string Parameter)
        {
            var response = new APIStatusResponse<object>();
            try
            {
                response.Data = await _pcms_Pdm_TestContext.plm_product_head.Where(x => (x.development_no ?? "").StartsWith(Parameter)).
                                                                             Select(x => x.development_no).
                                                                             Distinct().
                                                                             ToArrayAsync();
                return response;
            }
            catch (Exception e)
            {
                var Data = new Dictionary<string, object>();
                response.ErrorCode = "20001";
                response.Message = e.Message;
                return response;
            }
        }

        [HttpGet]
        public async Task<ActionResult<APIStatusResponse<object>>> Colors()
        {
            var response = new APIStatusResponse<object>();
            try
            {

                response.Data = await _pcms_Pdm_TestContext.plm_product_item.Where(x => !string.IsNullOrWhiteSpace(x.development_color_no)).
                                                                             Select(x => new { key = x.development_color_no, displayvalue = @$"{x.development_color_no}[{x.color_code}]" }).
                                                                             Distinct().
                                                                             ToArrayAsync();
                response.Message = "OK";
                return response;
            }
            catch (Exception e)
            {
                var Data = new Dictionary<string, object>();
                response.ErrorCode = "20001";
                response.Message = e.Message;
                return response;
            }
        }
        [HttpGet("{Parameter}")]
        public async Task<ActionResult<APIStatusResponse<object>>> Colors(string Parameter)
        {
            var response = new APIStatusResponse<object>();
            try
            {
                response.Data = await _pcms_Pdm_TestContext.plm_product_item.Where(x => (x.development_color_no ?? "").StartsWith(Parameter)).
                                                                             Select(x => new { key = x.development_color_no, displayvalue = @$"{x.development_color_no}[{x.color_code}]" }).
                                                                             Distinct().
                                                                             ToArrayAsync();
                return response;
            }
            catch (Exception e)
            {
                var Data = new Dictionary<string, object>();
                response.ErrorCode = "20001";
                response.Message = e.Message;
                return response;
            }
        }

        [HttpGet]
        public async Task<ActionResult<APIStatusResponse<object>>> Stage()
        {
            var response = new APIStatusResponse<object>();
            try
            {

                response.Data = await _pcms_Pdm_TestContext.pdm_namevalue.Where(x => x.group_key == "stage").
                                                                             Select(x => new { key = x.value_desc, displayvalue = @$"{x.value_desc}[{x.text}]" }).
                                                                             Distinct().
                                                                             ToArrayAsync();
                response.Message = "OK";
                return response;
            }
            catch (Exception e)
            {
                var Data = new Dictionary<string, object>();
                response.ErrorCode = "20001";
                response.Message = e.Message;
                return response;
            }
        }
        [HttpGet("{Parameter}")]
        public async Task<ActionResult<APIStatusResponse<object>>> Stage(string Parameter)
        {
            var response = new APIStatusResponse<object>();
            try
            {
                var data = await _pcms_Pdm_TestContext.pdm_namevalue.Where(x => x.group_key == "stage" && (x.value_desc ?? "").StartsWith(Parameter)).
                                                                        Select(x => new { key = x.value_desc, displayvalue = @$"{x.value_desc}[{x.text}]" }).
                                                                        Distinct().
                                                                        ToArrayAsync();
                response.Data = data;
                if (data.Length == 0)
                {
                    response.Message = "No Data";
                }
                else
                {
                    response.Message = "OK";
                }
                return response;
            }
            catch (Exception e)
            {
                var Data = new Dictionary<string, object>();
                response.ErrorCode = "20001";
                response.Message = e.Message;
                return response;
            }
        }
        [HttpPost]
        public async Task<ActionResult<APIStatusResponse<Utils.PagedResult<Dtos.PLM.CBD.CbdQueryDto.QueryDto>>>> Query(Parameters.PLM.CBD.CbdQueryParameter parameter)
        {
            var response = new APIStatusResponse<Utils.PagedResult<object>>();
            try
            {
                var query = from ph in _pcms_Pdm_TestContext.plm_product_head
                            join pi in _pcms_Pdm_TestContext.plm_product_item
                            on ph.product_m_id equals pi.product_m_id
                            join ch in _pcms_Pdm_TestContext.plm_cbd_head
                            on pi.product_d_id equals ch.product_d_id
                            orderby ph.development_no ascending, ch.ver ascending
                            select new Dtos.PLM.CBD.CbdQueryDto.QueryDto
                            {
                                Data_m_id = ch.data_m_id,
                                Product_m_id = ph.product_m_id,
                                Product_d_id = ch.product_d_id,
                                Itemtrading_code = ph.item_trading_code,
                                Development_no = ph.development_no,
                                Development_color_no = pi.development_color_no,
                                Stage = ch.stage,
                                Stage_display = (from nv in _pcms_Pdm_TestContext.pdm_namevalue
                                                 where nv.group_key == "stage" && nv.value_desc == ch.stage
                                                 orderby nv.value_desc
                                                 select nv.text
                                         ).FirstOrDefault(),
                                Working_name = ph.working_name,
                                Color_code = pi.color_code,
                                Colorway = pi.colorway,
                                Bom = ch.bom,
                                Colors = ch.colors,
                                Vssver = ch.vssver,
                                Ver = ch.ver,
                                Cbd_update_user = ch.cbd_update_user,
                                Cbd_update_date = ch.cbd_update_date == null ? "" : ch.update_date.ToString(),
                                Update_user = ch.update_user,
                                Update_date = ch.update_date == null ? "" : ch.update_date.ToString(),
                            };
                if (!string.IsNullOrEmpty(parameter.color_code))
                {
                    query = query.Where(x => x.Color_code.Contains(parameter.color_code));
                }
                if (!string.IsNullOrEmpty(parameter.development_no))
                {
                    query = query.Where(x => x.Development_no.Contains(parameter.development_no));
                }
                if (!string.IsNullOrEmpty(parameter.stage))
                {
                    query = query.Where(x => x.Stage == parameter.stage);
                }
                if (!string.IsNullOrEmpty(parameter.working_name))
                {
                    query = query.Where(x => x.Working_name.Contains(parameter.working_name));
                }
                if (!string.IsNullOrEmpty(parameter.colorway))
                {
                    query = query.Where(x => x.Colorway.Contains(parameter.colorway));
                }
                if (!string.IsNullOrEmpty(parameter.colors))
                {
                    query = query.Where(x => x.Colors.Contains(parameter.colors));
                }
                if (!string.IsNullOrEmpty(parameter.itemtrading_code))
                {
                    query = query.Where(x => x.Itemtrading_code.Contains(parameter.itemtrading_code));
                }
                if (!string.IsNullOrEmpty(parameter.color_code))
                {
                    query = query.Where(x => x.Color_code.Contains(parameter.color_code));
                }
                var data = await query.ToPagedResultAsync(parameter.Pagination.PageNumber, parameter.Pagination.PageSize);
                return APIResponseHelper.HandlePagedApiResponse(data);
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    ErrorCode = "20001",
                    Message = "ServerError",
                    Details = e.Message
                });
            }
        }

        [HttpGet("{Data_m_id}")]
        public async Task<ActionResult<APIStatusResponse<object>>> CbdData(string Data_m_id)
        {
            // string stage_no = this.dgvHeadData.CurrentRow.Cells["STAGE"].Value.ToString();
            // string product_m_id = this.dgvHeadData.CurrentRow.Cells["PRODUCT_M_ID"].Value.ToString();
            // string product_d_id = this.dgvHeadData.CurrentRow.Cells["PRODUCT_D_ID"].Value.ToString();
            // if (stage_no.Length == 0)
            //     return;
            // string spec_m_id = AnalysisBL.Get_Spec_m_Id(product_d_id, stage_no);
            // if (spec_m_id.Length == 0)
            // {
            //     MessageBox.Show("not found spec data");
            // }
            var response = new APIStatusResponse<object>();
            try
            {
                var item = (from x in _pcms_Pdm_TestContext.plm_cbd_item
                            where x.data_m_id == Data_m_id
                            select new Dtos.PLM.CBD.CbdQueryDto.CbdItemDto
                            {
                                Data_m_id = x.data_m_id,
                                Data_d_id = x.data_d_id,
                                Data_id = x.data_id,
                                Seqno = x.seqno,
                                No = x.no,
                                Newmaterial = x.newmaterial,
                                Parts = x.parts,
                                Detail = x.detail,
                                Materialno = x.materialno,
                                Process_mk = x.process_mk,
                                Material = x.material,
                                Recycle = x.recycle,
                                Mtrcomment = x.mtrcomment,
                                Cbdcomment = x.cbdcomment,
                                Standard = x.standard,
                                Supplier = x.supplier,
                                Agent = x.agent,
                                Quotesupplier = x.quotesupplier,
                                Colors = x.colors,
                                Clrcomment = x.clrcomment,
                                Moldno = x.moldno,
                                Hcha = x.hcha,
                                Sec = x.sec,
                                Width = x.width,
                                Usage1 = x.usage1,
                                Usage2 = x.usage2,
                                Basicprice = x.basicprice,
                                Unitprice = x.unitprice,
                                Mtrloss = x.mtrloss,
                                Freight = x.freight,
                                Cost = x.cost,
                                Memo = x.memo,
                                Change_mk = x.change_mk,
                                Partclass = x.partclass,
                                Act_no = x.act_no,
                                Act_parts = x.act_parts,
                                Factory_mold_no = x.factory_mold_no,
                                Group_Mk = x.group_mk
                            }
                            ).AsQueryable();
                var moldcharge = _pcms_Pdm_TestContext.plm_cbd_moldcharge.Where(x => x.data_m_id == Data_m_id).ToList();
                var upper = item.Where(z => z.Partclass == "A").OrderBy(x => x.Seqno).ToList();
                var sole = item.Where(z => z.Partclass == "B").OrderBy(x => x.Seqno).ToList();
                var other = item.Where(z => z.Partclass == "C").OrderBy(x => x.Seqno).ToList();
                var query = await (from ph in _pcms_Pdm_TestContext.plm_product_head
                                   join pi in _pcms_Pdm_TestContext.plm_product_item
                                   on ph.product_m_id equals pi.product_m_id
                                   join ch in _pcms_Pdm_TestContext.plm_cbd_head
                                   on pi.product_d_id equals ch.product_d_id
                                   where ch.data_m_id == Data_m_id
                                   orderby ph.development_no ascending, ch.ver ascending
                                   select new
                                   {
                                       ph = ph,
                                       pi = pi,
                                       ch = ch
                                   }).FirstOrDefaultAsync();
                if (query == null)
                {
                    throw new Exception("Data not found");
                }
                var product_m_id = query.ph.product_m_id;
                var product_d_id = query.pi.product_d_id;
                var stage = query.ch.stage;

                // _logger.LogInformation(product_m_id);
                // _logger.LogInformation(product_d_id);
                // _logger.LogInformation(stage);
                // var specData = await (from ph in _pcms_Pdm_TestContext.pdm_spec_head
                //                       join pi in _pcms_Pdm_TestContext.pdm_spec_item
                //                       on ph.spec_m_id equals pi.spec_m_id
                //                       where ph.product_d_id == product_d_id && ph.stage == stage
                //                       select new
                //                       {
                //                           ph = ph,
                //                           pi = pi,
                //                       }).FirstOrDefaultAsync();

                var basic = new Dtos.PLM.CBD.CbdQueryDto.BasicDto();
                basic.SetValues(query.ch.GetPropertiesWithValues());
                basic.SetValues(query.pi.GetPropertiesWithValues());
                basic.SetValues(query.ph.GetPropertiesWithValues());

                var expense = new Dtos.PLM.CBD.CbdQueryDto.ExpenseDto();
                expense.SetValues(query.ph.GetPropertiesWithValues());
                expense.SetValues(query.ph.GetPropertiesWithValues());
                expense.SetValues(query.ch.GetPropertiesWithValues());

                foreach (var molditem in moldcharge)
                {
                    var tmp = new Dtos.PLM.CBD.CbdQueryDto.MoldDto();
                    tmp.SetValues(molditem.GetPropertiesWithValues());
                    expense.mold.Add(tmp);
                }
                var dynamicData = new Dictionary<string, object>
                {
                    { "BasicData", basic },
                    { "UpperData", upper },
                    { "SoleData", sole },
                    { "OtherData", other },
                    { "ExpenseData", expense }
                };

                response.Data = dynamicData;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                response.Message = e.Message;
                response.ErrorCode = "21001";
            }
            return response;
        }
        [HttpGet()]
        public async Task<ActionResult<APIStatusResponse<object>>> Initial()
        {
            var response = new APIStatusResponse<object>();
            try
            {
                var dev_no = await _pcms_Pdm_TestContext.plm_product_head.Where(x => !string.IsNullOrWhiteSpace(x.development_no)).
                                                                             Select(x => new { Id = x.development_no, Value = x.development_no, Text = x.development_no }).
                                                                             Distinct().
                                                                             ToListAsync();
                var development_color_no = await _pcms_Pdm_TestContext.plm_product_item.Where(x => !string.IsNullOrWhiteSpace(x.development_color_no)).
                                                                             Select(x => new { Id = x.development_color_no, Value = x.color_code, Text = @$"{x.development_color_no}[{x.color_code}]" }).
                                                                             Distinct().
                                                                             ToListAsync();
                var stage = await _pcms_Pdm_TestContext.pdm_namevalue.Where(x => x.group_key == "stage").
                                                                             Select(x => new { Id = x.value_desc, Value = x.text, Text = @$"{x.value_desc}[{x.text}]" }).
                                                                             Distinct().
                                                                             ToListAsync();

                var dynamicData = new Dictionary<string, object>
                {
                    { "Development_Color_no", development_color_no.OrderBy(x=>x.Id) },
                    { "Stage", stage.OrderBy(x=>x.Id) },
                    { "Development_No", dev_no }
                };

                response.Data = dynamicData;
                response.Message = "OK";
                return response;
            }
            catch (Exception e)
            {
                var Data = new Dictionary<string, object>();
                response.ErrorCode = "20001";
                response.Message = e.Message;
                return response;
            }
        }

        [HttpPost]
        public async Task<ActionResult<APIStatusResponse<object>>> Import(CbdExcel value)
        {
            var response = new APIStatusResponse<object>();
            var Data = new Dictionary<string, object>();
            try
            {
                if (String.IsNullOrWhiteSpace(value?.DevNo))
                {
                    throw new Exception("開發代號不可為空");
                }
                if (String.IsNullOrWhiteSpace(value?.DevColorName))
                {
                    throw new Exception("開發色號不可為空");
                }
                if (String.IsNullOrWhiteSpace(value?.Stage))
                {
                    throw new Exception("開發階段不可為空");
                }
                if (!String.Equals(value?.DevNo, value?.Data?.Header?.Bom))
                {
                    throw new Exception("開發代號與匯入不一致");
                }
                if (!String.Equals(value?.DevColorName, value?.Data?.Header?.Colors))
                {
                    throw new Exception("開發色號與匯入不一致");

                }
                if (!String.Equals(value?.Stage, value?.Data?.Header?.Stage))
                {
                    throw new Exception("開發階段與匯入不一致");
                }
                if (value.Data == null || value.Data.Header == null || value.Data.Upper == null ||
                    value.Data.Sole == null || value.Data.Other == null || value.Data.MoldCharge == null)
                {
                    throw new Exception("資料有誤，請檢查");
                }
                else if (value.Data.Upper.Count == 0 || value.Data.Sole.Count == 0 || value.Data.Other.Count == 0 || value.Data.MoldCharge.Count == 0)
                {
                    throw new Exception("資料有誤，請檢查");
                }
                var ver = await _pcms_Pdm_TestContext.plm_cbd_head.Where(x => x.bom.Equals(value.DevNo) &&
                                                                              x.colors.Equals(value.DevColorName) &&
                                                                              x.stage.Equals(value.Stage)).
                                                                    Select(x => x.ver).MaxAsync();
                ver = (ver ?? -1) + 1;
                string data_m_id;
                var query = from head in _pcms_Pdm_TestContext.plm_product_head
                            join item in _pcms_Pdm_TestContext.plm_product_item
                            on head.product_m_id equals item.product_m_id
                            where head.development_no == value.DevNo && item.development_color_no == value.DevColorName
                            select item.product_d_id;
                string product_d_id = await query.FirstOrDefaultAsync<string>();
                using (var Command = _pcms_Pdm_TestContext.Database.GetDbConnection().CreateCommand())
                {
                    try
                    {
                        Command.CommandText = "SELECT gen_random_uuid()";
                        if (Command.Connection.State != ConnectionState.Open)
                            Command.Connection.Open();

                        var result = await Command.ExecuteScalarAsync();
                        data_m_id = result.ToString();
                        Console.WriteLine(data_m_id);
                    }
                    catch (Exception e)
                    {
                        throw new Exception(@$"{e.Message}");
                    }
                }

                plm_cbd_head _plm_cbd_head = new plm_cbd_head();
                _plm_cbd_head.SetValues(value.Data.Header.GetPropertiesWithValues());
                _plm_cbd_head.data_m_id = data_m_id;
                _plm_cbd_head.checkoutmk = "N";
                _plm_cbd_head.speclockmk = "N";
                _plm_cbd_head.cbdlockmk = "N";
                _plm_cbd_head.create_user = "TEST";
                _plm_cbd_head.create_date = DateTime.Now;
                _plm_cbd_head.update_user = "TEST";
                _plm_cbd_head.update_date = DateTime.Now;
                _plm_cbd_head.product_d_id = product_d_id;
                _plm_cbd_head.ver = ver;

                _pcms_Pdm_TestContext.plm_cbd_head.Add(_plm_cbd_head);
                int i = 1;
                foreach (var _upper in value.Data.Upper)
                {
                    var item = new plm_cbd_item();
                    item.SetValues(_upper.GetPropertiesWithValues());
                    item.data_m_id = data_m_id;
                    item.data_d_id = Guid.NewGuid().ToString();
                    item.data_id = item.data_d_id;
                    item.partclass = "A";
                    item.seqno = i;
                    i++;
                    _pcms_Pdm_TestContext.plm_cbd_item.Add(item);
                }
                i = 1;
                foreach (var sole in value.Data.Sole)
                {
                    var item = new plm_cbd_item();
                    item.SetValues(sole.GetPropertiesWithValues());
                    item.data_m_id = data_m_id;
                    item.data_d_id = Guid.NewGuid().ToString();
                    item.data_id = item.data_d_id;
                    item.partclass = "B";
                    item.seqno = i;
                    i++;
                    _pcms_Pdm_TestContext.plm_cbd_item.Add(item);
                }
                i = 1;
                foreach (var other in value.Data.Other)
                {
                    var item = new plm_cbd_item();
                    item.SetValues(other.GetPropertiesWithValues());
                    item.data_m_id = data_m_id;
                    item.data_d_id = Guid.NewGuid().ToString();
                    item.data_id = item.data_d_id;
                    item.partclass = "C";
                    item.seqno = i;
                    i++;
                    _pcms_Pdm_TestContext.plm_cbd_item.Add(item);
                }
                foreach (var mold in value.Data.MoldCharge)
                {
                    var item = new plm_cbd_moldcharge();
                    item.SetValues(mold.GetPropertiesWithValues());
                    item.data_m_id = data_m_id;
                    item.data_d_id = Guid.NewGuid().ToString();
                    _pcms_Pdm_TestContext.plm_cbd_moldcharge.Add(item);
                }
                int row = _pcms_Pdm_TestContext.SaveChanges();
                response.Message = "OK";
                response.Data = Data;
                Data.Add("data_m_id", _plm_cbd_head.data_m_id);
                Data.Add("row", row);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is PostgresException postgresEx)
                {
                    // Console.WriteLine("SqlState", postgresEx.SqlState);
                    // Console.WriteLine("MessageText", postgresEx.MessageText);
                    // Console.WriteLine("Detail", postgresEx.Detail);
                    // Console.WriteLine("TableName", postgresEx.TableName);
                    // Console.WriteLine("ColumnName", postgresEx.ColumnName);
                    Data.Add("SqlState", postgresEx.SqlState);
                    Data.Add("MessageText", postgresEx.MessageText);
                    Data.Add("Detail", postgresEx.Detail);
                    Data.Add("TableName", postgresEx.TableName);
                    Data.Add("Column", postgresEx.ColumnName);
                    response.ErrorCode = "20001";
                    response.Message = ex.Message;
                    response.Data = Data;
                }
                else
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                    response.ErrorCode = "20001";
                    response.Message = ex.Message;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"檢核失敗: {e.Message}");
                response.ErrorCode = "20002";
                response.Message = e.Message;
            }

            return Ok(response);
        }



    }


}