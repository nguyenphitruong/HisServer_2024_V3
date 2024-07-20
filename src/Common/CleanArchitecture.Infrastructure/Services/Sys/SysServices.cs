using Emr.Domain.Entities.Sys.Tables;
using Emr.Domain.Model.Sys;
using Emr.Domain.Model.Sys.Accounts;
using Emr.Domain.Model.Sys.Modules;
using Emr.Domain.Model.Sys.PrintTemplates;
using Emr.Domain.Model.Sys.StructureData;
using Emr.Domain.ReadModel.Sys;
using Emr.Domain.ReadModel.Sys.Api;
using Emr.Domain.ReadModel.Sys.Config;
using Emr.Domain.ReadModel.Sys.PrintTemplates;
using Emr.Infrastructure.UniOfWork;
using System;
using System.Collections.Generic;

namespace Emr.Infrastructure.Services.Sys
{
    public class SysServices : ISysServices
    {
        private IUnitOfWorkShare unitOfWork;
        public SysServices(IUnitOfWorkShare i_UnitOfWork)
        {
            unitOfWork = i_UnitOfWork;
        }

        #region sysAccount
        public List<SysAccountModel> GetAccount()
        {
            try
            {
                return unitOfWork.SysRepository.GetAccount();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SysAccountReadModel Update(string i_Code)
        {
            SysAccountReadModel result = new SysAccountReadModel();
            try
            {
                unitOfWork.InitTransaction();
                try
                {
                    result = unitOfWork.SysRepository.Update(i_Code);
                    unitOfWork.Save();
                    unitOfWork.CommitTransaction();
                    return result;
                }
                catch (Exception ex)
                {
                    unitOfWork.RollbackTransaction();
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public InfoReturnAfterLoginModel Login(int i_Siterf, string i_Username, string i_Password)
        {
            try
            {
                return unitOfWork.SysRepository.Login(i_Siterf, i_Username, i_Password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SysModuleModel> GetMenuByUsernameAndAppName(int i_Siterf, string i_UserName, string i_TypeUserCode, string i_AppName)
        {
            try
            {
                return unitOfWork.SysRepository.GetMenuByUsernameAndAppName(i_Siterf, i_UserName, i_TypeUserCode, i_AppName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region sysApi
        public List<SysApiConfigReadModel> GetApiAll(int i_Offset, int i_Limmit)
        {
            try
            {
                return unitOfWork.SysRepository.GetApiAll(i_Offset, i_Limmit);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region SysPrintTemplates
        public List<SysPrintTemplateReadModel> GetPrintTemplatebySiterf(int i_Siterf, int i_Offset, int i_Limmit)
        {
            try
            {
                return unitOfWork.SysRepository.GetPrintTemplatebySiterf(i_Siterf, i_Offset, i_Limmit);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SysPrintTemplateReadModel GetPrintTemplatebyId(int i_Siterf, int i_Id)
        {
            try
            {
                return unitOfWork.SysRepository.GetPrintTemplatebyId(i_Siterf, i_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SysPrintTemplateReadModel GetPrintTemplatebyCode(int i_Siterf, string code)
        {
            try
            {
                return unitOfWork.SysRepository.GetPrintTemplatebyCode(i_Siterf, code);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SysPrintTemplateReadModel CreatePrintTemplate(int i_Siterf, SysPrintTemplateModel i_SysPrintTemplate)
        {
            try
            {
                //var SysPrintTemplate = _mapper.MapSysPrintTemplateDTOToModel(i_Siterf, i_SysPrintTemplate);
                unitOfWork.InitTransaction();
                var code = unitOfWork.SysRepository.CreatePrintTemplate(i_Siterf, i_SysPrintTemplate);
                unitOfWork.Save();
                unitOfWork.CommitTransaction();
                return GetPrintTemplatebyCode(i_Siterf, code);
            }
            catch (Exception ex)
            {
                unitOfWork.RollbackTransaction();
                throw ex;
            }
        }

        public SysPrintTemplateReadModel UpdatePrintTemplate(int i_Siterf, SysPrintTemplateModel i_SysPrintTemplate)
        {
            try
            {
                //var SysPrintTemplate = _mapper.MapSysPrintTemplateDTOToModel(i_Siterf, i_SysPrintTemplate);
                unitOfWork.InitTransaction();
                string code = unitOfWork.SysRepository.UpdatePrintTemplate(i_Siterf, i_SysPrintTemplate);
                unitOfWork.Save();
                unitOfWork.CommitTransaction();
                return GetPrintTemplatebyCode(i_Siterf, code);
            }
            catch (Exception ex)
            {
                unitOfWork.RollbackTransaction();
                throw ex;
            }
        }

        public bool DeletePrintTemplate(int i_Siterf, int i_IdLine)
        {
            try
            {
                unitOfWork.InitTransaction();
                var result = unitOfWork.SysRepository.DeletePrintTemplate(i_Siterf, i_IdLine);
                unitOfWork.Save();
                unitOfWork.CommitTransaction();
                return result;
            }
            catch (Exception ex)
            {
                unitOfWork.RollbackTransaction();
                throw ex;
            }
        }
        #endregion

        #region sysconfig
        public List<SysconfigReadModel> GetSysConfigByCode(int i_Siterf, string i_Code)
        {
            try
            {
                return unitOfWork.SysRepository.GetSysConfigByCode(i_Siterf, i_Code);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region SYSStructureData
        public sysStructureDataReadModel CreateStructureDataNew(string i_mmyy)
        {
            try
            {
                return unitOfWork.SysRepository.CreateStructureDataNew(i_mmyy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
