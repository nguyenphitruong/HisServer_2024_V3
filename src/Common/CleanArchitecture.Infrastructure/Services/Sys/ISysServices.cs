using Emr.Domain.Model.Sys;
using Emr.Domain.Model.Sys.Accounts;
using Emr.Domain.Model.Sys.Modules;
using Emr.Domain.Model.Sys.PrintTemplates;
using Emr.Domain.Model.Sys.StructureData;
using Emr.Domain.ReadModel.Sys;
using Emr.Domain.ReadModel.Sys.Api;
using Emr.Domain.ReadModel.Sys.Config;
using Emr.Domain.ReadModel.Sys.Modules;
using Emr.Domain.ReadModel.Sys.PrintTemplates;
using System.Collections.Generic;

namespace Emr.Infrastructure.Services.Sys
{
    public interface ISysServices
    {
        #region sysAccounts
        List<SysAccountModel> GetAccount();

        SysAccountReadModel Update(string i_Code);

        InfoReturnAfterLoginModel Login(int i_Siterf, string i_Username, string i_Password);

        List<SysModuleModel> GetMenuByUsernameAndAppName(int i_Siterf, string i_UserName, string i_TypeUserCode, string i_AppName);
        #endregion

        #region sysApi
        List<SysApiConfigReadModel> GetApiAll(int i_Offset, int i_Limmit);
        #endregion

        #region SysPrintTemplates

        List<SysPrintTemplateReadModel> GetPrintTemplatebySiterf(int i_Siterf, int i_Offset, int i_Limit);

        SysPrintTemplateReadModel GetPrintTemplatebyId(int i_Siterf, int i_Id);

        SysPrintTemplateReadModel GetPrintTemplatebyCode(int i_Siterf, string code);


        SysPrintTemplateReadModel CreatePrintTemplate(int i_Siterf, SysPrintTemplateModel i_SysPrintTemplate);
        SysPrintTemplateReadModel UpdatePrintTemplate(int i_Siterf, SysPrintTemplateModel i_SysPrintTemplate);


        bool DeletePrintTemplate(int i_Siterf, int i_Id);


        #endregion

        #region sysconfig
        List<SysconfigReadModel> GetSysConfigByCode(int i_Siterf, string i_Code);
        #endregion 

        sysStructureDataReadModel CreateStructureDataNew(string i_mmyy);
    }
}
