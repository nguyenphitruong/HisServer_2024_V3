using Emr.Domain.Model.Sys.Accounts;
using Emr.Domain.Model.Sys.Api;
using Emr.Domain.Model.Sys.Modules;
using Emr.Domain.Model.Sys.PrintTemplates;
using Emr.Domain.Model.Sys.StructureData;
using Emr.Domain.ReadModel.Sys;
using Emr.Domain.ReadModel.Sys.Api;
using Emr.Domain.ReadModel.Sys.Config;
using Emr.Domain.ReadModel.Sys.PrintTemplates;
using System.Collections.Generic;

namespace Emr.Domain.Model.Sys
{
    public interface ISysRepository
    {
        #region sysAccounts
        List<SysAccountModel> GetAccount();
        List<SysServerModel> GetServices();
        SysAccountReadModel Update(string i_code);
        InfoReturnAfterLoginModel Login(int i_Siterf, string username, string password);
        //InfoReturnAfterLoginModel LoginHash(int i_Siterf, string i_Username, string i_Password);

        List<SysModuleModel> GetMenuByUsernameAndAppName(int i_Siterf, string i_UserName, string i_TypeUserCode, string i_AppName);
        #endregion
        #region sysApi
        List<SysApiConfigReadModel> GetApiAll(int i_Offset, int i_Limit);
        #endregion

        #region SysPrintTemplates

        List<SysPrintTemplateReadModel> GetPrintTemplatebySiterf(int i_Siterf, int i_Offset, int i_Limit);

        SysPrintTemplateReadModel GetPrintTemplatebyId(int i_Siterf, int i_Id);

        SysPrintTemplateReadModel GetPrintTemplatebyCode(int i_Siterf, string code);

        string CreatePrintTemplate(int i_Siterf, SysPrintTemplateModel i_SysPrintTemplateModel);


        string UpdatePrintTemplate(int i_Siterf, SysPrintTemplateModel i_SysPrintTemplateModel);


        bool DeletePrintTemplate(int i_Siterf, int i_Id);


        #endregion
        #region sysconfig
        List<SysconfigReadModel> GetSysConfigByCode(int i_Siterf, string i_Code);
        #endregion
        sysStructureDataReadModel CreateStructureDataNew(string i_mmyy);

    }
}
