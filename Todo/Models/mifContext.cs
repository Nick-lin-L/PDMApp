using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Todo.Models
{
    public partial class mifContext : DbContext
    {
        public mifContext()
        {
        }

        public mifContext(DbContextOptions<mifContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AclGroup> AclGroups { get; set; }
        public virtual DbSet<AclGroupMgr> AclGroupMgrs { get; set; }
        public virtual DbSet<AclGroupPage> AclGroupPages { get; set; }
        public virtual DbSet<AclOpColumn> AclOpColumns { get; set; }
        public virtual DbSet<AclOpElement> AclOpElements { get; set; }
        public virtual DbSet<AclOpTable> AclOpTables { get; set; }
        public virtual DbSet<AclUserGroup> AclUserGroups { get; set; }
        public virtual DbSet<BaseSetting> BaseSettings { get; set; }
        public virtual DbSet<CbnsKindd> CbnsKindds { get; set; }
        public virtual DbSet<CbnsKindm> CbnsKindms { get; set; }
        public virtual DbSet<ColEname> ColEnames { get; set; }
        public virtual DbSet<DbList> DbLists { get; set; }
        public virtual DbSet<Dual> Duals { get; set; }
        public virtual DbSet<EppDevSeason> EppDevSeasons { get; set; }
        public virtual DbSet<ErrorCode> ErrorCodes { get; set; }
        public virtual DbSet<ErrorMsg> ErrorMsgs { get; set; }
        public virtual DbSet<ExportColSeeting> ExportColSeetings { get; set; }
        public virtual DbSet<ExportFileLog> ExportFileLogs { get; set; }
        public virtual DbSet<ExportFileSetting> ExportFileSettings { get; set; }
        public virtual DbSet<FileMaster> FileMasters { get; set; }
        public virtual DbSet<FileRevision> FileRevisions { get; set; }
        public virtual DbSet<FileSetting> FileSettings { get; set; }
        public virtual DbSet<G2fwUser> G2fwUsers { get; set; }
        public virtual DbSet<GlobalUser> GlobalUsers { get; set; }
        public virtual DbSet<HgProductCm> HgProductCms { get; set; }
        public virtual DbSet<HgZcYymmProductStock> HgZcYymmProductStocks { get; set; }
        public virtual DbSet<Ibpart> Ibparts { get; set; }
        public virtual DbSet<ImpMapD> ImpMapDs { get; set; }
        public virtual DbSet<ImpMapM> ImpMapMs { get; set; }
        public virtual DbSet<Initial0Amdum> Initial0Amda { get; set; }
        public virtual DbSet<Initial0Wip> Initial0Wips { get; set; }
        public virtual DbSet<Initial1Material> Initial1Materials { get; set; }
        public virtual DbSet<Initial2Amatch> Initial2Amatches { get; set; }
        public virtual DbSet<Initial3Product> Initial3Products { get; set; }
        public virtual DbSet<KanbanDefectQtyO> KanbanDefectQtyOs { get; set; }
        public virtual DbSet<KanbanDefectQtyPeriodO> KanbanDefectQtyPeriodOs { get; set; }
        public virtual DbSet<KanbanProdStatusOrg> KanbanProdStatusOrgs { get; set; }
        public virtual DbSet<KanbanProdorgSetup> KanbanProdorgSetups { get; set; }
        public virtual DbSet<KanbanProdqtyDaystatus> KanbanProdqtyDaystatuses { get; set; }
        public virtual DbSet<KanbanProdqtySetup> KanbanProdqtySetups { get; set; }
        public virtual DbSet<KanbanProdrateDaystatus> KanbanProdrateDaystatuses { get; set; }
        public virtual DbSet<LogDetail> LogDetails { get; set; }
        public virtual DbSet<LogMaster> LogMasters { get; set; }
        public virtual DbSet<LogRequestBody> LogRequestBodies { get; set; }
        public virtual DbSet<MdaMatCawn> MdaMatCawns { get; set; }
        public virtual DbSet<MdaMatMakt> MdaMatMakts { get; set; }
        public virtual DbSet<MdaMatMara> MdaMatMaras { get; set; }
        public virtual DbSet<MdaMatMarm> MdaMatMarms { get; set; }
        public virtual DbSet<MdaMzzlSfa> MdaMzzlSfas { get; set; }
        public virtual DbSet<MesIbordcnf> MesIbordcnfs { get; set; }
        public virtual DbSet<MesIbpart> MesIbparts { get; set; }
        public virtual DbSet<MesIbsalesorder> MesIbsalesorders { get; set; }
        public virtual DbSet<MesIbwork> MesIbworks { get; set; }
        public virtual DbSet<MesIbworkmaterial> MesIbworkmaterials { get; set; }
        public virtual DbSet<MesObbproduce> MesObbproduces { get; set; }
        public virtual DbSet<MesObsoleprod> MesObsoleprods { get; set; }
        public virtual DbSet<MesObzqmd> MesObzqmds { get; set; }
        public virtual DbSet<MesOutboundaopgroupctrl> MesOutboundaopgroupctrls { get; set; }
        public virtual DbSet<MesOutboundaqmd> MesOutboundaqmds { get; set; }
        public virtual DbSet<MesOutboundaqmdTest> MesOutboundaqmdTests { get; set; }
        public virtual DbSet<MesOutboundbproduce> MesOutboundbproduces { get; set; }
        public virtual DbSet<MesOutboundbqmd> MesOutboundbqmds { get; set; }
        public virtual DbSet<MesOutboundbwork> MesOutboundbworks { get; set; }
        public virtual DbSet<MesOutboundfqcsap> MesOutboundfqcsaps { get; set; }
        public virtual DbSet<MesOutboundshoeprod> MesOutboundshoeprods { get; set; }
        public virtual DbSet<MesOutboundsoleprod> MesOutboundsoleprods { get; set; }
        public virtual DbSet<MetaBl> MetaBls { get; set; }
        public virtual DbSet<MetaBl1> MetaBls1 { get; set; }
        public virtual DbSet<MetaBlBackup> MetaBlBackups { get; set; }
        public virtual DbSet<MetaExt> MetaExts { get; set; }
        public virtual DbSet<MetaExtfield> MetaExtfields { get; set; }
        public virtual DbSet<MetaField> MetaFields { get; set; }
        public virtual DbSet<MetaMdl> MetaMdls { get; set; }
        public virtual DbSet<MetaMdl1> MetaMdls1 { get; set; }
        public virtual DbSet<MetaMdlBackup> MetaMdlBackups { get; set; }
        public virtual DbSet<MetaMdlbl> MetaMdlbls { get; set; }
        public virtual DbSet<MetaMdlblParam> MetaMdlblParams { get; set; }
        public virtual DbSet<MetaMdlobj> MetaMdlobjs { get; set; }
        public virtual DbSet<MetaMdlobj1> MetaMdlobjs1 { get; set; }
        public virtual DbSet<MetaMdlobjBackup> MetaMdlobjBackups { get; set; }
        public virtual DbSet<MetaObj> MetaObjs { get; set; }
        public virtual DbSet<MetaObjbl> MetaObjbls { get; set; }
        public virtual DbSet<MetaObjbl1> MetaObjbls1 { get; set; }
        public virtual DbSet<MetaObjblBackup> MetaObjblBackups { get; set; }
        public virtual DbSet<MetaObjblParam> MetaObjblParams { get; set; }
        public virtual DbSet<MetaObjpool> MetaObjpools { get; set; }
        public virtual DbSet<MetaPoly> MetaPolies { get; set; }
        public virtual DbSet<MetaSql> MetaSqls { get; set; }
        public virtual DbSet<MifAllguide> MifAllguides { get; set; }
        public virtual DbSet<MifBrand> MifBrands { get; set; }
        public virtual DbSet<MifMesBwork> MifMesBworks { get; set; }
        public virtual DbSet<MifMesShoefqc> MifMesShoefqcs { get; set; }
        public virtual DbSet<MifMesShoeopgroup> MifMesShoeopgroups { get; set; }
        public virtual DbSet<MifMesShoeprod> MifMesShoeprods { get; set; }
        public virtual DbSet<MifMesShoeqm> MifMesShoeqms { get; set; }
        public virtual DbSet<MifMesSoleprod> MifMesSoleprods { get; set; }
        public virtual DbSet<MifMpsSche> MifMpsSches { get; set; }
        public virtual DbSet<MifObbqmd> MifObbqmds { get; set; }
        public virtual DbSet<MifObmpsSche> MifObmpsSches { get; set; }
        public virtual DbSet<MifObsapPartm> MifObsapPartms { get; set; }
        public virtual DbSet<MifObsapShippingd1> MifObsapShippingd1s { get; set; }
        public virtual DbSet<MifObsapShippingm1> MifObsapShippingm1s { get; set; }
        public virtual DbSet<MifObsapShippingslr> MifObsapShippingslrs { get; set; }
        public virtual DbSet<MifObsapWo> MifObsapWos { get; set; }
        public virtual DbSet<MifObsapWoComp> MifObsapWoComps { get; set; }
        public virtual DbSet<MifSapPartm> MifSapPartms { get; set; }
        public virtual DbSet<MifSapSo> MifSapSos { get; set; }
        public virtual DbSet<MifSapSoCnf> MifSapSoCnfs { get; set; }
        public virtual DbSet<MifSapWo> MifSapWos { get; set; }
        public virtual DbSet<MifSapZrpp0009n> MifSapZrpp0009ns { get; set; }
        public virtual DbSet<MifShippingKind> MifShippingKinds { get; set; }
        public virtual DbSet<MifShippingKindDatum> MifShippingKindData { get; set; }
        public virtual DbSet<MifShippingd1> MifShippingd1s { get; set; }
        public virtual DbSet<MifShippingd12> MifShippingd12s { get; set; }
        public virtual DbSet<MifShippingm1> MifShippingm1s { get; set; }
        public virtual DbSet<MifShippingm12> MifShippingm12s { get; set; }
        public virtual DbSet<MifShippingslr> MifShippingslrs { get; set; }
        public virtual DbSet<MifShoePlanqty> MifShoePlanqties { get; set; }
        public virtual DbSet<MifSoleQcOther> MifSoleQcOthers { get; set; }
        public virtual DbSet<MifSysAuthority> MifSysAuthoritys { get; set; }
        public virtual DbSet<MifSysSlistcol> MifSysSlistcols { get; set; }
        public virtual DbSet<MifTimeProd> MifTimeProds { get; set; }
        public virtual DbSet<MifToslog> MifToslogs { get; set; }
        public virtual DbSet<MifWorkSfaBom> MifWorkSfaBoms { get; set; }
        public virtual DbSet<Money> Money { get; set; }
        public virtual DbSet<Money1> Money1s { get; set; }
        public virtual DbSet<Money2> Money2s { get; set; }
        public virtual DbSet<MsgAttachment> MsgAttachments { get; set; }
        public virtual DbSet<MsgMessenger> MsgMessengers { get; set; }
        public virtual DbSet<MsgRecipient> MsgRecipients { get; set; }
        public virtual DbSet<MsgSent> MsgSents { get; set; }
        public virtual DbSet<MsgSentRecipient> MsgSentRecipients { get; set; }
        public virtual DbSet<MsgSetAlias> MsgSetAliases { get; set; }
        public virtual DbSet<MsgSetAliasDetail> MsgSetAliasDetails { get; set; }
        public virtual DbSet<MsgSetServer> MsgSetServers { get; set; }
        public virtual DbSet<MsgTarget> MsgTargets { get; set; }
        public virtual DbSet<MultiLang> MultiLangs { get; set; }
        public virtual DbSet<PageMenu> PageMenus { get; set; }
        public virtual DbSet<PageOpColumn> PageOpColumns { get; set; }
        public virtual DbSet<PageOpElement> PageOpElements { get; set; }
        public virtual DbSet<PageOpResource> PageOpResources { get; set; }
        public virtual DbSet<PageOpTable> PageOpTables { get; set; }
        public virtual DbSet<PageUri> PageUris { get; set; }
        public virtual DbSet<Pbcatcol> Pbcatcols { get; set; }
        public virtual DbSet<Pbcatedt> Pbcatedts { get; set; }
        public virtual DbSet<Pbcatfmt> Pbcatfmts { get; set; }
        public virtual DbSet<Pbcattbl> Pbcattbls { get; set; }
        public virtual DbSet<Pbcatvld> Pbcatvlds { get; set; }
        public virtual DbSet<PcagKanbanShoeFact> PcagKanbanShoeFacts { get; set; }
        public virtual DbSet<PcagKanbanShoeProdSum> PcagKanbanShoeProdSums { get; set; }
        public virtual DbSet<PelletspkListSfa> PelletspkListSfas { get; set; }
        public virtual DbSet<QcReason> QcReasons { get; set; }
        public virtual DbSet<ScCatCtrl> ScCatCtrls { get; set; }
        public virtual DbSet<ScCodeLast> ScCodeLasts { get; set; }
        public virtual DbSet<ScCodeRecycling> ScCodeRecyclings { get; set; }
        public virtual DbSet<ScPlan> ScPlans { get; set; }
        public virtual DbSet<ScPlanPart> ScPlanParts { get; set; }
        public virtual DbSet<ScSetting> ScSettings { get; set; }
        public virtual DbSet<SchedConflictJob> SchedConflictJobs { get; set; }
        public virtual DbSet<SchedConflictQueue> SchedConflictQueues { get; set; }
        public virtual DbSet<SchedLog> SchedLogs { get; set; }
        public virtual DbSet<SchedParam> SchedParams { get; set; }
        public virtual DbSet<SchedSettingD> SchedSettingDs { get; set; }
        public virtual DbSet<SchedSettingM> SchedSettingMs { get; set; }
        public virtual DbSet<SchedStateD> SchedStateDs { get; set; }
        public virtual DbSet<SchedStateM> SchedStateMs { get; set; }
        public virtual DbSet<SfaProcess> SfaProcesses { get; set; }
        public virtual DbSet<Soleprod> Soleprods { get; set; }
        public virtual DbSet<Srd> Srds { get; set; }
        public virtual DbSet<StockPrintSizeSfa> StockPrintSizeSfas { get; set; }
        public virtual DbSet<StockYymmReport> StockYymmReports { get; set; }
        public virtual DbSet<TalendJob> TalendJobs { get; set; }
        public virtual DbSet<Tempdatum> Tempdata { get; set; }
        public virtual DbSet<TestOdrd> TestOdrds { get; set; }
        public virtual DbSet<TestOdrm> TestOdrms { get; set; }
        public virtual DbSet<TestWorkm> TestWorkms { get; set; }
        public virtual DbSet<TestXml> TestXmls { get; set; }
        public virtual DbSet<TplDesign> TplDesigns { get; set; }
        public virtual DbSet<TplMaster> TplMasters { get; set; }
        public virtual DbSet<TplSampleDatum> TplSampleData { get; set; }
        public virtual DbSet<TplSubType> TplSubTypes { get; set; }
        public virtual DbSet<VAclOpColumnByGroup> VAclOpColumnByGroups { get; set; }
        public virtual DbSet<VAclOpElementByGroup> VAclOpElementByGroups { get; set; }
        public virtual DbSet<VAclOpTableByGroup> VAclOpTableByGroups { get; set; }
        public virtual DbSet<VDay> VDays { get; set; }
        public virtual DbSet<VG2fwUser> VG2fwUsers { get; set; }
        public virtual DbSet<VcolEname> VcolEnames { get; set; }
        public virtual DbSet<Version> Versions { get; set; }
        public virtual DbSet<VersionImportLog> VersionImportLogs { get; set; }
        public virtual DbSet<VersionRemoveItem> VersionRemoveItems { get; set; }
        public virtual DbSet<VersionScript> VersionScripts { get; set; }
        public virtual DbSet<VersionScriptDetail> VersionScriptDetails { get; set; }
        public virtual DbSet<VersionTable> VersionTables { get; set; }
        public virtual DbSet<ViewOdrSumQss2> ViewOdrSumQss2s { get; set; }
        public virtual DbSet<WoTest> WoTests { get; set; }
        public virtual DbSet<Workm> Workms { get; set; }
        public virtual DbSet<Xmldatum> Xmldata { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp")
                .HasAnnotation("Relational:Collation", "en_US.UTF-8");

            modelBuilder.Entity<AclGroup>(entity =>
            {
                entity.HasKey(e => e.GroupId)
                    .HasName("acl_group_pk");

                entity.ToTable("acl_group", "fw_mif");

                entity.HasComment("公司組織");

                entity.HasIndex(e => e.GroupIda, "acl_group_idx");

                entity.HasIndex(e => new { e.GroupPid, e.GroupNo }, "acl_group_ui")
                    .IsUnique();

                entity.HasIndex(e => new { e.ApName, e.GroupNo }, "acl_group_uk1")
                    .IsUnique();

                entity.Property(e => e.GroupId)
                    .HasMaxLength(22)
                    .HasColumnName("group_id")
                    .HasComment("群組ID");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name");

                entity.Property(e => e.ConnAlias)
                    .HasMaxLength(20)
                    .HasColumnName("conn_alias")
                    .HasComment("連線別名");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("create_user")
                    .HasComment("建立人ID");

                entity.Property(e => e.GroupEnd)
                    .HasMaxLength(1)
                    .HasColumnName("group_end")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("最末級");

                entity.Property(e => e.GroupIda)
                    .HasMaxLength(120)
                    .HasColumnName("group_ida")
                    .HasComment("累積ID");

                entity.Property(e => e.GroupLvl)
                    .HasPrecision(2)
                    .HasColumnName("group_lvl")
                    .HasComment("層級");

                entity.Property(e => e.GroupMemo)
                    .HasMaxLength(100)
                    .HasColumnName("group_memo")
                    .HasComment("備註");

                entity.Property(e => e.GroupNm)
                    .HasMaxLength(20)
                    .HasColumnName("group_nm")
                    .HasComment("群組名稱");

                entity.Property(e => e.GroupNma)
                    .HasMaxLength(250)
                    .HasColumnName("group_nma")
                    .HasComment("累積名稱");

                entity.Property(e => e.GroupNo)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("group_no")
                    .HasComment("群組代號");

                entity.Property(e => e.GroupNoa)
                    .HasMaxLength(200)
                    .HasColumnName("group_noa")
                    .HasComment("累積碼");

                entity.Property(e => e.GroupNtyp)
                    .HasMaxLength(10)
                    .HasColumnName("group_ntyp")
                    .HasComment("節點類型");

                entity.Property(e => e.GroupOwner)
                    .HasMaxLength(22)
                    .HasColumnName("group_owner")
                    .HasComment("建立者");

                entity.Property(e => e.GroupPid)
                    .HasMaxLength(22)
                    .HasColumnName("group_pid")
                    .HasComment("父節點ID");

                entity.Property(e => e.GroupStat)
                    .HasMaxLength(1)
                    .HasColumnName("group_stat")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("狀態");

                entity.Property(e => e.GroupTyp)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("group_typ")
                    .HasDefaultValueSql("'G'::character varying")
                    .HasComment("角色類型 (S:超級管理員; A:系統管理員; R:角色管理員; G:一般角色; U:超級使用者)");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasComment("異動人ID");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.AclGroups)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("acl_group_fk2");
            });

            modelBuilder.Entity<AclGroupMgr>(entity =>
            {
                entity.ToTable("acl_group_mgr", "fw_mif");

                entity.HasIndex(e => new { e.UserId, e.GroupId }, "acl_group_mgr_uk1")
                    .IsUnique();

                entity.Property(e => e.AclGroupMgrId)
                    .HasMaxLength(22)
                    .HasColumnName("acl_group_mgr_id")
                    .HasComment("PK");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("create_user")
                    .HasComment("建立人ID");

                entity.Property(e => e.GroupId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("group_id")
                    .HasComment("群組ID");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasComment("異動人ID");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("user_id")
                    .HasComment("用戶ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AclGroupMgrs)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("acl_group_mgr_fk1");
            });

            modelBuilder.Entity<AclGroupPage>(entity =>
            {
                entity.HasKey(e => e.GroupPageId)
                    .HasName("acl_group_page_pk");

                entity.ToTable("acl_group_page", "fw_mif");

                entity.HasComment("組織授權");

                entity.HasIndex(e => new { e.GroupId, e.PageMenuId }, "acl_group_page_uk1")
                    .IsUnique();

                entity.Property(e => e.GroupPageId)
                    .HasMaxLength(22)
                    .HasColumnName("group_page_id")
                    .HasComment("群組授權ID");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name");

                entity.Property(e => e.GroupId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("group_id")
                    .HasComment("群組ID");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.PageMenuId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("page_menu_id")
                    .HasComment("系統選單ID");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasComment("異動人ID");
            });

            modelBuilder.Entity<AclOpColumn>(entity =>
            {
                entity.HasKey(e => e.AclColId)
                    .HasName("acl_op_column_pk");

                entity.ToTable("acl_op_column", "fw_mif");

                entity.HasIndex(e => new { e.GroupPageId, e.PageColId }, "acl_op_column_uk1")
                    .IsUnique();

                entity.Property(e => e.AclColId)
                    .HasMaxLength(22)
                    .HasColumnName("acl_col_id")
                    .HasComment("角色欄位權限ID");

                entity.Property(e => e.AclColOp)
                    .HasPrecision(1)
                    .HasColumnName("acl_col_op")
                    .HasDefaultValueSql("2")
                    .HasComment("操作");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name");

                entity.Property(e => e.GroupPageId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("group_page_id")
                    .HasComment("群組授權ID");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.PageColId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("page_col_id")
                    .HasComment("頁面權限欄位ID");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasComment("異動人ID");
            });

            modelBuilder.Entity<AclOpElement>(entity =>
            {
                entity.HasKey(e => e.AclEleId)
                    .HasName("acl_op_element_pk");

                entity.ToTable("acl_op_element", "fw_mif");

                entity.HasIndex(e => new { e.GroupPageId, e.PageEleId }, "acl_op_element_uk1")
                    .IsUnique();

                entity.Property(e => e.AclEleId)
                    .HasMaxLength(22)
                    .HasColumnName("acl_ele_id")
                    .HasComment("角色元素(按鈕)權限ID");

                entity.Property(e => e.AclEleOp)
                    .HasPrecision(1)
                    .HasColumnName("acl_ele_op")
                    .HasComment("操作");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name");

                entity.Property(e => e.GroupPageId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("group_page_id")
                    .HasComment("群組授權ID");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.PageEleId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("page_ele_id")
                    .HasComment("頁面權限元素 ID");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasComment("異動人ID");
            });

            modelBuilder.Entity<AclOpTable>(entity =>
            {
                entity.HasKey(e => e.AclTblId)
                    .HasName("acl_op_table_pk");

                entity.ToTable("acl_op_table", "fw_mif");

                entity.HasIndex(e => new { e.GroupPageId, e.PageTblId }, "acl_op_table_uk1")
                    .IsUnique();

                entity.Property(e => e.AclTblId)
                    .HasMaxLength(22)
                    .HasColumnName("acl_tbl_id")
                    .HasComment("角色對表權限ID");

                entity.Property(e => e.AclTblA)
                    .HasMaxLength(1)
                    .HasColumnName("acl_tbl_a")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("新增");

                entity.Property(e => e.AclTblD)
                    .HasMaxLength(1)
                    .HasColumnName("acl_tbl_d")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("删除");

                entity.Property(e => e.AclTblM)
                    .HasMaxLength(1)
                    .HasColumnName("acl_tbl_m")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("修改");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name");

                entity.Property(e => e.GroupPageId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("group_page_id")
                    .HasComment("群組授權ID");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.PageTblId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("page_tbl_id")
                    .HasComment("頁面權限表 ID");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasComment("異動人ID");
            });

            modelBuilder.Entity<AclUserGroup>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.GroupId })
                    .HasName("acl_user_group_pk");

                entity.ToTable("acl_user_group", "fw_mif");

                entity.HasComment("用戶組織");

                entity.Property(e => e.UserId)
                    .HasMaxLength(22)
                    .HasColumnName("user_id")
                    .HasComment("用戶ID");

                entity.Property(e => e.GroupId)
                    .HasMaxLength(22)
                    .HasColumnName("group_id")
                    .HasComment("群組ID");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasComment("異動人ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AclUserGroups)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_group_fk_users");
            });

            modelBuilder.Entity<BaseSetting>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("base_settings", "fw_mif");

                entity.HasIndex(e => e.BaseSettingsId, "idx_base_settings")
                    .IsUnique();

                entity.Property(e => e.AdvSetUrl)
                    .HasMaxLength(500)
                    .HasColumnName("adv_set_url")
                    .HasDefaultValueSql("'null'::character varying");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name");

                entity.Property(e => e.BaseSettingsId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("base_settings_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("description");

                entity.Property(e => e.Editable)
                    .HasMaxLength(1)
                    .HasColumnName("editable")
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.Editor)
                    .HasMaxLength(20)
                    .HasColumnName("editor")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.ModuleType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("module_type");

                entity.Property(e => e.ParamKey)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("param_key");

                entity.Property(e => e.ParamValue)
                    .HasMaxLength(4000)
                    .HasColumnName("param_value")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.Sort)
                    .HasPrecision(11)
                    .HasColumnName("sort");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasDefaultValueSql("'NULL'::character varying")
                    .HasComment("異動人ID");

                entity.Property(e => e.ValueDescription)
                    .HasMaxLength(200)
                    .HasColumnName("value_description")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.ValueList)
                    .HasMaxLength(200)
                    .HasColumnName("value_list")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.ValueType)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("value_type");
            });

            modelBuilder.Entity<CbnsKindd>(entity =>
            {
                entity.HasKey(e => new { e.FactNo, e.KindNo, e.KindType })
                    .HasName("cbns_kindd_pk");

                entity.ToTable("cbns_kindd", "ap_mif");

                entity.Property(e => e.FactNo)
                    .HasMaxLength(4)
                    .HasColumnName("fact_no");

                entity.Property(e => e.KindNo)
                    .HasMaxLength(2)
                    .HasColumnName("kind_no");

                entity.Property(e => e.KindType)
                    .HasMaxLength(20)
                    .HasColumnName("kind_type");

                entity.Property(e => e.CreateName).HasColumnName("create_name");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DefaMk)
                    .HasMaxLength(1)
                    .HasColumnName("defa_mk");

                entity.Property(e => e.KindCode)
                    .HasMaxLength(10)
                    .HasColumnName("kind_code");

                entity.Property(e => e.KindTypeDesc)
                    .HasMaxLength(100)
                    .HasColumnName("kind_type_desc");

                entity.Property(e => e.ModifyName).HasColumnName("modify_name");

                entity.Property(e => e.ModifyTime)
                    .HasColumnName("modify_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<CbnsKindm>(entity =>
            {
                entity.HasKey(e => new { e.FactNo, e.KindNo })
                    .HasName("cbns_kindm_pk");

                entity.ToTable("cbns_kindm", "ap_mif");

                entity.Property(e => e.FactNo)
                    .HasMaxLength(4)
                    .HasColumnName("fact_no");

                entity.Property(e => e.KindNo)
                    .HasMaxLength(2)
                    .HasColumnName("kind_no");

                entity.Property(e => e.CreateName).HasColumnName("create_name");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.KindCnm)
                    .HasMaxLength(50)
                    .HasColumnName("kind_cnm");

                entity.Property(e => e.KindEnm)
                    .HasMaxLength(50)
                    .HasColumnName("kind_enm");

                entity.Property(e => e.ModifyName).HasColumnName("modify_name");

                entity.Property(e => e.ModifyTime)
                    .HasColumnName("modify_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.StartMk)
                    .HasMaxLength(1)
                    .HasColumnName("start_mk");
            });

            modelBuilder.Entity<ColEname>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("col_ename", "ap_mif");

                entity.Property(e => e.ColEname1)
                    .HasMaxLength(60)
                    .HasColumnName("col_ename");
            });

            modelBuilder.Entity<DbList>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("db_list", "ap_mif");

                entity.Property(e => e.Cnname)
                    .HasMaxLength(100)
                    .HasColumnName("cnname")
                    .HasComment("中文名稱");

                entity.Property(e => e.DatabaseSid)
                    .HasMaxLength(50)
                    .HasColumnName("database_sid")
                    .HasComment("database 或叫 sid");

                entity.Property(e => e.DbHost)
                    .HasMaxLength(100)
                    .HasColumnName("db_host")
                    .HasComment("Host");

                entity.Property(e => e.DbMarktype)
                    .HasMaxLength(100)
                    .HasColumnName("db_marktype")
                    .HasComment("MIFDB or MESRDB or SAPDB等等的");

                entity.Property(e => e.DbPort)
                    .HasMaxLength(10)
                    .HasColumnName("db_port")
                    .HasComment("Port");

                entity.Property(e => e.FactoryNo)
                    .HasMaxLength(50)
                    .HasColumnName("factory_no")
                    .HasComment("廠別代號");

                entity.Property(e => e.Fqdn)
                    .HasMaxLength(100)
                    .HasColumnName("fqdn")
                    .HasComment("完整網域名稱");

                entity.Property(e => e.Passwd)
                    .HasMaxLength(50)
                    .HasColumnName("passwd")
                    .HasComment("密碼");

                entity.Property(e => e.Region)
                    .HasMaxLength(30)
                    .HasColumnName("region")
                    .HasComment("區域");

                entity.Property(e => e.Remark)
                    .HasMaxLength(200)
                    .HasColumnName("remark")
                    .HasComment("備註");

                entity.Property(e => e.ServerType)
                    .HasMaxLength(10)
                    .HasColumnName("server_type")
                    .HasComment("正式區or測試區");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username")
                    .HasComment("帳號");
            });

            modelBuilder.Entity<Dual>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dual", "ap_mif");

                entity.Property(e => e.Column1)
                    .HasMaxLength(1)
                    .HasColumnName("column1");
            });

            modelBuilder.Entity<EppDevSeason>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("epp_dev_season", "ap_mif");

                entity.Property(e => e.BrandNo)
                    .HasMaxLength(4)
                    .HasColumnName("brand_no");

                entity.Property(e => e.FactNo)
                    .HasMaxLength(4)
                    .HasColumnName("fact_no");

                entity.Property(e => e.ModifyTime)
                    .HasMaxLength(14)
                    .HasColumnName("modify_time");

                entity.Property(e => e.ModifyUser)
                    .HasMaxLength(60)
                    .HasColumnName("modify_user");

                entity.Property(e => e.SeasonId)
                    .HasMaxLength(6)
                    .HasColumnName("season_id");

                entity.Property(e => e.SeasonNo)
                    .HasMaxLength(10)
                    .HasColumnName("season_no");

                entity.Property(e => e.SortNo).HasColumnName("sort_no");

                entity.Property(e => e.TransDate)
                    .HasMaxLength(14)
                    .HasColumnName("trans_date");

                entity.Property(e => e.TransMk)
                    .HasMaxLength(1)
                    .HasColumnName("trans_mk");
            });

            modelBuilder.Entity<ErrorCode>(entity =>
            {
                entity.ToTable("error_code", "fw_mif");

                entity.Property(e => e.ErrorCodeId)
                    .HasMaxLength(22)
                    .HasColumnName("error_code_id");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("code");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.ModuleType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("module_type");

                entity.Property(e => e.Msg)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("msg");

                entity.Property(e => e.Solution).HasColumnName("solution");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasDefaultValueSql("'NULL'::character varying")
                    .HasComment("異動人ID");
            });

            modelBuilder.Entity<ErrorMsg>(entity =>
            {
                entity.ToTable("error_msg", "fw_mif");

                entity.HasIndex(e => e.ErrorCodeId, "ind_error_code_id");

                entity.Property(e => e.ErrorMsgId)
                    .HasMaxLength(22)
                    .HasColumnName("error_msg_id");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("code");

                entity.Property(e => e.ErrorCodeId)
                    .HasMaxLength(22)
                    .HasColumnName("error_code_id")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.Locale)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("locale");

                entity.Property(e => e.Msg)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("msg");

                entity.Property(e => e.Solution).HasColumnName("solution");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasDefaultValueSql("'NULL'::character varying")
                    .HasComment("異動人ID");

                entity.HasOne(d => d.ErrorCode)
                    .WithMany(p => p.ErrorMsgs)
                    .HasForeignKey(d => d.ErrorCodeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("error_msg_fk_error_code");
            });

            modelBuilder.Entity<ExportColSeeting>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("export_col_seeting", "ap_mif");

                entity.Property(e => e.Code)
                    .HasMaxLength(20)
                    .HasColumnName("code");

                entity.Property(e => e.ColName)
                    .HasMaxLength(50)
                    .HasColumnName("col_name");
            });

            modelBuilder.Entity<ExportFileLog>(entity =>
            {
                entity.HasKey(e => new { e.Pccuid, e.FileName })
                    .HasName("exprot_file_log_pk");

                entity.ToTable("export_file_log", "ap_mif");

                entity.Property(e => e.Pccuid)
                    .HasColumnType("character varying")
                    .HasColumnName("pccuid");

                entity.Property(e => e.FileName)
                    .HasMaxLength(100)
                    .HasColumnName("file_name");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ExportMk)
                    .HasMaxLength(1)
                    .HasColumnName("export_mk")
                    .HasDefaultValueSql("'Y'::character varying");

                entity.Property(e => e.UpdateTime).HasColumnName("update_time");

                entity.Property(e => e.Uuid)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("uuid");
            });

            modelBuilder.Entity<ExportFileSetting>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("export_file_setting", "ap_mif");

                entity.Property(e => e.Col1)
                    .HasMaxLength(30)
                    .HasColumnName("col_1");

                entity.Property(e => e.Col2)
                    .HasMaxLength(30)
                    .HasColumnName("col_2");

                entity.Property(e => e.Col3)
                    .HasMaxLength(30)
                    .HasColumnName("col_3");

                entity.Property(e => e.Col4)
                    .HasMaxLength(30)
                    .HasColumnName("col_4");

                entity.Property(e => e.Col5)
                    .HasMaxLength(30)
                    .HasColumnName("col_5");

                entity.Property(e => e.Col6)
                    .HasMaxLength(30)
                    .HasColumnName("col_6");

                entity.Property(e => e.Col7)
                    .HasMaxLength(30)
                    .HasColumnName("col_7");

                entity.Property(e => e.Col8)
                    .HasMaxLength(30)
                    .HasColumnName("col_8");

                entity.Property(e => e.UserName).HasColumnName("user_name");
            });

            modelBuilder.Entity<FileMaster>(entity =>
            {
                entity.HasKey(e => e.MGuid)
                    .HasName("file_master_pk");

                entity.ToTable("file_master", "fw_mif");

                entity.Property(e => e.MGuid)
                    .HasMaxLength(22)
                    .HasColumnName("m_guid");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name");

                entity.Property(e => e.DeleteTime)
                    .HasPrecision(19)
                    .HasColumnName("delete_time")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.DeleteUser)
                    .HasMaxLength(22)
                    .HasColumnName("delete_user")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("file_name");

                entity.Property(e => e.FileSize)
                    .HasPrecision(11)
                    .HasColumnName("file_size");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.RevGuid)
                    .HasMaxLength(22)
                    .HasColumnName("rev_guid")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasDefaultValueSql("'NULL'::character varying")
                    .HasComment("異動人ID");

                entity.Property(e => e.Version)
                    .HasPrecision(11)
                    .HasColumnName("version");
            });

            modelBuilder.Entity<FileRevision>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("file_revision", "fw_mif");

                entity.HasIndex(e => e.RevGuid, "idx_file_revision")
                    .IsUnique();

                entity.HasIndex(e => e.MGuid, "idx_file_revision1");

                entity.Property(e => e.ApPath)
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasColumnName("ap_path");

                entity.Property(e => e.CreateTime)
                    .HasPrecision(19)
                    .HasColumnName("create_time")
                    .HasComment("建立時間");

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(22)
                    .HasColumnName("create_user")
                    .HasDefaultValueSql("'null'::character varying")
                    .HasComment("建立人ID");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("file_name");

                entity.Property(e => e.FileSize)
                    .HasPrecision(11)
                    .HasColumnName("file_size");

                entity.Property(e => e.FileStorePath)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("file_store_path");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.IsZiped)
                    .HasMaxLength(1)
                    .HasColumnName("is_ziped")
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.MGuid)
                    .HasMaxLength(22)
                    .HasColumnName("m_guid")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.RevGuid)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("rev_guid");

                entity.Property(e => e.RootPath)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("root_path");

                entity.Property(e => e.Version)
                    .HasPrecision(11)
                    .HasColumnName("version");
            });

            modelBuilder.Entity<FileSetting>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("file_setting", "fw_mif");

                entity.HasIndex(e => e.FileSettingId, "indx_file_setting")
                    .IsUnique();

                entity.Property(e => e.AliasName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("alias_name");

                entity.Property(e => e.AllowTypes)
                    .HasMaxLength(255)
                    .HasColumnName("allow_types")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name");

                entity.Property(e => e.FileSettingId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("file_setting_id");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.MaxFileSize)
                    .HasPrecision(11)
                    .HasColumnName("max_file_size");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasDefaultValueSql("'NULL'::character varying")
                    .HasComment("異動人ID");
            });

            modelBuilder.Entity<G2fwUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("users_pk");

                entity.ToTable("g2fw_user", "fw_mif");

                entity.HasComment("系統用戶");

                entity.HasIndex(e => e.UserPccuid, "g2fw_user_index1");

                entity.Property(e => e.UserId)
                    .HasMaxLength(22)
                    .HasColumnName("user_id")
                    .HasComment("用戶ID");

                entity.Property(e => e.ImAcct)
                    .HasMaxLength(40)
                    .HasColumnName("im_acct")
                    .HasComment("IM帳號");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasComment("異動人ID");

                entity.Property(e => e.UserDisable)
                    .HasMaxLength(1)
                    .HasColumnName("user_disable")
                    .HasDefaultValueSql("'N'::character varying")
                    .HasComment("停用註記");

                entity.Property(e => e.UserLang)
                    .HasMaxLength(10)
                    .HasColumnName("user_lang")
                    .HasComment("登入語系");

                entity.Property(e => e.UserPccuid)
                    .HasPrecision(14)
                    .HasColumnName("user_pccuid")
                    .HasDefaultValueSql("NULL::numeric")
                    .HasComment("人事ID");

                entity.Property(e => e.UserTimezone)
                    .HasMaxLength(6)
                    .HasColumnName("user_timezone")
                    .HasComment("時區");
            });

            modelBuilder.Entity<GlobalUser>(entity =>
            {
                entity.HasKey(e => e.Pccuid)
                    .HasName("global_users_pkey");

                entity.ToTable("global_users", "global_sync");

                entity.Property(e => e.Pccuid)
                    .HasPrecision(20)
                    .HasColumnName("pccuid");

                entity.Property(e => e.ChineseNm)
                    .HasMaxLength(300)
                    .HasColumnName("chinese_nm");

                entity.Property(e => e.ContactMail)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("contact_mail");

                entity.Property(e => e.Disabled)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("disabled");

                entity.Property(e => e.DisabledDate).HasColumnName("disabled_date");

                entity.Property(e => e.EnglishNm)
                    .HasMaxLength(200)
                    .HasColumnName("english_nm");

                entity.Property(e => e.FactNo)
                    .HasMaxLength(10)
                    .HasColumnName("fact_no");

                entity.Property(e => e.Id)
                    .HasPrecision(20)
                    .HasColumnName("id");

                entity.Property(e => e.LeaveMk)
                    .HasMaxLength(20)
                    .HasColumnName("leave_mk");

                entity.Property(e => e.LoDeptNm)
                    .HasMaxLength(60)
                    .HasColumnName("lo_dept_nm");

                entity.Property(e => e.LoPosiNm)
                    .HasMaxLength(60)
                    .HasColumnName("lo_posi_nm");

                entity.Property(e => e.LocalFactNo)
                    .HasMaxLength(10)
                    .HasColumnName("local_fact_no");

                entity.Property(e => e.LocalPnlNm)
                    .HasMaxLength(300)
                    .HasColumnName("local_pnl_nm");

                entity.Property(e => e.Sex)
                    .HasMaxLength(1)
                    .HasColumnName("sex");

                entity.Property(e => e.SsoAcct)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("sso_acct");

                entity.Property(e => e.Tel)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("tel");

                entity.Property(e => e.UpdateDate).HasColumnName("update_date");
            });

            modelBuilder.Entity<HgProductCm>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hg_product_cm", "ap_mif");

                entity.Property(e => e.ColorNo)
                    .HasMaxLength(10)
                    .HasColumnName("color_no");

                entity.Property(e => e.DateStart)
                    .HasMaxLength(8)
                    .HasColumnName("date_start");

                entity.Property(e => e.DemoNo)
                    .HasMaxLength(20)
                    .HasColumnName("demo_no");

                entity.Property(e => e.FactNo)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("fact_no");

                entity.Property(e => e.ProcessNo)
                    .HasMaxLength(10)
                    .HasColumnName("process_no");
            });

            modelBuilder.Entity<HgZcYymmProductStock>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hg_zc_yymm_product_stock", "ap_mif");

                entity.Property(e => e.ColorNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("color_no");

                entity.Property(e => e.CreateDate)
                    .HasMaxLength(8)
                    .HasColumnName("create_date");

                entity.Property(e => e.FactNo)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("fact_no");

                entity.Property(e => e.FirstStock)
                    .HasMaxLength(10)
                    .HasColumnName("first_stock");

                entity.Property(e => e.InStock)
                    .HasMaxLength(10)
                    .HasColumnName("in_stock");

                entity.Property(e => e.LastStock)
                    .HasMaxLength(10)
                    .HasColumnName("last_stock");

                entity.Property(e => e.OutStock)
                    .HasMaxLength(10)
                    .HasColumnName("out_stock");

                entity.Property(e => e.PartNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("part_no");

                entity.Property(e => e.ProductNo)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("product_no");

                entity.Property(e => e.ProductType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("product_type");

                entity.Property(e => e.SizeNo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("size_no");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("user_name");

                entity.Property(e => e.WorkType)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("work_type");
            });

            modelBuilder.Entity<Ibpart>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ibpart", "ap_mif");

                entity.Property(e => e.BrandId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("brand_id")
                    .HasComment("品牌");

                entity.Property(e => e.Client)
                    .HasMaxLength(20)
                    .HasColumnName("client")
                    .HasComment("SAP Outbound Client");

                entity.Property(e => e.Component)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("component")
                    .HasComment("部位代號");

                entity.Property(e => e.CreateTime)
                    .HasMaxLength(20)
                    .HasColumnName("create_time")
                    .HasComment("寫入RDB的時間，到秒，同一次執行的同一批資料都寫一樣");

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(100)
                    .HasColumnName("create_user")
                    .HasComment("寫入RDB的人員，由TOS JOB寫入，則寫JOB NAME");

                entity.Property(e => e.DataBatchKey)
                    .HasMaxLength(300)
                    .HasColumnName("data_batch_key")
                    .HasComment("資料組");

                entity.Property(e => e.Dataid)
                    .HasColumnName("dataid")
                    .HasDefaultValueSql("nextval('ibpart_dataid_seq'::regclass)")
                    .HasComment("數字序號");

                entity.Property(e => e.Deactive)
                    .HasMaxLength(1)
                    .HasColumnName("deactive")
                    .HasComment("失效註記");

                entity.Property(e => e.FileName)
                    .HasMaxLength(50)
                    .HasColumnName("file_name")
                    .HasComment("SAP Outbound檔案名稱");

                entity.Property(e => e.MesSyncId)
                    .HasMaxLength(300)
                    .HasColumnName("mes_sync_id")
                    .HasComment("RDB到MES的ID");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(50)
                    .HasColumnName("name_en")
                    .HasComment("部位名稱(英文)");

                entity.Property(e => e.NameZf)
                    .HasMaxLength(50)
                    .HasColumnName("name_zf")
                    .HasComment("部位名稱(中文)");

                entity.Property(e => e.ProcessErrmsg)
                    .HasMaxLength(300)
                    .HasColumnName("process_errmsg")
                    .HasComment("同步MES失敗原因，失敗才有值");

                entity.Property(e => e.ProcessMk)
                    .HasMaxLength(1)
                    .HasColumnName("process_mk")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("同步MES的註記");

                entity.Property(e => e.ProcessTime)
                    .HasMaxLength(20)
                    .HasColumnName("process_time")
                    .HasComment("同步到MES的時間，到秒");

                entity.Property(e => e.ProcessUser)
                    .HasMaxLength(100)
                    .HasColumnName("process_user")
                    .HasComment("同步MES的TOS JOB NAME");

                entity.Property(e => e.SapOutboundTime)
                    .HasMaxLength(20)
                    .HasColumnName("sap_outbound_time")
                    .HasComment("SAP Outbound時間");

                entity.Property(e => e.Timestamp)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("timestamp")
                    .HasComment("時間註記");

                entity.Property(e => e.TransId)
                    .HasMaxLength(50)
                    .HasColumnName("trans_id")
                    .HasComment("資料交換ID");
            });

            modelBuilder.Entity<ImpMapD>(entity =>
            {
                entity.ToTable("imp_map_d", "fw_mif");

                entity.Property(e => e.ImpMapDId)
                    .HasMaxLength(22)
                    .HasColumnName("imp_map_d_id")
                    .HasDefaultValueSql("''::character varying")
                    .HasComment("資料匯入設定明細檔ID");

                entity.Property(e => e.ImpIdx)
                    .HasPrecision(2)
                    .HasColumnName("imp_idx")
                    .HasComment("欄位索引");

                entity.Property(e => e.ImpMapMId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("imp_map_m_id")
                    .HasDefaultValueSql("''::character varying")
                    .HasComment("資料匯入設定主檔ID");

                entity.Property(e => e.ImpRule)
                    .HasMaxLength(300)
                    .HasColumnName("imp_rule")
                    .HasComment("欄位規則");

                entity.Property(e => e.ImpRuleType)
                    .HasMaxLength(5)
                    .HasColumnName("imp_rule_type")
                    .HasComment("欄位規則類型(DF,TP01,TP02)");

                entity.Property(e => e.ImpTitle)
                    .HasMaxLength(50)
                    .HasColumnName("imp_title")
                    .HasComment("欄位標題");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.MetaFieldName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("meta_field_name")
                    .HasComment("欄位名");

                entity.Property(e => e.MetaMdlobjObj)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("meta_mdlobj_obj")
                    .HasComment("資料物件名");

                entity.HasOne(d => d.ImpMapM)
                    .WithMany(p => p.ImpMapDs)
                    .HasForeignKey(d => d.ImpMapMId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("imp_map_d_fk1");
            });

            modelBuilder.Entity<ImpMapM>(entity =>
            {
                entity.ToTable("imp_map_m", "fw_mif");

                entity.HasIndex(e => new { e.AliasName, e.ApName }, "imp_map_m_uk1")
                    .IsUnique();

                entity.Property(e => e.ImpMapMId)
                    .HasMaxLength(22)
                    .HasColumnName("imp_map_m_id")
                    .HasDefaultValueSql("''::character varying")
                    .HasComment("資料匯入設定主檔ID");

                entity.Property(e => e.AliasName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("alias_name")
                    .HasComment("設定別名");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name")
                    .HasComment("AP NAME");

                entity.Property(e => e.ConnAlias)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("conn_alias")
                    .HasComment("連線別名");

                entity.Property(e => e.Description)
                    .HasMaxLength(120)
                    .HasColumnName("description")
                    .HasComment("設定描述");

                entity.Property(e => e.FailHandle)
                    .HasMaxLength(1)
                    .HasColumnName("fail_handle")
                    .HasDefaultValueSql("'R'::bpchar")
                    .HasComment("錯誤發生後處理機制");

                entity.Property(e => e.HasHeader)
                    .HasMaxLength(1)
                    .HasColumnName("has_header")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("是否設定標題");

                entity.Property(e => e.ImpType)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("imp_type")
                    .HasComment("可處理檔案(副檔名)");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.MetaMdlNo)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("meta_mdl_no")
                    .HasComment("資料模型代號");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasDefaultValueSql("NULL::numeric")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasComment("異動人員(UUID)");
            });

            modelBuilder.Entity<Initial0Amdum>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("initial0_amda", "ap_mif");

                entity.Property(e => e._1)
                    .HasMaxLength(255)
                    .HasColumnName("1");
            });

            modelBuilder.Entity<Initial0Wip>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("initial0_wip", "ap_mif");

                entity.Property(e => e.Charg)
                    .HasMaxLength(255)
                    .HasColumnName("CHARG");

                entity.Property(e => e.DataGroup).HasMaxLength(255);

                entity.Property(e => e.DocDate)
                    .HasMaxLength(255)
                    .HasColumnName("DOC_DATE");

                entity.Property(e => e.Kdauf)
                    .HasMaxLength(255)
                    .HasColumnName("KDAUF");

                entity.Property(e => e.Kdpos)
                    .HasMaxLength(255)
                    .HasColumnName("KDPOS");

                entity.Property(e => e.Lgort)
                    .HasMaxLength(255)
                    .HasColumnName("LGORT");

                entity.Property(e => e.Lifnr)
                    .HasMaxLength(255)
                    .HasColumnName("LIFNR");

                entity.Property(e => e.Mblnr)
                    .HasMaxLength(255)
                    .HasColumnName("MBLNR");

                entity.Property(e => e.Meins)
                    .HasMaxLength(255)
                    .HasColumnName("MEINS");

                entity.Property(e => e.Menge)
                    .HasMaxLength(255)
                    .HasColumnName("MENGE");

                entity.Property(e => e.PostingDate)
                    .HasMaxLength(255)
                    .HasColumnName("POSTING_DATE");

                entity.Property(e => e.ProductBatch).HasMaxLength(255);

                entity.Property(e => e.ProductKind).HasMaxLength(255);

                entity.Property(e => e.Sobkz)
                    .HasMaxLength(255)
                    .HasColumnName("SOBKZ");

                entity.Property(e => e.Step).HasMaxLength(255);

                entity.Property(e => e.Werks)
                    .HasMaxLength(255)
                    .HasColumnName("WERKS");

                entity.Property(e => e.Zpack)
                    .HasMaxLength(255)
                    .HasColumnName("ZPACK");
            });

            modelBuilder.Entity<Initial1Material>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("initial1_material", "ap_mif");

                entity.Property(e => e.Auart)
                    .HasMaxLength(255)
                    .HasColumnName("AUART");

                entity.Property(e => e.Aufnr)
                    .HasMaxLength(255)
                    .HasColumnName("AUFNR");

                entity.Property(e => e.CapacityClass).HasMaxLength(255);

                entity.Property(e => e.DataGroup).HasMaxLength(255);

                entity.Property(e => e.DateCode).HasMaxLength(255);

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.DocumentationUrl)
                    .HasMaxLength(255)
                    .HasColumnName("DocumentationURL");

                entity.Property(e => e.DueDate).HasMaxLength(255);

                entity.Property(e => e.ExpirationDate).HasMaxLength(255);

                entity.Property(e => e.Facility).HasMaxLength(255);

                entity.Property(e => e.FloorLifeRemainingHours).HasMaxLength(255);

                entity.Property(e => e.FlowPath).HasMaxLength(255);

                entity.Property(e => e.Form).HasMaxLength(255);

                entity.Property(e => e.InhibitMoveFromStep).HasMaxLength(255);

                entity.Property(e => e.InhibitShip).HasMaxLength(255);

                entity.Property(e => e.IsRoHscompliant)
                    .HasMaxLength(255)
                    .HasColumnName("IsRoHSCompliant");

                entity.Property(e => e.IsTemplate).HasMaxLength(255);

                entity.Property(e => e.Leftqty)
                    .HasMaxLength(255)
                    .HasColumnName("LEFTQTY");

                entity.Property(e => e.Location).HasMaxLength(255);

                entity.Property(e => e.Manufacturer).HasMaxLength(255);

                entity.Property(e => e.ManufacturerLotNumber).HasMaxLength(255);

                entity.Property(e => e.ManufacturerPartNumber).HasMaxLength(255);

                entity.Property(e => e.MoistureSensitivityLevel).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.OrderNumber).HasMaxLength(255);

                entity.Property(e => e.ParentMaterial).HasMaxLength(255);

                entity.Property(e => e.Posnr)
                    .HasMaxLength(255)
                    .HasColumnName("POSNR");

                entity.Property(e => e.PrimaryQuantity).HasMaxLength(255);

                entity.Property(e => e.PrimaryUnits).HasMaxLength(255);

                entity.Property(e => e.PriorityZPriority)
                    .HasMaxLength(255)
                    .HasColumnName("Priority\r\nZ_Priority");

                entity.Property(e => e.Prodbatch)
                    .HasMaxLength(255)
                    .HasColumnName("PRODBATCH");

                entity.Property(e => e.Product).HasMaxLength(255);

                entity.Property(e => e.ProductionOrder).HasMaxLength(255);

                entity.Property(e => e.PurchaseOrderNumber).HasMaxLength(255);

                entity.Property(e => e.Rightqty)
                    .HasMaxLength(255)
                    .HasColumnName("RIGHTQTY");

                entity.Property(e => e.SecondaryQuantity).HasMaxLength(255);

                entity.Property(e => e.SplitMergeRestrictionType).HasMaxLength(255);

                entity.Property(e => e.Stand)
                    .HasMaxLength(255)
                    .HasColumnName("STAND");

                entity.Property(e => e.SubLineNo).HasMaxLength(255);

                entity.Property(e => e.Supplier).HasMaxLength(255);

                entity.Property(e => e.Type).HasMaxLength(255);

                entity.Property(e => e.Vbeln)
                    .HasMaxLength(255)
                    .HasColumnName("VBELN");

                entity.Property(e => e.Werks)
                    .HasMaxLength(255)
                    .HasColumnName("WERKS");

                entity.Property(e => e.Wosize)
                    .HasMaxLength(255)
                    .HasColumnName("WOSIZE");
            });

            modelBuilder.Entity<Initial2Amatch>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("initial2_amatch", "ap_mif");

                entity.Property(e => e.BookingQty).HasMaxLength(255);

                entity.Property(e => e.Component)
                    .HasMaxLength(255)
                    .HasColumnName("COMPONENT");

                entity.Property(e => e.DataGroup).HasMaxLength(255);

                entity.Property(e => e.Facility).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.PrimaryQuantity).HasMaxLength(255);

                entity.Property(e => e.Prodbatch)
                    .HasMaxLength(255)
                    .HasColumnName("PRODBATCH");

                entity.Property(e => e.Product).HasMaxLength(255);

                entity.Property(e => e.Step).HasMaxLength(255);

                entity.Property(e => e.TinQty)
                    .HasMaxLength(255)
                    .HasColumnName("TInQty");

                entity.Property(e => e.ToutQty)
                    .HasMaxLength(255)
                    .HasColumnName("TOutQty");

                entity.Property(e => e.UseQty).HasMaxLength(255);
            });

            modelBuilder.Entity<Initial3Product>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("initial3_product", "ap_mif");

                entity.Property(e => e.AdditionalConsumptionQuantity).HasMaxLength(255);

                entity.Property(e => e.ApprovalRole).HasMaxLength(255);

                entity.Property(e => e.BinningTree)
                    .HasMaxLength(255)
                    .HasColumnName("Binning Tree");

                entity.Property(e => e.CanSplitForPicking).HasMaxLength(255);

                entity.Property(e => e.CapacityClass).HasMaxLength(255);

                entity.Property(e => e.ConsumptionScrap).HasMaxLength(255);

                entity.Property(e => e.CycleTime).HasMaxLength(255);

                entity.Property(e => e.DataGroup).HasMaxLength(255);

                entity.Property(e => e.DefaultUnits).HasMaxLength(255);

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.FinishedUnitCost).HasMaxLength(255);

                entity.Property(e => e.FloorLife).HasMaxLength(255);

                entity.Property(e => e.FloorLifeUnitOfTime).HasMaxLength(255);

                entity.Property(e => e.FlowPath).HasMaxLength(255);

                entity.Property(e => e.IncludeInSchedule).HasMaxLength(255);

                entity.Property(e => e.InitialUnitCost).HasMaxLength(255);

                entity.Property(e => e.IsDiscrete).HasMaxLength(255);

                entity.Property(e => e.IsEnableForMaintenanceManagement).HasMaxLength(255);

                entity.Property(e => e.IsEnabled).HasMaxLength(255);

                entity.Property(e => e.IsEnabledForMaterialLogistics).HasMaxLength(255);

                entity.Property(e => e.MaintenanceManagementConsumeQuantity).HasMaxLength(255);

                entity.Property(e => e.MaterialLogisticsDefaultRequestQuantity).HasMaxLength(255);

                entity.Property(e => e.MaterialTransferAllowedPickup).HasMaxLength(255);

                entity.Property(e => e.MaterialTransferApprovalMode).HasMaxLength(255);

                entity.Property(e => e.MaterialTransferMode).HasMaxLength(255);

                entity.Property(e => e.MoistureSensitivityLevel).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.ProductGroup).HasMaxLength(255);

                entity.Property(e => e.ProductType).HasMaxLength(255);

                entity.Property(e => e.RequiresApproval).HasMaxLength(255);

                entity.Property(e => e.SubProducts)
                    .HasMaxLength(255)
                    .HasColumnName("Sub Products");

                entity.Property(e => e.Type).HasMaxLength(255);

                entity.Property(e => e.UnitConversionFactors)
                    .HasMaxLength(255)
                    .HasColumnName("Unit Conversion Factors");

                entity.Property(e => e.Yield).HasMaxLength(255);
            });

            modelBuilder.Entity<KanbanDefectQtyO>(entity =>
            {
                entity.HasKey(e => new { e.FactNo, e.BuildNo, e.ProdArea, e.ProdStep, e.ProdGroupno, e.ProdDate, e.DefectNo })
                    .HasName("pk_defect_qty_o");

                entity.ToTable("kanban_defect_qty_o", "ap_mif");

                entity.HasComment("不良原因統計狀況");

                entity.Property(e => e.FactNo)
                    .HasMaxLength(30)
                    .HasColumnName("fact_no")
                    .HasComment("廠別代碼");

                entity.Property(e => e.BuildNo)
                    .HasMaxLength(30)
                    .HasColumnName("build_no")
                    .HasComment("棟別代碼");

                entity.Property(e => e.ProdArea)
                    .HasMaxLength(30)
                    .HasColumnName("prod_area")
                    .HasComment("生產區域代碼");

                entity.Property(e => e.ProdStep)
                    .HasMaxLength(30)
                    .HasColumnName("prod_step")
                    .HasComment("生產站點代碼");

                entity.Property(e => e.ProdGroupno)
                    .HasMaxLength(30)
                    .HasColumnName("prod_groupno")
                    .HasComment("生產組別代碼");

                entity.Property(e => e.ProdDate)
                    .HasMaxLength(20)
                    .HasColumnName("prod_date")
                    .HasComment("生產日期");

                entity.Property(e => e.DefectNo)
                    .HasMaxLength(30)
                    .HasColumnName("defect_no")
                    .HasComment("不良原因代碼");

                entity.Property(e => e.DefectDesc)
                    .HasMaxLength(50)
                    .HasColumnName("defect_desc")
                    .HasComment("不良原因Desc");

                entity.Property(e => e.DefectRateG)
                    .HasPrecision(18, 3)
                    .HasColumnName("defect_rate_g")
                    .HasDefaultValueSql("0")
                    .HasComment("比率(組):不良點位數-組別/不良點位數-棟別");

                entity.Property(e => e.ProdGroupdec)
                    .HasMaxLength(30)
                    .HasColumnName("prod_groupdec")
                    .HasComment("生產組別Dec");

                entity.Property(e => e.VacancyQtyB)
                    .HasPrecision(18, 3)
                    .HasColumnName("vacancy_qty_b")
                    .HasDefaultValueSql("0")
                    .HasComment("不良點位數-棟別:By 棟別代碼+不良原因代碼-當下加總");

                entity.Property(e => e.VacancyQtyG)
                    .HasPrecision(18, 3)
                    .HasColumnName("vacancy_qty_g")
                    .HasDefaultValueSql("0")
                    .HasComment("不良點位數-組別:By 生產組別+不良原因代碼-當下加總");
            });

            modelBuilder.Entity<KanbanDefectQtyPeriodO>(entity =>
            {
                entity.HasKey(e => new { e.FactNo, e.BuildNo, e.ProdArea, e.ProdStep, e.ProdGroupno, e.ProdDate })
                    .HasName("pk_defect_qty");

                entity.ToTable("kanban_defect_qty_period_o", "ap_mif");

                entity.HasComment("各棟各站良率狀況");

                entity.Property(e => e.FactNo)
                    .HasMaxLength(30)
                    .HasColumnName("fact_no")
                    .HasComment("廠別代碼");

                entity.Property(e => e.BuildNo)
                    .HasMaxLength(30)
                    .HasColumnName("build_no")
                    .HasComment("棟別代碼");

                entity.Property(e => e.ProdArea)
                    .HasMaxLength(30)
                    .HasColumnName("prod_area")
                    .HasComment("生產區域代碼Eg:樓層");

                entity.Property(e => e.ProdStep)
                    .HasMaxLength(30)
                    .HasColumnName("prod_step")
                    .HasComment("生產站點代碼:裁管配套/成型/底加/針車");

                entity.Property(e => e.ProdGroupno)
                    .HasMaxLength(30)
                    .HasColumnName("prod_groupno")
                    .HasComment("生產組別代碼:100001");

                entity.Property(e => e.ProdDate)
                    .HasMaxLength(30)
                    .HasColumnName("prod_date")
                    .HasComment("生產日期:2022/08/04");

                entity.Property(e => e.ActualQty)
                    .HasPrecision(18, 3)
                    .HasColumnName("actual_qty")
                    .HasDefaultValueSql("0")
                    .HasComment("實際產量");

                entity.Property(e => e.Defect07Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("defect_07_qty")
                    .HasDefaultValueSql("0")
                    .HasComment("QC時段-07:抓取07:00~07:59:59-By 生產組別-不良數");

                entity.Property(e => e.Defect08Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("defect_08_qty")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Defect09Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("defect_09_qty")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Defect10Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("defect_10_qty")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Defect11Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("defect_11_qty")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Defect12Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("defect_12_qty")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Defect13Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("defect_13_qty")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Defect14Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("defect_14_qty")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Defect15Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("defect_15_qty")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Defect16Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("defect_16_qty")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Defect17Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("defect_17_qty")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Defect18Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("defect_18_qty")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DefectOther01Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("defect_other01_qty")
                    .HasDefaultValueSql("0")
                    .HasComment("QC時段-other-01:抓取00:00~06:59:59-By 生產組別-不良數");

                entity.Property(e => e.DefectOther02Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("defect_other02_qty")
                    .HasDefaultValueSql("0")
                    .HasComment("抓取19:00~24:59:59-By 生產組別-不良數");

                entity.Property(e => e.Prod07Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_07_qty")
                    .HasDefaultValueSql("0")
                    .HasComment("生產時段-07:抓取07:00~07:59:59-By 生產組別-產量");

                entity.Property(e => e.Prod08Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_08_qty")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Prod09Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_09_qty")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Prod10Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_10_qty")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Prod11Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_11_qty")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Prod12Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_12_qty")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Prod13Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_13_qty")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Prod14Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_14_qty")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Prod15Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_15_qty")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Prod16Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_16_qty")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Prod17Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_17_qty")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Prod18Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_18_qty")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ProdGroupdesc)
                    .HasMaxLength(30)
                    .HasColumnName("prod_groupdesc")
                    .HasComment("生產組別-Desc");

                entity.Property(e => e.ProdOther01Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_other01_qty")
                    .HasDefaultValueSql("0")
                    .HasComment("生產時段-other-01:抓取00:00~06:59:59-By 生產組別-產量");

                entity.Property(e => e.ProdOther02Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_other02_qty")
                    .HasDefaultValueSql("0")
                    .HasComment("抓取19:00~24:59:59-By 生產組別-產量");
            });

            modelBuilder.Entity<KanbanProdStatusOrg>(entity =>
            {
                entity.HasKey(e => new { e.FactNo, e.BuildNo, e.ProdArea, e.ProdStep, e.ProdDate })
                    .HasName("pk_status_org");

                entity.ToTable("kanban_prod_status_org", "ap_mif");

                entity.HasComment("投產完成狀況");

                entity.Property(e => e.FactNo)
                    .HasMaxLength(30)
                    .HasColumnName("fact_no")
                    .HasComment("廠別代碼");

                entity.Property(e => e.BuildNo)
                    .HasMaxLength(30)
                    .HasColumnName("build_no")
                    .HasComment("棟別代碼");

                entity.Property(e => e.ProdArea)
                    .HasMaxLength(30)
                    .HasColumnName("prod_area")
                    .HasComment("生產區域代碼");

                entity.Property(e => e.ProdStep)
                    .HasMaxLength(30)
                    .HasColumnName("prod_step")
                    .HasComment("生產站點代碼");

                entity.Property(e => e.ProdDate)
                    .HasMaxLength(20)
                    .HasColumnName("prod_date")
                    .HasComment("生產日期");

                entity.Property(e => e.CaQty)
                    .HasPrecision(18, 3)
                    .HasColumnName("ca_qty")
                    .HasDefaultValueSql("0")
                    .HasComment("累積完成數:依 欄位\"應完成數\"之抓取工單,去查核當下這些工單的己完成量總計");

                entity.Property(e => e.CaTodayQty)
                    .HasPrecision(18, 3)
                    .HasColumnName("ca_today_qty")
                    .HasDefaultValueSql("0")
                    .HasComment("本日實產累積數:2022/07/01-09:16 當下,當日之該生產區域+站點當日的生產數量");

                entity.Property(e => e.ExpQty)
                    .HasPrecision(18, 3)
                    .HasColumnName("exp_qty")
                    .HasDefaultValueSql("0")
                    .HasComment("應完成數:至生產日期前,應完成而未完成之工單數量總合");

                entity.Property(e => e.VacancyQty)
                    .HasPrecision(18, 3)
                    .HasColumnName("vacancy_qty")
                    .HasDefaultValueSql("0")
                    .HasComment("欠數:應完成數-累積完成數");
            });

            modelBuilder.Entity<KanbanProdorgSetup>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("kanban_prodorg_setup", "ap_mif");

                entity.HasComment("基本設定檔-站點基本資料");

                entity.Property(e => e.BuildDesc)
                    .HasMaxLength(80)
                    .HasColumnName("build_desc")
                    .HasComment("棟別說明");

                entity.Property(e => e.BuildNo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("build_no")
                    .HasComment("棟別代碼");

                entity.Property(e => e.Chartemp1)
                    .HasMaxLength(256)
                    .HasColumnName("chartemp1");

                entity.Property(e => e.Chartemp2)
                    .HasMaxLength(256)
                    .HasColumnName("chartemp2");

                entity.Property(e => e.Chartemp3)
                    .HasMaxLength(256)
                    .HasColumnName("chartemp3");

                entity.Property(e => e.Chartemp4)
                    .HasMaxLength(256)
                    .HasColumnName("chartemp4");

                entity.Property(e => e.Chartemp5)
                    .HasMaxLength(256)
                    .HasColumnName("chartemp5");

                entity.Property(e => e.FactDesc)
                    .HasMaxLength(80)
                    .HasColumnName("fact_desc")
                    .HasComment("廠別說明");

                entity.Property(e => e.FactNo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("fact_no")
                    .HasComment("廠別代碼");

                entity.Property(e => e.FactPcgMes)
                    .HasMaxLength(80)
                    .HasColumnName("fact_pcg_mes")
                    .HasComment("PCG-MES廠代碼");

                entity.Property(e => e.Numtemp1)
                    .HasPrecision(18, 3)
                    .HasColumnName("numtemp1")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Numtemp2)
                    .HasPrecision(18, 3)
                    .HasColumnName("numtemp2")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Numtemp3)
                    .HasPrecision(18, 3)
                    .HasColumnName("numtemp3")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Numtemp4)
                    .HasPrecision(18, 3)
                    .HasColumnName("numtemp4")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Numtemp5)
                    .HasPrecision(18, 3)
                    .HasColumnName("numtemp5")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ProdArea)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("prod_area")
                    .HasComment("生產區域代碼");

                entity.Property(e => e.ProdAreaDesc)
                    .HasMaxLength(80)
                    .HasColumnName("prod_area_desc")
                    .HasComment("生產區域");

                entity.Property(e => e.ProdGroupdesc)
                    .HasMaxLength(80)
                    .HasColumnName("prod_groupdesc")
                    .HasComment("生產組別");

                entity.Property(e => e.ProdGroupno)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("prod_groupno")
                    .HasComment("生產組別代碼");

                entity.Property(e => e.ProdStep)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("prod_step")
                    .HasComment("生產站點代碼");

                entity.Property(e => e.ProdStepDesc)
                    .HasMaxLength(80)
                    .HasColumnName("prod_step_desc")
                    .HasComment("生產站點");
            });

            modelBuilder.Entity<KanbanProdqtyDaystatus>(entity =>
            {
                entity.HasKey(e => new { e.FactNo, e.BuildNo, e.ProdArea, e.ProdStep, e.ProdGroupno, e.ProdDate })
                    .HasName("pk_daystatus");

                entity.ToTable("kanban_prodqty_daystatus", "ap_mif");

                entity.HasComment("生產狀況-日產量");

                entity.Property(e => e.FactNo)
                    .HasMaxLength(30)
                    .HasColumnName("fact_no")
                    .HasComment("廠別代碼");

                entity.Property(e => e.BuildNo)
                    .HasMaxLength(30)
                    .HasColumnName("build_no")
                    .HasComment("棟別代碼");

                entity.Property(e => e.ProdArea)
                    .HasMaxLength(30)
                    .HasColumnName("prod_area")
                    .HasComment("生產區域代碼Eg:樓層");

                entity.Property(e => e.ProdStep)
                    .HasMaxLength(30)
                    .HasColumnName("prod_step")
                    .HasComment("生產站點代碼:裁管配套/成型/底加/針車");

                entity.Property(e => e.ProdGroupno)
                    .HasMaxLength(30)
                    .HasColumnName("prod_groupno")
                    .HasComment("生產組別代碼:100001");

                entity.Property(e => e.ProdDate)
                    .HasMaxLength(30)
                    .HasColumnName("prod_date")
                    .HasComment("生產日期:2022/08/04");

                entity.Property(e => e.ActualQty)
                    .HasPrecision(18, 3)
                    .HasColumnName("actual_qty")
                    .HasDefaultValueSql("0")
                    .HasComment("實際產量");

                entity.Property(e => e.CaRate)
                    .HasPrecision(18, 3)
                    .HasColumnName("ca_rate")
                    .HasDefaultValueSql("0")
                    .HasComment("累積達成率:實際產量/預計產量-日");

                entity.Property(e => e.Prod07Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_07_qty")
                    .HasDefaultValueSql("0")
                    .HasComment("生產時段-07:抓取07:00~07:59:59-By 生產組別-產量");

                entity.Property(e => e.Prod08Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_08_qty")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Prod09Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_09_qty")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Prod10Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_10_qty")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Prod11Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_11_qty")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Prod12Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_12_qty")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Prod13Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_13_qty")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Prod14Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_14_qty")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Prod15Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_15_qty")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Prod16Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_16_qty")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Prod17Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_17_qty")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Prod18Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_18_qty")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ProdGroupdesc)
                    .HasMaxLength(30)
                    .HasColumnName("prod_groupdesc")
                    .HasComment("生產組別-Desc");

                entity.Property(e => e.ProdOther01Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_other01_qty")
                    .HasDefaultValueSql("0")
                    .HasComment("生產時段-other-01:抓取00:00~06:59:59-By 生產組別-產量");

                entity.Property(e => e.ProdOther02Qty)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_other02_qty")
                    .HasDefaultValueSql("0")
                    .HasComment("抓取19:00~24:59:59-By 生產組別");

                entity.Property(e => e.TargetQty)
                    .HasPrecision(18, 3)
                    .HasColumnName("target_qty")
                    .HasDefaultValueSql("0")
                    .HasComment("目標產量-日");

                entity.Property(e => e.Wip)
                    .HasPrecision(18, 3)
                    .HasColumnName("wip")
                    .HasDefaultValueSql("0")
                    .HasComment("取組別當日已投產未產出訂單數量匯總");
            });

            modelBuilder.Entity<KanbanProdqtySetup>(entity =>
            {
                entity.HasKey(e => new { e.FactNo, e.BuildNo, e.ProdArea, e.ProdStep, e.ProdGroupno, e.PreProdDate })
                    .HasName("pk_ProdQty");

                entity.ToTable("kanban_prodqty_setup", "ap_mif");

                entity.HasComment("基本設定檔-標準產量-日");

                entity.Property(e => e.FactNo)
                    .HasMaxLength(30)
                    .HasColumnName("fact_no")
                    .HasComment("廠別代碼");

                entity.Property(e => e.BuildNo)
                    .HasMaxLength(30)
                    .HasColumnName("build_no")
                    .HasComment("棟別代碼");

                entity.Property(e => e.ProdArea)
                    .HasMaxLength(30)
                    .HasColumnName("prod_area")
                    .HasComment("生產區域代碼");

                entity.Property(e => e.ProdStep)
                    .HasMaxLength(30)
                    .HasColumnName("prod_step")
                    .HasComment("生產站點代碼");

                entity.Property(e => e.ProdGroupno)
                    .HasMaxLength(30)
                    .HasColumnName("prod_groupno")
                    .HasComment("生產組別代碼");

                entity.Property(e => e.PreProdDate)
                    .HasMaxLength(20)
                    .HasColumnName("pre_prod_date")
                    .HasComment("預計生產日");

                entity.Property(e => e.BuildDesc)
                    .HasMaxLength(80)
                    .HasColumnName("build_desc")
                    .HasComment("棟別說明");

                entity.Property(e => e.Chartemp1)
                    .HasMaxLength(256)
                    .HasColumnName("chartemp1");

                entity.Property(e => e.Chartemp2)
                    .HasMaxLength(256)
                    .HasColumnName("chartemp2");

                entity.Property(e => e.Chartemp3)
                    .HasMaxLength(256)
                    .HasColumnName("chartemp3");

                entity.Property(e => e.Chartemp4)
                    .HasMaxLength(256)
                    .HasColumnName("chartemp4");

                entity.Property(e => e.Chartemp5)
                    .HasMaxLength(256)
                    .HasColumnName("chartemp5");

                entity.Property(e => e.FactDesc)
                    .HasMaxLength(80)
                    .HasColumnName("fact_desc")
                    .HasComment("廠別說明");

                entity.Property(e => e.FactPcgMes)
                    .HasMaxLength(80)
                    .HasColumnName("fact_pcg_mes")
                    .HasComment("PCG-MES廠代碼");

                entity.Property(e => e.Numtemp1)
                    .HasPrecision(18, 3)
                    .HasColumnName("numtemp1")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Numtemp2)
                    .HasPrecision(18, 3)
                    .HasColumnName("numtemp2")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Numtemp3)
                    .HasPrecision(18, 3)
                    .HasColumnName("numtemp3")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Numtemp4)
                    .HasPrecision(18, 3)
                    .HasColumnName("numtemp4")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Numtemp5)
                    .HasPrecision(18, 3)
                    .HasColumnName("numtemp5")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ProdAreaDesc)
                    .HasMaxLength(80)
                    .HasColumnName("prod_area_desc")
                    .HasComment("生產區域");

                entity.Property(e => e.ProdGroupdesc)
                    .HasMaxLength(80)
                    .HasColumnName("prod_groupdesc")
                    .HasComment("生產組別");

                entity.Property(e => e.ProdStepDesc)
                    .HasMaxLength(80)
                    .HasColumnName("prod_step_desc")
                    .HasComment("生產站點");

                entity.Property(e => e.StandardQtySd)
                    .HasPrecision(18, 3)
                    .HasColumnName("standard_qty_sd")
                    .HasDefaultValueSql("0")
                    .HasComment("標準產量(SD)");

                entity.Property(e => e.TargetQty)
                    .HasPrecision(18, 3)
                    .HasColumnName("target_qty")
                    .HasDefaultValueSql("0")
                    .HasComment("目標產量(現場)");
            });

            modelBuilder.Entity<KanbanProdrateDaystatus>(entity =>
            {
                entity.HasKey(e => new { e.FactNo, e.BuildNo, e.ProdArea, e.ProdStep, e.ProdGroupno, e.ProdDate })
                    .HasName("pk_rate_daystatus");

                entity.ToTable("kanban_prodrate_daystatus", "ap_mif");

                entity.HasComment("生產狀況-日達成率");

                entity.Property(e => e.FactNo)
                    .HasMaxLength(30)
                    .HasColumnName("fact_no")
                    .HasComment("廠別代碼");

                entity.Property(e => e.BuildNo)
                    .HasMaxLength(30)
                    .HasColumnName("build_no")
                    .HasComment("棟別代碼");

                entity.Property(e => e.ProdArea)
                    .HasMaxLength(30)
                    .HasColumnName("prod_area")
                    .HasComment("生產區域代碼Eg:樓層");

                entity.Property(e => e.ProdStep)
                    .HasMaxLength(30)
                    .HasColumnName("prod_step")
                    .HasComment("生產站點代碼:裁管配套/成型/底加/針車");

                entity.Property(e => e.ProdGroupno)
                    .HasMaxLength(30)
                    .HasColumnName("prod_groupno")
                    .HasComment("生產組別代碼:100001");

                entity.Property(e => e.ProdDate)
                    .HasMaxLength(30)
                    .HasColumnName("prod_date")
                    .HasComment("生產日期:2022/08/04");

                entity.Property(e => e.ActualQty)
                    .HasPrecision(18, 3)
                    .HasColumnName("actual_qty")
                    .HasDefaultValueSql("0")
                    .HasComment("實際產量");

                entity.Property(e => e.CaRate)
                    .HasPrecision(18, 3)
                    .HasColumnName("ca_rate")
                    .HasDefaultValueSql("0")
                    .HasComment("累積達成率:實際產量/預計產量-日");

                entity.Property(e => e.Prod07Rate)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_07_rate")
                    .HasDefaultValueSql("0")
                    .HasComment("生產時段-07:抓取07:00~07:59:59-By 生產組別-產量");

                entity.Property(e => e.Prod08Rate)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_08_rate")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Prod09Rate)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_09_rate")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Prod10Rate)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_10_rate")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Prod11Rate)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_11_rate")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Prod12Rate)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_12_rate")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Prod13Rate)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_13_rate")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Prod14Rate)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_14_rate")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Prod15Rate)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_15_rate")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Prod16Rate)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_16_rate")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Prod17Rate)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_17_rate")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Prod18Rate)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_18_rate")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ProdGroupdesc)
                    .HasMaxLength(30)
                    .HasColumnName("prod_groupdesc")
                    .HasComment("生產組別-Desc");

                entity.Property(e => e.ProdOther01Rate)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_other01_rate")
                    .HasDefaultValueSql("0")
                    .HasComment("生產時段-other-01:抓取00:00~06:59:59-By 生產組別-產量");

                entity.Property(e => e.ProdOther02Rate)
                    .HasPrecision(18, 3)
                    .HasColumnName("prod_other02_rate")
                    .HasDefaultValueSql("0")
                    .HasComment("抓取19:00~24:59:59-By 生產組別");

                entity.Property(e => e.TargetQty)
                    .HasPrecision(18, 3)
                    .HasColumnName("target_qty")
                    .HasDefaultValueSql("0")
                    .HasComment("目標產量-日");

                entity.Property(e => e.Wip)
                    .HasPrecision(18, 3)
                    .HasColumnName("wip")
                    .HasDefaultValueSql("0")
                    .HasComment("取組別當日已投產未產出訂單數量匯總");
            });

            modelBuilder.Entity<LogDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("log_detail", "fw_mif");

                entity.HasIndex(e => e.LogDId, "idx_log_detail")
                    .IsUnique();

                entity.HasIndex(e => e.LogMId, "idx_log_detail1");

                entity.HasIndex(e => new { e.LogTime, e.LogLevel }, "idx_log_detail_q1");

                entity.Property(e => e.BundleName)
                    .HasMaxLength(100)
                    .HasColumnName("bundle_name")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.BundleVersion)
                    .HasMaxLength(100)
                    .HasColumnName("bundle_version")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.ErrorCode)
                    .HasMaxLength(15)
                    .HasColumnName("error_code")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.LogDId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("log_d_id");

                entity.Property(e => e.LogLevel)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("log_level");

                entity.Property(e => e.LogMId)
                    .HasMaxLength(22)
                    .HasColumnName("log_m_id")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.LogTime)
                    .HasPrecision(19)
                    .HasColumnName("log_time");

                entity.Property(e => e.LoggerName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("logger_name");

                entity.Property(e => e.Message)
                    .HasMaxLength(4000)
                    .HasColumnName("message")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.ScanTime)
                    .HasPrecision(19)
                    .HasColumnName("scan_time");

                entity.Property(e => e.Sort)
                    .HasPrecision(5)
                    .HasColumnName("sort");

                entity.Property(e => e.StackTrace)
                    .HasMaxLength(4000)
                    .HasColumnName("stack_trace")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.ThreadName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("thread_name");

                entity.HasOne(d => d.LogM)
                    .WithMany()
                    .HasForeignKey(d => d.LogMId)
                    .HasConstraintName("log_detail_fk1");
            });

            modelBuilder.Entity<LogMaster>(entity =>
            {
                entity.HasKey(e => e.LogMId)
                    .HasName("log_master_pk");

                entity.ToTable("log_master", "fw_mif");

                entity.Property(e => e.LogMId)
                    .HasMaxLength(22)
                    .HasColumnName("log_m_id");

                entity.Property(e => e.Action)
                    .HasMaxLength(500)
                    .HasColumnName("action")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name");

                entity.Property(e => e.EndTime)
                    .HasPrecision(19)
                    .HasColumnName("end_time");

                entity.Property(e => e.FwVersion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("fw_version");

                entity.Property(e => e.HasError)
                    .HasMaxLength(1)
                    .HasColumnName("has_error")
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.HttpMethod)
                    .HasMaxLength(10)
                    .HasColumnName("http_method")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsMasterMissing)
                    .HasMaxLength(1)
                    .HasColumnName("is_master_missing")
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.PccUid)
                    .HasMaxLength(14)
                    .HasColumnName("pcc_uid")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.RemoteAddr)
                    .HasMaxLength(39)
                    .HasColumnName("remote_addr")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.RequestBody).HasColumnName("request_body");

                entity.Property(e => e.ServerIp)
                    .IsRequired()
                    .HasMaxLength(39)
                    .HasColumnName("server_ip");

                entity.Property(e => e.SessionId)
                    .HasMaxLength(200)
                    .HasColumnName("session_id")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.StartTime)
                    .HasPrecision(19)
                    .HasColumnName("start_time");

                entity.Property(e => e.TakeTime)
                    .HasPrecision(11)
                    .HasColumnName("take_time")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.ThreadName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("thread_name");

                entity.Property(e => e.UserAccount)
                    .HasMaxLength(100)
                    .HasColumnName("user_account")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.UserAgent)
                    .HasMaxLength(500)
                    .HasColumnName("user_agent")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.UserId)
                    .HasMaxLength(22)
                    .HasColumnName("user_id")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.UserIp)
                    .HasMaxLength(500)
                    .HasColumnName("user_ip")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.UserName)
                    .HasMaxLength(200)
                    .HasColumnName("user_name")
                    .HasDefaultValueSql("'NULL'::character varying");
            });

            modelBuilder.Entity<LogRequestBody>(entity =>
            {
                entity.HasKey(e => e.LogMId)
                    .HasName("log_request_body_pk");

                entity.ToTable("log_request_body", "fw_mif");

                entity.Property(e => e.LogMId)
                    .HasMaxLength(22)
                    .HasColumnName("log_m_id");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.RequestBody).HasColumnName("request_body");

                entity.HasOne(d => d.LogM)
                    .WithOne(p => p.LogRequestBody)
                    .HasForeignKey<LogRequestBody>(d => d.LogMId)
                    .HasConstraintName("log_request_body_fk_log_master");
            });

            modelBuilder.Entity<MdaMatCawn>(entity =>
            {
                entity.HasKey(e => e.Matnr)
                    .HasName("mda_mat_cawn_pk");

                entity.ToTable("mda_mat_cawn", "ap_mif");

                entity.Property(e => e.Matnr)
                    .HasMaxLength(18)
                    .HasColumnName("matnr");

                entity.Property(e => e.UpdateTime)
                    .HasMaxLength(14)
                    .HasColumnName("update_time");

                entity.Property(e => e.Zann)
                    .HasMaxLength(30)
                    .HasColumnName("zann");

                entity.Property(e => e.Zbackin)
                    .HasMaxLength(30)
                    .HasColumnName("zbackin");

                entity.Property(e => e.Zbraname)
                    .HasMaxLength(30)
                    .HasColumnName("zbraname");

                entity.Property(e => e.Zcbfile)
                    .HasMaxLength(30)
                    .HasColumnName("zcbfile");

                entity.Property(e => e.Zcloth2s)
                    .HasMaxLength(30)
                    .HasColumnName("zcloth2s");

                entity.Property(e => e.Zcolor)
                    .HasMaxLength(300)
                    .HasColumnName("zcolor");

                entity.Property(e => e.Zdanny)
                    .HasMaxLength(30)
                    .HasColumnName("zdanny");

                entity.Property(e => e.Zdensity)
                    .HasMaxLength(30)
                    .HasColumnName("zdensity");

                entity.Property(e => e.Zdthinfo)
                    .HasMaxLength(30)
                    .HasColumnName("zdthinfo");

                entity.Property(e => e.Zdyeing)
                    .HasMaxLength(30)
                    .HasColumnName("zdyeing");

                entity.Property(e => e.Zeffect)
                    .HasMaxLength(30)
                    .HasColumnName("zeffect");

                entity.Property(e => e.ZgscmL)
                    .HasMaxLength(30)
                    .HasColumnName("zgscm_l");

                entity.Property(e => e.ZgscmM)
                    .HasMaxLength(30)
                    .HasColumnName("zgscm_m");

                entity.Property(e => e.ZgscmS)
                    .HasMaxLength(30)
                    .HasColumnName("zgscm_s");

                entity.Property(e => e.Zhammng)
                    .HasMaxLength(30)
                    .HasColumnName("zhammng");

                entity.Property(e => e.Zhard)
                    .HasMaxLength(30)
                    .HasColumnName("zhard");

                entity.Property(e => e.Zl1narr)
                    .HasMaxLength(30)
                    .HasColumnName("zl1narr");

                entity.Property(e => e.Zl2narr)
                    .HasMaxLength(30)
                    .HasColumnName("zl2narr");

                entity.Property(e => e.Zl3narr)
                    .HasMaxLength(30)
                    .HasColumnName("zl3narr");

                entity.Property(e => e.Zl4narr)
                    .HasMaxLength(30)
                    .HasColumnName("zl4narr");

                entity.Property(e => e.Zl5narr)
                    .HasMaxLength(30)
                    .HasColumnName("zl5narr");

                entity.Property(e => e.Zl6narr)
                    .HasMaxLength(30)
                    .HasColumnName("zl6narr");

                entity.Property(e => e.Zlastno)
                    .HasMaxLength(30)
                    .HasColumnName("zlastno");

                entity.Property(e => e.ZleatherH)
                    .HasMaxLength(30)
                    .HasColumnName("zleather_h");

                entity.Property(e => e.Zlength)
                    .HasMaxLength(30)
                    .HasColumnName("zlength");

                entity.Property(e => e.Zmatnr)
                    .HasMaxLength(30)
                    .HasColumnName("zmatnr");

                entity.Property(e => e.Zmatnrpcnt)
                    .HasMaxLength(30)
                    .HasColumnName("zmatnrpcnt");

                entity.Property(e => e.Zmatnrpd)
                    .HasMaxLength(30)
                    .HasColumnName("zmatnrpd");

                entity.Property(e => e.Zmodel)
                    .HasMaxLength(30)
                    .HasColumnName("zmodel");

                entity.Property(e => e.Zmoldno)
                    .HasMaxLength(30)
                    .HasColumnName("zmoldno");

                entity.Property(e => e.Zmoredtl)
                    .HasMaxLength(30)
                    .HasColumnName("zmoredtl");

                entity.Property(e => e.Zmuticolor)
                    .HasMaxLength(30)
                    .HasColumnName("zmuticolor");

                entity.Property(e => e.Znature)
                    .HasMaxLength(30)
                    .HasColumnName("znature");

                entity.Property(e => e.Zneedles)
                    .HasMaxLength(30)
                    .HasColumnName("zneedles");

                entity.Property(e => e.Znop)
                    .HasMaxLength(30)
                    .HasColumnName("znop");

                entity.Property(e => e.Zoilcont)
                    .HasMaxLength(30)
                    .HasColumnName("zoilcont");

                entity.Property(e => e.Zorg)
                    .HasMaxLength(30)
                    .HasColumnName("zorg");

                entity.Property(e => e.Zpack)
                    .HasMaxLength(30)
                    .HasColumnName("zpack");

                entity.Property(e => e.Zpackcont)
                    .HasMaxLength(30)
                    .HasColumnName("zpackcont");

                entity.Property(e => e.Zpartname)
                    .HasMaxLength(30)
                    .HasColumnName("zpartname");

                entity.Property(e => e.Zpattern)
                    .HasMaxLength(30)
                    .HasColumnName("zpattern");

                entity.Property(e => e.Zplst)
                    .HasMaxLength(30)
                    .HasColumnName("zplst");

                entity.Property(e => e.Zplstmtrl)
                    .HasMaxLength(30)
                    .HasColumnName("zplstmtrl");

                entity.Property(e => e.Zpound)
                    .HasMaxLength(30)
                    .HasColumnName("zpound");

                entity.Property(e => e.Zprocmd)
                    .HasMaxLength(300)
                    .HasColumnName("zprocmd");

                entity.Property(e => e.Zqty)
                    .HasMaxLength(30)
                    .HasColumnName("zqty");

                entity.Property(e => e.Zsegm)
                    .HasMaxLength(30)
                    .HasColumnName("zsegm");

                entity.Property(e => e.Zsegrang)
                    .HasMaxLength(30)
                    .HasColumnName("zsegrang");

                entity.Property(e => e.Zshoelen)
                    .HasMaxLength(30)
                    .HasColumnName("zshoelen");

                entity.Property(e => e.Zshoeno)
                    .HasMaxLength(30)
                    .HasColumnName("zshoeno");

                entity.Property(e => e.Zsize)
                    .HasMaxLength(30)
                    .HasColumnName("zsize");

                entity.Property(e => e.Zstybmn)
                    .HasMaxLength(30)
                    .HasColumnName("zstybmn");

                entity.Property(e => e.Zthick)
                    .HasMaxLength(30)
                    .HasColumnName("zthick");

                entity.Property(e => e.Zvdname)
                    .HasMaxLength(30)
                    .HasColumnName("zvdname");

                entity.Property(e => e.Zvenprod)
                    .HasMaxLength(30)
                    .HasColumnName("zvenprod");

                entity.Property(e => e.Zweight)
                    .HasMaxLength(30)
                    .HasColumnName("zweight");

                entity.Property(e => e.Zwide)
                    .HasMaxLength(30)
                    .HasColumnName("zwide");

                entity.Property(e => e.Zwovenno)
                    .HasMaxLength(30)
                    .HasColumnName("zwovenno");

                entity.Property(e => e.Zzatcolr)
                    .HasMaxLength(100)
                    .HasColumnName("zzatcolr");

                entity.Property(e => e.Zzcolorcode)
                    .HasMaxLength(40)
                    .HasColumnName("zzcolorcode");

                entity.Property(e => e.Zzdgdif)
                    .HasMaxLength(40)
                    .HasColumnName("zzdgdif");

                entity.Property(e => e.Zzdvpcd)
                    .HasMaxLength(40)
                    .HasColumnName("zzdvpcd");

                entity.Property(e => e.Zzdvpst)
                    .HasMaxLength(40)
                    .HasColumnName("zzdvpst");

                entity.Property(e => e.ZzdvpstCode)
                    .HasMaxLength(4)
                    .HasColumnName("zzdvpst_code");

                entity.Property(e => e.Zzdvptyp)
                    .HasMaxLength(40)
                    .HasColumnName("zzdvptyp");

                entity.Property(e => e.Zzfactstylecode)
                    .HasMaxLength(40)
                    .HasColumnName("zzfactstylecode");

                entity.Property(e => e.Zzformulanumber)
                    .HasMaxLength(40)
                    .HasColumnName("zzformulanumber");

                entity.Property(e => e.Zzgendr)
                    .HasMaxLength(40)
                    .HasColumnName("zzgendr");

                entity.Property(e => e.Zzheelheight)
                    .HasMaxLength(40)
                    .HasColumnName("zzheelheight");

                entity.Property(e => e.Zzlstcod)
                    .HasMaxLength(40)
                    .HasColumnName("zzlstcod");

                entity.Property(e => e.ZzmatnrPcnt)
                    .HasMaxLength(100)
                    .HasColumnName("zzmatnr_pcnt");

                entity.Property(e => e.Zzmdmark)
                    .HasMaxLength(40)
                    .HasColumnName("zzmdmark");

                entity.Property(e => e.Zzmdnam)
                    .HasMaxLength(100)
                    .HasColumnName("zzmdnam");

                entity.Property(e => e.Zzmidsolmod)
                    .HasMaxLength(100)
                    .HasColumnName("zzmidsolmod");

                entity.Property(e => e.Zzodrszrg)
                    .HasMaxLength(40)
                    .HasColumnName("zzodrszrg");

                entity.Property(e => e.Zzoutsolmat)
                    .HasMaxLength(200)
                    .HasColumnName("zzoutsolmat");

                entity.Property(e => e.Zzoutsolmod)
                    .HasMaxLength(100)
                    .HasColumnName("zzoutsolmod");

                entity.Property(e => e.Zzpartno)
                    .HasMaxLength(10)
                    .HasColumnName("zzpartno");

                entity.Property(e => e.Zzptncd)
                    .HasMaxLength(40)
                    .HasColumnName("zzptncd");

                entity.Property(e => e.Zzsizemap)
                    .HasMaxLength(40)
                    .HasColumnName("zzsizemap");

                entity.Property(e => e.Zzsmplsize)
                    .HasMaxLength(10)
                    .HasColumnName("zzsmplsize");

                entity.Property(e => e.Zzspclnote)
                    .HasMaxLength(40)
                    .HasColumnName("zzspclnote");

                entity.Property(e => e.Zzspecialnote2)
                    .HasMaxLength(100)
                    .HasColumnName("zzspecialnote2");

                entity.Property(e => e.Zzspecialnote3)
                    .HasMaxLength(100)
                    .HasColumnName("zzspecialnote3");

                entity.Property(e => e.Zzstylcode)
                    .HasMaxLength(40)
                    .HasColumnName("zzstylcode");

                entity.Property(e => e.Zzuprmatnr)
                    .HasMaxLength(200)
                    .HasColumnName("zzuprmatnr");

                entity.Property(e => e.Zzwidth)
                    .HasMaxLength(40)
                    .HasColumnName("zzwidth");
            });

            modelBuilder.Entity<MdaMatMakt>(entity =>
            {
                entity.HasKey(e => new { e.Matnr, e.Laiso })
                    .HasName("mda_mat_makt_pk");

                entity.ToTable("mda_mat_makt", "ap_mif");

                entity.Property(e => e.Matnr)
                    .HasMaxLength(18)
                    .HasColumnName("matnr");

                entity.Property(e => e.Laiso)
                    .HasMaxLength(2)
                    .HasColumnName("laiso");

                entity.Property(e => e.Loevm)
                    .HasMaxLength(1)
                    .HasColumnName("loevm");

                entity.Property(e => e.Maktx)
                    .HasMaxLength(40)
                    .HasColumnName("maktx");

                entity.Property(e => e.MaktxContent)
                    .HasMaxLength(300)
                    .HasColumnName("maktx_content");

                entity.Property(e => e.UpdateTime)
                    .HasMaxLength(14)
                    .HasColumnName("update_time");
            });

            modelBuilder.Entity<MdaMatMara>(entity =>
            {
                entity.HasKey(e => e.Matnr)
                    .HasName("mda_mat_mara_pk");

                entity.ToTable("mda_mat_mara", "ap_mif");

                entity.Property(e => e.Matnr)
                    .HasMaxLength(18)
                    .HasColumnName("matnr");

                entity.Property(e => e.Attyp)
                    .HasMaxLength(2)
                    .HasColumnName("attyp");

                entity.Property(e => e.Atwrt)
                    .HasMaxLength(18)
                    .HasColumnName("atwrt");

                entity.Property(e => e.AtwrtDesc)
                    .HasMaxLength(30)
                    .HasColumnName("atwrt_desc");

                entity.Property(e => e.BrandId)
                    .HasMaxLength(4)
                    .HasColumnName("brand_id");

                entity.Property(e => e.FshSaisj)
                    .HasMaxLength(4)
                    .HasColumnName("fsh_saisj");

                entity.Property(e => e.FshSaiso)
                    .HasMaxLength(4)
                    .HasColumnName("fsh_saiso");

                entity.Property(e => e.Groes)
                    .HasMaxLength(32)
                    .HasColumnName("groes");

                entity.Property(e => e.Loevm)
                    .HasMaxLength(1)
                    .HasColumnName("loevm");

                entity.Property(e => e.Matkl)
                    .HasMaxLength(9)
                    .HasColumnName("matkl");

                entity.Property(e => e.Meins)
                    .HasMaxLength(3)
                    .HasColumnName("meins");

                entity.Property(e => e.Mstae)
                    .HasMaxLength(2)
                    .HasColumnName("mstae");

                entity.Property(e => e.Mtart)
                    .HasMaxLength(4)
                    .HasColumnName("mtart");

                entity.Property(e => e.Pmatnr)
                    .HasMaxLength(18)
                    .HasColumnName("pmatnr");

                entity.Property(e => e.SpecialShoetx)
                    .HasMaxLength(4)
                    .HasColumnName("special_shoetx");

                entity.Property(e => e.UpdateTime)
                    .HasMaxLength(14)
                    .HasColumnName("update_time");

                entity.Property(e => e.Wherl)
                    .HasMaxLength(2)
                    .HasColumnName("wherl");
            });

            modelBuilder.Entity<MdaMatMarm>(entity =>
            {
                entity.HasKey(e => new { e.Matnr, e.MsehiType })
                    .HasName("mda_mat_marm_pk");

                entity.ToTable("mda_mat_marm", "ap_mif");

                entity.Property(e => e.Matnr)
                    .HasMaxLength(18)
                    .HasColumnName("matnr");

                entity.Property(e => e.MsehiType)
                    .HasMaxLength(2)
                    .HasColumnName("msehi_type");

                entity.Property(e => e.Breit)
                    .HasPrecision(13, 3)
                    .HasColumnName("breit");

                entity.Property(e => e.Brgew)
                    .HasPrecision(13, 3)
                    .HasColumnName("brgew");

                entity.Property(e => e.Ean11)
                    .HasMaxLength(18)
                    .HasColumnName("ean11");

                entity.Property(e => e.Gewei)
                    .HasMaxLength(3)
                    .HasColumnName("gewei");

                entity.Property(e => e.Hoehe)
                    .HasPrecision(13, 3)
                    .HasColumnName("hoehe");

                entity.Property(e => e.Laeng)
                    .HasPrecision(13, 3)
                    .HasColumnName("laeng");

                entity.Property(e => e.Loevm)
                    .HasMaxLength(1)
                    .HasColumnName("loevm");

                entity.Property(e => e.Meabm)
                    .HasMaxLength(3)
                    .HasColumnName("meabm");

                entity.Property(e => e.Meinh)
                    .HasMaxLength(3)
                    .HasColumnName("meinh");

                entity.Property(e => e.Mesub)
                    .HasMaxLength(3)
                    .HasColumnName("mesub");

                entity.Property(e => e.Ntgew)
                    .HasPrecision(13, 3)
                    .HasColumnName("ntgew");

                entity.Property(e => e.Numtp)
                    .HasMaxLength(2)
                    .HasColumnName("numtp");

                entity.Property(e => e.Umren)
                    .HasPrecision(5)
                    .HasColumnName("umren");

                entity.Property(e => e.Umrez)
                    .HasPrecision(5)
                    .HasColumnName("umrez");

                entity.Property(e => e.UpdateTime)
                    .HasMaxLength(14)
                    .HasColumnName("update_time");

                entity.Property(e => e.Voleh)
                    .HasMaxLength(3)
                    .HasColumnName("voleh");

                entity.Property(e => e.Volum)
                    .HasPrecision(13, 3)
                    .HasColumnName("volum");
            });

            modelBuilder.Entity<MdaMzzlSfa>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mda_mzzl_sfa", "ap_mif");

                entity.Property(e => e.ColorNo)
                    .IsRequired()
                    .HasMaxLength(4000)
                    .HasColumnName("color_no");

                entity.Property(e => e.ColorNoo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("color_noo");

                entity.Property(e => e.FactNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("fact_no");

                entity.Property(e => e.MatMzzl)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("mat_mzzl");

                entity.Property(e => e.MatNoSfa)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("mat_no_sfa");

                entity.Property(e => e.PartNoMzzl)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("part_no_mzzl");

                entity.Property(e => e.PartNoSfa)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("part_no_sfa");

                entity.Property(e => e.ProductNo)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("product_no");

                entity.Property(e => e.SizeNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("size_no");
            });

            modelBuilder.Entity<MesIbordcnf>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mes_ibordcnf", "ap_mif");

                entity.Property(e => e.ArchFlag)
                    .HasMaxLength(1)
                    .HasColumnName("arch_flag")
                    .HasComment("刪除");

                entity.Property(e => e.Client)
                    .HasMaxLength(20)
                    .HasColumnName("client")
                    .HasComment("SAP Outbound Client");

                entity.Property(e => e.CreateTime)
                    .HasMaxLength(20)
                    .HasColumnName("create_time")
                    .HasComment("抄寫到mif temp的時間");

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(100)
                    .HasColumnName("create_user")
                    .HasComment("抄寫到mif temp的job");

                entity.Property(e => e.DataBatchKey)
                    .HasMaxLength(300)
                    .HasColumnName("data_batch_key")
                    .HasComment("資料組");

                entity.Property(e => e.Dataid)
                    .HasColumnName("dataid")
                    .HasDefaultValueSql("nextval('mes_ibordcnf_dataid_seq'::regclass)")
                    .HasComment("數字id");

                entity.Property(e => e.FileName)
                    .HasMaxLength(50)
                    .HasColumnName("file_name")
                    .HasComment("SAP Outbound檔案名稱");

                entity.Property(e => e.MesSyncId)
                    .HasMaxLength(300)
                    .HasColumnName("mes_sync_id")
                    .HasComment("RDB到MES的ID");

                entity.Property(e => e.ProcessErrmsg)
                    .HasMaxLength(300)
                    .HasColumnName("process_errmsg")
                    .HasComment("抄寫到mif_sap_so_cnf的錯誤訊息");

                entity.Property(e => e.ProcessMk)
                    .HasMaxLength(1)
                    .HasColumnName("process_mk")
                    .HasComment("抄寫到mif_sap_so_cnf註記");

                entity.Property(e => e.ProcessTime)
                    .HasMaxLength(20)
                    .HasColumnName("process_time")
                    .HasComment("抄寫到mif_sap_so_cnf的時間");

                entity.Property(e => e.ProcessUser)
                    .HasMaxLength(100)
                    .HasColumnName("process_user")
                    .HasComment("抄寫到mif_sap_so_cnf的job");

                entity.Property(e => e.RecId)
                    .HasMaxLength(100)
                    .HasColumnName("rec_id")
                    .HasComment("Talend 傳遞ID");

                entity.Property(e => e.ReqDate1)
                    .HasMaxLength(20)
                    .HasColumnName("req_date1")
                    .HasComment("需求日期1");

                entity.Property(e => e.ReqDate2)
                    .HasMaxLength(20)
                    .HasColumnName("req_date2")
                    .HasComment("需求日期2");

                entity.Property(e => e.ReqDate3)
                    .HasMaxLength(20)
                    .HasColumnName("req_date3")
                    .HasComment("需求日期3");

                entity.Property(e => e.SapOutboundTime)
                    .HasMaxLength(20)
                    .HasColumnName("sap_outbound_time")
                    .HasComment("SAP Outbound時間");

                entity.Property(e => e.Timestamp)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("timestamp")
                    .HasComment("傳送日期時間");

                entity.Property(e => e.TransId)
                    .HasMaxLength(50)
                    .HasColumnName("trans_id")
                    .HasComment("資料交換ID");

                entity.Property(e => e.Uepos)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("uepos")
                    .HasComment("銷售訂單GA項次");

                entity.Property(e => e.Vbeln)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("vbeln")
                    .HasComment("銷售訂單");

                entity.Property(e => e.ZodrType)
                    .HasMaxLength(50)
                    .HasColumnName("zodr_type")
                    .HasComment("訂單類型");
            });

            modelBuilder.Entity<MesIbpart>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mes_ibpart", "ap_mif");

                entity.Property(e => e.BrandId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("brand_id")
                    .HasComment("品牌");

                entity.Property(e => e.Client)
                    .HasMaxLength(20)
                    .HasColumnName("client")
                    .HasComment("SAP Outbound Client");

                entity.Property(e => e.Component)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("component")
                    .HasComment("部位代號");

                entity.Property(e => e.CreateTime)
                    .HasMaxLength(20)
                    .HasColumnName("create_time")
                    .HasComment("寫入mif temp的時間，到秒，同一次執行的同一批資料都寫一樣");

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(100)
                    .HasColumnName("create_user")
                    .HasComment("寫入mif temp的人員，由TOS JOB寫入，則寫JOB NAME");

                entity.Property(e => e.DataBatchKey)
                    .HasMaxLength(300)
                    .HasColumnName("data_batch_key")
                    .HasComment("資料組");

                entity.Property(e => e.Dataid)
                    .HasColumnName("dataid")
                    .HasDefaultValueSql("nextval('mes_ibpart_dataid_seq'::regclass)")
                    .HasComment("數字序號");

                entity.Property(e => e.Deactive)
                    .HasMaxLength(1)
                    .HasColumnName("deactive")
                    .HasComment("失效註記");

                entity.Property(e => e.FileName)
                    .HasMaxLength(50)
                    .HasColumnName("file_name")
                    .HasComment("SAP Outbound檔案名稱");

                entity.Property(e => e.MesSyncId)
                    .HasMaxLength(300)
                    .HasColumnName("mes_sync_id")
                    .HasComment("RDB到MES的ID");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(50)
                    .HasColumnName("name_en")
                    .HasComment("部位名稱(英文)");

                entity.Property(e => e.NameZf)
                    .HasMaxLength(50)
                    .HasColumnName("name_zf")
                    .HasComment("部位名稱(中文)");

                entity.Property(e => e.ProcessErrmsg)
                    .HasMaxLength(300)
                    .HasColumnName("process_errmsg")
                    .HasComment("同步mif失敗原因，失敗才有值");

                entity.Property(e => e.ProcessMk)
                    .HasMaxLength(1)
                    .HasColumnName("process_mk")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("同步mif的註記");

                entity.Property(e => e.ProcessTime)
                    .HasMaxLength(20)
                    .HasColumnName("process_time")
                    .HasComment("同步到mif的時間，到秒");

                entity.Property(e => e.ProcessUser)
                    .HasMaxLength(100)
                    .HasColumnName("process_user")
                    .HasComment("同步mif的TOS JOB NAME");

                entity.Property(e => e.SapOutboundTime)
                    .HasMaxLength(20)
                    .HasColumnName("sap_outbound_time")
                    .HasComment("SAP Outbound時間");

                entity.Property(e => e.Timestamp)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("timestamp")
                    .HasComment("時間註記");

                entity.Property(e => e.TransId)
                    .HasMaxLength(50)
                    .HasColumnName("trans_id")
                    .HasComment("資料交換ID");
            });

            modelBuilder.Entity<MesIbsalesorder>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mes_ibsalesorder", "ap_mif");

                entity.Property(e => e.Aedat)
                    .HasMaxLength(20)
                    .HasColumnName("aedat")
                    .HasComment("取消日期");

                entity.Property(e => e.Arktx)
                    .HasMaxLength(50)
                    .HasColumnName("arktx");

                entity.Property(e => e.Auart)
                    .HasMaxLength(20)
                    .HasColumnName("auart")
                    .HasComment("銷售文件類型");

                entity.Property(e => e.Bezei)
                    .HasMaxLength(50)
                    .HasColumnName("bezei")
                    .HasComment("說明");

                entity.Property(e => e.Bstdk)
                    .HasMaxLength(20)
                    .HasColumnName("bstdk")
                    .HasComment("客戶下單日期");

                entity.Property(e => e.Bstkd)
                    .HasMaxLength(50)
                    .HasColumnName("bstkd")
                    .HasComment("客戶PO");

                entity.Property(e => e.BstkdE)
                    .HasMaxLength(50)
                    .HasColumnName("bstkd_e");

                entity.Property(e => e.Client)
                    .HasMaxLength(20)
                    .HasColumnName("client")
                    .HasComment("SAP Outbound Client");

                entity.Property(e => e.CreateTime)
                    .HasMaxLength(20)
                    .HasColumnName("create_time");

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(100)
                    .HasColumnName("create_user");

                entity.Property(e => e.DataBatchKey)
                    .HasMaxLength(300)
                    .HasColumnName("data_batch_key")
                    .HasComment("資料組");

                entity.Property(e => e.Dataid)
                    .HasColumnName("dataid")
                    .HasDefaultValueSql("nextval('mes_ibsalesorder_dataid_seq'::regclass)");

                entity.Property(e => e.DelFlag)
                    .HasMaxLength(1)
                    .HasColumnName("del_flag")
                    .HasComment("刪除");

                entity.Property(e => e.Destination)
                    .HasMaxLength(20)
                    .HasColumnName("destination")
                    .HasComment("出貨地");

                entity.Property(e => e.EndCustSo)
                    .HasMaxLength(50)
                    .HasColumnName("end_cust_so")
                    .HasComment("終端客戶訂單號");

                entity.Property(e => e.FactOrder)
                    .HasMaxLength(20)
                    .HasColumnName("fact_order")
                    .HasComment("工廠訂單");

                entity.Property(e => e.FileName)
                    .HasMaxLength(50)
                    .HasColumnName("file_name")
                    .HasComment("SAP Outbound檔案名稱");

                entity.Property(e => e.FshSeason)
                    .HasMaxLength(4)
                    .HasColumnName("fsh_season");

                entity.Property(e => e.Kdmat)
                    .HasMaxLength(50)
                    .HasColumnName("kdmat");

                entity.Property(e => e.Kwmeng)
                    .HasPrecision(18, 8)
                    .HasColumnName("kwmeng")
                    .HasComment("數量");

                entity.Property(e => e.MatnrSo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("matnr_so")
                    .HasComment("銷售料號");

                entity.Property(e => e.MesSyncId)
                    .HasMaxLength(300)
                    .HasColumnName("mes_sync_id")
                    .HasComment("RDB到MES的ID");

                entity.Property(e => e.ProcessErrmsg)
                    .HasMaxLength(300)
                    .HasColumnName("process_errmsg");

                entity.Property(e => e.ProcessMk)
                    .HasMaxLength(1)
                    .HasColumnName("process_mk");

                entity.Property(e => e.ProcessTime)
                    .HasMaxLength(20)
                    .HasColumnName("process_time");

                entity.Property(e => e.ProcessUser)
                    .HasMaxLength(100)
                    .HasColumnName("process_user");

                entity.Property(e => e.RecId)
                    .HasMaxLength(100)
                    .HasColumnName("rec_id")
                    .HasComment("Talend 傳遞ID");

                entity.Property(e => e.ReqDate1)
                    .HasMaxLength(20)
                    .HasColumnName("req_date1")
                    .HasComment("需求日期1");

                entity.Property(e => e.ReqDate2)
                    .HasMaxLength(20)
                    .HasColumnName("req_date2")
                    .HasComment("需求日期2");

                entity.Property(e => e.ReqDate3)
                    .HasMaxLength(20)
                    .HasColumnName("req_date3")
                    .HasComment("需求日期3");

                entity.Property(e => e.SapOutboundTime)
                    .HasMaxLength(20)
                    .HasColumnName("sap_outbound_time")
                    .HasComment("SAP Outbound時間");

                entity.Property(e => e.SgtRcat)
                    .HasMaxLength(20)
                    .HasColumnName("sgt_rcat")
                    .HasComment("需求類別");

                entity.Property(e => e.SizeNo)
                    .HasMaxLength(50)
                    .HasColumnName("size_no")
                    .HasComment("訂單SIZE");

                entity.Property(e => e.SoRemark)
                    .HasMaxLength(500)
                    .HasColumnName("so_remark")
                    .HasComment("訂單訊息註記");

                entity.Property(e => e.Spart)
                    .HasMaxLength(2)
                    .HasColumnName("spart");

                entity.Property(e => e.Timestamp)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("timestamp")
                    .HasComment("傳送日期時間");

                entity.Property(e => e.TransId)
                    .HasMaxLength(50)
                    .HasColumnName("trans_id")
                    .HasComment("資料交換ID");

                entity.Property(e => e.Uepos)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("uepos")
                    .HasComment("銷售訂單GA項次");

                entity.Property(e => e.Vbeln)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("vbeln")
                    .HasComment("銷售訂單");

                entity.Property(e => e.Vbpos)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("vbpos")
                    .HasComment("銷售訂單項次");

                entity.Property(e => e.Vdatu)
                    .HasMaxLength(20)
                    .HasColumnName("vdatu")
                    .HasComment("計劃出貨日期");

                entity.Property(e => e.Vrkme)
                    .HasMaxLength(20)
                    .HasColumnName("vrkme")
                    .HasComment("計量單位");

                entity.Property(e => e.Vsart)
                    .HasMaxLength(20)
                    .HasColumnName("vsart")
                    .HasComment("出貨方式(shipping Type)");

                entity.Property(e => e.Vtweg)
                    .HasMaxLength(2)
                    .HasColumnName("vtweg");

                entity.Property(e => e.Werks)
                    .HasMaxLength(20)
                    .HasColumnName("werks")
                    .HasComment("接單工廠");

                entity.Property(e => e.ZzbuyPeriod)
                    .HasMaxLength(20)
                    .HasColumnName("zzbuy_period")
                    .HasComment("接單年月");

                entity.Property(e => e.Zzdgdif)
                    .HasMaxLength(20)
                    .HasColumnName("zzdgdif")
                    .HasComment("難易度");

                entity.Property(e => e.Zzlaunch)
                    .HasMaxLength(20)
                    .HasColumnName("zzlaunch")
                    .HasComment("Launch Remark");

                entity.Property(e => e.ZzpurchNoSs)
                    .HasMaxLength(50)
                    .HasColumnName("zzpurch_no_ss");
            });

            modelBuilder.Entity<MesIbwork>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mes_ibwork", "ap_mif");

                entity.Property(e => e.Astnr)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("astnr")
                    .HasComment("工單狀態 DLID (刪除)/ REL(核發) / TECO(技術性完成 , 翻譯中文 : 完成)三種");

                entity.Property(e => e.AstnrTxt)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("astnr_txt")
                    .HasComment("工單狀態說明");

                entity.Property(e => e.Auart)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("auart")
                    .HasComment("工單類型");

                entity.Property(e => e.Aufld)
                    .HasMaxLength(20)
                    .HasColumnName("aufld")
                    .HasComment("BOM展開日期");

                entity.Property(e => e.Aufnr)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("aufnr")
                    .HasComment("工單號碼");

                entity.Property(e => e.Client)
                    .HasMaxLength(20)
                    .HasColumnName("client")
                    .HasComment("SAP Outbound Client");

                entity.Property(e => e.CreateTime)
                    .HasMaxLength(20)
                    .HasColumnName("create_time")
                    .HasComment("寫入RDB的時間，到秒，同一次執行的同一批資料都寫一樣");

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(100)
                    .HasColumnName("create_user")
                    .HasComment("寫入RDB的人員，由TOS JOB寫入，則寫JOB NAME");

                entity.Property(e => e.DataBatchKey)
                    .HasMaxLength(300)
                    .HasColumnName("data_batch_key")
                    .HasComment("資料組");

                entity.Property(e => e.Dataid)
                    .HasColumnName("dataid")
                    .HasDefaultValueSql("nextval('mes_ibwork_dataid_seq'::regclass)")
                    .HasComment("數字序號");

                entity.Property(e => e.FileName)
                    .HasMaxLength(50)
                    .HasColumnName("file_name")
                    .HasComment("SAP Outbound檔案名稱");

                entity.Property(e => e.Gamng)
                    .HasPrecision(18, 8)
                    .HasColumnName("gamng")
                    .HasComment("生產數量");

                entity.Property(e => e.Gltrp)
                    .HasMaxLength(14)
                    .HasColumnName("gltrp")
                    .IsFixedLength(true)
                    .HasComment("基準結束日");

                entity.Property(e => e.Gstrp)
                    .HasMaxLength(14)
                    .HasColumnName("gstrp")
                    .IsFixedLength(true)
                    .HasComment("基準開始日");

                entity.Property(e => e.LeftQty)
                    .HasPrecision(18, 8)
                    .HasColumnName("left_qty")
                    .HasComment("左腳隻數");

                entity.Property(e => e.Meins)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("meins")
                    .HasComment("計量單位");

                entity.Property(e => e.MesSyncId)
                    .HasMaxLength(300)
                    .HasColumnName("mes_sync_id")
                    .HasComment("RDB到MES的ID");

                entity.Property(e => e.Plnal)
                    .HasMaxLength(20)
                    .HasColumnName("plnal")
                    .HasComment("群組計數器");

                entity.Property(e => e.Plnbez)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("plnbez")
                    .HasComment("產出料號");

                entity.Property(e => e.Plnnr)
                    .HasMaxLength(20)
                    .HasColumnName("plnnr")
                    .HasComment("群組號碼");

                entity.Property(e => e.Posnr)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("posnr")
                    .HasComment("訂單項次");

                entity.Property(e => e.ProcessErrmsg)
                    .HasMaxLength(300)
                    .HasColumnName("process_errmsg")
                    .HasComment("同步MES失敗原因，失敗才有值");

                entity.Property(e => e.ProcessMk)
                    .HasMaxLength(1)
                    .HasColumnName("process_mk")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("同步MES的註記");

                entity.Property(e => e.ProcessTime)
                    .HasMaxLength(20)
                    .HasColumnName("process_time")
                    .HasComment("同步到MES的時間，到秒");

                entity.Property(e => e.ProcessUser)
                    .HasMaxLength(100)
                    .HasColumnName("process_user")
                    .HasComment("同步MES的TOS JOB NAME");

                entity.Property(e => e.ProdBatch)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("prod_batch")
                    .HasComment("生產批次");

                entity.Property(e => e.Rcode)
                    .HasMaxLength(1)
                    .HasColumnName("rcode")
                    .HasComment("開補類型 是否要報工在補料工單上\r\n1-補料工單需報補料工\r\n2-補料工單不報工\r\n3-補料工單報工回原量產工單(MES無法報回原工單)=2");

                entity.Property(e => e.RightQty)
                    .HasPrecision(18, 8)
                    .HasColumnName("right_qty")
                    .HasComment("RIGHTQTY");

                entity.Property(e => e.SapOutboundTime)
                    .HasMaxLength(20)
                    .HasColumnName("sap_outbound_time")
                    .HasComment("SAP Outbound時間");

                entity.Property(e => e.SgtScat)
                    .HasMaxLength(20)
                    .HasColumnName("sgt_scat")
                    .HasComment("庫存區段");

                entity.Property(e => e.SoSize)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("so_size")
                    .HasComment("訂單SIZE");

                entity.Property(e => e.Stlal)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("stlal")
                    .HasComment("替代用料表");

                entity.Property(e => e.Stlan)
                    .HasMaxLength(1)
                    .HasColumnName("stlan")
                    .HasComment("BOM使用");

                entity.Property(e => e.Timestamp)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("timestamp")
                    .HasComment("傳送日期時間");

                entity.Property(e => e.TransId)
                    .HasMaxLength(50)
                    .HasColumnName("trans_id")
                    .HasComment("資料交換ID");

                entity.Property(e => e.Uebtk)
                    .HasMaxLength(1)
                    .HasColumnName("uebtk")
                    .HasComment("無限制的超量交貨");

                entity.Property(e => e.Uebto)
                    .HasPrecision(18, 8)
                    .HasColumnName("uebto")
                    .HasComment("超量交貨允差");

                entity.Property(e => e.Vbeln)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("vbeln")
                    .HasComment("銷售訂單號碼");

                entity.Property(e => e.Verid)
                    .HasMaxLength(20)
                    .HasColumnName("verid")
                    .HasComment("生產版本");

                entity.Property(e => e.Werks)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("werks")
                    .HasComment("工廠");

                entity.Property(e => e.WoSize)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("wo_size")
                    .HasComment("生產SIZE");

                entity.Property(e => e.ZzpartNo)
                    .HasMaxLength(20)
                    .HasColumnName("zzpart_no")
                    .HasComment("部位代號");
            });

            modelBuilder.Entity<MesIbworkmaterial>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mes_ibworkmaterial", "ap_mif");

                entity.Property(e => e.Aufnr)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("aufnr")
                    .HasComment("工單號碼");

                entity.Property(e => e.Charg)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("charg")
                    .HasComment("批次");

                entity.Property(e => e.Client)
                    .HasMaxLength(20)
                    .HasColumnName("client")
                    .HasComment("SAP Outbound Client");

                entity.Property(e => e.Component)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("component")
                    .HasComment("部位代號");

                entity.Property(e => e.CreateTime)
                    .HasMaxLength(20)
                    .HasColumnName("create_time")
                    .HasComment("寫入mif temp的時間，到秒，同一次執行的同一批資料都寫一樣");

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(100)
                    .HasColumnName("create_user")
                    .HasComment("寫入mif temp的人員，由TOS JOB寫入，則寫JOB NAME");

                entity.Property(e => e.DataBatchKey)
                    .HasMaxLength(300)
                    .HasColumnName("data_batch_key")
                    .HasComment("資料組");

                entity.Property(e => e.Dataid)
                    .HasColumnName("dataid")
                    .HasDefaultValueSql("nextval('mes_ibworkmaterial_dataid_seq'::regclass)")
                    .HasComment("數字序號");

                entity.Property(e => e.Erskz)
                    .HasMaxLength(1)
                    .HasColumnName("erskz")
                    .HasComment("裁次");

                entity.Property(e => e.FileName)
                    .HasMaxLength(50)
                    .HasColumnName("file_name")
                    .HasComment("SAP Outbound檔案名稱");

                entity.Property(e => e.Idnrk)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("idnrk")
                    .HasComment("材料料號");

                entity.Property(e => e.LeftQty)
                    .HasPrecision(18, 8)
                    .HasColumnName("left_qty")
                    .HasComment("左腳隻數");

                entity.Property(e => e.Lgort)
                    .HasMaxLength(20)
                    .HasColumnName("lgort")
                    .HasComment("領料位置");

                entity.Property(e => e.Meins)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("meins")
                    .HasComment("計量單位");

                entity.Property(e => e.Menge)
                    .HasPrecision(18, 8)
                    .HasColumnName("menge")
                    .HasComment("預計用量");

                entity.Property(e => e.MesSyncId)
                    .HasMaxLength(300)
                    .HasColumnName("mes_sync_id")
                    .HasComment("RDB到MES的ID");

                entity.Property(e => e.Posnr)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("posnr")
                    .HasComment("項次");

                entity.Property(e => e.ProcessErrmsg)
                    .HasMaxLength(300)
                    .HasColumnName("process_errmsg")
                    .HasComment("同步Mif失敗原因，失敗才有值");

                entity.Property(e => e.ProcessMk)
                    .HasMaxLength(1)
                    .HasColumnName("process_mk")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("同步Mif的註記");

                entity.Property(e => e.ProcessTime)
                    .HasMaxLength(20)
                    .HasColumnName("process_time")
                    .HasComment("同步到Mif的時間，到秒");

                entity.Property(e => e.ProcessUser)
                    .HasMaxLength(100)
                    .HasColumnName("process_user")
                    .HasComment("同步Mif的TOS JOB NAME");

                entity.Property(e => e.Rgekz)
                    .HasMaxLength(1)
                    .HasColumnName("rgekz")
                    .HasComment("倒扣帳");

                entity.Property(e => e.RightQty)
                    .HasPrecision(18, 8)
                    .HasColumnName("right_qty")
                    .HasComment("右腳隻數");

                entity.Property(e => e.Rsnum)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("rsnum")
                    .HasComment("預留單號");

                entity.Property(e => e.SapOutboundTime)
                    .HasMaxLength(20)
                    .HasColumnName("sap_outbound_time")
                    .HasComment("SAP Outbound時間");

                entity.Property(e => e.SgtRcat)
                    .HasMaxLength(20)
                    .HasColumnName("sgt_rcat")
                    .HasComment("需求區段");

                entity.Property(e => e.Timestamp)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("timestamp")
                    .HasComment("傳送日期時間");

                entity.Property(e => e.TransId)
                    .HasMaxLength(50)
                    .HasColumnName("trans_id")
                    .HasComment("資料交換ID");

                entity.Property(e => e.Vlsch)
                    .HasMaxLength(300)
                    .HasColumnName("vlsch")
                    .HasComment("開補內文");

                entity.Property(e => e.Vornr)
                    .HasMaxLength(20)
                    .HasColumnName("vornr")
                    .HasComment("作業編號");

                entity.Property(e => e.Werks)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("werks")
                    .HasComment("工廠");

                entity.Property(e => e.WerksIs)
                    .HasMaxLength(20)
                    .HasColumnName("werks_is")
                    .HasComment("發料廠");
            });

            modelBuilder.Entity<MesObbproduce>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mes_obbproduce", "ap_mif");

                entity.Property(e => e.Aufnr)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("aufnr")
                    .HasComment("工單號碼");

                entity.Property(e => e.Bmeng)
                    .HasPrecision(18, 8)
                    .HasColumnName("bmeng")
                    .HasComment("每手重量(KG)");

                entity.Property(e => e.Componentdescen)
                    .HasMaxLength(50)
                    .HasColumnName("componentdescen")
                    .HasComment("部位名稱(英文)");

                entity.Property(e => e.Componentdesczf)
                    .HasMaxLength(50)
                    .HasColumnName("componentdesczf")
                    .HasComment("部位名稱(中文)");

                entity.Property(e => e.Datagroup)
                    .HasMaxLength(256)
                    .HasColumnName("datagroup")
                    .HasComment("MES資料群組");

                entity.Property(e => e.Facility)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("facility")
                    .HasComment("廠別");

                entity.Property(e => e.Flow)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("flow")
                    .HasComment("製程代號");

                entity.Property(e => e.Formulano)
                    .HasMaxLength(300)
                    .HasColumnName("formulano")
                    .HasComment("配方代號");

                entity.Property(e => e.KbnProcessmk)
                    .HasMaxLength(1)
                    .HasColumnName("kbn_processmk")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("Kanban(看板)資料處理註記");

                entity.Property(e => e.Leftqty)
                    .HasPrecision(18, 8)
                    .HasColumnName("leftqty")
                    .HasComment("左腳派工數量");

                entity.Property(e => e.Meins)
                    .HasMaxLength(20)
                    .HasColumnName("meins")
                    .HasComment("派工單位(計量單位)");

                entity.Property(e => e.Mescomponent)
                    .HasMaxLength(20)
                    .HasColumnName("mescomponent")
                    .HasComment("部位代號");

                entity.Property(e => e.Mesresource)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("mesresource")
                    .HasComment("機台");

                entity.Property(e => e.Moldbarcode)
                    .HasMaxLength(256)
                    .HasColumnName("moldbarcode")
                    .HasComment("模具條碼");

                entity.Property(e => e.Molddescription)
                    .HasMaxLength(256)
                    .HasColumnName("molddescription")
                    .HasComment("MES模具說明");

                entity.Property(e => e.Moldname)
                    .HasMaxLength(256)
                    .HasColumnName("moldname")
                    .HasComment("MES模具名稱");

                entity.Property(e => e.Outboundtime)
                    .HasMaxLength(14)
                    .HasColumnName("outboundtime")
                    .HasComment("OutBoundTime");

                entity.Property(e => e.Perqty)
                    .HasPrecision(18, 8)
                    .HasColumnName("perqty")
                    .HasComment("手數");

                entity.Property(e => e.Plnbez)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("plnbez")
                    .HasComment("產出料號");

                entity.Property(e => e.Processmk)
                    .HasMaxLength(1)
                    .HasColumnName("processmk")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("ERP資料處理註記");

                entity.Property(e => e.Producedate)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("producedate")
                    .IsFixedLength(true)
                    .HasComment("製令日期");

                entity.Property(e => e.Produceitem)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("produceitem")
                    .HasComment("製令項次");

                entity.Property(e => e.Produceno)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("produceno")
                    .HasComment("製令號碼");

                entity.Property(e => e.Producestatus)
                    .IsRequired()
                    .HasMaxLength(512)
                    .HasColumnName("producestatus")
                    .HasComment("製令單狀態 (P=已列印 , T=Terminate)");

                entity.Property(e => e.Producttype)
                    .IsRequired()
                    .HasMaxLength(512)
                    .HasColumnName("producttype")
                    .HasComment("產品類別");

                entity.Property(e => e.Qty)
                    .HasPrecision(18, 8)
                    .HasColumnName("qty")
                    .HasComment("派工數量(生產數量)");

                entity.Property(e => e.ReceiveTime)
                    .HasMaxLength(14)
                    .HasColumnName("receive_time")
                    .HasComment("外圍接收時間");

                entity.Property(e => e.Resourcegroup)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("resourcegroup")
                    .HasComment("機群");

                entity.Property(e => e.Rightqty)
                    .HasPrecision(18, 8)
                    .HasColumnName("rightqty")
                    .HasComment("右腳派工數量");

                entity.Property(e => e.Shiftdefinitionshift)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("shiftdefinitionshift")
                    .HasComment("製令單班別");

                entity.Property(e => e.Universalstate)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("universalstate")
                    .HasDefaultValueSql("' '::character varying")
                    .HasComment("製令單狀態");

                entity.Property(e => e.WebProcessmk)
                    .HasMaxLength(1)
                    .HasColumnName("web_processmk")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("WEB資料處理註記");

                entity.Property(e => e.Wosize)
                    .HasMaxLength(50)
                    .HasColumnName("wosize")
                    .HasComment("生產SIZE");

                entity.Property(e => e.Zzatcolr)
                    .HasMaxLength(100)
                    .HasColumnName("zzatcolr")
                    .HasComment("型體顏色");

                entity.Property(e => e.Zzcolorcode)
                    .HasMaxLength(50)
                    .HasColumnName("zzcolorcode")
                    .HasComment("部位顏色代號");

                entity.Property(e => e.Zzmdmark)
                    .HasMaxLength(300)
                    .HasColumnName("zzmdmark")
                    .HasComment("型體代號+顏色代號");

                entity.Property(e => e.Zzmdnam)
                    .HasMaxLength(300)
                    .HasColumnName("zzmdnam")
                    .HasComment("型體名稱");

                entity.Property(e => e.Zzmidsolmod)
                    .HasMaxLength(100)
                    .HasColumnName("zzmidsolmod")
                    .HasComment("中底代號");

                entity.Property(e => e.Zzoutsolmod)
                    .HasMaxLength(100)
                    .HasColumnName("zzoutsolmod")
                    .HasComment("外底代號");

                entity.Property(e => e.Zzstylcode)
                    .HasMaxLength(50)
                    .HasColumnName("zzstylcode")
                    .HasComment("型體代號");
            });

            modelBuilder.Entity<MesObsoleprod>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mes_obsoleprod", "ap_mif");

                entity.Property(e => e.ActShift)
                    .HasMaxLength(256)
                    .HasColumnName("act_shift")
                    .HasComment("實際班別");

                entity.Property(e => e.ActWorkdate)
                    .HasMaxLength(8)
                    .HasColumnName("act_workdate")
                    .HasComment("實際生產日期");

                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("action")
                    .HasComment("TrackIn / TrackOut");

                entity.Property(e => e.Arbpl)
                    .HasMaxLength(20)
                    .HasColumnName("arbpl")
                    .HasComment("工作中心");

                entity.Property(e => e.Auart)
                    .HasMaxLength(20)
                    .HasColumnName("auart")
                    .HasComment("工單類型");

                entity.Property(e => e.Aufnr)
                    .HasMaxLength(20)
                    .HasColumnName("aufnr")
                    .HasComment("工單號碼");

                entity.Property(e => e.Bmeng)
                    .HasPrecision(18, 8)
                    .HasColumnName("bmeng")
                    .HasComment("每手重量(KG)");

                entity.Property(e => e.Brandid)
                    .HasMaxLength(20)
                    .HasColumnName("brandid")
                    .HasComment("品牌");

                entity.Property(e => e.Componentdescen)
                    .HasMaxLength(50)
                    .HasColumnName("componentdescen")
                    .HasComment("部位名稱(英文)");

                entity.Property(e => e.Componentdesczf)
                    .HasMaxLength(50)
                    .HasColumnName("componentdesczf")
                    .HasComment("部位名稱(中文)");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .HasColumnName("createby")
                    .HasComment("Obtemp資料建立人員");

                entity.Property(e => e.Createon)
                    .HasMaxLength(14)
                    .HasColumnName("createon")
                    .IsFixedLength(true)
                    .HasComment("Obtemp建立時間");

                entity.Property(e => e.Datagroup)
                    .HasMaxLength(256)
                    .HasColumnName("datagroup")
                    .HasComment("資料群組");

                entity.Property(e => e.Empid)
                    .HasMaxLength(20)
                    .HasColumnName("empid")
                    .HasComment("人員集團ID");

                entity.Property(e => e.Facility)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("facility")
                    .HasComment("Facility");

                entity.Property(e => e.Feedto)
                    .HasMaxLength(256)
                    .HasColumnName("feedto")
                    .HasComment("貨批綁定號");

                entity.Property(e => e.Flow)
                    .HasMaxLength(100)
                    .HasColumnName("flow")
                    .HasComment("FLOW");

                entity.Property(e => e.Formulano)
                    .HasMaxLength(300)
                    .HasColumnName("formulano")
                    .HasComment("配方代號");

                entity.Property(e => e.KbnProcessmk)
                    .HasMaxLength(1)
                    .HasColumnName("kbn_processmk")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("Kanban(看板)資料處理註記");

                entity.Property(e => e.Leftqty)
                    .HasPrecision(18, 8)
                    .HasColumnName("leftqty")
                    .HasComment("左腳派工數量");

                entity.Property(e => e.Maktx)
                    .HasMaxLength(50)
                    .HasColumnName("maktx")
                    .HasComment("產出說明");

                entity.Property(e => e.Materialname)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("materialname")
                    .HasComment("Lot ID");

                entity.Property(e => e.Materialtype)
                    .HasMaxLength(512)
                    .HasColumnName("materialtype")
                    .HasComment("MaterialType");

                entity.Property(e => e.Mescomponent)
                    .HasMaxLength(20)
                    .HasColumnName("mescomponent")
                    .HasComment("部位代號");

                entity.Property(e => e.Mesresource)
                    .HasMaxLength(256)
                    .HasColumnName("mesresource")
                    .HasComment("MES機台");

                entity.Property(e => e.Obtempname)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("obtempname")
                    .HasComment("ObTemp.Name");

                entity.Property(e => e.Opgroupno)
                    .HasMaxLength(100)
                    .HasColumnName("opgroupno")
                    .HasComment("組別(TrackOut人員/組別)");

                entity.Property(e => e.Opno)
                    .HasMaxLength(300)
                    .HasColumnName("opno")
                    .HasComment("OP No.(作業代碼)");

                entity.Property(e => e.Outboundtime)
                    .HasMaxLength(14)
                    .HasColumnName("outboundtime")
                    .IsFixedLength(true)
                    .HasComment("OutBound時間");

                entity.Property(e => e.Plnbez)
                    .HasMaxLength(20)
                    .HasColumnName("plnbez")
                    .HasComment("產出料號");

                entity.Property(e => e.Posnr)
                    .HasMaxLength(20)
                    .HasColumnName("posnr")
                    .HasComment("訂單號碼項次");

                entity.Property(e => e.Primaryquantity)
                    .HasPrecision(18, 8)
                    .HasColumnName("primaryquantity")
                    .HasComment("數量");

                entity.Property(e => e.Primaryunits)
                    .HasMaxLength(512)
                    .HasColumnName("primaryunits")
                    .HasComment("單位");

                entity.Property(e => e.Processmk)
                    .HasMaxLength(1)
                    .HasColumnName("processmk")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("ERP資料處理註記");

                entity.Property(e => e.Prodbatch)
                    .HasMaxLength(20)
                    .HasColumnName("prodbatch")
                    .HasComment("生產批次");

                entity.Property(e => e.Producedate)
                    .HasMaxLength(8)
                    .HasColumnName("producedate")
                    .IsFixedLength(true)
                    .HasComment("製令日期");

                entity.Property(e => e.Produceitem)
                    .HasMaxLength(20)
                    .HasColumnName("produceitem")
                    .HasComment("製令項次");

                entity.Property(e => e.Produceno)
                    .HasMaxLength(20)
                    .HasColumnName("produceno")
                    .HasComment("製令號碼");

                entity.Property(e => e.Producttype)
                    .HasMaxLength(512)
                    .HasColumnName("producttype")
                    .HasComment("產品類別");

                entity.Property(e => e.Rcode)
                    .HasMaxLength(1)
                    .HasColumnName("rcode")
                    .HasComment("開補類型");

                entity.Property(e => e.ReceiveTime)
                    .HasMaxLength(14)
                    .HasColumnName("receive_time")
                    .HasComment("外圍接收時間");

                entity.Property(e => e.Resourcegroup)
                    .HasMaxLength(256)
                    .HasColumnName("resourcegroup")
                    .HasComment("MES機群");

                entity.Property(e => e.Returnmk)
                    .HasMaxLength(1)
                    .HasColumnName("returnmk")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("退料註記(Y/N)");

                entity.Property(e => e.Rightqty)
                    .HasPrecision(18, 8)
                    .HasColumnName("rightqty")
                    .HasComment("右腳派工數量");

                entity.Property(e => e.Sapdefecttype)
                    .HasMaxLength(50)
                    .HasColumnName("sapdefecttype")
                    .HasComment("SAP不良類型");

                entity.Property(e => e.Sgtscat)
                    .HasMaxLength(20)
                    .HasColumnName("sgtscat")
                    .HasComment("庫存區段");

                entity.Property(e => e.Shiftdefinitionshift)
                    .HasMaxLength(256)
                    .HasColumnName("shiftdefinitionshift")
                    .HasComment("班別");

                entity.Property(e => e.Sosize)
                    .HasMaxLength(50)
                    .HasColumnName("sosize")
                    .HasComment("訂單Size");

                entity.Property(e => e.Stand)
                    .HasMaxLength(20)
                    .HasColumnName("stand")
                    .HasComment("SAP產出位置");

                entity.Property(e => e.Stepname)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("stepname")
                    .HasComment("MES站點");

                entity.Property(e => e.Timmeron)
                    .HasMaxLength(14)
                    .HasColumnName("timmeron")
                    .IsFixedLength(true)
                    .HasComment("轉入RDB時間");

                entity.Property(e => e.Vbeln)
                    .HasMaxLength(20)
                    .HasColumnName("vbeln")
                    .HasComment("訂單號碼");

                entity.Property(e => e.Vornr)
                    .HasMaxLength(20)
                    .HasColumnName("vornr")
                    .HasComment("作業編號");

                entity.Property(e => e.WebProcessmk)
                    .HasMaxLength(1)
                    .HasColumnName("web_processmk")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("WEB資料處理註記");

                entity.Property(e => e.Werks)
                    .HasMaxLength(20)
                    .HasColumnName("werks")
                    .HasComment("工廠");

                entity.Property(e => e.Wosize)
                    .HasMaxLength(50)
                    .HasColumnName("wosize")
                    .HasComment("生產SIZE");

                entity.Property(e => e.Zpack)
                    .HasMaxLength(50)
                    .HasColumnName("zpack")
                    .HasComment("包裝規格");

                entity.Property(e => e.Zzatcolr)
                    .HasMaxLength(100)
                    .HasColumnName("zzatcolr")
                    .HasComment("型體顏色");

                entity.Property(e => e.Zzcolorcode)
                    .HasMaxLength(50)
                    .HasColumnName("zzcolorcode")
                    .HasComment("顏色代號");

                entity.Property(e => e.Zzmdmark)
                    .HasMaxLength(300)
                    .HasColumnName("zzmdmark")
                    .HasComment("型體代號+顏色代號(Article)");

                entity.Property(e => e.Zzmdnam)
                    .HasMaxLength(300)
                    .HasColumnName("zzmdnam")
                    .HasComment("型體名稱");

                entity.Property(e => e.Zzmidsolmod)
                    .HasMaxLength(100)
                    .HasColumnName("zzmidsolmod")
                    .HasComment("中底代號");

                entity.Property(e => e.Zzoutsolmod)
                    .HasMaxLength(100)
                    .HasColumnName("zzoutsolmod")
                    .HasComment("外底代號");

                entity.Property(e => e.Zzstylcode)
                    .HasMaxLength(50)
                    .HasColumnName("zzstylcode")
                    .HasComment("型體代號");
            });

            modelBuilder.Entity<MesObzqmd>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mes_obzqmd", "ap_mif");

                entity.Property(e => e.Approvetime)
                    .HasMaxLength(14)
                    .HasColumnName("approvetime")
                    .HasComment("審核時間註記");

                entity.Property(e => e.Aufnr)
                    .HasMaxLength(20)
                    .HasColumnName("aufnr")
                    .HasComment("工單號碼");

                entity.Property(e => e.Brandid)
                    .HasMaxLength(50)
                    .HasColumnName("brandid")
                    .HasComment("品牌");

                entity.Property(e => e.Componentdescen)
                    .HasMaxLength(50)
                    .HasColumnName("componentdescen")
                    .HasComment("部位名稱(英)");

                entity.Property(e => e.Componentdesczf)
                    .HasMaxLength(50)
                    .HasColumnName("componentdesczf")
                    .HasComment("部位名稱(中)");

                entity.Property(e => e.Createdby)
                    .HasMaxLength(100)
                    .HasColumnName("createdby")
                    .HasComment("資料建立人員");

                entity.Property(e => e.Createdon)
                    .HasMaxLength(14)
                    .HasColumnName("createdon")
                    .HasComment("Tranaction時間");

                entity.Property(e => e.Datagroup)
                    .HasMaxLength(256)
                    .HasColumnName("datagroup")
                    .HasComment("資料群組");

                entity.Property(e => e.Defectcode)
                    .HasMaxLength(50)
                    .HasColumnName("defectcode")
                    .HasComment("不良原因代碼");

                entity.Property(e => e.Defectdesclocal)
                    .HasMaxLength(200)
                    .HasColumnName("defectdesclocal")
                    .HasComment("不良原因說明(Local)");

                entity.Property(e => e.Defectdesczf)
                    .HasMaxLength(200)
                    .HasColumnName("defectdesczf")
                    .HasComment("不良原因說明(中)");

                entity.Property(e => e.Defectkind)
                    .HasMaxLength(50)
                    .HasColumnName("defectkind")
                    .HasComment("不良分類代號");

                entity.Property(e => e.Defectkinddesclocal)
                    .HasMaxLength(200)
                    .HasColumnName("defectkinddesclocal")
                    .HasComment("不良分類說明(Local)");

                entity.Property(e => e.Defectkinddesczf)
                    .HasMaxLength(200)
                    .HasColumnName("defectkinddesczf")
                    .HasComment("不良分類說明(中)");

                entity.Property(e => e.Defectqty)
                    .HasPrecision(18, 8)
                    .HasColumnName("defectqty")
                    .HasComment("不良數量");

                entity.Property(e => e.Empid)
                    .HasMaxLength(20)
                    .HasColumnName("empid")
                    .HasComment("操作人員集團ID");

                entity.Property(e => e.Facility)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("facility")
                    .HasComment("工廠名稱");

                entity.Property(e => e.Foqcno)
                    .HasMaxLength(20)
                    .HasColumnName("foqcno")
                    .HasComment("驗貨單號");

                entity.Property(e => e.Formulano)
                    .HasMaxLength(300)
                    .HasColumnName("formulano")
                    .HasComment("配方代號");

                entity.Property(e => e.Isdelete)
                    .HasMaxLength(1)
                    .HasColumnName("isdelete")
                    .HasComment("是否被刪除");

                entity.Property(e => e.KbnProcessmk)
                    .HasMaxLength(1)
                    .HasColumnName("kbn_processmk")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("Kanban(看板)資料處理註記");

                entity.Property(e => e.Leftqty)
                    .HasPrecision(18, 8)
                    .HasColumnName("leftqty")
                    .HasComment("左腳不良支數");

                entity.Property(e => e.Memo)
                    .HasMaxLength(512)
                    .HasColumnName("memo")
                    .HasComment("驗貨註記");

                entity.Property(e => e.Mescomponent)
                    .HasMaxLength(20)
                    .HasColumnName("mescomponent")
                    .HasComment("部位代號");

                entity.Property(e => e.Mesresource)
                    .HasMaxLength(256)
                    .HasColumnName("mesresource")
                    .HasComment("MES機台");

                entity.Property(e => e.Modifiedby)
                    .HasMaxLength(100)
                    .HasColumnName("modifiedby")
                    .HasComment("資料異動人員");

                entity.Property(e => e.Modifiedon)
                    .HasMaxLength(14)
                    .HasColumnName("modifiedon")
                    .HasComment("修改日期");

                entity.Property(e => e.Moldbarcode)
                    .HasMaxLength(50)
                    .HasColumnName("moldbarcode")
                    .HasComment("MES模號條碼");

                entity.Property(e => e.Molddescription)
                    .HasMaxLength(256)
                    .HasColumnName("molddescription")
                    .HasComment("MES模號說明");

                entity.Property(e => e.Moldname)
                    .HasMaxLength(256)
                    .HasColumnName("moldname")
                    .HasComment("MES模號名稱");

                entity.Property(e => e.Orderlevel)
                    .HasMaxLength(20)
                    .HasColumnName("orderlevel")
                    .HasComment("訂單等級");

                entity.Property(e => e.Orderqty)
                    .HasPrecision(18, 8)
                    .HasColumnName("orderqty")
                    .HasComment("訂單數量");

                entity.Property(e => e.Outboundtime)
                    .HasMaxLength(14)
                    .HasColumnName("outboundtime")
                    .HasComment("OutBound RDB時間(Sole)");

                entity.Property(e => e.Plnbez)
                    .HasMaxLength(20)
                    .HasColumnName("plnbez")
                    .HasComment("產出料號");

                entity.Property(e => e.Processmk)
                    .HasMaxLength(1)
                    .HasColumnName("processmk")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("ERP資料處理註記");

                entity.Property(e => e.Prodbatch)
                    .HasMaxLength(20)
                    .HasColumnName("prodbatch")
                    .HasComment("生產批次");

                entity.Property(e => e.Produceitem)
                    .HasMaxLength(20)
                    .HasColumnName("produceitem")
                    .HasComment("製令項次");

                entity.Property(e => e.Produceno)
                    .HasMaxLength(20)
                    .HasColumnName("produceno")
                    .HasComment("製令號碼");

                entity.Property(e => e.Productdate)
                    .HasMaxLength(8)
                    .HasColumnName("productdate")
                    .IsFixedLength(true)
                    .HasComment("實際檢驗日期");

                entity.Property(e => e.Producttype)
                    .HasMaxLength(512)
                    .HasColumnName("producttype")
                    .HasComment("產品類別");

                entity.Property(e => e.Qclevel)
                    .HasMaxLength(20)
                    .HasColumnName("qclevel")
                    .HasComment("驗貨等級");

                entity.Property(e => e.Qcqty)
                    .HasPrecision(18, 8)
                    .HasColumnName("qcqty")
                    .HasComment("驗貨數量");

                entity.Property(e => e.ReceiveTime)
                    .HasMaxLength(14)
                    .HasColumnName("receive_time")
                    .HasComment("外圍接收時間");

                entity.Property(e => e.Resourcegroup)
                    .HasMaxLength(256)
                    .HasColumnName("resourcegroup")
                    .HasComment("MES機群");

                entity.Property(e => e.Rightqty)
                    .HasPrecision(18, 8)
                    .HasColumnName("rightqty")
                    .HasComment("右腳不良支數");

                entity.Property(e => e.Sapdefecttype)
                    .HasMaxLength(50)
                    .HasColumnName("sapdefecttype")
                    .HasComment("SAP不良類型");

                entity.Property(e => e.Shiftdefinitionshift)
                    .HasMaxLength(256)
                    .HasColumnName("shiftdefinitionshift")
                    .HasComment("班別");

                entity.Property(e => e.Step)
                    .HasMaxLength(256)
                    .HasColumnName("step")
                    .HasComment("MES站點");

                entity.Property(e => e.Sublineno)
                    .HasMaxLength(20)
                    .HasColumnName("sublineno")
                    .HasComment("線別");

                entity.Property(e => e.Timmeron)
                    .HasMaxLength(14)
                    .HasColumnName("timmeron")
                    .HasComment("Timmer轉入RDB時間(Sole)");

                entity.Property(e => e.Vbeln)
                    .HasMaxLength(20)
                    .HasColumnName("vbeln")
                    .HasComment("訂單號碼");

                entity.Property(e => e.WebProcessmk)
                    .HasMaxLength(1)
                    .HasColumnName("web_processmk")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("WEB資料處理註記");

                entity.Property(e => e.Werks)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("werks")
                    .HasComment("廠別");

                entity.Property(e => e.Wosize)
                    .HasMaxLength(50)
                    .HasColumnName("wosize")
                    .HasComment("生產SIZE");

                entity.Property(e => e.Zqmdname)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("zqmdname")
                    .HasComment("ZQmDName");

                entity.Property(e => e.Zzactresult)
                    .HasMaxLength(1)
                    .HasColumnName("zzactresult")
                    .HasComment("實際檢驗結果");

                entity.Property(e => e.Zzatcolr)
                    .HasMaxLength(100)
                    .HasColumnName("zzatcolr")
                    .HasComment("型體顏色");

                entity.Property(e => e.Zzbatchid)
                    .HasMaxLength(2)
                    .HasColumnName("zzbatchid")
                    .IsFixedLength(true)
                    .HasComment("外部驗貨批次號");

                entity.Property(e => e.Zzcolorcode)
                    .HasMaxLength(50)
                    .HasColumnName("zzcolorcode")
                    .HasComment("部位顏色代號");

                entity.Property(e => e.Zzmdmark)
                    .HasMaxLength(50)
                    .HasColumnName("zzmdmark")
                    .HasComment("型體代號+顏色代號(Article)");

                entity.Property(e => e.Zzmdnam)
                    .HasMaxLength(300)
                    .HasColumnName("zzmdnam")
                    .HasComment("型體名稱");

                entity.Property(e => e.Zzmidsolmod)
                    .HasMaxLength(100)
                    .HasColumnName("zzmidsolmod")
                    .HasComment("中底代號");

                entity.Property(e => e.Zzoutsolmod)
                    .HasMaxLength(100)
                    .HasColumnName("zzoutsolmod")
                    .HasComment("外底代號");

                entity.Property(e => e.Zzstylcode)
                    .HasMaxLength(50)
                    .HasColumnName("zzstylcode")
                    .HasComment("型體代號");
            });

            modelBuilder.Entity<MesOutboundaopgroupctrl>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mes_outboundaopgroupctrl", "ap_mif");

                entity.HasComment("廠別線別儲位設定");

                entity.Property(e => e.Arbpl)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("arbpl")
                    .HasComment("SAP 工作中心");

                entity.Property(e => e.Buildno)
                    .HasMaxLength(100)
                    .HasColumnName("buildno");

                entity.Property(e => e.CreateTime)
                    .HasMaxLength(20)
                    .HasColumnName("create_time");

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(100)
                    .HasColumnName("create_user");

                entity.Property(e => e.Createdon)
                    .HasMaxLength(14)
                    .HasColumnName("createdon")
                    .HasComment("AOPGroupCtrl.CreatedOn");

                entity.Property(e => e.Datagroup)
                    .HasMaxLength(256)
                    .HasColumnName("datagroup");

                entity.Property(e => e.Deptno)
                    .HasMaxLength(100)
                    .HasColumnName("deptno");

                entity.Property(e => e.Extensionnv1)
                    .HasMaxLength(300)
                    .HasColumnName("extensionnv1")
                    .HasComment("SAP 儲位(工作中心對應的的面底配套的儲存位置)");

                entity.Property(e => e.Extensionnv2)
                    .HasMaxLength(300)
                    .HasColumnName("extensionnv2");

                entity.Property(e => e.Extensionnv3)
                    .HasMaxLength(300)
                    .HasColumnName("extensionnv3");

                entity.Property(e => e.Extensionnv4)
                    .HasMaxLength(300)
                    .HasColumnName("extensionnv4");

                entity.Property(e => e.Extensionnv5)
                    .HasMaxLength(300)
                    .HasColumnName("extensionnv5");

                entity.Property(e => e.Extensionnv6)
                    .HasMaxLength(300)
                    .HasColumnName("extensionnv6");

                entity.Property(e => e.Extensionnv7)
                    .HasMaxLength(300)
                    .HasColumnName("extensionnv7");

                entity.Property(e => e.Extensionnv8)
                    .HasMaxLength(300)
                    .HasColumnName("extensionnv8");

                entity.Property(e => e.Facilityname)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("facilityname")
                    .HasComment("MESFacility");

                entity.Property(e => e.Factoryno)
                    .HasMaxLength(100)
                    .HasColumnName("factoryno");

                entity.Property(e => e.Mainlineno)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("mainlineno");

                entity.Property(e => e.Modifiedon)
                    .HasMaxLength(14)
                    .HasColumnName("modifiedon")
                    .HasComment("AOPGroupCtrl.ModifiedOn");

                entity.Property(e => e.Opgroupdesc)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("opgroupdesc");

                entity.Property(e => e.Opgroupname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("opgroupname");

                entity.Property(e => e.Opgroupno)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("opgroupno");

                entity.Property(e => e.Pressmk)
                    .HasMaxLength(1)
                    .HasColumnName("pressmk")
                    .HasComment("外圍取走資料寫入Y(新增/更新寫N)");

                entity.Property(e => e.ProcessErrmsg)
                    .HasMaxLength(300)
                    .HasColumnName("process_errmsg");

                entity.Property(e => e.ProcessTime)
                    .HasMaxLength(20)
                    .HasColumnName("process_time");

                entity.Property(e => e.ProcessUser)
                    .HasMaxLength(100)
                    .HasColumnName("process_user");

                entity.Property(e => e.Resourcename)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("resourcename")
                    .HasComment("MESResource");

                entity.Property(e => e.Stand)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("stand")
                    .HasComment("SAP儲位(最長只能設定 4碼)工作中心對應的產出位置");

                entity.Property(e => e.Stepname)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("stepname")
                    .HasComment("MESStep");

                entity.Property(e => e.Stopmk)
                    .HasMaxLength(1)
                    .HasColumnName("stopmk")
                    .HasComment("預設 N");

                entity.Property(e => e.Sublineno)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("sublineno")
                    .HasComment("不可以超過20 碼");

                entity.Property(e => e.Timmeron)
                    .HasMaxLength(14)
                    .HasColumnName("timmeron")
                    .HasComment("MES寫入RDB時間(YYYYMMDDHHmm)");
            });

            modelBuilder.Entity<MesOutboundaqmd>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mes_outboundaqmd", "ap_mif");

                entity.Property(e => e.Approvetime)
                    .HasMaxLength(14)
                    .HasColumnName("approvetime")
                    .HasComment("審核時間註記，SYSDATE Format : YYYYMMDDHH24MiSS");

                entity.Property(e => e.Brandid)
                    .HasMaxLength(50)
                    .HasColumnName("brandid")
                    .HasComment("品牌");

                entity.Property(e => e.CreateTime)
                    .HasMaxLength(20)
                    .HasColumnName("create_time")
                    .HasComment("抄寫到Temp時間");

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(100)
                    .HasColumnName("create_user")
                    .HasComment("抄寫Temp排程");

                entity.Property(e => e.Createdby)
                    .HasMaxLength(100)
                    .HasColumnName("createdby")
                    .HasComment("MES原生欄位");

                entity.Property(e => e.Createdon)
                    .HasMaxLength(14)
                    .HasColumnName("createdon")
                    .HasComment("MES原生欄位");

                entity.Property(e => e.Defectcode)
                    .HasMaxLength(50)
                    .HasColumnName("defectcode")
                    .HasComment("不良原因代碼");

                entity.Property(e => e.Defectdesclocal)
                    .HasMaxLength(200)
                    .HasColumnName("defectdesclocal")
                    .HasComment("不良原因說明(Local)");

                entity.Property(e => e.Defectdesctw)
                    .HasMaxLength(200)
                    .HasColumnName("defectdesctw")
                    .HasComment("不良原因說明(中)");

                entity.Property(e => e.Defectqty)
                    .HasPrecision(18, 3)
                    .HasColumnName("defectqty")
                    .HasComment("不良數量");

                entity.Property(e => e.Defecttype)
                    .HasMaxLength(50)
                    .HasColumnName("defecttype")
                    .HasComment("不良分類代號");

                entity.Property(e => e.Defectypedsclocal)
                    .HasMaxLength(200)
                    .HasColumnName("defectypedsclocal")
                    .HasComment("不良分類說明(Local)");

                entity.Property(e => e.Defectypedsctw)
                    .HasMaxLength(200)
                    .HasColumnName("defectypedsctw")
                    .HasComment("不良分類說明(中)");

                entity.Property(e => e.Facilityname)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("facilityname")
                    .HasComment("VYSh_VNdn");

                entity.Property(e => e.Foqcno)
                    .HasMaxLength(20)
                    .HasColumnName("foqcno")
                    .HasComment("驗貨單號，FI+YYMMDD+三碼流水碼");

                entity.Property(e => e.Isdelete)
                    .HasMaxLength(1)
                    .HasColumnName("isdelete")
                    .HasComment("Y=已刪除");

                entity.Property(e => e.Leftqty)
                    .HasPrecision(18, 3)
                    .HasColumnName("leftqty")
                    .HasComment("左腳不良支數");

                entity.Property(e => e.Memo)
                    .HasMaxLength(150)
                    .HasColumnName("memo")
                    .HasComment("驗貨註記");

                entity.Property(e => e.Modifiedon)
                    .HasMaxLength(14)
                    .HasColumnName("modifiedon")
                    .HasComment("資料更改日期");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("name")
                    .HasComment("SAP不良類型{SAPDefectType }+建立日期yyyymmddHHmmss+兩碼流水碼");

                entity.Property(e => e.Orderid)
                    .HasMaxLength(20)
                    .HasColumnName("orderid")
                    .HasComment("訂單號碼");

                entity.Property(e => e.Orderlevel)
                    .HasMaxLength(20)
                    .HasColumnName("orderlevel")
                    .HasComment("訂單等級");

                entity.Property(e => e.Orderqty)
                    .HasMaxLength(20)
                    .HasColumnName("orderqty")
                    .HasComment("訂單數量");

                entity.Property(e => e.Outboundtime)
                    .HasMaxLength(14)
                    .HasColumnName("outboundtime")
                    .HasComment("OutBound時間註記，SYSDATE Format : YYYYMMDDHH24MiSS");

                entity.Property(e => e.Part)
                    .HasMaxLength(256)
                    .HasColumnName("part")
                    .HasComment("部位名稱");

                entity.Property(e => e.Partno)
                    .HasMaxLength(20)
                    .HasColumnName("partno")
                    .HasComment("部位代號");

                entity.Property(e => e.Plnbez)
                    .HasMaxLength(20)
                    .HasColumnName("plnbez")
                    .HasComment("產出料號");

                entity.Property(e => e.ProcessErrmsg)
                    .HasMaxLength(300)
                    .HasColumnName("process_errmsg")
                    .HasComment("抄寫到MIF錯誤訊息");

                entity.Property(e => e.ProcessMk)
                    .HasMaxLength(1)
                    .HasColumnName("process_mk")
                    .HasComment("ERP資料處理註記，外圍取走資料寫入Y");

                entity.Property(e => e.ProcessTime)
                    .HasMaxLength(20)
                    .HasColumnName("process_time")
                    .HasComment("抄寫到MIF時間");

                entity.Property(e => e.ProcessUser)
                    .HasMaxLength(100)
                    .HasColumnName("process_user")
                    .HasComment("抄寫到MIF排程");

                entity.Property(e => e.Processmk1)
                    .HasMaxLength(1)
                    .HasColumnName("processmk");

                entity.Property(e => e.Productdate)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("productdate")
                    .IsFixedLength(true)
                    .HasComment("實際製令檢驗日期");

                entity.Property(e => e.Productno)
                    .HasMaxLength(20)
                    .HasColumnName("productno")
                    .HasComment("工單號碼");

                entity.Property(e => e.Producttime)
                    .HasMaxLength(20)
                    .HasColumnName("producttime")
                    .HasComment("實際檢驗日回報時段");

                entity.Property(e => e.Producttype)
                    .IsRequired()
                    .HasMaxLength(512)
                    .HasColumnName("producttype")
                    .HasComment("產品類別");

                entity.Property(e => e.Qclevel)
                    .HasMaxLength(20)
                    .HasColumnName("qclevel")
                    .HasComment("驗貨等級");

                entity.Property(e => e.Qcqty)
                    .HasPrecision(18, 3)
                    .HasColumnName("qcqty")
                    .HasComment("驗貨數量");

                entity.Property(e => e.Rightqty)
                    .HasPrecision(18, 3)
                    .HasColumnName("rightqty")
                    .HasComment("右腳不良支數");

                entity.Property(e => e.Sapdefecttype)
                    .HasMaxLength(50)
                    .HasColumnName("sapdefecttype")
                    .HasComment("SAP不良類型");

                entity.Property(e => e.Shiftdefinitionshift)
                    .HasMaxLength(256)
                    .HasColumnName("shiftdefinitionshift")
                    .HasComment("班別");

                entity.Property(e => e.Sizeno)
                    .HasMaxLength(50)
                    .HasColumnName("sizeno")
                    .HasComment("生產size");

                entity.Property(e => e.Stepname)
                    .HasMaxLength(256)
                    .HasColumnName("stepname")
                    .HasComment("站點");

                entity.Property(e => e.Sublineno)
                    .HasMaxLength(20)
                    .HasColumnName("sublineno")
                    .HasComment("線別");

                entity.Property(e => e.Timmeron)
                    .HasMaxLength(14)
                    .HasColumnName("timmeron")
                    .HasComment("MES拋到RDB時間(yyyymmddhhmmss)");

                entity.Property(e => e.Werks)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("werks")
                    .HasComment("廠別");

                entity.Property(e => e.Zzactresult)
                    .HasMaxLength(1)
                    .HasColumnName("zzactresult")
                    .HasComment("實際檢驗結果，\"Y=準收(Accepted)\r\nN=未通過(Reject)\"");

                entity.Property(e => e.Zzbatchid)
                    .HasMaxLength(2)
                    .HasColumnName("zzbatchid")
                    .IsFixedLength(true)
                    .HasComment("外部驗貨批次號");

                entity.Property(e => e.Zzmdmark)
                    .HasMaxLength(300)
                    .HasColumnName("zzmdmark")
                    .HasComment("型體代號+顏色代號(Article)");
            });

            modelBuilder.Entity<MesOutboundaqmdTest>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mes_outboundaqmd_test", "ap_mif");

                entity.Property(e => e.Approvetime)
                    .HasMaxLength(14)
                    .HasColumnName("approvetime")
                    .HasComment("SYSDATE Format : YYYYMMDDHH24MiSS");

                entity.Property(e => e.Brandid)
                    .HasMaxLength(50)
                    .HasColumnName("brandid");

                entity.Property(e => e.CreateTime)
                    .HasMaxLength(20)
                    .HasColumnName("create_time");

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(100)
                    .HasColumnName("create_user");

                entity.Property(e => e.Createdby)
                    .HasMaxLength(100)
                    .HasColumnName("createdby");

                entity.Property(e => e.Createdon)
                    .HasMaxLength(14)
                    .HasColumnName("createdon");

                entity.Property(e => e.Defectcode)
                    .HasMaxLength(50)
                    .HasColumnName("defectcode");

                entity.Property(e => e.Defectdesclocal)
                    .HasMaxLength(200)
                    .HasColumnName("defectdesclocal");

                entity.Property(e => e.Defectdesctw)
                    .HasMaxLength(200)
                    .HasColumnName("defectdesctw");

                entity.Property(e => e.Defectqty)
                    .HasPrecision(18, 3)
                    .HasColumnName("defectqty");

                entity.Property(e => e.Defecttype)
                    .HasMaxLength(50)
                    .HasColumnName("defecttype");

                entity.Property(e => e.Defectypedsclocal)
                    .HasMaxLength(200)
                    .HasColumnName("defectypedsclocal");

                entity.Property(e => e.Defectypedsctw)
                    .HasMaxLength(200)
                    .HasColumnName("defectypedsctw");

                entity.Property(e => e.Facilityname)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("facilityname")
                    .HasComment("VYSh_VNdn");

                entity.Property(e => e.Foqcno)
                    .HasMaxLength(20)
                    .HasColumnName("foqcno")
                    .HasComment("FI+YYMMDD+三碼流水碼");

                entity.Property(e => e.Isdelete)
                    .HasMaxLength(1)
                    .HasColumnName("isdelete")
                    .HasComment("Y=已刪除");

                entity.Property(e => e.Leftqty)
                    .HasPrecision(18, 3)
                    .HasColumnName("leftqty");

                entity.Property(e => e.Memo)
                    .HasMaxLength(150)
                    .HasColumnName("memo");

                entity.Property(e => e.Modifiedon)
                    .HasMaxLength(14)
                    .HasColumnName("modifiedon")
                    .HasComment("資料更改日期");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("name")
                    .HasComment("SAP不良類型{SAPDefectType }+建立日期yyyymmddHHmmss+兩碼流水碼");

                entity.Property(e => e.Orderid)
                    .HasMaxLength(20)
                    .HasColumnName("orderid");

                entity.Property(e => e.Orderlevel)
                    .HasMaxLength(20)
                    .HasColumnName("orderlevel");

                entity.Property(e => e.Orderqty)
                    .HasMaxLength(20)
                    .HasColumnName("orderqty")
                    .HasComment("由Packing 寫入");

                entity.Property(e => e.Outboundtime)
                    .HasMaxLength(14)
                    .HasColumnName("outboundtime")
                    .HasComment("SYSDATE Format : YYYYMMDDHH24MiSS");

                entity.Property(e => e.Part)
                    .HasMaxLength(256)
                    .HasColumnName("part");

                entity.Property(e => e.Partno)
                    .HasMaxLength(20)
                    .HasColumnName("partno");

                entity.Property(e => e.Plnbez)
                    .HasMaxLength(20)
                    .HasColumnName("plnbez");

                entity.Property(e => e.ProcessErrmsg)
                    .HasMaxLength(300)
                    .HasColumnName("process_errmsg");

                entity.Property(e => e.ProcessMk)
                    .HasMaxLength(1)
                    .HasColumnName("process_mk")
                    .HasComment("外圍取走資料寫入Y");

                entity.Property(e => e.ProcessTime)
                    .HasMaxLength(20)
                    .HasColumnName("process_time");

                entity.Property(e => e.ProcessUser)
                    .HasMaxLength(100)
                    .HasColumnName("process_user");

                entity.Property(e => e.Productdate)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("productdate")
                    .IsFixedLength(true)
                    .HasComment("實際製令檢驗日期");

                entity.Property(e => e.Productno)
                    .HasMaxLength(20)
                    .HasColumnName("productno");

                entity.Property(e => e.Producttime)
                    .HasMaxLength(20)
                    .HasColumnName("producttime");

                entity.Property(e => e.Producttype)
                    .IsRequired()
                    .HasMaxLength(512)
                    .HasColumnName("producttype");

                entity.Property(e => e.Qclevel)
                    .HasMaxLength(20)
                    .HasColumnName("qclevel");

                entity.Property(e => e.Qcqty)
                    .HasPrecision(18, 3)
                    .HasColumnName("qcqty");

                entity.Property(e => e.Rightqty)
                    .HasPrecision(18, 3)
                    .HasColumnName("rightqty");

                entity.Property(e => e.Sapdefecttype)
                    .HasMaxLength(50)
                    .HasColumnName("sapdefecttype");

                entity.Property(e => e.Shiftdefinitionshift)
                    .HasMaxLength(256)
                    .HasColumnName("shiftdefinitionshift");

                entity.Property(e => e.Sizeno)
                    .HasMaxLength(50)
                    .HasColumnName("sizeno");

                entity.Property(e => e.Stepname)
                    .HasMaxLength(256)
                    .HasColumnName("stepname");

                entity.Property(e => e.Sublineno)
                    .HasMaxLength(20)
                    .HasColumnName("sublineno");

                entity.Property(e => e.Timmeron)
                    .HasMaxLength(14)
                    .HasColumnName("timmeron")
                    .HasComment("MES拋到RDB時間(yyyymmddhhmmss)");

                entity.Property(e => e.Werks)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("werks");

                entity.Property(e => e.Zzactresult)
                    .HasMaxLength(1)
                    .HasColumnName("zzactresult")
                    .HasComment("\"Y=準收(Accepted)\nN=未通過(Reject)\"");

                entity.Property(e => e.Zzbatchid)
                    .HasMaxLength(2)
                    .HasColumnName("zzbatchid")
                    .IsFixedLength(true);

                entity.Property(e => e.Zzmdmark)
                    .HasMaxLength(300)
                    .HasColumnName("zzmdmark");
            });

            modelBuilder.Entity<MesOutboundbproduce>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mes_outboundbproduce", "ap_mif");

                entity.Property(e => e.Aufnr)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("aufnr")
                    .HasComment("工單號碼");

                entity.Property(e => e.Bmeng)
                    .HasPrecision(18, 8)
                    .HasColumnName("bmeng")
                    .HasComment("每手重量(KG)");

                entity.Property(e => e.Component)
                    .HasMaxLength(20)
                    .HasColumnName("component")
                    .HasComment("部位代號");

                entity.Property(e => e.Componentdescen)
                    .HasMaxLength(50)
                    .HasColumnName("componentdescen")
                    .HasComment("部位名稱(英文)");

                entity.Property(e => e.Componentdesczf)
                    .HasMaxLength(50)
                    .HasColumnName("componentdesczf")
                    .HasComment("部位名稱(中文)");

                entity.Property(e => e.Datagroup)
                    .HasMaxLength(256)
                    .HasColumnName("datagroup")
                    .HasComment("DataGroup");

                entity.Property(e => e.Facility)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("facility")
                    .HasComment("廠別");

                entity.Property(e => e.Flow)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("flow")
                    .HasComment("製程代號");

                entity.Property(e => e.Formulano)
                    .HasMaxLength(300)
                    .HasColumnName("formulano")
                    .HasComment("配方代號");

                entity.Property(e => e.Leftqty)
                    .HasPrecision(18, 8)
                    .HasColumnName("leftqty")
                    .HasComment("左腳派工數量");

                entity.Property(e => e.Meins)
                    .HasMaxLength(20)
                    .HasColumnName("meins")
                    .HasComment("派工單位(計量單位)");

                entity.Property(e => e.MifMk)
                    .HasMaxLength(1)
                    .HasColumnName("mif_mk")
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.Moldbarcode)
                    .HasMaxLength(256)
                    .HasColumnName("moldbarcode")
                    .HasComment("模具條碼");

                entity.Property(e => e.Molddescription)
                    .HasMaxLength(256)
                    .HasColumnName("molddescription")
                    .HasComment("MES模具說明");

                entity.Property(e => e.Moldname)
                    .HasMaxLength(256)
                    .HasColumnName("moldname")
                    .HasComment("MES模具名稱");

                entity.Property(e => e.Outboundtime)
                    .HasMaxLength(14)
                    .HasColumnName("outboundtime")
                    .IsFixedLength(true)
                    .HasComment("OutBoundTime");

                entity.Property(e => e.Perqty)
                    .HasPrecision(18, 8)
                    .HasColumnName("perqty")
                    .HasComment("手數");

                entity.Property(e => e.Plnbez)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("plnbez")
                    .HasComment("產出料號");

                entity.Property(e => e.Processmk)
                    .HasMaxLength(1)
                    .HasColumnName("processmk")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("ERP資料處理註記");

                entity.Property(e => e.Producedate)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("producedate")
                    .IsFixedLength(true)
                    .HasComment("製令日期");

                entity.Property(e => e.Produceitem)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("produceitem")
                    .HasComment("製令項次");

                entity.Property(e => e.Produceno)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("produceno")
                    .HasComment("製令號碼");

                entity.Property(e => e.Producestatus)
                    .IsRequired()
                    .HasMaxLength(512)
                    .HasColumnName("producestatus")
                    .HasComment("製令單狀態");

                entity.Property(e => e.Producttype)
                    .IsRequired()
                    .HasMaxLength(512)
                    .HasColumnName("producttype")
                    .HasComment("產品類別");

                entity.Property(e => e.Qty)
                    .HasPrecision(18, 8)
                    .HasColumnName("qty")
                    .HasComment("派工數量(生產數量)");

                entity.Property(e => e.Resource)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("resource")
                    .HasComment("機台");

                entity.Property(e => e.Resourcegroup)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("resourcegroup")
                    .HasComment("機群");

                entity.Property(e => e.Rightqty)
                    .HasPrecision(18, 8)
                    .HasColumnName("rightqty")
                    .HasComment("右腳派工數量");

                entity.Property(e => e.Shiftdefinitionshift)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("shiftdefinitionshift")
                    .HasComment("班別");

                entity.Property(e => e.Universalstate)
                    .HasMaxLength(1)
                    .HasColumnName("universalstate")
                    .HasComment("製令單狀態");

                entity.Property(e => e.WebProcessmk)
                    .HasMaxLength(1)
                    .HasColumnName("web_processmk")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("ERP資料處理註記");

                entity.Property(e => e.Wosize)
                    .HasMaxLength(50)
                    .HasColumnName("wosize")
                    .HasComment("生產SIZE");

                entity.Property(e => e.Zzatcolr)
                    .HasMaxLength(100)
                    .HasColumnName("zzatcolr")
                    .HasComment("型體顏色");

                entity.Property(e => e.Zzcolorcode)
                    .HasMaxLength(50)
                    .HasColumnName("zzcolorcode")
                    .HasComment("部位顏色代號");

                entity.Property(e => e.Zzmdmark)
                    .HasMaxLength(300)
                    .HasColumnName("zzmdmark")
                    .HasComment("型體代號+顏色代號(Article)");

                entity.Property(e => e.Zzmdnam)
                    .HasMaxLength(300)
                    .HasColumnName("zzmdnam")
                    .HasComment("型體名稱");

                entity.Property(e => e.Zzmidsolmod)
                    .HasMaxLength(100)
                    .HasColumnName("zzmidsolmod")
                    .HasComment("中底代號");

                entity.Property(e => e.Zzoutsolmod)
                    .HasMaxLength(100)
                    .HasColumnName("zzoutsolmod")
                    .HasComment("外底代號");

                entity.Property(e => e.Zzstylcode)
                    .HasMaxLength(50)
                    .HasColumnName("zzstylcode")
                    .HasComment("型體代號");
            });

            modelBuilder.Entity<MesOutboundbqmd>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mes_outboundbqmd", "ap_mif");

                entity.Property(e => e.Approvetime)
                    .HasMaxLength(14)
                    .HasColumnName("approvetime");

                entity.Property(e => e.Aufnr)
                    .HasMaxLength(20)
                    .HasColumnName("aufnr");

                entity.Property(e => e.Brandid)
                    .HasMaxLength(50)
                    .HasColumnName("brandid");

                entity.Property(e => e.Component)
                    .HasMaxLength(20)
                    .HasColumnName("component");

                entity.Property(e => e.Componentdescen)
                    .HasMaxLength(50)
                    .HasColumnName("componentdescen");

                entity.Property(e => e.Componentdesczf)
                    .HasMaxLength(50)
                    .HasColumnName("componentdesczf");

                entity.Property(e => e.Createdby)
                    .HasMaxLength(100)
                    .HasColumnName("createdby");

                entity.Property(e => e.Createdon)
                    .HasMaxLength(14)
                    .HasColumnName("createdon");

                entity.Property(e => e.Datagroup)
                    .HasMaxLength(256)
                    .HasColumnName("datagroup");

                entity.Property(e => e.Defectcode)
                    .HasMaxLength(50)
                    .HasColumnName("defectcode");

                entity.Property(e => e.Defectdesclocal)
                    .HasMaxLength(200)
                    .HasColumnName("defectdesclocal");

                entity.Property(e => e.Defectdesczf)
                    .HasMaxLength(200)
                    .HasColumnName("defectdesczf");

                entity.Property(e => e.Defectkind)
                    .HasMaxLength(50)
                    .HasColumnName("defectkind");

                entity.Property(e => e.Defectkinddesclocal)
                    .HasMaxLength(200)
                    .HasColumnName("defectkinddesclocal");

                entity.Property(e => e.Defectkinddesczf)
                    .HasMaxLength(200)
                    .HasColumnName("defectkinddesczf");

                entity.Property(e => e.Defectqty)
                    .HasPrecision(18, 8)
                    .HasColumnName("defectqty");

                entity.Property(e => e.Empid)
                    .HasMaxLength(20)
                    .HasColumnName("empid");

                entity.Property(e => e.Facility)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("facility");

                entity.Property(e => e.Foqcno)
                    .HasMaxLength(20)
                    .HasColumnName("foqcno");

                entity.Property(e => e.Formulano)
                    .HasMaxLength(300)
                    .HasColumnName("formulano");

                entity.Property(e => e.Isdelete)
                    .HasMaxLength(1)
                    .HasColumnName("isdelete");

                entity.Property(e => e.Leftqty)
                    .HasPrecision(18, 8)
                    .HasColumnName("leftqty");

                entity.Property(e => e.Memo)
                    .HasMaxLength(512)
                    .HasColumnName("memo");

                entity.Property(e => e.Modifiedby)
                    .HasMaxLength(100)
                    .HasColumnName("modifiedby");

                entity.Property(e => e.Modifiedon)
                    .HasMaxLength(14)
                    .HasColumnName("modifiedon");

                entity.Property(e => e.Moldbarcode)
                    .HasMaxLength(50)
                    .HasColumnName("moldbarcode");

                entity.Property(e => e.Molddescription)
                    .HasMaxLength(256)
                    .HasColumnName("molddescription");

                entity.Property(e => e.Moldname)
                    .HasMaxLength(256)
                    .HasColumnName("moldname");

                entity.Property(e => e.Orderlevel)
                    .HasMaxLength(20)
                    .HasColumnName("orderlevel");

                entity.Property(e => e.Orderqty)
                    .HasPrecision(18, 8)
                    .HasColumnName("orderqty");

                entity.Property(e => e.Outboundtime)
                    .HasMaxLength(14)
                    .HasColumnName("outboundtime");

                entity.Property(e => e.Plnbez)
                    .HasMaxLength(20)
                    .HasColumnName("plnbez");

                entity.Property(e => e.Prodbatch)
                    .HasMaxLength(20)
                    .HasColumnName("prodbatch");

                entity.Property(e => e.Produceitem)
                    .HasMaxLength(20)
                    .HasColumnName("produceitem");

                entity.Property(e => e.Produceno)
                    .HasMaxLength(20)
                    .HasColumnName("produceno");

                entity.Property(e => e.Productdate)
                    .HasMaxLength(8)
                    .HasColumnName("productdate")
                    .IsFixedLength(true);

                entity.Property(e => e.Producttype)
                    .HasMaxLength(512)
                    .HasColumnName("producttype");

                entity.Property(e => e.Qclevel)
                    .HasMaxLength(20)
                    .HasColumnName("qclevel");

                entity.Property(e => e.Qcqty)
                    .HasPrecision(18, 8)
                    .HasColumnName("qcqty");

                entity.Property(e => e.Resource)
                    .HasMaxLength(256)
                    .HasColumnName("resource");

                entity.Property(e => e.Resourcegroup)
                    .HasMaxLength(256)
                    .HasColumnName("resourcegroup");

                entity.Property(e => e.Rightqty)
                    .HasPrecision(18, 8)
                    .HasColumnName("rightqty");

                entity.Property(e => e.Sapdefecttype)
                    .HasMaxLength(50)
                    .HasColumnName("sapdefecttype");

                entity.Property(e => e.Shiftdefinitionshift)
                    .HasMaxLength(256)
                    .HasColumnName("shiftdefinitionshift");

                entity.Property(e => e.Step)
                    .HasMaxLength(256)
                    .HasColumnName("step");

                entity.Property(e => e.Sublineno)
                    .HasMaxLength(20)
                    .HasColumnName("sublineno");

                entity.Property(e => e.Timmeron)
                    .HasMaxLength(14)
                    .HasColumnName("timmeron");

                entity.Property(e => e.Vbeln)
                    .HasMaxLength(20)
                    .HasColumnName("vbeln");

                entity.Property(e => e.Werks)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("werks");

                entity.Property(e => e.Wosize)
                    .HasMaxLength(50)
                    .HasColumnName("wosize");

                entity.Property(e => e.Zqmdname)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("zqmdname");

                entity.Property(e => e.Zzactresult)
                    .HasMaxLength(1)
                    .HasColumnName("zzactresult");

                entity.Property(e => e.Zzatcolr)
                    .HasMaxLength(100)
                    .HasColumnName("zzatcolr");

                entity.Property(e => e.Zzbatchid)
                    .HasMaxLength(2)
                    .HasColumnName("zzbatchid")
                    .IsFixedLength(true);

                entity.Property(e => e.Zzcolorcode)
                    .HasMaxLength(50)
                    .HasColumnName("zzcolorcode");

                entity.Property(e => e.Zzmdmark)
                    .HasMaxLength(300)
                    .HasColumnName("zzmdmark");

                entity.Property(e => e.Zzmdnam)
                    .HasMaxLength(300)
                    .HasColumnName("zzmdnam");

                entity.Property(e => e.Zzmidsolmod)
                    .HasMaxLength(100)
                    .HasColumnName("zzmidsolmod");

                entity.Property(e => e.Zzoutsolmod)
                    .HasMaxLength(100)
                    .HasColumnName("zzoutsolmod");

                entity.Property(e => e.Zzstylcode)
                    .HasMaxLength(50)
                    .HasColumnName("zzstylcode");
            });

            modelBuilder.Entity<MesOutboundbwork>(entity =>
            {
                entity.HasKey(e => new { e.Facility, e.Workno, e.Workseq, e.Aufnr, e.Universalstate })
                    .HasName("pk_outboundbwork");

                entity.ToTable("mes_outboundbwork", "ap_mif");

                entity.Property(e => e.Facility)
                    .HasMaxLength(256)
                    .HasColumnName("facility");

                entity.Property(e => e.Workno)
                    .HasMaxLength(20)
                    .HasColumnName("workno");

                entity.Property(e => e.Workseq)
                    .HasMaxLength(20)
                    .HasColumnName("workseq");

                entity.Property(e => e.Aufnr)
                    .HasMaxLength(20)
                    .HasColumnName("aufnr");

                entity.Property(e => e.Universalstate)
                    .HasMaxLength(1)
                    .HasColumnName("universalstate");

                entity.Property(e => e.Bmeng)
                    .HasPrecision(18, 8)
                    .HasColumnName("bmeng");

                entity.Property(e => e.Component)
                    .HasMaxLength(20)
                    .HasColumnName("component");

                entity.Property(e => e.Formulano)
                    .HasMaxLength(50)
                    .HasColumnName("formulano");

                entity.Property(e => e.Gamng)
                    .HasPrecision(18, 8)
                    .HasColumnName("gamng");

                entity.Property(e => e.Leftqty)
                    .HasPrecision(18, 8)
                    .HasColumnName("leftqty");

                entity.Property(e => e.Meins)
                    .HasMaxLength(20)
                    .HasColumnName("meins");

                entity.Property(e => e.Mescomponent)
                    .HasMaxLength(20)
                    .HasColumnName("mescomponent");

                entity.Property(e => e.Mesresource)
                    .HasMaxLength(256)
                    .HasColumnName("mesresource");

                entity.Property(e => e.MifMk)
                    .HasMaxLength(1)
                    .HasColumnName("mif_mk")
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.Nameen)
                    .HasMaxLength(50)
                    .HasColumnName("nameen");

                entity.Property(e => e.Namezf)
                    .HasMaxLength(50)
                    .HasColumnName("namezf");

                entity.Property(e => e.Outboundtime)
                    .HasMaxLength(14)
                    .HasColumnName("outboundtime");

                entity.Property(e => e.Partcolor)
                    .HasMaxLength(50)
                    .HasColumnName("partcolor");

                entity.Property(e => e.Perqty)
                    .HasPrecision(18, 8)
                    .HasColumnName("perqty");

                entity.Property(e => e.Plnbez)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("plnbez");

                entity.Property(e => e.Processmk)
                    .HasMaxLength(1)
                    .HasColumnName("processmk")
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.Productkind)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("productkind");

                entity.Property(e => e.ReceiveTime)
                    .HasMaxLength(14)
                    .HasColumnName("receive_time");

                entity.Property(e => e.Resource)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("resource");

                entity.Property(e => e.Resourcegroup)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("resourcegroup");

                entity.Property(e => e.Rightqty)
                    .HasPrecision(18, 8)
                    .HasColumnName("rightqty");

                entity.Property(e => e.Shift)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("shift");

                entity.Property(e => e.Stepname)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("stepname");

                entity.Property(e => e.WebProcessmk)
                    .HasMaxLength(1)
                    .HasColumnName("web_processmk")
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.Workdate)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("workdate")
                    .IsFixedLength(true);

                entity.Property(e => e.Wosize)
                    .HasMaxLength(50)
                    .HasColumnName("wosize");

                entity.Property(e => e.Zzatcolr)
                    .HasMaxLength(100)
                    .HasColumnName("zzatcolr");

                entity.Property(e => e.Zzmdmark)
                    .HasMaxLength(50)
                    .HasColumnName("zzmdmark");

                entity.Property(e => e.Zzmdnam)
                    .HasMaxLength(100)
                    .HasColumnName("zzmdnam");

                entity.Property(e => e.Zzmidsolmod)
                    .HasMaxLength(100)
                    .HasColumnName("zzmidsolmod");

                entity.Property(e => e.Zzoutsolmod)
                    .HasMaxLength(100)
                    .HasColumnName("zzoutsolmod");

                entity.Property(e => e.Zzstylcode)
                    .HasMaxLength(50)
                    .HasColumnName("zzstylcode");
            });

            modelBuilder.Entity<MesOutboundfqcsap>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mes_outboundfqcsap", "ap_mif");

                entity.Property(e => e.CreateTime)
                    .HasMaxLength(20)
                    .HasColumnName("create_time")
                    .HasComment("抄寫到Temp時間");

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(100)
                    .HasColumnName("create_user")
                    .HasComment("抄寫Temp排程");

                entity.Property(e => e.Createon)
                    .HasMaxLength(14)
                    .HasColumnName("createon")
                    .HasComment("Create時間");

                entity.Property(e => e.Fqcname)
                    .HasMaxLength(300)
                    .HasColumnName("fqcname")
                    .HasComment("fqcname");

                entity.Property(e => e.Posnr)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("posnr")
                    .HasComment("SAP Itme#");

                entity.Property(e => e.ProcessErrmsg)
                    .HasMaxLength(300)
                    .HasColumnName("process_errmsg")
                    .HasComment("抄寫到MIF錯誤訊息");

                entity.Property(e => e.ProcessMk)
                    .HasMaxLength(1)
                    .HasColumnName("process_mk")
                    .HasComment("抄寫到MIF註記");

                entity.Property(e => e.ProcessTime)
                    .HasMaxLength(20)
                    .HasColumnName("process_time")
                    .HasComment("抄寫到MIF時間");

                entity.Property(e => e.ProcessUser)
                    .HasMaxLength(100)
                    .HasColumnName("process_user")
                    .HasComment("抄寫到MIF排程");

                entity.Property(e => e.Timmeron)
                    .HasMaxLength(14)
                    .HasColumnName("timmeron")
                    .HasComment("Timmer轉入時間");

                entity.Property(e => e.UlSapErrCode)
                    .HasMaxLength(20)
                    .HasColumnName("ul_sap_err_code")
                    .HasComment("Upload SAP錯誤代碼");

                entity.Property(e => e.UlSapErrMsg)
                    .HasMaxLength(500)
                    .HasColumnName("ul_sap_err_msg")
                    .HasComment("Upload SAP上傳訊息");

                entity.Property(e => e.UlSapFileName)
                    .HasMaxLength(100)
                    .HasColumnName("ul_sap_file_name")
                    .HasComment("Upload SAP 檔案名稱");

                entity.Property(e => e.UlSapSts)
                    .HasMaxLength(1)
                    .HasColumnName("ul_sap_sts")
                    .HasComment("Upload SAP狀態");

                entity.Property(e => e.UlSapTime)
                    .HasMaxLength(14)
                    .HasColumnName("ul_sap_time")
                    .HasComment("Upload SAP時間");

                entity.Property(e => e.UlSapTransId)
                    .HasMaxLength(50)
                    .HasColumnName("ul_sap_trans_id")
                    .HasComment("Upload SAP交易代碼");

                entity.Property(e => e.Vbeln)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("vbeln")
                    .HasComment("SO#(訂單號碼)");

                entity.Property(e => e.ZzactInsp)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("zzact_insp")
                    .HasComment("實際驗貨日");

                entity.Property(e => e.ZzactInspDrc)
                    .HasMaxLength(50)
                    .HasColumnName("zzact_insp_drc")
                    .HasComment("實際驗貨的delay reason code");

                entity.Property(e => e.ZzactInspMemo)
                    .HasMaxLength(150)
                    .HasColumnName("zzact_insp_memo")
                    .HasComment("實際驗貨結果註記");

                entity.Property(e => e.ZzactInspResult)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("zzact_insp_result")
                    .HasComment("實際驗貨結果");

                entity.Property(e => e.Zzbatchid)
                    .HasMaxLength(2)
                    .HasColumnName("zzbatchid")
                    .HasComment("外部驗貨批次號");

                entity.Property(e => e.Zzchgflag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("zzchgflag")
                    .HasComment("更新註記");

                entity.Property(e => e.Zzqty)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("zzqty")
                    .HasComment("實際驗貨數量");
            });

            modelBuilder.Entity<MesOutboundshoeprod>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mes_outboundshoeprod", "ap_mif");

                entity.HasIndex(e => e.Obtempname, "pk_outboundshoeprod")
                    .IsUnique();

                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("action");

                entity.Property(e => e.Arbpl)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("arbpl")
                    .HasComment("取得VORNR對應的工作中心");

                entity.Property(e => e.Auart)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("auart")
                    .HasComment("ZP01/ ZP02..");

                entity.Property(e => e.Barcodei)
                    .HasMaxLength(20)
                    .HasColumnName("barcodei");

                entity.Property(e => e.Componentdescen)
                    .HasMaxLength(50)
                    .HasColumnName("componentdescen")
                    .HasComment("ComponentDescEN");

                entity.Property(e => e.CreateTime)
                    .HasMaxLength(20)
                    .HasColumnName("create_time");

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(100)
                    .HasColumnName("create_user");

                entity.Property(e => e.Createon)
                    .HasMaxLength(14)
                    .HasColumnName("createon")
                    .HasComment("原生欄位");

                entity.Property(e => e.Facility)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("facility")
                    .HasComment("FacilityName");

                entity.Property(e => e.Flow)
                    .HasMaxLength(100)
                    .HasColumnName("flow");

                entity.Property(e => e.Leftqty)
                    .HasPrecision(18, 8)
                    .HasColumnName("leftqty");

                entity.Property(e => e.Lindid)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("lindid")
                    .HasComment("SubLineNo");

                entity.Property(e => e.Maktx)
                    .HasMaxLength(50)
                    .HasColumnName("maktx")
                    .HasComment("暫時不需要");

                entity.Property(e => e.Materialname)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("materialname")
                    .HasComment("\"Material.Name\nQM帶入NA\"");

                entity.Property(e => e.Materialtype)
                    .IsRequired()
                    .HasMaxLength(512)
                    .HasColumnName("materialtype");

                entity.Property(e => e.Obtempname)
                    .HasMaxLength(256)
                    .HasColumnName("obtempname");

                entity.Property(e => e.Opgroup)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("opgroup");

                entity.Property(e => e.Part)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("part")
                    .HasComment("material.COMPONENT");

                entity.Property(e => e.Plnbez)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("plnbez")
                    .HasComment("product.name");

                entity.Property(e => e.Posnr)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("posnr");

                entity.Property(e => e.PosnrOut)
                    .HasMaxLength(20)
                    .HasColumnName("posnr_out")
                    .HasComment("POSNR by UpAufnr");

                entity.Property(e => e.Primaryquantity)
                    .HasPrecision(18, 8)
                    .HasColumnName("primaryquantity");

                entity.Property(e => e.Primaryunits)
                    .IsRequired()
                    .HasMaxLength(512)
                    .HasColumnName("primaryunits");

                entity.Property(e => e.ProcessErrmsg)
                    .HasMaxLength(300)
                    .HasColumnName("process_errmsg");

                entity.Property(e => e.ProcessTime)
                    .HasMaxLength(20)
                    .HasColumnName("process_time");

                entity.Property(e => e.ProcessUser)
                    .HasMaxLength(100)
                    .HasColumnName("process_user");

                entity.Property(e => e.Processmk)
                    .HasMaxLength(1)
                    .HasColumnName("processmk")
                    .HasComment("外圍取走資料寫入Y");

                entity.Property(e => e.Prodbatch)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("prodbatch");

                entity.Property(e => e.Productno)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("productno")
                    .HasComment("ProductionOrder");

                entity.Property(e => e.Producttype)
                    .IsRequired()
                    .HasMaxLength(512)
                    .HasColumnName("producttype")
                    .HasComment("MH/HU/HC/HS/FG");

                entity.Property(e => e.Rcode)
                    .HasMaxLength(1)
                    .HasColumnName("rcode")
                    .HasComment("\"是否要報工在補料工單上 \r\n1-補料工單需報補料工\r\n2-補料工單不報工\r\n3-補料工單報工回原量產工單(MES無法報回原工單)=2\"");

                entity.Property(e => e.Resource)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("resource");

                entity.Property(e => e.Resourcegroup)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("resourcegroup");

                entity.Property(e => e.Rightqty)
                    .HasPrecision(18, 8)
                    .HasColumnName("rightqty");

                entity.Property(e => e.Sapdefecttype)
                    .HasMaxLength(50)
                    .HasColumnName("sapdefecttype")
                    .HasComment("\"B：B品\nC：C品\"");

                entity.Property(e => e.Sgtscat)
                    .HasMaxLength(20)
                    .HasColumnName("sgtscat")
                    .HasComment("IBWork.SGTSCAT");

                entity.Property(e => e.Shift)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("shift")
                    .HasComment("ShiftDefinitionShift");

                entity.Property(e => e.Sizeno)
                    .HasMaxLength(50)
                    .HasColumnName("sizeno")
                    .HasComment("material.WOSIZE");

                entity.Property(e => e.Sosize)
                    .HasMaxLength(50)
                    .HasColumnName("sosize")
                    .HasComment("Ibwork.sosize，查無資料或已被Terminated則帶入空值");

                entity.Property(e => e.Stand)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("stand")
                    .HasComment("\"SAP儲位(最長只能設定4碼)\n工作中心對應的產出位置 ex:2101\"");

                entity.Property(e => e.Stepname)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("stepname");

                entity.Property(e => e.Timmeron)
                    .HasMaxLength(14)
                    .HasColumnName("timmeron")
                    .HasComment("原生欄位");

                entity.Property(e => e.Vbeln)
                    .HasMaxLength(20)
                    .HasColumnName("vbeln");

                entity.Property(e => e.Vornr)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("vornr")
                    .HasComment("取得工單最大VORNR");

                entity.Property(e => e.Werks)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("werks");

                entity.Property(e => e.Workno)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("workno")
                    .HasComment("materinal.aufnr(workno)");

                entity.Property(e => e.Zzmdmark)
                    .HasMaxLength(300)
                    .HasColumnName("zzmdmark");

                entity.Property(e => e.Zzmidsolmod)
                    .HasMaxLength(100)
                    .HasColumnName("zzmidsolmod");

                entity.Property(e => e.Zzoutsolmod)
                    .HasMaxLength(100)
                    .HasColumnName("zzoutsolmod");
            });

            modelBuilder.Entity<MesOutboundsoleprod>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mes_outboundsoleprod", "ap_mif");

                entity.Property(e => e.ActShift)
                    .HasMaxLength(256)
                    .HasColumnName("act_shift");

                entity.Property(e => e.ActWorkdate)
                    .HasMaxLength(14)
                    .HasColumnName("act_workdate");

                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("action")
                    .IsFixedLength(true)
                    .HasComment("TrackIn / TrackOut / MoveNext");

                entity.Property(e => e.Arbpl)
                    .HasMaxLength(20)
                    .HasColumnName("arbpl")
                    .HasComment("工作中心");

                entity.Property(e => e.Auart)
                    .HasMaxLength(20)
                    .HasColumnName("auart")
                    .HasComment("工單類型");

                entity.Property(e => e.Aufnr)
                    .HasMaxLength(20)
                    .HasColumnName("aufnr")
                    .HasComment("工單號碼");

                entity.Property(e => e.Bmeng)
                    .HasPrecision(18, 8)
                    .HasColumnName("bmeng")
                    .HasComment("每手重量(KG)");

                entity.Property(e => e.Brandid)
                    .HasMaxLength(20)
                    .HasColumnName("brandid")
                    .HasComment("品牌");

                entity.Property(e => e.Component)
                    .HasMaxLength(20)
                    .HasColumnName("component")
                    .HasComment("部位代號");

                entity.Property(e => e.Componentdescen)
                    .HasMaxLength(50)
                    .HasColumnName("componentdescen")
                    .HasComment("部位名稱(英文)");

                entity.Property(e => e.Componentdesczf)
                    .HasMaxLength(50)
                    .HasColumnName("componentdesczf")
                    .HasComment("部位名稱(中文)");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .HasColumnName("createby")
                    .HasComment("Obtemp資料建立人員");

                entity.Property(e => e.Createon)
                    .HasMaxLength(14)
                    .HasColumnName("createon")
                    .IsFixedLength(true)
                    .HasComment("Obtemp建立時間");

                entity.Property(e => e.Datagroup)
                    .HasMaxLength(256)
                    .HasColumnName("datagroup")
                    .HasComment("DataGroupName");

                entity.Property(e => e.Empid)
                    .HasMaxLength(20)
                    .HasColumnName("empid")
                    .HasComment("人員集團ID");

                entity.Property(e => e.Facility)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("facility")
                    .HasComment("廠別");

                entity.Property(e => e.Feedto)
                    .HasMaxLength(256)
                    .HasColumnName("feedto")
                    .HasComment("貨批綁定號");

                entity.Property(e => e.Flow)
                    .HasMaxLength(100)
                    .HasColumnName("flow")
                    .HasComment("FLOW");

                entity.Property(e => e.Formulano)
                    .HasMaxLength(300)
                    .HasColumnName("formulano")
                    .HasComment("配方代號");

                entity.Property(e => e.Leftqty)
                    .HasPrecision(18, 8)
                    .HasColumnName("leftqty")
                    .HasComment("左腳派工數量");

                entity.Property(e => e.Maktx)
                    .HasMaxLength(50)
                    .HasColumnName("maktx")
                    .HasComment("產出說明");

                entity.Property(e => e.Materialname)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("materialname")
                    .HasComment("Lot ID");

                entity.Property(e => e.Materialtype)
                    .HasMaxLength(512)
                    .HasColumnName("materialtype")
                    .HasComment("MaterialType");

                entity.Property(e => e.MifMk)
                    .HasMaxLength(1)
                    .HasColumnName("mif_mk")
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.Obtempname)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("obtempname")
                    .HasComment("ObTemp.Name");

                entity.Property(e => e.Opgroupno)
                    .HasMaxLength(100)
                    .HasColumnName("opgroupno")
                    .HasComment("組別(TrackOut人員/組別)");

                entity.Property(e => e.Outboundtime)
                    .HasMaxLength(14)
                    .HasColumnName("outboundtime")
                    .IsFixedLength(true)
                    .HasComment("OutBound時間");

                entity.Property(e => e.Plnbez)
                    .HasMaxLength(20)
                    .HasColumnName("plnbez")
                    .HasComment("產出料號");

                entity.Property(e => e.Posnr)
                    .HasMaxLength(20)
                    .HasColumnName("posnr")
                    .HasComment("訂單號碼項次");

                entity.Property(e => e.Primaryquantity)
                    .HasPrecision(18, 8)
                    .HasColumnName("primaryquantity")
                    .HasComment("數量");

                entity.Property(e => e.Primaryunits)
                    .HasMaxLength(512)
                    .HasColumnName("primaryunits")
                    .HasComment("單位");

                entity.Property(e => e.Processmk)
                    .HasMaxLength(1)
                    .HasColumnName("processmk")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("ERP資料處理註記");

                entity.Property(e => e.Prodbatch)
                    .HasMaxLength(20)
                    .HasColumnName("prodbatch")
                    .HasComment("生產批次");

                entity.Property(e => e.Producedate)
                    .HasMaxLength(8)
                    .HasColumnName("producedate")
                    .IsFixedLength(true)
                    .HasComment("製令日期");

                entity.Property(e => e.Produceitem)
                    .HasMaxLength(20)
                    .HasColumnName("produceitem")
                    .HasComment("製令項次");

                entity.Property(e => e.Produceno)
                    .HasMaxLength(20)
                    .HasColumnName("produceno")
                    .HasComment("製令號碼");

                entity.Property(e => e.Producttype)
                    .HasMaxLength(512)
                    .HasColumnName("producttype")
                    .HasComment("產品類別");

                entity.Property(e => e.Rcode)
                    .HasMaxLength(1)
                    .HasColumnName("rcode")
                    .HasComment("開補類型");

                entity.Property(e => e.Resource)
                    .HasMaxLength(256)
                    .HasColumnName("resource")
                    .HasComment("設備");

                entity.Property(e => e.Resourcegroup)
                    .HasMaxLength(256)
                    .HasColumnName("resourcegroup")
                    .HasComment("機群");

                entity.Property(e => e.Returnmk)
                    .HasMaxLength(1)
                    .HasColumnName("returnmk")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("退料註記(Y/N)");

                entity.Property(e => e.Rightqty)
                    .HasPrecision(18, 8)
                    .HasColumnName("rightqty")
                    .HasComment("右腳派工數量");

                entity.Property(e => e.Sapdefecttype)
                    .HasMaxLength(50)
                    .HasColumnName("sapdefecttype")
                    .HasComment("SAP不良類型");

                entity.Property(e => e.Sgtscat)
                    .HasMaxLength(20)
                    .HasColumnName("sgtscat")
                    .HasComment("庫存區段");

                entity.Property(e => e.Shiftdefinitionshift)
                    .HasMaxLength(256)
                    .HasColumnName("shiftdefinitionshift")
                    .HasComment("班別");

                entity.Property(e => e.Sosize)
                    .HasMaxLength(50)
                    .HasColumnName("sosize")
                    .HasComment("訂單Size");

                entity.Property(e => e.Stand)
                    .HasMaxLength(20)
                    .HasColumnName("stand")
                    .HasComment("SAP產出位置");

                entity.Property(e => e.Stepname)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("stepname")
                    .HasComment("站點");

                entity.Property(e => e.Timmeron)
                    .HasMaxLength(14)
                    .HasColumnName("timmeron");

                entity.Property(e => e.Vbeln)
                    .HasMaxLength(20)
                    .HasColumnName("vbeln")
                    .HasComment("訂單號碼");

                entity.Property(e => e.Vornr)
                    .HasMaxLength(20)
                    .HasColumnName("vornr")
                    .HasComment("作業編號");

                entity.Property(e => e.WebProcessmk)
                    .HasMaxLength(1)
                    .HasColumnName("web_processmk")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("Legacy接收註記");

                entity.Property(e => e.Werks)
                    .HasMaxLength(20)
                    .HasColumnName("werks")
                    .HasComment("工廠");

                entity.Property(e => e.Wosize)
                    .HasMaxLength(50)
                    .HasColumnName("wosize")
                    .HasComment("生產SIZE");

                entity.Property(e => e.Zpack)
                    .HasMaxLength(50)
                    .HasColumnName("zpack")
                    .HasComment("包裝規格");

                entity.Property(e => e.Zzatcolr)
                    .HasMaxLength(100)
                    .HasColumnName("zzatcolr")
                    .HasComment("型體顏色");

                entity.Property(e => e.Zzcolorcode)
                    .HasMaxLength(50)
                    .HasColumnName("zzcolorcode")
                    .HasComment("顏色代號");

                entity.Property(e => e.Zzmdmark)
                    .HasMaxLength(300)
                    .HasColumnName("zzmdmark")
                    .HasComment("型體代號+顏色代號(Article)");

                entity.Property(e => e.Zzmdnam)
                    .HasMaxLength(300)
                    .HasColumnName("zzmdnam")
                    .HasComment("型體名稱");

                entity.Property(e => e.Zzmidsolmod)
                    .HasMaxLength(100)
                    .HasColumnName("zzmidsolmod")
                    .HasComment("中底代號");

                entity.Property(e => e.Zzoutsolmod)
                    .HasMaxLength(100)
                    .HasColumnName("zzoutsolmod")
                    .HasComment("外底代號");

                entity.Property(e => e.Zzstylcode)
                    .HasMaxLength(50)
                    .HasColumnName("zzstylcode")
                    .HasComment("型體代號");
            });

            modelBuilder.Entity<MetaBl>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("meta_bl", "ap_mif");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.MetaBlClass)
                    .IsRequired()
                    .HasMaxLength(120)
                    .HasColumnName("meta_bl_class");

                entity.Property(e => e.MetaBlDesc)
                    .HasMaxLength(100)
                    .HasColumnName("meta_bl_desc")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.MetaBlEvent)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("meta_bl_event");

                entity.Property(e => e.MetaBlId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("meta_bl_id")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.MetaBlTarget)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("meta_bl_target")
                    .HasDefaultValueSql("'DU'::character varying");

                entity.Property(e => e.MetaBlType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("meta_bl_type")
                    .HasDefaultValueSql("'G2FW'::character varying");

                entity.Property(e => e.TalendJobId)
                    .HasMaxLength(22)
                    .HasColumnName("talend_job_id");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(22)
                    .HasColumnName("update_user");
            });

            modelBuilder.Entity<MetaBl1>(entity =>
            {
                entity.HasKey(e => e.MetaBlId)
                    .HasName("meta_bl_pk");

                entity.ToTable("meta_bl", "fw_mif");

                entity.HasIndex(e => new { e.MetaBlClass, e.MetaBlEvent, e.TalendJobId }, "meta_bl_uk1")
                    .IsUnique();

                entity.Property(e => e.MetaBlId)
                    .HasMaxLength(22)
                    .HasColumnName("meta_bl_id")
                    .HasDefaultValueSql("''::character varying")
                    .HasComment("業務邏輯ID");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.MetaBlClass)
                    .IsRequired()
                    .HasMaxLength(120)
                    .HasColumnName("meta_bl_class")
                    .HasComment("CLASS全名");

                entity.Property(e => e.MetaBlDesc)
                    .HasMaxLength(100)
                    .HasColumnName("meta_bl_desc")
                    .HasDefaultValueSql("'NULL'::character varying")
                    .HasComment("描述");

                entity.Property(e => e.MetaBlEvent)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("meta_bl_event")
                    .HasComment("事件名");

                entity.Property(e => e.MetaBlTarget)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("meta_bl_target")
                    .HasDefaultValueSql("'DU'::character varying");

                entity.Property(e => e.MetaBlType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("meta_bl_type")
                    .HasDefaultValueSql("'G2FW'::character varying");

                entity.Property(e => e.TalendJobId)
                    .HasMaxLength(22)
                    .HasColumnName("talend_job_id");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(22)
                    .HasColumnName("update_user");

                entity.HasOne(d => d.TalendJob)
                    .WithMany(p => p.MetaBl1s)
                    .HasForeignKey(d => d.TalendJobId)
                    .HasConstraintName("meta_bl_fk1");
            });

            modelBuilder.Entity<MetaBlBackup>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("meta_bl_backup", "ap_mif");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.MetaBlClass)
                    .IsRequired()
                    .HasMaxLength(120)
                    .HasColumnName("meta_bl_class");

                entity.Property(e => e.MetaBlDesc)
                    .HasMaxLength(100)
                    .HasColumnName("meta_bl_desc")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.MetaBlEvent)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("meta_bl_event");

                entity.Property(e => e.MetaBlId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("meta_bl_id")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.MetaBlTarget)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("meta_bl_target")
                    .HasDefaultValueSql("'DU'::character varying");

                entity.Property(e => e.MetaBlType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("meta_bl_type")
                    .HasDefaultValueSql("'G2FW'::character varying");

                entity.Property(e => e.TalendJobId)
                    .HasMaxLength(22)
                    .HasColumnName("talend_job_id");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(22)
                    .HasColumnName("update_user");
            });

            modelBuilder.Entity<MetaExt>(entity =>
            {
                entity.ToTable("meta_ext", "fw_mif");

                entity.HasIndex(e => e.MetaExtName, "ui_meta_ext")
                    .IsUnique();

                entity.Property(e => e.MetaExtId)
                    .HasMaxLength(22)
                    .HasColumnName("meta_ext_id")
                    .HasDefaultValueSql("''::character varying")
                    .HasComment("約束條件ID");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.MetaExtName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("meta_ext_name")
                    .HasComment("約束條件名稱");

                entity.Property(e => e.MetaExtType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("meta_ext_type")
                    .HasDefaultValueSql("'P'::character varying")
                    .HasComment("類型");

                entity.Property(e => e.MetaObjId)
                    .HasMaxLength(22)
                    .HasColumnName("meta_obj_id")
                    .HasDefaultValueSql("'NULL'::character varying")
                    .HasComment("主表ID(META_OBJ)");

                entity.Property(e => e.RefMetaObjId)
                    .HasMaxLength(22)
                    .HasColumnName("ref_meta_obj_id")
                    .HasDefaultValueSql("'NULL\n   '::character varying")
                    .HasComment("參考表ID(META_OBJ)");

                entity.HasOne(d => d.MetaObj)
                    .WithMany(p => p.MetaExtMetaObjs)
                    .HasForeignKey(d => d.MetaObjId)
                    .HasConstraintName("meta_ext_fk1");

                entity.HasOne(d => d.RefMetaObj)
                    .WithMany(p => p.MetaExtRefMetaObjs)
                    .HasForeignKey(d => d.RefMetaObjId)
                    .HasConstraintName("meta_ext_fk2");
            });

            modelBuilder.Entity<MetaExtfield>(entity =>
            {
                entity.HasKey(e => new { e.MetaExtId, e.MetaFieldId })
                    .HasName("meta_extfield_pk");

                entity.ToTable("meta_extfield", "fw_mif");

                entity.Property(e => e.MetaExtId)
                    .HasMaxLength(22)
                    .HasColumnName("meta_ext_id")
                    .HasDefaultValueSql("''::character varying")
                    .HasComment("約束條件ID(META_EXT)");

                entity.Property(e => e.MetaFieldId)
                    .HasMaxLength(22)
                    .HasColumnName("meta_field_id")
                    .HasDefaultValueSql("''::character varying")
                    .HasComment("欄位ID(META_FIELD)");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.MetaExtfieldSeq)
                    .HasPrecision(3)
                    .HasColumnName("meta_extfield_seq")
                    .HasComment("排序");

                entity.Property(e => e.RefMetaFieldId)
                    .HasMaxLength(22)
                    .HasColumnName("ref_meta_field_id")
                    .HasDefaultValueSql("'NULL'::character varying")
                    .HasComment("參考欄位ID(META_FIELD)");

                entity.HasOne(d => d.MetaExt)
                    .WithMany(p => p.MetaExtfields)
                    .HasForeignKey(d => d.MetaExtId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("meta_extfield_fk1");

                entity.HasOne(d => d.MetaField)
                    .WithMany(p => p.MetaExtfieldMetaFields)
                    .HasForeignKey(d => d.MetaFieldId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("meta_extfield_fk2");

                entity.HasOne(d => d.RefMetaField)
                    .WithMany(p => p.MetaExtfieldRefMetaFields)
                    .HasForeignKey(d => d.RefMetaFieldId)
                    .HasConstraintName("meta_extfield_fk3");
            });

            modelBuilder.Entity<MetaField>(entity =>
            {
                entity.ToTable("meta_field", "fw_mif");

                entity.HasIndex(e => new { e.MetaObjId, e.MetaFieldName }, "ui_meta_field")
                    .IsUnique();

                entity.Property(e => e.MetaFieldId)
                    .HasMaxLength(22)
                    .HasColumnName("meta_field_id")
                    .HasDefaultValueSql("''::character varying")
                    .HasComment("欄位ID");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.MetaFieldAllownull)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("meta_field_allownull")
                    .HasDefaultValueSql("'Y'::character varying")
                    .HasComment("可空");

                entity.Property(e => e.MetaFieldAuto)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("meta_field_auto")
                    .HasDefaultValueSql("'0'::character varying")
                    .HasComment("自動");

                entity.Property(e => e.MetaFieldColumn)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("meta_field_column")
                    .HasComment("欄位名稱");

                entity.Property(e => e.MetaFieldComment)
                    .HasMaxLength(60)
                    .HasColumnName("meta_field_comment")
                    .HasDefaultValueSql("'NULL'::character varying")
                    .HasComment("描述");

                entity.Property(e => e.MetaFieldContent)
                    .HasMaxLength(3)
                    .HasColumnName("meta_field_content")
                    .HasDefaultValueSql("'NUL'::character varying")
                    .HasComment("內容類型");

                entity.Property(e => e.MetaFieldDatatype)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("meta_field_datatype")
                    .HasDefaultValueSql("'C'::character varying")
                    .HasComment("數據類型");

                entity.Property(e => e.MetaFieldDecwidth)
                    .HasPrecision(3)
                    .HasColumnName("meta_field_decwidth")
                    .HasComment("小數位");

                entity.Property(e => e.MetaFieldDefault)
                    .HasMaxLength(60)
                    .HasColumnName("meta_field_default")
                    .HasDefaultValueSql("'NULL'::character varying")
                    .HasComment("默認值");

                entity.Property(e => e.MetaFieldName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("meta_field_name")
                    .HasComment("欄位別名");

                entity.Property(e => e.MetaFieldSeq)
                    .HasPrecision(3)
                    .HasColumnName("meta_field_seq")
                    .HasComment("排序");

                entity.Property(e => e.MetaFieldSysdefine)
                    .HasMaxLength(10)
                    .HasColumnName("meta_field_sysdefine")
                    .HasDefaultValueSql("'NULL\n   '::character varying")
                    .HasComment("系統定義");

                entity.Property(e => e.MetaFieldTotwidth)
                    .HasPrecision(4)
                    .HasColumnName("meta_field_totwidth")
                    .HasComment("總寬度");

                entity.Property(e => e.MetaObjId)
                    .HasMaxLength(22)
                    .HasColumnName("meta_obj_id")
                    .HasDefaultValueSql("'NULL'::character varying")
                    .HasComment("表ID(META_OBJ)");

                entity.HasOne(d => d.MetaObj)
                    .WithMany(p => p.MetaFields)
                    .HasForeignKey(d => d.MetaObjId)
                    .HasConstraintName("meta_field_fk1");
            });

            modelBuilder.Entity<MetaMdl>(entity =>
            {
                entity.ToTable("meta_mdl", "fw_mif");

                entity.HasIndex(e => e.MetaMdlNo, "ui_meta_mdl")
                    .IsUnique();

                entity.Property(e => e.MetaMdlId)
                    .HasMaxLength(22)
                    .HasColumnName("meta_mdl_id")
                    .HasDefaultValueSql("''::character varying")
                    .HasComment("資料模型ID");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.MetaMdlDesc)
                    .HasMaxLength(120)
                    .HasColumnName("meta_mdl_desc")
                    .HasDefaultValueSql("'NULL'::character varying")
                    .HasComment("描述");

                entity.Property(e => e.MetaMdlName)
                    .HasMaxLength(100)
                    .HasColumnName("meta_mdl_name")
                    .HasComment("資料模型名稱");

                entity.Property(e => e.MetaMdlNo)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("meta_mdl_no")
                    .HasComment("資料模型編號");

                entity.Property(e => e.MetaMdlPost)
                    .HasMaxLength(120)
                    .HasColumnName("meta_mdl_post")
                    .HasDefaultValueSql("'NULL'::character varying")
                    .HasComment("組裝後委託");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasDefaultValueSql("NULL::numeric")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasComment("異動人ID");
            });

            modelBuilder.Entity<MetaMdl1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("meta_mdl", "ap_mif");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.MetaMdlDesc)
                    .HasMaxLength(120)
                    .HasColumnName("meta_mdl_desc")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.MetaMdlId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("meta_mdl_id")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.MetaMdlName)
                    .HasMaxLength(100)
                    .HasColumnName("meta_mdl_name");

                entity.Property(e => e.MetaMdlNo)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("meta_mdl_no");

                entity.Property(e => e.MetaMdlPost)
                    .HasMaxLength(120)
                    .HasColumnName("meta_mdl_post")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(22)
                    .HasColumnName("update_user");
            });

            modelBuilder.Entity<MetaMdlBackup>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("meta_mdl_backup", "ap_mif");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.MetaMdlDesc)
                    .HasMaxLength(120)
                    .HasColumnName("meta_mdl_desc")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.MetaMdlId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("meta_mdl_id")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.MetaMdlName)
                    .HasMaxLength(100)
                    .HasColumnName("meta_mdl_name");

                entity.Property(e => e.MetaMdlNo)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("meta_mdl_no");

                entity.Property(e => e.MetaMdlPost)
                    .HasMaxLength(120)
                    .HasColumnName("meta_mdl_post")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(22)
                    .HasColumnName("update_user");
            });

            modelBuilder.Entity<MetaMdlbl>(entity =>
            {
                entity.ToTable("meta_mdlbl", "fw_mif");

                entity.HasIndex(e => new { e.MetaMdlId, e.MetaBlId }, "meta_mdlbl_uk1")
                    .IsUnique();

                entity.Property(e => e.MetaMdlblId)
                    .HasMaxLength(22)
                    .HasColumnName("meta_mdlbl_id")
                    .HasComment("資料模型商業邏輯ID");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsEnable)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("is_enable")
                    .HasDefaultValueSql("'Y'::character varying")
                    .HasComment("啟用");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.MetaBlId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("meta_bl_id")
                    .HasComment("商業邏輯ID");

                entity.Property(e => e.MetaMdlId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("meta_mdl_id")
                    .HasComment("資料模型ID");

                entity.Property(e => e.Seq)
                    .HasPrecision(3)
                    .HasColumnName("seq")
                    .HasComment("排序");

                entity.HasOne(d => d.MetaBl)
                    .WithMany(p => p.MetaMdlbls)
                    .HasForeignKey(d => d.MetaBlId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("meta_mdlbl_fk1");

                entity.HasOne(d => d.MetaMdl)
                    .WithMany(p => p.MetaMdlbls)
                    .HasForeignKey(d => d.MetaMdlId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("meta_mdlbl_fk2");
            });

            modelBuilder.Entity<MetaMdlblParam>(entity =>
            {
                entity.ToTable("meta_mdlbl_param", "fw_mif");

                entity.HasIndex(e => new { e.MetaMdlblId, e.ParamKey }, "meta_mdlbl_param_uk1")
                    .IsUnique();

                entity.Property(e => e.MetaMdlblParamId)
                    .HasMaxLength(22)
                    .HasColumnName("meta_mdlbl_param_id")
                    .HasDefaultValueSql("''::character varying")
                    .HasComment("PK");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.MetaMdlblId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("meta_mdlbl_id")
                    .HasDefaultValueSql("''::character varying")
                    .HasComment("資料模型邏輯ID");

                entity.Property(e => e.ParamKey)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("param_key")
                    .HasDefaultValueSql("''::character varying")
                    .HasComment("參數名");

                entity.Property(e => e.ParamValue)
                    .HasMaxLength(100)
                    .HasColumnName("param_value")
                    .HasComment("參數值");

                entity.HasOne(d => d.MetaMdlbl)
                    .WithMany(p => p.MetaMdlblParams)
                    .HasForeignKey(d => d.MetaMdlblId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("meta_mdlbl_param_fk1");
            });

            modelBuilder.Entity<MetaMdlobj>(entity =>
            {
                entity.ToTable("meta_mdlobj", "fw_mif");

                entity.HasIndex(e => new { e.MetaMdlId, e.MetaMdlobjObj }, "ui_meta_mdlobj")
                    .IsUnique();

                entity.Property(e => e.MetaMdlobjId)
                    .HasMaxLength(22)
                    .HasColumnName("meta_mdlobj_id")
                    .HasDefaultValueSql("''::character varying")
                    .HasComment("資料模型單元ID");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.MetaMdlId)
                    .HasMaxLength(22)
                    .HasColumnName("meta_mdl_id")
                    .HasDefaultValueSql("'NULL'::character varying")
                    .HasComment("資料模型ID(META_MDL)");

                entity.Property(e => e.MetaMdlobjObj)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("meta_mdlobj_obj")
                    .HasComment("對象名");

                entity.Property(e => e.MetaMdlobjOwner)
                    .HasMaxLength(30)
                    .HasColumnName("meta_mdlobj_owner")
                    .HasDefaultValueSql("'NULL\n   '::character varying")
                    .HasComment("OWNER");

                entity.Property(e => e.MetaMdlobjSave)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("meta_mdlobj_save")
                    .HasDefaultValueSql("'Y'::character varying")
                    .HasComment("可保存");

                entity.Property(e => e.MetaMdlobjUplink)
                    .HasMaxLength(300)
                    .HasColumnName("meta_mdlobj_uplink")
                    .HasDefaultValueSql("'NULL'::character varying")
                    .HasComment("關聯式");

                entity.Property(e => e.MetaMdlobjUpobj)
                    .HasMaxLength(50)
                    .HasColumnName("meta_mdlobj_upobj")
                    .HasDefaultValueSql("'NULL'::character varying")
                    .HasComment("父對象");

                entity.Property(e => e.MetaMdlobjVosql)
                    .HasMaxLength(30)
                    .HasColumnName("meta_mdlobj_vosql")
                    .HasDefaultValueSql("'NULL'::character varying")
                    .HasComment("SQL編號");

                entity.HasOne(d => d.MetaMdl)
                    .WithMany(p => p.MetaMdlobjs)
                    .HasForeignKey(d => d.MetaMdlId)
                    .HasConstraintName("meta_mdlobj_fk1");
            });

            modelBuilder.Entity<MetaMdlobj1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("meta_mdlobj", "ap_mif");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.MetaMdlId)
                    .HasMaxLength(22)
                    .HasColumnName("meta_mdl_id")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.MetaMdlobjId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("meta_mdlobj_id")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.MetaMdlobjObj)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("meta_mdlobj_obj");

                entity.Property(e => e.MetaMdlobjOwner)
                    .HasMaxLength(30)
                    .HasColumnName("meta_mdlobj_owner")
                    .HasDefaultValueSql("'NULL\r\n   '::character varying");

                entity.Property(e => e.MetaMdlobjSave)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("meta_mdlobj_save")
                    .HasDefaultValueSql("'Y'::character varying");

                entity.Property(e => e.MetaMdlobjUplink)
                    .HasMaxLength(300)
                    .HasColumnName("meta_mdlobj_uplink")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.MetaMdlobjUpobj)
                    .HasMaxLength(50)
                    .HasColumnName("meta_mdlobj_upobj")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.MetaMdlobjVosql)
                    .HasMaxLength(30)
                    .HasColumnName("meta_mdlobj_vosql")
                    .HasDefaultValueSql("'NULL'::character varying");
            });

            modelBuilder.Entity<MetaMdlobjBackup>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("meta_mdlobj_backup", "ap_mif");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.MetaMdlId)
                    .HasMaxLength(22)
                    .HasColumnName("meta_mdl_id")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.MetaMdlobjId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("meta_mdlobj_id")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.MetaMdlobjObj)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("meta_mdlobj_obj");

                entity.Property(e => e.MetaMdlobjOwner)
                    .HasMaxLength(30)
                    .HasColumnName("meta_mdlobj_owner")
                    .HasDefaultValueSql("'NULL\r\n   '::character varying");

                entity.Property(e => e.MetaMdlobjSave)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("meta_mdlobj_save")
                    .HasDefaultValueSql("'Y'::character varying");

                entity.Property(e => e.MetaMdlobjUplink)
                    .HasMaxLength(300)
                    .HasColumnName("meta_mdlobj_uplink")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.MetaMdlobjUpobj)
                    .HasMaxLength(50)
                    .HasColumnName("meta_mdlobj_upobj")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.MetaMdlobjVosql)
                    .HasMaxLength(30)
                    .HasColumnName("meta_mdlobj_vosql")
                    .HasDefaultValueSql("'NULL'::character varying");
            });

            modelBuilder.Entity<MetaObj>(entity =>
            {
                entity.ToTable("meta_obj", "fw_mif");

                entity.HasIndex(e => e.MetaObjName, "ui_meta_obj")
                    .IsUnique();

                entity.Property(e => e.MetaObjId)
                    .HasMaxLength(22)
                    .HasColumnName("meta_obj_id")
                    .HasDefaultValueSql("''::character varying")
                    .HasComment("資料表ID");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.MetaObjAudit)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("meta_obj_audit")
                    .HasDefaultValueSql("'0'::character varying")
                    .HasComment("審計");

                entity.Property(e => e.MetaObjComment)
                    .HasMaxLength(60)
                    .HasColumnName("meta_obj_comment")
                    .HasDefaultValueSql("'NULL'::character varying")
                    .HasComment("描述");

                entity.Property(e => e.MetaObjLevel)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnName("meta_obj_level")
                    .HasDefaultValueSql("'1'::character varying")
                    .HasComment("表級別");

                entity.Property(e => e.MetaObjName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("meta_obj_name")
                    .HasComment("資料表別名");

                entity.Property(e => e.MetaObjTab)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("meta_obj_tab")
                    .HasComment("資料表名稱");

                entity.Property(e => e.MetaObjType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("meta_obj_type")
                    .HasDefaultValueSql("'normal'::character varying")
                    .HasComment("表類型");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasDefaultValueSql("NULL::numeric")
                    .HasComment("異動時間");
            });

            modelBuilder.Entity<MetaObjbl>(entity =>
            {
                entity.ToTable("meta_objbl", "fw_mif");

                entity.HasIndex(e => new { e.MetaMdlobjId, e.MetaBlId }, "meta_objbl_uk1")
                    .IsUnique();

                entity.Property(e => e.MetaObjblId)
                    .HasMaxLength(22)
                    .HasColumnName("meta_objbl_id")
                    .HasDefaultValueSql("''::character varying")
                    .HasComment("PK");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsEnable)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("is_enable")
                    .HasDefaultValueSql("'Y'::character varying")
                    .HasComment("啟用");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.MetaBlId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("meta_bl_id")
                    .HasDefaultValueSql("''::character varying")
                    .HasComment("商業邏輯ID");

                entity.Property(e => e.MetaMdlobjId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("meta_mdlobj_id")
                    .HasDefaultValueSql("''::character varying")
                    .HasComment("資料模型物件ID");

                entity.Property(e => e.Seq)
                    .HasPrecision(3)
                    .HasColumnName("seq")
                    .HasComment("排序");

                entity.HasOne(d => d.MetaBl)
                    .WithMany(p => p.MetaObjbls)
                    .HasForeignKey(d => d.MetaBlId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("meta_objbl_fk1");

                entity.HasOne(d => d.MetaMdlobj)
                    .WithMany(p => p.MetaObjbls)
                    .HasForeignKey(d => d.MetaMdlobjId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("meta_objbl_fk2");
            });

            modelBuilder.Entity<MetaObjbl1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("meta_objbl", "ap_mif");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar");

                entity.Property(e => e.IsEnable)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("is_enable")
                    .HasDefaultValueSql("'Y'::character varying");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.MetaBlId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("meta_bl_id")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.MetaMdlobjId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("meta_mdlobj_id")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.MetaObjblId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("meta_objbl_id")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Seq)
                    .HasPrecision(3)
                    .HasColumnName("seq");
            });

            modelBuilder.Entity<MetaObjblBackup>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("meta_objbl_backup", "ap_mif");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar");

                entity.Property(e => e.IsEnable)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("is_enable")
                    .HasDefaultValueSql("'Y'::character varying");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.MetaBlId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("meta_bl_id")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.MetaMdlobjId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("meta_mdlobj_id")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.MetaObjblId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("meta_objbl_id")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Seq)
                    .HasPrecision(3)
                    .HasColumnName("seq");
            });

            modelBuilder.Entity<MetaObjblParam>(entity =>
            {
                entity.ToTable("meta_objbl_param", "fw_mif");

                entity.HasIndex(e => new { e.MetaObjblId, e.ParamKey }, "meta_objbl_param_uk1")
                    .IsUnique();

                entity.Property(e => e.MetaObjblParamId)
                    .HasMaxLength(22)
                    .HasColumnName("meta_objbl_param_id")
                    .HasDefaultValueSql("''::character varying")
                    .HasComment("PK");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.MetaObjblId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("meta_objbl_id")
                    .HasDefaultValueSql("''::character varying")
                    .HasComment("資料物件邏輯ID");

                entity.Property(e => e.ParamKey)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("param_key")
                    .HasDefaultValueSql("''::character varying")
                    .HasComment("參數名");

                entity.Property(e => e.ParamValue)
                    .HasMaxLength(100)
                    .HasColumnName("param_value")
                    .HasComment("參數值");

                entity.HasOne(d => d.MetaObjbl)
                    .WithMany(p => p.MetaObjblParams)
                    .HasForeignKey(d => d.MetaObjblId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("meta_objbl_param_fk1");
            });

            modelBuilder.Entity<MetaObjpool>(entity =>
            {
                entity.HasKey(e => new { e.MetaObjpoolClass, e.MetaObjpoolCondition })
                    .HasName("meta_objpool_pk");

                entity.ToTable("meta_objpool", "fw_mif");

                entity.Property(e => e.MetaObjpoolClass)
                    .HasMaxLength(120)
                    .HasColumnName("meta_objpool_class")
                    .HasComment("宣告類名");

                entity.Property(e => e.MetaObjpoolCondition)
                    .HasMaxLength(120)
                    .HasColumnName("meta_objpool_condition")
                    .HasComment("條件");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.MetaObjpoolChksec)
                    .HasPrecision(3)
                    .HasColumnName("meta_objpool_chksec")
                    .HasDefaultValueSql("600")
                    .HasComment("檢查間隔");

                entity.Property(e => e.MetaObjpoolIdlemin)
                    .HasPrecision(4)
                    .HasColumnName("meta_objpool_idlemin")
                    .HasDefaultValueSql("90")
                    .HasComment("閒置分鐘");

                entity.Property(e => e.MetaObjpoolMax)
                    .HasPrecision(4)
                    .HasColumnName("meta_objpool_max")
                    .HasDefaultValueSql("100")
                    .HasComment("最大個數");
            });

            modelBuilder.Entity<MetaPoly>(entity =>
            {
                entity.HasKey(e => new { e.MetaPolyDeclareclass, e.MetaPolyCondition })
                    .HasName("meta_poly_pk");

                entity.ToTable("meta_poly", "fw_mif");

                entity.Property(e => e.MetaPolyDeclareclass)
                    .HasMaxLength(120)
                    .HasColumnName("meta_poly_declareclass")
                    .HasComment("宣告類名");

                entity.Property(e => e.MetaPolyCondition)
                    .HasMaxLength(120)
                    .HasColumnName("meta_poly_condition")
                    .HasComment("條件");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.MetaPolyCreateclass)
                    .IsRequired()
                    .HasMaxLength(120)
                    .HasColumnName("meta_poly_createclass")
                    .HasComment("實現類名");
            });

            modelBuilder.Entity<MetaSql>(entity =>
            {
                entity.ToTable("meta_sql", "fw_mif");

                entity.HasIndex(e => new { e.MetaSqlNo, e.MetaSqlDbms }, "ui_meta_sql")
                    .IsUnique();

                entity.Property(e => e.MetaSqlId)
                    .HasMaxLength(22)
                    .HasColumnName("meta_sql_id")
                    .HasDefaultValueSql("''::character varying")
                    .HasComment("SQL定義ID");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.MetaSqlDbms)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("meta_sql_dbms")
                    .HasDefaultValueSql("'Oracle'::character varying")
                    .HasComment("數據庫類型");

                entity.Property(e => e.MetaSqlDesc)
                    .HasMaxLength(200)
                    .HasColumnName("meta_sql_desc")
                    .HasDefaultValueSql("'NULL'::character varying")
                    .HasComment("描述");

                entity.Property(e => e.MetaSqlName)
                    .HasMaxLength(100)
                    .HasColumnName("meta_sql_name")
                    .HasComment("SQL定義名稱");

                entity.Property(e => e.MetaSqlNo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("meta_sql_no")
                    .HasComment("SQL定義編號");

                entity.Property(e => e.MetaSqlSort)
                    .HasMaxLength(100)
                    .HasColumnName("meta_sql_sort")
                    .HasDefaultValueSql("'NULL'::character varying")
                    .HasComment("排序");

                entity.Property(e => e.MetaSqlSql)
                    .IsRequired()
                    .HasMaxLength(7000)
                    .HasColumnName("meta_sql_sql")
                    .HasComment("SQL語句");

                entity.Property(e => e.MetaSqlType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("meta_sql_type")
                    .HasDefaultValueSql("'Q'::character varying")
                    .HasComment("用途");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasComment("異動人ID");
            });

            modelBuilder.Entity<MifAllguide>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mif_allguide", "ap_mif");

                entity.Property(e => e.Data1)
                    .HasMaxLength(256)
                    .HasColumnName("data1");

                entity.Property(e => e.Data2)
                    .HasMaxLength(256)
                    .HasColumnName("data2");

                entity.Property(e => e.Data3)
                    .HasMaxLength(256)
                    .HasColumnName("data3");

                entity.Property(e => e.Data4)
                    .HasMaxLength(256)
                    .HasColumnName("data4");

                entity.Property(e => e.Data5)
                    .HasMaxLength(256)
                    .HasColumnName("data5");

                entity.Property(e => e.DataSort)
                    .HasPrecision(4, 1)
                    .HasColumnName("data_sort");

                entity.Property(e => e.FactNo)
                    .HasMaxLength(20)
                    .HasColumnName("fact_no");

                entity.Property(e => e.GuideDesc)
                    .HasMaxLength(200)
                    .HasColumnName("guide_desc");

                entity.Property(e => e.GuideNo)
                    .HasMaxLength(100)
                    .HasColumnName("guide_no");

                entity.Property(e => e.HeadMk)
                    .HasMaxLength(1)
                    .HasColumnName("head_mk");

                entity.Property(e => e.StopMk)
                    .HasMaxLength(1)
                    .HasColumnName("stop_mk");

                entity.Property(e => e.UpGuideNo)
                    .HasMaxLength(100)
                    .HasColumnName("up_guide_no");
            });

            modelBuilder.Entity<MifBrand>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mif_brand", "ap_mif");

                entity.Property(e => e.Brand)
                    .HasMaxLength(30)
                    .HasColumnName("brand")
                    .HasComment("ex.Asics");

                entity.Property(e => e.BrandNo)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("brand_no")
                    .HasComment("ex.13");
            });

            modelBuilder.Entity<MifMesBwork>(entity =>
            {
                entity.HasKey(e => new { e.Facility, e.Workno, e.Workseq, e.Aufnr })
                    .HasName("mif_mes_bwork_pk");

                entity.ToTable("mif_mes_bwork", "ap_mif");

                entity.Property(e => e.Facility)
                    .HasMaxLength(256)
                    .HasColumnName("facility");

                entity.Property(e => e.Workno)
                    .HasMaxLength(20)
                    .HasColumnName("workno");

                entity.Property(e => e.Workseq)
                    .HasMaxLength(20)
                    .HasColumnName("workseq");

                entity.Property(e => e.Aufnr)
                    .HasMaxLength(20)
                    .HasColumnName("aufnr");

                entity.Property(e => e.Bmeng)
                    .HasPrecision(18, 8)
                    .HasColumnName("bmeng");

                entity.Property(e => e.Formulano)
                    .HasMaxLength(50)
                    .HasColumnName("formulano");

                entity.Property(e => e.Gamng)
                    .HasPrecision(18, 8)
                    .HasColumnName("gamng");

                entity.Property(e => e.Leftqty)
                    .HasPrecision(18, 8)
                    .HasColumnName("leftqty");

                entity.Property(e => e.Meins)
                    .HasMaxLength(20)
                    .HasColumnName("meins");

                entity.Property(e => e.Mescomponent)
                    .HasMaxLength(20)
                    .HasColumnName("mescomponent");

                entity.Property(e => e.Mesresource)
                    .HasMaxLength(256)
                    .HasColumnName("mesresource");

                entity.Property(e => e.Nameen)
                    .HasMaxLength(50)
                    .HasColumnName("nameen");

                entity.Property(e => e.Namezf)
                    .HasMaxLength(50)
                    .HasColumnName("namezf");

                entity.Property(e => e.Outboundtime)
                    .HasMaxLength(14)
                    .HasColumnName("outboundtime");

                entity.Property(e => e.Partcolor)
                    .HasMaxLength(50)
                    .HasColumnName("partcolor");

                entity.Property(e => e.Perqty)
                    .HasPrecision(18, 8)
                    .HasColumnName("perqty");

                entity.Property(e => e.Plnbez)
                    .HasMaxLength(20)
                    .HasColumnName("plnbez");

                entity.Property(e => e.Productkind)
                    .HasMaxLength(20)
                    .HasColumnName("productkind");

                entity.Property(e => e.RecTime)
                    .HasMaxLength(14)
                    .HasColumnName("rec_time");

                entity.Property(e => e.Resourcegroup)
                    .HasMaxLength(20)
                    .HasColumnName("resourcegroup");

                entity.Property(e => e.Rightqty)
                    .HasPrecision(18, 8)
                    .HasColumnName("rightqty");

                entity.Property(e => e.Shift)
                    .HasMaxLength(256)
                    .HasColumnName("shift");

                entity.Property(e => e.Stepname)
                    .HasMaxLength(256)
                    .HasColumnName("stepname");

                entity.Property(e => e.Universalstate)
                    .HasMaxLength(1)
                    .HasColumnName("universalstate");

                entity.Property(e => e.Werks)
                    .HasMaxLength(20)
                    .HasColumnName("werks");

                entity.Property(e => e.Workdate)
                    .HasMaxLength(8)
                    .HasColumnName("workdate");

                entity.Property(e => e.Wosize)
                    .HasMaxLength(50)
                    .HasColumnName("wosize");

                entity.Property(e => e.Zzatcolr)
                    .HasMaxLength(100)
                    .HasColumnName("zzatcolr");

                entity.Property(e => e.Zzmdmark)
                    .HasMaxLength(50)
                    .HasColumnName("zzmdmark");

                entity.Property(e => e.Zzmdnam)
                    .HasMaxLength(100)
                    .HasColumnName("zzmdnam");

                entity.Property(e => e.Zzmidsolmod)
                    .HasMaxLength(100)
                    .HasColumnName("zzmidsolmod");

                entity.Property(e => e.Zzoutsolmod)
                    .HasMaxLength(100)
                    .HasColumnName("zzoutsolmod");

                entity.Property(e => e.Zzstylcode)
                    .HasMaxLength(50)
                    .HasColumnName("zzstylcode");
            });

            modelBuilder.Entity<MifMesShoefqc>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mif_mes_shoefqc", "ap_mif");

                entity.Property(e => e.CreateTime)
                    .HasMaxLength(20)
                    .HasColumnName("create_time")
                    .HasComment("抄寫到Temp時間");

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(100)
                    .HasColumnName("create_user")
                    .HasComment("抄寫Temp排程");

                entity.Property(e => e.Createon)
                    .HasMaxLength(14)
                    .HasColumnName("createon")
                    .HasComment("Create時間");

                entity.Property(e => e.Fqcname)
                    .HasMaxLength(300)
                    .HasColumnName("fqcname")
                    .HasComment("fqcname");

                entity.Property(e => e.Posnr)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("posnr")
                    .HasComment("SAP Itme#");

                entity.Property(e => e.Timmeron)
                    .HasMaxLength(14)
                    .HasColumnName("timmeron")
                    .HasComment("Timmer轉入時間");

                entity.Property(e => e.UlSapErrCode)
                    .HasMaxLength(20)
                    .HasColumnName("ul_sap_err_code")
                    .HasComment("Upload SAP錯誤代碼");

                entity.Property(e => e.UlSapErrMsg)
                    .HasMaxLength(500)
                    .HasColumnName("ul_sap_err_msg")
                    .HasComment("Upload SAP上傳訊息");

                entity.Property(e => e.UlSapFileName)
                    .HasMaxLength(100)
                    .HasColumnName("ul_sap_file_name")
                    .HasComment("Upload SAP 檔案名稱");

                entity.Property(e => e.UlSapSts)
                    .HasMaxLength(1)
                    .HasColumnName("ul_sap_sts")
                    .HasComment("Upload SAP狀態");

                entity.Property(e => e.UlSapTime)
                    .HasMaxLength(14)
                    .HasColumnName("ul_sap_time")
                    .HasComment("Upload SAP時間");

                entity.Property(e => e.UlSapTransId)
                    .HasMaxLength(50)
                    .HasColumnName("ul_sap_trans_id")
                    .HasComment("Upload SAP交易代碼");

                entity.Property(e => e.Vbeln)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("vbeln")
                    .HasComment("SO#(訂單號碼)");

                entity.Property(e => e.ZzactInsp)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("zzact_insp")
                    .HasComment("實際驗貨日");

                entity.Property(e => e.ZzactInspDrc)
                    .HasMaxLength(50)
                    .HasColumnName("zzact_insp_drc")
                    .HasComment("實際驗貨的delay reason code");

                entity.Property(e => e.ZzactInspMemo)
                    .HasMaxLength(150)
                    .HasColumnName("zzact_insp_memo")
                    .HasComment("實際驗貨結果註記");

                entity.Property(e => e.ZzactInspResult)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("zzact_insp_result")
                    .HasComment("實際驗貨結果");

                entity.Property(e => e.Zzbatchid)
                    .HasMaxLength(2)
                    .HasColumnName("zzbatchid")
                    .HasComment("外部驗貨批次號");

                entity.Property(e => e.Zzchgflag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("zzchgflag")
                    .HasComment("更新註記");

                entity.Property(e => e.Zzqty)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("zzqty")
                    .HasComment("實際驗貨數量");
            });

            modelBuilder.Entity<MifMesShoeopgroup>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mif_mes_shoeopgroup", "ap_mif");

                entity.Property(e => e.Arbpl)
                    .HasMaxLength(20)
                    .HasColumnName("arbpl");

                entity.Property(e => e.Buildno)
                    .HasMaxLength(100)
                    .HasColumnName("buildno");

                entity.Property(e => e.Datagroup)
                    .HasMaxLength(256)
                    .HasColumnName("datagroup");

                entity.Property(e => e.Deptno)
                    .HasMaxLength(100)
                    .HasColumnName("deptno");

                entity.Property(e => e.Facilityname)
                    .HasMaxLength(256)
                    .HasColumnName("facilityname");

                entity.Property(e => e.Factoryno)
                    .HasMaxLength(100)
                    .HasColumnName("factoryno");

                entity.Property(e => e.Mainlineno)
                    .HasMaxLength(100)
                    .HasColumnName("mainlineno");

                entity.Property(e => e.Modifiedon)
                    .HasMaxLength(14)
                    .HasColumnName("modifiedon");

                entity.Property(e => e.Opgroupdesc)
                    .HasMaxLength(256)
                    .HasColumnName("opgroupdesc");

                entity.Property(e => e.Opgroupname)
                    .HasMaxLength(100)
                    .HasColumnName("opgroupname");

                entity.Property(e => e.Opgroupno)
                    .HasMaxLength(100)
                    .HasColumnName("opgroupno");

                entity.Property(e => e.Prvbe)
                    .HasMaxLength(300)
                    .HasColumnName("prvbe");

                entity.Property(e => e.Resourcename)
                    .HasMaxLength(256)
                    .HasColumnName("resourcename");

                entity.Property(e => e.Stand)
                    .HasMaxLength(256)
                    .HasColumnName("stand");

                entity.Property(e => e.Stepname)
                    .HasMaxLength(256)
                    .HasColumnName("stepname");

                entity.Property(e => e.Stopmk)
                    .HasMaxLength(1)
                    .HasColumnName("stopmk");

                entity.Property(e => e.Sublineno)
                    .HasMaxLength(100)
                    .HasColumnName("sublineno");

                entity.Property(e => e.Timmeron)
                    .HasMaxLength(14)
                    .HasColumnName("timmeron");
            });

            modelBuilder.Entity<MifMesShoeprod>(entity =>
            {
                entity.HasKey(e => new { e.Facility, e.Stepname, e.Action, e.Materialn })
                    .HasName("mif_mes_shoeprod_pkey");

                entity.ToTable("mif_mes_shoeprod", "ap_mif");

                entity.HasComment("鞋廠MES產量資料");

                entity.Property(e => e.Facility)
                    .HasMaxLength(256)
                    .HasColumnName("facility");

                entity.Property(e => e.Stepname)
                    .HasMaxLength(256)
                    .HasColumnName("stepname");

                entity.Property(e => e.Action)
                    .HasMaxLength(20)
                    .HasColumnName("action");

                entity.Property(e => e.Materialn)
                    .HasMaxLength(256)
                    .HasColumnName("materialn");

                entity.Property(e => e.Arbpl)
                    .HasMaxLength(20)
                    .HasColumnName("arbpl");

                entity.Property(e => e.Auart)
                    .HasMaxLength(20)
                    .HasColumnName("auart")
                    .HasComment("ZP01/ ZP02.. \r\n是否要報工在補料工單上 \r\n1-補料工單需報補料工 \r\n2-補料工單不報工\r\n3-補料工單報工回原量產工單\r\n(MES無法報回原工單)=2");

                entity.Property(e => e.Brand)
                    .HasMaxLength(100)
                    .HasColumnName("brand")
                    .HasComment("根據MDA料號抓出");

                entity.Property(e => e.Buildno)
                    .HasMaxLength(100)
                    .HasColumnName("buildno");

                entity.Property(e => e.Createon)
                    .HasMaxLength(14)
                    .HasColumnName("createon");

                entity.Property(e => e.Floor)
                    .HasMaxLength(20)
                    .HasColumnName("floor");

                entity.Property(e => e.Leftqty)
                    .HasPrecision(18, 3)
                    .HasColumnName("leftqty");

                entity.Property(e => e.Lindid)
                    .HasMaxLength(20)
                    .HasColumnName("lindid");

                entity.Property(e => e.Opgroup)
                    .HasMaxLength(100)
                    .HasColumnName("opgroup");

                entity.Property(e => e.Plnbez)
                    .HasMaxLength(20)
                    .HasColumnName("plnbez");

                entity.Property(e => e.Posnr)
                    .HasMaxLength(20)
                    .HasColumnName("posnr");

                entity.Property(e => e.Primaryquantity)
                    .HasPrecision(18, 3)
                    .HasColumnName("primaryquantity");

                entity.Property(e => e.Primaryunits)
                    .HasMaxLength(512)
                    .HasColumnName("primaryunits");

                entity.Property(e => e.Prodbatch)
                    .HasMaxLength(20)
                    .HasColumnName("prodbatch");

                entity.Property(e => e.Productno)
                    .HasMaxLength(256)
                    .HasColumnName("productno");

                entity.Property(e => e.Producttype)
                    .HasMaxLength(512)
                    .HasColumnName("producttype")
                    .HasComment("MH/HU/HC/HS/FG");

                entity.Property(e => e.Rcode)
                    .HasMaxLength(1)
                    .HasColumnName("rcode");

                entity.Property(e => e.Resource)
                    .HasMaxLength(256)
                    .HasColumnName("resource");

                entity.Property(e => e.Resourceg)
                    .HasMaxLength(20)
                    .HasColumnName("resourceg");

                entity.Property(e => e.Rightqty)
                    .HasPrecision(18, 3)
                    .HasColumnName("rightqty");

                entity.Property(e => e.Sizeno)
                    .HasMaxLength(50)
                    .HasColumnName("sizeno");

                entity.Property(e => e.Vbeln)
                    .HasMaxLength(20)
                    .HasColumnName("vbeln");

                entity.Property(e => e.Werks)
                    .HasMaxLength(20)
                    .HasColumnName("werks");

                entity.Property(e => e.Workno)
                    .HasMaxLength(20)
                    .HasColumnName("workno");

                entity.Property(e => e.Zzfactstylecode)
                    .HasMaxLength(100)
                    .HasColumnName("zzfactstylecode")
                    .HasComment("根據MDA料號抓出");

                entity.Property(e => e.Zzmdmar)
                    .HasMaxLength(300)
                    .HasColumnName("zzmdmar");

                entity.Property(e => e.Zzmidsol)
                    .HasMaxLength(100)
                    .HasColumnName("zzmidsol");

                entity.Property(e => e.Zzoutsol)
                    .HasMaxLength(100)
                    .HasColumnName("zzoutsol");

                entity.Property(e => e.Zzstylco)
                    .HasMaxLength(100)
                    .HasColumnName("zzstylco")
                    .HasComment("根據MDA料號抓出");

                entity.HasOne(d => d.PlnbezNavigation)
                    .WithMany(p => p.MifMesShoeprods)
                    .HasForeignKey(d => d.Plnbez)
                    .HasConstraintName("mif_mes_shoeprod_plnbez_fkey1");
            });

            modelBuilder.Entity<MifMesShoeqm>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mif_mes_shoeqm", "ap_mif");

                entity.Property(e => e.Approvetime)
                    .HasMaxLength(14)
                    .HasColumnName("approvetime")
                    .HasComment("審核時間註記，SYSDATE Format : YYYYMMDDHH24MiSS");

                entity.Property(e => e.Brandid)
                    .HasMaxLength(50)
                    .HasColumnName("brandid")
                    .HasComment("品牌");

                entity.Property(e => e.CreateTime)
                    .HasMaxLength(20)
                    .HasColumnName("create_time")
                    .HasComment("抄寫到Temp時間");

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(100)
                    .HasColumnName("create_user")
                    .HasComment("抄寫Temp排程");

                entity.Property(e => e.Createdby)
                    .HasMaxLength(100)
                    .HasColumnName("createdby")
                    .HasComment("MES原生欄位");

                entity.Property(e => e.Createdon)
                    .HasMaxLength(14)
                    .HasColumnName("createdon")
                    .HasComment("MES原生欄位");

                entity.Property(e => e.Defectcode)
                    .HasMaxLength(50)
                    .HasColumnName("defectcode")
                    .HasComment("不良原因代碼");

                entity.Property(e => e.Defectdesclocal)
                    .HasMaxLength(200)
                    .HasColumnName("defectdesclocal")
                    .HasComment("不良原因說明(Local)");

                entity.Property(e => e.Defectdesctw)
                    .HasMaxLength(200)
                    .HasColumnName("defectdesctw")
                    .HasComment("不良原因說明(中)");

                entity.Property(e => e.Defectqty)
                    .HasPrecision(18, 3)
                    .HasColumnName("defectqty")
                    .HasComment("不良數量");

                entity.Property(e => e.Defecttype)
                    .HasMaxLength(50)
                    .HasColumnName("defecttype")
                    .HasComment("不良分類代號");

                entity.Property(e => e.Defectypedsclocal)
                    .HasMaxLength(200)
                    .HasColumnName("defectypedsclocal")
                    .HasComment("不良分類說明(Local)");

                entity.Property(e => e.Defectypedsctw)
                    .HasMaxLength(200)
                    .HasColumnName("defectypedsctw")
                    .HasComment("不良分類說明(中)");

                entity.Property(e => e.Facilityname)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("facilityname")
                    .HasComment("VYSh_VNdn");

                entity.Property(e => e.Foqcno)
                    .HasMaxLength(20)
                    .HasColumnName("foqcno")
                    .HasComment("驗貨單號，FI+YYMMDD+三碼流水碼");

                entity.Property(e => e.Isdelete)
                    .HasMaxLength(1)
                    .HasColumnName("isdelete")
                    .HasComment("Y=已刪除");

                entity.Property(e => e.Leftqty)
                    .HasPrecision(18, 3)
                    .HasColumnName("leftqty")
                    .HasComment("左腳不良支數");

                entity.Property(e => e.Memo)
                    .HasMaxLength(150)
                    .HasColumnName("memo")
                    .HasComment("驗貨註記");

                entity.Property(e => e.Modifiedon)
                    .HasMaxLength(14)
                    .HasColumnName("modifiedon")
                    .HasComment("資料更改日期");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("name")
                    .HasComment("SAP不良類型{SAPDefectType }+建立日期yyyymmddHHmmss+兩碼流水碼");

                entity.Property(e => e.Orderid)
                    .HasMaxLength(20)
                    .HasColumnName("orderid")
                    .HasComment("訂單號碼");

                entity.Property(e => e.Orderlevel)
                    .HasMaxLength(20)
                    .HasColumnName("orderlevel")
                    .HasComment("訂單等級");

                entity.Property(e => e.Orderqty)
                    .HasMaxLength(20)
                    .HasColumnName("orderqty")
                    .HasComment("訂單數量");

                entity.Property(e => e.Outboundtime)
                    .HasMaxLength(14)
                    .HasColumnName("outboundtime")
                    .HasComment("OutBound時間註記，SYSDATE Format : YYYYMMDDHH24MiSS");

                entity.Property(e => e.Part)
                    .HasMaxLength(256)
                    .HasColumnName("part")
                    .HasComment("部位名稱");

                entity.Property(e => e.Partno)
                    .HasMaxLength(20)
                    .HasColumnName("partno")
                    .HasComment("部位代號");

                entity.Property(e => e.Plnbez)
                    .HasMaxLength(20)
                    .HasColumnName("plnbez")
                    .HasComment("產出料號");

                entity.Property(e => e.ProcessMk)
                    .HasMaxLength(1)
                    .HasColumnName("process_mk")
                    .HasComment("外圍取走資料寫入Y");

                entity.Property(e => e.Productdate)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("productdate")
                    .IsFixedLength(true)
                    .HasComment("實際製令檢驗日期");

                entity.Property(e => e.Productno)
                    .HasMaxLength(20)
                    .HasColumnName("productno")
                    .HasComment("工單號碼");

                entity.Property(e => e.Producttime)
                    .HasMaxLength(20)
                    .HasColumnName("producttime")
                    .HasComment("實際檢驗日回報時段");

                entity.Property(e => e.Producttype)
                    .IsRequired()
                    .HasMaxLength(512)
                    .HasColumnName("producttype")
                    .HasComment("產品類別");

                entity.Property(e => e.Qclevel)
                    .HasMaxLength(20)
                    .HasColumnName("qclevel")
                    .HasComment("驗貨等級");

                entity.Property(e => e.Qcqty)
                    .HasPrecision(18, 3)
                    .HasColumnName("qcqty")
                    .HasComment("驗貨數量");

                entity.Property(e => e.Rightqty)
                    .HasPrecision(18, 3)
                    .HasColumnName("rightqty")
                    .HasComment("右腳不良支數");

                entity.Property(e => e.Sapdefecttype)
                    .HasMaxLength(50)
                    .HasColumnName("sapdefecttype")
                    .HasComment("SAP不良類型");

                entity.Property(e => e.Shiftdefinitionshift)
                    .HasMaxLength(256)
                    .HasColumnName("shiftdefinitionshift")
                    .HasComment("班別");

                entity.Property(e => e.Sizeno)
                    .HasMaxLength(50)
                    .HasColumnName("sizeno")
                    .HasComment("生產size");

                entity.Property(e => e.Stepname)
                    .HasMaxLength(256)
                    .HasColumnName("stepname")
                    .HasComment("站點");

                entity.Property(e => e.Sublineno)
                    .HasMaxLength(20)
                    .HasColumnName("sublineno")
                    .HasComment("線別");

                entity.Property(e => e.Timmeron)
                    .HasMaxLength(14)
                    .HasColumnName("timmeron")
                    .HasComment("MES拋到RDB時間(yyyymmddhhmmss)");

                entity.Property(e => e.Werks)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("werks")
                    .HasComment("廠別");

                entity.Property(e => e.Zzactresult)
                    .HasMaxLength(1)
                    .HasColumnName("zzactresult")
                    .HasComment("實際檢驗結果，\"Y=準收(Accepted)\r\nN=未通過(Reject)\"");

                entity.Property(e => e.Zzbatchid)
                    .HasMaxLength(2)
                    .HasColumnName("zzbatchid")
                    .IsFixedLength(true)
                    .HasComment("外部驗貨批次號");

                entity.Property(e => e.Zzmdmark)
                    .HasMaxLength(300)
                    .HasColumnName("zzmdmark")
                    .HasComment("型體代號+顏色代號(Article)");
            });

            modelBuilder.Entity<MifMesSoleprod>(entity =>
            {
                entity.HasKey(e => new { e.Facility, e.Stepid, e.Action, e.Workno, e.Workseq, e.Aufnr, e.ActWorkdate, e.ActShift })
                    .HasName("mif_mes_soleprod_pk");

                entity.ToTable("mif_mes_soleprod", "ap_mif");

                entity.HasIndex(e => new { e.Facility, e.Stepid, e.Action, e.Workno, e.Workseq, e.Aufnr }, "mif_mes_soleprod_idx");

                entity.Property(e => e.Facility)
                    .HasMaxLength(256)
                    .HasColumnName("facility");

                entity.Property(e => e.Stepid)
                    .HasMaxLength(256)
                    .HasColumnName("stepid");

                entity.Property(e => e.Action)
                    .HasMaxLength(20)
                    .HasColumnName("action");

                entity.Property(e => e.Workno)
                    .HasMaxLength(20)
                    .HasColumnName("workno");

                entity.Property(e => e.Workseq)
                    .HasMaxLength(20)
                    .HasColumnName("workseq");

                entity.Property(e => e.Aufnr)
                    .HasMaxLength(20)
                    .HasColumnName("aufnr");

                entity.Property(e => e.ActWorkdate)
                    .HasMaxLength(8)
                    .HasColumnName("act_workdate");

                entity.Property(e => e.ActShift)
                    .HasMaxLength(256)
                    .HasColumnName("act_shift");

                entity.Property(e => e.Arbpl)
                    .HasMaxLength(20)
                    .HasColumnName("arbpl");

                entity.Property(e => e.Auart)
                    .HasMaxLength(20)
                    .HasColumnName("auart");

                entity.Property(e => e.Bmeng)
                    .HasPrecision(18, 8)
                    .HasColumnName("bmeng");

                entity.Property(e => e.Brandid)
                    .HasMaxLength(20)
                    .HasColumnName("brandid");

                entity.Property(e => e.Feedto)
                    .HasMaxLength(256)
                    .HasColumnName("feedto");

                entity.Property(e => e.Formulano)
                    .HasMaxLength(50)
                    .HasColumnName("formulano");

                entity.Property(e => e.Leftqty)
                    .HasPrecision(18, 8)
                    .HasColumnName("leftqty");

                entity.Property(e => e.Maktx)
                    .HasMaxLength(50)
                    .HasColumnName("maktx");

                entity.Property(e => e.Mescomponent)
                    .HasMaxLength(20)
                    .HasColumnName("mescomponent");

                entity.Property(e => e.Mesresource)
                    .HasMaxLength(256)
                    .HasColumnName("mesresource");

                entity.Property(e => e.Nameen)
                    .HasMaxLength(50)
                    .HasColumnName("nameen");

                entity.Property(e => e.Namezf)
                    .HasMaxLength(50)
                    .HasColumnName("namezf");

                entity.Property(e => e.Plnbez)
                    .HasMaxLength(20)
                    .HasColumnName("plnbez");

                entity.Property(e => e.Posnr)
                    .HasMaxLength(20)
                    .HasColumnName("posnr");

                entity.Property(e => e.Primaryquantity)
                    .HasPrecision(18, 8)
                    .HasColumnName("primaryquantity");

                entity.Property(e => e.Primaryunits)
                    .HasMaxLength(512)
                    .HasColumnName("primaryunits");

                entity.Property(e => e.Prodbatch)
                    .HasMaxLength(20)
                    .HasColumnName("prodbatch");

                entity.Property(e => e.Productkind)
                    .HasMaxLength(20)
                    .HasColumnName("productkind");

                entity.Property(e => e.RecTime)
                    .HasMaxLength(14)
                    .HasColumnName("rec_time");

                entity.Property(e => e.Resourcegroup)
                    .HasMaxLength(20)
                    .HasColumnName("resourcegroup");

                entity.Property(e => e.Rightqty)
                    .HasPrecision(18, 8)
                    .HasColumnName("rightqty");

                entity.Property(e => e.Sgtscat)
                    .HasMaxLength(20)
                    .HasColumnName("sgtscat");

                entity.Property(e => e.Shift)
                    .HasMaxLength(256)
                    .HasColumnName("shift");

                entity.Property(e => e.Vbeln)
                    .HasMaxLength(20)
                    .HasColumnName("vbeln");

                entity.Property(e => e.Werks)
                    .HasMaxLength(20)
                    .HasColumnName("werks");

                entity.Property(e => e.Workdate)
                    .HasMaxLength(8)
                    .HasColumnName("workdate");

                entity.Property(e => e.Wosize)
                    .HasMaxLength(50)
                    .HasColumnName("wosize");

                entity.Property(e => e.Zzatcolr)
                    .HasMaxLength(100)
                    .HasColumnName("zzatcolr");

                entity.Property(e => e.Zzcolorcode)
                    .HasMaxLength(50)
                    .HasColumnName("zzcolorcode");

                entity.Property(e => e.Zzmdmark)
                    .HasMaxLength(50)
                    .HasColumnName("zzmdmark");

                entity.Property(e => e.Zzmdnam)
                    .HasMaxLength(100)
                    .HasColumnName("zzmdnam");

                entity.Property(e => e.Zzmidsolmod)
                    .HasMaxLength(100)
                    .HasColumnName("zzmidsolmod");

                entity.Property(e => e.Zzoutsolmod)
                    .HasMaxLength(100)
                    .HasColumnName("zzoutsolmod");

                entity.Property(e => e.Zzstylcode)
                    .HasMaxLength(50)
                    .HasColumnName("zzstylcode");
            });

            modelBuilder.Entity<MifMpsSche>(entity =>
            {
                entity.HasKey(e => new { e.ProdBatch, e.Zstono, e.Zstonr, e.Vbeln, e.Posnr })
                    .HasName("mif_mps_sche_pk");

                entity.ToTable("mif_mps_sche", "ap_mif");

                entity.Property(e => e.ProdBatch)
                    .HasMaxLength(20)
                    .HasColumnName("prod_batch");

                entity.Property(e => e.Zstono)
                    .HasMaxLength(10)
                    .HasColumnName("zstono");

                entity.Property(e => e.Zstonr)
                    .HasMaxLength(5)
                    .HasColumnName("zstonr");

                entity.Property(e => e.Vbeln)
                    .HasMaxLength(20)
                    .HasColumnName("vbeln");

                entity.Property(e => e.Posnr)
                    .HasMaxLength(20)
                    .HasColumnName("posnr");

                entity.Property(e => e.Actreqdate)
                    .HasMaxLength(10)
                    .HasColumnName("actreqdate");

                entity.Property(e => e.Arbpl)
                    .HasMaxLength(20)
                    .HasColumnName("arbpl");

                entity.Property(e => e.ChgCode)
                    .HasMaxLength(1)
                    .HasColumnName("chg_code");

                entity.Property(e => e.Deliverydate)
                    .HasMaxLength(10)
                    .HasColumnName("deliverydate");

                entity.Property(e => e.FileName)
                    .HasMaxLength(50)
                    .HasColumnName("file_name");

                entity.Property(e => e.Gamng)
                    .HasPrecision(18, 8)
                    .HasColumnName("gamng");

                entity.Property(e => e.Gltrs)
                    .HasMaxLength(8)
                    .HasColumnName("gltrs");

                entity.Property(e => e.Gmein)
                    .HasMaxLength(3)
                    .HasColumnName("gmein");

                entity.Property(e => e.Gstrs)
                    .HasMaxLength(8)
                    .HasColumnName("gstrs");

                entity.Property(e => e.MfgType)
                    .HasMaxLength(3)
                    .HasColumnName("mfg_type");

                entity.Property(e => e.ProdMatnr)
                    .HasMaxLength(20)
                    .HasColumnName("prod_matnr");

                entity.Property(e => e.ProdPlant)
                    .HasMaxLength(4)
                    .HasColumnName("prod_plant");

                entity.Property(e => e.RecId)
                    .HasMaxLength(23)
                    .HasColumnName("rec_id");

                entity.Property(e => e.RecTime)
                    .HasMaxLength(14)
                    .HasColumnName("rec_time");

                entity.Property(e => e.Seqno)
                    .HasMaxLength(4)
                    .HasColumnName("seqno");

                entity.Property(e => e.SgtRcat)
                    .HasMaxLength(20)
                    .HasColumnName("sgt_rcat");

                entity.Property(e => e.Timestamp)
                    .HasMaxLength(20)
                    .HasColumnName("timestamp");

                entity.Property(e => e.ZlQty)
                    .HasPrecision(18, 8)
                    .HasColumnName("zl_qty");

                entity.Property(e => e.ZrQty)
                    .HasPrecision(18, 8)
                    .HasColumnName("zr_qty");
            });

            modelBuilder.Entity<MifObbqmd>(entity =>
            {
                entity.HasKey(e => e.Bqmdname)
                    .HasName("mif_obbqmd_pk");

                entity.ToTable("mif_obbqmd", "ap_mif");

                entity.Property(e => e.Bqmdname)
                    .HasMaxLength(256)
                    .HasColumnName("bqmdname");

                entity.Property(e => e.Aufnr)
                    .HasMaxLength(20)
                    .HasColumnName("aufnr");

                entity.Property(e => e.Createdby)
                    .HasMaxLength(50)
                    .HasColumnName("createdby");

                entity.Property(e => e.Createdon)
                    .HasMaxLength(14)
                    .HasColumnName("createdon");

                entity.Property(e => e.Defectcode)
                    .HasMaxLength(50)
                    .HasColumnName("defectcode");

                entity.Property(e => e.Defectdescen)
                    .HasMaxLength(200)
                    .HasColumnName("defectdescen");

                entity.Property(e => e.Defectdesctw)
                    .HasMaxLength(200)
                    .HasColumnName("defectdesctw");

                entity.Property(e => e.Defectkind)
                    .HasMaxLength(50)
                    .HasColumnName("defectkind");

                entity.Property(e => e.Defecttype)
                    .HasMaxLength(50)
                    .HasColumnName("defecttype");

                entity.Property(e => e.Empid)
                    .HasMaxLength(20)
                    .HasColumnName("empid");

                entity.Property(e => e.Facility)
                    .HasMaxLength(256)
                    .HasColumnName("facility");

                entity.Property(e => e.Formulano)
                    .HasMaxLength(50)
                    .HasColumnName("formulano");

                entity.Property(e => e.Leftqty)
                    .HasPrecision(18, 8)
                    .HasColumnName("leftqty");

                entity.Property(e => e.Mescomponent)
                    .HasMaxLength(20)
                    .HasColumnName("mescomponent");

                entity.Property(e => e.Mesresource)
                    .HasMaxLength(256)
                    .HasColumnName("mesresource");

                entity.Property(e => e.Nameen)
                    .HasMaxLength(50)
                    .HasColumnName("nameen");

                entity.Property(e => e.Namezf)
                    .HasMaxLength(50)
                    .HasColumnName("namezf");

                entity.Property(e => e.Outboundtime)
                    .HasMaxLength(14)
                    .HasColumnName("outboundtime");

                entity.Property(e => e.Plnbez)
                    .HasMaxLength(20)
                    .HasColumnName("plnbez");

                entity.Property(e => e.Processmk)
                    .HasMaxLength(1)
                    .HasColumnName("processmk")
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.Prodbatch)
                    .HasMaxLength(20)
                    .HasColumnName("prodbatch");

                entity.Property(e => e.Productkind)
                    .HasMaxLength(20)
                    .HasColumnName("productkind");

                entity.Property(e => e.ReceiveTime)
                    .HasMaxLength(14)
                    .HasColumnName("receive_time");

                entity.Property(e => e.Resourcegroup)
                    .HasMaxLength(20)
                    .HasColumnName("resourcegroup");

                entity.Property(e => e.Rightqty)
                    .HasPrecision(18, 8)
                    .HasColumnName("rightqty");

                entity.Property(e => e.Shift)
                    .HasMaxLength(256)
                    .HasColumnName("shift");

                entity.Property(e => e.Step)
                    .HasMaxLength(256)
                    .HasColumnName("step");

                entity.Property(e => e.Totalqty)
                    .HasPrecision(18, 8)
                    .HasColumnName("totalqty");

                entity.Property(e => e.WebProcessmk)
                    .HasMaxLength(1)
                    .HasColumnName("web_processmk")
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.Workdate)
                    .HasMaxLength(8)
                    .HasColumnName("workdate")
                    .IsFixedLength(true);

                entity.Property(e => e.Workno)
                    .HasMaxLength(20)
                    .HasColumnName("workno");

                entity.Property(e => e.Workseq)
                    .HasMaxLength(20)
                    .HasColumnName("workseq");

                entity.Property(e => e.Wosize)
                    .HasMaxLength(50)
                    .HasColumnName("wosize");

                entity.Property(e => e.Zzatcolr)
                    .HasMaxLength(100)
                    .HasColumnName("zzatcolr");

                entity.Property(e => e.Zzcolorcode)
                    .HasMaxLength(50)
                    .HasColumnName("zzcolorcode");

                entity.Property(e => e.Zzmdmark)
                    .HasMaxLength(50)
                    .HasColumnName("zzmdmark");

                entity.Property(e => e.Zzmdnam)
                    .HasMaxLength(100)
                    .HasColumnName("zzmdnam");

                entity.Property(e => e.Zzmidsolmod)
                    .HasMaxLength(100)
                    .HasColumnName("zzmidsolmod");

                entity.Property(e => e.Zzoutsolmod)
                    .HasMaxLength(100)
                    .HasColumnName("zzoutsolmod");

                entity.Property(e => e.Zzstylcode)
                    .HasMaxLength(50)
                    .HasColumnName("zzstylcode");
            });

            modelBuilder.Entity<MifObmpsSche>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mif_obmps_sche", "ap_mif");

                entity.Property(e => e.Arbpl)
                    .HasMaxLength(10)
                    .HasColumnName("arbpl");

                entity.Property(e => e.C1Start)
                    .HasMaxLength(8)
                    .HasColumnName("c1_start");

                entity.Property(e => e.C2Start)
                    .HasMaxLength(8)
                    .HasColumnName("c2_start");

                entity.Property(e => e.C3Start)
                    .HasMaxLength(8)
                    .HasColumnName("c3_start");

                entity.Property(e => e.Del12)
                    .HasMaxLength(12)
                    .HasColumnName("del12");

                entity.Property(e => e.FileName)
                    .HasMaxLength(50)
                    .HasColumnName("file_name");

                entity.Property(e => e.Gamng)
                    .HasPrecision(15, 3)
                    .HasColumnName("gamng");

                entity.Property(e => e.Gltrs)
                    .HasMaxLength(8)
                    .HasColumnName("gltrs");

                entity.Property(e => e.Gmein)
                    .HasMaxLength(3)
                    .HasColumnName("gmein");

                entity.Property(e => e.Gstrs)
                    .HasMaxLength(8)
                    .HasColumnName("gstrs");

                entity.Property(e => e.OrType)
                    .HasMaxLength(1)
                    .HasColumnName("or_type");

                entity.Property(e => e.Plnbez)
                    .HasMaxLength(18)
                    .HasColumnName("plnbez");

                entity.Property(e => e.Posnr)
                    .HasMaxLength(6)
                    .HasColumnName("posnr");

                entity.Property(e => e.ProdBatch)
                    .HasMaxLength(20)
                    .HasColumnName("prod_batch");

                entity.Property(e => e.RecMk)
                    .HasMaxLength(1)
                    .HasColumnName("rec_mk");

                entity.Property(e => e.Timestamp)
                    .HasMaxLength(14)
                    .HasColumnName("timestamp");

                entity.Property(e => e.Vbeln)
                    .HasMaxLength(10)
                    .HasColumnName("vbeln");

                entity.Property(e => e.Verid)
                    .HasMaxLength(4)
                    .HasColumnName("verid");

                entity.Property(e => e.Werks)
                    .HasMaxLength(4)
                    .HasColumnName("werks");

                entity.Property(e => e.ZlQty)
                    .HasPrecision(15, 3)
                    .HasColumnName("zl_qty");

                entity.Property(e => e.ZrQty)
                    .HasPrecision(15, 3)
                    .HasColumnName("zr_qty");
            });

            modelBuilder.Entity<MifObsapPartm>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mif_obsap_partm", "ap_mif");

                entity.Property(e => e.BrandId)
                    .HasMaxLength(4)
                    .HasColumnName("brand_id");

                entity.Property(e => e.Component)
                    .HasMaxLength(5)
                    .HasColumnName("component");

                entity.Property(e => e.Deactive)
                    .HasMaxLength(1)
                    .HasColumnName("deactive");

                entity.Property(e => e.FileName)
                    .HasMaxLength(50)
                    .HasColumnName("file_name");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(50)
                    .HasColumnName("name_en");

                entity.Property(e => e.NameZf)
                    .HasMaxLength(50)
                    .HasColumnName("name_zf");

                entity.Property(e => e.RecMk)
                    .HasMaxLength(1)
                    .HasColumnName("rec_mk");

                entity.Property(e => e.Timestamp)
                    .HasMaxLength(14)
                    .HasColumnName("timestamp");
            });

            modelBuilder.Entity<MifObsapShippingd1>(entity =>
            {
                entity.HasKey(e => new { e.Zplann, e.Ctnseq, e.Vbeln, e.Posnr, e.FileName, e.Zvers })
                    .HasName("mif_obsap_shippingd1_pk");

                entity.ToTable("mif_obsap_shippingd1", "ap_mif");

                entity.Property(e => e.Zplann)
                    .HasMaxLength(15)
                    .HasColumnName("zplann")
                    .HasComment("包裝計畫單號");

                entity.Property(e => e.Ctnseq)
                    .HasMaxLength(25)
                    .HasColumnName("ctnseq")
                    .HasComment("內部箱號");

                entity.Property(e => e.Vbeln)
                    .HasMaxLength(10)
                    .HasColumnName("vbeln")
                    .HasComment("訂單號碼");

                entity.Property(e => e.Posnr)
                    .HasMaxLength(6)
                    .HasColumnName("posnr")
                    .HasComment("訂單項次");

                entity.Property(e => e.FileName)
                    .HasMaxLength(50)
                    .HasColumnName("file_name")
                    .HasComment("檔案名");

                entity.Property(e => e.Zvers)
                    .HasMaxLength(14)
                    .HasColumnName("zvers");

                entity.Property(e => e.Article)
                    .HasMaxLength(40)
                    .HasColumnName("article")
                    .HasComment("型體名稱(sd自行維護)");

                entity.Property(e => e.Atcolr)
                    .HasMaxLength(300)
                    .HasColumnName("atcolr")
                    .HasComment("顏色代號英文說明");

                entity.Property(e => e.BarcodeI)
                    .HasMaxLength(18)
                    .HasColumnName("barcode_i")
                    .HasComment("內盒條碼");

                entity.Property(e => e.BstkdE)
                    .HasMaxLength(35)
                    .HasColumnName("bstkd_e")
                    .HasComment("po no.");

                entity.Property(e => e.Category)
                    .HasMaxLength(40)
                    .HasColumnName("category")
                    .HasComment("category");

                entity.Property(e => e.Colorcode)
                    .HasMaxLength(40)
                    .HasColumnName("colorcode")
                    .HasComment("顏色代號");

                entity.Property(e => e.Content)
                    .HasMaxLength(20)
                    .HasColumnName("content")
                    .HasComment("產品類別英文名稱");

                entity.Property(e => e.CustboxI)
                    .HasMaxLength(40)
                    .HasColumnName("custbox_i")
                    .HasComment("客戶內盒代號");

                entity.Property(e => e.Custpo)
                    .HasMaxLength(35)
                    .HasColumnName("custpo")
                    .HasComment("customer po");

                entity.Property(e => e.DeliveryCode)
                    .HasMaxLength(24)
                    .HasColumnName("delivery_code")
                    .HasComment("出貨地址代碼");

                entity.Property(e => e.DevCode)
                    .HasMaxLength(40)
                    .HasColumnName("dev_code")
                    .HasComment("開發代碼");

                entity.Property(e => e.Gendr)
                    .HasMaxLength(20)
                    .HasColumnName("gendr")
                    .HasComment("性別代號");

                entity.Property(e => e.Ketdat)
                    .HasMaxLength(8)
                    .HasColumnName("ketdat")
                    .HasComment("訂單交期");

                entity.Property(e => e.Matnr)
                    .HasMaxLength(18)
                    .HasColumnName("matnr")
                    .HasComment("料號");

                entity.Property(e => e.MatnroI)
                    .HasMaxLength(18)
                    .HasColumnName("matnro_i")
                    .HasComment("內盒料號");

                entity.Property(e => e.MatnrospI)
                    .HasMaxLength(120)
                    .HasColumnName("matnrosp_i")
                    .HasComment("內盒規格說明");

                entity.Property(e => e.Mdmark)
                    .HasMaxLength(40)
                    .HasColumnName("mdmark")
                    .HasComment("配色說明");

                entity.Property(e => e.ModelName)
                    .HasMaxLength(120)
                    .HasColumnName("model_name")
                    .HasComment("型體名稱");

                entity.Property(e => e.Move)
                    .HasMaxLength(1)
                    .HasColumnName("move")
                    .HasDefaultValueSql("'N'::character varying");

                entity.Property(e => e.Pkk)
                    .HasMaxLength(100)
                    .HasColumnName("pkk")
                    .HasComment("pkk/lot table");

                entity.Property(e => e.Poart)
                    .HasMaxLength(18)
                    .HasColumnName("poart")
                    .HasComment("artic_no");

                entity.Property(e => e.Ponum)
                    .HasMaxLength(35)
                    .HasColumnName("ponum")
                    .HasComment("客人訂單號");

                entity.Property(e => e.Qty)
                    .HasMaxLength(50)
                    .HasColumnName("qty")
                    .HasComment("數量");

                entity.Property(e => e.RecMk)
                    .HasMaxLength(1)
                    .HasColumnName("rec_mk")
                    .HasComment("接收註記(n.mes未接收 y.mes己接收)");

                entity.Property(e => e.SalesUnit)
                    .HasMaxLength(3)
                    .HasColumnName("sales_unit")
                    .HasComment("銷售單位");

                entity.Property(e => e.Serialno)
                    .HasMaxLength(50)
                    .HasColumnName("serialno")
                    .HasComment("serial from serial to");

                entity.Property(e => e.ServIdno)
                    .HasMaxLength(25)
                    .HasColumnName("serv_idno")
                    .HasComment("service identifier");

                entity.Property(e => e.SgtRcat)
                    .HasMaxLength(16)
                    .HasColumnName("sgt_rcat")
                    .HasComment("segmentation");

                entity.Property(e => e.ShipType)
                    .HasMaxLength(23)
                    .HasColumnName("ship_type")
                    .HasComment("ship type");

                entity.Property(e => e.Shoew)
                    .HasMaxLength(30)
                    .HasColumnName("shoew")
                    .HasComment("shoe width");

                entity.Property(e => e.Size4)
                    .HasMaxLength(200)
                    .HasColumnName("size4")
                    .HasComment("size (四國尺碼)");

                entity.Property(e => e.SizeArg)
                    .HasMaxLength(12)
                    .HasColumnName("size_arg")
                    .HasComment("阿根廷尺碼");

                entity.Property(e => e.SizeBr)
                    .HasMaxLength(12)
                    .HasColumnName("size_br")
                    .HasComment("巴西尺碼");

                entity.Property(e => e.SizeFr)
                    .HasMaxLength(12)
                    .HasColumnName("size_fr")
                    .HasComment("法國尺碼");

                entity.Property(e => e.SizeJp)
                    .HasMaxLength(12)
                    .HasColumnName("size_jp")
                    .HasComment("日本尺碼");

                entity.Property(e => e.SizeKr)
                    .HasMaxLength(12)
                    .HasColumnName("size_kr")
                    .HasComment("kr尺碼");

                entity.Property(e => e.SizeMx)
                    .HasMaxLength(12)
                    .HasColumnName("size_mx")
                    .HasComment("墨西哥尺碼");

                entity.Property(e => e.Sizeukus)
                    .HasMaxLength(100)
                    .HasColumnName("sizeukus")
                    .HasComment("美英尺碼");

                entity.Property(e => e.SoSize)
                    .HasMaxLength(100)
                    .HasColumnName("so_size")
                    .HasComment("接單size");

                entity.Property(e => e.SpecialNote)
                    .HasMaxLength(40)
                    .HasColumnName("special_note")
                    .HasComment("特殊註記");

                entity.Property(e => e.Stylecode)
                    .HasMaxLength(40)
                    .HasColumnName("stylecode")
                    .HasComment("型體代號");

                entity.Property(e => e.SubsalesPo)
                    .HasMaxLength(35)
                    .HasColumnName("subsales_po")
                    .HasComment("subsales po");

                entity.Property(e => e.Width)
                    .HasMaxLength(40)
                    .HasColumnName("width")
                    .HasComment("肥度 (楦寬)");
            });

            modelBuilder.Entity<MifObsapShippingm1>(entity =>
            {
                entity.HasKey(e => new { e.Zplann, e.Ctnseq, e.PrdSite, e.Zvers, e.FileName })
                    .HasName("mif_obsap_shippingm1_pk");

                entity.ToTable("mif_obsap_shippingm1", "ap_mif");

                entity.Property(e => e.Zplann)
                    .HasMaxLength(15)
                    .HasColumnName("zplann")
                    .HasComment("包裝計劃單號");

                entity.Property(e => e.Ctnseq)
                    .HasMaxLength(25)
                    .HasColumnName("ctnseq")
                    .HasComment("內部箱號");

                entity.Property(e => e.PrdSite)
                    .HasMaxLength(4)
                    .HasColumnName("prd_site")
                    .HasComment("生產工廠代號");

                entity.Property(e => e.Zvers)
                    .HasMaxLength(14)
                    .HasColumnName("zvers")
                    .HasComment("版次");

                entity.Property(e => e.FileName)
                    .HasMaxLength(50)
                    .HasColumnName("file_name")
                    .HasComment("檔案名");

                entity.Property(e => e.Address)
                    .HasMaxLength(660)
                    .HasColumnName("address")
                    .HasComment("ship-to客戶地址");

                entity.Property(e => e.Artplan)
                    .HasMaxLength(6)
                    .HasColumnName("artplan")
                    .HasComment("品牌工廠編碼");

                entity.Property(e => e.Artplna)
                    .HasMaxLength(6)
                    .HasColumnName("artplna")
                    .HasComment("品牌工廠代號");

                entity.Property(e => e.Barcode3)
                    .HasMaxLength(25)
                    .HasColumnName("barcode_3")
                    .HasComment("條碼");

                entity.Property(e => e.BarcodeO)
                    .HasMaxLength(25)
                    .HasColumnName("barcode_o")
                    .HasComment("外箱條碼");

                entity.Property(e => e.Boxkun)
                    .HasMaxLength(20)
                    .HasColumnName("boxkun")
                    .HasComment("客戶箱號/自訂箱序/系統箱序");

                entity.Property(e => e.Boxnum)
                    .HasMaxLength(25)
                    .HasColumnName("boxnum")
                    .HasComment("外箱序號");

                entity.Property(e => e.Breit)
                    .HasMaxLength(13)
                    .HasColumnName("breit")
                    .HasComment("外箱規格-寬");

                entity.Property(e => e.Commodtyp)
                    .HasMaxLength(30)
                    .HasColumnName("commodtyp")
                    .HasComment("commodities type");

                entity.Property(e => e.Consignee)
                    .HasMaxLength(120)
                    .HasColumnName("consignee")
                    .HasComment("收件公司");

                entity.Property(e => e.Contw)
                    .HasMaxLength(30)
                    .HasColumnName("contw")
                    .HasComment("小包重量/外箱重量");

                entity.Property(e => e.CtnNtgew)
                    .HasMaxLength(13)
                    .HasColumnName("ctn_ntgew")
                    .HasComment("外箱重量(克)");

                entity.Property(e => e.Ctnno)
                    .HasMaxLength(12)
                    .HasColumnName("ctnno")
                    .HasComment("箱序/總箱數");

                entity.Property(e => e.Cuport)
                    .HasMaxLength(90)
                    .HasColumnName("cuport")
                    .HasComment("客戶港口名稱");

                entity.Property(e => e.Custbox)
                    .HasMaxLength(40)
                    .HasColumnName("custbox")
                    .HasComment("客戶外箱代號");

                entity.Property(e => e.Custsku)
                    .HasMaxLength(40)
                    .HasColumnName("custsku")
                    .HasComment("customer_sku");

                entity.Property(e => e.Destnt)
                    .HasMaxLength(50)
                    .HasColumnName("destnt")
                    .HasComment("國家代碼");

                entity.Property(e => e.Double)
                    .HasMaxLength(6)
                    .HasColumnName("double")
                    .HasComment("每箱雙數");

                entity.Property(e => e.Eeantp)
                    .HasMaxLength(5)
                    .HasColumnName("eeantp")
                    .HasComment("條碼類型");

                entity.Property(e => e.GpsCuna)
                    .HasMaxLength(240)
                    .HasColumnName("gps_cuna")
                    .HasComment("gps_customer_name");

                entity.Property(e => e.GpsCuno)
                    .HasMaxLength(10)
                    .HasColumnName("gps_cuno")
                    .HasComment("gps_customer_no");

                entity.Property(e => e.Grosswe)
                    .HasMaxLength(17)
                    .HasColumnName("grosswe")
                    .HasComment("毛重");

                entity.Property(e => e.Grosswet)
                    .HasMaxLength(14)
                    .HasColumnName("grosswet")
                    .HasComment("毛重(kg)下限");

                entity.Property(e => e.GrosswetT)
                    .HasMaxLength(14)
                    .HasColumnName("grosswet_t")
                    .HasComment("毛重(kg)上限");

                entity.Property(e => e.Hoehe)
                    .HasMaxLength(13)
                    .HasColumnName("hoehe")
                    .HasComment("外箱規格-高");

                entity.Property(e => e.Kunnr)
                    .HasMaxLength(10)
                    .HasColumnName("kunnr")
                    .HasComment("sold-to客戶代號");

                entity.Property(e => e.Laeng)
                    .HasMaxLength(13)
                    .HasColumnName("laeng")
                    .HasComment("外箱規格-長");

                entity.Property(e => e.Land1)
                    .HasMaxLength(150)
                    .HasColumnName("land1")
                    .HasComment("生產國家");

                entity.Property(e => e.Matnro)
                    .HasMaxLength(18)
                    .HasColumnName("matnro")
                    .HasComment("外箱料號");

                entity.Property(e => e.Matnrocbm)
                    .HasMaxLength(17)
                    .HasColumnName("matnrocbm")
                    .HasComment("外箱cbm");

                entity.Property(e => e.Matnrolwh)
                    .HasMaxLength(30)
                    .HasColumnName("matnrolwh")
                    .HasComment("外箱尺寸");

                entity.Property(e => e.Matnrosp)
                    .HasMaxLength(120)
                    .HasColumnName("matnrosp")
                    .HasComment("外箱規格說明");

                entity.Property(e => e.Meabm)
                    .HasMaxLength(3)
                    .HasColumnName("meabm")
                    .HasComment("外箱規格-單位");

                entity.Property(e => e.Mixcode)
                    .HasMaxLength(12)
                    .HasColumnName("mixcode")
                    .HasComment("混裝代碼");

                entity.Property(e => e.Move)
                    .HasMaxLength(1)
                    .HasColumnName("move")
                    .HasDefaultValueSql("'N'::character varying");

                entity.Property(e => e.Netwe)
                    .HasMaxLength(17)
                    .HasColumnName("netwe")
                    .HasComment("淨重");

                entity.Property(e => e.Netwet)
                    .HasMaxLength(14)
                    .HasColumnName("netwet")
                    .HasComment("淨重(kg)下限");

                entity.Property(e => e.NetwetT)
                    .HasMaxLength(14)
                    .HasColumnName("netwet_t")
                    .HasComment("淨重(kg)上限");

                entity.Property(e => e.PayerCode)
                    .HasMaxLength(10)
                    .HasColumnName("payer_code")
                    .HasComment("付款方代碼");

                entity.Property(e => e.PayerName)
                    .HasMaxLength(80)
                    .HasColumnName("payer_name")
                    .HasComment("付款方名稱");

                entity.Property(e => e.Product)
                    .HasMaxLength(40)
                    .HasColumnName("product")
                    .HasComment("product");

                entity.Property(e => e.Qrcode)
                    .HasMaxLength(25)
                    .HasColumnName("qrcode")
                    .HasComment("fty _qrcode");

                entity.Property(e => e.RecMk)
                    .HasMaxLength(1)
                    .HasColumnName("rec_mk")
                    .HasDefaultValueSql("'n'::character varying")
                    .HasComment("接收註記(n.mes未接收 y.mes己接收)");

                entity.Property(e => e.Recip)
                    .HasMaxLength(210)
                    .HasColumnName("recip")
                    .HasComment("收件者");

                entity.Property(e => e.Remark)
                    .HasMaxLength(300)
                    .HasColumnName("remark")
                    .HasComment("備註");

                entity.Property(e => e.Salemark)
                    .HasMaxLength(25)
                    .HasColumnName("salemark")
                    .HasComment("salesman_sample_to");

                entity.Property(e => e.Salepkmk)
                    .HasMaxLength(75)
                    .HasColumnName("salepkmk")
                    .HasComment("銷樣訂單側嘜呈現字樣");

                entity.Property(e => e.Season)
                    .HasMaxLength(20)
                    .HasColumnName("season")
                    .HasComment("season");

                entity.Property(e => e.ShipSortl2)
                    .HasMaxLength(60)
                    .HasColumnName("ship_sortl2")
                    .HasComment("ship-to search term2");

                entity.Property(e => e.Soldtol)
                    .HasMaxLength(60)
                    .HasColumnName("soldtol")
                    .HasComment("sold-to向線");

                entity.Property(e => e.Sortl)
                    .HasMaxLength(20)
                    .HasColumnName("sortl")
                    .HasComment("ship to search term1");

                entity.Property(e => e.Trackcm)
                    .HasMaxLength(40)
                    .HasColumnName("trackcm")
                    .HasComment("快遞公司");

                entity.Property(e => e.Trackno)
                    .HasMaxLength(20)
                    .HasColumnName("trackno")
                    .HasComment("快遞單號");

                entity.Property(e => e.Tradmk)
                    .HasMaxLength(40)
                    .HasColumnName("tradmk")
                    .HasComment("trademark");

                entity.Property(e => e.TrfMark)
                    .HasMaxLength(1)
                    .HasColumnName("trf_mark")
                    .HasComment("刪除註記");

                entity.Property(e => e.Vtxtk)
                    .HasMaxLength(20)
                    .HasColumnName("vtxtk")
                    .HasComment("品牌名稱");

                entity.Property(e => e.Zcntnoa)
                    .HasMaxLength(15)
                    .HasColumnName("zcntnoa")
                    .HasComment("實際櫃號");

                entity.Property(e => e.Zcntnoi)
                    .HasMaxLength(25)
                    .HasColumnName("zcntnoi")
                    .HasComment("系統櫃號");

                entity.Property(e => e.Zzsubcon)
                    .HasMaxLength(4)
                    .HasColumnName("zzsubcon")
                    .HasComment("代工工廠");
            });

            modelBuilder.Entity<MifObsapShippingslr>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mif_obsap_shippingslr", "ap_mif");

                entity.HasComment("sap嘜頭資料(slr)");

                entity.Property(e => e.Content)
                    .HasMaxLength(1000)
                    .HasColumnName("content")
                    .HasComment("內容");

                entity.Property(e => e.FileName)
                    .HasMaxLength(50)
                    .HasColumnName("file_name")
                    .HasComment("檔案名");

                entity.Property(e => e.MarkType)
                    .HasMaxLength(2)
                    .HasColumnName("mark_type")
                    .HasComment("資訊類別");

                entity.Property(e => e.RecMk)
                    .HasMaxLength(1)
                    .HasColumnName("rec_mk")
                    .HasDefaultValueSql("'n'::character varying")
                    .HasComment("接收註記(n.mes未接收 y.mes己接收)");

                entity.Property(e => e.Zplann)
                    .HasMaxLength(15)
                    .HasColumnName("zplann")
                    .HasComment("sap計畫單");
            });

            modelBuilder.Entity<MifObsapWo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mif_obsap_wo", "ap_mif");

                entity.Property(e => e.Astnr)
                    .HasMaxLength(4)
                    .HasColumnName("astnr");

                entity.Property(e => e.AstnrTxt)
                    .HasMaxLength(30)
                    .HasColumnName("astnr_txt");

                entity.Property(e => e.Auart)
                    .HasMaxLength(4)
                    .HasColumnName("auart");

                entity.Property(e => e.Aufld)
                    .HasMaxLength(20)
                    .HasColumnName("aufld");

                entity.Property(e => e.Aufnr)
                    .HasMaxLength(12)
                    .HasColumnName("aufnr");

                entity.Property(e => e.FileName)
                    .HasMaxLength(50)
                    .HasColumnName("file_name");

                entity.Property(e => e.Gamng)
                    .HasPrecision(15, 3)
                    .HasColumnName("gamng");

                entity.Property(e => e.Gltrp)
                    .HasMaxLength(8)
                    .HasColumnName("gltrp");

                entity.Property(e => e.Gstrp)
                    .HasMaxLength(8)
                    .HasColumnName("gstrp");

                entity.Property(e => e.LeftQty)
                    .HasPrecision(15, 3)
                    .HasColumnName("left_qty");

                entity.Property(e => e.Meins)
                    .HasMaxLength(3)
                    .HasColumnName("meins");

                entity.Property(e => e.Plnal)
                    .HasMaxLength(2)
                    .HasColumnName("plnal");

                entity.Property(e => e.Plnbez)
                    .HasMaxLength(18)
                    .HasColumnName("plnbez");

                entity.Property(e => e.Plnnr)
                    .HasMaxLength(20)
                    .HasColumnName("plnnr");

                entity.Property(e => e.Posnr)
                    .HasMaxLength(6)
                    .HasColumnName("posnr");

                entity.Property(e => e.ProdBatch)
                    .HasMaxLength(20)
                    .HasColumnName("prod_batch");

                entity.Property(e => e.Rcode)
                    .HasMaxLength(1)
                    .HasColumnName("rcode");

                entity.Property(e => e.RecMk)
                    .HasMaxLength(1)
                    .HasColumnName("rec_mk");

                entity.Property(e => e.RightQty)
                    .HasPrecision(15, 3)
                    .HasColumnName("right_qty");

                entity.Property(e => e.SgtScat)
                    .HasMaxLength(16)
                    .HasColumnName("sgt_scat");

                entity.Property(e => e.SoSize)
                    .HasMaxLength(30)
                    .HasColumnName("so_size");

                entity.Property(e => e.Stlal)
                    .HasMaxLength(2)
                    .HasColumnName("stlal");

                entity.Property(e => e.Stlan)
                    .HasMaxLength(1)
                    .HasColumnName("stlan");

                entity.Property(e => e.Timestamp)
                    .HasMaxLength(14)
                    .HasColumnName("timestamp");

                entity.Property(e => e.Uebtk)
                    .HasMaxLength(1)
                    .HasColumnName("uebtk");

                entity.Property(e => e.Uebto)
                    .HasMaxLength(4)
                    .HasColumnName("uebto");

                entity.Property(e => e.Vbeln)
                    .HasMaxLength(10)
                    .HasColumnName("vbeln");

                entity.Property(e => e.Verid)
                    .HasMaxLength(20)
                    .HasColumnName("verid");

                entity.Property(e => e.Werks)
                    .HasMaxLength(4)
                    .HasColumnName("werks");

                entity.Property(e => e.WoSize)
                    .HasMaxLength(30)
                    .HasColumnName("wo_size");

                entity.Property(e => e.ZzpartNo)
                    .HasMaxLength(5)
                    .HasColumnName("zzpart_no");
            });

            modelBuilder.Entity<MifObsapWoComp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mif_obsap_wo_comp", "ap_mif");

                entity.Property(e => e.Aufnr)
                    .HasMaxLength(20)
                    .HasColumnName("aufnr");

                entity.Property(e => e.Charg)
                    .HasMaxLength(20)
                    .HasColumnName("charg");

                entity.Property(e => e.Component)
                    .HasMaxLength(20)
                    .HasColumnName("component");

                entity.Property(e => e.CreateTime)
                    .HasMaxLength(20)
                    .HasColumnName("create_time")
                    .HasComment("寫入RDB的時間，到秒，同一次執行的同一批資料都寫一樣");

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(100)
                    .HasColumnName("create_user")
                    .HasComment("寫入RDB的人員，由TOS JOB寫入，則寫JOB NAME");

                entity.Property(e => e.Erskz)
                    .HasMaxLength(1)
                    .HasColumnName("erskz");

                entity.Property(e => e.FileName)
                    .HasMaxLength(50)
                    .HasColumnName("file_name");

                entity.Property(e => e.Idnrk)
                    .HasMaxLength(20)
                    .HasColumnName("idnrk");

                entity.Property(e => e.LeftQty)
                    .HasPrecision(18, 8)
                    .HasColumnName("left_qty");

                entity.Property(e => e.Lgort)
                    .HasMaxLength(20)
                    .HasColumnName("lgort");

                entity.Property(e => e.Meins)
                    .HasMaxLength(20)
                    .HasColumnName("meins");

                entity.Property(e => e.Menge)
                    .HasPrecision(18, 8)
                    .HasColumnName("menge");

                entity.Property(e => e.Posnr)
                    .HasMaxLength(20)
                    .HasColumnName("posnr");

                entity.Property(e => e.ProcessErrmsg)
                    .HasMaxLength(300)
                    .HasColumnName("process_errmsg")
                    .HasComment("同步MES失敗原因，失敗才有值");

                entity.Property(e => e.ProcessMk)
                    .HasMaxLength(1)
                    .HasColumnName("process_mk")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("同步MES的註記");

                entity.Property(e => e.ProcessTime)
                    .HasMaxLength(20)
                    .HasColumnName("process_time")
                    .HasComment("同步到MES的時間，到秒");

                entity.Property(e => e.ProcessUser)
                    .HasMaxLength(100)
                    .HasColumnName("process_user")
                    .HasComment("同步MES的TOS JOB NAME");

                entity.Property(e => e.RecMk)
                    .HasMaxLength(1)
                    .HasColumnName("rec_mk")
                    .HasDefaultValueSql("'N'::character varying");

                entity.Property(e => e.Rgekz)
                    .HasMaxLength(1)
                    .HasColumnName("rgekz");

                entity.Property(e => e.RightQty)
                    .HasPrecision(18, 8)
                    .HasColumnName("right_qty");

                entity.Property(e => e.Rsnum)
                    .HasMaxLength(20)
                    .HasColumnName("rsnum");

                entity.Property(e => e.Sgtrcat)
                    .HasMaxLength(20)
                    .HasColumnName("sgtrcat");

                entity.Property(e => e.Timestamp)
                    .HasMaxLength(20)
                    .HasColumnName("timestamp");

                entity.Property(e => e.Vlsch)
                    .HasMaxLength(300)
                    .HasColumnName("vlsch");

                entity.Property(e => e.Vornr)
                    .HasMaxLength(20)
                    .HasColumnName("vornr");

                entity.Property(e => e.Werks)
                    .HasMaxLength(20)
                    .HasColumnName("werks");

                entity.Property(e => e.WerksIs)
                    .HasMaxLength(20)
                    .HasColumnName("werks_is");
            });

            modelBuilder.Entity<MifSapPartm>(entity =>
            {
                entity.HasKey(e => new { e.BrandId, e.Component })
                    .HasName("mif_sap_partm_pk");

                entity.ToTable("mif_sap_partm", "ap_mif");

                entity.Property(e => e.BrandId)
                    .HasMaxLength(4)
                    .HasColumnName("brand_id");

                entity.Property(e => e.Component)
                    .HasMaxLength(5)
                    .HasColumnName("component");

                entity.Property(e => e.Deactive)
                    .HasMaxLength(1)
                    .HasColumnName("deactive");

                entity.Property(e => e.FileName)
                    .HasMaxLength(50)
                    .HasColumnName("file_name");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(50)
                    .HasColumnName("name_en");

                entity.Property(e => e.NameZf)
                    .HasMaxLength(50)
                    .HasColumnName("name_zf");

                entity.Property(e => e.RecTime)
                    .HasMaxLength(14)
                    .HasColumnName("rec_time");

                entity.Property(e => e.Timestamp)
                    .HasMaxLength(14)
                    .HasColumnName("timestamp");
            });

            modelBuilder.Entity<MifSapSo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mif_sap_so", "ap_mif");

                entity.Property(e => e.Aedat)
                    .HasMaxLength(20)
                    .HasColumnName("aedat")
                    .HasComment("取消日期");

                entity.Property(e => e.Arktx)
                    .HasMaxLength(50)
                    .HasColumnName("arktx")
                    .HasComment("銷售訂單項目短文");

                entity.Property(e => e.Auart)
                    .HasMaxLength(20)
                    .HasColumnName("auart")
                    .HasComment("銷售文件類型");

                entity.Property(e => e.Bezei)
                    .HasMaxLength(50)
                    .HasColumnName("bezei")
                    .HasComment("說明");

                entity.Property(e => e.Bstdk)
                    .HasMaxLength(20)
                    .HasColumnName("bstdk")
                    .HasComment("客戶下單日期");

                entity.Property(e => e.Bstkd)
                    .HasMaxLength(50)
                    .HasColumnName("bstkd")
                    .HasComment("客戶PO");

                entity.Property(e => e.BstkdE)
                    .HasMaxLength(50)
                    .HasColumnName("bstkd_e")
                    .HasComment("收貨人採購單號碼");

                entity.Property(e => e.DelFlag)
                    .HasMaxLength(1)
                    .HasColumnName("del_flag")
                    .HasComment("刪除");

                entity.Property(e => e.Destination)
                    .HasMaxLength(20)
                    .HasColumnName("destination")
                    .HasComment("出貨地");

                entity.Property(e => e.EndCustSo)
                    .HasMaxLength(50)
                    .HasColumnName("end_cust_so")
                    .HasComment("終端客戶訂單號");

                entity.Property(e => e.FactOrder)
                    .HasMaxLength(20)
                    .HasColumnName("fact_order")
                    .HasComment("工廠訂單");

                entity.Property(e => e.FshSeason)
                    .HasMaxLength(4)
                    .HasColumnName("fsh_season")
                    .HasComment("季節");

                entity.Property(e => e.Kdmat)
                    .HasMaxLength(50)
                    .HasColumnName("kdmat")
                    .HasComment("客戶物料編號");

                entity.Property(e => e.Kwmeng)
                    .HasPrecision(18, 8)
                    .HasColumnName("kwmeng")
                    .HasComment("數量");

                entity.Property(e => e.MatnrSo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("matnr_so")
                    .HasComment("銷售料號");

                entity.Property(e => e.RecId)
                    .HasMaxLength(100)
                    .HasColumnName("rec_id")
                    .HasComment("Talend 傳遞ID");

                entity.Property(e => e.ReqDate1)
                    .HasMaxLength(20)
                    .HasColumnName("req_date1")
                    .HasComment("需求日期1");

                entity.Property(e => e.ReqDate2)
                    .HasMaxLength(20)
                    .HasColumnName("req_date2")
                    .HasComment("需求日期2");

                entity.Property(e => e.ReqDate3)
                    .HasMaxLength(20)
                    .HasColumnName("req_date3")
                    .HasComment("需求日期3");

                entity.Property(e => e.SgtRcat)
                    .HasMaxLength(20)
                    .HasColumnName("sgt_rcat")
                    .HasComment("需求類別");

                entity.Property(e => e.SizeNo)
                    .HasMaxLength(50)
                    .HasColumnName("size_no")
                    .HasComment("訂單SIZE");

                entity.Property(e => e.SoRemark)
                    .HasMaxLength(500)
                    .HasColumnName("so_remark")
                    .HasComment("訂單訊息註記");

                entity.Property(e => e.Spart)
                    .HasMaxLength(2)
                    .HasColumnName("spart")
                    .HasComment("部門");

                entity.Property(e => e.Timestamp)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("timestamp")
                    .HasComment("傳送日期時間");

                entity.Property(e => e.Uepos)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("uepos")
                    .HasComment("銷售訂單GA項次");

                entity.Property(e => e.Vbeln)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("vbeln")
                    .HasComment("銷售訂單");

                entity.Property(e => e.Vbpos)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("vbpos")
                    .HasComment("銷售訂單項次");

                entity.Property(e => e.Vdatu)
                    .HasMaxLength(20)
                    .HasColumnName("vdatu")
                    .HasComment("計劃出貨日期");

                entity.Property(e => e.Vrkme)
                    .HasMaxLength(20)
                    .HasColumnName("vrkme")
                    .HasComment("計量單位");

                entity.Property(e => e.Vsart)
                    .HasMaxLength(20)
                    .HasColumnName("vsart")
                    .HasComment("出貨方式(shipping Type)");

                entity.Property(e => e.Vtweg)
                    .HasMaxLength(2)
                    .HasColumnName("vtweg")
                    .HasComment("銷售通路代碼");

                entity.Property(e => e.Werks)
                    .HasMaxLength(20)
                    .HasColumnName("werks")
                    .HasComment("接單工廠");

                entity.Property(e => e.ZzbuyPeriod)
                    .HasMaxLength(20)
                    .HasColumnName("zzbuy_period")
                    .HasComment("接單年月");

                entity.Property(e => e.Zzdgdif)
                    .HasMaxLength(20)
                    .HasColumnName("zzdgdif")
                    .HasComment("難易度");

                entity.Property(e => e.Zzlaunch)
                    .HasMaxLength(20)
                    .HasColumnName("zzlaunch")
                    .HasComment("Launch Remark");

                entity.Property(e => e.ZzpurchNoSs)
                    .HasMaxLength(50)
                    .HasColumnName("zzpurch_no_ss")
                    .HasComment("SubSales採購單號");
            });

            modelBuilder.Entity<MifSapSoCnf>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mif_sap_so_cnf", "ap_mif");

                entity.Property(e => e.ArchFlag)
                    .HasMaxLength(1)
                    .HasColumnName("arch_flag")
                    .HasComment("刪除");

                entity.Property(e => e.BuildNo)
                    .HasMaxLength(10)
                    .HasColumnName("build_no")
                    .HasComment("棟別");

                entity.Property(e => e.CancelMk)
                    .HasMaxLength(1)
                    .HasColumnName("cancel_mk")
                    .HasDefaultValueSql("'N'::character varying")
                    .HasComment("PP取消註記");

                entity.Property(e => e.CreateTime)
                    .HasMaxLength(20)
                    .HasColumnName("create_time")
                    .HasComment("建立時間");

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(50)
                    .HasColumnName("create_user")
                    .HasComment("建立人員");

                entity.Property(e => e.FloorNo)
                    .HasMaxLength(10)
                    .HasColumnName("floor_no")
                    .HasComment("樓層");

                entity.Property(e => e.ModifyTime)
                    .HasMaxLength(20)
                    .HasColumnName("modify_time")
                    .HasComment("修改時間");

                entity.Property(e => e.ModifyUser)
                    .HasMaxLength(50)
                    .HasColumnName("modify_user")
                    .HasComment("修改人員");

                entity.Property(e => e.RecId)
                    .HasMaxLength(100)
                    .HasColumnName("rec_id")
                    .HasComment("Talend 傳遞ID");

                entity.Property(e => e.ReqDate1)
                    .HasMaxLength(20)
                    .HasColumnName("req_date1")
                    .HasComment("需求日期1");

                entity.Property(e => e.ReqDate2)
                    .HasMaxLength(20)
                    .HasColumnName("req_date2")
                    .HasComment("需求日期2");

                entity.Property(e => e.ReqDate3)
                    .HasMaxLength(20)
                    .HasColumnName("req_date3")
                    .HasComment("需求日期3");

                entity.Property(e => e.Timestamp)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("timestamp")
                    .HasComment("傳送日期時間");

                entity.Property(e => e.Uepos)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("uepos")
                    .HasComment("銷售訂單GA項次");

                entity.Property(e => e.Vbeln)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("vbeln")
                    .HasComment("銷售訂單");

                entity.Property(e => e.Vdatu)
                    .HasMaxLength(20)
                    .HasColumnName("vdatu")
                    .HasComment("計劃出貨日期");

                entity.Property(e => e.ZodrType)
                    .HasMaxLength(50)
                    .HasColumnName("zodr_type")
                    .HasComment("訂單類型");
            });

            modelBuilder.Entity<MifSapWo>(entity =>
            {
                entity.HasKey(e => e.Aufnr)
                    .HasName("mif_sap_wo_pk");

                entity.ToTable("mif_sap_wo", "ap_mif");

                entity.Property(e => e.Aufnr)
                    .HasMaxLength(20)
                    .HasColumnName("aufnr");

                entity.Property(e => e.Astnr)
                    .HasMaxLength(20)
                    .HasColumnName("astnr");

                entity.Property(e => e.AstnrTxt)
                    .HasMaxLength(50)
                    .HasColumnName("astnr_txt");

                entity.Property(e => e.Auart)
                    .HasMaxLength(20)
                    .HasColumnName("auart");

                entity.Property(e => e.ChgCode)
                    .HasMaxLength(1)
                    .HasColumnName("chg_code");

                entity.Property(e => e.Dispo)
                    .HasMaxLength(3)
                    .HasColumnName("dispo");

                entity.Property(e => e.FactOrder)
                    .HasMaxLength(20)
                    .HasColumnName("fact_order");

                entity.Property(e => e.FileName)
                    .HasMaxLength(50)
                    .HasColumnName("file_name");

                entity.Property(e => e.GaMatnr)
                    .HasMaxLength(20)
                    .HasColumnName("ga_matnr");

                entity.Property(e => e.Gamng)
                    .HasPrecision(18, 8)
                    .HasColumnName("gamng");

                entity.Property(e => e.Gltrp)
                    .HasMaxLength(8)
                    .HasColumnName("gltrp");

                entity.Property(e => e.Gltrs)
                    .HasMaxLength(8)
                    .HasColumnName("gltrs");

                entity.Property(e => e.Gstrp)
                    .HasMaxLength(8)
                    .HasColumnName("gstrp");

                entity.Property(e => e.Gstrs)
                    .HasMaxLength(8)
                    .HasColumnName("gstrs");

                entity.Property(e => e.LeftQty)
                    .HasPrecision(18, 8)
                    .HasColumnName("left_qty");

                entity.Property(e => e.Maktx)
                    .HasMaxLength(50)
                    .HasColumnName("maktx");

                entity.Property(e => e.Meins)
                    .HasMaxLength(20)
                    .HasColumnName("meins");

                entity.Property(e => e.Plnal)
                    .HasMaxLength(2)
                    .HasColumnName("plnal");

                entity.Property(e => e.Plnbez)
                    .HasMaxLength(20)
                    .HasColumnName("plnbez");

                entity.Property(e => e.Posnr)
                    .HasMaxLength(20)
                    .HasColumnName("posnr");

                entity.Property(e => e.ProdBatch)
                    .HasMaxLength(20)
                    .HasColumnName("prod_batch");

                entity.Property(e => e.Rcode)
                    .HasMaxLength(1)
                    .HasColumnName("rcode");

                entity.Property(e => e.RecTime)
                    .HasMaxLength(14)
                    .HasColumnName("rec_time");

                entity.Property(e => e.RightQty)
                    .HasPrecision(18, 8)
                    .HasColumnName("right_qty");

                entity.Property(e => e.SgtScat)
                    .HasMaxLength(20)
                    .HasColumnName("sgt_scat");

                entity.Property(e => e.SoSize)
                    .HasMaxLength(50)
                    .HasColumnName("so_size");

                entity.Property(e => e.Stlal)
                    .HasMaxLength(20)
                    .HasColumnName("stlal");

                entity.Property(e => e.Stlan)
                    .HasMaxLength(1)
                    .HasColumnName("stlan");

                entity.Property(e => e.Timestamp)
                    .HasMaxLength(20)
                    .HasColumnName("timestamp");

                entity.Property(e => e.Uebtk)
                    .HasMaxLength(1)
                    .HasColumnName("uebtk");

                entity.Property(e => e.Uebto)
                    .HasMaxLength(4)
                    .HasColumnName("uebto");

                entity.Property(e => e.Vbeln)
                    .HasMaxLength(20)
                    .HasColumnName("vbeln");

                entity.Property(e => e.Verid)
                    .HasMaxLength(4)
                    .HasColumnName("verid");

                entity.Property(e => e.Werks)
                    .HasMaxLength(20)
                    .HasColumnName("werks");

                entity.Property(e => e.WoSize)
                    .HasMaxLength(50)
                    .HasColumnName("wo_size");

                entity.Property(e => e.ZzpartNo)
                    .HasMaxLength(5)
                    .HasColumnName("zzpart_no");
            });

            modelBuilder.Entity<MifSapZrpp0009n>(entity =>
            {
                entity.HasKey(e => new { e.Timestamp, e.Vbeln, e.Uepos, e.Vbpos, e.MatnrSo })
                    .HasName("mif_sap_zrpp0009n_pk");

                entity.ToTable("mif_sap_zrpp0009n", "ap_mif");

                entity.HasComment("銷售訂單");

                entity.HasIndex(e => e.MatnrSo, "mif_sap_zrpp0009n_matnr_so_idx");

                entity.HasIndex(e => e.Timestamp, "mif_sap_zrpp0009n_timestamp_idx");

                entity.HasIndex(e => e.Uepos, "mif_sap_zrpp0009n_uepos_idx");

                entity.HasIndex(e => e.Vbpos, "mif_sap_zrpp0009n_vbpos_idx");

                entity.Property(e => e.Timestamp)
                    .HasMaxLength(14)
                    .HasColumnName("timestamp")
                    .HasComment("傳送日期時間");

                entity.Property(e => e.Vbeln)
                    .HasMaxLength(10)
                    .HasColumnName("vbeln")
                    .HasComment("銷售訂單");

                entity.Property(e => e.Uepos)
                    .HasMaxLength(6)
                    .HasColumnName("uepos")
                    .HasComment("銷售訂單GA項次");

                entity.Property(e => e.Vbpos)
                    .HasMaxLength(6)
                    .HasColumnName("vbpos")
                    .HasComment("銷售訂單項次");

                entity.Property(e => e.MatnrSo)
                    .HasMaxLength(18)
                    .HasColumnName("matnr_so")
                    .HasComment("銷售料號");

                entity.Property(e => e.Aedat)
                    .HasMaxLength(8)
                    .HasColumnName("aedat")
                    .HasComment("取消日期");

                entity.Property(e => e.ArchFlag)
                    .HasMaxLength(1)
                    .HasColumnName("arch_flag");

                entity.Property(e => e.Arktx)
                    .HasMaxLength(40)
                    .HasColumnName("arktx")
                    .HasComment("銷售訂單項目短文");

                entity.Property(e => e.Auart)
                    .HasMaxLength(4)
                    .HasColumnName("auart")
                    .HasComment("銷售文件類型");

                entity.Property(e => e.Bezei)
                    .HasMaxLength(20)
                    .HasColumnName("bezei")
                    .HasComment("說明");

                entity.Property(e => e.Bstdk)
                    .HasMaxLength(8)
                    .HasColumnName("bstdk")
                    .HasComment("客戶下單日期");

                entity.Property(e => e.Bstkd)
                    .HasMaxLength(35)
                    .HasColumnName("bstkd")
                    .HasComment("客戶PO");

                entity.Property(e => e.BstkdE)
                    .HasMaxLength(35)
                    .HasColumnName("bstkd_e")
                    .HasComment("收貨人採購單號碼");

                entity.Property(e => e.DelFlag)
                    .HasMaxLength(1)
                    .HasColumnName("del_flag")
                    .HasComment("刪除");

                entity.Property(e => e.Destination)
                    .HasMaxLength(2)
                    .HasColumnName("destination")
                    .HasComment("出貨地");

                entity.Property(e => e.EndCustSo)
                    .HasMaxLength(35)
                    .HasColumnName("end_cust_so")
                    .HasComment("終端客戶訂單號");

                entity.Property(e => e.FactOrder)
                    .HasMaxLength(20)
                    .HasColumnName("fact_order")
                    .HasComment("工廠訂單");

                entity.Property(e => e.FshSeason)
                    .HasMaxLength(4)
                    .HasColumnName("fsh_season")
                    .HasComment("季節");

                entity.Property(e => e.Kdmat)
                    .HasMaxLength(35)
                    .HasColumnName("kdmat")
                    .HasComment("客戶物料編號");

                entity.Property(e => e.Kwmeng)
                    .HasMaxLength(13)
                    .HasColumnName("kwmeng")
                    .HasComment("數量");

                entity.Property(e => e.RecId)
                    .HasMaxLength(100)
                    .HasColumnName("rec_id")
                    .HasComment("Talend 傳遞ID");

                entity.Property(e => e.ReqDate1)
                    .HasMaxLength(8)
                    .HasColumnName("req_date1")
                    .HasComment("需求日期1");

                entity.Property(e => e.ReqDate2)
                    .HasMaxLength(8)
                    .HasColumnName("req_date2")
                    .HasComment("需求日期2");

                entity.Property(e => e.ReqDate3)
                    .HasMaxLength(8)
                    .HasColumnName("req_date3")
                    .HasComment("需求日期3");

                entity.Property(e => e.SgtRcat)
                    .HasMaxLength(16)
                    .HasColumnName("sgt_rcat")
                    .HasComment("需求類別");

                entity.Property(e => e.SizeNo)
                    .HasMaxLength(30)
                    .HasColumnName("size_no")
                    .HasComment("訂單SIZE");

                entity.Property(e => e.SoRemark)
                    .HasMaxLength(500)
                    .HasColumnName("so_remark")
                    .HasComment("訂單訊息註記");

                entity.Property(e => e.Spart)
                    .HasMaxLength(2)
                    .HasColumnName("spart")
                    .HasComment("部門");

                entity.Property(e => e.Vdatu)
                    .HasMaxLength(8)
                    .HasColumnName("vdatu")
                    .HasComment("計劃出貨日期");

                entity.Property(e => e.Vrkme)
                    .HasMaxLength(3)
                    .HasColumnName("vrkme")
                    .HasComment("計量單位");

                entity.Property(e => e.Vsart)
                    .HasMaxLength(2)
                    .HasColumnName("vsart")
                    .HasComment("出貨方式(shipping Type)");

                entity.Property(e => e.Vtweg)
                    .HasMaxLength(2)
                    .HasColumnName("vtweg")
                    .HasComment("銷售通路代碼");

                entity.Property(e => e.Werks)
                    .HasMaxLength(4)
                    .HasColumnName("werks")
                    .HasComment("接單工廠");

                entity.Property(e => e.ZzbuyPeriod)
                    .HasMaxLength(10)
                    .HasColumnName("zzbuy_period")
                    .HasComment("接單年月");

                entity.Property(e => e.Zzdgdif)
                    .HasMaxLength(1)
                    .HasColumnName("zzdgdif")
                    .HasComment("難易度");

                entity.Property(e => e.Zzlaunch)
                    .HasMaxLength(1)
                    .HasColumnName("zzlaunch")
                    .HasComment("Launch Remark");

                entity.Property(e => e.ZzpurchNoSs)
                    .HasMaxLength(35)
                    .HasColumnName("zzpurch_no_ss")
                    .HasComment("SubSales採購單號");
            });

            modelBuilder.Entity<MifShippingKind>(entity =>
            {
                entity.HasKey(e => new { e.Site, e.KindDataKey })
                    .HasName("mif_shipping_kind_pk_1");

                entity.ToTable("mif_shipping_kind", "ap_mif");

                entity.Property(e => e.Site)
                    .HasMaxLength(4)
                    .HasColumnName("site");

                entity.Property(e => e.KindDataKey)
                    .HasMaxLength(10)
                    .HasColumnName("kind_data_key");
            });

            modelBuilder.Entity<MifShippingKindDatum>(entity =>
            {
                entity.HasKey(e => e.Key)
                    .HasName("mif_shipping_kind_data_pk_1");

                entity.ToTable("mif_shipping_kind_data", "ap_mif");

                entity.HasIndex(e => e.Key, "index_pk_1");

                entity.Property(e => e.Key)
                    .HasMaxLength(4)
                    .HasColumnName("key");

                entity.Property(e => e.Folder)
                    .HasMaxLength(10)
                    .HasColumnName("folder");

                entity.Property(e => e.KindDesc)
                    .HasMaxLength(40)
                    .HasColumnName("kind_desc");

                entity.Property(e => e.KindNo)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnName("kind_no");

                entity.Property(e => e.Mixpacket)
                    .HasMaxLength(10)
                    .HasColumnName("mixpacket");
            });

            modelBuilder.Entity<MifShippingd1>(entity =>
            {
                entity.HasKey(e => new { e.Zplann, e.Ctnseq, e.Vbeln, e.Posnr, e.Zvers })
                    .HasName("mif_shippingd1_pk_1");

                entity.ToTable("mif_shippingd1", "ap_mif");

                entity.Property(e => e.Zplann)
                    .HasMaxLength(15)
                    .HasColumnName("zplann")
                    .HasComment("包裝計畫單號");

                entity.Property(e => e.Ctnseq)
                    .HasMaxLength(25)
                    .HasColumnName("ctnseq")
                    .HasComment("內部箱號");

                entity.Property(e => e.Vbeln)
                    .HasMaxLength(10)
                    .HasColumnName("vbeln")
                    .HasComment("訂單號碼");

                entity.Property(e => e.Posnr)
                    .HasMaxLength(6)
                    .HasColumnName("posnr")
                    .HasComment("訂單項次");

                entity.Property(e => e.Zvers)
                    .HasMaxLength(14)
                    .HasColumnName("zvers")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Article)
                    .HasMaxLength(40)
                    .HasColumnName("article")
                    .HasComment("型體名稱(sd自行維護)");

                entity.Property(e => e.Atcolr)
                    .HasMaxLength(300)
                    .HasColumnName("atcolr")
                    .HasComment("顏色代號英文說明");

                entity.Property(e => e.BarcodeI)
                    .HasMaxLength(18)
                    .HasColumnName("barcode_i")
                    .HasComment("內盒條碼");

                entity.Property(e => e.BstkdE)
                    .HasMaxLength(35)
                    .HasColumnName("bstkd_e")
                    .HasComment("po no.");

                entity.Property(e => e.Category)
                    .HasMaxLength(40)
                    .HasColumnName("category")
                    .HasComment("category");

                entity.Property(e => e.Colorcode)
                    .HasMaxLength(40)
                    .HasColumnName("colorcode")
                    .HasComment("顏色代號");

                entity.Property(e => e.Content)
                    .HasMaxLength(20)
                    .HasColumnName("content")
                    .HasComment("產品類別英文名稱");

                entity.Property(e => e.CustboxI)
                    .HasMaxLength(40)
                    .HasColumnName("custbox_i")
                    .HasComment("客戶內盒代號");

                entity.Property(e => e.Custpo)
                    .HasMaxLength(35)
                    .HasColumnName("custpo")
                    .HasComment("customer po");

                entity.Property(e => e.DeliveryCode)
                    .HasMaxLength(24)
                    .HasColumnName("delivery_code")
                    .HasComment("出貨地址代碼");

                entity.Property(e => e.DevCode)
                    .HasMaxLength(40)
                    .HasColumnName("dev_code")
                    .HasComment("開發代碼");

                entity.Property(e => e.FileName)
                    .HasMaxLength(50)
                    .HasColumnName("file_name")
                    .HasComment("檔案名");

                entity.Property(e => e.Gendr)
                    .HasMaxLength(20)
                    .HasColumnName("gendr")
                    .HasComment("性別代號");

                entity.Property(e => e.Ketdat)
                    .HasMaxLength(8)
                    .HasColumnName("ketdat")
                    .HasComment("訂單交期");

                entity.Property(e => e.Matnr)
                    .HasMaxLength(18)
                    .HasColumnName("matnr")
                    .HasComment("料號");

                entity.Property(e => e.MatnroI)
                    .HasMaxLength(18)
                    .HasColumnName("matnro_i")
                    .HasComment("內盒料號");

                entity.Property(e => e.MatnrospI)
                    .HasMaxLength(120)
                    .HasColumnName("matnrosp_i")
                    .HasComment("內盒規格說明");

                entity.Property(e => e.Mdmark)
                    .HasMaxLength(40)
                    .HasColumnName("mdmark")
                    .HasComment("配色說明");

                entity.Property(e => e.ModelName)
                    .HasMaxLength(120)
                    .HasColumnName("model_name")
                    .HasComment("型體名稱");

                entity.Property(e => e.Pkk)
                    .HasMaxLength(100)
                    .HasColumnName("pkk")
                    .HasComment("pkk/lot table");

                entity.Property(e => e.Poart)
                    .HasMaxLength(18)
                    .HasColumnName("poart")
                    .HasComment("artic_no");

                entity.Property(e => e.Ponum)
                    .HasMaxLength(35)
                    .HasColumnName("ponum")
                    .HasComment("客人訂單號");

                entity.Property(e => e.Qty)
                    .HasMaxLength(50)
                    .HasColumnName("qty")
                    .HasComment("數量");

                entity.Property(e => e.RecMk)
                    .HasMaxLength(1)
                    .HasColumnName("rec_mk")
                    .HasComment("接收註記(n.mes未接收 y.mes己接收)");

                entity.Property(e => e.SalesUnit)
                    .HasMaxLength(3)
                    .HasColumnName("sales_unit")
                    .HasComment("銷售單位");

                entity.Property(e => e.Serialno)
                    .HasMaxLength(50)
                    .HasColumnName("serialno")
                    .HasComment("serial from serial to");

                entity.Property(e => e.ServIdno)
                    .HasMaxLength(25)
                    .HasColumnName("serv_idno")
                    .HasComment("service identifier");

                entity.Property(e => e.SgtRcat)
                    .HasMaxLength(16)
                    .HasColumnName("sgt_rcat")
                    .HasComment("segmentation");

                entity.Property(e => e.ShipType)
                    .HasMaxLength(23)
                    .HasColumnName("ship_type")
                    .HasComment("ship type");

                entity.Property(e => e.Shoew)
                    .HasMaxLength(30)
                    .HasColumnName("shoew")
                    .HasComment("shoe width");

                entity.Property(e => e.Size4)
                    .HasMaxLength(200)
                    .HasColumnName("size4")
                    .HasComment("size (四國尺碼)");

                entity.Property(e => e.SizeArg)
                    .HasMaxLength(12)
                    .HasColumnName("size_arg")
                    .HasComment("阿根廷尺碼");

                entity.Property(e => e.SizeBr)
                    .HasMaxLength(12)
                    .HasColumnName("size_br")
                    .HasComment("巴西尺碼");

                entity.Property(e => e.SizeFr)
                    .HasMaxLength(12)
                    .HasColumnName("size_fr")
                    .HasComment("法國尺碼");

                entity.Property(e => e.SizeJp)
                    .HasMaxLength(12)
                    .HasColumnName("size_jp")
                    .HasComment("日本尺碼");

                entity.Property(e => e.SizeKr)
                    .HasMaxLength(12)
                    .HasColumnName("size_kr")
                    .HasComment("kr尺碼");

                entity.Property(e => e.SizeMx)
                    .HasMaxLength(12)
                    .HasColumnName("size_mx")
                    .HasComment("墨西哥尺碼");

                entity.Property(e => e.Sizeukus)
                    .HasMaxLength(100)
                    .HasColumnName("sizeukus")
                    .HasComment("美英尺碼");

                entity.Property(e => e.SoSize)
                    .HasMaxLength(100)
                    .HasColumnName("so_size")
                    .HasComment("接單size");

                entity.Property(e => e.SpecialNote)
                    .HasMaxLength(40)
                    .HasColumnName("special_note")
                    .HasComment("特殊註記");

                entity.Property(e => e.Stylecode)
                    .HasMaxLength(40)
                    .HasColumnName("stylecode")
                    .HasComment("型體代號");

                entity.Property(e => e.SubsalesPo)
                    .HasMaxLength(35)
                    .HasColumnName("subsales_po")
                    .HasComment("subsales po");

                entity.Property(e => e.Width)
                    .HasMaxLength(40)
                    .HasColumnName("width")
                    .HasComment("肥度 (楦寬)");
            });

            modelBuilder.Entity<MifShippingd12>(entity =>
            {
                entity.HasKey(e => new { e.Zplann, e.Ctnseq, e.Vbeln, e.Posnr, e.Zvers })
                    .HasName("mif_shippingd1_pk");

                entity.ToTable("mif_shippingd12", "ap_mif");

                entity.Property(e => e.Zplann)
                    .HasMaxLength(15)
                    .HasColumnName("zplann")
                    .HasComment("包裝計畫單號");

                entity.Property(e => e.Ctnseq)
                    .HasMaxLength(25)
                    .HasColumnName("ctnseq")
                    .HasComment("內部箱號");

                entity.Property(e => e.Vbeln)
                    .HasMaxLength(10)
                    .HasColumnName("vbeln")
                    .HasComment("訂單號碼");

                entity.Property(e => e.Posnr)
                    .HasMaxLength(6)
                    .HasColumnName("posnr")
                    .HasComment("訂單項次");

                entity.Property(e => e.Zvers)
                    .HasMaxLength(14)
                    .HasColumnName("zvers")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Article)
                    .HasMaxLength(40)
                    .HasColumnName("article")
                    .HasComment("型體名稱(sd自行維護)");

                entity.Property(e => e.Atcolr)
                    .HasMaxLength(300)
                    .HasColumnName("atcolr")
                    .HasComment("顏色代號英文說明");

                entity.Property(e => e.BarcodeI)
                    .HasMaxLength(18)
                    .HasColumnName("barcode_i")
                    .HasComment("內盒條碼");

                entity.Property(e => e.BstkdE)
                    .HasMaxLength(35)
                    .HasColumnName("bstkd_e")
                    .HasComment("po no.");

                entity.Property(e => e.Category)
                    .HasMaxLength(40)
                    .HasColumnName("category")
                    .HasComment("category");

                entity.Property(e => e.Colorcode)
                    .HasMaxLength(40)
                    .HasColumnName("colorcode")
                    .HasComment("顏色代號");

                entity.Property(e => e.Content)
                    .HasMaxLength(20)
                    .HasColumnName("content")
                    .HasComment("產品類別英文名稱");

                entity.Property(e => e.CustboxI)
                    .HasMaxLength(40)
                    .HasColumnName("custbox_i")
                    .HasComment("客戶內盒代號");

                entity.Property(e => e.Custpo)
                    .HasMaxLength(35)
                    .HasColumnName("custpo")
                    .HasComment("customer po");

                entity.Property(e => e.DeliveryCode)
                    .HasMaxLength(24)
                    .HasColumnName("delivery_code")
                    .HasComment("出貨地址代碼");

                entity.Property(e => e.DevCode)
                    .HasMaxLength(40)
                    .HasColumnName("dev_code")
                    .HasComment("開發代碼");

                entity.Property(e => e.FileName)
                    .HasMaxLength(50)
                    .HasColumnName("file_name")
                    .HasComment("檔案名");

                entity.Property(e => e.Gendr)
                    .HasMaxLength(20)
                    .HasColumnName("gendr")
                    .HasComment("性別代號");

                entity.Property(e => e.Ketdat)
                    .HasMaxLength(8)
                    .HasColumnName("ketdat")
                    .HasComment("訂單交期");

                entity.Property(e => e.Matnr)
                    .HasMaxLength(18)
                    .HasColumnName("matnr")
                    .HasComment("料號");

                entity.Property(e => e.MatnroI)
                    .HasMaxLength(18)
                    .HasColumnName("matnro_i")
                    .HasComment("內盒料號");

                entity.Property(e => e.MatnrospI)
                    .HasMaxLength(120)
                    .HasColumnName("matnrosp_i")
                    .HasComment("內盒規格說明");

                entity.Property(e => e.Mdmark)
                    .HasMaxLength(40)
                    .HasColumnName("mdmark")
                    .HasComment("配色說明");

                entity.Property(e => e.ModelName)
                    .HasMaxLength(120)
                    .HasColumnName("model_name")
                    .HasComment("型體名稱");

                entity.Property(e => e.Pkk)
                    .HasMaxLength(100)
                    .HasColumnName("pkk")
                    .HasComment("pkk/lot table");

                entity.Property(e => e.Poart)
                    .HasMaxLength(18)
                    .HasColumnName("poart")
                    .HasComment("artic_no");

                entity.Property(e => e.Ponum)
                    .HasMaxLength(35)
                    .HasColumnName("ponum")
                    .HasComment("客人訂單號");

                entity.Property(e => e.Qty)
                    .HasMaxLength(50)
                    .HasColumnName("qty")
                    .HasComment("數量");

                entity.Property(e => e.RecMk)
                    .HasMaxLength(1)
                    .HasColumnName("rec_mk")
                    .HasComment("接收註記(n.mes未接收 y.mes己接收)");

                entity.Property(e => e.SalesUnit)
                    .HasMaxLength(3)
                    .HasColumnName("sales_unit")
                    .HasComment("銷售單位");

                entity.Property(e => e.Serialno)
                    .HasMaxLength(50)
                    .HasColumnName("serialno")
                    .HasComment("serial from serial to");

                entity.Property(e => e.ServIdno)
                    .HasMaxLength(25)
                    .HasColumnName("serv_idno")
                    .HasComment("service identifier");

                entity.Property(e => e.SgtRcat)
                    .HasMaxLength(16)
                    .HasColumnName("sgt_rcat")
                    .HasComment("segmentation");

                entity.Property(e => e.ShipType)
                    .HasMaxLength(23)
                    .HasColumnName("ship_type")
                    .HasComment("ship type");

                entity.Property(e => e.Shoew)
                    .HasMaxLength(30)
                    .HasColumnName("shoew")
                    .HasComment("shoe width");

                entity.Property(e => e.Size4)
                    .HasMaxLength(200)
                    .HasColumnName("size4")
                    .HasComment("size (四國尺碼)");

                entity.Property(e => e.SizeArg)
                    .HasMaxLength(12)
                    .HasColumnName("size_arg")
                    .HasComment("阿根廷尺碼");

                entity.Property(e => e.SizeBr)
                    .HasMaxLength(12)
                    .HasColumnName("size_br")
                    .HasComment("巴西尺碼");

                entity.Property(e => e.SizeFr)
                    .HasMaxLength(12)
                    .HasColumnName("size_fr")
                    .HasComment("法國尺碼");

                entity.Property(e => e.SizeJp)
                    .HasMaxLength(12)
                    .HasColumnName("size_jp")
                    .HasComment("日本尺碼");

                entity.Property(e => e.SizeKr)
                    .HasMaxLength(12)
                    .HasColumnName("size_kr")
                    .HasComment("kr尺碼");

                entity.Property(e => e.SizeMx)
                    .HasMaxLength(12)
                    .HasColumnName("size_mx")
                    .HasComment("墨西哥尺碼");

                entity.Property(e => e.Sizeukus)
                    .HasMaxLength(100)
                    .HasColumnName("sizeukus")
                    .HasComment("美英尺碼");

                entity.Property(e => e.SoSize)
                    .HasMaxLength(100)
                    .HasColumnName("so_size")
                    .HasComment("接單size");

                entity.Property(e => e.SpecialNote)
                    .HasMaxLength(40)
                    .HasColumnName("special_note")
                    .HasComment("特殊註記");

                entity.Property(e => e.Stylecode)
                    .HasMaxLength(40)
                    .HasColumnName("stylecode")
                    .HasComment("型體代號");

                entity.Property(e => e.SubsalesPo)
                    .HasMaxLength(35)
                    .HasColumnName("subsales_po")
                    .HasComment("subsales po");

                entity.Property(e => e.Width)
                    .HasMaxLength(40)
                    .HasColumnName("width")
                    .HasComment("肥度 (楦寬)");
            });

            modelBuilder.Entity<MifShippingm1>(entity =>
            {
                entity.HasKey(e => new { e.Zplann, e.Ctnseq, e.PrdSite, e.Zvers, e.FileName })
                    .HasName("mif_shippingm1_pk_1");

                entity.ToTable("mif_shippingm1", "ap_mif");

                entity.Property(e => e.Zplann)
                    .HasMaxLength(15)
                    .HasColumnName("zplann")
                    .HasComment("包裝計劃單號");

                entity.Property(e => e.Ctnseq)
                    .HasMaxLength(25)
                    .HasColumnName("ctnseq")
                    .HasComment("內部箱號");

                entity.Property(e => e.PrdSite)
                    .HasMaxLength(4)
                    .HasColumnName("prd_site")
                    .HasComment("生產工廠代號");

                entity.Property(e => e.Zvers)
                    .HasMaxLength(14)
                    .HasColumnName("zvers")
                    .HasComment("版次");

                entity.Property(e => e.FileName)
                    .HasMaxLength(50)
                    .HasColumnName("file_name")
                    .HasComment("檔案名");

                entity.Property(e => e.Address)
                    .HasMaxLength(660)
                    .HasColumnName("address")
                    .HasComment("ship-to客戶地址");

                entity.Property(e => e.Artplan)
                    .HasMaxLength(6)
                    .HasColumnName("artplan")
                    .HasComment("品牌工廠編碼");

                entity.Property(e => e.Artplna)
                    .HasMaxLength(6)
                    .HasColumnName("artplna")
                    .HasComment("品牌工廠代號");

                entity.Property(e => e.Barcode3)
                    .HasMaxLength(25)
                    .HasColumnName("barcode_3")
                    .HasComment("條碼");

                entity.Property(e => e.BarcodeO)
                    .HasMaxLength(25)
                    .HasColumnName("barcode_o")
                    .HasComment("外箱條碼");

                entity.Property(e => e.Boxkun)
                    .HasMaxLength(20)
                    .HasColumnName("boxkun");

                entity.Property(e => e.Boxnum)
                    .HasMaxLength(25)
                    .HasColumnName("boxnum")
                    .HasComment("外箱序號");

                entity.Property(e => e.Breit)
                    .HasMaxLength(13)
                    .HasColumnName("breit")
                    .HasComment("外箱規格-寬");

                entity.Property(e => e.Commodtyp)
                    .HasMaxLength(30)
                    .HasColumnName("commodtyp")
                    .HasComment("commodities type");

                entity.Property(e => e.Consignee)
                    .HasMaxLength(120)
                    .HasColumnName("consignee")
                    .HasComment("收件公司");

                entity.Property(e => e.Contw)
                    .HasMaxLength(30)
                    .HasColumnName("contw")
                    .HasComment("小包重量/外箱重量");

                entity.Property(e => e.CtnNtgew)
                    .HasMaxLength(13)
                    .HasColumnName("ctn_ntgew")
                    .HasComment("外箱重量(克)");

                entity.Property(e => e.Ctnno)
                    .HasMaxLength(12)
                    .HasColumnName("ctnno")
                    .HasComment("箱序/總箱數");

                entity.Property(e => e.Cuport)
                    .HasMaxLength(90)
                    .HasColumnName("cuport")
                    .HasComment("客戶港口名稱");

                entity.Property(e => e.Custbox)
                    .HasMaxLength(40)
                    .HasColumnName("custbox")
                    .HasComment("客戶外箱代號");

                entity.Property(e => e.Custsku)
                    .HasMaxLength(40)
                    .HasColumnName("custsku")
                    .HasComment("customer_sku");

                entity.Property(e => e.Destnt)
                    .HasMaxLength(50)
                    .HasColumnName("destnt")
                    .HasComment("國家代碼");

                entity.Property(e => e.Double)
                    .HasMaxLength(6)
                    .HasColumnName("double")
                    .HasComment("每箱雙數");

                entity.Property(e => e.Eeantp)
                    .HasMaxLength(5)
                    .HasColumnName("eeantp")
                    .HasComment("條碼類型");

                entity.Property(e => e.GpsCuna)
                    .HasMaxLength(240)
                    .HasColumnName("gps_cuna")
                    .HasComment("gps_customer_name");

                entity.Property(e => e.GpsCuno)
                    .HasMaxLength(10)
                    .HasColumnName("gps_cuno")
                    .HasComment("gps_customer_no");

                entity.Property(e => e.Grosswe)
                    .HasMaxLength(17)
                    .HasColumnName("grosswe")
                    .HasComment("毛重");

                entity.Property(e => e.Grosswet)
                    .HasMaxLength(14)
                    .HasColumnName("grosswet")
                    .HasComment("毛重(kg)下限");

                entity.Property(e => e.GrosswetT)
                    .HasMaxLength(14)
                    .HasColumnName("grosswet_t")
                    .HasComment("毛重(kg)上限");

                entity.Property(e => e.Hoehe)
                    .HasMaxLength(13)
                    .HasColumnName("hoehe")
                    .HasComment("外箱規格-高");

                entity.Property(e => e.Kunnr)
                    .HasMaxLength(10)
                    .HasColumnName("kunnr")
                    .HasComment("sold-to客戶代號");

                entity.Property(e => e.Laeng)
                    .HasMaxLength(13)
                    .HasColumnName("laeng")
                    .HasComment("外箱規格-長");

                entity.Property(e => e.Land1)
                    .HasMaxLength(150)
                    .HasColumnName("land1")
                    .HasComment("生產國家");

                entity.Property(e => e.Matnro)
                    .HasMaxLength(18)
                    .HasColumnName("matnro")
                    .HasComment("外箱料號");

                entity.Property(e => e.Matnrocbm)
                    .HasMaxLength(50)
                    .HasColumnName("matnrocbm")
                    .HasComment("外箱cbm");

                entity.Property(e => e.Matnrolwh)
                    .HasMaxLength(30)
                    .HasColumnName("matnrolwh")
                    .HasComment("外箱尺寸");

                entity.Property(e => e.Matnrosp)
                    .HasMaxLength(120)
                    .HasColumnName("matnrosp")
                    .HasComment("外箱規格說明");

                entity.Property(e => e.Meabm)
                    .HasMaxLength(3)
                    .HasColumnName("meabm")
                    .HasComment("外箱規格-單位");

                entity.Property(e => e.Mixcode)
                    .HasMaxLength(12)
                    .HasColumnName("mixcode")
                    .HasComment("混裝代碼");

                entity.Property(e => e.Netwe)
                    .HasMaxLength(17)
                    .HasColumnName("netwe")
                    .HasComment("淨重");

                entity.Property(e => e.Netwet)
                    .HasMaxLength(14)
                    .HasColumnName("netwet")
                    .HasComment("淨重(kg)下限");

                entity.Property(e => e.NetwetT)
                    .HasMaxLength(14)
                    .HasColumnName("netwet_t")
                    .HasComment("淨重(kg)上限");

                entity.Property(e => e.PayerCode)
                    .HasMaxLength(10)
                    .HasColumnName("payer_code")
                    .HasComment("付款方代碼");

                entity.Property(e => e.PayerName)
                    .HasMaxLength(80)
                    .HasColumnName("payer_name")
                    .HasComment("付款方名稱");

                entity.Property(e => e.Product)
                    .HasMaxLength(40)
                    .HasColumnName("product")
                    .HasComment("product");

                entity.Property(e => e.Qrcode)
                    .HasMaxLength(25)
                    .HasColumnName("qrcode")
                    .HasComment("fty _qrcode");

                entity.Property(e => e.RecMk)
                    .HasMaxLength(1)
                    .HasColumnName("rec_mk")
                    .HasDefaultValueSql("'n'::character varying")
                    .HasComment("接收註記(n.mes未接收 y.mes己接收)");

                entity.Property(e => e.Recip)
                    .HasMaxLength(210)
                    .HasColumnName("recip")
                    .HasComment("收件者");

                entity.Property(e => e.Remark)
                    .HasMaxLength(300)
                    .HasColumnName("remark")
                    .HasComment("備註");

                entity.Property(e => e.Salemark)
                    .HasMaxLength(25)
                    .HasColumnName("salemark")
                    .HasComment("salesman_sample_to");

                entity.Property(e => e.Salepkmk)
                    .HasMaxLength(75)
                    .HasColumnName("salepkmk")
                    .HasComment("銷樣訂單側嘜呈現字樣");

                entity.Property(e => e.Season)
                    .HasMaxLength(20)
                    .HasColumnName("season")
                    .HasComment("season");

                entity.Property(e => e.ShipSortl2)
                    .HasMaxLength(60)
                    .HasColumnName("ship_sortl2")
                    .HasComment("ship-to search term2");

                entity.Property(e => e.Soldtol)
                    .HasMaxLength(60)
                    .HasColumnName("soldtol")
                    .HasComment("sold-to向線");

                entity.Property(e => e.Sortl)
                    .HasMaxLength(20)
                    .HasColumnName("sortl")
                    .HasComment("ship to search term1");

                entity.Property(e => e.Trackcm)
                    .HasMaxLength(40)
                    .HasColumnName("trackcm")
                    .HasComment("快遞公司");

                entity.Property(e => e.Trackno)
                    .HasMaxLength(20)
                    .HasColumnName("trackno")
                    .HasComment("快遞單號");

                entity.Property(e => e.Tradmk)
                    .HasMaxLength(40)
                    .HasColumnName("tradmk")
                    .HasComment("trademark");

                entity.Property(e => e.TrfMark)
                    .HasMaxLength(1)
                    .HasColumnName("trf_mark");

                entity.Property(e => e.Vtxtk)
                    .HasMaxLength(20)
                    .HasColumnName("vtxtk")
                    .HasComment("品牌名稱");

                entity.Property(e => e.Zcntnoa)
                    .HasMaxLength(15)
                    .HasColumnName("zcntnoa")
                    .HasComment("實際櫃號");

                entity.Property(e => e.Zcntnoi)
                    .HasMaxLength(25)
                    .HasColumnName("zcntnoi")
                    .HasComment("系統櫃號");

                entity.Property(e => e.Zzsubcon)
                    .HasMaxLength(4)
                    .HasColumnName("zzsubcon")
                    .HasComment("代工工廠");
            });

            modelBuilder.Entity<MifShippingm12>(entity =>
            {
                entity.HasKey(e => new { e.Zplann, e.Ctnseq, e.PrdSite, e.Zvers, e.FileName })
                    .HasName("mif_shippingm1_pk");

                entity.ToTable("mif_shippingm12", "ap_mif");

                entity.Property(e => e.Zplann)
                    .HasMaxLength(15)
                    .HasColumnName("zplann")
                    .HasComment("包裝計劃單號");

                entity.Property(e => e.Ctnseq)
                    .HasMaxLength(25)
                    .HasColumnName("ctnseq")
                    .HasComment("內部箱號");

                entity.Property(e => e.PrdSite)
                    .HasMaxLength(4)
                    .HasColumnName("prd_site")
                    .HasComment("生產工廠代號");

                entity.Property(e => e.Zvers)
                    .HasMaxLength(14)
                    .HasColumnName("zvers")
                    .HasComment("版次");

                entity.Property(e => e.FileName)
                    .HasMaxLength(50)
                    .HasColumnName("file_name")
                    .HasComment("檔案名");

                entity.Property(e => e.Address)
                    .HasMaxLength(660)
                    .HasColumnName("address")
                    .HasComment("ship-to客戶地址");

                entity.Property(e => e.Artplan)
                    .HasMaxLength(6)
                    .HasColumnName("artplan")
                    .HasComment("品牌工廠編碼");

                entity.Property(e => e.Artplna)
                    .HasMaxLength(6)
                    .HasColumnName("artplna")
                    .HasComment("品牌工廠代號");

                entity.Property(e => e.Barcode3)
                    .HasMaxLength(25)
                    .HasColumnName("barcode_3")
                    .HasComment("條碼");

                entity.Property(e => e.BarcodeO)
                    .HasMaxLength(25)
                    .HasColumnName("barcode_o")
                    .HasComment("外箱條碼");

                entity.Property(e => e.Boxkun)
                    .HasMaxLength(20)
                    .HasColumnName("boxkun");

                entity.Property(e => e.Boxnum)
                    .HasMaxLength(25)
                    .HasColumnName("boxnum")
                    .HasComment("外箱序號");

                entity.Property(e => e.Breit)
                    .HasMaxLength(13)
                    .HasColumnName("breit")
                    .HasComment("外箱規格-寬");

                entity.Property(e => e.Commodtyp)
                    .HasMaxLength(30)
                    .HasColumnName("commodtyp")
                    .HasComment("commodities type");

                entity.Property(e => e.Consignee)
                    .HasMaxLength(120)
                    .HasColumnName("consignee")
                    .HasComment("收件公司");

                entity.Property(e => e.Contw)
                    .HasMaxLength(30)
                    .HasColumnName("contw")
                    .HasComment("小包重量/外箱重量");

                entity.Property(e => e.CtnNtgew)
                    .HasMaxLength(13)
                    .HasColumnName("ctn_ntgew")
                    .HasComment("外箱重量(克)");

                entity.Property(e => e.Ctnno)
                    .HasMaxLength(12)
                    .HasColumnName("ctnno")
                    .HasComment("箱序/總箱數");

                entity.Property(e => e.Cuport)
                    .HasMaxLength(90)
                    .HasColumnName("cuport")
                    .HasComment("客戶港口名稱");

                entity.Property(e => e.Custbox)
                    .HasMaxLength(40)
                    .HasColumnName("custbox")
                    .HasComment("客戶外箱代號");

                entity.Property(e => e.Custsku)
                    .HasMaxLength(40)
                    .HasColumnName("custsku")
                    .HasComment("customer_sku");

                entity.Property(e => e.Destnt)
                    .HasMaxLength(50)
                    .HasColumnName("destnt")
                    .HasComment("國家代碼");

                entity.Property(e => e.Double)
                    .HasMaxLength(6)
                    .HasColumnName("double")
                    .HasComment("每箱雙數");

                entity.Property(e => e.Eeantp)
                    .HasMaxLength(5)
                    .HasColumnName("eeantp")
                    .HasComment("條碼類型");

                entity.Property(e => e.GpsCuna)
                    .HasMaxLength(240)
                    .HasColumnName("gps_cuna")
                    .HasComment("gps_customer_name");

                entity.Property(e => e.GpsCuno)
                    .HasMaxLength(10)
                    .HasColumnName("gps_cuno")
                    .HasComment("gps_customer_no");

                entity.Property(e => e.Grosswe)
                    .HasMaxLength(17)
                    .HasColumnName("grosswe")
                    .HasComment("毛重");

                entity.Property(e => e.Grosswet)
                    .HasMaxLength(14)
                    .HasColumnName("grosswet")
                    .HasComment("毛重(kg)下限");

                entity.Property(e => e.GrosswetT)
                    .HasMaxLength(14)
                    .HasColumnName("grosswet_t")
                    .HasComment("毛重(kg)上限");

                entity.Property(e => e.Hoehe)
                    .HasMaxLength(13)
                    .HasColumnName("hoehe")
                    .HasComment("外箱規格-高");

                entity.Property(e => e.Kunnr)
                    .HasMaxLength(10)
                    .HasColumnName("kunnr")
                    .HasComment("sold-to客戶代號");

                entity.Property(e => e.Laeng)
                    .HasMaxLength(13)
                    .HasColumnName("laeng")
                    .HasComment("外箱規格-長");

                entity.Property(e => e.Land1)
                    .HasMaxLength(150)
                    .HasColumnName("land1")
                    .HasComment("生產國家");

                entity.Property(e => e.Matnro)
                    .HasMaxLength(18)
                    .HasColumnName("matnro")
                    .HasComment("外箱料號");

                entity.Property(e => e.Matnrocbm)
                    .HasMaxLength(50)
                    .HasColumnName("matnrocbm")
                    .HasComment("外箱cbm");

                entity.Property(e => e.Matnrolwh)
                    .HasMaxLength(30)
                    .HasColumnName("matnrolwh")
                    .HasComment("外箱尺寸");

                entity.Property(e => e.Matnrosp)
                    .HasMaxLength(120)
                    .HasColumnName("matnrosp")
                    .HasComment("外箱規格說明");

                entity.Property(e => e.Meabm)
                    .HasMaxLength(3)
                    .HasColumnName("meabm")
                    .HasComment("外箱規格-單位");

                entity.Property(e => e.Mixcode)
                    .HasMaxLength(12)
                    .HasColumnName("mixcode")
                    .HasComment("混裝代碼");

                entity.Property(e => e.Netwe)
                    .HasMaxLength(17)
                    .HasColumnName("netwe")
                    .HasComment("淨重");

                entity.Property(e => e.Netwet)
                    .HasMaxLength(14)
                    .HasColumnName("netwet")
                    .HasComment("淨重(kg)下限");

                entity.Property(e => e.NetwetT)
                    .HasMaxLength(14)
                    .HasColumnName("netwet_t")
                    .HasComment("淨重(kg)上限");

                entity.Property(e => e.PayerCode)
                    .HasMaxLength(10)
                    .HasColumnName("payer_code")
                    .HasComment("付款方代碼");

                entity.Property(e => e.PayerName)
                    .HasMaxLength(80)
                    .HasColumnName("payer_name")
                    .HasComment("付款方名稱");

                entity.Property(e => e.Product)
                    .HasMaxLength(40)
                    .HasColumnName("product")
                    .HasComment("product");

                entity.Property(e => e.Qrcode)
                    .HasMaxLength(25)
                    .HasColumnName("qrcode")
                    .HasComment("fty _qrcode");

                entity.Property(e => e.RecMk)
                    .HasMaxLength(1)
                    .HasColumnName("rec_mk")
                    .HasDefaultValueSql("'n'::character varying")
                    .HasComment("接收註記(n.mes未接收 y.mes己接收)");

                entity.Property(e => e.Recip)
                    .HasMaxLength(210)
                    .HasColumnName("recip")
                    .HasComment("收件者");

                entity.Property(e => e.Remark)
                    .HasMaxLength(300)
                    .HasColumnName("remark")
                    .HasComment("備註");

                entity.Property(e => e.Salemark)
                    .HasMaxLength(25)
                    .HasColumnName("salemark")
                    .HasComment("salesman_sample_to");

                entity.Property(e => e.Salepkmk)
                    .HasMaxLength(75)
                    .HasColumnName("salepkmk")
                    .HasComment("銷樣訂單側嘜呈現字樣");

                entity.Property(e => e.Season)
                    .HasMaxLength(20)
                    .HasColumnName("season")
                    .HasComment("season");

                entity.Property(e => e.ShipSortl2)
                    .HasMaxLength(60)
                    .HasColumnName("ship_sortl2")
                    .HasComment("ship-to search term2");

                entity.Property(e => e.Soldtol)
                    .HasMaxLength(60)
                    .HasColumnName("soldtol")
                    .HasComment("sold-to向線");

                entity.Property(e => e.Sortl)
                    .HasMaxLength(20)
                    .HasColumnName("sortl")
                    .HasComment("ship to search term1");

                entity.Property(e => e.Trackcm)
                    .HasMaxLength(40)
                    .HasColumnName("trackcm")
                    .HasComment("快遞公司");

                entity.Property(e => e.Trackno)
                    .HasMaxLength(20)
                    .HasColumnName("trackno")
                    .HasComment("快遞單號");

                entity.Property(e => e.Tradmk)
                    .HasMaxLength(40)
                    .HasColumnName("tradmk")
                    .HasComment("trademark");

                entity.Property(e => e.TrfMark)
                    .HasMaxLength(1)
                    .HasColumnName("trf_mark");

                entity.Property(e => e.Vtxtk)
                    .HasMaxLength(20)
                    .HasColumnName("vtxtk")
                    .HasComment("品牌名稱");

                entity.Property(e => e.Zcntnoa)
                    .HasMaxLength(15)
                    .HasColumnName("zcntnoa")
                    .HasComment("實際櫃號");

                entity.Property(e => e.Zcntnoi)
                    .HasMaxLength(25)
                    .HasColumnName("zcntnoi")
                    .HasComment("系統櫃號");

                entity.Property(e => e.Zzsubcon)
                    .HasMaxLength(4)
                    .HasColumnName("zzsubcon")
                    .HasComment("代工工廠");
            });

            modelBuilder.Entity<MifShippingslr>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mif_shippingslr", "ap_mif");

                entity.Property(e => e.ArrivalPort)
                    .HasMaxLength(50)
                    .HasColumnName("arrival_port");

                entity.Property(e => e.Attn)
                    .HasMaxLength(50)
                    .HasColumnName("attn");

                entity.Property(e => e.CartonNoTotal)
                    .HasMaxLength(50)
                    .HasColumnName("carton_no_total");

                entity.Property(e => e.ColorName)
                    .HasMaxLength(50)
                    .HasColumnName("color_name");

                entity.Property(e => e.ColorNo)
                    .HasMaxLength(50)
                    .HasColumnName("color_no");

                entity.Property(e => e.Content)
                    .HasMaxLength(1000)
                    .HasColumnName("content")
                    .HasComment("內容");

                entity.Property(e => e.Contents)
                    .HasMaxLength(50)
                    .HasColumnName("contents");

                entity.Property(e => e.CountryOfOrign)
                    .HasMaxLength(50)
                    .HasColumnName("country_of_orign");

                entity.Property(e => e.Customer)
                    .HasMaxLength(50)
                    .HasColumnName("customer");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(50)
                    .HasColumnName("customer_name");

                entity.Property(e => e.Factory)
                    .HasMaxLength(50)
                    .HasColumnName("factory");

                entity.Property(e => e.FileName)
                    .HasMaxLength(50)
                    .HasColumnName("file_name")
                    .HasComment("檔案名");

                entity.Property(e => e.MarkType)
                    .HasMaxLength(2)
                    .HasColumnName("mark_type")
                    .HasComment("資訊類別");

                entity.Property(e => e.OrderNo)
                    .HasMaxLength(50)
                    .HasColumnName("order_no");

                entity.Property(e => e.PoNo)
                    .HasMaxLength(50)
                    .HasColumnName("po_no");

                entity.Property(e => e.Quantity)
                    .HasMaxLength(50)
                    .HasColumnName("quantity");

                entity.Property(e => e.Quantity1)
                    .HasMaxLength(5)
                    .HasColumnName("quantity1");

                entity.Property(e => e.Quantity2)
                    .HasMaxLength(5)
                    .HasColumnName("quantity2");

                entity.Property(e => e.Quantity3)
                    .HasMaxLength(5)
                    .HasColumnName("quantity3");

                entity.Property(e => e.Quantity4)
                    .HasMaxLength(5)
                    .HasColumnName("quantity4");

                entity.Property(e => e.Quantity5)
                    .HasMaxLength(5)
                    .HasColumnName("quantity5");

                entity.Property(e => e.ShipToAddr)
                    .HasMaxLength(150)
                    .HasColumnName("ship_to_addr");

                entity.Property(e => e.Size1)
                    .HasMaxLength(10)
                    .HasColumnName("size1");

                entity.Property(e => e.Size2)
                    .HasMaxLength(10)
                    .HasColumnName("size2");

                entity.Property(e => e.Size3)
                    .HasMaxLength(10)
                    .HasColumnName("size3");

                entity.Property(e => e.Size4)
                    .HasMaxLength(10)
                    .HasColumnName("size4");

                entity.Property(e => e.Size5)
                    .HasMaxLength(10)
                    .HasColumnName("size5");

                entity.Property(e => e.SizeUk)
                    .HasMaxLength(50)
                    .HasColumnName("size_uk");

                entity.Property(e => e.Sizes)
                    .HasMaxLength(50)
                    .HasColumnName("sizes");

                entity.Property(e => e.StyleName)
                    .HasMaxLength(50)
                    .HasColumnName("style_name");

                entity.Property(e => e.StyleNo)
                    .HasMaxLength(50)
                    .HasColumnName("style_no");

                entity.Property(e => e.Zplann)
                    .HasMaxLength(15)
                    .HasColumnName("zplann")
                    .HasComment("sap計畫單");
            });

            modelBuilder.Entity<MifShoePlanqty>(entity =>
            {
                entity.HasKey(e => new { e.FactNo, e.Yymm, e.SecNo, e.WorkDate, e.Arbpl })
                    .HasName("mif_shoe_planqty_pk");

                entity.ToTable("mif_shoe_planqty", "ap_mif");

                entity.Property(e => e.FactNo)
                    .HasMaxLength(20)
                    .HasColumnName("fact_no");

                entity.Property(e => e.Yymm)
                    .HasMaxLength(20)
                    .HasColumnName("yymm");

                entity.Property(e => e.SecNo)
                    .HasMaxLength(20)
                    .HasColumnName("sec_no");

                entity.Property(e => e.WorkDate)
                    .HasMaxLength(20)
                    .HasColumnName("work_date");

                entity.Property(e => e.Arbpl)
                    .HasMaxLength(20)
                    .HasColumnName("arbpl");

                entity.Property(e => e.ChgCode)
                    .HasMaxLength(1)
                    .HasColumnName("chg_code");

                entity.Property(e => e.CreateTime)
                    .HasMaxLength(14)
                    .HasColumnName("create_time");

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(50)
                    .HasColumnName("create_user");

                entity.Property(e => e.DataTime)
                    .HasMaxLength(20)
                    .HasColumnName("data_time");

                entity.Property(e => e.IeQty)
                    .HasPrecision(18, 8)
                    .HasColumnName("ie_qty");

                entity.Property(e => e.IndirectWorker1)
                    .HasPrecision(18, 8)
                    .HasColumnName("indirect_worker1");

                entity.Property(e => e.ModifyTime)
                    .HasMaxLength(14)
                    .HasColumnName("modify_time");

                entity.Property(e => e.ModifyUser)
                    .HasMaxLength(50)
                    .HasColumnName("modify_user");

                entity.Property(e => e.OnDutyStd)
                    .HasPrecision(3, 1)
                    .HasColumnName("on_duty_std");

                entity.Property(e => e.PlanQty)
                    .HasPrecision(18, 8)
                    .HasColumnName("plan_qty");

                entity.Property(e => e.Prodtype)
                    .HasMaxLength(10)
                    .HasColumnName("prodtype");

                entity.Property(e => e.RealQty)
                    .HasPrecision(18, 8)
                    .HasColumnName("real_qty");

                entity.Property(e => e.StdTime)
                    .HasPrecision(18, 8)
                    .HasColumnName("std_time");

                entity.Property(e => e.TargetId)
                    .HasMaxLength(50)
                    .HasColumnName("target_id");

                entity.Property(e => e.Worker)
                    .HasPrecision(18, 8)
                    .HasColumnName("worker");
            });

            modelBuilder.Entity<MifSoleQcOther>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mif_sole_qc_other", "ap_mif");

                entity.Property(e => e.CreateName)
                    .HasPrecision(20)
                    .HasColumnName("create_name");

                entity.Property(e => e.CreateTime).HasColumnName("create_time");

                entity.Property(e => e.Date)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("date");

                entity.Property(e => e.FactNo)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("fact_no");

                entity.Property(e => e.Item)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnName("item");

                entity.Property(e => e.Matnr)
                    .IsRequired()
                    .HasMaxLength(18)
                    .HasColumnName("matnr");

                entity.Property(e => e.ModifyName)
                    .HasPrecision(20)
                    .HasColumnName("modify_name");

                entity.Property(e => e.ModifyTime).HasColumnName("modify_time");

                entity.Property(e => e.QcCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("qc_code");

                entity.Property(e => e.Qty)
                    .HasPrecision(12, 3)
                    .HasColumnName("qty");

                entity.Property(e => e.Resource)
                    .HasMaxLength(20)
                    .HasColumnName("resource");

                entity.Property(e => e.Resourcegroup)
                    .HasMaxLength(20)
                    .HasColumnName("resourcegroup");

                entity.Property(e => e.Shift)
                    .HasMaxLength(20)
                    .HasColumnName("shift");
            });

            modelBuilder.Entity<MifSysAuthority>(entity =>
            {
                entity.HasKey(e => new { e.CodeNo, e.FactNo, e.UserId })
                    .HasName("pk_mif_sys_authoritys");

                entity.ToTable("mif_sys_authoritys", "ap_mif");

                entity.HasComment("系統功能權限細項管控");

                entity.Property(e => e.CodeNo)
                    .HasMaxLength(1)
                    .HasColumnName("code_no")
                    .HasComment("代號(A:鞋廠/B:化廠)");

                entity.Property(e => e.FactNo)
                    .HasMaxLength(10)
                    .HasColumnName("fact_no")
                    .HasComment("廠別代號");

                entity.Property(e => e.UserId)
                    .HasPrecision(20)
                    .HasColumnName("user_id")
                    .HasComment("使用者id");

                entity.Property(e => e.CreateName)
                    .HasPrecision(20)
                    .HasColumnName("create_name")
                    .HasComment("建立者");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("建立時間");

                entity.Property(e => e.ModifyName)
                    .HasPrecision(20)
                    .HasColumnName("modify_name")
                    .HasComment("修改者");

                entity.Property(e => e.ModifyTime)
                    .HasColumnName("modify_time")
                    .HasComment("修改時間");
            });

            modelBuilder.Entity<MifSysSlistcol>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mif_sys_slistcols", "ap_mif");

                entity.Property(e => e.ColCname)
                    .HasMaxLength(60)
                    .HasColumnName("col_cname");

                entity.Property(e => e.ColCode)
                    .HasMaxLength(15)
                    .HasColumnName("col_code");

                entity.Property(e => e.ColEname)
                    .HasMaxLength(60)
                    .HasColumnName("col_ename");

                entity.Property(e => e.ColValue)
                    .HasMaxLength(20)
                    .HasColumnName("col_value");

                entity.Property(e => e.CreateNm)
                    .HasMaxLength(10)
                    .HasColumnName("create_nm");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("date")
                    .HasColumnName("create_time")
                    .HasDefaultValueSql("('now'::text)::date");

                entity.Property(e => e.ExCol1)
                    .HasMaxLength(10)
                    .HasColumnName("ex_col1");

                entity.Property(e => e.ExCol2)
                    .HasMaxLength(10)
                    .HasColumnName("ex_col2");

                entity.Property(e => e.ExtraData)
                    .HasMaxLength(30)
                    .HasColumnName("extra_data");

                entity.Property(e => e.FlgUser)
                    .HasMaxLength(1)
                    .HasColumnName("flg_user")
                    .HasDefaultValueSql("'N'::character varying");

                entity.Property(e => e.ModifyNm)
                    .HasMaxLength(10)
                    .HasColumnName("modify_nm");

                entity.Property(e => e.ModifyTime)
                    .HasColumnType("date")
                    .HasColumnName("modify_time")
                    .HasDefaultValueSql("('now'::text)::date");

                entity.Property(e => e.Oldvalue)
                    .HasMaxLength(15)
                    .HasColumnName("oldvalue");

                entity.Property(e => e.ValueOrder)
                    .HasPrecision(6)
                    .HasColumnName("value_order");
            });

            modelBuilder.Entity<MifTimeProd>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mif_time_prod", "ap_mif");

                entity.Property(e => e.DeptTimeE)
                    .HasMaxLength(20)
                    .HasColumnName("dept_time_e");

                entity.Property(e => e.DeptTimeNo)
                    .HasMaxLength(20)
                    .HasColumnName("dept_time_no");

                entity.Property(e => e.DeptTimeS)
                    .HasMaxLength(20)
                    .HasColumnName("dept_time_s");

                entity.Property(e => e.Facility)
                    .HasMaxLength(256)
                    .HasColumnName("facility");
            });

            modelBuilder.Entity<MifToslog>(entity =>
            {
                entity.HasKey(e => e.Logid)
                    .HasName("mif_toslog_pk");

                entity.ToTable("mif_toslog", "ap_mif");

                entity.Property(e => e.Logid)
                    .HasColumnName("logid")
                    .HasDefaultValueSql("nextval('mif_toslog_logid_seq'::regclass)");

                entity.Property(e => e.Action)
                    .HasMaxLength(50)
                    .HasColumnName("action");

                entity.Property(e => e.Configcontent).HasColumnName("configcontent");

                entity.Property(e => e.Exemk)
                    .HasMaxLength(1)
                    .HasColumnName("exemk");

                entity.Property(e => e.Exemsg).HasColumnName("exemsg");

                entity.Property(e => e.Factno)
                    .HasMaxLength(10)
                    .HasColumnName("factno");

                entity.Property(e => e.Jobname)
                    .HasMaxLength(50)
                    .HasColumnName("jobname");

                entity.Property(e => e.Logtime)
                    .HasColumnName("logtime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<MifWorkSfaBom>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mif_work_sfa_bom", "ap_mif");

                entity.Property(e => e.MatnrC)
                    .HasMaxLength(18)
                    .HasColumnName("matnr_c");

                entity.Property(e => e.MatnrP)
                    .HasMaxLength(18)
                    .HasColumnName("matnr_p");

                entity.Property(e => e.UpdateTime)
                    .HasMaxLength(20)
                    .HasColumnName("update_time");
            });

            modelBuilder.Entity<Money>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("money", "ap_mif");

                entity.Property(e => e.Count1).HasColumnName("count_1");

                entity.Property(e => e.Name)
                    .HasMaxLength(512)
                    .HasColumnName("name");

                entity.Property(e => e.Othername)
                    .HasMaxLength(512)
                    .HasColumnName("othername");

                entity.Property(e => e.Type)
                    .HasMaxLength(512)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Money1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("money_1", "ap_mif");

                entity.Property(e => e.Count1).HasColumnName("count_1");

                entity.Property(e => e.Name)
                    .HasMaxLength(512)
                    .HasColumnName("name");

                entity.Property(e => e.Othername)
                    .HasMaxLength(512)
                    .HasColumnName("othername");

                entity.Property(e => e.Type)
                    .HasMaxLength(512)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Money2>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("money_2", "ap_mif");

                entity.Property(e => e.Count1).HasColumnName("count_1");

                entity.Property(e => e.Name)
                    .HasMaxLength(512)
                    .HasColumnName("name");

                entity.Property(e => e.Othername)
                    .HasMaxLength(512)
                    .HasColumnName("othername");

                entity.Property(e => e.Processmk)
                    .HasMaxLength(256)
                    .HasColumnName("processmk");

                entity.Property(e => e.Type)
                    .HasMaxLength(512)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<MsgAttachment>(entity =>
            {
                entity.ToTable("msg_attachment", "fw_mif");

                entity.HasIndex(e => e.MsgMessengerId, "ind_msg_messenger_id");

                entity.Property(e => e.MsgAttachmentId)
                    .HasMaxLength(22)
                    .HasColumnName("msg_attachment_id");

                entity.Property(e => e.AttachContent)
                    .IsRequired()
                    .HasColumnName("attach_content");

                entity.Property(e => e.AttachName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("attach_name");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.MsgMessengerId)
                    .HasMaxLength(22)
                    .HasColumnName("msg_messenger_id")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.HasOne(d => d.MsgMessenger)
                    .WithMany(p => p.MsgAttachments)
                    .HasForeignKey(d => d.MsgMessengerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("msg_attachment_fk_messenger");
            });

            modelBuilder.Entity<MsgMessenger>(entity =>
            {
                entity.ToTable("msg_messenger", "fw_mif");

                entity.HasIndex(e => e.ParentId, "ind_parent_id");

                entity.Property(e => e.MsgMessengerId)
                    .HasMaxLength(22)
                    .HasColumnName("msg_messenger_id");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name");

                entity.Property(e => e.Charset)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("charset")
                    .HasDefaultValueSql("'UTF-8'::character varying");

                entity.Property(e => e.CreateTime)
                    .HasPrecision(19)
                    .HasColumnName("create_time")
                    .HasComment("建立時間");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.Locale)
                    .HasMaxLength(5)
                    .HasColumnName("locale")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.ParentId)
                    .HasMaxLength(22)
                    .HasColumnName("parent_id")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.Priority)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("priority")
                    .HasDefaultValueSql("'NORMAL'::character varying");

                entity.Property(e => e.TemplateAliasName)
                    .HasMaxLength(100)
                    .HasColumnName("template_alias_name")
                    .HasDefaultValueSql("'NULL'::character varying");
            });

            modelBuilder.Entity<MsgRecipient>(entity =>
            {
                entity.ToTable("msg_recipient", "fw_mif");

                entity.HasIndex(e => e.MsgTargetId, "ind_msg_target_id");

                entity.Property(e => e.MsgRecipientId)
                    .HasMaxLength(22)
                    .HasColumnName("msg_recipient_id");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.MsgTargetId)
                    .HasMaxLength(22)
                    .HasColumnName("msg_target_id")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.RecipientAccount)
                    .HasMaxLength(255)
                    .HasColumnName("recipient_account")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.RecipientName)
                    .HasMaxLength(100)
                    .HasColumnName("recipient_name")
                    .HasDefaultValueSql("'NULL\n   '::character varying");

                entity.Property(e => e.RecipientType)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("recipient_type")
                    .HasDefaultValueSql("'TO'::character varying");

                entity.HasOne(d => d.MsgTarget)
                    .WithMany(p => p.MsgRecipients)
                    .HasForeignKey(d => d.MsgTargetId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("msg_recipient_fk_msg_target");
            });

            modelBuilder.Entity<MsgSent>(entity =>
            {
                entity.ToTable("msg_sent", "fw_mif");

                entity.HasIndex(e => e.MsgMessengerId, "ind_msg_sent_msg_messenger_id");

                entity.HasIndex(e => e.MsgTargetId, "ind_msg_sent_msg_target_id");

                entity.Property(e => e.MsgSentId)
                    .HasMaxLength(22)
                    .HasColumnName("msg_sent_id");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name");

                entity.Property(e => e.AppointmentTime)
                    .HasPrecision(19)
                    .HasColumnName("appointment_time");

                entity.Property(e => e.ErrorCount)
                    .HasPrecision(11)
                    .HasColumnName("error_count");

                entity.Property(e => e.ErrorReason).HasColumnName("error_reason");

                entity.Property(e => e.ExecuteTime)
                    .HasPrecision(19)
                    .HasColumnName("execute_time");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.MsgMessengerId)
                    .HasMaxLength(22)
                    .HasColumnName("msg_messenger_id")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.MsgTargetId)
                    .HasMaxLength(22)
                    .HasColumnName("msg_target_id")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.NextExecuteTime)
                    .HasPrecision(19)
                    .HasColumnName("next_execute_time");

                entity.Property(e => e.ResponseMsgId)
                    .HasMaxLength(255)
                    .HasColumnName("response_msg_id")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.SentStatus)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("sent_status");

                entity.HasOne(d => d.MsgMessenger)
                    .WithMany(p => p.MsgSents)
                    .HasForeignKey(d => d.MsgMessengerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("msg_sent_fk_msg_messenger");

                entity.HasOne(d => d.MsgTarget)
                    .WithMany(p => p.MsgSents)
                    .HasForeignKey(d => d.MsgTargetId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("msg_sent_fk_msg_target");
            });

            modelBuilder.Entity<MsgSentRecipient>(entity =>
            {
                entity.ToTable("msg_sent_recipient", "fw_mif");

                entity.HasIndex(e => e.MsgSentId, "ind_msg_sent_id");

                entity.Property(e => e.MsgSentRecipientId)
                    .HasMaxLength(22)
                    .HasColumnName("msg_sent_recipient_id");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.MsgSentId)
                    .HasMaxLength(22)
                    .HasColumnName("msg_sent_id")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.RecipientAccount)
                    .HasMaxLength(255)
                    .HasColumnName("recipient_account")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.RecipientName)
                    .HasMaxLength(100)
                    .HasColumnName("recipient_name")
                    .HasDefaultValueSql("'NULL\n   '::character varying");

                entity.Property(e => e.RecipientType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("recipient_type")
                    .HasDefaultValueSql("'TO'::character varying");

                entity.HasOne(d => d.MsgSent)
                    .WithMany(p => p.MsgSentRecipients)
                    .HasForeignKey(d => d.MsgSentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("msg_sent_recipient_fk_msg_sent");
            });

            modelBuilder.Entity<MsgSetAlias>(entity =>
            {
                entity.HasKey(e => e.MsgAliasId)
                    .HasName("msg_set_alias_pk");

                entity.ToTable("msg_set_alias", "fw_mif");

                entity.Property(e => e.MsgAliasId)
                    .HasMaxLength(22)
                    .HasColumnName("msg_alias_id")
                    .HasComment("MSG別名ID");

                entity.Property(e => e.AliasName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("alias_name")
                    .HasComment("MSG別名名稱");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasDefaultValueSql("'NULL'::character varying")
                    .HasComment("異動人ID");
            });

            modelBuilder.Entity<MsgSetAliasDetail>(entity =>
            {
                entity.HasKey(e => new { e.MsgAliasId, e.MsgServerId })
                    .HasName("msg_set_alias_detail_pk");

                entity.ToTable("msg_set_alias_detail", "fw_mif");

                entity.HasIndex(e => e.MsgServerId, "ind_msg_server_id");

                entity.Property(e => e.MsgAliasId)
                    .HasMaxLength(22)
                    .HasColumnName("msg_alias_id")
                    .HasComment("MSG別名ID");

                entity.Property(e => e.MsgServerId)
                    .HasMaxLength(22)
                    .HasColumnName("msg_server_id")
                    .HasComment("MSG主機ID");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.HasOne(d => d.MsgAlias)
                    .WithMany(p => p.MsgSetAliasDetails)
                    .HasForeignKey(d => d.MsgAliasId)
                    .HasConstraintName("msg_alias_detail_fk_msg_alias");

                entity.HasOne(d => d.MsgServer)
                    .WithMany(p => p.MsgSetAliasDetails)
                    .HasForeignKey(d => d.MsgServerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("msg_alias_detail_fk_msg_server");
            });

            modelBuilder.Entity<MsgSetServer>(entity =>
            {
                entity.HasKey(e => e.MsgServerId)
                    .HasName("msg_set_server_pk");

                entity.ToTable("msg_set_server", "fw_mif");

                entity.Property(e => e.MsgServerId)
                    .HasMaxLength(22)
                    .HasColumnName("msg_server_id");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name")
                    .HasDefaultValueSql("'_PCG'::character varying");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.MsgType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("msg_type");

                entity.Property(e => e.SenderAccount)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("sender_account");

                entity.Property(e => e.SenderName)
                    .HasMaxLength(100)
                    .HasColumnName("sender_name")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.SenderPwd)
                    .HasMaxLength(255)
                    .HasColumnName("sender_pwd")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.ServerName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("server_name");

                entity.Property(e => e.ServerParams)
                    .HasMaxLength(255)
                    .HasColumnName("server_params")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.ServerPort)
                    .HasMaxLength(5)
                    .HasColumnName("server_port")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.ServerUrl)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("server_url");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasComment("異動人ID");
            });

            modelBuilder.Entity<MsgTarget>(entity =>
            {
                entity.ToTable("msg_target", "fw_mif");

                entity.HasIndex(e => e.MsgServerId, "ind_msg_target_msg_server_id");

                entity.HasIndex(e => new { e.MsgMessengerId, e.MsgServerId }, "msg_target_uk1")
                    .IsUnique();

                entity.Property(e => e.MsgTargetId)
                    .HasMaxLength(22)
                    .HasColumnName("msg_target_id");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.ContentJson).HasColumnName("content_json");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.MsgMessengerId)
                    .HasMaxLength(22)
                    .HasColumnName("msg_messenger_id")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.MsgServerId)
                    .HasMaxLength(22)
                    .HasColumnName("msg_server_id")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.Subject)
                    .HasMaxLength(4000)
                    .HasColumnName("subject")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.HasOne(d => d.MsgMessenger)
                    .WithMany(p => p.MsgTargets)
                    .HasForeignKey(d => d.MsgMessengerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("msg_target_fk_msg_messenger");

                entity.HasOne(d => d.MsgServer)
                    .WithMany(p => p.MsgTargets)
                    .HasForeignKey(d => d.MsgServerId)
                    .HasConstraintName("msg_target_fk_msg_set_server");
            });

            modelBuilder.Entity<MultiLang>(entity =>
            {
                entity.ToTable("multi_lang", "fw_mif");

                entity.Property(e => e.MultiLangId)
                    .HasMaxLength(22)
                    .HasColumnName("multi_lang_id")
                    .HasComment("PK");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name")
                    .HasComment("APP Name");

                entity.Property(e => e.ColumnName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("column_name")
                    .HasComment("來源資料的 column name");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.LangId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("lang_id")
                    .HasComment("LANG ID");

                entity.Property(e => e.LocaleName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("locale_name")
                    .HasComment("語系編碼");

                entity.Property(e => e.LocaleValue)
                    .HasMaxLength(4000)
                    .HasColumnName("locale_value")
                    .HasComment("語系內容");

                entity.Property(e => e.NeedTrans)
                    .HasMaxLength(1)
                    .HasColumnName("need_trans")
                    .HasComment("是否需要翻譯");

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("table_name")
                    .HasComment("來源資料的 table name");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasComment("異動人ID");
            });

            modelBuilder.Entity<PageMenu>(entity =>
            {
                entity.ToTable("page_menu", "fw_mif");

                entity.HasComment("系統選單");

                entity.Property(e => e.PageMenuId)
                    .HasMaxLength(22)
                    .HasColumnName("page_menu_id")
                    .HasComment("系統選單ID");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.PageMenuArg)
                    .HasMaxLength(150)
                    .HasColumnName("page_menu_arg")
                    .HasComment("呼叫參數");

                entity.Property(e => e.PageMenuEnd)
                    .HasMaxLength(1)
                    .HasColumnName("page_menu_end")
                    .HasComment("最末級");

                entity.Property(e => e.PageMenuHp)
                    .HasMaxLength(1)
                    .HasColumnName("page_menu_hp")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("預設首頁");

                entity.Property(e => e.PageMenuIda)
                    .HasMaxLength(110)
                    .HasColumnName("page_menu_ida")
                    .HasComment("累積ID");

                entity.Property(e => e.PageMenuLvl)
                    .HasPrecision(2)
                    .HasColumnName("page_menu_lvl")
                    .HasComment("層級");

                entity.Property(e => e.PageMenuMemo)
                    .HasMaxLength(100)
                    .HasColumnName("page_menu_memo")
                    .HasComment("備註");

                entity.Property(e => e.PageMenuNm)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("page_menu_nm")
                    .HasComment("選單名稱");

                entity.Property(e => e.PageMenuNma)
                    .HasMaxLength(200)
                    .HasColumnName("page_menu_nma")
                    .HasComment("累積名稱");

                entity.Property(e => e.PageMenuNo)
                    .HasMaxLength(8)
                    .HasColumnName("page_menu_no")
                    .HasComment("選單代號");

                entity.Property(e => e.PageMenuNoa)
                    .HasMaxLength(50)
                    .HasColumnName("page_menu_noa")
                    .HasComment("累積碼");

                entity.Property(e => e.PageMenuNtyp)
                    .HasMaxLength(10)
                    .HasColumnName("page_menu_ntyp")
                    .HasComment("節點類型");

                entity.Property(e => e.PageMenuPic)
                    .HasMaxLength(60)
                    .HasColumnName("page_menu_pic")
                    .HasComment("圖片");

                entity.Property(e => e.PageMenuPid)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("page_menu_pid")
                    .HasComment("父節點ID");

                entity.Property(e => e.PageMenuPrtc)
                    .HasMaxLength(10)
                    .HasColumnName("page_menu_prtc")
                    .HasComment("通訊協議");

                entity.Property(e => e.PageMenuShow)
                    .HasMaxLength(1)
                    .HasColumnName("page_menu_show")
                    .HasDefaultValueSql("'D'::bpchar")
                    .HasComment("是否顯示在首頁選單。D:預設(依權限);N:不顯示;Y:公開(預留)");

                entity.Property(e => e.PageMenuSort)
                    .HasPrecision(4)
                    .HasColumnName("page_menu_sort")
                    .HasComment("排序");

                entity.Property(e => e.PageMenuSsvr)
                    .HasMaxLength(22)
                    .HasColumnName("page_menu_ssvr")
                    .HasComment("伺服器");

                entity.Property(e => e.PageMenuStat)
                    .HasMaxLength(1)
                    .HasColumnName("page_menu_stat")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("狀態");

                entity.Property(e => e.PageUriId)
                    .HasMaxLength(22)
                    .HasColumnName("page_uri_id")
                    .HasComment("程式頁面 ID");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasComment("異動人ID");

                entity.HasOne(d => d.PageUri)
                    .WithMany(p => p.PageMenus)
                    .HasForeignKey(d => d.PageUriId)
                    .HasConstraintName("page_menu_fk_page_uri");
            });

            modelBuilder.Entity<PageOpColumn>(entity =>
            {
                entity.HasKey(e => e.PageColId)
                    .HasName("page_op_column_pk");

                entity.ToTable("page_op_column", "fw_mif");

                entity.HasComment("畫面操作列");

                entity.HasIndex(e => new { e.PageUriId, e.PageColUnit, e.PageColCol }, "page_op_column_ui")
                    .IsUnique();

                entity.Property(e => e.PageColId)
                    .HasMaxLength(22)
                    .HasColumnName("page_col_id")
                    .HasComment("頁面權限欄位ID");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.PageColCol)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("page_col_col")
                    .HasComment("欄位名");

                entity.Property(e => e.PageColDesc)
                    .HasMaxLength(30)
                    .HasColumnName("page_col_desc")
                    .HasComment("描述");

                entity.Property(e => e.PageColOp)
                    .HasPrecision(1)
                    .HasColumnName("page_col_op")
                    .HasDefaultValueSql("2")
                    .HasComment("操作權限");

                entity.Property(e => e.PageColUnit)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("page_col_unit")
                    .HasComment("表名");

                entity.Property(e => e.PageUriId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("page_uri_id")
                    .HasComment("程式頁面 ID");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasComment("異動人ID");

                entity.HasOne(d => d.PageUri)
                    .WithMany(p => p.PageOpColumns)
                    .HasForeignKey(d => d.PageUriId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("page_op_column_fk_page_uri");
            });

            modelBuilder.Entity<PageOpElement>(entity =>
            {
                entity.HasKey(e => e.PageEleId)
                    .HasName("page_op_element_pk");

                entity.ToTable("page_op_element", "fw_mif");

                entity.HasComment("畫面操作元素");

                entity.HasIndex(e => new { e.PageUriId, e.PageEleIdentify }, "page_op_element_ui")
                    .IsUnique();

                entity.Property(e => e.PageEleId)
                    .HasMaxLength(22)
                    .HasColumnName("page_ele_id")
                    .HasComment("頁面權限元素 ID");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.PageEleDesc)
                    .HasMaxLength(30)
                    .HasColumnName("page_ele_desc")
                    .HasComment("描述");

                entity.Property(e => e.PageEleIdentify)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("page_ele_identify")
                    .HasComment("識別名稱");

                entity.Property(e => e.PageEleOp)
                    .HasPrecision(1)
                    .HasColumnName("page_ele_op")
                    .HasDefaultValueSql("2")
                    .HasComment("操作權限");

                entity.Property(e => e.PageResId)
                    .HasMaxLength(22)
                    .HasColumnName("page_res_id")
                    .HasComment("動作資源");

                entity.Property(e => e.PageUriId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("page_uri_id")
                    .HasComment("程式頁面 ID");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasComment("異動人ID");

                entity.HasOne(d => d.PageRes)
                    .WithMany(p => p.PageOpElements)
                    .HasForeignKey(d => d.PageResId)
                    .HasConstraintName("page_op_element_fk1");

                entity.HasOne(d => d.PageUri)
                    .WithMany(p => p.PageOpElements)
                    .HasForeignKey(d => d.PageUriId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("page_op_element_fk_page_uri");
            });

            modelBuilder.Entity<PageOpResource>(entity =>
            {
                entity.HasKey(e => e.PageResId)
                    .HasName("page_op_resource_pk");

                entity.ToTable("page_op_resource", "fw_mif");

                entity.HasComment("畫面資源");

                entity.HasIndex(e => new { e.PageUriId, e.PageResType, e.PageResNo }, "page_op_resource_ui")
                    .IsUnique();

                entity.Property(e => e.PageResId)
                    .HasMaxLength(22)
                    .HasColumnName("page_res_id")
                    .HasComment("頁面資源 ID");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.PageResMemo)
                    .HasMaxLength(100)
                    .HasColumnName("page_res_memo")
                    .HasComment("備註");

                entity.Property(e => e.PageResNo)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("page_res_no")
                    .HasComment("資源內容");

                entity.Property(e => e.PageResType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("page_res_type")
                    .HasDefaultValueSql("'DM'::character varying")
                    .HasComment("資源類型(DM,QM,QU,URI)");

                entity.Property(e => e.PageUriId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("page_uri_id")
                    .HasComment("程式頁面 ID");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasComment("異動人ID");

                entity.HasOne(d => d.PageUri)
                    .WithMany(p => p.PageOpResources)
                    .HasForeignKey(d => d.PageUriId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("page_res_fk_page_uri");
            });

            modelBuilder.Entity<PageOpTable>(entity =>
            {
                entity.HasKey(e => e.PageTblId)
                    .HasName("page_op_table_pk");

                entity.ToTable("page_op_table", "fw_mif");

                entity.HasComment("畫面操作表");

                entity.HasIndex(e => new { e.PageUriId, e.PageTblUnit }, "page_op_table_ui")
                    .IsUnique();

                entity.Property(e => e.PageTblId)
                    .HasMaxLength(22)
                    .HasColumnName("page_tbl_id")
                    .HasComment("頁面權限表 ID");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.PageTblA)
                    .HasMaxLength(1)
                    .HasColumnName("page_tbl_a")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("新增");

                entity.Property(e => e.PageTblD)
                    .HasMaxLength(1)
                    .HasColumnName("page_tbl_d")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("删除");

                entity.Property(e => e.PageTblDesc)
                    .HasMaxLength(30)
                    .HasColumnName("page_tbl_desc")
                    .HasComment("描述");

                entity.Property(e => e.PageTblM)
                    .HasMaxLength(1)
                    .HasColumnName("page_tbl_m")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("修改");

                entity.Property(e => e.PageTblUnit)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("page_tbl_unit")
                    .HasComment("表名");

                entity.Property(e => e.PageUriId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("page_uri_id")
                    .HasComment("程式頁面 ID");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasComment("異動人ID");

                entity.HasOne(d => d.PageUri)
                    .WithMany(p => p.PageOpTables)
                    .HasForeignKey(d => d.PageUriId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("page_op_table_fk_page_uri");
            });

            modelBuilder.Entity<PageUri>(entity =>
            {
                entity.ToTable("page_uri", "fw_mif");

                entity.HasComment("系統畫面");

                entity.HasIndex(e => new { e.PageUri1, e.ApName }, "page_uri_uk1")
                    .IsUnique();

                entity.Property(e => e.PageUriId)
                    .HasMaxLength(22)
                    .HasColumnName("page_uri_id")
                    .HasComment("程式頁面 ID");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.PageTarget)
                    .HasMaxLength(20)
                    .HasColumnName("page_target")
                    .HasComment("頁面開啟位置");

                entity.Property(e => e.PageUri1)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("page_uri")
                    .HasComment("URI");

                entity.Property(e => e.PageUriMdl)
                    .HasMaxLength(60)
                    .HasColumnName("page_uri_mdl")
                    .HasComment("模型名稱");

                entity.Property(e => e.PageUriMemo)
                    .HasMaxLength(100)
                    .HasColumnName("page_uri_memo")
                    .HasComment("備註");

                entity.Property(e => e.PageUriNm)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("page_uri_nm")
                    .HasComment("頁面名稱");

                entity.Property(e => e.PageUriStat)
                    .HasMaxLength(1)
                    .HasColumnName("page_uri_stat")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("狀態");

                entity.Property(e => e.PageUriTyp)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("page_uri_typ")
                    .HasDefaultValueSql("'JS_PAGE'::character varying")
                    .HasComment("程式頁面類型 (JP_PAGE / URI / URL)");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasComment("異動人ID");
            });

            modelBuilder.Entity<Pbcatcol>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pbcatcol", "ap_mif");

                entity.HasIndex(e => new { e.PbcTnam, e.PbcOwnr, e.PbcCnam }, "pbcatc_x")
                    .IsUnique();

                entity.Property(e => e.PbcBmap)
                    .HasMaxLength(1)
                    .HasColumnName("pbc_bmap");

                entity.Property(e => e.PbcCase).HasColumnName("pbc_case");

                entity.Property(e => e.PbcCid).HasColumnName("pbc_cid");

                entity.Property(e => e.PbcCmnt)
                    .HasMaxLength(254)
                    .HasColumnName("pbc_cmnt");

                entity.Property(e => e.PbcCnam)
                    .IsRequired()
                    .HasMaxLength(65)
                    .HasColumnName("pbc_cnam")
                    .IsFixedLength(true);

                entity.Property(e => e.PbcEdit)
                    .HasMaxLength(31)
                    .HasColumnName("pbc_edit");

                entity.Property(e => e.PbcHdr)
                    .HasMaxLength(254)
                    .HasColumnName("pbc_hdr");

                entity.Property(e => e.PbcHght).HasColumnName("pbc_hght");

                entity.Property(e => e.PbcHpos).HasColumnName("pbc_hpos");

                entity.Property(e => e.PbcInit)
                    .HasMaxLength(254)
                    .HasColumnName("pbc_init");

                entity.Property(e => e.PbcJtfy).HasColumnName("pbc_jtfy");

                entity.Property(e => e.PbcLabl)
                    .HasMaxLength(254)
                    .HasColumnName("pbc_labl");

                entity.Property(e => e.PbcLpos).HasColumnName("pbc_lpos");

                entity.Property(e => e.PbcMask)
                    .HasMaxLength(31)
                    .HasColumnName("pbc_mask");

                entity.Property(e => e.PbcOwnr)
                    .IsRequired()
                    .HasMaxLength(65)
                    .HasColumnName("pbc_ownr")
                    .IsFixedLength(true);

                entity.Property(e => e.PbcPtrn)
                    .HasMaxLength(31)
                    .HasColumnName("pbc_ptrn");

                entity.Property(e => e.PbcTag)
                    .HasMaxLength(254)
                    .HasColumnName("pbc_tag");

                entity.Property(e => e.PbcTid).HasColumnName("pbc_tid");

                entity.Property(e => e.PbcTnam)
                    .IsRequired()
                    .HasMaxLength(65)
                    .HasColumnName("pbc_tnam")
                    .IsFixedLength(true);

                entity.Property(e => e.PbcWdth).HasColumnName("pbc_wdth");
            });

            modelBuilder.Entity<Pbcatedt>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pbcatedt", "ap_mif");

                entity.HasIndex(e => new { e.PbeName, e.PbeSeqn }, "pbcate_x")
                    .IsUnique();

                entity.Property(e => e.PbeCntr).HasColumnName("pbe_cntr");

                entity.Property(e => e.PbeEdit)
                    .HasMaxLength(254)
                    .HasColumnName("pbe_edit");

                entity.Property(e => e.PbeFlag).HasColumnName("pbe_flag");

                entity.Property(e => e.PbeName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("pbe_name");

                entity.Property(e => e.PbeSeqn).HasColumnName("pbe_seqn");

                entity.Property(e => e.PbeType).HasColumnName("pbe_type");

                entity.Property(e => e.PbeWork)
                    .HasMaxLength(32)
                    .HasColumnName("pbe_work")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Pbcatfmt>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pbcatfmt", "ap_mif");

                entity.HasIndex(e => e.PbfName, "pbcatf_x")
                    .IsUnique();

                entity.Property(e => e.PbfCntr).HasColumnName("pbf_cntr");

                entity.Property(e => e.PbfFrmt)
                    .HasMaxLength(254)
                    .HasColumnName("pbf_frmt");

                entity.Property(e => e.PbfName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("pbf_name");

                entity.Property(e => e.PbfType).HasColumnName("pbf_type");
            });

            modelBuilder.Entity<Pbcattbl>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pbcattbl", "ap_mif");

                entity.HasIndex(e => new { e.PbtTnam, e.PbtOwnr }, "pbcatt_x")
                    .IsUnique();

                entity.Property(e => e.PbdFchr).HasColumnName("pbd_fchr");

                entity.Property(e => e.PbdFfce)
                    .HasMaxLength(18)
                    .HasColumnName("pbd_ffce")
                    .IsFixedLength(true);

                entity.Property(e => e.PbdFhgt).HasColumnName("pbd_fhgt");

                entity.Property(e => e.PbdFitl)
                    .HasMaxLength(1)
                    .HasColumnName("pbd_fitl");

                entity.Property(e => e.PbdFptc).HasColumnName("pbd_fptc");

                entity.Property(e => e.PbdFunl)
                    .HasMaxLength(1)
                    .HasColumnName("pbd_funl");

                entity.Property(e => e.PbdFwgt).HasColumnName("pbd_fwgt");

                entity.Property(e => e.PbhFchr).HasColumnName("pbh_fchr");

                entity.Property(e => e.PbhFfce)
                    .HasMaxLength(18)
                    .HasColumnName("pbh_ffce")
                    .IsFixedLength(true);

                entity.Property(e => e.PbhFhgt).HasColumnName("pbh_fhgt");

                entity.Property(e => e.PbhFitl)
                    .HasMaxLength(1)
                    .HasColumnName("pbh_fitl");

                entity.Property(e => e.PbhFptc).HasColumnName("pbh_fptc");

                entity.Property(e => e.PbhFunl)
                    .HasMaxLength(1)
                    .HasColumnName("pbh_funl");

                entity.Property(e => e.PbhFwgt).HasColumnName("pbh_fwgt");

                entity.Property(e => e.PblFchr).HasColumnName("pbl_fchr");

                entity.Property(e => e.PblFfce)
                    .HasMaxLength(18)
                    .HasColumnName("pbl_ffce")
                    .IsFixedLength(true);

                entity.Property(e => e.PblFhgt).HasColumnName("pbl_fhgt");

                entity.Property(e => e.PblFitl)
                    .HasMaxLength(1)
                    .HasColumnName("pbl_fitl");

                entity.Property(e => e.PblFptc).HasColumnName("pbl_fptc");

                entity.Property(e => e.PblFunl)
                    .HasMaxLength(1)
                    .HasColumnName("pbl_funl");

                entity.Property(e => e.PblFwgt).HasColumnName("pbl_fwgt");

                entity.Property(e => e.PbtCmnt)
                    .HasMaxLength(254)
                    .HasColumnName("pbt_cmnt");

                entity.Property(e => e.PbtOwnr)
                    .IsRequired()
                    .HasMaxLength(65)
                    .HasColumnName("pbt_ownr")
                    .IsFixedLength(true);

                entity.Property(e => e.PbtTid).HasColumnName("pbt_tid");

                entity.Property(e => e.PbtTnam)
                    .IsRequired()
                    .HasMaxLength(65)
                    .HasColumnName("pbt_tnam")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Pbcatvld>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pbcatvld", "ap_mif");

                entity.HasIndex(e => e.PbvName, "pbcatv_x")
                    .IsUnique();

                entity.Property(e => e.PbvCntr).HasColumnName("pbv_cntr");

                entity.Property(e => e.PbvMsg)
                    .HasMaxLength(254)
                    .HasColumnName("pbv_msg");

                entity.Property(e => e.PbvName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("pbv_name");

                entity.Property(e => e.PbvType).HasColumnName("pbv_type");

                entity.Property(e => e.PbvVald)
                    .HasMaxLength(254)
                    .HasColumnName("pbv_vald");
            });

            modelBuilder.Entity<PcagKanbanShoeFact>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pcag_kanban_shoe_fact", "ap_mif");

                entity.Property(e => e.CrateDate)
                    .HasColumnType("date")
                    .HasColumnName("crate_date");

                entity.Property(e => e.FactNameEng)
                    .HasColumnType("character varying")
                    .HasColumnName("fact_name_eng");

                entity.Property(e => e.FactNameZh)
                    .HasColumnType("character varying")
                    .HasColumnName("fact_name_zh");

                entity.Property(e => e.FactNo)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("fact_no");

                entity.Property(e => e.ModifyDate)
                    .HasColumnType("character varying")
                    .HasColumnName("modify_date");

                entity.Property(e => e.Pph)
                    .HasColumnType("character varying")
                    .HasColumnName("pph");

                entity.Property(e => e.Rft)
                    .HasColumnType("character varying")
                    .HasColumnName("rft");
            });

            modelBuilder.Entity<PcagKanbanShoeProdSum>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pcag_kanban_shoe_prod_sum", "ap_mif");

                entity.Property(e => e.Factory)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("factory")
                    .HasComment("廠別");

                entity.Property(e => e.Lineid)
                    .HasColumnType("character varying")
                    .HasColumnName("lineid")
                    .HasComment("線別");

                entity.Property(e => e.ProdQuantity)
                    .HasColumnType("character varying")
                    .HasColumnName("prod_quantity")
                    .HasComment("累績生產數量");

                entity.Property(e => e.ProdType)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("prod_type")
                    .HasComment("製程");

                entity.Property(e => e.ProdTypeName)
                    .HasColumnType("character varying")
                    .HasColumnName("prod_type_name")
                    .HasComment("製程名稱");
            });

            modelBuilder.Entity<PelletspkListSfa>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pelletspk_list_sfa", "ap_mif");

                entity.Property(e => e.Aufnr)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("aufnr");

                entity.Property(e => e.ColorNm)
                    .HasMaxLength(200)
                    .HasColumnName("color_nm");

                entity.Property(e => e.ColorNo)
                    .HasMaxLength(10)
                    .HasColumnName("color_no");

                entity.Property(e => e.ErpSpkqty)
                    .HasPrecision(18, 8)
                    .HasColumnName("erp_spkqty");

                entity.Property(e => e.Gamng)
                    .HasPrecision(18, 8)
                    .HasColumnName("gamng");

                entity.Property(e => e.Maktx)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("maktx");

                entity.Property(e => e.Materialname)
                    .HasMaxLength(30)
                    .HasColumnName("materialname");

                entity.Property(e => e.PartNo)
                    .HasMaxLength(10)
                    .HasColumnName("part_no");

                entity.Property(e => e.Plnbez)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("plnbez");

                entity.Property(e => e.Prodbatch)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("prodbatch");

                entity.Property(e => e.ProductNo)
                    .HasMaxLength(20)
                    .HasColumnName("product_no");

                entity.Property(e => e.ProductType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("product_type");

                entity.Property(e => e.Return)
                    .HasPrecision(18, 8)
                    .HasColumnName("return");

                entity.Property(e => e.SoSize)
                    .HasMaxLength(30)
                    .HasColumnName("so_size");

                entity.Property(e => e.StockIn)
                    .HasPrecision(18, 8)
                    .HasColumnName("stock_in");

                entity.Property(e => e.Stockout)
                    .HasPrecision(18, 8)
                    .HasColumnName("stockout");

                entity.Property(e => e.Trackout)
                    .HasPrecision(18, 8)
                    .HasColumnName("trackout");

                entity.Property(e => e.WoSize)
                    .HasMaxLength(30)
                    .HasColumnName("wo_size");

                entity.Property(e => e.Workdate)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("workdate");

                entity.Property(e => e.Workno)
                    .IsRequired()
                    .HasMaxLength(400)
                    .HasColumnName("workno");

                entity.Property(e => e.Workseq)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("workseq")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<QcReason>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("qc_reason", "ap_mif");

                entity.Property(e => e.FactNo)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("fact_no");

                entity.Property(e => e.QcNm)
                    .HasMaxLength(50)
                    .HasColumnName("qc_nm");

                entity.Property(e => e.QcNo)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("qc_no");
            });

            modelBuilder.Entity<ScCatCtrl>(entity =>
            {
                entity.HasKey(e => e.CatCtrlId)
                    .HasName("sc_cat_ctrl_pk");

                entity.ToTable("sc_cat_ctrl", "fw_mif");

                entity.HasIndex(e => new { e.TableName, e.ColumnName, e.CatNo, e.ApName }, "sc_cat_ctrl_uk1")
                    .IsUnique();

                entity.Property(e => e.CatCtrlId)
                    .HasMaxLength(22)
                    .HasColumnName("cat_ctrl_id")
                    .HasComment("單據分類ID");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name");

                entity.Property(e => e.CatNm)
                    .HasMaxLength(40)
                    .HasColumnName("cat_nm")
                    .HasComment("分類說明");

                entity.Property(e => e.CatNo)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("cat_no")
                    .HasComment("分類編號");

                entity.Property(e => e.ColumnName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("column_name")
                    .HasComment("欄位名");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("table_name")
                    .HasComment("表名");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasComment("異動人ID");
            });

            modelBuilder.Entity<ScCodeLast>(entity =>
            {
                entity.ToTable("sc_code_last", "fw_mif");

                entity.HasIndex(e => new { e.ScPlanId, e.ScCodeRef }, "sc_code_last_uk1")
                    .IsUnique();

                entity.Property(e => e.ScCodeLastId)
                    .HasMaxLength(22)
                    .HasColumnName("sc_code_last_id")
                    .HasComment("ID");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.ScCodeRef)
                    .HasMaxLength(20)
                    .HasColumnName("sc_code_ref")
                    .HasComment("流水參照");

                entity.Property(e => e.ScCodeSeq)
                    .HasPrecision(10)
                    .HasColumnName("sc_code_seq")
                    .HasComment("最新流水號");

                entity.Property(e => e.ScPlanId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("sc_plan_id")
                    .HasComment("編碼方案ID");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasComment("異動人ID");

                entity.HasOne(d => d.ScPlan)
                    .WithMany(p => p.ScCodeLasts)
                    .HasForeignKey(d => d.ScPlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sc_code_last_fk1");
            });

            modelBuilder.Entity<ScCodeRecycling>(entity =>
            {
                entity.HasKey(e => e.RecyclingId)
                    .HasName("sc_code_recycling_pk");

                entity.ToTable("sc_code_recycling", "fw_mif");

                entity.HasIndex(e => new { e.ScPlanId, e.ScCodeRef }, "sc_code_recycling_uk1")
                    .IsUnique();

                entity.Property(e => e.RecyclingId)
                    .HasMaxLength(22)
                    .HasColumnName("recycling_id")
                    .HasComment("ID");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.ScCodeRef)
                    .HasMaxLength(20)
                    .HasColumnName("sc_code_ref")
                    .HasComment("流水參照");

                entity.Property(e => e.ScCodeSeq)
                    .HasColumnName("sc_code_seq")
                    .HasComment("回收流水號");

                entity.Property(e => e.ScPlanId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("sc_plan_id")
                    .HasComment("編碼方案ID");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasComment("異動人ID");

                entity.HasOne(d => d.ScPlan)
                    .WithMany(p => p.ScCodeRecyclings)
                    .HasForeignKey(d => d.ScPlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sc_code_recycling_fk1");
            });

            modelBuilder.Entity<ScPlan>(entity =>
            {
                entity.ToTable("sc_plan", "fw_mif");

                entity.HasIndex(e => new { e.ScPlanNo, e.ApName }, "sc_plan_uk1")
                    .IsUnique();

                entity.Property(e => e.ScPlanId)
                    .HasMaxLength(22)
                    .HasColumnName("sc_plan_id")
                    .HasComment("編號方案ID");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.IsRc)
                    .HasMaxLength(1)
                    .HasColumnName("is_rc")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("是否可回收?");

                entity.Property(e => e.ScPlanNm)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("sc_plan_nm")
                    .HasComment("編號方案名稱");

                entity.Property(e => e.ScPlanNo)
                    .HasMaxLength(10)
                    .HasColumnName("sc_plan_no")
                    .HasComment("編號方案No");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasComment("異動人ID");
            });

            modelBuilder.Entity<ScPlanPart>(entity =>
            {
                entity.HasKey(e => e.ScPartId)
                    .HasName("sc_plan_part_pk");

                entity.ToTable("sc_plan_part", "fw_mif");

                entity.HasIndex(e => new { e.ScPlanId, e.ScPartSeq }, "sc_plan_part_uk1")
                    .IsUnique();

                entity.Property(e => e.ScPartId)
                    .HasMaxLength(22)
                    .HasColumnName("sc_part_id")
                    .HasComment("PART ID");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.ScMemo)
                    .HasMaxLength(60)
                    .HasColumnName("sc_memo")
                    .HasComment("備註");

                entity.Property(e => e.ScPartCond)
                    .HasMaxLength(80)
                    .HasColumnName("sc_part_cond")
                    .HasComment("取值條件");

                entity.Property(e => e.ScPartContent)
                    .HasMaxLength(30)
                    .HasColumnName("sc_part_content")
                    .HasComment("PART內容");

                entity.Property(e => e.ScPartLength)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("sc_part_length")
                    .HasDefaultValueSql("'0 '::character varying")
                    .HasComment("長度");

                entity.Property(e => e.ScPartSeq)
                    .HasPrecision(2)
                    .HasColumnName("sc_part_seq")
                    .HasComment("組成順序");

                entity.Property(e => e.ScPartType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("sc_part_type")
                    .HasDefaultValueSql("'0'::character varying")
                    .HasComment("PART 類型 (0: 固定, 1: 來源欄位, 2: 系統時間, 3: 流水號)");

                entity.Property(e => e.ScPlanId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("sc_plan_id")
                    .HasComment("編碼方案ID");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasComment("異動人ID");

                entity.HasOne(d => d.ScPlan)
                    .WithMany(p => p.ScPlanParts)
                    .HasForeignKey(d => d.ScPlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sc_plan_part_fk1");
            });

            modelBuilder.Entity<ScSetting>(entity =>
            {
                entity.ToTable("sc_setting", "fw_mif");

                entity.HasIndex(e => new { e.TargetTblNm, e.TargetColNm, e.CatCtrlId, e.ScFct, e.ApName }, "sc_setting_uk1")
                    .IsUnique();

                entity.Property(e => e.ScSettingId)
                    .HasMaxLength(22)
                    .HasColumnName("sc_setting_id")
                    .HasComment("ID");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name");

                entity.Property(e => e.CatColNm)
                    .HasMaxLength(30)
                    .HasColumnName("cat_col_nm")
                    .HasDefaultValueSql("'0 \n'::character varying")
                    .HasComment("類別字段");

                entity.Property(e => e.CatCtrlId)
                    .HasMaxLength(22)
                    .HasColumnName("cat_ctrl_id")
                    .HasDefaultValueSql("'0 \n'::character varying")
                    .HasComment("單據分類ID");

                entity.Property(e => e.CatTblNm)
                    .HasMaxLength(30)
                    .HasColumnName("cat_tbl_nm")
                    .HasDefaultValueSql("'0 \n'::character varying")
                    .HasComment("類別表");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.ScFct)
                    .HasMaxLength(5)
                    .HasColumnName("sc_fct")
                    .HasComment("廠別");

                entity.Property(e => e.ScPlanId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("sc_plan_id")
                    .HasComment("編碼方案ID");

                entity.Property(e => e.TargetColNm)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("target_col_nm")
                    .HasComment("目的欄位名");

                entity.Property(e => e.TargetTblNm)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("target_tbl_nm")
                    .HasComment("目的表名");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasComment("異動人ID");

                entity.HasOne(d => d.CatCtrl)
                    .WithMany(p => p.ScSettings)
                    .HasForeignKey(d => d.CatCtrlId)
                    .HasConstraintName("sc_setting_fk1");

                entity.HasOne(d => d.ScPlan)
                    .WithMany(p => p.ScSettings)
                    .HasForeignKey(d => d.ScPlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sc_setting_fk2");
            });

            modelBuilder.Entity<SchedConflictJob>(entity =>
            {
                entity.HasKey(e => e.ConflictJobId)
                    .HasName("sched_conflict_job_pk");

                entity.ToTable("sched_conflict_job", "fw_mif");

                entity.HasIndex(e => e.SettingMId, "ind_setting_m_id");

                entity.Property(e => e.ConflictJobId)
                    .HasMaxLength(22)
                    .HasColumnName("conflict_job_id");

                entity.Property(e => e.Grouping)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("grouping");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.Priority)
                    .HasPrecision(11)
                    .HasColumnName("priority")
                    .HasDefaultValueSql("5")
                    .HasComment("優先權 範圍(高 --> 低)(1-9)");

                entity.Property(e => e.SettingMId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("setting_m_id");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasDefaultValueSql("'NULL'::character varying")
                    .HasComment("異動人ID");

                entity.HasOne(d => d.SettingM)
                    .WithMany(p => p.SchedConflictJobs)
                    .HasForeignKey(d => d.SettingMId)
                    .HasConstraintName("conflict_job_fk_sched_set_m");
            });

            modelBuilder.Entity<SchedConflictQueue>(entity =>
            {
                entity.HasKey(e => e.ConflictQueueId)
                    .HasName("sched_conflict_queue_pk");

                entity.ToTable("sched_conflict_queue", "fw_mif");

                entity.HasIndex(e => e.SettingMId, "ind_scq_setting_m_id");

                entity.Property(e => e.ConflictQueueId)
                    .HasMaxLength(22)
                    .HasColumnName("conflict_queue_id");

                entity.Property(e => e.Grouping)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("grouping");

                entity.Property(e => e.InsertTime)
                    .HasPrecision(19)
                    .HasColumnName("insert_time");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.SettingMId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("setting_m_id");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("status");

                entity.HasOne(d => d.SettingM)
                    .WithMany(p => p.SchedConflictQueues)
                    .HasForeignKey(d => d.SettingMId)
                    .HasConstraintName("conflict_queue_fk_sched_set_m");
            });

            modelBuilder.Entity<SchedLog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("sched_log_pk");

                entity.ToTable("sched_log", "fw_mif");

                entity.HasIndex(e => e.SettingDId, "ind_setting_d_id");

                entity.HasIndex(e => e.SettingMId, "ind_sl_setting_m_id");

                entity.Property(e => e.LogId)
                    .HasMaxLength(22)
                    .HasColumnName("log_id");

                entity.Property(e => e.CompleteTime)
                    .HasPrecision(19)
                    .HasColumnName("complete_time")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.ExecuteTime)
                    .HasPrecision(19)
                    .HasColumnName("execute_time");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.LogType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("log_type")
                    .HasComment("EXEC、DELAY_EXEC、RETRY_EXEC、DELAYED、SKIPPED、KILLED、UPDATED、STARTUP、SHUTDOWN");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("message");

                entity.Property(e => e.Remark).HasColumnName("remark");

                entity.Property(e => e.SettingDId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("setting_d_id");

                entity.Property(e => e.SettingMId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("setting_m_id");

                entity.Property(e => e.Success)
                    .HasMaxLength(1)
                    .HasColumnName("success")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("執行成功否? Y:成功 N:失敗");

                entity.HasOne(d => d.SettingD)
                    .WithMany(p => p.SchedLogs)
                    .HasForeignKey(d => d.SettingDId)
                    .HasConstraintName("sched_log_fk_sched_setting_d");
            });

            modelBuilder.Entity<SchedParam>(entity =>
            {
                entity.HasKey(e => e.ParamId)
                    .HasName("sched_param_pk");

                entity.ToTable("sched_param", "fw_mif");

                entity.HasIndex(e => e.SettingMId, "ind_sp_setting_m_id");

                entity.Property(e => e.ParamId)
                    .HasMaxLength(22)
                    .HasColumnName("param_id");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.ParamKey)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("param_key");

                entity.Property(e => e.ParamValue)
                    .IsRequired()
                    .HasMaxLength(4000)
                    .HasColumnName("param_value");

                entity.Property(e => e.SettingMId)
                    .HasMaxLength(22)
                    .HasColumnName("setting_m_id")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.HasOne(d => d.SettingM)
                    .WithMany(p => p.SchedParams)
                    .HasForeignKey(d => d.SettingMId)
                    .HasConstraintName("sched_param_fk_sched_setting_m");
            });

            modelBuilder.Entity<SchedSettingD>(entity =>
            {
                entity.HasKey(e => e.SettingDId)
                    .HasName("sched_setting_d_pk");

                entity.ToTable("sched_setting_d", "fw_mif");

                entity.HasIndex(e => e.SettingMId, "ind_ss_setting_m_id");

                entity.Property(e => e.SettingDId)
                    .HasMaxLength(22)
                    .HasColumnName("setting_d_id");

                entity.Property(e => e.DayOfMonth)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("day_of_month")
                    .HasDefaultValueSql("'*'::character varying");

                entity.Property(e => e.DayOfWeek)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("day_of_week")
                    .HasDefaultValueSql("'*'::character varying");

                entity.Property(e => e.Hours)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("hours")
                    .HasDefaultValueSql("'*'::character varying");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.Minutes)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("minutes")
                    .HasDefaultValueSql("'0'::character varying");

                entity.Property(e => e.Month)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("month")
                    .HasDefaultValueSql("'*'::character varying");

                entity.Property(e => e.Seconds)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("seconds")
                    .HasDefaultValueSql("'0'::character varying");

                entity.Property(e => e.SettingMId)
                    .HasMaxLength(22)
                    .HasColumnName("setting_m_id")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.StartTime)
                    .HasPrecision(19)
                    .HasColumnName("start_time");

                entity.HasOne(d => d.SettingM)
                    .WithMany(p => p.SchedSettingDs)
                    .HasForeignKey(d => d.SettingMId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("sched_setting_d_fk_sched_set_m");
            });

            modelBuilder.Entity<SchedSettingM>(entity =>
            {
                entity.HasKey(e => e.SettingMId)
                    .HasName("sched_setting_m_pk");

                entity.ToTable("sched_setting_m", "fw_mif");

                entity.Property(e => e.SettingMId)
                    .HasMaxLength(22)
                    .HasColumnName("setting_m_id");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name");

                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("class_name");

                entity.Property(e => e.DelayByErrcnt)
                    .HasMaxLength(1)
                    .HasColumnName("delay_by_errcnt")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("延遲時間是否依錯誤次數進行倍數成長。(delay time= retry_interval * error_count)");

                entity.Property(e => e.Deployable)
                    .HasMaxLength(1)
                    .HasColumnName("deployable")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("可發佈註記");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasColumnName("description")
                    .HasDefaultValueSql("'NULL'::character varying")
                    .HasComment("排程說明");

                entity.Property(e => e.Effective)
                    .HasMaxLength(1)
                    .HasColumnName("effective")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("有效註記  Y : 有效 N : 失效");

                entity.Property(e => e.ExecutionMode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("execution_mode")
                    .HasComment("周期類別  O : 執行一次 (ONE) R : 重複執行 (Repeat)");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.JobGroup)
                    .HasMaxLength(1)
                    .HasColumnName("job_group")
                    .HasDefaultValueSql("'N'::character varying")
                    .HasComment("(預留欄位，當一台server無法負荷排程執行時)");

                entity.Property(e => e.Retry)
                    .HasMaxLength(1)
                    .HasColumnName("retry")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("錯誤重新嘗試註記(RETRY)  Y :  會嘗試重新執行；N :  不會嘗試重新執行");

                entity.Property(e => e.RetryInterval)
                    .HasPrecision(11)
                    .HasColumnName("retry_interval")
                    .HasDefaultValueSql("NULL::numeric")
                    .HasComment("間隔多久時間重新嘗試(單位 : 分)");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasDefaultValueSql("'NULL'::character varying")
                    .HasComment("異動人ID");
            });

            modelBuilder.Entity<SchedStateD>(entity =>
            {
                entity.HasKey(e => e.SettingDId)
                    .HasName("sched_state_d_pk");

                entity.ToTable("sched_state_d", "fw_mif");

                entity.Property(e => e.SettingDId)
                    .HasMaxLength(22)
                    .HasColumnName("setting_d_id");

                entity.Property(e => e.ErrorCount)
                    .HasPrecision(11)
                    .HasColumnName("error_count")
                    .HasComment("排程產生例外次數，重起或排程執行完成後歸零，產生例外則累加");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.NextExecuteTime)
                    .HasPrecision(19)
                    .HasColumnName("next_execute_time")
                    .HasComment("發生錯誤時的下次執行時間");

                entity.HasOne(d => d.SettingD)
                    .WithOne(p => p.SchedStateD)
                    .HasForeignKey<SchedStateD>(d => d.SettingDId)
                    .HasConstraintName("sched_state_d_fk_sched_set_d");
            });

            modelBuilder.Entity<SchedStateM>(entity =>
            {
                entity.HasKey(e => e.SettingMId)
                    .HasName("sched_state_m_pk");

                entity.ToTable("sched_state_m", "fw_mif");

                entity.Property(e => e.SettingMId)
                    .HasMaxLength(22)
                    .HasColumnName("setting_m_id");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.Pause)
                    .HasMaxLength(1)
                    .HasColumnName("pause")
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.Scaned)
                    .HasMaxLength(1)
                    .HasColumnName("scaned")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("工作狀態 Y : 已掃描 N : 未掃描");

                entity.HasOne(d => d.SettingM)
                    .WithOne(p => p.SchedStateM)
                    .HasForeignKey<SchedStateM>(d => d.SettingMId)
                    .HasConstraintName("sched_state_m_fk_sched_set_m");
            });

            modelBuilder.Entity<SfaProcess>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("sfa_process", "ap_mif");

                entity.Property(e => e.Auart)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("auart");

                entity.Property(e => e.Aufnr)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("aufnr");

                entity.Property(e => e.ColorName)
                    .IsRequired()
                    .HasMaxLength(400)
                    .HasColumnName("color_name");

                entity.Property(e => e.ColorNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("color_no");

                entity.Property(e => e.Gamng)
                    .HasPrecision(18, 8)
                    .HasColumnName("gamng");

                entity.Property(e => e.PartNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("part_no");

                entity.Property(e => e.Plnbez)
                    .HasMaxLength(20)
                    .HasColumnName("plnbez");

                entity.Property(e => e.ProductNo)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("product_no");

                entity.Property(e => e.Sosize)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("sosize");

                entity.Property(e => e.StockInqty)
                    .HasPrecision(18, 8)
                    .HasColumnName("stock_inqty");

                entity.Property(e => e.StockOutqty)
                    .HasPrecision(18, 8)
                    .HasColumnName("stock_outqty");

                entity.Property(e => e.StockReturnqty)
                    .HasPrecision(18, 8)
                    .HasColumnName("stock_returnqty");

                entity.Property(e => e.StockSt1340)
                    .HasPrecision(18, 8)
                    .HasColumnName("stock_st1340");

                entity.Property(e => e.TrackOutqty)
                    .HasPrecision(18, 8)
                    .HasColumnName("track_outqty");

                entity.Property(e => e.Yymm)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("yymm")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Soleprod>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("soleprod", "ap_mif");

                entity.Property(e => e.Aufnr)
                    .HasMaxLength(20)
                    .HasColumnName("aufnr");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .HasColumnName("createby");

                entity.Property(e => e.Facility)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("facility");

                entity.Property(e => e.Posnr)
                    .HasMaxLength(20)
                    .HasColumnName("posnr");

                entity.Property(e => e.Primaryquantity)
                    .HasPrecision(18, 8)
                    .HasColumnName("primaryquantity");

                entity.Property(e => e.Prodbatch)
                    .HasMaxLength(20)
                    .HasColumnName("prodbatch");

                entity.Property(e => e.Productkind)
                    .HasMaxLength(20)
                    .HasColumnName("productkind");

                entity.Property(e => e.Stepid)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("stepid");

                entity.Property(e => e.Vbeln)
                    .HasMaxLength(20)
                    .HasColumnName("vbeln");

                entity.Property(e => e.Workno)
                    .HasMaxLength(20)
                    .HasColumnName("workno");

                entity.Property(e => e.Workseq)
                    .HasMaxLength(20)
                    .HasColumnName("workseq");

                entity.Property(e => e.Wosize)
                    .HasMaxLength(50)
                    .HasColumnName("wosize");
            });

            modelBuilder.Entity<Srd>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("srd", "ap_mif");

                entity.Property(e => e.Action)
                    .HasMaxLength(20)
                    .HasColumnName("action");

                entity.Property(e => e.Arbpl)
                    .HasMaxLength(20)
                    .HasColumnName("arbpl");

                entity.Property(e => e.Brand)
                    .HasMaxLength(100)
                    .HasColumnName("brand");

                entity.Property(e => e.Buildno)
                    .HasMaxLength(100)
                    .HasColumnName("buildno");

                entity.Property(e => e.Createon)
                    .HasMaxLength(14)
                    .HasColumnName("createon");

                entity.Property(e => e.Floor)
                    .HasMaxLength(20)
                    .HasColumnName("floor");

                entity.Property(e => e.Opgroup)
                    .HasMaxLength(100)
                    .HasColumnName("opgroup");

                entity.Property(e => e.Primaryquantity)
                    .HasPrecision(18, 3)
                    .HasColumnName("primaryquantity");

                entity.Property(e => e.Producttype)
                    .HasMaxLength(512)
                    .HasColumnName("producttype");

                entity.Property(e => e.Rcode)
                    .HasMaxLength(1)
                    .HasColumnName("rcode");

                entity.Property(e => e.Vbeln)
                    .HasMaxLength(20)
                    .HasColumnName("vbeln");

                entity.Property(e => e.Werks)
                    .HasMaxLength(20)
                    .HasColumnName("werks");

                entity.Property(e => e.Zzmdnam)
                    .HasMaxLength(100)
                    .HasColumnName("zzmdnam");

                entity.Property(e => e.Zzoutsol)
                    .HasMaxLength(100)
                    .HasColumnName("zzoutsol");

                entity.Property(e => e.Zzstylco)
                    .HasMaxLength(100)
                    .HasColumnName("zzstylco");
            });

            modelBuilder.Entity<StockPrintSizeSfa>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("stock_print_size_sfa", "ap_mif");

                entity.Property(e => e.ColorNo)
                    .HasMaxLength(10)
                    .HasColumnName("color_no");

                entity.Property(e => e.LastStock).HasColumnName("last_stock");

                entity.Property(e => e.PartNo)
                    .HasMaxLength(10)
                    .HasColumnName("part_no");

                entity.Property(e => e.ProductNo)
                    .HasMaxLength(40)
                    .HasColumnName("product_no");

                entity.Property(e => e.ProductXh)
                    .HasMaxLength(4)
                    .HasColumnName("product_xh");

                entity.Property(e => e.SizeNo)
                    .HasMaxLength(10)
                    .HasColumnName("size_no");

                entity.Property(e => e.WorkType)
                    .HasMaxLength(1)
                    .HasColumnName("work_type");

                entity.Property(e => e.Yymm)
                    .HasMaxLength(6)
                    .HasColumnName("yymm");
            });

            modelBuilder.Entity<StockYymmReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("stock_yymm_report", "ap_mif");

                entity.Property(e => e.ColorB)
                    .HasMaxLength(400)
                    .HasColumnName("color_b");

                entity.Property(e => e.ColorNm)
                    .HasMaxLength(400)
                    .HasColumnName("color_nm");

                entity.Property(e => e.ColorNo)
                    .HasMaxLength(10)
                    .HasColumnName("color_no");

                entity.Property(e => e.FactNo)
                    .HasMaxLength(4)
                    .HasColumnName("fact_no");

                entity.Property(e => e.FirstStock)
                    .HasPrecision(13, 3)
                    .HasColumnName("first_stock");

                entity.Property(e => e.InStock)
                    .HasPrecision(13, 3)
                    .HasColumnName("in_stock");

                entity.Property(e => e.OutStock)
                    .HasPrecision(13, 3)
                    .HasColumnName("out_stock");

                entity.Property(e => e.PartNm)
                    .HasMaxLength(100)
                    .HasColumnName("part_nm");

                entity.Property(e => e.PartNo)
                    .HasMaxLength(10)
                    .HasColumnName("part_no");

                entity.Property(e => e.ProductNo)
                    .HasMaxLength(40)
                    .HasColumnName("product_no");

                entity.Property(e => e.TkStock)
                    .HasPrecision(13, 3)
                    .HasColumnName("tk_stock");

                entity.Property(e => e.Yymm)
                    .HasMaxLength(6)
                    .HasColumnName("yymm");
            });

            modelBuilder.Entity<TalendJob>(entity =>
            {
                entity.ToTable("talend_job", "fw_mif");

                entity.HasIndex(e => new { e.TalendJobName, e.ApName }, "uk_talend_job")
                    .IsUnique();

                entity.Property(e => e.TalendJobId)
                    .HasMaxLength(22)
                    .HasColumnName("talend_job_id")
                    .HasComment("主鍵");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.TalendJobClass)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("talend_job_class")
                    .HasComment("Job 完整 class path");

                entity.Property(e => e.TalendJobDesc)
                    .HasMaxLength(100)
                    .HasColumnName("talend_job_desc")
                    .HasComment("描述");

                entity.Property(e => e.TalendJobName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("talend_job_name")
                    .HasComment("Job 名稱");

                entity.Property(e => e.TalendJobTarget)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("talend_job_target")
                    .HasDefaultValueSql("'C'::character varying")
                    .HasComment("對應的 G2FW 應用. S (Service) / E (Event) / C (Common)");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasComment("異動人ID");
            });

            modelBuilder.Entity<Tempdatum>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tempdata", "ap_mif");

                entity.HasComment("比對資料暫存表");

                entity.Property(e => e.A)
                    .HasMaxLength(100)
                    .HasColumnName("a");

                entity.Property(e => e.B)
                    .HasMaxLength(100)
                    .HasColumnName("b");

                entity.Property(e => e.C)
                    .HasMaxLength(100)
                    .HasColumnName("c");

                entity.Property(e => e.D)
                    .HasMaxLength(100)
                    .HasColumnName("d");

                entity.Property(e => e.E)
                    .HasMaxLength(100)
                    .HasColumnName("e");

                entity.Property(e => e.F)
                    .HasMaxLength(100)
                    .HasColumnName("f");

                entity.Property(e => e.G)
                    .HasMaxLength(100)
                    .HasColumnName("g");

                entity.Property(e => e.H)
                    .HasMaxLength(100)
                    .HasColumnName("h");

                entity.Property(e => e.I)
                    .HasMaxLength(100)
                    .HasColumnName("i");

                entity.Property(e => e.J)
                    .HasMaxLength(100)
                    .HasColumnName("j");

                entity.Property(e => e.K)
                    .HasMaxLength(100)
                    .HasColumnName("k");

                entity.Property(e => e.L)
                    .HasMaxLength(100)
                    .HasColumnName("l");

                entity.Property(e => e.M)
                    .HasMaxLength(100)
                    .HasColumnName("m");

                entity.Property(e => e.N)
                    .HasMaxLength(100)
                    .HasColumnName("n");

                entity.Property(e => e.O)
                    .HasMaxLength(100)
                    .HasColumnName("o");

                entity.Property(e => e.P)
                    .HasMaxLength(100)
                    .HasColumnName("p");

                entity.Property(e => e.Q)
                    .HasMaxLength(100)
                    .HasColumnName("q");

                entity.Property(e => e.R)
                    .HasMaxLength(100)
                    .HasColumnName("r");

                entity.Property(e => e.S)
                    .HasMaxLength(100)
                    .HasColumnName("s");

                entity.Property(e => e.T)
                    .HasMaxLength(100)
                    .HasColumnName("t");

                entity.Property(e => e.U)
                    .HasMaxLength(100)
                    .HasColumnName("u");

                entity.Property(e => e.V)
                    .HasMaxLength(100)
                    .HasColumnName("v");

                entity.Property(e => e.W)
                    .HasMaxLength(100)
                    .HasColumnName("w");

                entity.Property(e => e.X)
                    .HasMaxLength(100)
                    .HasColumnName("x");

                entity.Property(e => e.Y)
                    .HasMaxLength(100)
                    .HasColumnName("y");

                entity.Property(e => e.Z)
                    .HasMaxLength(100)
                    .HasColumnName("z");
            });

            modelBuilder.Entity<TestOdrd>(entity =>
            {
                entity.HasKey(e => new { e.OdrNo, e.SizeNo })
                    .HasName("pk_test_odrd");

                entity.ToTable("test_odrd", "ap_mif");

                entity.Property(e => e.OdrNo)
                    .HasMaxLength(20)
                    .HasColumnName("odr_no");

                entity.Property(e => e.SizeNo)
                    .HasMaxLength(10)
                    .HasColumnName("size_no");

                entity.Property(e => e.CreateName)
                    .HasPrecision(20)
                    .HasColumnName("create_name");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ModifyName)
                    .HasPrecision(20)
                    .HasColumnName("modify_name");

                entity.Property(e => e.ModifyTime)
                    .HasColumnName("modify_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Qty)
                    .HasPrecision(18, 8)
                    .HasColumnName("qty");
            });

            modelBuilder.Entity<TestOdrm>(entity =>
            {
                entity.HasKey(e => new { e.OdrNo, e.ArticNo, e.BrandNo })
                    .HasName("pk_test_odrm");

                entity.ToTable("test_odrm", "ap_mif");

                entity.Property(e => e.OdrNo)
                    .HasMaxLength(20)
                    .HasColumnName("odr_no");

                entity.Property(e => e.ArticNo)
                    .HasMaxLength(20)
                    .HasColumnName("artic_no");

                entity.Property(e => e.BrandNo)
                    .HasMaxLength(15)
                    .HasColumnName("brand_no")
                    .IsFixedLength(true);

                entity.Property(e => e.CreateName)
                    .HasPrecision(20)
                    .HasColumnName("create_name");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CustOdr)
                    .HasMaxLength(20)
                    .HasColumnName("cust_odr");

                entity.Property(e => e.ModifyName)
                    .HasPrecision(20)
                    .HasColumnName("modify_name");

                entity.Property(e => e.ModifyTime)
                    .HasColumnName("modify_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.TotalQty)
                    .HasPrecision(18, 8)
                    .HasColumnName("total_qty");

                entity.Property(e => e.Yymm)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("yymm");
            });

            modelBuilder.Entity<TestWorkm>(entity =>
            {
                entity.HasKey(e => new { e.Workno, e.OdrNo, e.Workdate, e.WoSize })
                    .HasName("pk_test_workm");

                entity.ToTable("test_workm", "ap_mif");

                entity.Property(e => e.Workno)
                    .HasMaxLength(20)
                    .HasColumnName("workno");

                entity.Property(e => e.OdrNo)
                    .HasMaxLength(20)
                    .HasColumnName("odr_no");

                entity.Property(e => e.Workdate)
                    .HasMaxLength(8)
                    .HasColumnName("workdate")
                    .IsFixedLength(true);

                entity.Property(e => e.WoSize)
                    .HasMaxLength(10)
                    .HasColumnName("wo_size");

                entity.Property(e => e.CreateName)
                    .HasPrecision(20)
                    .HasColumnName("create_name");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Gamng)
                    .HasPrecision(18, 8)
                    .HasColumnName("gamng");

                entity.Property(e => e.ModifyName)
                    .HasPrecision(20)
                    .HasColumnName("modify_name");

                entity.Property(e => e.ModifyTime)
                    .HasColumnName("modify_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<TestXml>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("test_xml", "ap_mif");

                entity.Property(e => e.A)
                    .HasColumnType("xml")
                    .HasColumnName("a");

                entity.Property(e => e.B)
                    .HasColumnType("xml")
                    .HasColumnName("b");
            });

            modelBuilder.Entity<TplDesign>(entity =>
            {
                entity.HasKey(e => e.TemplateDesignId)
                    .HasName("tpl_design_pk");

                entity.ToTable("tpl_design", "fw_mif");

                entity.HasIndex(e => e.TemplateSubTypeId, "ind_template_sub_type_id");

                entity.Property(e => e.TemplateDesignId)
                    .HasMaxLength(22)
                    .HasColumnName("template_design_id");

                entity.Property(e => e.ExpireTime)
                    .HasPrecision(19)
                    .HasColumnName("expire_time")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.Locale)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("locale");

                entity.Property(e => e.TemplateContent)
                    .IsRequired()
                    .HasColumnName("template_content");

                entity.Property(e => e.TemplateSubTypeId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("template_sub_type_id");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasDefaultValueSql("'NULL'::character varying")
                    .HasComment("異動人ID");

                entity.HasOne(d => d.TemplateSubType)
                    .WithMany(p => p.TplDesigns)
                    .HasForeignKey(d => d.TemplateSubTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tpl_design_fk_tpl_sub_type");
            });

            modelBuilder.Entity<TplMaster>(entity =>
            {
                entity.HasKey(e => e.TemplateId)
                    .HasName("tpl_master_pk");

                entity.ToTable("tpl_master", "fw_mif");

                entity.HasIndex(e => e.MetaMdlId, "ind_meta_mdl_id");

                entity.Property(e => e.TemplateId)
                    .HasMaxLength(22)
                    .HasColumnName("template_id");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.JsonSampleData).HasColumnName("json_sample_data");

                entity.Property(e => e.MasterId)
                    .HasMaxLength(50)
                    .HasColumnName("master_id")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.MetaMdlId)
                    .HasMaxLength(32)
                    .HasColumnName("meta_mdl_id")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.TemplateAliasName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("template_alias_name");

                entity.Property(e => e.TemplateType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("template_type");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasDefaultValueSql("'NULL'::character varying")
                    .HasComment("異動人ID");

                entity.HasOne(d => d.MetaMdl)
                    .WithMany(p => p.TplMasters)
                    .HasForeignKey(d => d.MetaMdlId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("tpl_master_fk_meta_mdl");
            });

            modelBuilder.Entity<TplSampleDatum>(entity =>
            {
                entity.HasKey(e => e.SampleDataId)
                    .HasName("tpl_sample_data_pk");

                entity.ToTable("tpl_sample_data", "fw_mif");

                entity.HasIndex(e => e.MetaFieldId, "ind_meta_field_id");

                entity.HasIndex(e => e.TemplateId, "ind_template_id");

                entity.Property(e => e.SampleDataId)
                    .HasMaxLength(22)
                    .HasColumnName("sample_data_id");

                entity.Property(e => e.ColumnName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("column_name");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("description");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsDetail)
                    .HasMaxLength(1)
                    .HasColumnName("is_detail")
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.MetaFieldId)
                    .HasMaxLength(32)
                    .HasColumnName("meta_field_id")
                    .HasDefaultValueSql("'NULL\n   '::character varying");

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("table_name");

                entity.Property(e => e.TemplateId)
                    .HasMaxLength(22)
                    .HasColumnName("template_id")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value");

                entity.HasOne(d => d.MetaField)
                    .WithMany(p => p.TplSampleData)
                    .HasForeignKey(d => d.MetaFieldId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("tpl_sample_data_fk_meta_field");

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.TplSampleData)
                    .HasForeignKey(d => d.TemplateId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("tpl_sample_data_fk_tpl_master");
            });

            modelBuilder.Entity<TplSubType>(entity =>
            {
                entity.HasKey(e => e.TemplateSubTypeId)
                    .HasName("tpl_sub_type_pk");

                entity.ToTable("tpl_sub_type", "fw_mif");

                entity.HasIndex(e => e.TemplateId, "ind_tpl_sub_type_template_id");

                entity.Property(e => e.TemplateSubTypeId)
                    .HasMaxLength(22)
                    .HasColumnName("template_sub_type_id");

                entity.Property(e => e.ClassName)
                    .HasMaxLength(255)
                    .HasColumnName("class_name")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.TemplateId)
                    .HasMaxLength(22)
                    .HasColumnName("template_id")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.TemplateSubType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("template_sub_type");

                entity.Property(e => e.TplPath)
                    .HasMaxLength(255)
                    .HasColumnName("tpl_path")
                    .HasDefaultValueSql("'NULL'::character varying");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasDefaultValueSql("'NULL'::character varying")
                    .HasComment("異動人ID");

                entity.Property(e => e.UseTemplate)
                    .HasMaxLength(1)
                    .HasColumnName("use_template")
                    .HasDefaultValueSql("'N'::bpchar");

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.TplSubTypes)
                    .HasForeignKey(d => d.TemplateId)
                    .HasConstraintName("tpl_sub_type_fk_tpl_master");
            });

            modelBuilder.Entity<VAclOpColumnByGroup>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("v_acl_op_column_by_group", "fw_mif");

                entity.Property(e => e.ColumnName)
                    .HasMaxLength(30)
                    .HasColumnName("column_name");

                entity.Property(e => e.ColumnPermission)
                    .HasPrecision(1)
                    .HasColumnName("column_permission");

                entity.Property(e => e.GroupId)
                    .HasMaxLength(22)
                    .HasColumnName("group_id");

                entity.Property(e => e.GroupPageId)
                    .HasMaxLength(22)
                    .HasColumnName("group_page_id");

                entity.Property(e => e.PageMenuId)
                    .HasMaxLength(22)
                    .HasColumnName("page_menu_id");

                entity.Property(e => e.TableName)
                    .HasMaxLength(30)
                    .HasColumnName("table_name");
            });

            modelBuilder.Entity<VAclOpElementByGroup>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("v_acl_op_element_by_group", "fw_mif");

                entity.Property(e => e.ElementLimit)
                    .HasPrecision(1)
                    .HasColumnName("element_limit");

                entity.Property(e => e.ElementResourceUri)
                    .HasMaxLength(200)
                    .HasColumnName("element_resource_uri");

                entity.Property(e => e.GroupId)
                    .HasMaxLength(22)
                    .HasColumnName("group_id");

                entity.Property(e => e.GroupPageId)
                    .HasMaxLength(22)
                    .HasColumnName("group_page_id");

                entity.Property(e => e.PageEleIdentify)
                    .HasMaxLength(30)
                    .HasColumnName("page_ele_identify");

                entity.Property(e => e.PageMenuId)
                    .HasMaxLength(22)
                    .HasColumnName("page_menu_id");
            });

            modelBuilder.Entity<VAclOpTableByGroup>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("v_acl_op_table_by_group", "fw_mif");

                entity.Property(e => e.DatamodelName)
                    .HasMaxLength(60)
                    .HasColumnName("datamodel_name");

                entity.Property(e => e.GroupId)
                    .HasMaxLength(22)
                    .HasColumnName("group_id");

                entity.Property(e => e.GroupPageId)
                    .HasMaxLength(22)
                    .HasColumnName("group_page_id");

                entity.Property(e => e.PageMenuId)
                    .HasMaxLength(22)
                    .HasColumnName("page_menu_id");

                entity.Property(e => e.TableName)
                    .HasMaxLength(50)
                    .HasColumnName("table_name");

                entity.Property(e => e.TablePermissionA)
                    .HasColumnType("char")
                    .HasColumnName("table_permission_a");

                entity.Property(e => e.TablePermissionD)
                    .HasColumnType("char")
                    .HasColumnName("table_permission_d");

                entity.Property(e => e.TablePermissionM)
                    .HasColumnType("char")
                    .HasColumnName("table_permission_m");
            });

            modelBuilder.Entity<VDay>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("v_day", "ap_mif");

                entity.Property(e => e.Round).HasColumnName("round");
            });

            modelBuilder.Entity<VG2fwUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("v_g2fw_user", "fw_mif");

                entity.Property(e => e.ChineseNm)
                    .HasColumnType("character varying")
                    .HasColumnName("chinese_nm");

                entity.Property(e => e.ContactMail)
                    .HasColumnType("character varying")
                    .HasColumnName("contact_mail");

                entity.Property(e => e.DisabledDate).HasColumnName("disabled_date");

                entity.Property(e => e.EnglishNm)
                    .HasColumnType("character varying")
                    .HasColumnName("english_nm");

                entity.Property(e => e.FactNo)
                    .HasColumnType("character varying")
                    .HasColumnName("fact_no");

                entity.Property(e => e.ImAcct)
                    .HasColumnType("character varying")
                    .HasColumnName("im_acct");

                entity.Property(e => e.LoPosiNm)
                    .HasColumnType("character varying")
                    .HasColumnName("lo_posi_nm");

                entity.Property(e => e.LocalFactNo)
                    .HasColumnType("character varying")
                    .HasColumnName("local_fact_no");

                entity.Property(e => e.LocalPnlNm)
                    .HasColumnType("character varying")
                    .HasColumnName("local_pnl_nm");

                entity.Property(e => e.Pccuid).HasColumnName("pccuid");

                entity.Property(e => e.Sex)
                    .HasColumnType("character varying")
                    .HasColumnName("sex");

                entity.Property(e => e.SsoAcct)
                    .HasColumnType("character varying")
                    .HasColumnName("sso_acct");

                entity.Property(e => e.UpdateDate).HasColumnName("update_date");

                entity.Property(e => e.UpdateTime).HasColumnName("update_time");

                entity.Property(e => e.UpdateUser)
                    .HasColumnType("character varying")
                    .HasColumnName("update_user");

                entity.Property(e => e.UserDisable)
                    .HasColumnType("character varying")
                    .HasColumnName("user_disable");

                entity.Property(e => e.UserId)
                    .HasColumnType("character varying")
                    .HasColumnName("user_id");

                entity.Property(e => e.UserLang)
                    .HasColumnType("character varying")
                    .HasColumnName("user_lang");

                entity.Property(e => e.UserTimezone)
                    .HasColumnType("character varying")
                    .HasColumnName("user_timezone");
            });

            modelBuilder.Entity<VcolEname>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("vcol_ename", "ap_mif");

                entity.Property(e => e.ColEname)
                    .HasMaxLength(60)
                    .HasColumnName("col_ename");
            });

            modelBuilder.Entity<Version>(entity =>
            {
                entity.ToTable("version", "fw_mif");

                entity.Property(e => e.VersionId)
                    .HasPrecision(5)
                    .HasColumnName("version_id")
                    .HasComment("代碼 ");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name")
                    .HasComment("系統名稱");

                entity.Property(e => e.CreateTime)
                    .HasPrecision(19)
                    .HasColumnName("create_time")
                    .HasComment("建立時間");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("create_user")
                    .HasComment("建立人ID");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsLocked)
                    .HasMaxLength(1)
                    .HasColumnName("is_locked")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("Y:版本鎖定, 無法修改");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasComment("異動人ID");

                entity.Property(e => e.VersionDesc)
                    .HasMaxLength(200)
                    .HasColumnName("version_desc")
                    .HasComment("描述");

                entity.Property(e => e.VersionName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("version_name")
                    .HasComment("版本名稱");

                entity.Property(e => e.VersionScriptTime)
                    .HasPrecision(19)
                    .HasColumnName("version_script_time")
                    .HasComment("最近一次Script產生時間");

                entity.Property(e => e.VersionScriptZipFileId)
                    .HasMaxLength(22)
                    .HasColumnName("version_script_zip_file_id")
                    .HasComment("已產生的Scipt檔案代碼(套用FileModule)");
            });

            modelBuilder.Entity<VersionImportLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("version_import_log", "fw_mif");

                entity.Property(e => e.ApName)
                    .HasMaxLength(10)
                    .HasColumnName("ap_name")
                    .HasComment("底層: _PCG");

                entity.Property(e => e.ExecuteIpAddress)
                    .HasMaxLength(20)
                    .HasColumnName("execute_ip_address")
                    .HasComment("實際執行人使用的IP");

                entity.Property(e => e.ExecuteOsUser)
                    .HasMaxLength(50)
                    .HasColumnName("execute_os_user")
                    .HasComment("實際執行人使用的OS帳號");

                entity.Property(e => e.ExecuteSessionUser)
                    .HasMaxLength(20)
                    .HasColumnName("execute_session_user")
                    .HasComment("實際執行人使用的DB帳號");

                entity.Property(e => e.ExecuteTime)
                    .HasPrecision(19)
                    .HasColumnName("execute_time")
                    .HasComment("實際執行時間");

                entity.Property(e => e.Memo)
                    .HasMaxLength(100)
                    .HasColumnName("memo")
                    .HasComment("其他註記 (備用欄位)");

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .HasColumnName("type")
                    .HasComment("Log 類型 (START/END/...)");

                entity.Property(e => e.VersionId)
                    .HasPrecision(5)
                    .HasColumnName("version_id")
                    .HasComment("版本代碼");

                entity.Property(e => e.VersionName)
                    .HasMaxLength(50)
                    .HasColumnName("version_name")
                    .HasComment("版本名稱");

                entity.Property(e => e.VersionScriptDesc)
                    .HasMaxLength(1000)
                    .HasColumnName("version_script_desc")
                    .HasComment("語法描述");

                entity.Property(e => e.VersionScriptExecOrder)
                    .HasPrecision(5)
                    .HasColumnName("version_script_exec_order")
                    .HasComment("執行順序");

                entity.Property(e => e.VersionScriptTime)
                    .HasPrecision(19)
                    .HasColumnName("version_script_time")
                    .HasComment("Script File 產生時間");

                entity.Property(e => e.VersionScriptType)
                    .HasMaxLength(20)
                    .HasColumnName("version_script_type")
                    .HasComment("語法種類");
            });

            modelBuilder.Entity<VersionRemoveItem>(entity =>
            {
                entity.ToTable("version_remove_item", "fw_mif");

                entity.Property(e => e.VersionRemoveItemId)
                    .HasMaxLength(22)
                    .HasColumnName("version_remove_item_id")
                    .HasComment("刪除語法ID");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name")
                    .HasComment("系統代碼");

                entity.Property(e => e.CreateTime)
                    .HasPrecision(19)
                    .HasColumnName("create_time")
                    .HasComment("建立時間");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("create_user")
                    .HasComment("建立人ID");

                entity.Property(e => e.RemoveAtVersionId)
                    .HasPrecision(5)
                    .HasColumnName("remove_at_version_id")
                    .HasComment("處理版本號");

                entity.Property(e => e.RemoveByScript)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("remove_by_script")
                    .HasComment("完整刪除語法 (含where)");

                entity.Property(e => e.RemoveFromTableName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("remove_from_table_name")
                    .HasComment("刪除對象資料表");

                entity.HasOne(d => d.RemoveAtVersion)
                    .WithMany(p => p.VersionRemoveItems)
                    .HasForeignKey(d => d.RemoveAtVersionId)
                    .HasConstraintName("version_remove_item_fk1");
            });

            modelBuilder.Entity<VersionScript>(entity =>
            {
                entity.ToTable("version_script", "fw_mif");

                entity.HasIndex(e => new { e.VersionId, e.VersionScriptExecOrder }, "version_script_uk1")
                    .IsUnique();

                entity.Property(e => e.VersionScriptId)
                    .HasMaxLength(22)
                    .HasColumnName("version_script_id")
                    .HasComment("代碼");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name")
                    .HasComment("系統名稱");

                entity.Property(e => e.CreateTime)
                    .HasPrecision(19)
                    .HasColumnName("create_time")
                    .HasComment("建立時間");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("create_user")
                    .HasComment("建立人ID");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsAutoGen)
                    .HasMaxLength(1)
                    .HasColumnName("is_auto_gen")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("是否自動生成");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasComment("異動人ID");

                entity.Property(e => e.VersionId)
                    .HasPrecision(5)
                    .HasColumnName("version_id")
                    .HasComment("版本代碼");

                entity.Property(e => e.VersionScriptDesc)
                    .HasMaxLength(1000)
                    .HasColumnName("version_script_desc")
                    .HasComment("描述");

                entity.Property(e => e.VersionScriptExecOrder)
                    .HasPrecision(5)
                    .HasColumnName("version_script_exec_order")
                    .HasComment("執行順序");

                entity.Property(e => e.VersionScriptType)
                    .HasMaxLength(20)
                    .HasColumnName("version_script_type")
                    .HasComment("語法種類");

                entity.HasOne(d => d.Version)
                    .WithMany(p => p.VersionScripts)
                    .HasForeignKey(d => d.VersionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("version_script_fk1");
            });

            modelBuilder.Entity<VersionScriptDetail>(entity =>
            {
                entity.ToTable("version_script_detail", "fw_mif");

                entity.HasIndex(e => new { e.VersionScriptId, e.ExecOrder }, "version_script_detail_uk1")
                    .IsUnique();

                entity.Property(e => e.VersionScriptDetailId)
                    .HasMaxLength(22)
                    .HasColumnName("version_script_detail_id")
                    .HasComment("代碼");

                entity.Property(e => e.CreateTime)
                    .HasPrecision(19)
                    .HasColumnName("create_time")
                    .HasComment("建立時間");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("create_user")
                    .HasComment("建立人ID");

                entity.Property(e => e.ExecOrder)
                    .HasPrecision(5)
                    .HasColumnName("exec_order")
                    .HasComment("執行順序");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsAutoGen)
                    .HasMaxLength(1)
                    .HasColumnName("is_auto_gen")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("是否系統自動生成");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasComment("異動人ID");

                entity.Property(e => e.UpgradeSql)
                    .IsRequired()
                    .HasColumnName("upgrade_sql")
                    .HasComment("DB更新語法");

                entity.Property(e => e.VersionScriptId)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("version_script_id")
                    .HasComment("版本升級語法代碼");

                entity.HasOne(d => d.VersionScript)
                    .WithMany(p => p.VersionScriptDetails)
                    .HasForeignKey(d => d.VersionScriptId)
                    .HasConstraintName("version_script_detail_fk1");
            });

            modelBuilder.Entity<VersionTable>(entity =>
            {
                entity.HasKey(e => e.VersionTableName)
                    .HasName("version_table_pk");

                entity.ToTable("version_table", "fw_mif");

                entity.Property(e => e.VersionTableName)
                    .HasMaxLength(30)
                    .HasColumnName("version_table_name")
                    .HasComment("版控表格名稱");

                entity.Property(e => e.ApAllow)
                    .HasMaxLength(1)
                    .HasColumnName("ap_allow")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許AP發佈用");

                entity.Property(e => e.ApName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ap_name")
                    .HasComment("系統名稱");

                entity.Property(e => e.CreateTime)
                    .HasPrecision(19)
                    .HasColumnName("create_time")
                    .HasComment("建立時間");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("create_user")
                    .HasComment("建立人ID");

                entity.Property(e => e.IsAllowDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("允許發佈");

                entity.Property(e => e.IsAllowModify)
                    .HasMaxLength(1)
                    .HasColumnName("is_allow_modify")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("允許修改");

                entity.Property(e => e.IsEnabled)
                    .HasMaxLength(1)
                    .HasColumnName("is_enabled")
                    .HasDefaultValueSql("'Y'::bpchar")
                    .HasComment("是否啟用 (N: 停用, 產生版本script時略過該Table)");

                entity.Property(e => e.IsPassDeploy)
                    .HasMaxLength(1)
                    .HasColumnName("is_pass_deploy")
                    .HasDefaultValueSql("'N'::bpchar")
                    .HasComment("暫停發佈");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(19)
                    .HasColumnName("update_time")
                    .HasComment("異動時間");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(22)
                    .HasColumnName("update_user")
                    .HasComment("異動人ID");

                entity.Property(e => e.VersionTableExecutionOrder)
                    .HasPrecision(5)
                    .HasColumnName("version_table_execution_order")
                    .HasComment("版控執行順序");

                entity.Property(e => e.VersionTablePkName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("version_table_pk_name")
                    .HasComment("版控表格主鍵名稱 (多主鍵則用逗點分隔)");
            });

            modelBuilder.Entity<ViewOdrSumQss2>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("view_odr_sum_qss_2", "ap_mif");

                entity.Property(e => e.ArticNo)
                    .HasMaxLength(40)
                    .HasColumnName("artic_no");

                entity.Property(e => e.BqDate)
                    .HasMaxLength(8)
                    .HasColumnName("bq_date");

                entity.Property(e => e.ColorNo)
                    .HasMaxLength(20)
                    .HasColumnName("color_no");

                entity.Property(e => e.CpOutDate)
                    .HasMaxLength(8)
                    .HasColumnName("cp_out_date");

                entity.Property(e => e.CustNm)
                    .HasMaxLength(50)
                    .HasColumnName("cust_nm");

                entity.Property(e => e.CustNo)
                    .HasMaxLength(10)
                    .HasColumnName("cust_no");

                entity.Property(e => e.DemoNo)
                    .HasMaxLength(40)
                    .HasColumnName("demo_no");

                entity.Property(e => e.FactNo)
                    .HasMaxLength(4)
                    .HasColumnName("fact_no");

                entity.Property(e => e.InQty)
                    .HasPrecision(10, 1)
                    .HasColumnName("in_qty");

                entity.Property(e => e.OdrNo)
                    .HasMaxLength(40)
                    .HasColumnName("odr_no");

                entity.Property(e => e.PartNo)
                    .HasMaxLength(10)
                    .HasColumnName("part_no");

                entity.Property(e => e.ProductType)
                    .HasMaxLength(10)
                    .HasColumnName("product_type");

                entity.Property(e => e.QsOutQty)
                    .HasPrecision(10, 1)
                    .HasColumnName("qs_out_qty");

                entity.Property(e => e.QsQty)
                    .HasPrecision(10, 1)
                    .HasColumnName("qs_qty");

                entity.Property(e => e.StyleNo)
                    .HasMaxLength(60)
                    .HasColumnName("style_no");

                entity.Property(e => e.TotalQty)
                    .HasPrecision(10, 1)
                    .HasColumnName("total_qty");

                entity.Property(e => e.TypeNo)
                    .HasMaxLength(1)
                    .HasColumnName("type_no");

                entity.Property(e => e.WorkType)
                    .HasMaxLength(1)
                    .HasColumnName("work_type");

                entity.Property(e => e.Yymm)
                    .HasMaxLength(6)
                    .HasColumnName("yymm");
            });

            modelBuilder.Entity<WoTest>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("wo_test", "ap_mif");

                entity.Property(e => e.CreateTime)
                    .HasMaxLength(8)
                    .HasColumnName("create_time");

                entity.Property(e => e.Meint)
                    .HasMaxLength(3)
                    .HasColumnName("meint");

                entity.Property(e => e.Qty)
                    .HasMaxLength(15)
                    .HasColumnName("qty");

                entity.Property(e => e.Wo)
                    .HasMaxLength(12)
                    .HasColumnName("wo");
            });

            modelBuilder.Entity<Workm>(entity =>
            {
                entity.HasKey(e => new { e.Facility, e.Workno, e.Workseq, e.Aufnr })
                    .HasName("pk_workm");

                entity.ToTable("workm", "ap_mif");

                entity.Property(e => e.Facility)
                    .HasMaxLength(256)
                    .HasColumnName("facility");

                entity.Property(e => e.Workno)
                    .HasMaxLength(20)
                    .HasColumnName("workno");

                entity.Property(e => e.Workseq)
                    .HasMaxLength(20)
                    .HasColumnName("workseq");

                entity.Property(e => e.Aufnr)
                    .HasMaxLength(20)
                    .HasColumnName("aufnr");

                entity.Property(e => e.CreateName)
                    .HasPrecision(20)
                    .HasColumnName("create_name");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Gamng)
                    .HasPrecision(18, 8)
                    .HasColumnName("gamng");

                entity.Property(e => e.ModifyName)
                    .HasPrecision(20)
                    .HasColumnName("modify_name");

                entity.Property(e => e.ModifyTime)
                    .HasColumnName("modify_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Plnbez)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("plnbez");

                entity.Property(e => e.Shift)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("shift");

                entity.Property(e => e.Workdate)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("workdate")
                    .IsFixedLength(true);

                entity.Property(e => e.Wosize)
                    .HasMaxLength(50)
                    .HasColumnName("wosize");
            });

            modelBuilder.Entity<Xmldatum>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("xmldata", "ap_mif");

                entity.Property(e => e.Data)
                    .HasColumnType("xml")
                    .HasColumnName("data");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
