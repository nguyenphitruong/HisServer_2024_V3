using Emr.Domain.Entities.Cate;
using Emr.Domain.Entities.Cate.Hospital;
using Emr.Domain.Entities.Cate.Icd10;
using Emr.Domain.Entities.Cate.Medexa;
using Emr.Domain.Entities.Emr.ServiceOrder;
using Emr.Domain.Entities.Pay.Services;
using Emr.Domain.Entities.Pha;
using Emr.Domain.Entities.Share.Patient;
using Emr.Domain.Entities.Sys;
using Emr.Domain.Entities.Sys.Api;
using Emr.Domain.Entities.Sys.Config;
using Emr.Domain.Entities.Sys.Menus;
using Emr.Domain.Entities.Sys.Module;
using Emr.Domain.Entities.Sys.Modules;
using Emr.Domain.Entities.Sys.PrintTemplates;
using Emr.Domain.Entities.Sys.Tables;
using Emr.Domain.Entities.Sys.Views;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Emr.Infrastructure.Persistence
{
    public class MyDbShareContext : DbContext
    {
        public MyDbShareContext(DbContextOptions<MyDbShareContext> options)
        : base(options)
        {

        }
        //Patient----------
        public virtual DbSet<EMR_patient> EMR_patients { get; set; }
        public virtual DbSet<EMR_patienthi> EMR_patienthis { get; set; }
        public virtual DbSet<emrpatientsurvival> emrpatientsurvivals { get; set; }
        public virtual DbSet<emrpatientelation> emrpatientelations { get; set; }
        //End Patient -----

        //cate--------------
        public virtual DbSet<CATE_shareh> CATE_sharehs { get; set; }
        public virtual DbSet<CATE_sharel> CATE_sharels { get; set; }
        public virtual DbSet<cadepartment> cadepartments { get; set; }
        public virtual DbSet<camedexah> camedexahs { get; set; }
        public virtual DbSet<camedexal> camedexals { get; set; }
        public virtual DbSet<emrservicesorder> emrservicesorders { get; set; }
        public virtual DbSet<emrdrugsorder> emrdrugsorders { get; set; }
        public virtual DbSet<CATE_icd10> CATE_icd10s { get; set; }
        public virtual DbSet<CATE_hospital> CATE_hospitals { get; set; }

        //----Sevices--------
        public virtual DbSet<CATE_groupservices> CATE_groupservicess { get; set; }
        public virtual DbSet<CATE_cateservices> CATE_cateservicess { get; set; }
        public virtual DbSet<CATE_priceservices> CATE_priceservicess { get; set; }
        //---End--------------
        //---Sys---
        public virtual DbSet<CaShareGetCode> CaShareGetCodes { get; set; }
        public virtual DbSet<sysaccount> sysAccounts { get; set; }
        public virtual DbSet<sysService> sysServices { get; set; }
        public virtual DbSet<sysserver> sysServers { get; set; }
        public virtual DbSet<sysapi> sysapis { get; set; }
        public virtual DbSet<sysmodule> sysmodules { get; set; }
        public virtual DbSet<sysmenu> sysmenus { get; set; }
        public virtual DbSet<sysview> sysviews { get; set; }
        public virtual DbSet<configclinicqueue> configclinicqueues { get; set; }
        public virtual DbSet<sysprinttemplate> sysprinttemplates { get; set; }
        public virtual DbSet<tbltest> tbltests { get; set; }
        public virtual DbSet<sysschema> sysschemas { get; set; }
        public virtual DbSet<SYS_config> SYS_configs { get; set; }
        public virtual DbSet<SYS_configslipexam> SYS_configslipexams { get; set; }
        public virtual DbSet<systable> systables { get; set; }
        public virtual DbSet<PHA_inventoryl> PHA_inventoryl { get; set; }

        public virtual DbSet<SYS_module> SYS_modules { get; set; }
        public virtual DbSet<SYS_menu> SYS_menus { get; set; }
        public virtual DbSet<SYS_noseriline> SYS_noserilines { get; set; }

        //---End-----

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
