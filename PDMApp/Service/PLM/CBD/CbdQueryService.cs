using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PDMApp.Dtos.BasicProgram;
using PDMApp.Dtos.PLM.CBD;
using PDMApp.Extensions;
using PDMApp.Models;

namespace PDMApp.Service.PLM.CBD
{
    public class CbdQueryService : ICbdQueryService
    {
        private readonly pcms_pdm_testContext _context;
        private readonly ILogger<CbdQueryService> _logger;

        public CbdQueryService(pcms_pdm_testContext context, ILogger<CbdQueryService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<dynamic> ExcelImport(Parameters.PLM.CBD.CbdQueryParameter.CbdExcel value)
        {
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
                var ver = await _context.plm_cbd_head.Where(x => x.bom.Equals(value.DevNo) &&
                                                                              x.colors.Equals(value.DevColorName) &&
                                                                              x.stage.Equals(value.Stage)).
                                                                    Select(x => x.ver).MaxAsync();
                ver = (ver ?? -1) + 1;
                string data_m_id;
                var query = from head in _context.plm_product_head
                            join item in _context.plm_product_item
                            on head.product_m_id equals item.product_m_id
                            where head.development_no == value.DevNo && item.development_color_no == value.DevColorName
                            select item.product_d_id;
                string product_d_id = await query.FirstOrDefaultAsync<string>();
                using (var Command = _context.Database.GetDbConnection().CreateCommand())
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

                _context.plm_cbd_head.Add(_plm_cbd_head);
                int i = 1;
                plm_cbd_item previou = null;
                foreach (var _upper in value.Data.Upper)
                {
                    var item = new plm_cbd_item();
                    item.SetValues(_upper.GetPropertiesWithValues());
                    item.data_m_id = data_m_id;
                    item.data_d_id = Guid.NewGuid().ToString();
                    item.data_id = item.data_d_id;
                    item.partclass = "A";
                    item.group_mk = string.IsNullOrWhiteSpace(item.no) ? "N" : "Y";
                    if (string.IsNullOrWhiteSpace(item.no) && previou != null)
                    {
                        item.act_parts = previou.act_parts;
                        item.act_no = previou.act_no;
                    }
                    item.seqno = i;
                    i++;
                    previou = item;
                    _context.plm_cbd_item.Add(item);
                }
                i = 1;
                previou = null;
                foreach (var sole in value.Data.Sole)
                {
                    var item = new plm_cbd_item();
                    item.SetValues(sole.GetPropertiesWithValues());
                    item.data_m_id = data_m_id;
                    item.data_d_id = Guid.NewGuid().ToString();
                    item.data_id = item.data_d_id;
                    item.partclass = "B";
                    item.group_mk = string.IsNullOrWhiteSpace(item.no) ? "N" : "Y";
                    if (string.IsNullOrWhiteSpace(item.no) && previou != null)
                    {
                        item.act_parts = previou.act_parts;
                        item.act_no = previou.act_no;
                    }
                    item.seqno = i;
                    i++;
                    previou = item;
                    _context.plm_cbd_item.Add(item);
                }
                i = 1;
                previou = null;
                foreach (var other in value.Data.Other)
                {
                    var item = new plm_cbd_item();
                    item.SetValues(other.GetPropertiesWithValues());
                    item.data_m_id = data_m_id;
                    item.data_d_id = Guid.NewGuid().ToString();
                    item.data_id = item.data_d_id;
                    item.partclass = "C";
                    item.group_mk = string.IsNullOrWhiteSpace(item.no) ? "N" : "Y";
                    if (string.IsNullOrWhiteSpace(item.no) && previou != null)
                    {
                        item.act_parts = previou.act_parts;
                        item.act_no = previou.act_no;
                    }
                    item.seqno = i;
                    i++;
                    previou = item;
                    _context.plm_cbd_item.Add(item);
                }
                foreach (var mold in value.Data.MoldCharge)
                {
                    var item = new plm_cbd_moldcharge();
                    item.SetValues(mold.GetPropertiesWithValues());
                    item.data_m_id = data_m_id;
                    item.data_d_id = Guid.NewGuid().ToString();
                    _context.plm_cbd_moldcharge.Add(item);
                }
                int row = _context.SaveChanges();
                var data = new Dictionary<string, object>();
                data["udpate_row"] = row;
                data["DataMID"] = data_m_id;
                return data;
            }
            catch
            {
                throw;
            }

            throw new NotImplementedException();
        }
        public async Task<IEnumerable<object>> Stage()
        {
            try
            {
                return await _context.pdm_namevalue.Where(x => x.group_key == "stage").
                                                    Select(x => new { Id = x.value_desc, Value = x.text, Text = @$"{x.value_desc}[{x.text}]" }).
                                                    Distinct().
                                                    ToListAsync();
            }
            catch (Exception e)
            {
                MethodBase currentMethod = MethodBase.GetCurrentMethod();
                string namespaceName = this.GetType().Namespace;// 取得命名空間
                string className = this.GetType().Name;// 取得類別名稱
                string functionName = currentMethod.Name;// 取得函式名稱
                _logger.LogError(namespaceName);
                _logger.LogError(className);
                _logger.LogError(functionName);
                _logger.LogError(e.Message);
                throw;
            }
        }
        public async Task<IEnumerable<object>> Stage(string parameter)
        {
            try
            {
                return await _context.pdm_namevalue.Where(x => x.group_key == "stage").
                                                    Where(x => (x.value_desc ?? "").StartsWith(parameter)).
                                                    Select(x => new { Id = x.value_desc, Value = x.text, Text = @$"{x.value_desc}[{x.text}]" }).
                                                    Distinct().
                                                    ToListAsync();
            }
            catch (Exception e)
            {
                MethodBase currentMethod = MethodBase.GetCurrentMethod();
                string namespaceName = this.GetType().Namespace;// 取得命名空間
                string className = this.GetType().Name;// 取得類別名稱
                string functionName = currentMethod.Name;// 取得函式名稱
                _logger.LogError(namespaceName);
                _logger.LogError(className);
                _logger.LogError(functionName);
                _logger.LogError(e.Message);
                throw;
            }
        }
        public async Task<IEnumerable<object>> Color_no()
        {
            try
            {
                return await _context.plm_product_item.Where(x => !string.IsNullOrWhiteSpace(x.development_color_no)).
                                                        Select(x => new { Id = x.development_color_no, Value = x.color_code, Text = @$"{x.development_color_no}[{x.color_code}]" }).
                                                        Distinct().
                                                        ToListAsync();
            }
            catch (Exception e)
            {
                MethodBase currentMethod = MethodBase.GetCurrentMethod();
                string namespaceName = this.GetType().Namespace;// 取得命名空間
                string className = this.GetType().Name;// 取得類別名稱
                string functionName = currentMethod.Name;// 取得函式名稱
                _logger.LogError(namespaceName);
                _logger.LogError(className);
                _logger.LogError(functionName);
                _logger.LogError(e.Message);
                throw;
            }
        }
        public async Task<IEnumerable<object>> Color_no(string parameter)
        {
            try
            {
                return await _context.plm_product_item.Where(x => (x.development_color_no ?? "").StartsWith(parameter)).
                                                        Select(x => new { Id = x.development_color_no, Value = x.color_code, Text = @$"{x.development_color_no}[{x.color_code}]" }).
                                                        Distinct().
                                                        ToListAsync();
            }
            catch (Exception e)
            {
                MethodBase currentMethod = MethodBase.GetCurrentMethod();
                string namespaceName = this.GetType().Namespace;// 取得命名空間
                string className = this.GetType().Name;// 取得類別名稱
                string functionName = currentMethod.Name;// 取得函式名稱
                _logger.LogError(namespaceName);
                _logger.LogError(className);
                _logger.LogError(functionName);
                _logger.LogError(e.Message);
                throw;
            }
        }
        public async Task<IEnumerable<object>> Dev_no()
        {
            try
            {
                return await _context.plm_product_head.Where(x => !string.IsNullOrWhiteSpace(x.development_no)).
                                                        Select(x => new { Id = x.development_no, Value = x.development_no, Text = x.development_no }).
                                                        Distinct().
                                                        ToListAsync();
            }
            catch (Exception e)
            {
                MethodBase currentMethod = MethodBase.GetCurrentMethod();
                string namespaceName = this.GetType().Namespace;// 取得命名空間
                string className = this.GetType().Name;// 取得類別名稱
                string functionName = currentMethod.Name;// 取得函式名稱
                _logger.LogError(namespaceName);
                _logger.LogError(className);
                _logger.LogError(functionName);
                _logger.LogError(e.Message);
                throw;
            }
        }
        public async Task<IEnumerable<object>> Dev_no(string parameter)
        {
            try
            {
                return await _context.plm_product_head.Where(x => (x.development_no ?? "").StartsWith(parameter)).
                                                        Select(x => new { Id = x.development_no, Value = x.development_no, Text = x.development_no }).
                                                        Distinct().
                                                        ToArrayAsync();
            }
            catch (Exception e)
            {
                MethodBase currentMethod = MethodBase.GetCurrentMethod();
                string namespaceName = this.GetType().Namespace;// 取得命名空間
                string className = this.GetType().Name;// 取得類別名稱
                string functionName = currentMethod.Name;// 取得函式名稱
                _logger.LogError(namespaceName);
                _logger.LogError(className);
                _logger.LogError(functionName);
                _logger.LogError(e.Message);
                throw;
            }
        }
        public async Task<IEnumerable<object>> DropDown(string key)
        {
            try
            {
                switch (key)
                {
                    case string s when Regex.IsMatch(s, "stage", RegexOptions.IgnoreCase):
                        return await Stage();
                    case string s when Regex.IsMatch(s, "Color_no", RegexOptions.IgnoreCase):
                        return await Color_no();
                    case string s when Regex.IsMatch(s, "Dev_no", RegexOptions.IgnoreCase):
                        return await Dev_no();
                    default:
                        throw new Exception("Not Match key");
                }
            }
            catch (Exception e)
            {
                MethodBase currentMethod = MethodBase.GetCurrentMethod();
                string namespaceName = this.GetType().Namespace;// 取得命名空間
                string className = this.GetType().Name;// 取得類別名稱
                string functionName = currentMethod.Name;// 取得函式名稱
                _logger.LogError(namespaceName);
                _logger.LogError(className);
                _logger.LogError(functionName);
                _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<dynamic> GetCbdDataByID(string Data_m_id)
        {

            try
            {
                var item = (from x in _context.plm_cbd_item
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
                var moldcharge = _context.plm_cbd_moldcharge.Where(x => x.data_m_id == Data_m_id).ToList();
                var upper = item.Where(z => z.Partclass == "A").OrderBy(x => x.Seqno).ToList();
                var sole = item.Where(z => z.Partclass == "B").OrderBy(x => x.Seqno).ToList();
                var other = item.Where(z => z.Partclass == "C").OrderBy(x => x.Seqno).ToList();
                var query = await (from ph in _context.plm_product_head
                                   join pi in _context.plm_product_item
                                   on ph.product_m_id equals pi.product_m_id
                                   join ch in _context.plm_cbd_head
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

                return dynamicData;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}