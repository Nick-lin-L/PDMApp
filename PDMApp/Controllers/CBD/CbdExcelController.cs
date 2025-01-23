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
namespace PDMApp.Controllers.CBD
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class CbdExcelController : ControllerBase
    {
        private readonly pcms_pdm_testContext _pcms_Pdm_TestContext;

        public CbdExcelController(pcms_pdm_testContext pcms_Pdm_testContext)
        {
            _pcms_Pdm_TestContext = pcms_Pdm_testContext;
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
                    finally
                    {
                        Command.Connection.Close();
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

        [HttpPost]
        public async Task<ActionResult<IEnumerable<object>>> Development_Nos(CbdSearch _value)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(_value.Parameter))
                {
                    return await _pcms_Pdm_TestContext.plm_product_head.Select(x => x.development_no).ToArrayAsync();
                }
                else
                {
                    return await _pcms_Pdm_TestContext.plm_product_head.Where(x => x.development_no.StartsWith(_value.Parameter)).Select(x => x.development_no).ToArrayAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<object>>> Colors(CbdSearch _value)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(_value.Parameter))
                {
                    return await _pcms_Pdm_TestContext.plm_product_item.Select(x => new { key = x.development_color_no, value = x.color_code }).ToArrayAsync();
                }
                else
                {
                    return await _pcms_Pdm_TestContext.plm_product_item.Where(x => x.development_color_no.StartsWith(_value.Parameter)).
                                                                        Select(x => new { key = x.development_color_no, value = x.color_code }).ToArrayAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<object>>> Stages(CbdSearch _value)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(_value.Parameter))
                {
                    return await _pcms_Pdm_TestContext.pdm_namevalue.Select(x => new { key = x.value_desc, value = x.text }).ToArrayAsync();
                }
                else
                {
                    return await _pcms_Pdm_TestContext.pdm_namevalue.Where(x => x.value_desc.StartsWith(_value.Parameter)).
                                                                        Select(x => new { key = x.value_desc, value = x.text }).ToArrayAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }


        public class CbdSearch
        {
            public string Parameter { get; set; }
        }

        public class CbdExcel
        {
            [Required]
            public String DevNo { get; set; }
            [Required]
            public String DevColorName { get; set; }
            [Required]
            public String Stage { get; set; }
            [Required]
            public ExcelData Data { get; set; }
        }

        public class ExcelData
        {
            [Required]
            public HeaderData Header { get; set; }
            [Required]
            public List<cbd_item> Upper { get; set; }
            [Required]
            public List<cbd_item> Sole { get; set; }
            [Required]
            public List<cbd_item> Other { get; set; }
            [Required]
            public List<plm_cbd_moldcharge> MoldCharge { get; set; }
        }

        public class HeaderData
        {
            public string? Stage { get; set; }
            public string? Itemmode_Subtype { get; set; }
            public string? Currency { get; set; }
            public DateTime? Cbd_Update_Date { get; set; }
            public string? Size_Run { get; set; }
            public decimal? Targetprice { get; set; }
            public decimal? Finalprice { get; set; }
            public string? Sample_Size { get; set; }
            public string? Forecast { get; set; }
            public decimal? Subtotal { get; set; }
            public string? Lasting_Heelheight { get; set; }
            public string? Working_Name { get; set; }
            public decimal? Exsubtotal { get; set; }
            public decimal? Totalcost { get; set; }
            public string? Bom { get; set; }
            public decimal? Exmoldamortization { get; set; }
            public decimal? Commisiion { get; set; }
            public string? Colors { get; set; }
            public decimal? Exdirectlabor { get; set; }
            public decimal? Excommisiion { get; set; }
            public string? Factory { get; set; }
            public decimal? Exfactoryoverhead { get; set; }
            public decimal? Extotal { get; set; }
            public decimal? Materialcost { get; set; }
            public decimal? Exprofit { get; set; }
            public decimal? Cpcutting { get; set; }
            public decimal? Cpstiching { get; set; }
            public decimal? Cpoutsoleassembly { get; set; }
            public decimal? Cplasting { get; set; }
            public decimal? Umsubtotal { get; set; }
            public decimal? Smsubtotal { get; set; }
            public decimal? Omsubtotal { get; set; }
            public string? Cbd_remarks { get; set; }
        }

        public class cbd_item
        {
            public string? No { get; set; }
            public string? Parts { get; set; }
            public string? Detail { get; set; }
            public string? Material { get; set; }
            public string? Recycle { get; set; }
            public string? Process_mk { get; set; }
            public string? Mtrcomment { get; set; }
            public string? Cbdcomment { get; set; }
            public string? Hcha { get; set; }
            public string? Sec { get; set; }
            public string? Colors { get; set; }
            public string? Clrcomment { get; set; }
            public string? Supplier { get; set; }
            public string? Agent { get; set; }
            public string? Quotesupplier { get; set; }
            public string? Standard { get; set; }
            public string? Width { get; set; }
            public decimal? Usage1 { get; set; }
            public decimal? Usage2 { get; set; }
            public decimal? Basicprice { get; set; }
            public decimal? Unitprice { get; set; }
            public decimal? Mtrloss { get; set; }
            public decimal? Freight { get; set; }
            public decimal? Cost { get; set; }
        }

        public class moldcharge
        {
            public string? Item { get; set; }
            public decimal? Price { get; set; }
            public decimal? Amortization { get; set; }
            public int? Qty { get; set; }
            public decimal? Years { get; set; }
            public decimal? Rate { get; set; }
            public decimal? Unitprice { get; set; }
            public decimal? Cost { get; set; }
        }
    }
}