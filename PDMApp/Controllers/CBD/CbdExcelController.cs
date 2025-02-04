using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDMApp.Dtos.Spec;
using PDMApp.Models;
using PDMApp.Parameters.Cbd;
using PDMApp.Utils;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PDMApp.Extensions;
using System.ComponentModel;
using Npgsql;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using Microsoft.Extensions.Logging;
using static PDMApp.Dtos.Cbd.CbdExcelDto;
namespace PDMApp.Controllers.CBD
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class CbdExcelController : ControllerBase
    {
        private readonly pcms_pdm_testContext _pcms_Pdm_TestContext;
        private readonly ILogger<CbdExcelController> _logger;

        public CbdExcelController(pcms_pdm_testContext pcms_Pdm_testContext, ILogger<CbdExcelController> logger)
        {
            _pcms_Pdm_TestContext = pcms_Pdm_testContext;
            _logger = logger;
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