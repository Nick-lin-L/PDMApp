using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PDMApp.Dtos.BasicProgram;
using PDMApp.Dtos.PLM.CBD;
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

        public async Task<object> ExeclImport(Parameters.PLM.CBD.CbdQueryParameter.CbdExcel value)
        {
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
        public async Task<IEnumerable<object>> DropDown(string key, string parameter)
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
    }
}