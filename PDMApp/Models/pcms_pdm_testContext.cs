﻿using System;
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
        public virtual DbSet<pdm_api_permission> pdm_api_permission { get; set; }
        public virtual DbSet<pdm_factoryspec_ref_signflow> pdm_factoryspec_ref_signflow { get; set; }
        public virtual DbSet<pdm_group> pdm_group { get; set; }
        public virtual DbSet<pdm_group_mgr> pdm_group_mgr { get; set; }
        public virtual DbSet<pdm_history_denamic_signflow> pdm_history_denamic_signflow { get; set; }
        public virtual DbSet<pdm_namevalue> pdm_namevalue { get; set; }
        public virtual DbSet<pdm_permission_logs> pdm_permission_logs { get; set; }
        public virtual DbSet<pdm_permissions> pdm_permissions { get; set; }
        public virtual DbSet<pdm_product_head> pdm_product_head { get; set; }
        public virtual DbSet<pdm_product_item> pdm_product_item { get; set; }
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
        public virtual DbSet<pdm_user_group> pdm_user_group { get; set; }
        public virtual DbSet<pdm_user_roles> pdm_user_roles { get; set; }
        public virtual DbSet<pdm_users> pdm_users { get; set; }
        public virtual DbSet<pdm_users_new> pdm_users_new { get; set; }
        public virtual DbSet<plm_cbd_head> plm_cbd_head { get; set; }
        public virtual DbSet<plm_cbd_item> plm_cbd_item { get; set; }
        public virtual DbSet<plm_cbd_moldcharge> plm_cbd_moldcharge { get; set; }
        public virtual DbSet<plm_product_head> plm_product_head { get; set; }
        public virtual DbSet<plm_product_item> plm_product_item { get; set; }
        public virtual DbSet<sys_menu> sys_menu { get; set; }

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

            modelBuilder.Entity<pdm_api_permission>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pdm_api_permission", "asics_pdm");

                entity.Property(e => e.permission_name).HasColumnType("character varying");

                entity.Property(e => e.update_time).HasColumnType("timestamp with time zone");

                entity.Property(e => e.update_user).HasColumnType("character varying");
            });

            modelBuilder.Entity<pdm_factoryspec_ref_signflow>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pdm_factoryspec_ref_signflow", "asics_pdm");

                entity.Property(e => e.id).HasMaxLength(4);

                entity.Property(e => e.spec_m_id).HasMaxLength(36);

                entity.Property(e => e.sub_bill_class).HasMaxLength(2);
            });

            modelBuilder.Entity<pdm_group>(entity =>
            {
                entity.HasKey(e => e.group_id)
                    .HasName("acl_group_groupid_pk");

                entity.ToTable("pdm_group", "asics_pdm");

                entity.HasIndex(e => e.group_ida, "acl_group_idx");

                entity.HasIndex(e => new { e.group_pid, e.group_no }, "acl_group_ui")
                    .IsUnique();

                entity.HasIndex(e => new { e.ap_name, e.group_no }, "acl_group_uk1")
                    .IsUnique();

                entity.Property(e => e.group_id).HasMaxLength(22);

                entity.Property(e => e.ap_name)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.conn_alias).HasMaxLength(20);

                entity.Property(e => e.create_user)
                    .IsRequired()
                    .HasMaxLength(22);

                entity.Property(e => e.group_end)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'Y'::bpchar");

                entity.Property(e => e.group_ida).HasMaxLength(120);

                entity.Property(e => e.group_lvl).HasPrecision(2);

                entity.Property(e => e.group_memo).HasMaxLength(100);

                entity.Property(e => e.group_nm).HasMaxLength(20);

                entity.Property(e => e.group_nma).HasMaxLength(250);

                entity.Property(e => e.group_no)
                    .IsRequired()
                    .HasMaxLength(22);

                entity.Property(e => e.group_noa).HasMaxLength(200);

                entity.Property(e => e.group_ntyp).HasMaxLength(10);

                entity.Property(e => e.group_owner).HasMaxLength(22);

                entity.Property(e => e.group_pid).HasMaxLength(22);

                entity.Property(e => e.group_stat)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'Y'::bpchar");

                entity.Property(e => e.group_typ)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'G'::character varying");

                entity.Property(e => e.is_allow_deploy)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.is_allow_modify)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'Y'::bpchar");

                entity.Property(e => e.is_pass_deploy)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.update_time).HasPrecision(19);

                entity.Property(e => e.update_user).HasMaxLength(22);

                entity.HasOne(d => d.create_userNavigation)
                    .WithMany(p => p.pdm_group)
                    .HasForeignKey(d => d.create_user)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("acl_group_userid_fk");
            });

            modelBuilder.Entity<pdm_group_mgr>(entity =>
            {
                entity.HasKey(e => e.group_mgr_id)
                    .HasName("acl_group_mgr_pk");

                entity.ToTable("pdm_group_mgr", "asics_pdm");

                entity.HasIndex(e => new { e.user_id, e.group_id }, "acl_group_mgr_uk1")
                    .IsUnique();

                entity.Property(e => e.group_mgr_id).HasMaxLength(22);

                entity.Property(e => e.create_user)
                    .IsRequired()
                    .HasMaxLength(22);

                entity.Property(e => e.group_id)
                    .IsRequired()
                    .HasMaxLength(22);

                entity.Property(e => e.is_allow_deploy)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.is_allow_modify)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'Y'::bpchar");

                entity.Property(e => e.is_pass_deploy)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.update_time).HasPrecision(19);

                entity.Property(e => e.update_user).HasMaxLength(22);

                entity.Property(e => e.user_id)
                    .IsRequired()
                    .HasMaxLength(22);

                entity.HasOne(d => d.user)
                    .WithMany(p => p.pdm_group_mgr)
                    .HasForeignKey(d => d.user_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("acl_group_mgr_fk1");
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

            modelBuilder.Entity<pdm_permission_logs>(entity =>
            {
                entity.HasKey(e => e.log_id)
                    .HasName("pdm_permission_logs_pkey");

                entity.ToTable("pdm_permission_logs", "asics_pdm");

                entity.Property(e => e.log_id).HasDefaultValueSql("nextval('pdm_permission_logs_log_id_seq'::regclass)");

                entity.Property(e => e.created_at).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.factory).HasMaxLength(50);

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

            modelBuilder.Entity<pdm_role_permissions>(entity =>
            {
                entity.HasKey(e => e.role_permission_id)
                    .HasName("pdm_role_permissions_pkey");

                entity.ToTable("pdm_role_permissions", "asics_pdm");

                entity.Property(e => e.role_permission_id).HasDefaultValueSql("nextval('pdm_role_permissions_role_permission_id_seq'::regclass)");

                entity.Property(e => e.created_at).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.createp).HasDefaultValueSql("true");

                entity.Property(e => e.deletep).HasDefaultValueSql("true");

                entity.Property(e => e.exportp).HasDefaultValueSql("true");

                entity.Property(e => e.factory)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'ALL'::character varying");

                entity.Property(e => e.importp).HasDefaultValueSql("true");

                entity.Property(e => e.is_active).HasDefaultValueSql("true");

                entity.Property(e => e.permission1).HasDefaultValueSql("true");

                entity.Property(e => e.permission2).HasDefaultValueSql("true");

                entity.Property(e => e.permission3).HasDefaultValueSql("true");

                entity.Property(e => e.permission4).HasDefaultValueSql("true");

                entity.Property(e => e.readp).HasDefaultValueSql("true");

                entity.Property(e => e.updated_at).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.updatep).HasDefaultValueSql("true");

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

                entity.Property(e => e.role_id).HasDefaultValueSql("nextval('pdm_roles_role_id_seq'::regclass)");

                entity.Property(e => e.created_at).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.factory)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'DEFAULT'::character varying");

                entity.Property(e => e.role_name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.updated_at).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.created_byNavigation)
                    .WithMany(p => p.pdm_rolescreated_byNavigation)
                    .HasForeignKey(d => d.created_by)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pdm_roles_created_by_fkey");

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

            modelBuilder.Entity<pdm_user_group>(entity =>
            {
                entity.HasKey(e => new { e.user_id, e.group_id })
                    .HasName("acl_user_group_pk");

                entity.ToTable("pdm_user_group", "asics_pdm");

                entity.Property(e => e.user_id)
                    .HasMaxLength(22)
                    .HasComment("PDM UserID");

                entity.Property(e => e.group_id).HasMaxLength(22);

                entity.Property(e => e.is_allow_deploy)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.is_allow_modify)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'Y'::bpchar");

                entity.Property(e => e.is_pass_deploy)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.update_time).HasPrecision(19);

                entity.Property(e => e.update_user).HasMaxLength(22);

                entity.HasOne(d => d.user)
                    .WithMany(p => p.pdm_user_group)
                    .HasForeignKey(d => d.user_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_group_fk_users");
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
                    .HasName("users_pk");

                entity.ToTable("pdm_users", "asics_pdm");

                entity.HasIndex(e => e.user_pccuid, "pdm_pccuid_index");

                entity.Property(e => e.user_id).HasMaxLength(22);

                entity.Property(e => e.im_acct).HasMaxLength(40);

                entity.Property(e => e.is_allow_deploy)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.is_allow_modify)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'Y'::bpchar");

                entity.Property(e => e.is_pass_deploy)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.last_logintime).HasPrecision(19);

                entity.Property(e => e.update_time).HasPrecision(19);

                entity.Property(e => e.update_user).HasMaxLength(22);

                entity.Property(e => e.user_disable)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::character varying");

                entity.Property(e => e.user_lang).HasMaxLength(10);

                entity.Property(e => e.user_pccuid)
                    .HasPrecision(14)
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.user_timezone).HasMaxLength(6);
            });

            modelBuilder.Entity<pdm_users_new>(entity =>
            {
                entity.HasKey(e => e.user_id)
                    .HasName("pdm_users_new_pkey");

                entity.ToTable("pdm_users_new", "asics_pdm");

                entity.HasIndex(e => e.email, "pdm_users_new_email_key")
                    .IsUnique();

                entity.Property(e => e.user_id).HasDefaultValueSql("nextval('pdm_users_new_user_id_seq'::regclass)");

                entity.Property(e => e.created_at).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.is_active).HasDefaultValueSql("true");

                entity.Property(e => e.is_sso).HasDefaultValueSql("true");

                entity.Property(e => e.local_name).HasMaxLength(300);

                entity.Property(e => e.password_hash)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.pccuid).HasPrecision(20);

                entity.Property(e => e.sso_acct).HasMaxLength(50);

                entity.Property(e => e.updated_at).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.username).HasMaxLength(300);
            });

            modelBuilder.Entity<plm_cbd_head>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("plm_cbd_head", "asics_pdm");

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

                entity.Property(e => e.data_m_id)
                    .IsRequired()
                    .HasMaxLength(36);

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
                entity.HasNoKey();

                entity.ToTable("plm_cbd_item", "asics_pdm");

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

                entity.Property(e => e.data_d_id)
                    .IsRequired()
                    .HasMaxLength(36);

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
                entity.HasNoKey();

                entity.ToTable("plm_cbd_moldcharge", "asics_pdm");

                entity.Property(e => e.amortization)
                    .HasPrecision(10, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.charge)
                    .HasPrecision(11, 3)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.cost).HasPrecision(11, 3);

                entity.Property(e => e.data_d_id)
                    .IsRequired()
                    .HasMaxLength(36);

                entity.Property(e => e.data_m_id).HasMaxLength(36);

                entity.Property(e => e.id).HasMaxLength(10);

                entity.Property(e => e.item).HasMaxLength(200);

                entity.Property(e => e.price)
                    .HasPrecision(8, 2)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.qty).HasDefaultValueSql("0");

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

                entity.Property(e => e.account_code).HasMaxLength(30);

                entity.Property(e => e.account_exclusivity).HasMaxLength(30);

                entity.Property(e => e.account_name).HasMaxLength(100);

                entity.Property(e => e.active).HasMaxLength(10);

                entity.Property(e => e.add_date).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.article_description).HasMaxLength(100);

                entity.Property(e => e.assigned_agents).HasMaxLength(20);

                entity.Property(e => e.brand).HasMaxLength(20);

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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
