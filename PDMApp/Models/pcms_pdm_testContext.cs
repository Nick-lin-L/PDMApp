using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PDMApp.Models
{
    public partial class pcms_pdm_testContext : DbContext
    {
        public pcms_pdm_testContext()
        {
        }

        public pcms_pdm_testContext(DbContextOptions<pcms_pdm_testContext> options)
            : base(options)
        {
        }

        public virtual DbSet<dms_article> dms_article { get; set; }
        public virtual DbSet<dms_ebom_color> dms_ebom_color { get; set; }
        public virtual DbSet<global_users> global_users { get; set; }
        public virtual DbSet<matm> matm { get; set; }
        public virtual DbSet<pcg_spec_head> pcg_spec_head { get; set; }
        public virtual DbSet<pcg_spec_item> pcg_spec_item { get; set; }
        public virtual DbSet<pdm_api_permission> pdm_api_permission { get; set; }
        public virtual DbSet<pdm_factory> pdm_factory { get; set; }
        public virtual DbSet<pdm_factoryspec_ref_signflow> pdm_factoryspec_ref_signflow { get; set; }
        public virtual DbSet<pdm_history_denamic_signflow> pdm_history_denamic_signflow { get; set; }
        public virtual DbSet<pdm_namevalue> pdm_namevalue { get; set; }
        public virtual DbSet<pdm_namevalue_new> pdm_namevalue_new { get; set; }
        public virtual DbSet<pdm_permission_keys> pdm_permission_keys { get; set; }
        public virtual DbSet<pdm_permission_logs> pdm_permission_logs { get; set; }
        public virtual DbSet<pdm_permissions> pdm_permissions { get; set; }
        public virtual DbSet<pdm_product_head> pdm_product_head { get; set; }
        public virtual DbSet<pdm_product_item> pdm_product_item { get; set; }
        public virtual DbSet<pdm_role_permission_details> pdm_role_permission_details { get; set; }
        public virtual DbSet<pdm_role_permissions> pdm_role_permissions { get; set; }
        public virtual DbSet<pdm_roles> pdm_roles { get; set; }
        public virtual DbSet<pdm_spec_head> pdm_spec_head { get; set; }
        public virtual DbSet<pdm_spec_head_factory> pdm_spec_head_factory { get; set; }
        public virtual DbSet<pdm_spec_head_test> pdm_spec_head_test { get; set; }
        public virtual DbSet<pdm_spec_item> pdm_spec_item { get; set; }
        public virtual DbSet<pdm_spec_item_factory> pdm_spec_item_factory { get; set; }
        public virtual DbSet<pdm_spec_moldcharge> pdm_spec_moldcharge { get; set; }
        public virtual DbSet<pdm_spec_standard> pdm_spec_standard { get; set; }
        public virtual DbSet<pdm_spec_standard_factory> pdm_spec_standard_factory { get; set; }
        public virtual DbSet<pdm_user_roles> pdm_user_roles { get; set; }
        public virtual DbSet<pdm_users> pdm_users { get; set; }
        public virtual DbSet<plm_cbd_head> plm_cbd_head { get; set; }
        public virtual DbSet<plm_cbd_item> plm_cbd_item { get; set; }
        public virtual DbSet<plm_cbd_moldcharge> plm_cbd_moldcharge { get; set; }
        public virtual DbSet<plm_product_head> plm_product_head { get; set; }
        public virtual DbSet<plm_product_item> plm_product_item { get; set; }
        public virtual DbSet<plm_spec_head> plm_spec_head { get; set; }
        public virtual DbSet<plm_spec_item> plm_spec_item { get; set; }
        public virtual DbSet<sys_material_large_class> sys_material_large_class { get; set; }
        public virtual DbSet<sys_material_medium_class> sys_material_medium_class { get; set; }
        public virtual DbSet<sys_material_small_class> sys_material_small_class { get; set; }
        public virtual DbSet<sys_menu> sys_menu { get; set; }
        public virtual DbSet<sys_namevalue> sys_namevalue { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.UTF-8");

            modelBuilder.Entity<dms_article>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dms_article", "asics_pdm");

                entity.Property(e => e.ARTIC_ID).HasPrecision(10);

                entity.Property(e => e.ARTIC_NO)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ARTIC_NO_ITEM).HasMaxLength(1);

                entity.Property(e => e.ARTIC_OLD_SPEC).HasMaxLength(15);

                entity.Property(e => e.ARTIC_REMARK).HasMaxLength(50);

                entity.Property(e => e.COL_WAY_ID).HasMaxLength(100);

                entity.Property(e => e.COL_WAY_NAME).HasMaxLength(100);

                entity.Property(e => e.COL_WAY_STATUS).HasMaxLength(20);

                entity.Property(e => e.CS1).HasMaxLength(1);

                entity.Property(e => e.CS2).HasMaxLength(1);

                entity.Property(e => e.CS3).HasMaxLength(1);

                entity.Property(e => e.C_W_A).HasMaxLength(8);

                entity.Property(e => e.DEL_MK).HasMaxLength(1);

                entity.Property(e => e.DEVELOPER).HasMaxLength(60);

                entity.Property(e => e.DEV_QUARTER).HasMaxLength(10);

                entity.Property(e => e.DEV_SEASON).HasMaxLength(10);

                entity.Property(e => e.LEAD_TIME).HasPrecision(3);

                entity.Property(e => e.MAKE_LEVEL).HasMaxLength(2);

                entity.Property(e => e.MOC_DC_DT).HasColumnType("date");

                entity.Property(e => e.MOC_DC_ORDER_NO).HasMaxLength(30);

                entity.Property(e => e.MOC_DC_USER).HasMaxLength(60);

                entity.Property(e => e.MOC_ORDER_DT).HasColumnType("date");

                entity.Property(e => e.MOC_ORDER_NO).HasMaxLength(30);

                entity.Property(e => e.MOC_ORDER_USER).HasMaxLength(60);

                entity.Property(e => e.MODEL_OK).HasMaxLength(10);

                entity.Property(e => e.MODIFY_DT).HasMaxLength(14);

                entity.Property(e => e.MTRL_WAY_NID).HasPrecision(10);

                entity.Property(e => e.PF).HasMaxLength(1);

                entity.Property(e => e.PRODUCT_D_ID).HasMaxLength(32);

                entity.Property(e => e.PRODUCT_M_ID).HasMaxLength(32);

                entity.Property(e => e.PROD_TIME).HasMaxLength(5);

                entity.Property(e => e.REC_DATE).HasColumnType("date");

                entity.Property(e => e.REC_MK)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::character varying");

                entity.Property(e => e.R_I_DATE)
                    .HasMaxLength(8)
                    .IsFixedLength(true);

                entity.Property(e => e.SAMPLE_SIZE).HasMaxLength(10);

                entity.Property(e => e.SHOE_CLASS).HasMaxLength(15);

                entity.Property(e => e.SOT).HasPrecision(3);

                entity.Property(e => e.SPEC_M_ID).HasMaxLength(32);

                entity.Property(e => e.TYPE).HasMaxLength(5);

                entity.Property(e => e.USER_NO).HasMaxLength(60);
            });

            modelBuilder.Entity<dms_ebom_color>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dms_ebom_color", "asics_pdm");

                entity.HasComment("EBOM Article Color檔(EBOM_COLOR)");

                entity.Property(e => e.ARTIC_ID).HasPrecision(10);

                entity.Property(e => e.CHG_MEMO).HasMaxLength(200);

                entity.Property(e => e.CHG_REASON).HasMaxLength(2);

                entity.Property(e => e.COLOR_CODE).HasMaxLength(60);

                entity.Property(e => e.COLOR_NAME).HasMaxLength(200);

                entity.Property(e => e.IM_NO).HasMaxLength(20);

                entity.Property(e => e.INSTRUCTION).HasMaxLength(1200);

                entity.Property(e => e.MODIFY_DT).HasMaxLength(14);

                entity.Property(e => e.MTRL_FULL_NAME).HasMaxLength(600);

                entity.Property(e => e.MTRL_ID).HasMaxLength(20);

                entity.Property(e => e.MTRL_NOTE).HasMaxLength(600);

                entity.Property(e => e.MTRL_SUPPLIER).HasMaxLength(100);

                entity.Property(e => e.OTHERS_NO).HasMaxLength(20);

                entity.Property(e => e.PRE_MAT_NO).HasMaxLength(10);

                entity.Property(e => e.REC_DATE).HasColumnType("date");

                entity.Property(e => e.REC_MK)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::character varying");

                entity.Property(e => e.SPEC_D_ID).HasMaxLength(32);

                entity.Property(e => e.SPEC_M_ID).HasMaxLength(32);

                entity.Property(e => e.SUPPLIER_FAC).HasMaxLength(50);

                entity.Property(e => e.TREATMENT).HasMaxLength(300);

                entity.Property(e => e.UOM).HasMaxLength(50);

                entity.Property(e => e.USER_NO).HasMaxLength(60);

                entity.Property(e => e.YIELD).HasPrecision(8, 4);
            });

            modelBuilder.Entity<global_users>(entity =>
            {
                entity.HasKey(e => e.pccuid)
                    .HasName("global_users_pkey");

                entity.ToTable("global_users", "asics_pdm");

                entity.HasIndex(e => e.sso_acct, "idx_global_users_sso_acct");

                entity.Property(e => e.pccuid).HasPrecision(20);

                entity.Property(e => e.chinese_nm).HasMaxLength(300);

                entity.Property(e => e.contact_mail)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.disabled)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.disabled_date).HasPrecision(0);

                entity.Property(e => e.english_nm).HasMaxLength(200);

                entity.Property(e => e.fact_no).HasMaxLength(10);

                entity.Property(e => e.id).HasPrecision(20);

                entity.Property(e => e.leave_mk).HasMaxLength(20);

                entity.Property(e => e.lo_dept_nm).HasMaxLength(60);

                entity.Property(e => e.lo_posi_nm).HasMaxLength(60);

                entity.Property(e => e.local_fact_no).HasMaxLength(10);

                entity.Property(e => e.local_pnl_nm).HasMaxLength(300);

                entity.Property(e => e.sex).HasMaxLength(1);

                entity.Property(e => e.sso_acct)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.tel)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.update_date).HasPrecision(0);
            });

            modelBuilder.Entity<matm>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("matm", "asics_pdm");

                entity.Property(e => e.attyp)
                    .HasMaxLength(2)
                    .HasComment("物料種類");

                entity.Property(e => e.color_nm)
                    .HasMaxLength(100)
                    .HasComment("顏色說明");

                entity.Property(e => e.color_no)
                    .HasMaxLength(22)
                    .HasComment("顏色代號");

                entity.Property(e => e.create_tm)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("新增時間");

                entity.Property(e => e.cust_no)
                    .HasMaxLength(30)
                    .HasComment("客人料號");

                entity.Property(e => e.fact_no)
                    .HasMaxLength(4)
                    .HasComment("工廠代號(MGT_NO)");

                entity.Property(e => e.locked)
                    .HasMaxLength(1)
                    .HasComment("鎖檔註記(from SERP)");

                entity.Property(e => e.mat_full_nm)
                    .HasMaxLength(300)
                    .HasComment("物料完整說明");

                entity.Property(e => e.mat_id)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasComment("物料ID");

                entity.Property(e => e.mat_nm)
                    .HasMaxLength(300)
                    .HasComment("物料說明");

                entity.Property(e => e.mat_no)
                    .HasMaxLength(30)
                    .HasComment("PDM料號");

                entity.Property(e => e.matnr)
                    .HasMaxLength(25)
                    .HasComment("MDA料號");

                entity.Property(e => e.memo)
                    .HasMaxLength(2200)
                    .HasComment("物料備註");

                entity.Property(e => e.modify_tm)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("異動時間");

                entity.Property(e => e.modify_user)
                    .HasMaxLength(20)
                    .HasComment("異動人員");

                entity.Property(e => e.mtart)
                    .HasMaxLength(4)
                    .HasComment("物料類型");

                entity.Property(e => e.order_stauts)
                    .HasMaxLength(10)
                    .HasComment("物料編碼狀態");

                entity.Property(e => e.scm_bclass_no)
                    .HasMaxLength(1)
                    .HasComment("大分類");

                entity.Property(e => e.scm_mclass_no)
                    .HasMaxLength(2)
                    .HasComment("中分類");

                entity.Property(e => e.scm_sclass_no)
                    .HasMaxLength(2)
                    .HasComment("小分類");

                entity.Property(e => e.serp_mat_no)
                    .HasMaxLength(30)
                    .HasComment("SERP料號");

                entity.Property(e => e.standard)
                    .HasMaxLength(100)
                    .HasComment("規格");

                entity.Property(e => e.status)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'Y'::character varying")
                    .HasComment("物料狀態");

                entity.Property(e => e.stop_date)
                    .HasMaxLength(8)
                    .HasComment("停用日期");

                entity.Property(e => e.sync_time)
                    .HasMaxLength(100)
                    .HasComment("物料更新時間(from SERP)");

                entity.Property(e => e.trans_id)
                    .HasMaxLength(22)
                    .HasComment("拋轉ID");

                entity.Property(e => e.trans_msg)
                    .HasMaxLength(100)
                    .HasComment("拋轉錯誤訊息");

                entity.Property(e => e.trans_pro_mk)
                    .HasMaxLength(1)
                    .HasComment("拋轉處理註記");

                entity.Property(e => e.uom)
                    .HasMaxLength(3)
                    .HasComment("基礎計量單位");
            });

            modelBuilder.Entity<pcg_spec_head>(entity =>
            {
                entity.HasKey(e => e.spec_m_id)
                    .HasName("pcg_spec_head_pkey");

                entity.ToTable("pcg_spec_head", "asics_pdm");

                entity.HasIndex(e => new { e.spec_m_id, e.stage_code }, "idx_pcg_spec_head_spec_id_stage_code");

                entity.HasIndex(e => e.spec_m_id, "idx_pcg_spec_head_spec_m_id");

                entity.HasIndex(e => e.stage_code, "idx_pcg_spec_head_stage_code");

                entity.HasIndex(e => e.ver, "idx_pcg_spec_head_ver");

                entity.Property(e => e.spec_m_id).HasMaxLength(36);

                entity.Property(e => e.checkoutmk)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::character varying");

                entity.Property(e => e.checkoutuser).HasMaxLength(40);

                entity.Property(e => e.create_date).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.create_mode).HasMaxLength(1);

                entity.Property(e => e.create_user_id).HasMaxLength(14);

                entity.Property(e => e.create_user_nm).HasMaxLength(30);

                entity.Property(e => e.filename).HasMaxLength(256);

                entity.Property(e => e.lan).HasMaxLength(5);

                entity.Property(e => e.mold_no1).HasMaxLength(80);

                entity.Property(e => e.mold_no2).HasMaxLength(80);

                entity.Property(e => e.mold_no3).HasMaxLength(80);

                entity.Property(e => e.pgt_color_name).HasMaxLength(80);

                entity.Property(e => e.product_d_id).HasMaxLength(36);

                entity.Property(e => e.ref_bill_id).HasMaxLength(36);

                entity.Property(e => e.ref_dev_no).HasMaxLength(80);

                entity.Property(e => e.remarks_prohibit).HasMaxLength(1024);

                entity.Property(e => e.remarks_spec).HasMaxLength(1024);

                entity.Property(e => e.spec_pic_id).HasMaxLength(36);

                entity.Property(e => e.speclockmk)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::character varying");

                entity.Property(e => e.stage_code).HasMaxLength(10);

                entity.Property(e => e.translockmk)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::character varying");

                entity.Property(e => e.update_date).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.update_user_id).HasMaxLength(14);

                entity.Property(e => e.update_user_nm).HasMaxLength(30);

                entity.Property(e => e.ver).HasDefaultValueSql("1");

                entity.Property(e => e.vssver).HasDefaultValueSql("1");
            });

            modelBuilder.Entity<pcg_spec_item>(entity =>
            {
                entity.HasKey(e => e.spec_d_id)
                    .HasName("pcg_spec_item_pkey");

                entity.ToTable("pcg_spec_item", "asics_pdm");

                entity.HasIndex(e => e.spec_m_id, "idx_pcg_spec_item_spec_m_id");

                entity.Property(e => e.spec_d_id).HasMaxLength(36);

                entity.Property(e => e.act_part_no).HasMaxLength(4);

                entity.Property(e => e.add_date).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.agent).HasMaxLength(200);

                entity.Property(e => e.basecolor).HasMaxLength(200);

                entity.Property(e => e.clr_comment).HasMaxLength(200);

                entity.Property(e => e.detail).HasMaxLength(200);

                entity.Property(e => e.effect).HasMaxLength(200);

                entity.Property(e => e.hcha).HasMaxLength(30);

                entity.Property(e => e.mat_comment).HasMaxLength(200);

                entity.Property(e => e.mat_type).HasMaxLength(1);

                entity.Property(e => e.material).HasMaxLength(200);

                entity.Property(e => e.material_color).HasMaxLength(200);

                entity.Property(e => e.material_group).HasMaxLength(5);

                entity.Property(e => e.material_new).HasMaxLength(10);

                entity.Property(e => e.material_sort).HasPrecision(10, 2);

                entity.Property(e => e.memo).HasMaxLength(400);

                entity.Property(e => e.mtrbase).HasMaxLength(200);

                entity.Property(e => e.mtrtype).HasMaxLength(200);

                entity.Property(e => e.part_mk).HasMaxLength(1);

                entity.Property(e => e.parts).HasMaxLength(200);

                entity.Property(e => e.parts_no).HasMaxLength(4);

                entity.Property(e => e.process_mk).HasMaxLength(3);

                entity.Property(e => e.processing).HasMaxLength(200);

                entity.Property(e => e.quote_supplier).HasMaxLength(200);

                entity.Property(e => e.recycle).HasMaxLength(200);

                entity.Property(e => e.ref_bill_id).HasMaxLength(36);

                entity.Property(e => e.releasepaper).HasMaxLength(200);

                entity.Property(e => e.sec).HasMaxLength(10);

                entity.Property(e => e.spec_m_id).HasMaxLength(36);

                entity.Property(e => e.standard).HasMaxLength(20);

                entity.Property(e => e.supplier).HasMaxLength(200);

                entity.Property(e => e.translate_lock_mk).HasMaxLength(1);

                entity.Property(e => e.translate_rule).HasMaxLength(1024);

                entity.Property(e => e.update_date).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.spec_m)
                    .WithMany(p => p.pcg_spec_item)
                    .HasForeignKey(d => d.spec_m_id)
                    .HasConstraintName("fk_pcg_spec_item");
            });

            modelBuilder.Entity<pdm_api_permission>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pdm_api_permission", "asics_pdm");

                entity.Property(e => e.permission_name).HasColumnType("character varying");

                entity.Property(e => e.update_time).HasColumnType("timestamp with time zone");

                entity.Property(e => e.update_user).HasColumnType("character varying");
            });

            modelBuilder.Entity<pdm_factory>(entity =>
            {
                entity.HasKey(e => e.factory_id)
                    .HasName("pdm_factory_pkey");

                entity.ToTable("pdm_factory", "asics_pdm");

                entity.HasIndex(e => e.dev_factory_no, "pdm_factory_dev_factory_no_key")
                    .IsUnique();

                entity.Property(e => e.factory_id)
                    .HasDefaultValueSql("nextval('pdm_factory_factory_id_seq'::regclass)")
                    .HasComment("廠別 ID");

                entity.Property(e => e.area_no)
                    .HasMaxLength(20)
                    .HasComment("區域別");

                entity.Property(e => e.bu)
                    .HasMaxLength(10)
                    .HasComment("BU");

                entity.Property(e => e.bu_no)
                    .HasMaxLength(20)
                    .HasComment("事業單位別");

                entity.Property(e => e.company_no)
                    .HasMaxLength(10)
                    .HasComment("公司代號 (SAP)");

                entity.Property(e => e.country)
                    .HasMaxLength(10)
                    .HasComment("國別");

                entity.Property(e => e.created_at)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("新建時間");

                entity.Property(e => e.created_by).HasComment("新建人員");

                entity.Property(e => e.custom_region_no)
                    .HasMaxLength(10)
                    .HasComment("關區");

                entity.Property(e => e.dev_factory_name)
                    .IsRequired()
                    .HasMaxLength(120)
                    .HasComment("開發中心名稱");

                entity.Property(e => e.dev_factory_no)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("開發中心代號");

                entity.Property(e => e.factory_abbr)
                    .HasMaxLength(60)
                    .HasComment("廠別簡稱");

                entity.Property(e => e.factory_abbr_en)
                    .HasMaxLength(60)
                    .HasComment("廠別英文簡稱");

                entity.Property(e => e.factory_name)
                    .HasMaxLength(120)
                    .HasComment("廠別名稱");

                entity.Property(e => e.factory_name_en)
                    .HasMaxLength(120)
                    .HasComment("廠別英文名稱");

                entity.Property(e => e.factory_no)
                    .HasMaxLength(50)
                    .HasComment("廠別代號");

                entity.Property(e => e.pca_no)
                    .HasMaxLength(10)
                    .HasComment("利潤中心代號");

                entity.Property(e => e.updated_at)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("異動時間");

                entity.Property(e => e.updated_by).HasComment("異動人員");

                entity.HasOne(d => d.created_byNavigation)
                    .WithMany(p => p.pdm_factorycreated_byNavigation)
                    .HasForeignKey(d => d.created_by)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pdm_factory_created_by_fkey");

                entity.HasOne(d => d.updated_byNavigation)
                    .WithMany(p => p.pdm_factoryupdated_byNavigation)
                    .HasForeignKey(d => d.updated_by)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pdm_factory_updated_by_fkey");
            });

            modelBuilder.Entity<pdm_factoryspec_ref_signflow>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pdm_factoryspec_ref_signflow", "asics_pdm");

                entity.Property(e => e.id).HasMaxLength(4);

                entity.Property(e => e.spec_m_id).HasMaxLength(36);

                entity.Property(e => e.sub_bill_class).HasMaxLength(2);
            });

            modelBuilder.Entity<pdm_history_denamic_signflow>(entity =>
            {
                entity.ToTable("pdm_history_denamic_signflow", "asics_pdm");

                entity.Property(e => e.id).ValueGeneratedNever();

                entity.Property(e => e.bill_class_id).HasMaxLength(4);

                entity.Property(e => e.group_key).HasMaxLength(100);

                entity.Property(e => e.is_default)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'Y'::character varying");

                entity.Property(e => e.signflow_cn).HasMaxLength(200);

                entity.Property(e => e.signflow_detail).HasMaxLength(500);

                entity.Property(e => e.status)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::character varying");

                entity.Property(e => e.sub_bill_class).HasMaxLength(2);

                entity.Property(e => e.user_id).HasMaxLength(4);
            });

            modelBuilder.Entity<pdm_namevalue>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pdm_namevalue", "asics_pdm");

                entity.Property(e => e.fact_no).HasMaxLength(4);

                entity.Property(e => e.group_key).HasMaxLength(30);

                entity.Property(e => e.pkid)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.status)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'Y'::character varying");

                entity.Property(e => e.text).HasMaxLength(100);

                entity.Property(e => e.text_ex1).HasMaxLength(100);

                entity.Property(e => e.text_ex2).HasMaxLength(100);

                entity.Property(e => e.value_desc).HasMaxLength(20);
            });

            modelBuilder.Entity<pdm_namevalue_new>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pdm_namevalue_new", "asics_pdm");

                entity.HasIndex(e => e.group_key, "idx_pdm_namevalue_new_group_key");

                entity.HasIndex(e => e.value_desc, "idx_pdm_namevalue_new_value_desc");

                entity.HasIndex(e => new { e.value_desc, e.group_key }, "idx_pdm_namevalue_new_value_desc_group_key");

                entity.Property(e => e.fact_no).HasMaxLength(4);

                entity.Property(e => e.group_key).HasMaxLength(30);

                entity.Property(e => e.pkid)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.status)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'Y'::character varying");

                entity.Property(e => e.text).HasMaxLength(100);

                entity.Property(e => e.text_ex1).HasMaxLength(100);

                entity.Property(e => e.text_ex2).HasMaxLength(100);

                entity.Property(e => e.value_desc).HasMaxLength(20);
            });

            modelBuilder.Entity<pdm_permission_keys>(entity =>
            {
                entity.HasKey(e => e.permission_key_id)
                    .HasName("pdm_permission_keys_pkey");

                entity.ToTable("pdm_permission_keys", "asics_pdm");

                entity.HasComment("存放作業對應的細部權限，如 read/write/export/import");

                entity.HasIndex(e => new { e.permission_id, e.permission_key }, "uq_permission_keys")
                    .IsUnique();

                entity.Property(e => e.permission_key_id)
                    .HasDefaultValueSql("nextval('pdm_permission_keys_permission_key_id_seq'::regclass)")
                    .HasComment("細部權限的唯一識別碼");

                entity.Property(e => e.created_at)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("建立時間");

                entity.Property(e => e.created_by).HasComment("建立者");

                entity.Property(e => e.description).HasComment("細部權限的說明，例如「可讀取數據」、「可修改資料」");

                entity.Property(e => e.permission_id).HasComment("關聯 pdm_permissions，代表此細部權限屬於哪個作業");

                entity.Property(e => e.permission_key)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("細部權限名稱，如 read/write/export/import");

                entity.Property(e => e.updated_at)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("修改時間");

                entity.Property(e => e.updated_by).HasComment("修改者");

                entity.HasOne(d => d.created_byNavigation)
                    .WithMany(p => p.pdm_permission_keyscreated_byNavigation)
                    .HasForeignKey(d => d.created_by)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pdm_permission_keys_created_by_fkey");

                entity.HasOne(d => d.permission)
                    .WithMany(p => p.pdm_permission_keys)
                    .HasForeignKey(d => d.permission_id)
                    .HasConstraintName("fk_permission_keys_permission");

                entity.HasOne(d => d.updated_byNavigation)
                    .WithMany(p => p.pdm_permission_keysupdated_byNavigation)
                    .HasForeignKey(d => d.updated_by)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pdm_permission_keys_updated_by_fkey");
            });

            modelBuilder.Entity<pdm_permission_logs>(entity =>
            {
                entity.HasKey(e => e.log_id)
                    .HasName("pdm_permission_logs_pkey");

                entity.ToTable("pdm_permission_logs", "asics_pdm");

                entity.Property(e => e.log_id).HasDefaultValueSql("nextval('pdm_permission_logs_log_id_seq'::regclass)");

                entity.Property(e => e.created_at).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.dev_factory_no).HasMaxLength(50);

                entity.Property(e => e.factory_no).HasMaxLength(50);

                entity.Property(e => e.ip_address).HasMaxLength(50);

                entity.Property(e => e.operation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.role)
                    .WithMany(p => p.pdm_permission_logs)
                    .HasForeignKey(d => d.role_id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("pdm_permission_logs_role_id_fkey");

                entity.HasOne(d => d.user)
                    .WithMany(p => p.pdm_permission_logs)
                    .HasForeignKey(d => d.user_id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("pdm_permission_logs_user_id_fkey");
            });

            modelBuilder.Entity<pdm_permissions>(entity =>
            {
                entity.HasKey(e => e.permission_id)
                    .HasName("pdm_permissions_pkey");

                entity.ToTable("pdm_permissions", "asics_pdm");

                entity.HasIndex(e => e.permission_name, "pdm_permissions_permission_name_key")
                    .IsUnique();

                entity.Property(e => e.permission_id).HasDefaultValueSql("nextval('pdm_permissions_permission_id_seq'::regclass)");

                entity.Property(e => e.created_at).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.frontend_id).HasComment("前端id");

                entity.Property(e => e.is_active)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::character varying");

                entity.Property(e => e.permission_name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.updated_at).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.created_byNavigation)
                    .WithMany(p => p.pdm_permissionscreated_byNavigation)
                    .HasForeignKey(d => d.created_by)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pdm_permissions_created_by_fkey");

                entity.HasOne(d => d.updated_byNavigation)
                    .WithMany(p => p.pdm_permissionsupdated_byNavigation)
                    .HasForeignKey(d => d.updated_by)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pdm_permissions_updated_by_fkey");
            });

            modelBuilder.Entity<pdm_product_head>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pdm_product_head", "asics_pdm");

                entity.Property(e => e.betsubai_flg).HasMaxLength(1);

                entity.Property(e => e.category_grp).HasMaxLength(5);

                entity.Property(e => e.category_kbn).HasMaxLength(5);

                entity.Property(e => e.cud_no_moto).HasMaxLength(30);

                entity.Property(e => e.customer_kbn).HasMaxLength(10);

                entity.Property(e => e.customer_kbn_name).HasMaxLength(128);

                entity.Property(e => e.cutting_die).HasMaxLength(30);

                entity.Property(e => e.delete_mk)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::character varying");

                entity.Property(e => e.design_tanto).HasMaxLength(30);

                entity.Property(e => e.dev_brand_no).HasMaxLength(30);

                entity.Property(e => e.dev_building_no).HasMaxLength(30);

                entity.Property(e => e.dev_last_no).HasMaxLength(15);

                entity.Property(e => e.dev_marker_user).HasMaxLength(10);

                entity.Property(e => e.dev_marker_user_name).HasMaxLength(60);

                entity.Property(e => e.dev_marker_width).HasMaxLength(10);

                entity.Property(e => e.dev_marker_width_name).HasMaxLength(60);

                entity.Property(e => e.dev_no).HasMaxLength(30);

                entity.Property(e => e.dev_sp_mark).HasMaxLength(10);

                entity.Property(e => e.devmode).HasMaxLength(10);

                entity.Property(e => e.entry_drop_date).HasColumnType("date");

                entity.Property(e => e.etc_mold).HasMaxLength(10);

                entity.Property(e => e.etc_mold_name).HasMaxLength(128);

                entity.Property(e => e.etc_mold_no).HasMaxLength(30);

                entity.Property(e => e.etc_mold_no_biko).HasMaxLength(128);

                entity.Property(e => e.etc_mold_no_moto).HasMaxLength(30);

                entity.Property(e => e.f_gel).HasMaxLength(10);

                entity.Property(e => e.f_gel_name).HasMaxLength(128);

                entity.Property(e => e.factory1).HasMaxLength(10);

                entity.Property(e => e.factory1_forecast).HasPrecision(10);

                entity.Property(e => e.factory1_name).HasMaxLength(128);

                entity.Property(e => e.factory2).HasMaxLength(10);

                entity.Property(e => e.factory2_forecast).HasPrecision(10);

                entity.Property(e => e.factory2_name).HasMaxLength(128);

                entity.Property(e => e.factory3).HasMaxLength(10);

                entity.Property(e => e.factory3_forecast).HasPrecision(10);

                entity.Property(e => e.factory3_name).HasMaxLength(128);

                entity.Property(e => e.factory_upper).HasMaxLength(10);

                entity.Property(e => e.factory_upper_name).HasMaxLength(128);

                entity.Property(e => e.item_name_eng).HasMaxLength(80);

                entity.Property(e => e.item_name_jpn).HasMaxLength(80);

                entity.Property(e => e.item_no).HasMaxLength(30);

                entity.Property(e => e.item_type).HasMaxLength(10);

                entity.Property(e => e.item_type_name).HasMaxLength(128);

                entity.Property(e => e.kaihatsu_tanto).HasMaxLength(40);

                entity.Property(e => e.kanzan_type).HasMaxLength(30);

                entity.Property(e => e.karyu_kbn).HasMaxLength(10);

                entity.Property(e => e.karyu_kbn_name).HasMaxLength(128);

                entity.Property(e => e.ketteo_tuki).HasColumnType("date");

                entity.Property(e => e.last_no1).HasMaxLength(15);

                entity.Property(e => e.last_no2).HasMaxLength(15);

                entity.Property(e => e.last_no3).HasMaxLength(15);

                entity.Property(e => e.leveli).HasMaxLength(10);

                entity.Property(e => e.make_date).HasColumnType("date");

                entity.Property(e => e.make_user).HasMaxLength(30);

                entity.Property(e => e.mid_mold).HasMaxLength(10);

                entity.Property(e => e.mid_mold_name).HasMaxLength(128);

                entity.Property(e => e.mid_mold_no).HasMaxLength(30);

                entity.Property(e => e.mid_mold_no_biko).HasMaxLength(128);

                entity.Property(e => e.mid_mold_no_moto).HasMaxLength(30);

                entity.Property(e => e.mode_name).HasMaxLength(128);

                entity.Property(e => e.nakajiki_code).HasMaxLength(10);

                entity.Property(e => e.nakajiki_code_name).HasMaxLength(128);

                entity.Property(e => e.out_mold).HasMaxLength(10);

                entity.Property(e => e.out_mold_name).HasMaxLength(128);

                entity.Property(e => e.out_mold_no).HasMaxLength(30);

                entity.Property(e => e.out_mold_no_biko).HasMaxLength(128);

                entity.Property(e => e.out_mold_no_moto).HasMaxLength(30);

                entity.Property(e => e.pb_analyze_report_flg).HasMaxLength(1);

                entity.Property(e => e.product_m_id)
                    .IsRequired()
                    .HasMaxLength(36);

                entity.Property(e => e.producted_tuki).HasColumnType("date");

                entity.Property(e => e.r_gel).HasMaxLength(10);

                entity.Property(e => e.r_gel_name).HasMaxLength(128);

                entity.Property(e => e.real_weight).HasPrecision(10);

                entity.Property(e => e.request1_comment).HasMaxLength(1024);

                entity.Property(e => e.request1_shinsei_comment).HasMaxLength(1024);

                entity.Property(e => e.request2_comment).HasMaxLength(1024);

                entity.Property(e => e.request2_shinsei_comment).HasMaxLength(1024);

                entity.Property(e => e.request3_comment).HasMaxLength(1024);

                entity.Property(e => e.request3_shinsei_comment).HasMaxLength(1024);

                entity.Property(e => e.request_weight).HasPrecision(10);

                entity.Property(e => e.saishu_comment).HasMaxLength(1024);

                entity.Property(e => e.saishu_date).HasColumnType("date");

                entity.Property(e => e.saishu_user).HasMaxLength(30);

                entity.Property(e => e.sample_factory).HasMaxLength(10);

                entity.Property(e => e.sample_factory_name).HasMaxLength(128);

                entity.Property(e => e.sample_size).HasMaxLength(10);

                entity.Property(e => e.season).HasMaxLength(3);

                entity.Property(e => e.season_name).HasMaxLength(128);

                entity.Property(e => e.shinsei_tanto).HasMaxLength(30);

                entity.Property(e => e.siyo_kigou).HasMaxLength(10);

                entity.Property(e => e.siyo_kigou_name).HasMaxLength(128);

                entity.Property(e => e.smu_comment).HasMaxLength(2048);

                entity.Property(e => e.sp_kanzan).HasMaxLength(1);

                entity.Property(e => e.stage).HasMaxLength(10);

                entity.Property(e => e.stage_name).HasMaxLength(128);

                entity.Property(e => e.status).HasMaxLength(10);

                entity.Property(e => e.status_name).HasMaxLength(128);

                entity.Property(e => e.syokyaku_yoteinen).HasMaxLength(2);

                entity.Property(e => e.upd_date).HasColumnType("date");

                entity.Property(e => e.upd_num).HasPrecision(10);

                entity.Property(e => e.upd_user).HasMaxLength(30);

                entity.Property(e => e.year).HasMaxLength(2);
            });

            modelBuilder.Entity<pdm_product_item>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pdm_product_item", "asics_pdm");

                entity.Property(e => e.col_revise_flg).HasMaxLength(1);

                entity.Property(e => e.color_name_eng).HasMaxLength(80);

                entity.Property(e => e.color_name_jpn).HasMaxLength(80);

                entity.Property(e => e.color_no).HasMaxLength(10);

                entity.Property(e => e.conf_color_no).HasMaxLength(10);

                entity.Property(e => e.conf_date).HasColumnType("date");

                entity.Property(e => e.conf_last).HasMaxLength(15);

                entity.Property(e => e.conf_model_no).HasMaxLength(30);

                entity.Property(e => e.conf_mold).HasMaxLength(30);

                entity.Property(e => e.conf_remarks).HasMaxLength(512);

                entity.Property(e => e.conf_request).HasMaxLength(10);

                entity.Property(e => e.conf_request_flg).HasMaxLength(1);

                entity.Property(e => e.conf_sample_flg).HasMaxLength(1);

                entity.Property(e => e.conf_sample_no).HasMaxLength(30);

                entity.Property(e => e.conf_size).HasMaxLength(10);

                entity.Property(e => e.dev_color_disp_name).HasMaxLength(10);

                entity.Property(e => e.dev_color_no).HasMaxLength(10);

                entity.Property(e => e.drop_flg).HasMaxLength(1);

                entity.Property(e => e.hqn_no).HasMaxLength(10);

                entity.Property(e => e.hqn_no_name).HasMaxLength(128);

                entity.Property(e => e.hs_code).HasMaxLength(10);

                entity.Property(e => e.hs_code_name).HasMaxLength(128);

                entity.Property(e => e.iroseqno).HasPrecision(4);

                entity.Property(e => e.offer_fob).HasPrecision(10, 2);

                entity.Property(e => e.product_d_id)
                    .IsRequired()
                    .HasMaxLength(36);

                entity.Property(e => e.product_m_id).HasMaxLength(36);

                entity.Property(e => e.request1_uketsuke).HasMaxLength(1);

                entity.Property(e => e.request2_uketsuke).HasMaxLength(1);

                entity.Property(e => e.request3_uketsuke).HasMaxLength(1);

                entity.Property(e => e.size_run).HasMaxLength(100);

                entity.Property(e => e.sole_sozai_code).HasMaxLength(10);

                entity.Property(e => e.sole_sozai_code_name).HasMaxLength(128);

                entity.Property(e => e.tsurifuda_code).HasMaxLength(10);

                entity.Property(e => e.tsurifuda_code_name).HasMaxLength(128);

                entity.Property(e => e.upper_sozai_code).HasMaxLength(10);

                entity.Property(e => e.upper_sozai_code_name).HasMaxLength(128);
            });

            modelBuilder.Entity<pdm_role_permission_details>(entity =>
            {
                entity.HasKey(e => e.role_permission_detail_id)
                    .HasName("pdm_role_permission_details_pkey");

                entity.ToTable("pdm_role_permission_details", "asics_pdm");

                entity.HasIndex(e => new { e.role_id, e.permission_id, e.permission_key_id, e.dev_factory_no }, "uq_role_permission")
                    .IsUnique();

                entity.Property(e => e.role_permission_detail_id)
                    .HasDefaultValueSql("nextval('pdm_role_permission_details_role_permission_detail_id_seq'::regclass)")
                    .HasComment("Table ID");

                entity.Property(e => e.created_at)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("建立時間");

                entity.Property(e => e.created_by).HasComment("建立者,關聯 pdm_users.user_id");

                entity.Property(e => e.description).HasComment("權限詳細描述");

                entity.Property(e => e.dev_factory_no)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("開發中心代號");

                entity.Property(e => e.is_active)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'Y'::character varying")
                    .HasComment("是否啟用 (Y: 啟用, N: 停用)");

                entity.Property(e => e.permission_id).HasComment("關聯 pdm_permissions 表中的 permission_id");

                entity.Property(e => e.permission_key)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("權限名稱");

                entity.Property(e => e.permission_key_id).HasComment("關聯 pdm_permissions_keys 表中的 permission_key_id");

                entity.Property(e => e.role_id).HasComment("角色 ID");

                entity.Property(e => e.updated_at)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("更新時間");

                entity.Property(e => e.updated_by).HasComment("最後更新者,關聯 pdm_users.user_id");

                entity.HasOne(d => d.created_byNavigation)
                    .WithMany(p => p.pdm_role_permission_detailscreated_byNavigation)
                    .HasForeignKey(d => d.created_by)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pdm_role_permission_details_created_by_fkey");

                entity.HasOne(d => d.permission_keyNavigation)
                    .WithMany(p => p.pdm_role_permission_details)
                    .HasForeignKey(d => d.permission_key_id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_role_permission_details_permission_key");

                entity.HasOne(d => d.role)
                    .WithMany(p => p.pdm_role_permission_details)
                    .HasForeignKey(d => d.role_id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("pdm_role_permission_details_role_id_fkey");

                entity.HasOne(d => d.updated_byNavigation)
                    .WithMany(p => p.pdm_role_permission_detailsupdated_byNavigation)
                    .HasForeignKey(d => d.updated_by)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pdm_role_permission_details_updated_by_fkey");
            });

            modelBuilder.Entity<pdm_role_permissions>(entity =>
            {
                entity.HasKey(e => e.role_permission_id)
                    .HasName("pdm_role_permissions_pkey");

                entity.ToTable("pdm_role_permissions", "asics_pdm");

                entity.Property(e => e.role_permission_id).HasDefaultValueSql("nextval('pdm_role_permissions_role_permission_id_seq'::regclass)");

                entity.Property(e => e.created_at).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.createp)
                    .HasColumnType("character varying")
                    .HasDefaultValueSql("'Y'::character varying");

                entity.Property(e => e.deletep)
                    .HasColumnType("character varying")
                    .HasDefaultValueSql("'Y'::character varying");

                entity.Property(e => e.dev_factory_no)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.exportp)
                    .HasColumnType("character varying")
                    .HasDefaultValueSql("'Y'::character varying");

                entity.Property(e => e.importp)
                    .HasColumnType("character varying")
                    .HasDefaultValueSql("'Y'::character varying");

                entity.Property(e => e.is_active)
                    .HasColumnType("character varying")
                    .HasDefaultValueSql("'Y'::character varying");

                entity.Property(e => e.permission1)
                    .HasColumnType("character varying")
                    .HasDefaultValueSql("'Y'::character varying");

                entity.Property(e => e.permission2)
                    .HasColumnType("character varying")
                    .HasDefaultValueSql("'Y'::character varying");

                entity.Property(e => e.permission3)
                    .HasColumnType("character varying")
                    .HasDefaultValueSql("'Y'::character varying");

                entity.Property(e => e.permission4)
                    .HasColumnType("character varying")
                    .HasDefaultValueSql("'Y'::character varying");

                entity.Property(e => e.readp)
                    .HasColumnType("character varying")
                    .HasDefaultValueSql("'Y'::character varying");

                entity.Property(e => e.updated_at).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.updatep)
                    .HasColumnType("character varying")
                    .HasDefaultValueSql("'Y'::character varying");

                entity.HasOne(d => d.created_byNavigation)
                    .WithMany(p => p.pdm_role_permissionscreated_byNavigation)
                    .HasForeignKey(d => d.created_by)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pdm_role_permissions_created_by_fkey");

                entity.HasOne(d => d.permission)
                    .WithMany(p => p.pdm_role_permissions)
                    .HasForeignKey(d => d.permission_id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("pdm_role_permissions_permission_id_fkey");

                entity.HasOne(d => d.role)
                    .WithMany(p => p.pdm_role_permissions)
                    .HasForeignKey(d => d.role_id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("pdm_role_permissions_role_id_fkey");

                entity.HasOne(d => d.updated_byNavigation)
                    .WithMany(p => p.pdm_role_permissionsupdated_byNavigation)
                    .HasForeignKey(d => d.updated_by)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pdm_role_permissions_updated_by_fkey");
            });

            modelBuilder.Entity<pdm_roles>(entity =>
            {
                entity.HasKey(e => e.role_id)
                    .HasName("pdm_roles_pkey");

                entity.ToTable("pdm_roles", "asics_pdm");

                entity.HasIndex(e => e.role_name, "pdm_roles_role_name_key")
                    .IsUnique();

                entity.HasIndex(e => e.role_name, "unique_role_name")
                    .IsUnique();

                entity.Property(e => e.role_id).HasDefaultValueSql("nextval('pdm_roles_role_id_seq'::regclass)");

                entity.Property(e => e.created_at).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.dev_factory_no)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.is_active)
                    .HasColumnType("character varying")
                    .HasDefaultValueSql("'Y'::character varying")
                    .HasComment("Y:N");

                entity.Property(e => e.role_level).HasDefaultValueSql("3");

                entity.Property(e => e.role_name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.updated_at).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.created_byNavigation)
                    .WithMany(p => p.pdm_rolescreated_byNavigation)
                    .HasForeignKey(d => d.created_by)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pdm_roles_created_by_fkey");

                entity.HasOne(d => d.dev_factory_noNavigation)
                    .WithMany(p => p.pdm_roles)
                    .HasPrincipalKey(p => p.dev_factory_no)
                    .HasForeignKey(d => d.dev_factory_no)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pdm_roles_dev_factory_no_fkey");

                entity.HasOne(d => d.updated_byNavigation)
                    .WithMany(p => p.pdm_rolesupdated_byNavigation)
                    .HasForeignKey(d => d.updated_by)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pdm_roles_updated_by_fkey");
            });

            modelBuilder.Entity<pdm_spec_head>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pdm_spec_head", "asics_pdm");

                entity.Property(e => e.cbd_update_date).HasColumnType("date");

                entity.Property(e => e.cbd_update_user).HasMaxLength(30);

                entity.Property(e => e.cbd_xml_id).HasMaxLength(36);

                entity.Property(e => e.cbdlockmk)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::character varying");

                entity.Property(e => e.check_out_area).HasMaxLength(40);

                entity.Property(e => e.checkoutmk)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::character varying");

                entity.Property(e => e.checkoutuser).HasMaxLength(40);

                entity.Property(e => e.commission)
                    .HasPrecision(4, 1)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.cpcutting)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.cplasting)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.cpoutsoleassembly)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.cpstiching)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.create_date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("CURRENT_DATE");

                entity.Property(e => e.create_user).HasMaxLength(30);

                entity.Property(e => e.currency).HasMaxLength(10);

                entity.Property(e => e.devcolorno).HasMaxLength(10);

                entity.Property(e => e.devno).HasMaxLength(30);

                entity.Property(e => e.entrymode).HasMaxLength(6);

                entity.Property(e => e.excommission)
                    .HasPrecision(7, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.exdirectlabor)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.exfactoryoverhead)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.exmoldamortization)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.exprofit)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.exsubtotal)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.extotal)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.factory).HasMaxLength(10);

                entity.Property(e => e.filename).HasMaxLength(256);

                entity.Property(e => e.fob1stsample)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.fob2ndsample)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.fobfinal)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.fobnego)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.fobphoto)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.fobsales)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.forecast).HasDefaultValueSql("0");

                entity.Property(e => e.heelheight)
                    .HasPrecision(6, 1)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.itemname1)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'SHOE LACE LENGTH'::character varying");

                entity.Property(e => e.itemname10).HasMaxLength(50);

                entity.Property(e => e.itemname2)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'SHOE BOX'::character varying");

                entity.Property(e => e.itemname3)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'GEL FORE'::character varying");

                entity.Property(e => e.itemname4)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'GEL REAR'::character varying");

                entity.Property(e => e.itemname5)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'TOE KEEPER'::character varying");

                entity.Property(e => e.itemname6)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'SHOE BAG'::character varying");

                entity.Property(e => e.itemname7).HasMaxLength(50);

                entity.Property(e => e.itemname8).HasMaxLength(50);

                entity.Property(e => e.itemname9).HasMaxLength(50);

                entity.Property(e => e.lasting).HasMaxLength(10);

                entity.Property(e => e.loginuser).HasMaxLength(30);

                entity.Property(e => e.materialcost)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.materialrate)
                    .HasPrecision(3, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.materialratecurrency).HasMaxLength(10);

                entity.Property(e => e.mcmoldrate)
                    .HasPrecision(5, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.mcmoldratecurency).HasMaxLength(10);

                entity.Property(e => e.mcmoldyears).HasDefaultValueSql("0");

                entity.Property(e => e.omsubtotal)
                    .HasPrecision(11, 3)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.product_d_id).HasMaxLength(36);

                entity.Property(e => e.remarks_cbd).HasMaxLength(1024);

                entity.Property(e => e.remarks_spec).HasMaxLength(1024);

                entity.Property(e => e.smsubtotal)
                    .HasPrecision(11, 3)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.spec_m_id)
                    .IsRequired()
                    .HasMaxLength(36);

                entity.Property(e => e.spec_pic_id).HasMaxLength(36);

                entity.Property(e => e.spec_update_date).HasColumnType("date");

                entity.Property(e => e.spec_update_user).HasMaxLength(30);

                entity.Property(e => e.spec_xml_id).HasMaxLength(36);

                entity.Property(e => e.speclockmk)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::character varying");

                entity.Property(e => e.stage).HasMaxLength(10);

                entity.Property(e => e.targetprice)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.umsubtotal)
                    .HasPrecision(11, 3)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ver)
                    .HasPrecision(4)
                    .HasDefaultValueSql("1");

                entity.Property(e => e.vssver)
                    .HasPrecision(4)
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<pdm_spec_head_factory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pdm_spec_head_factory", "asics_pdm");

                entity.Property(e => e.cbd_update_date).HasColumnType("date");

                entity.Property(e => e.cbd_update_user).HasMaxLength(30);

                entity.Property(e => e.cbd_xml_id).HasMaxLength(36);

                entity.Property(e => e.cbdlockmk)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::character varying");

                entity.Property(e => e.check_out_area).HasMaxLength(40);

                entity.Property(e => e.checkoutmk)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::character varying");

                entity.Property(e => e.checkoutuser).HasMaxLength(40);

                entity.Property(e => e.color_eng).HasMaxLength(80);

                entity.Property(e => e.color_name_chn).HasMaxLength(80);

                entity.Property(e => e.commission)
                    .HasPrecision(4, 1)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.cpcutting)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.cplasting)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.cpoutsoleassembly)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.cpstiching)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.create_date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("CURRENT_DATE");

                entity.Property(e => e.create_user).HasMaxLength(30);

                entity.Property(e => e.currency).HasMaxLength(10);

                entity.Property(e => e.devcolorno).HasMaxLength(10);

                entity.Property(e => e.devno).HasMaxLength(30);

                entity.Property(e => e.entrymode).HasMaxLength(6);

                entity.Property(e => e.excommission)
                    .HasPrecision(7, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.exdirectlabor)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.exfactoryoverhead)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.exmoldamortization)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.exprofit)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.exsubtotal)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.extotal)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.factory).HasMaxLength(10);

                entity.Property(e => e.filename).HasMaxLength(256);

                entity.Property(e => e.fob1stsample)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.fob2ndsample)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.fobfinal)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.fobnego)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.fobphoto)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.fobsales)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.forecast).HasDefaultValueSql("0");

                entity.Property(e => e.heelheight)
                    .HasPrecision(6, 1)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.itemname1).HasMaxLength(50);

                entity.Property(e => e.itemname10).HasMaxLength(50);

                entity.Property(e => e.itemname2).HasMaxLength(50);

                entity.Property(e => e.itemname3).HasMaxLength(50);

                entity.Property(e => e.itemname4).HasMaxLength(50);

                entity.Property(e => e.itemname5).HasMaxLength(50);

                entity.Property(e => e.itemname6).HasMaxLength(50);

                entity.Property(e => e.itemname7).HasMaxLength(50);

                entity.Property(e => e.itemname8).HasMaxLength(50);

                entity.Property(e => e.itemname9).HasMaxLength(50);

                entity.Property(e => e.lasting).HasMaxLength(10);

                entity.Property(e => e.loginuser).HasMaxLength(30);

                entity.Property(e => e.materialcost)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.materialrate)
                    .HasPrecision(3, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.materialratecurrency).HasMaxLength(10);

                entity.Property(e => e.mcmoldrate)
                    .HasPrecision(5, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.mcmoldratecurency).HasMaxLength(10);

                entity.Property(e => e.mcmoldyears).HasDefaultValueSql("0");

                entity.Property(e => e.mold_no1).HasMaxLength(30);

                entity.Property(e => e.mold_no2).HasMaxLength(30);

                entity.Property(e => e.mold_no3).HasMaxLength(30);

                entity.Property(e => e.omsubtotal)
                    .HasPrecision(11, 3)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.product_d_id).HasMaxLength(36);

                entity.Property(e => e.ref_dev_no).HasMaxLength(80);

                entity.Property(e => e.remarks_cbd).HasMaxLength(1024);

                entity.Property(e => e.remarks_prohibit).HasMaxLength(1024);

                entity.Property(e => e.remarks_spec).HasMaxLength(1024);

                entity.Property(e => e.smsubtotal)
                    .HasPrecision(11, 3)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.spec_m_id)
                    .IsRequired()
                    .HasMaxLength(36);

                entity.Property(e => e.spec_pic_id).HasMaxLength(36);

                entity.Property(e => e.spec_update_date).HasColumnType("date");

                entity.Property(e => e.spec_update_user).HasMaxLength(30);

                entity.Property(e => e.spec_xml_id).HasMaxLength(36);

                entity.Property(e => e.speclockmk)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::character varying");

                entity.Property(e => e.stage).HasMaxLength(10);

                entity.Property(e => e.targetprice)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.translockmk)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::character varying");

                entity.Property(e => e.umsubtotal)
                    .HasPrecision(11, 3)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ver)
                    .HasPrecision(4)
                    .HasDefaultValueSql("1");

                entity.Property(e => e.vssver)
                    .HasPrecision(4)
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<pdm_spec_head_test>(entity =>
            {
                entity.HasKey(e => e.spec_m_id)
                    .HasName("pdm_spec_head_test_pkey");

                entity.ToTable("pdm_spec_head_test", "asics_pdm");

                entity.Property(e => e.spec_m_id).HasMaxLength(36);

                entity.Property(e => e.cbd_update_date).HasColumnType("date");

                entity.Property(e => e.cbd_update_user).HasMaxLength(30);

                entity.Property(e => e.cbd_xml_id).HasMaxLength(36);

                entity.Property(e => e.cbdlockmk)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::character varying");

                entity.Property(e => e.checkoutmk)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::character varying");

                entity.Property(e => e.checkoutuser).HasMaxLength(40);

                entity.Property(e => e.commission)
                    .HasPrecision(4, 1)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.cpcutting)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.cplasting)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.cpoutsoleassembly)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.cpstiching)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.create_date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("CURRENT_DATE");

                entity.Property(e => e.create_user).HasMaxLength(30);

                entity.Property(e => e.currency).HasMaxLength(10);

                entity.Property(e => e.devcolorno).HasMaxLength(10);

                entity.Property(e => e.devno).HasMaxLength(30);

                entity.Property(e => e.entrymode).HasMaxLength(6);

                entity.Property(e => e.excommission)
                    .HasPrecision(7, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.exdirectlabor)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.exfactoryoverhead)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.exmoldamortization)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.exprofit)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.exsubtotal)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.extotal)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.factory).HasMaxLength(10);

                entity.Property(e => e.filename).HasMaxLength(256);

                entity.Property(e => e.fob1stsample)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.fob2ndsample)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.fobfinal)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.fobnego)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.fobphoto)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.fobsales)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.forecast).HasDefaultValueSql("0");

                entity.Property(e => e.heelheight)
                    .HasPrecision(6, 1)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.itemname1)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'SHOE LACE LENGTH'::character varying");

                entity.Property(e => e.itemname10).HasMaxLength(50);

                entity.Property(e => e.itemname2)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'SHOE BOX'::character varying");

                entity.Property(e => e.itemname3)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'GEL FORE'::character varying");

                entity.Property(e => e.itemname4)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'GEL REAR'::character varying");

                entity.Property(e => e.itemname5)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'TOE KEEPER'::character varying");

                entity.Property(e => e.itemname6)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'SHOE BAG'::character varying");

                entity.Property(e => e.itemname7).HasMaxLength(50);

                entity.Property(e => e.itemname8).HasMaxLength(50);

                entity.Property(e => e.itemname9).HasMaxLength(50);

                entity.Property(e => e.lasting).HasMaxLength(10);

                entity.Property(e => e.loginuser).HasMaxLength(30);

                entity.Property(e => e.materialcost)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.materialrate)
                    .HasPrecision(3, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.materialratecurrency).HasMaxLength(10);

                entity.Property(e => e.mcmoldrate)
                    .HasPrecision(5, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.mcmoldratecurency).HasMaxLength(10);

                entity.Property(e => e.mcmoldyears).HasDefaultValueSql("0");

                entity.Property(e => e.omsubtotal)
                    .HasPrecision(11, 3)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.product_d_id).HasMaxLength(36);

                entity.Property(e => e.remarks_cbd).HasMaxLength(1024);

                entity.Property(e => e.remarks_spec).HasMaxLength(1024);

                entity.Property(e => e.smsubtotal)
                    .HasPrecision(11, 3)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.spec_pic_id).HasMaxLength(36);

                entity.Property(e => e.spec_update_date).HasColumnType("date");

                entity.Property(e => e.spec_update_user).HasMaxLength(30);

                entity.Property(e => e.spec_xml_id).HasMaxLength(36);

                entity.Property(e => e.speclockmk)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::character varying");

                entity.Property(e => e.stage).HasMaxLength(10);

                entity.Property(e => e.targetprice)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.umsubtotal)
                    .HasPrecision(11, 3)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ver)
                    .HasPrecision(4)
                    .HasDefaultValueSql("1");

                entity.Property(e => e.vssver)
                    .HasPrecision(4)
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<pdm_spec_item>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pdm_spec_item", "asics_pdm");

                entity.Property(e => e.act_no).HasMaxLength(5);

                entity.Property(e => e.colors).HasMaxLength(50);

                entity.Property(e => e.cost)
                    .HasPrecision(11, 3)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.data_id).HasMaxLength(36);

                entity.Property(e => e.factory_mold_no).HasMaxLength(30);

                entity.Property(e => e.freight)
                    .HasPrecision(3, 1)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.group_mk).HasMaxLength(1);

                entity.Property(e => e.hcha).HasMaxLength(20);

                entity.Property(e => e.material).HasMaxLength(100);

                entity.Property(e => e.materialcomment).HasMaxLength(100);

                entity.Property(e => e.materialloss)
                    .HasPrecision(3, 1)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.materialno).HasMaxLength(30);

                entity.Property(e => e.memo).HasMaxLength(400);

                entity.Property(e => e.moldno).HasMaxLength(30);

                entity.Property(e => e.newmaterial).HasMaxLength(1);

                entity.Property(e => e.no).HasMaxLength(3);

                entity.Property(e => e.partclass).HasMaxLength(1);

                entity.Property(e => e.parts).HasMaxLength(50);

                entity.Property(e => e.pricentmst)
                    .HasPrecision(11, 3)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.pricenttur)
                    .HasPrecision(11, 3)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.sec).HasMaxLength(15);

                entity.Property(e => e.seqno).HasDefaultValueSql("0");

                entity.Property(e => e.spec_d_id)
                    .IsRequired()
                    .HasMaxLength(36);

                entity.Property(e => e.spec_m_id).HasMaxLength(36);

                entity.Property(e => e.standard).HasMaxLength(30);

                entity.Property(e => e.submaterial).HasMaxLength(100);

                entity.Property(e => e.supplier).HasMaxLength(40);

                entity.Property(e => e.usage1)
                    .HasPrecision(11, 3)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.usage2)
                    .HasPrecision(11, 3)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.width).HasMaxLength(10);
            });

            modelBuilder.Entity<pdm_spec_item_factory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pdm_spec_item_factory", "asics_pdm");

                entity.Property(e => e.act_no).HasMaxLength(5);

                entity.Property(e => e.colors).HasMaxLength(50);

                entity.Property(e => e.cost).HasPrecision(11, 3);

                entity.Property(e => e.data_id).HasMaxLength(36);

                entity.Property(e => e.factory_mold_no).HasMaxLength(30);

                entity.Property(e => e.freight).HasPrecision(3, 1);

                entity.Property(e => e.hcha).HasMaxLength(20);

                entity.Property(e => e.material).HasMaxLength(100);

                entity.Property(e => e.materialcomment).HasMaxLength(100);

                entity.Property(e => e.materialloss).HasPrecision(3, 1);

                entity.Property(e => e.materialno).HasMaxLength(30);

                entity.Property(e => e.memo).HasMaxLength(400);

                entity.Property(e => e.moldno).HasMaxLength(30);

                entity.Property(e => e.newmaterial).HasMaxLength(1);

                entity.Property(e => e.no).HasMaxLength(3);

                entity.Property(e => e.page_break)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::character varying");

                entity.Property(e => e.partclass).HasMaxLength(1);

                entity.Property(e => e.parts).HasMaxLength(50);

                entity.Property(e => e.pricentmst).HasPrecision(11, 3);

                entity.Property(e => e.pricenttur).HasPrecision(11, 3);

                entity.Property(e => e.sec).HasMaxLength(10);

                entity.Property(e => e.spec_d_id)
                    .IsRequired()
                    .HasMaxLength(36);

                entity.Property(e => e.spec_m_id).HasMaxLength(36);

                entity.Property(e => e.standard).HasMaxLength(30);

                entity.Property(e => e.submaterial).HasMaxLength(100);

                entity.Property(e => e.supplier).HasMaxLength(40);

                entity.Property(e => e.usage1).HasPrecision(11, 3);

                entity.Property(e => e.usage2).HasPrecision(11, 3);

                entity.Property(e => e.width).HasMaxLength(10);
            });

            modelBuilder.Entity<pdm_spec_moldcharge>(entity =>
            {
                entity.HasKey(e => e.data_id)
                    .HasName("pdm_spec_moldcharge_pkey");

                entity.ToTable("pdm_spec_moldcharge", "asics_pdm");

                entity.Property(e => e.data_id).HasMaxLength(36);

                entity.Property(e => e.amortization)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.charge)
                    .HasPrecision(11, 3)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.id).HasMaxLength(10);

                entity.Property(e => e.item).HasMaxLength(30);

                entity.Property(e => e.price)
                    .HasPrecision(8)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.qty).HasDefaultValueSql("0");

                entity.Property(e => e.spec_m_id).HasMaxLength(36);

                entity.Property(e => e.years).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<pdm_spec_standard>(entity =>
            {
                entity.HasKey(e => e.data_id)
                    .HasName("pdm_spec_standard_pkey");

                entity.ToTable("pdm_spec_standard", "asics_pdm");

                entity.Property(e => e.data_id).HasMaxLength(36);

                entity.Property(e => e.itemval1).HasMaxLength(50);

                entity.Property(e => e.itemval10).HasMaxLength(50);

                entity.Property(e => e.itemval2).HasMaxLength(50);

                entity.Property(e => e.itemval3).HasMaxLength(50);

                entity.Property(e => e.itemval4).HasMaxLength(50);

                entity.Property(e => e.itemval5).HasMaxLength(50);

                entity.Property(e => e.itemval6).HasMaxLength(50);

                entity.Property(e => e.itemval7).HasMaxLength(50);

                entity.Property(e => e.itemval8).HasMaxLength(50);

                entity.Property(e => e.itemval9).HasMaxLength(50);

                entity.Property(e => e.memo).HasMaxLength(400);

                entity.Property(e => e.seqno).HasDefaultValueSql("0");

                entity.Property(e => e.spec_m_id).HasMaxLength(36);

                entity.Property(e => e.the_size).HasMaxLength(10);
            });

            modelBuilder.Entity<pdm_spec_standard_factory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pdm_spec_standard_factory", "asics_pdm");

                entity.Property(e => e.data_id)
                    .IsRequired()
                    .HasMaxLength(36);

                entity.Property(e => e.itemval1).HasMaxLength(50);

                entity.Property(e => e.itemval10).HasMaxLength(50);

                entity.Property(e => e.itemval2).HasMaxLength(50);

                entity.Property(e => e.itemval3).HasMaxLength(50);

                entity.Property(e => e.itemval4).HasMaxLength(50);

                entity.Property(e => e.itemval5).HasMaxLength(50);

                entity.Property(e => e.itemval6).HasMaxLength(50);

                entity.Property(e => e.itemval7).HasMaxLength(50);

                entity.Property(e => e.itemval8).HasMaxLength(50);

                entity.Property(e => e.itemval9).HasMaxLength(50);

                entity.Property(e => e.memo).HasMaxLength(400);

                entity.Property(e => e.spec_m_id).HasMaxLength(36);

                entity.Property(e => e.the_size).HasMaxLength(10);
            });

            modelBuilder.Entity<pdm_user_roles>(entity =>
            {
                entity.HasKey(e => e.user_role_id)
                    .HasName("pdm_user_roles_pkey");

                entity.ToTable("pdm_user_roles", "asics_pdm");

                entity.Property(e => e.user_role_id).HasDefaultValueSql("nextval('pdm_user_roles_user_role_id_seq'::regclass)");

                entity.Property(e => e.created_at).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.updated_at).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.created_byNavigation)
                    .WithMany(p => p.pdm_user_rolescreated_byNavigation)
                    .HasForeignKey(d => d.created_by)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pdm_user_roles_created_by_fkey");

                entity.HasOne(d => d.role)
                    .WithMany(p => p.pdm_user_roles)
                    .HasForeignKey(d => d.role_id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("pdm_user_roles_role_id_fkey");

                entity.HasOne(d => d.updated_byNavigation)
                    .WithMany(p => p.pdm_user_rolesupdated_byNavigation)
                    .HasForeignKey(d => d.updated_by)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pdm_user_roles_updated_by_fkey");

                entity.HasOne(d => d.user)
                    .WithMany(p => p.pdm_user_rolesuser)
                    .HasForeignKey(d => d.user_id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("pdm_user_roles_user_id_fkey");
            });

            modelBuilder.Entity<pdm_users>(entity =>
            {
                entity.HasKey(e => e.user_id)
                    .HasName("pdm_users_new_pkey");

                entity.ToTable("pdm_users", "asics_pdm");

                entity.HasIndex(e => e.email, "idx_email");

                entity.HasIndex(e => e.email, "pdm_users_new_email_key")
                    .IsUnique();

                entity.HasIndex(e => e.sso_acct, "unique_sso_acct")
                    .IsUnique();

                entity.Property(e => e.user_id)
                    .HasDefaultValueSql("nextval('pdm_users_new_user_id_seq'::regclass)")
                    .HasComment("ID流水號");

                entity.Property(e => e.created_at)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("新建時間");

                entity.Property(e => e.created_by).HasComment("新建人員");

                entity.Property(e => e.email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasComment("Email");

                entity.Property(e => e.is_active)
                    .HasColumnType("character varying")
                    .HasDefaultValueSql("'Y'::character varying")
                    .HasComment("是否生效");

                entity.Property(e => e.is_sso)
                    .HasColumnType("character varying")
                    .HasDefaultValueSql("'Y'::character varying")
                    .HasComment("是否來自SSO建立帳號");

                entity.Property(e => e.keycloak_iam_sub)
                    .HasMaxLength(255)
                    .HasComment("keycloak_sub也是唯一碼");

                entity.Property(e => e.last_login).HasComment("上次登入時間");

                entity.Property(e => e.local_name)
                    .HasMaxLength(300)
                    .HasComment("當地名稱");

                entity.Property(e => e.password_hash)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasComment("預設密碼");

                entity.Property(e => e.pccuid)
                    .HasPrecision(20)
                    .HasComment("PCCUID");

                entity.Property(e => e.sso_acct)
                    .HasMaxLength(50)
                    .HasComment("SSO帳號");

                entity.Property(e => e.updated_at)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("異動時間");

                entity.Property(e => e.updated_by).HasComment("異動人員");

                entity.Property(e => e.username)
                    .HasMaxLength(300)
                    .HasComment("User名稱");
            });

            modelBuilder.Entity<plm_cbd_head>(entity =>
            {
                entity.HasKey(e => e.data_m_id)
                    .HasName("plm_cbd_head_pk");

                entity.ToTable("plm_cbd_head", "asics_pdm");

                entity.Property(e => e.data_m_id).HasMaxLength(36);

                entity.Property(e => e.bom).HasMaxLength(80);

                entity.Property(e => e.cbd_remarks).HasMaxLength(1024);

                entity.Property(e => e.cbd_update_date).HasColumnType("date");

                entity.Property(e => e.cbd_update_user).HasMaxLength(30);

                entity.Property(e => e.cbdlockmk)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::character varying");

                entity.Property(e => e.checkoutmk)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::character varying");

                entity.Property(e => e.checkoutuser).HasMaxLength(40);

                entity.Property(e => e.colors).HasMaxLength(80);

                entity.Property(e => e.commisiion)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.cpcutting)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.cplasting)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.cpoutsoleassembly)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.cpstiching)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.create_date).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.create_user).HasMaxLength(30);

                entity.Property(e => e.currency).HasMaxLength(10);

                entity.Property(e => e.excommisiion)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.exdirectlabor)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.exfactoryoverhead)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.exmoldamortization)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.exprofit)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.exsubtotal)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.extotal)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.factory).HasMaxLength(40);

                entity.Property(e => e.finalprice)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.forecast).HasMaxLength(20);

                entity.Property(e => e.loginuser).HasMaxLength(30);

                entity.Property(e => e.materialcost)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.omsubtotal)
                    .HasPrecision(11, 3)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.product_d_id).HasMaxLength(36);

                entity.Property(e => e.smsubtotal)
                    .HasPrecision(11, 3)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.spec_remarks).HasMaxLength(1024);

                entity.Property(e => e.spec_update_date).HasColumnType("date");

                entity.Property(e => e.spec_update_user).HasMaxLength(30);

                entity.Property(e => e.speclockmk)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::character varying");

                entity.Property(e => e.stage).HasMaxLength(3);

                entity.Property(e => e.targetprice)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.totalcost)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.umsubtotal)
                    .HasPrecision(11, 3)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.update_date).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.update_user).HasMaxLength(30);

                entity.Property(e => e.ver).HasDefaultValueSql("1");

                entity.Property(e => e.vssver).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<plm_cbd_item>(entity =>
            {
                entity.HasKey(e => e.data_d_id)
                    .HasName("plm_cbd_item_pk");

                entity.ToTable("plm_cbd_item", "asics_pdm");

                entity.Property(e => e.data_d_id).HasMaxLength(36);

                entity.Property(e => e.act_no).HasMaxLength(5);

                entity.Property(e => e.act_parts).HasMaxLength(80);

                entity.Property(e => e.agent).HasMaxLength(40);

                entity.Property(e => e.basecolor).HasMaxLength(200);

                entity.Property(e => e.basicprice)
                    .HasPrecision(11, 3)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.cbdcomment).HasMaxLength(400);

                entity.Property(e => e.change_mk)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::character varying");

                entity.Property(e => e.clrcomment).HasMaxLength(400);

                entity.Property(e => e.colors).HasMaxLength(50);

                entity.Property(e => e.cost)
                    .HasPrecision(11, 3)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.data_id)
                    .IsRequired()
                    .HasMaxLength(36);

                entity.Property(e => e.data_m_id)
                    .IsRequired()
                    .HasMaxLength(36);

                entity.Property(e => e.detail).HasMaxLength(60);

                entity.Property(e => e.effect).HasMaxLength(200);

                entity.Property(e => e.factory_mold_no).HasMaxLength(30);

                entity.Property(e => e.freight)
                    .HasPrecision(11, 3)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.group_mk).HasMaxLength(1);

                entity.Property(e => e.hcha).HasMaxLength(50);

                entity.Property(e => e.material).HasMaxLength(100);

                entity.Property(e => e.materialno).HasMaxLength(30);

                entity.Property(e => e.memo).HasMaxLength(400);

                entity.Property(e => e.moldno).HasMaxLength(30);

                entity.Property(e => e.mtrbase).HasMaxLength(200);

                entity.Property(e => e.mtrcomment).HasMaxLength(400);

                entity.Property(e => e.mtrloss)
                    .HasPrecision(11, 3)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.mtrtype).HasMaxLength(200);

                entity.Property(e => e.newmaterial).HasMaxLength(1);

                entity.Property(e => e.no).HasMaxLength(3);

                entity.Property(e => e.partclass).HasMaxLength(1);

                entity.Property(e => e.parts).HasMaxLength(50);

                entity.Property(e => e.process_mk).HasMaxLength(1);

                entity.Property(e => e.processing).HasMaxLength(200);

                entity.Property(e => e.quotesupplier).HasMaxLength(50);

                entity.Property(e => e.recycle).HasMaxLength(200);

                entity.Property(e => e.releasepaper).HasMaxLength(200);

                entity.Property(e => e.sec).HasMaxLength(10);

                entity.Property(e => e.seqno).HasDefaultValueSql("0");

                entity.Property(e => e.standard).HasMaxLength(30);

                entity.Property(e => e.supplier).HasMaxLength(40);

                entity.Property(e => e.unitprice)
                    .HasPrecision(11, 3)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.usage1)
                    .HasPrecision(11, 3)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.usage2)
                    .HasPrecision(11, 3)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.width).HasMaxLength(20);
            });

            modelBuilder.Entity<plm_cbd_moldcharge>(entity =>
            {
                entity.HasKey(e => e.data_d_id)
                    .HasName("plm_cbd_moldcharge_pk");

                entity.ToTable("plm_cbd_moldcharge", "asics_pdm");

                entity.Property(e => e.data_d_id).HasMaxLength(36);

                entity.Property(e => e.amortization)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.charge)
                    .HasPrecision(11, 3)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.cost).HasPrecision(11, 3);

                entity.Property(e => e.data_m_id).HasMaxLength(36);

                entity.Property(e => e.id).HasMaxLength(10);

                entity.Property(e => e.item).HasMaxLength(200);

                entity.Property(e => e.price)
                    .HasPrecision(8)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.qty)
                    .HasPrecision(10)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.rate).HasPrecision(10, 2);

                entity.Property(e => e.unitprice).HasPrecision(11, 3);

                entity.Property(e => e.years)
                    .HasPrecision(4, 1)
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<plm_product_head>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("plm_product_head", "asics_pdm");

                entity.HasIndex(e => e.brand_no, "idx_plm_product_head_brand_no");

                entity.HasIndex(e => new { e.development_no, e.stage_code }, "idx_plm_product_head_dev_no_color_no_stage");

                entity.HasIndex(e => e.development_no, "idx_plm_product_head_development_no");

                entity.HasIndex(e => e.working_name, "idx_plm_product_head_working_name");

                entity.Property(e => e.account_code).HasMaxLength(30);

                entity.Property(e => e.account_exclusivity).HasMaxLength(30);

                entity.Property(e => e.account_name).HasMaxLength(100);

                entity.Property(e => e.active).HasMaxLength(10);

                entity.Property(e => e.add_date).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.article_description).HasMaxLength(100);

                entity.Property(e => e.assigned_agents).HasMaxLength(20);

                entity.Property(e => e.brand).HasMaxLength(20);

                entity.Property(e => e.brand_no).HasMaxLength(3);

                entity.Property(e => e.bt_project).HasMaxLength(5);

                entity.Property(e => e.category1).HasMaxLength(20);

                entity.Property(e => e.category2).HasMaxLength(20);

                entity.Property(e => e.category3).HasMaxLength(20);

                entity.Property(e => e.category4).HasMaxLength(20);

                entity.Property(e => e.cleats_material).HasMaxLength(30);

                entity.Property(e => e.cleats_replaceable_fixed).HasMaxLength(30);

                entity.Property(e => e.cleats_type).HasMaxLength(15);

                entity.Property(e => e.default_size).HasMaxLength(5);

                entity.Property(e => e.designer).HasMaxLength(30);

                entity.Property(e => e.developer).HasMaxLength(30);

                entity.Property(e => e.developer_remarks).HasMaxLength(100);

                entity.Property(e => e.development_no).HasMaxLength(40);

                entity.Property(e => e.distribution_tier).HasMaxLength(15);

                entity.Property(e => e.domain).HasMaxLength(30);

                entity.Property(e => e.earliest_rid).HasMaxLength(8);

                entity.Property(e => e.factory).HasMaxLength(4);

                entity.Property(e => e.gender).HasMaxLength(10);

                entity.Property(e => e.global_id).HasMaxLength(8);

                entity.Property(e => e.global_rid).HasMaxLength(8);

                entity.Property(e => e.global_srp).HasPrecision(10, 2);

                entity.Property(e => e.heel_height).HasMaxLength(30);

                entity.Property(e => e.item_initial_season).HasMaxLength(4);

                entity.Property(e => e.item_mode).HasMaxLength(10);

                entity.Property(e => e.item_mode_sub_type).HasMaxLength(30);

                entity.Property(e => e.item_trading_code).HasMaxLength(20);

                entity.Property(e => e.jump_to_merch_plan).HasMaxLength(10);

                entity.Property(e => e.key_item).HasMaxLength(5);

                entity.Property(e => e.kids_type).HasMaxLength(10);

                entity.Property(e => e.last1).HasMaxLength(50);

                entity.Property(e => e.last2).HasMaxLength(50);

                entity.Property(e => e.last3).HasMaxLength(50);

                entity.Property(e => e.lasting).HasMaxLength(15);

                entity.Property(e => e.latest_bom).HasMaxLength(70);

                entity.Property(e => e.lp02_season_forecast).HasMaxLength(10);

                entity.Property(e => e.lp02_yearly_forecast).HasMaxLength(10);

                entity.Property(e => e.lp03_season_forecast).HasMaxLength(10);

                entity.Property(e => e.lp03_yearly_forecast).HasMaxLength(10);

                entity.Property(e => e.ls_category).HasMaxLength(20);

                entity.Property(e => e.main_factory).HasMaxLength(2);

                entity.Property(e => e.md_remarks).HasMaxLength(300);

                entity.Property(e => e.modified).HasColumnType("date");

                entity.Property(e => e.modified_by).HasMaxLength(30);

                entity.Property(e => e.mold_set).HasMaxLength(120);

                entity.Property(e => e.moq_per_item).HasMaxLength(10);

                entity.Property(e => e.original_factory).HasMaxLength(2);

                entity.Property(e => e.pack).HasMaxLength(40);

                entity.Property(e => e.pm_name).HasMaxLength(30);

                entity.Property(e => e.previous_factory).HasMaxLength(2);

                entity.Property(e => e.price_tier).HasMaxLength(10);

                entity.Property(e => e.product_line_type).HasMaxLength(10);

                entity.Property(e => e.product_m_id)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.production_approval).HasMaxLength(5);

                entity.Property(e => e.production_approval_date).HasMaxLength(8);

                entity.Property(e => e.production_lead_time).HasMaxLength(10);

                entity.Property(e => e.production_start_month).HasMaxLength(8);

                entity.Property(e => e.pushed_development_time).HasMaxLength(8);

                entity.Property(e => e.ref_item).HasMaxLength(50);

                entity.Property(e => e.ref_item_mold_set).HasMaxLength(50);

                entity.Property(e => e.region_exclusivity).HasMaxLength(30);

                entity.Property(e => e.regional_approval).HasMaxLength(30);

                entity.Property(e => e.regional_approval_date).HasMaxLength(8);

                entity.Property(e => e.sampling_factory).HasMaxLength(2);

                entity.Property(e => e.season).HasMaxLength(4);

                entity.Property(e => e.series).HasMaxLength(30);

                entity.Property(e => e.series_with_generation).HasMaxLength(30);

                entity.Property(e => e.sfm_date).HasMaxLength(8);

                entity.Property(e => e.sfm_date_status).HasMaxLength(10);

                entity.Property(e => e.silo1).HasMaxLength(50);

                entity.Property(e => e.silo2).HasMaxLength(50);

                entity.Property(e => e.size_range).HasMaxLength(20);

                entity.Property(e => e.size_run).HasMaxLength(200);

                entity.Property(e => e.sizemap).HasMaxLength(30);

                entity.Property(e => e.sole_material1).HasMaxLength(30);

                entity.Property(e => e.sole_material2).HasMaxLength(30);

                entity.Property(e => e.sole_material3).HasMaxLength(30);

                entity.Property(e => e.sort_order).HasMaxLength(30);

                entity.Property(e => e.sourcing_remarks).HasMaxLength(400);

                entity.Property(e => e.stage).HasMaxLength(10);

                entity.Property(e => e.stage_code).HasMaxLength(10);

                entity.Property(e => e.sub_factory).HasMaxLength(2);

                entity.Property(e => e.sub_factory2).HasMaxLength(2);

                entity.Property(e => e.target_fob).HasPrecision(10, 2);

                entity.Property(e => e.target_of_colors).HasMaxLength(2);

                entity.Property(e => e.tdm_date).HasMaxLength(8);

                entity.Property(e => e.tdm_status).HasMaxLength(10);

                entity.Property(e => e.transfer_to).HasMaxLength(10);

                entity.Property(e => e.update_date).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.upper_material).HasMaxLength(30);

                entity.Property(e => e.upper_material1).HasMaxLength(30);

                entity.Property(e => e.upper_material2).HasMaxLength(30);

                entity.Property(e => e.upper_material3).HasMaxLength(30);

                entity.Property(e => e.upper_material4).HasMaxLength(30);

                entity.Property(e => e.upper_material5).HasMaxLength(30);

                entity.Property(e => e.width).HasMaxLength(10);

                entity.Property(e => e.working_name).HasMaxLength(130);
            });

            modelBuilder.Entity<plm_product_item>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("plm_product_item", "asics_pdm");

                entity.HasIndex(e => e.colorway, "idx_plm_product_item_colorway");

                entity.HasIndex(e => new { e.development_color_no, e.colorway }, "idx_plm_product_item_dev_color_no");

                entity.HasIndex(e => e.development_color_no, "idx_plm_product_item_development_color_no");

                entity.HasIndex(e => e.product_d_id, "idx_plm_product_item_product_d_id");

                entity.HasIndex(e => e.product_m_id, "idx_plm_product_item_product_m_id");

                entity.Property(e => e.active).HasMaxLength(5);

                entity.Property(e => e.add_date).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.attributes_active).HasMaxLength(30);

                entity.Property(e => e.attributes_color_mode).HasMaxLength(30);

                entity.Property(e => e.attributes_color_mode_sub_type).HasMaxLength(30);

                entity.Property(e => e.color_code).HasMaxLength(4);

                entity.Property(e => e.colorway).HasMaxLength(100);

                entity.Property(e => e.created).HasColumnType("date");

                entity.Property(e => e.created_by).HasMaxLength(20);

                entity.Property(e => e.design_candidate).HasMaxLength(10);

                entity.Property(e => e.development_color_no).HasMaxLength(5);

                entity.Property(e => e.drop_reason).HasMaxLength(10);

                entity.Property(e => e.jump_to_merch_plan).HasMaxLength(30);

                entity.Property(e => e.key_color).HasMaxLength(50);

                entity.Property(e => e.main_color).HasMaxLength(30);

                entity.Property(e => e.modified).HasColumnType("date");

                entity.Property(e => e.modified_by).HasMaxLength(20);

                entity.Property(e => e.moq_per_color).HasMaxLength(30);

                entity.Property(e => e.product_d_id)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.product_m_id)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.sub_color).HasMaxLength(30);

                entity.Property(e => e.update_date).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<plm_spec_head>(entity =>
            {
                entity.HasKey(e => new { e.product_d_id, e.spec_m_id })
                    .HasName("plm_spec_head_pkey");

                entity.ToTable("plm_spec_head", "asics_pdm");

                entity.Property(e => e.product_d_id).HasMaxLength(32);

                entity.Property(e => e.spec_m_id).HasMaxLength(32);

                entity.Property(e => e.colorcode).HasMaxLength(10);

                entity.Property(e => e.colorway).HasMaxLength(100);

                entity.Property(e => e.create_date).HasColumnType("date");

                entity.Property(e => e.create_user).HasMaxLength(30);

                entity.Property(e => e.development_color).HasMaxLength(5);

                entity.Property(e => e.development_no).HasMaxLength(40);

                entity.Property(e => e.stage).HasMaxLength(10);

                entity.Property(e => e.stage_code).HasMaxLength(5);

                entity.Property(e => e.update_date).HasColumnType("date");

                entity.Property(e => e.update_user).HasMaxLength(30);
            });

            modelBuilder.Entity<plm_spec_item>(entity =>
            {
                entity.HasKey(e => new { e.spec_m_id, e.spec_d_id })
                    .HasName("plm_spec_item_pkey");

                entity.ToTable("plm_spec_item", "asics_pdm");

                entity.Property(e => e.spec_m_id).HasMaxLength(32);

                entity.Property(e => e.spec_d_id).HasMaxLength(32);

                entity.Property(e => e.act_part_no).HasMaxLength(3);

                entity.Property(e => e.act_parts).HasMaxLength(200);

                entity.Property(e => e.add_date).HasColumnType("date");

                entity.Property(e => e.agent).HasMaxLength(200);

                entity.Property(e => e.basecolor).HasMaxLength(200);

                entity.Property(e => e.clr_comment).HasMaxLength(200);

                entity.Property(e => e.detail).HasMaxLength(200);

                entity.Property(e => e.effect).HasMaxLength(200);

                entity.Property(e => e.hcha).HasMaxLength(30);

                entity.Property(e => e.mat_comment).HasMaxLength(200);

                entity.Property(e => e.material).HasMaxLength(200);

                entity.Property(e => e.material_color).HasMaxLength(200);

                entity.Property(e => e.material_group).HasMaxLength(5);

                entity.Property(e => e.material_new).HasMaxLength(10);

                entity.Property(e => e.mtrbase).HasMaxLength(200);

                entity.Property(e => e.mtrtype).HasMaxLength(200);

                entity.Property(e => e.part_mk)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::character varying");

                entity.Property(e => e.parts).HasMaxLength(200);

                entity.Property(e => e.parts_no).HasMaxLength(3);

                entity.Property(e => e.process_mk).HasMaxLength(3);

                entity.Property(e => e.processing).HasMaxLength(200);

                entity.Property(e => e.quote_supplier).HasMaxLength(200);

                entity.Property(e => e.recycle).HasMaxLength(200);

                entity.Property(e => e.releasepaper).HasMaxLength(200);

                entity.Property(e => e.sec).HasMaxLength(15);

                entity.Property(e => e.standard).HasMaxLength(50);

                entity.Property(e => e.supplier).HasMaxLength(200);

                entity.Property(e => e.update_date).HasColumnType("date");
            });

            modelBuilder.Entity<sys_material_large_class>(entity =>
            {
                entity.HasKey(e => e.class_l_no)
                    .HasName("default_material_large_class_pk");

                entity.ToTable("sys_material_large_class", "asics_pdm");

                entity.Property(e => e.class_l_no).HasMaxLength(2);

                entity.Property(e => e.class_name_en)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.class_name_zh_tw)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.is_activate)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'Y'::bpchar");

                entity.Property(e => e.mda_mtart)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'ZROH'::character varying");
            });

            modelBuilder.Entity<sys_material_medium_class>(entity =>
            {
                entity.HasKey(e => new { e.class_l_no, e.class_m_no })
                    .HasName("default_material_medium_class_pk");

                entity.ToTable("sys_material_medium_class", "asics_pdm");

                entity.Property(e => e.class_l_no).HasMaxLength(2);

                entity.Property(e => e.class_m_no).HasMaxLength(2);

                entity.Property(e => e.class_name_en)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.class_name_zh_tw)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.is_activate)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'Y'::bpchar");

                entity.Property(e => e.is_appt)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::bpchar");
            });

            modelBuilder.Entity<sys_material_small_class>(entity =>
            {
                entity.HasKey(e => new { e.class_l_no, e.class_m_no, e.class_s_no })
                    .HasName("default_material_small_class_pk");

                entity.ToTable("sys_material_small_class", "asics_pdm");

                entity.Property(e => e.class_l_no).HasMaxLength(2);

                entity.Property(e => e.class_m_no).HasMaxLength(2);

                entity.Property(e => e.class_s_no).HasMaxLength(2);

                entity.Property(e => e.class_name_en)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.class_name_zh_tw)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.is_activate)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'Y'::bpchar");
            });

            modelBuilder.Entity<sys_menu>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("sys_menu", "asics_pdm");

                entity.Property(e => e.is_parents)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasComment("是否為主節點");

                entity.Property(e => e.menu_id)
                    .IsRequired()
                    .HasMaxLength(36)
                    .HasComment("作業id");

                entity.Property(e => e.menu_name)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasComment("作業名稱");

                entity.Property(e => e.menu_no)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasComment("作業代號");

                entity.Property(e => e.menu_pid)
                    .HasMaxLength(36)
                    .HasComment("主節點");

                entity.Property(e => e.menu_sort)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasComment("排序");
            });

            modelBuilder.Entity<sys_namevalue>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("sys_namevalue", "asics_pdm");

                entity.Property(e => e.data_no).HasMaxLength(20);

                entity.Property(e => e.group_key).HasMaxLength(30);

                entity.Property(e => e.pkid)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.status)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'Y'::character varying");

                entity.Property(e => e.text).HasMaxLength(100);

                entity.Property(e => e.text_en).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
