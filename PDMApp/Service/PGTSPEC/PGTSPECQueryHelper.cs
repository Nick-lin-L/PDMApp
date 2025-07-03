using Dtos.PGTSPEC;
using Microsoft.EntityFrameworkCore;
using PDMApp.Models;
using PDMApp.Parameters.PGTSPEC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Service.PGTSPEC
{
    public static class PGTSPECQueryHelper
    {
        public static IQueryable<ComboDto> QueryBrand(pcms_pdm_testContext _pcms_Pdm_TestContext, DevelopmentFactoryParameter value)
        {
            var query = from n in _pcms_Pdm_TestContext.pdm_namevalue_new
                        where n.group_key == "brand"
                        select new
                        {
                            Brand = n.text,
                            FactNo = n.fact_no,
                            ValueDesc = n.value_desc 
                        };

            // 根據 FactNo 過濾
            if (!string.IsNullOrWhiteSpace(value.DevFactoryNo))
            {
                query = query.Where(n => n.FactNo == value.DevFactoryNo);
            }

            // 排序 (根據 ValueDesc 排序)
            query = query.OrderBy(n => n.ValueDesc);

            // 轉換成 ComboDto
            return query.Select(n => new ComboDto
            {
                Text = n.Brand,
                Value = n.Brand
            });

        }


        public static IQueryable<ComboDto> QuerySpecSource(pcms_pdm_testContext _pcms_Pdm_TestContext, DevelopmentFactoryParameter value)
        {
            var query = from n in _pcms_Pdm_TestContext.pdm_namevalue_new
                        where n.group_key == "specsource"
                        select new
                        {
                            SpecSource = n.text,
                            FactNo = n.fact_no,
                            ValueDesc = n.value_desc
                        };

            if (!string.IsNullOrWhiteSpace(value.DevFactoryNo))
            {
                query = query.Where(n => n.FactNo == value.DevFactoryNo);
            }

            query = query.OrderBy(n => n.ValueDesc);

            // 轉換成 ComboDto
            return query.Select(n => new ComboDto
            {
                Text = n.SpecSource,
                Value = n.SpecSource
            });
        }

        public static IQueryable<ComboDto> QueryStage(pcms_pdm_testContext _pcms_Pdm_TestContext, DevelopmentFactoryParameter value)
        {
            var query = from n in _pcms_Pdm_TestContext.pdm_namevalue_new
                        where n.group_key == "stage" 
                        select new
                        {
                            Stage = n.text,
                            FactNo = n.fact_no,
                            ValueDesc = n.value_desc 
                        };

            if (!string.IsNullOrWhiteSpace(value.DevFactoryNo))
            {
                query = query.Where(n => n.FactNo == value.DevFactoryNo);
            }

            query = query.OrderBy(n => n.ValueDesc);

            // 轉換成 ComboDto
            return query.Select(n => new ComboDto
            {
                Text = n.Stage,
                Value = n.Stage
            });
        }

        public static async Task<Dictionary<string, List<DevelopmentNoDto>>> QueryDevelopmentNo(pcms_pdm_testContext _pcms_Pdm_TestContext)
        {
            var query = (from ph in _pcms_Pdm_TestContext.plm_product_head
                         join n in _pcms_Pdm_TestContext.pdm_namevalue_new on ph.brand_no equals n.value_desc
                         where n.group_key == "brand"
                         select new
                         {
                             ProductMId = ph.product_m_id,
                             DevelopmentNo = ph.development_no,
                             Brand = n.text
                         }).Distinct();

            // **先執行 SQL 查詢，將結果載入記憶體**
            var rawData = await query.ToListAsync();

            // **在 C# 端執行 GroupBy**
            var groupedData = rawData
                .GroupBy(ph => ph.Brand)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(ph => new DevelopmentNoDto
                    {
                        ProductMId = ph.ProductMId,
                        Text = ph.DevelopmentNo,
                        Value = ph.DevelopmentNo
                    }).ToList()
                );

            return groupedData;
        }

        public static async Task<Dictionary<string, List<DevelopmentColorNoDto>>> QueryDevelopmentColorNo(pcms_pdm_testContext _pcms_Pdm_TestContext)
        {
            var query = (from pi in _pcms_Pdm_TestContext.plm_product_item
                         select new
                         {
                             ProductMId = pi.product_m_id,
                             DevelopmentColorNo = pi.development_color_no
                         }).Distinct();

            // **先執行 SQL 查詢，將結果載入記憶體**
            var rawData = await query.ToListAsync();

            // **在 C# 端執行 GroupBy 並過濾空值**
            var groupedData = rawData
                .OrderBy(pi => pi.DevelopmentColorNo)
                .GroupBy(pi => pi.ProductMId)
                .ToDictionary(
                    g => g.Key,
                    g => g
                        .Where(pi => !string.IsNullOrWhiteSpace(pi.DevelopmentColorNo)) // 過濾空值
                        .Select(pi => new DevelopmentColorNoDto
                        {
                            Text = pi.DevelopmentColorNo,
                            Value = pi.DevelopmentColorNo
                        })
                        .ToList()
                );

            return groupedData;
        }

        public static async Task<List<ComboDto>> QueryMailToCombo(pcms_pdm_testContext _pcms_Pdm_TestContext, DevelopmentFactoryParameter? value)
        {
            var query = from n in _pcms_Pdm_TestContext.pdm_namevalue_new
                        where n.group_key == "mail_to"
                        select new
                        {
                            Text = n.text,
                            Value = n.value_desc,
                            FactNo = n.fact_no
                        };

            if (value != null && !string.IsNullOrWhiteSpace(value.DevFactoryNo))
            {
                query = query.Where(n => n.FactNo == value.DevFactoryNo);
            }

            query = query.OrderBy(n => n.Value);

            // 在這裡使用 ToListAsync() 執行資料庫查詢，確保在 memory 中操作
            var comboDtos = await query.Select(n => new ComboDto
            {
                Text = n.Text,
                Value = n.Text
            }).ToListAsync(); // <--- 這裡使用 ToListAsync()

            // 新增一個新的列表來組合資料
            var finalComboList = new List<ComboDto>();
            finalComboList.Add(new ComboDto { Text = "", Value = "" }); // 新增空白選項
            finalComboList.AddRange(comboDtos); // 加入所有查詢到的資料

            // 直接返回 List<ComboDto>
            return finalComboList;
        }

        public static async Task<List<ComboDto>> QueryMailCcCombo(pcms_pdm_testContext _pcms_Pdm_TestContext, DevelopmentFactoryParameter? value)
        {
            var query = from n in _pcms_Pdm_TestContext.pdm_namevalue_new
                        where n.group_key == "mail_cc"
                        select new
                        {
                            Text = n.text,
                            Value = n.value_desc,
                            FactNo = n.fact_no
                        };

            if (value != null && !string.IsNullOrWhiteSpace(value.DevFactoryNo))
            {
                query = query.Where(n => n.FactNo == value.DevFactoryNo);
            }

            query = query.OrderBy(n => n.Value);

            // 在這裡使用 ToListAsync() 執行資料庫查詢，確保在 memory 中操作
            var comboDtos = await query.Select(n => new ComboDto
            {
                Text = n.Text,
                Value = n.Text
            }).ToListAsync(); // <--- 這裡使用 ToListAsync()

            // 新增一個新的列表來組合資料
            var finalComboList = new List<ComboDto>();
            finalComboList.Add(new ComboDto { Text = "", Value = "" }); // 新增空白選項
            finalComboList.AddRange(comboDtos); // 加入所有查詢到的資料

            // 直接返回 List<ComboDto>
            return finalComboList;
        }

        public static async Task<(bool IsSuccess, string Message, IQueryable<MatmResultDto>? Query)> QueryMatmAsync(pcms_pdm_testContext _pcms_Pdm_TestContext, MatmSearchParameter value)
        {
            try
            {
                var rawMatmQuery = _pcms_Pdm_TestContext.matm.AsQueryable();

                // 套用查詢條件 (這些條件直接在資料庫端執行)
                if (!string.IsNullOrWhiteSpace(value.SerpMatNo))
                {
                    rawMatmQuery = rawMatmQuery.Where(m => m.serp_mat_no != null && m.serp_mat_no.Contains(value.SerpMatNo));
                }
                if (!string.IsNullOrWhiteSpace(value.MaterialNo))
                {
                    rawMatmQuery = rawMatmQuery.Where(m => m.mat_no != null && m.mat_no.Contains(value.MaterialNo));
                }
                if (!string.IsNullOrWhiteSpace(value.MatFullNm))
                {
                    rawMatmQuery = rawMatmQuery.Where(m => m.mat_full_nm != null && m.mat_full_nm.Contains(value.MatFullNm));
                }
                if (!string.IsNullOrWhiteSpace(value.ColorNo))
                {
                    rawMatmQuery = rawMatmQuery.Where(m => m.color_no != null && m.color_no.Contains(value.ColorNo));
                }
                if (!string.IsNullOrWhiteSpace(value.ColorNm))
                {
                    rawMatmQuery = rawMatmQuery.Where(m => m.color_nm != null && m.color_nm.Contains(value.ColorNm));
                }

                // 在這裡只做初步的 Select 映射，不做 GroupBy 和 string.Join
                // 因為這些操作無法直接轉譯為資料庫查詢
                var resultQuery = rawMatmQuery.Select(m => new MatmResultDto
                {
                    SerpMatNo = m.serp_mat_no, // 暫時保留原始值
                    MaterialNo = m.mat_no,     // 暫時保留原始值
                    MatFullNm = m.mat_full_nm,
                    Uom = m.uom,
                    Memo = m.memo,
                    Standard = m.standard,
                    ColorNo = m.color_no,
                    ColorNm = m.color_nm,
                    // Colors 的邏輯可以在 IQueryable 階段，因為是單行處理
                    Colors = (m.color_no != null && m.color_nm != null) ? $"{m.color_no} {m.color_nm}" :
                               (m.color_no != null ? m.color_no : m.color_nm)
                });

                return (true, "Query successful", resultQuery); // 返回 IQueryable<MatmResultDto>
            }
            catch (Exception ex)
            {
                return (false, $"Database error during Matm query: {ex.Message}", null);
            }
        }

        public static async Task<(bool, string, IQueryable<PGTSPECHeaderDto>)> QuerySpecHead(pcms_pdm_testContext _pcms_Pdm_TestContext, bool latestVerOnly, PGTSPECSearchParameter value, string pccuid, string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(value.ModelName) &&
                    string.IsNullOrWhiteSpace(value.Colorway) &&
                    string.IsNullOrWhiteSpace(value.DevelopmentNo) &&
                    string.IsNullOrWhiteSpace(value.DevelopmentColorNo))
                {
                    return (false, "除了 Brand 之外，Model Name、Colorway、Development No、Development Color No 必須至少填寫一個！", null);
                }

                var baseQuery = (from ph in _pcms_Pdm_TestContext.plm_product_head
                                 join pi in _pcms_Pdm_TestContext.plm_product_item on ph.product_m_id equals pi.product_m_id
                                 join sh in _pcms_Pdm_TestContext.pcg_spec_head on pi.product_d_id equals sh.product_d_id
                                 join si in _pcms_Pdm_TestContext.pcg_spec_item on sh.spec_m_id equals si.spec_m_id
                                 join n_stage in _pcms_Pdm_TestContext.pdm_namevalue_new on sh.stage_code equals n_stage.value_desc
                                 where n_stage.group_key == "stage"
                                 join n_brand in _pcms_Pdm_TestContext.pdm_namevalue_new on ph.brand_no equals n_brand.value_desc
                                 where n_brand.group_key == "brand"
                                 select new
                                 {
                                     SpecMId = sh.spec_m_id, // 加入 SpecMId
                                     Brand = n_brand.text,
                                     DevelopmentNo = ph.development_no,
                                     DevelopmentColorNo = pi.development_color_no,
                                     ColorCode = pi.color_code,
                                     Colorway = pi.colorway,
                                     Stage = n_stage.text,
                                     ModelName = ph.working_name,
                                     Ver = sh.ver,
                                     CheckoutMk = sh.checkoutmk,
                                     CheckoutUser = sh.checkoutuser,
                                     SpecLockMk = sh.speclockmk,
                                     UpdateDate = sh.update_date,
                                     UpdateUser = sh.update_user_nm
                                 }).Distinct();

                // **WHERE 過濾條件**
                if (!string.IsNullOrWhiteSpace(value.Brand))
                    baseQuery = baseQuery.Where(ph => ph.Brand == value.Brand);
                if (!string.IsNullOrWhiteSpace(value.ModelName))
                    baseQuery = baseQuery.Where(ph => ph.ModelName.Contains(value.ModelName));
                if (!string.IsNullOrWhiteSpace(value.Colorway))
                    baseQuery = baseQuery.Where(ph => ph.Colorway.Contains(value.Colorway));
                if (!string.IsNullOrWhiteSpace(value.DevelopmentNo))
                    baseQuery = baseQuery.Where(ph => ph.DevelopmentNo.Contains(value.DevelopmentNo));
                if (!string.IsNullOrWhiteSpace(value.DevelopmentColorNo))
                    baseQuery = baseQuery.Where(ph => ph.DevelopmentColorNo.Contains(value.DevelopmentColorNo));
                if (!string.IsNullOrWhiteSpace(value.Stage))
                    baseQuery = baseQuery.Where(ph => ph.Stage == value.Stage);

                if (latestVerOnly)
                {
                    // **先計算最大版本**
                    var maxVerQuery = baseQuery
                        .GroupBy(x => new { x.DevelopmentNo, x.DevelopmentColorNo, x.Stage })
                        .Select(g => new
                        {
                            g.Key.DevelopmentNo,
                            g.Key.DevelopmentColorNo,
                            g.Key.Stage,
                            MaxVer = g.Max(x => x.Ver)
                        });

                    // **篩選最新版本**
                    var latestQuery = from q in baseQuery
                                      join maxVer in maxVerQuery
                                      on new { q.DevelopmentNo, q.DevelopmentColorNo, q.Stage, q.Ver }
                                      equals new { maxVer.DevelopmentNo, maxVer.DevelopmentColorNo, maxVer.Stage, Ver = maxVer.MaxVer }
                                      select q;

                    var resultQuery = latestQuery.Select(q => new PGTSPECHeaderDto
                    {
                        SpecMId = q.SpecMId,
                        Brand = q.Brand,
                        DevelopmentNo = q.DevelopmentNo,
                        DevelopmentColorNo = q.DevelopmentColorNo,
                        ColorCode = q.ColorCode,
                        Colorway = q.Colorway,
                        Stage = q.Stage,
                        ModelName = q.ModelName,
                        Ver = q.Ver,
                        CheckoutMk = q.CheckoutMk,
                        CheckoutUser = q.CheckoutUser,
                        SpecLockMk = q.SpecLockMk,
                        UpdateDate = q.UpdateDate,
                        UpdateUser = q.UpdateUser,
                        EditMk = (q.CheckoutUser == name && q.CheckoutMk == "Y") ? "Y" : "N"
                    });

                    return (true, "Query successful", resultQuery);
                }

                // 如果不篩選最新版本
                var baseResultQuery = baseQuery.Select(q => new PGTSPECHeaderDto
                {
                    SpecMId = q.SpecMId,
                    Brand = q.Brand,
                    DevelopmentNo = q.DevelopmentNo,
                    DevelopmentColorNo = q.DevelopmentColorNo,
                    ColorCode = q.ColorCode,
                    Colorway = q.Colorway,
                    Stage = q.Stage,
                    ModelName = q.ModelName,
                    Ver = q.Ver,
                    CheckoutMk = q.CheckoutMk,
                    CheckoutUser = q.CheckoutUser,
                    SpecLockMk = q.SpecLockMk,
                    UpdateDate = q.UpdateDate,
                    UpdateUser = q.UpdateUser,
                    EditMk = (q.CheckoutUser == name && q.CheckoutMk == "Y") ? "Y" : "N"
                });

                return (true, "Query successful", baseResultQuery);
            }
            catch (Exception ex)
            {
                return (false, $"Database error: {ex.Message}", null);
            }
        }



        public static IQueryable<SpecBasicDTO> GetSpecBasicResponse(pcms_pdm_testContext _pcms_pdm_testContext)
        {
            return (from ph in _pcms_pdm_testContext.plm_product_head
                    join pi in _pcms_pdm_testContext.plm_product_item on ph.product_m_id equals pi.product_m_id
                    join pn in _pcms_pdm_testContext.pdm_namevalue_new on ph.stage equals pn.text
                    join psh in _pcms_pdm_testContext.pcg_spec_head on pi.product_d_id equals psh.product_d_id
                    where pn.group_key == "stage"
                    select new SpecBasicDTO
                    {
                        SpecMId = psh.spec_m_id ?? "",
                        DevelopmentNo = ph.development_no ?? "",
                        ItemNo = ph.item_trading_code ?? "",            // ITEM NO
                        ModelName = ph.working_name ?? "",              // MODEL NAME
                        Factory = ph.assigned_agents ?? "",             // FACTORY
                        Season = ph.item_initial_season ?? "",          // SEASON
                        SampleSize = ph.default_size ?? "",             // SAMPLE SIZE
                        SizeRun = ph.size_run ?? "",                    // SIZE RUN
                        SizeRange = ph.size_range ?? "",                // SIZE RANGE
                        Stage = pn.text ?? "",                          // STAGE（使用 pn.text 取得描述）
                        ColorWay = pi.colorway ?? "",                   // COLOR WAY
                        ColorCode = pi.color_code ?? "",                // COLOR CODE
                        DevelopmentColorNo = pi.development_color_no ?? "",     // DEVELOPMENT COLOR NO
                        MainColor = pi.main_color ?? "",                // MAIN COLOR
                        SubColor = pi.sub_color ?? "",                  // SUB COLOR
                        ItemMode = ph.item_mode ?? "",                  // ITEM MODE
                        SubItemMode = ph.item_mode_sub_type ?? "",      // SUB ITEM MODE
                        Gender = ph.gender ?? "",                       // GENDER
                        Width = ph.width ?? "",                         // WIDTH
                        Last1 = ph.last1 ?? "",                         // LAST1
                        Last2 = ph.last2 ?? "",                         // LAST2
                        Last3 = ph.last3 ?? "",                         // LAST3
                        SizeMap = ph.sizemap ?? "",                     // SIZE MAP
                        Lasting = ph.lasting ?? "",                     // LASTING
                        HeelHeight = ph.heel_height ?? "",              // HEEL HEIGHT
                        ProductType = ph.product_line_type ?? "",       // PRODUCT TYPE
                        Category = ph.category1 ?? "",                  // CATEGORY
                        ProductionLeadTime = ph.production_lead_time ?? "" // PRODUCT LEAD TIME
                    });
        }


        public static async Task<List<SpecUpperDTO>> GetSpecUpperResponse(pcms_pdm_testContext _pcms_Pdm_TestContext)
        {
            // 步驟一：非同步地從 matm 表中獲取所有相關的 material_full_nm, mat_no, serp_mat_no 資料。
            var matmRawData = await _pcms_Pdm_TestContext.matm
                .Where(m => m.mat_full_nm != null && (m.mat_no != null || m.serp_mat_no != null))
                .Select(m => new { m.mat_full_nm, m.mat_no, m.serp_mat_no })
                .ToListAsync(); // <-- 非同步執行並載入到記憶體

            // 步驟二：在記憶體中對 matmRawData 進行分組和去重，建立一個用於快速查找的字典。
            var matmMaterialLookup = matmRawData
                .GroupBy(m => m.mat_full_nm)
                .ToDictionary(
                    g => g.Key,
                    g => new
                    {
                        MaterialNos = g.Where(x => x.mat_no != null).Select(x => x.mat_no).Distinct().ToList(),
                        SerpMatNos = g.Where(x => x.serp_mat_no != null).Select(x => x.serp_mat_no).Distinct().ToList()
                    }
                );

            // 步驟三：非同步地從 pcg_spec_item 表中獲取基礎資料。
            var specItemBaseData = await _pcms_Pdm_TestContext.pcg_spec_item
                .Select(si => new // 在資料庫端選擇所有基礎欄位
            {
                    si.spec_m_id,
                    si.spec_d_id,
                    si.material_sort,
                    si.parts_no,
                    si.act_part_no,
                    si.material_new,
                    si.parts,
                    si.detail,
                    si.process_mk,
                    si.material, // 這裡需要 material 來進行字典查找
                si.recycle,
                    si.mat_comment,
                    si.standard,
                    si.agent,
                    si.supplier,
                    si.quote_supplier,
                    si.hcha,
                    si.sec,
                    si.material_color,
                    si.clr_comment,
                    si.memo,
                    si.material_group
                })
                .ToListAsync(); // <-- 非同步執行並載入到記憶體

            // 步驟四：在記憶體中組裝最終的 SpecUpperDTO 列表，並填充 MaterialNo 和 SerpMatNo。
            var finalSpecUpperDtos = specItemBaseData.Select(si =>
            {
                matmMaterialLookup.TryGetValue(si.material ?? "", out var matmInfo);

                return new SpecUpperDTO
                {
                    SpecMId = si.spec_m_id ?? "",
                    SpecDId = si.spec_d_id ?? "",
                    Sort = si.material_sort,
                    No = si.parts_no ?? "",
                    ActPartNo = si.act_part_no ?? "",
                    Type = si.material_new ?? "",
                    Parts = si.parts ?? "",
                    Detail = si.detail ?? "",
                    ProcessMk = si.process_mk ?? "",
                    MaterialNo = matmInfo != null ? string.Join("\n", matmInfo.MaterialNos) : "",
                    SerpMatNo = matmInfo != null ? string.Join("\n", matmInfo.SerpMatNos) : "",
                    Material = si.material ?? "",
                    Recycle = si.recycle ?? "",
                    MaterialComment = si.mat_comment ?? "",
                    Standard = si.standard ?? "",
                    Agent = si.agent ?? "",
                    Supplier = si.supplier ?? "",
                    QuoteSupplier = si.quote_supplier ?? "",
                    Hcha = si.hcha ?? "", // HC/HA
                    Sec = si.sec ?? "",
                    Colors = si.material_color ?? "",
                    ColorComment = si.clr_comment ?? "",
                    Memo = si.memo ?? "",
                    MatGroup = si.material_group ?? ""
                };
            }).ToList(); // <-- 直接返回 List<SpecUpperDTO>，不再 AsQueryable()

            return finalSpecUpperDtos;
        }

        public static IQueryable<SpecHeadDto> GetSpecHeadResponse(pcms_pdm_testContext context, string currentFactNo) 
        {
            var mailToNames = context.pdm_namevalue_new
                                   .Where(nv => nv.group_key == "mail_to" && nv.fact_no == currentFactNo);

            var mailCcNames = context.pdm_namevalue_new
                                   .Where(nv => nv.group_key == "mail_cc" && nv.fact_no == currentFactNo);

            var query = from sh in context.pcg_spec_head
                        join mt in mailToNames
                        on sh.mail_to equals mt.value_desc into mailToGroup
                        from mailTo in mailToGroup.DefaultIfEmpty() 
                        join mc in mailCcNames
                        on sh.mail_cc equals mc.value_desc into mailCcGroup
                        from mailCc in mailCcGroup.DefaultIfEmpty() 
                        select new SpecHeadDto
                        {
                            SpecMId = sh.spec_m_id ?? "",
                            PgtColorName = sh.pgt_color_name ?? "",
                            RefDevNo = sh.ref_dev_no ?? "",
                            MailTo = mailTo.text ,
                            MailCc =  mailCc.text,
                            MoldNo1 = sh.mold_no1 ?? "",
                            MoldNo2 = sh.mold_no2 ?? "",
                            MoldNo3 = sh.mold_no3 ?? "",
                            RemarksSpec = sh.remarks_spec ?? "",
                            RemarksProhibit = sh.remarks_prohibit ?? ""
                        };

            return query;
        }

        public static IQueryable<ItemSheetDTO> GetItemSheetResponse(pcms_pdm_testContext _pcms_Pdm_TestContext)
        {
            return (from ph in _pcms_Pdm_TestContext.plm_product_head
                    join pi in _pcms_Pdm_TestContext.plm_product_item on ph.product_m_id equals pi.product_m_id
                    join shf in _pcms_Pdm_TestContext.pcg_spec_head on pi.product_d_id equals shf.product_d_id
                    join sif in _pcms_Pdm_TestContext.pcg_spec_item on shf.spec_m_id equals sif.spec_m_id
                    join pn in _pcms_Pdm_TestContext.pdm_namevalue_new on ph.stage equals pn.text
                    where pn.group_key == "stage"

                    let mailTo = (from f in _pcms_Pdm_TestContext.pdm_factoryspec_ref_signflow
                                  join h in _pcms_Pdm_TestContext.pdm_history_denamic_signflow on f.id equals h.id.ToString()
                                  where f.spec_m_id == shf.spec_m_id && f.sub_bill_class == "01"
                                  select h.signflow_cn).FirstOrDefault()
                    let mailCC = (from f in _pcms_Pdm_TestContext.pdm_factoryspec_ref_signflow
                                  join h in _pcms_Pdm_TestContext.pdm_history_denamic_signflow on f.id equals h.id.ToString()
                                  where f.spec_m_id == shf.spec_m_id && f.sub_bill_class == "02"
                                  select h.signflow_cn).FirstOrDefault()
                    select new ItemSheetDTO
                    {
                        SpecMId = shf.spec_m_id,
                        MailTo = mailTo,  // 預設為 null，根據需求填入
                        MailCC = mailCC,  // 預設為 null，根據需求填入
                        Stage = pn.text, // 使用 Join 的 stage 對應的 text 值
                        ActNo = sif.act_part_no,
                        CreateTime = DateTime.Now.ToString("yyyy/MM/dd"),
                        DevNo = ph.development_no,
                        RefDevNo = shf.ref_dev_no,
                        ItemNameEng = ph.article_description,
                        ItemNo = ph.item_trading_code,
                        ColorNo = pi.color_code,
                        DevelopmentColorNo = pi.development_color_no,
                        SampleSize = ph.default_size,
                        HeelHeight = ph.heel_height,
                        ColorNameChn = shf.pgt_color_name,
                        ColorEng = pi.colorway,
                        FactoryMoldNo1 = shf.mold_no1,
                        FactoryMoldNo2 = shf.mold_no2,
                        FactoryMoldNo3 = shf.mold_no3,
                        LastNo1 = ph.last1,
                        LastNo2 = ph.last2,
                        LastNo3 = ph.last3,
                        CreateUser = shf.create_user_nm,
                        Type = sif.material_new == "*" ? "△" : sif.material_new, // 轉換邏輯
                        Parts = $"{sif.parts} {sif.detail}".Trim(), // 串接 sif.parts 和 sif.detail
                        No = sif.parts_no,
                        Material = !string.IsNullOrWhiteSpace(sif.process_mk)? $"{sif.process_mk} {(string.IsNullOrWhiteSpace(sif.material) ? sif.mat_comment : sif.material)}": (sif.material ?? sif.mat_comment), // 如果 Material 為 null，就使用 mat_comment
                        SubMaterial = sif.mat_comment,
                        Colors = !string.IsNullOrWhiteSpace(sif.clr_comment)? $"{sif.material_color} {sif.clr_comment}".Trim(): sif.material_color,
                        Standard = sif.standard,
                        Hcha = sif.hcha,
                        Sec = sif.sec,
                        Supplier = !string.IsNullOrWhiteSpace(sif.agent) && !string.IsNullOrWhiteSpace(sif.supplier)? $"{sif.agent} / {sif.supplier}": (!string.IsNullOrWhiteSpace(sif.agent) ? sif.agent : sif.supplier),
                        Seqno = sif.material_sort,
                        PartClass = sif.material_group,
                        RemarksProhibit = shf.remarks_prohibit
                    });
        }


    }
}
