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
        public virtual DbSet<pdm_namevalue> pdm_namevalue { get; set; }
        public virtual DbSet<pdm_product_head> pdm_product_head { get; set; }
        public virtual DbSet<pdm_product_item> pdm_product_item { get; set; }
        public virtual DbSet<pdm_spec_head> pdm_spec_head { get; set; }
        public virtual DbSet<pdm_spec_head_factory> pdm_spec_head_factory { get; set; }
        public virtual DbSet<pdm_spec_item> pdm_spec_item { get; set; }
        public virtual DbSet<pdm_spec_item_factory> pdm_spec_item_factory { get; set; }
        public virtual DbSet<pdm_spec_standard> pdm_spec_standard { get; set; }

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

            modelBuilder.Entity<pdm_namevalue>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pdm_namevalue", "asics_pdm");

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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
