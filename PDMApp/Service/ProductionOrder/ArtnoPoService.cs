using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Report.Utils;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Npgsql;
using NPOI.SS.Formula.Functions;
using PDMApp.Models;
using PDMApp.Service.Basic;
using SixLabors.ImageSharp;

namespace PDMApp.Service.ProductionOrder
{
    public class ArtnoPoService : IArtnoPoService
    {
        private readonly pcms_pdm_testContext _context;
        private readonly ILogger<ArtnoPoService> _logger;
        private readonly ICurrentUserService _currentUserService;

        public ArtnoPoService(pcms_pdm_testContext context, ILogger<ArtnoPoService> logger, ICurrentUserService currentUserService)
        {
            _context = context;
            _logger = logger;
            _currentUserService = currentUserService;
        }
        public async Task<IQueryable<Dtos.ProductionOrder.ArtPoDto.QueryDto>> Search(Parameters.ProductionOrder.ArtPoParameter.QueryParameter parameter)
        {
            var orderStatus = await GetWorkSataus(parameter.OrderStatus);
            _logger.LogInformation($"orderStatus: {orderStatus}");
            var brand = await GetBrand(parameter.DevFactoryNo, parameter.Brand);
            _logger.LogInformation($"brand: {brand}");
            var query = from m in _context.work_order_head
                        where (m.order_type == "1") &&
                              (m.fact_no == parameter.DevFactoryNo) &&
                              (m.brand_no == brand) &&
                              (string.IsNullOrWhiteSpace(parameter.OrderNo) || m.order_no.Contains(parameter.OrderNo)) &&
                              (string.IsNullOrWhiteSpace(parameter.ModelName) || m.model_nm.Contains(parameter.ModelName)) &&
                              (string.IsNullOrWhiteSpace(parameter.DevelopmentNo) || m.dev_no.Contains(parameter.DevelopmentNo)) &&
                              (string.IsNullOrWhiteSpace(parameter.ArticleNo) || m.article_no.Contains(parameter.ArticleNo)) &&
                              (string.IsNullOrWhiteSpace(parameter.Season) || m.season.Contains(parameter.Season)) &&
                              (string.IsNullOrWhiteSpace(parameter.OrderStatus) || m.order_status == orderStatus)
                        select new Dtos.ProductionOrder.ArtPoDto.QueryDto
                        {
                            DevFactoryNo = m.fact_no,
                            WkMId = m.wk_m_id,
                            Brand = (from nv in _context.pdm_namevalue_new where nv.group_key == "brand" && nv.status == "Y" && nv.value_desc == m.brand_no && nv.fact_no == m.fact_no select nv.text).FirstOrDefault(),
                            OrderNo = m.order_no,
                            OrderPurchase = m.purpose,
                            OrderKind = (from nv in _context.pdm_namevalue_new where nv.group_key == "order_kind" && nv.status == "Y" && nv.value_desc == m.order_kind && nv.fact_no == m.fact_no select nv.text).FirstOrDefault(),
                            DevelopmentNo = m.dev_no,
                            Season = m.season,
                            ModelName = m.model_nm,
                            ColorNo = m.color_no,
                            ColorWay = m.colorway,
                            Stage = (from nv in _context.pdm_namevalue_new where nv.group_key == "stage" && nv.status == "Y" && nv.value_desc == m.stage && nv.fact_no == m.fact_no select nv.text).FirstOrDefault(),
                            OrderStatus = (from sv in _context.sys_namevalue where sv.group_key == "wkorder_status" && sv.status == "Y" && sv.data_no == m.order_status select sv.text).FirstOrDefault(),
                            ArticleNo = m.article_no,
                            Category = m.category,
                            Gender = m.gender,
                            MoldNo = m.mold_no,
                            LastNo = m.last_no,
                            LastWidth = m.last_width,
                            ReqDate = m.req_date.HasValue ? DateTime.Parse(m.req_date.ToString()).ToString("yyyy/MM/dd hh:mm:sss") : "",
                            Definition = m.type_definition,
                            CustomSr = m.cust_sr,
                            CustomPm = m.b_pm,
                            SampleSize = m.sample_size,
                            FGType = (from nv in _context.pdm_namevalue_new where nv.group_key == "fg_type" && nv.status == "Y" && nv.value_desc == m.fg_type && nv.fact_no == m.fact_no select nv.text).FirstOrDefault(),
                            DelMk = m.del_mk.ToString(),
                            DelDate = m.del_date.ToString(),
                            SerpErrorMsg = m.err_msg,
                            Memo1 = m.txt_attrib_01,
                            Memo2 = m.txt_attrib_02,
                            Memo3 = m.txt_attrib_03,
                            Memo4 = m.txt_attrib_04,
                            Memo5 = m.txt_attrib_05,
                            Memo6 = m.txt_attrib_06,
                            Memo7 = m.txt_attrib_07,
                            Memo8 = m.txt_attrib_08,
                            Memo9 = m.txt_attrib_09,
                            Memo10 = m.txt_attrib_10,
                            Memo11 = m.txt_attrib_11,
                            Memo12 = m.txt_attrib_12,
                            Memo13 = m.txt_attrib_13,
                            Memo14 = m.txt_attrib_14,
                            Memo15 = m.txt_attrib_15,
                            Memo16 = m.txt_attrib_16,
                            Memo17 = m.txt_attrib_17,
                            Memo18 = m.txt_attrib_18,
                            Memo19 = m.txt_attrib_19,
                            Memo20 = m.txt_attrib_20,
                            StyleId = m.style_id,
                            RowVersion = m.RowVersion,
                        };
            return query;
        }
        public async Task<List<Dtos.ProductionOrder.ArtPoDto.QueryDetailDto>> SearchDetail(Parameters.ProductionOrder.ArtPoParameter.QueryDetailParameter parameter)
        {
            var query = from m in _context.work_order_head
                        join d in _context.work_order_item
                        on m.wk_m_id equals d.wk_m_id
                        where m.wk_m_id == parameter.WkMId
                        select new Dtos.ProductionOrder.ArtPoDto.QueryDetailDto
                        {
                            WkMId = m.wk_m_id,
                            WkDId = d.wk_d_id,
                            Sort = d.sort,
                            TransMk = d.trans_mk,
                            ShoeKind = d.shoe_kind,
                            SizeNo = d.size_no,
                            Qty = d.qty,
                            DelMk = d.del_mk.ToString(),
                            RowVersion = d.RowVersion,
                        };
            return await query.ToListAsync();
        }
        public async Task<Dtos.ProductionOrder.ArtPoDto.QueryDto> CreateMainData(Parameters.ProductionOrder.ArtPoParameter.MainDataParameter parameter)
        {
            try
            {
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    var brand = await GetBrand(parameter.DevFactoryNo, parameter.Brand);
                    if (string.IsNullOrWhiteSpace(brand))
                    {
                        throw new Exception($@"Brand: {parameter.Brand} not exist");
                    }
                    var stage = (await GetNameValueByKey(parameter.DevFactoryNo, "stage")).Where(x => x.text == parameter.Stage).FirstOrDefault()?.value_desc;
                    if (string.IsNullOrWhiteSpace(stage))
                    {
                        throw new Exception($@"Stage: {parameter.Brand} not exist System");
                    }
                    var OrderKind = (await GetNameValueByKey(parameter.DevFactoryNo, "order_kind")).Where(x => x.text == parameter.OrderKind).FirstOrDefault()?.value_desc;
                    if (string.IsNullOrWhiteSpace(OrderKind))
                    {
                        throw new Exception($@"OrderKind: {parameter.OrderKind} not exist System");
                    }
                    if (string.IsNullOrWhiteSpace(parameter.DevFactoryNo) ||
                        string.IsNullOrWhiteSpace(parameter.OrderKind) ||
                        string.IsNullOrWhiteSpace(parameter.DevelopmentNo) ||
                        string.IsNullOrWhiteSpace(parameter.Stage) ||
                        string.IsNullOrWhiteSpace(parameter.Season) ||
                        string.IsNullOrWhiteSpace(parameter.ModelName) ||
                        string.IsNullOrWhiteSpace(parameter.ArticleNo))
                    {
                        throw new Exception($@"Stage、OrderKind、DevelopmentNo、Season、ModelName、ArticleNo is can be empty !");
                    }
                    //若ORDER_NO不為空，則需判斷不存在系統，若存在系統，則跳出訊息：″系統已存在派工單號：XXXXXX，請重新確認單據號碼″。
                    var orderCount = _context.work_order_head.Where(x => x.fact_no == parameter.DevFactoryNo && x.order_no == parameter.OrderNo).Count();
                    if (!string.IsNullOrWhiteSpace(parameter.OrderNo) && orderCount > 0)
                    {
                        throw new Exception($@"系統已存在派工單號：{parameter.OrderNo}，請重新確認單據號碼");
                    }
                    var data = new work_order_head();
                    data.wk_m_id = Guid.NewGuid().ToString();
                    data.fact_no = parameter.DevFactoryNo;
                    data.brand_no = brand;
                    data.order_no = parameter.OrderNo ?? "";
                    data.purpose = parameter.OrderPurchase;
                    data.order_kind = OrderKind;
                    data.dev_no = parameter.DevelopmentNo;
                    data.season = parameter.Season;
                    data.model_nm = parameter.ModelName;
                    data.color_no = parameter.ColorNo;
                    data.colorway = parameter.ColorWay;
                    data.stage = stage;
                    data.article_no = parameter.ArticleNo;
                    data.category = parameter.Category;
                    data.mold_no = parameter.MoldNo;
                    data.last_no = parameter.LastNo;
                    data.last_width = parameter.LastWidth;
                    if (!string.IsNullOrWhiteSpace(parameter.ReqDate))
                    {
                        data.req_date = DateTime.ParseExact(parameter.ReqDate, "yyyyMMdd",
                            System.Globalization.CultureInfo.InvariantCulture);
                        // data.req_date = Convert.ToDecimal(new DateTimeOffset(dateTime).ToUnixTimeMilliseconds());
                    }


                    data.gender = parameter.Gender;
                    //點擊存檔時，將ORDER_STATUS='OPEN'、ORDER_TYPE='1'、CREATE_USER & MODIFY_USER寫入使用者PCCUID、CREATE_DATE & MODIFY_DATE寫入現在日期時間、WK_M_ID=UUID(36)
                    data.order_type = "1";
                    data.order_status = "OPEN";
                    data.create_user = _currentUserService.UserId == null ? 0 : decimal.Parse(_currentUserService.PccUid);
                    data.create_time = DateTime.Now;
                    data.modify_user = _currentUserService.UserId == null ? 0 : decimal.Parse(_currentUserService.PccUid);
                    data.modify_time = DateTime.Now;
                    _context.Add(data);
                    try
                    {
                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();
                    }
                    catch
                    {
                        await transaction.RollbackAsync(); // 發生錯誤時 rollback
                        throw; // 重新拋出例外
                    }
                    return await GetDataById(data.fact_no, data.wk_m_id);
                }
            }
            catch (DbUpdateException ex) when (ex.InnerException is PostgresException pgEx)
            {
                string errmsg = "";
                switch (pgEx.SqlState)
                {
                    case PostgresErrorCodes.UniqueViolation:
                        errmsg = "違反唯一約束";
                        Console.WriteLine(errmsg);
                        break;
                    case PostgresErrorCodes.ForeignKeyViolation:
                        errmsg = "違反外鍵約束";
                        Console.WriteLine(errmsg);
                        break;
                    default:
                        errmsg = $"Postgres 錯誤代碼: {pgEx.SqlState}, 訊息: {pgEx.Message}";
                        Console.WriteLine(errmsg);
                        break;
                }
                throw;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw;
            }
            catch (Exception e)
            {
                throw;
            }

        }
        public async Task<Dtos.ProductionOrder.ArtPoDto.QueryDto> UpdateMainData(Parameters.ProductionOrder.ArtPoParameter.MainDataParameter parameter)
        {
            try
            {

                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    var data = await _context.work_order_head.Where(x => x.wk_m_id == parameter.WkMId && x.fact_no == parameter.DevFactoryNo).FirstOrDefaultAsync();
                    if (data == null)
                    {
                        throw new Exception($@"WorkOrder: {parameter.WkMId} not exist");
                    }
                    if (data.order_status == "INPRG")
                    {
                        throw new Exception($@"派工單正拋轉SERP中，不可再被異動");
                    }
                    if (data.order_status == "APPD" || data.order_status == "REJD")
                    {
                        if (!string.Equals(data.order_no, parameter.OrderNo))
                        {
                            throw new Exception($@"ORDER_STATUS in ('APPD'、'REJD')，ORDER_NO不可修改");
                        }
                    }
                    var brand = await GetBrand(parameter.DevFactoryNo, parameter.Brand);
                    if (string.IsNullOrWhiteSpace(brand))
                    {
                        throw new Exception($@"Brand: {parameter.Brand} not exist");
                    }
                    var stage = (await GetNameValueByKey(parameter.DevFactoryNo, "stage")).Where(x => x.text == parameter.Stage).FirstOrDefault()?.value_desc;
                    if (string.IsNullOrWhiteSpace(stage))
                    {
                        throw new Exception($@"Stage: {parameter.Brand} not exist System");
                    }
                    var OrderKind = (await GetNameValueByKey(parameter.DevFactoryNo, "order_kind")).Where(x => x.text == parameter.OrderKind).FirstOrDefault()?.value_desc;
                    if (string.IsNullOrWhiteSpace(OrderKind))
                    {
                        throw new Exception($@"OrderKind: {parameter.OrderKind} not exist System");
                    }
                    if (string.IsNullOrWhiteSpace(parameter.DevFactoryNo) ||
                        string.IsNullOrWhiteSpace(parameter.OrderKind) ||
                        string.IsNullOrWhiteSpace(parameter.DevelopmentNo) ||
                        string.IsNullOrWhiteSpace(parameter.Stage) ||
                        string.IsNullOrWhiteSpace(parameter.Season) ||
                        string.IsNullOrWhiteSpace(parameter.ModelName) ||
                        string.IsNullOrWhiteSpace(parameter.ArticleNo))
                    {
                        throw new Exception($@"Stage、OrderKind、DevelopmentNo、Season、ModelName、ArticleNo is can be empty !");
                    }
                    if (data.RowVersion != parameter.RowVersion)
                    {
                        throw new Exception($@"Data has been modified , please Refresh data again !");
                    }
                    var orderCount = _context.work_order_head.Where(x => x.fact_no == parameter.DevFactoryNo && x.order_no != parameter.OrderNo).Count();
                    if (string.IsNullOrWhiteSpace(parameter.OrderNo) && orderCount > 0)
                    {
                        throw new Exception($@"系統已存在派工單號：{parameter.OrderNo}，請重新確認單據號碼");
                    }
                    else
                    {
                        data.order_no = parameter.OrderNo;
                    }

                    data.brand_no = brand;
                    data.purpose = parameter.OrderPurchase;
                    data.order_kind = OrderKind;
                    data.dev_no = parameter.DevelopmentNo;
                    data.season = parameter.Season;
                    data.model_nm = parameter.ModelName;
                    data.color_no = parameter.ColorNo;
                    data.colorway = parameter.ColorWay;
                    data.stage = stage;
                    data.article_no = parameter.ArticleNo;
                    data.category = parameter.Category;
                    data.mold_no = parameter.MoldNo;
                    data.last_no = parameter.LastNo;
                    data.last_width = parameter.LastWidth;
                    if (!string.Equals(parameter.DelMk, data.del_mk))
                    {
                        data.del_mk = char.Parse(parameter.DelMk);
                        if ("Y" == parameter.DelMk)
                        {
                            data.del_date = DateTime.Now;
                        }
                        else if ("N" == parameter.DelMk)
                        {
                            data.del_date = null;
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(parameter.ReqDate))
                    {
                        var req_date = DateTime.Parse(parameter.ReqDate);
                        bool isDifferentYearOrMonth = req_date.Year != data.req_date?.Year || req_date.Month != data.req_date?.Month;
                        if (isDifferentYearOrMonth)
                        {
                            data.report_sort = "";
                        }
                        data.req_date = req_date;
                    }
                    data.gender = parameter.Gender;
                    if (_context.Entry(data).State == EntityState.Modified)
                    {
                        if (data.order_status == "APPD" || data.order_status == "REJD")
                        {
                            data.order_status = "OPEN";
                        }

                        data.modify_user = _currentUserService.UserId == null ? 0 : decimal.Parse(_currentUserService.PccUid);
                        data.modify_time = DateTime.Now;
                        try
                        {
                            await _context.SaveChangesAsync();
                            await transaction.CommitAsync();
                        }
                        catch
                        {
                            await transaction.RollbackAsync(); // 發生錯誤時 rollback
                            throw; // 重新拋出例外
                        }
                    }
                    else
                    {
                        throw new Exception($@"Data never change !");
                    }
                    return await GetDataById(data.fact_no, data.wk_m_id);
                }
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
                throw;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception($@"Data has been modified , please Refresh data again !");
            }
            catch (Exception e)
            {
                throw;
            }

        }
        public async Task<List<Dtos.ProductionOrder.ArtPoDto.QueryDetailDto>> CreateDetailData(Parameters.ProductionOrder.ArtPoParameter.DetailDataParameter parameter)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var mainData = await _context.work_order_head.FindAsync(parameter.WkMId);
                    if (object.ReferenceEquals(mainData, null))
                    {
                        throw new Exception("main data not found!");
                    }
                    if (mainData.order_status == "INPRG")
                    {
                        throw new Exception($@"派工單正拋轉SERP中，不可再被異動");
                    }
                    // 先檢查是否有重複的數據
                    var existingItems = await _context.work_order_item
                        .Where(x => x.wk_m_id == parameter.WkMId && x.del_mk != 'Y')
                        .Select(x => new { x.shoe_kind, x.size_no })
                        .ToListAsync();

                    var newItems = parameter.DetailData
                        .Select(x => new { shoe_kind = x.ShoeKind, size_no = x.SizeNo });

                    // 合併現有和新的記錄來檢查重複
                    var allItems = existingItems.Concat(newItems);
                    var duplicates = allItems
                        .GroupBy(x => new { x.shoe_kind, x.size_no })
                        .Where(g => g.Count() > 1)
                        .Select(g => new { g.Key.shoe_kind, g.Key.size_no })
                        .ToList();

                    if (duplicates.Any())
                    {
                        var duplicateInfo = string.Join(", ",
                            duplicates.Select(d => $"鞋型:{d.shoe_kind} 尺寸:{d.size_no}"));
                        throw new Exception($"發現重複資料: {duplicateInfo}");
                    }
                    var sort = await _context.work_order_item
                                                      .Where(x => x.wk_m_id == parameter.WkMId && x.del_mk.ToString() != "Y")
                                                      .Where(x => string.IsNullOrWhiteSpace(x.sort))
                                                      .Where(x => x.sort.IsNumber())
                                                      .Select(x => x.sort)
                                                      .MaxAsync();
                    var sortNum = decimal.Parse(sort);
                    foreach (var item in parameter.DetailData)
                    {
                        var detail = new work_order_item();
                        detail.wk_d_id = Guid.NewGuid().ToString();
                        detail.wk_m_id = parameter.WkMId;
                        detail.size_no = item.SizeNo;
                        detail.qty = (decimal)item.Qty;
                        detail.shoe_kind = item.ShoeKind;
                        detail.trans_mk = item.TransMk;
                        detail.sort = item.Sort.IsNumber() ? item.Sort : (++sortNum).ToString();
                        detail.modify_user = _currentUserService.UserId == null ? 0 : decimal.Parse(_currentUserService.PccUid);
                        detail.modify_date = DateTime.Now;
                        _context.Add(detail);
                        await _context.SaveChangesAsync();
                    }

                    await transaction.CommitAsync();
                    return await GetDetailById(parameter.WkMId);
                }
                catch
                {
                    await transaction.RollbackAsync(); // 發生錯誤時 rollback
                    throw;
                }
            }
        }
        public async Task<List<Dtos.ProductionOrder.ArtPoDto.QueryDetailDto>> UpdateDetailData(Parameters.ProductionOrder.ArtPoParameter.DetailDataParameter parameter)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var mainData = await _context.work_order_head.FindAsync(parameter.WkMId);
                    if (object.ReferenceEquals(mainData, null))
                    {
                        throw new Exception("main data not found!");
                    }
                    if (mainData.order_status == "INPRG")
                    {
                        throw new Exception($@"派工單正拋轉SERP中，不可再被異動");
                    }
                    var updateItemKey = parameter.DetailData.Where(x => x.DelMk != 'Y').Select(x => x.WkDId).ToList();
                    // 先檢查是否有重複的數據
                    var existingItems = await _context.work_order_item
                        .Where(x => x.wk_m_id == parameter.WkMId && x.del_mk != 'Y' && !updateItemKey.Contains(x.wk_d_id))
                        .Select(x => new { x.shoe_kind, x.size_no })
                        .ToListAsync();

                    var updateItem = parameter.DetailData.Select(x => new { shoe_kind = x.ShoeKind, size_no = x.SizeNo });

                    // 合併現有和新的記錄來檢查重複
                    var allItems = existingItems.Concat(updateItem);
                    var duplicates = allItems
                        .GroupBy(x => new { x.shoe_kind, x.size_no })
                        .Where(g => g.Count() > 1)
                        .Select(g => new { g.Key.shoe_kind, g.Key.size_no })
                        .ToList();

                    if (duplicates.Any())
                    {
                        var duplicateInfo = string.Join(", ",
                            duplicates.Select(d => $"鞋型:{d.shoe_kind} 尺寸:{d.size_no}"));
                        throw new Exception($"發現重複資料: {duplicateInfo}");
                    }
                    var sort = await _context.work_order_item
                                            .Where(x => x.wk_m_id == parameter.WkMId && x.del_mk.ToString() != "Y")
                                            .Where(x => string.IsNullOrWhiteSpace(x.sort))
                                            .Where(x => x.sort.IsNumber())
                                            .Select(x => x.sort)
                                            .MaxAsync();
                    var sortNum = decimal.Parse(sort);
                    // 記錄實際異動的筆數
                    int actualModifiedCount = 0;

                    foreach (var item in parameter.DetailData)
                    {
                        var detail = await _context.work_order_item.FindAsync(item.WkDId);
                        if (detail.RowVersion != item.RowVersion)
                        {
                            throw new Exception("Data has been modify");
                        }
                        detail.size_no = item.SizeNo;
                        detail.qty = (decimal)item.Qty;
                        detail.shoe_kind = item.ShoeKind;
                        detail.trans_mk = item.TransMk;
                        detail.sort = item.Sort.IsNumber() ? item.Sort : (++sortNum).ToString();
                        detail.del_mk = (char)item.DelMk;
                        if (_context.Entry(detail).State == EntityState.Modified)
                        {
                            detail.modify_user = _currentUserService.UserId == null ? 0 : decimal.Parse(_currentUserService.PccUid);
                            detail.modify_date = DateTime.Now;

                            // 執行單筆更新並累計異動筆數
                            int changes = await _context.SaveChangesAsync();
                            actualModifiedCount += changes;
                        }

                    }
                    // 獲取更新後的待異動筆數
                    int pendingChangesAfter = _context.ChangeTracker.Entries().Count(e => e.State != EntityState.Unchanged);
                    _logger.LogInformation($"更新後待異動筆數: {pendingChangesAfter}");
                    _logger.LogInformation($"實際異動總筆數: {actualModifiedCount}");

                    await transaction.CommitAsync();
                    return await GetDetailById(parameter.WkMId);
                }
                catch
                {
                    await transaction.RollbackAsync(); // 發生錯誤時 rollback
                    throw;
                }
            }
        }
        public async Task<List<Dtos.ProductionOrder.ArtPoDto.QueryDetailDto>> DeleteDetailData(Parameters.ProductionOrder.ArtPoParameter.DetailDataParameter parameter)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var mainData = await _context.work_order_head.FindAsync(parameter.WkMId);
                    if (object.ReferenceEquals(mainData, null))
                    {
                        throw new Exception("main data not found!");
                    }
                    if (mainData.order_status == "INPRG")
                    {
                        throw new Exception($@"派工單正拋轉SERP中，不可再被異動");
                    }

                    foreach (var item in parameter.DetailData)
                    {
                        var detail = await _context.work_order_item.FindAsync(item.WkDId);
                        if (detail.RowVersion != item.RowVersion)
                        {
                            throw new Exception("Data has been modify");
                        }
                        detail.del_mk = (char)item.DelMk;
                        if (_context.Entry(detail).State == EntityState.Modified)
                        {
                            detail.modify_user = _currentUserService.UserId == null ? 0 : decimal.Parse(_currentUserService.PccUid);
                            detail.modify_date = DateTime.Now;
                            await _context.SaveChangesAsync();
                        }
                    }

                    await transaction.CommitAsync();
                    return await GetDetailById(parameter.WkMId);
                }
                catch
                {
                    await transaction.RollbackAsync(); // 發生錯誤時 rollback
                    throw;
                }
            }
        }
        public async Task<List<Dtos.ProductionOrder.ArtPoDto.QueryPickerDto>> QueryPicker(Parameters.ProductionOrder.ArtPoParameter.QueryPickerParameter parameter)
        {
            var query = from m in _context.plm_product_head
                        join d in _context.plm_product_item
                        on m.product_m_id equals d.product_m_id
                        where (m.factory == parameter.DevFactoryNo) &&
                              (string.IsNullOrWhiteSpace(parameter.Season) || m.season.Contains(parameter.Season)) &&
                              (string.IsNullOrWhiteSpace(parameter.DevelopmentNo) || m.development_no.Contains(parameter.DevelopmentNo)) &&
                              (string.IsNullOrWhiteSpace(parameter.ModelName) || m.working_name.Contains(parameter.ModelName)) &&
                              (string.IsNullOrWhiteSpace(parameter.ColorName) || d.development_color_no.Contains(parameter.ColorName) || d.color_code.Contains(parameter.ColorName)) &&
                              (string.IsNullOrWhiteSpace(parameter.ColorWay) || d.colorway.Contains(parameter.ColorWay))
                        select new Dtos.ProductionOrder.ArtPoDto.QueryPickerDto
                        {
                            Season = m.season,
                            DevelopmentNo = m.development_no,
                            ModelName = m.working_name,
                            ColorNo = d.development_color_no + (string.IsNullOrEmpty(d.color_code) ? "" : "(" + d.color_code + ")"),
                            ColorWay = d.colorway,
                            Stage = m.stage,
                            ArticleNo = (!string.IsNullOrEmpty(d.color_code) && !string.IsNullOrWhiteSpace(m.item_trading_code)) ? m.item_trading_code + "/" + d.color_code : "NA",
                            Category = m.category1,
                            Gender = m.gender,
                            LastNo = m.last1,
                            Definition = m.item_mode_sub_type,
                            CustomPm = m.developer,
                            SampleSize = m.default_size,
                            StyleId = m.product_m_id
                        };
            return await query.ToListAsync();
        }

        public async Task<string> GetWorkSataus(string value)
        {
            var query = await _context.sys_namevalue.Where(x => x.group_key == "wkorder_status" && x.status == "Y" && x.text == value).Select(x => x.data_no).FirstOrDefaultAsync();
            return query;
        }

        public async Task<string> GetBrand(string fact_no, string text)
        {
            var query = (from n in _context.pdm_namevalue_new
                         where n.group_key == "brand" && n.fact_no == fact_no && n.text == text
                         select n.value_desc).FirstOrDefaultAsync();
            return await query;
        }
        public async Task<IEnumerable<pdm_namevalue_new>> GetNameValueByKey(string fact_no, string key)
        {
            var query = await (from n in _context.pdm_namevalue_new
                               where n.group_key == key && n.fact_no == fact_no && n.status == "Y"
                               select n).ToListAsync();
            return query;
        }
        public async Task<IEnumerable<sys_namevalue>> GetSysNameValueByKey(string key)
        {
            var query = await _context.sys_namevalue.Where(x => x.group_key == key && x.status == "Y").ToListAsync();
            return query;
        }

        public async Task<object> GetSeason(string DevFactoryNo)
        {
            try
            {
                var query = _context.plm_product_head
                                    .Where(m => m.factory == DevFactoryNo && m.season.Length > 0 && m.brand.Length > 0)
                                    .Select(g => new
                                    {
                                        BrandNo = (from nv in _context.pdm_namevalue_new where nv.group_key == "brand" && nv.status == "Y" && nv.fact_no == DevFactoryNo && nv.value_desc == g.brand_no select nv.text).FirstOrDefault(),
                                        Season = g.season
                                    });

                // **先執行 SQL 查詢，將結果載入記憶體**
                var rawData = await query.Distinct().ToListAsync();
                rawData = rawData.Where(x => !string.IsNullOrWhiteSpace(x.BrandNo?.ToString()) && !string.IsNullOrWhiteSpace(x.Season)).ToList();
                // **在 C# 端執行 GroupBy**
                return rawData
                    .GroupBy(ph => ph.BrandNo)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Select(x => new { Text = x.Season, Value = x.Season }).ToList().OrderBy(x => x.Text)
                        );
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<object> GetShoeKind(string DevFactoryNo)
        {
            try
            {
                var query = from nv in _context.pdm_namevalue_new
                            where nv.group_key == "shoe_kind" && nv.status == "Y" && nv.fact_no == DevFactoryNo
                            select new { Text = nv.text, Value = nv.value_desc, TransMk = nv.text_ex2 };

                // **先執行 SQL 查詢，將結果載入記憶體**
                var rawData = await query.Distinct().ToListAsync();

                // **在 C# 端執行 GroupBy**
                return rawData;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Dtos.ProductionOrder.ArtPoDto.QueryDto> GetDataById(string DevFactoryNo, string wk_m_id)
        {
            return await (from m in _context.work_order_head
                          where (m.fact_no == DevFactoryNo) &&
                                (m.wk_m_id == wk_m_id)
                          select new Dtos.ProductionOrder.ArtPoDto.QueryDto
                          {
                              DevFactoryNo = m.fact_no,
                              WkMId = m.wk_m_id,
                              Brand = (from nv in _context.pdm_namevalue_new where nv.group_key == "brand" && nv.status == "Y" && nv.value_desc == m.brand_no && nv.fact_no == m.fact_no select nv.text).FirstOrDefault(),
                              OrderNo = m.order_no,
                              OrderPurchase = m.purpose,
                              OrderKind = (from nv in _context.pdm_namevalue_new where nv.group_key == "order_kind" && nv.status == "Y" && nv.value_desc == m.order_kind && nv.fact_no == m.fact_no select nv.text).FirstOrDefault(),
                              DevelopmentNo = m.dev_no,
                              Season = m.season,
                              ModelName = m.model_nm,
                              ColorNo = m.color_no,
                              ColorWay = m.colorway,
                              Stage = (from nv in _context.pdm_namevalue_new where nv.group_key == "stage" && nv.status == "Y" && nv.value_desc == m.stage && nv.fact_no == m.fact_no select nv.text).FirstOrDefault(),
                              OrderStatus = (from sv in _context.sys_namevalue where sv.group_key == "wkorder_status" && sv.status == "Y" && sv.data_no == m.order_status select sv.text).FirstOrDefault(),
                              ArticleNo = m.article_no,
                              Category = m.category,
                              Gender = m.gender,
                              MoldNo = m.mold_no,
                              LastNo = m.last_no,
                              LastWidth = m.last_width,
                              ReqDate = m.req_date.ToString(),
                              Definition = m.type_definition,
                              CustomSr = m.cust_sr,
                              CustomPm = m.b_pm,
                              SampleSize = m.sample_size,
                              FGType = (from nv in _context.pdm_namevalue_new where nv.group_key == "fg_type" && nv.status == "Y" && nv.value_desc == m.fg_type && nv.fact_no == m.fact_no select nv.text).FirstOrDefault(),
                              DelMk = m.del_mk.ToString(),
                              DelDate = m.del_date.ToString(),
                              SerpErrorMsg = m.err_msg,
                              Memo1 = m.txt_attrib_01,
                              Memo2 = m.txt_attrib_02,
                              Memo3 = m.txt_attrib_03,
                              Memo4 = m.txt_attrib_04,
                              Memo5 = m.txt_attrib_05,
                              Memo6 = m.txt_attrib_06,
                              Memo7 = m.txt_attrib_07,
                              Memo8 = m.txt_attrib_08,
                              Memo9 = m.txt_attrib_09,
                              Memo10 = m.txt_attrib_10,
                              Memo11 = m.txt_attrib_11,
                              Memo12 = m.txt_attrib_12,
                              Memo13 = m.txt_attrib_13,
                              Memo14 = m.txt_attrib_14,
                              Memo15 = m.txt_attrib_15,
                              Memo16 = m.txt_attrib_16,
                              Memo17 = m.txt_attrib_17,
                              Memo18 = m.txt_attrib_18,
                              Memo19 = m.txt_attrib_19,
                              Memo20 = m.txt_attrib_20,
                              StyleId = m.style_id,
                              RowVersion = m.RowVersion,
                          }).FirstOrDefaultAsync();
        }

        private (decimal unixTimestamp, int month) ConvertReqDateToUnixTimestamp(string reqDate)
        {
            if (string.IsNullOrWhiteSpace(reqDate))
                return (0, 0);

            try
            {
                // 解析 yyyyMMdd 格式的字串
                if (DateTime.TryParseExact(reqDate, "yyyyMMdd",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out DateTime dateTime))
                {
                    // 轉換為 Unix timestamp (毫秒)
                    var unixTimestamp = new DateTimeOffset(dateTime).ToUnixTimeMilliseconds();
                    return (Convert.ToDecimal(unixTimestamp), dateTime.Month);
                }
                return (0, 0);
            }
            catch
            {
                return (0, 0);
            }
        }

        private async Task<List<Dtos.ProductionOrder.ArtPoDto.QueryDetailDto>> GetDetailById(string Id)
        {
            var query = from d in _context.work_order_item
                        where d.wk_m_id == Id
                        select new Dtos.ProductionOrder.ArtPoDto.QueryDetailDto
                        {
                            WkMId = d.wk_m_id,
                            WkDId = d.wk_d_id,
                            Sort = d.sort,
                            TransMk = d.trans_mk,
                            ShoeKind = d.shoe_kind,
                            SizeNo = d.size_no,
                            Qty = d.qty,
                            DelMk = d.del_mk.ToString(),
                            RowVersion = d.RowVersion,
                        };
            return await query.ToListAsync();
        }
    }
}