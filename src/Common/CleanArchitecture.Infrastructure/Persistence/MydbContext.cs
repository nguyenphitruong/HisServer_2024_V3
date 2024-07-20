using Emr.Domain.Entities.Cate;
using Emr.Domain.Entities.Cate.Hospital;
using Emr.Domain.Entities.Cate.Icd10;
using Emr.Domain.Entities.Cate.Medexa;
using Emr.Domain.Entities.Emr;
using Emr.Domain.Entities.Emr.Outclinic;
using Emr.Domain.Entities.Emr.Registers;
using Emr.Domain.Entities.Emr.ServiceOrder;
using Emr.Domain.Entities.General;
using Emr.Domain.Entities.Pay;
using Emr.Domain.Entities.Pay.Services;
using Emr.Domain.Entities.Pha;
using Emr.Domain.Entities.Sys;
using Emr.Domain.Entities.Sys.Api;
using Emr.Domain.Entities.Sys.Config;
using Emr.Domain.Entities.Sys.Menus;
using Emr.Domain.Entities.Sys.Module;
using Emr.Domain.Entities.Sys.PrintTemplates;
using Emr.Domain.Entities.Sys.Views;
using Emr.Infrastructure.Hepper.Provider;
using Emr.Infrastructure.Persistence.SchemaChange;
using Microsoft.EntityFrameworkCore;

namespace Emr.Infrastructure.Persistence
{
    public class MydbContext : DbContext
    {
        public readonly ConnectionStrings connectionStrings;
        public readonly SchemaCurent schemaCurent;
        public MydbContext(DbContextOptions<MydbContext> options, ConnectionStrings i_connectionStrings, SchemaCurent i_schemaCurent) : base(options)
        {
            schemaCurent = i_schemaCurent;
            connectionStrings = i_connectionStrings;    
        }

        //---Register
        public virtual DbSet<emrregister> emrregisters { get; set; }
        public virtual DbSet<emrregisterhi> emrregisterhis { get; set; }
        public virtual DbSet<emrclinicqueue> emrclinicqueues { get; set; }
        public virtual DbSet<emroutclinic> emroutclinics { get; set; }
        public virtual DbSet<EMR_medioutclinic> EMR_medioutclinics { get; set; }
        //---End-----
        //----Sevices--------
        public virtual DbSet<CATE_groupservices> CATE_groupservicess { get; set; }
        public virtual DbSet<CATE_cateservices> CATE_cateservicess { get; set; }
        public virtual DbSet<CATE_priceservices> CATE_priceservicess { get; set; }
        //---End--------------

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

        //---PHA----------
        public virtual DbSet<phainventoryh> phainventoryhs { get; set; }
        public virtual DbSet<phainventoryl> phainventoryls { get; set; }
        //----------------

        public virtual DbSet<PayService> PayServices { get; set; }

        public virtual DbSet<PayMentH> PayMentHs { get; set; }
        public virtual DbSet<PayMentL> PayMentLs { get; set; }

        //---Sys---
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
        //---End-----

        //Create 09012024 => GeneralInfo---------
        public virtual DbSet<EMR_departtranfer> EMR_departtranfer { get; set; }
        public virtual DbSet<EMR_drugorder> EMR_drugorder { get; set; }
        public virtual DbSet<EMR_happenning> EMR_happenning { get; set; }
        public virtual DbSet<EMR_medicalrecord> EMR_medicalrecord { get; set; }
        public virtual DbSet<EMR_serviceorder> EMR_serviceorder { get; set; }
        public virtual DbSet<PAY_paymenth> PAY_paymenth { get; set; }
        public virtual DbSet<PAY_paymentl> PAY_paymentl { get; set; }

        public virtual DbSet<PHA_cateaction> PHA_cateaction { get; set; }
        public virtual DbSet<PHA_catepermission> PHA_catepermission { get; set; }
        public virtual DbSet<PHA_cateprocess> PHA_cateprocess { get; set; }
        public virtual DbSet<PHA_caterolepermission> PHA_caterolepermission { get; set; }
        public virtual DbSet<PHA_catestore> PHA_catestore { get; set; }
        public virtual DbSet<PHA_cfaction> PHA_cfaction { get; set; }
        public virtual DbSet<PHA_cfpermission> PHA_cfpermission { get; set; }
        public virtual DbSet<PHA_cfprocess> PHA_cfprocess { get; set; }
        public virtual DbSet<PHA_cfstorebydepart> PHA_cfstorebydepart { get; set; }
        public virtual DbSet<PHA_cfuserpermission> PHA_cfuserpermission { get; set; }
        public virtual DbSet<PHA_drugitem> PHA_drugitem { get; set; }
        public virtual DbSet<PHA_flstoreexport> PHA_flstoreexport { get; set; }
        public virtual DbSet<PHA_flstoreimport> PHA_flstoreimport { get; set; }
        public virtual DbSet<PHA_follow> PHA_follow { get; set; }
        public virtual DbSet<PHA_inventorytransaction> PHA_inventorytransaction { get; set; }
        public virtual DbSet<PHA_invoiceinput> PHA_invoiceinput { get; set; }
        public virtual DbSet<PHA_prescriptionh> PHA_prescriptionh { get; set; }
        public virtual DbSet<PHA_prescriptionl> PHA_prescriptionl { get; set; }
        public virtual DbSet<PHA_pricedrugbidl> PHA_pricedrugbidl { get; set; }
        public virtual DbSet<PHA_pricedrugh> PHA_pricedrugh { get; set; }
        public virtual DbSet<PHA_pricedrugl> PHA_pricedrugl { get; set; }
        public virtual DbSet<PHA_storeexporth> PHA_storeexporth { get; set; }
        public virtual DbSet<PHA_storeexportl> PHA_storeexportl { get; set; }
        public virtual DbSet<PHA_storeimporth> PHA_storeimporth { get; set; }
        public virtual DbSet<PHA_storeimportl> PHA_storeimportl { get; set; }
        public virtual DbSet<PHA_inventoryh> PHA_inventoryh { get; set; }
        public virtual DbSet<PHA_inventoryl> PHA_inventoryl { get; set; }
        public virtual DbSet<PHA_fltemp> PHA_fltemps { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema(string.IsNullOrEmpty(schemaCurent.Name) ? "dbo" : schemaCurent.Name);
            base.OnModelCreating(builder);
        }
    }
}
