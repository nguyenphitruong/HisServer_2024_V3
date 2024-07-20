using Emr.Domain.Entities.Sys;
using Emr.Domain.Entities.Sys.Api;
using Emr.Domain.Entities.Sys.Config;
using Emr.Domain.Entities.Sys.PrintTemplates;
using Emr.Domain.Entities.Sys.Tables;
using Emr.Domain.Entities.Sys.Views;
using Emr.Domain.Model.Sys;
using Emr.Domain.Model.Sys.Accounts;
using Emr.Domain.Model.Sys.Api;
using Emr.Domain.Model.Sys.Menu;
using Emr.Domain.Model.Sys.Modules;
using Emr.Domain.Model.Sys.PrintTemplates;
using Emr.Domain.Model.Sys.StructureData;
using Emr.Domain.ReadModel.Sys;
using Emr.Domain.ReadModel.Sys.Api;
using Emr.Domain.ReadModel.Sys.Config;
using Emr.Domain.ReadModel.Sys.Menu;
using Emr.Domain.ReadModel.Sys.PrintTemplates;
using Emr.Infrastructure.Hepper.Exceptions;
using Emr.Infrastructure.Hepper.Lib;
using Emr.Infrastructure.Persistence;
using Emr.Infrastructure.RepoMapper.Sys;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emr.Infrastructure.Repositories.Sys
{
    public class SysRepository : ISysRepository
    {
        //CaGetCodeRepository caRepo;
        //private RegistryEntityMapper _mapper;
        SysRepoMapper mapper;
        private MyDbShareContext dbContext;
        //private MydbContext dbContext_share;
        public SysRepository(MyDbShareContext i_Context)
        {
            dbContext = i_Context;
            mapper = new SysRepoMapper();
        }

        #region SysAccount
        //public bool SaveAccount()
        //{
        //    List<SysAccountModel> _lstResult = new List<SysAccountModel>();

        //    var TaskSave = Task.Run(() => GetAsyncAccount(""));
        //    TaskSave.Wait();
        //    var  result = TaskSave.Result;
        //    //return result;

        //    //   var aa = dbContext.CaPayPriceServices.ToList();

        //    var _lstResult1 = dbContext.sysAccounts.ToList();


        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return result;
        //}



        public List<SysAccountModel> GetAccount()
        {
            List<SysAccountModel> _lstResult = new List<SysAccountModel>();



            //   var aa = dbContext.CaPayPriceServices.ToList();

            var _lstResult1 = dbContext.sysAccounts.ToList();


            try
            {
                _lstResult = dbContext.sysAccounts
                    .Select(a => new SysAccountModel
                    {
                        //codeUser = a.codeUser,
                        //userName = a.userName,
                        //passWord = a.passWord,
                        //fullName = a.fullName,
                        //codeDep = a.codeDep,
                        //codeEmp = a.codeEmp,
                        //codePer = a.codePer,
                        //active = a.active,
                    }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _lstResult;
        }

        //public SysAccountReadModel Save(SysAccountModel i_AccountModel)
        //{
        //    SysAccountReadModel accountReadModel = new SysAccountReadModel();

        //    if (CheckAccount(i_AccountModel))
        //    {
        //        // Lấy dữ liệu id  max
        //        int? idmax = dbContext.sysAccounts.Max(x => (int?)x.idline);
        //        if (idmax != null) { idmax++; } else { idmax = 1; }
        //        //Mã hóa Pass
        //        string PassEnCode = Encrypt(i_AccountModel.password);
        //        // Khởi tạo Entity
        //        sysaccount _sysaccount = mapper.MapperSysAccount(i_AccountModel, idmax, PassEnCode);
        //        List<sysaccount> _lstsysaccount = new List<sysaccount>();
        //        _lstsysaccount.Add(_sysaccount);
        //        using (var transaction = dbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
        //        {
        //            try
        //            {
        //                // Lưu company
        //                dbContext.BulkMerge(_lstsysaccount);
        //                dbContext.BulkSaveChanges();
        //                transaction.Commit(); // Commit;
        //            }
        //            catch (Exception ex)
        //            {
        //                transaction.Rollback();// Rollback nếu lỗi
        //                throw ex;
        //            }
        //        }
        //        // accountReadModel = Get(_sysaccount.siterf, _sysaccount.idline).FirstOrDefault();

        //        var TaskSave = Task.Run(() => GetAsyncAccount(_sysaccount));
        //        TaskSave.Wait();
        //        accountReadModel = TaskSave.Result;
        //    }

        //    return accountReadModel;
        //}

        public SysAccountReadModel Update(string i_code)
        {
            SysAccountReadModel accountReadModel = new SysAccountReadModel();

            var resultCheck = dbContext.sysAccounts.AsNoTracking()
                .Where(x => x.usercode == i_code).ToList();

            var TaskSave = Task.Run(() => GetAsyncAccount(i_code));
            TaskSave.Wait();
            accountReadModel = TaskSave.Result;


            if (resultCheck.Count > 0)
            {
                resultCheck.ForEach(x => x.username = "noasy");

                dbContext.BulkUpdate(resultCheck);

                accountReadModel.userName = resultCheck[0].username;
            }

            return accountReadModel;


        }

        public async Task<SysAccountReadModel> GetAsyncAccount(string i_code)
        {
            //   List<SysAccountReadModel> lstResult = new List<SysAccountReadModel>();
            SysAccountReadModel Result = new SysAccountReadModel();
            //try
            //{
            //    dbContext_share = new MydbContext();
            //    SysAccountReadModel accountReadModel = new SysAccountReadModel();


            //    var resultCheck = dbContext_share.sysAccounts.AsNoTracking()
            //        .Where(x => x.usercode == i_code).ToList();


            //    if (resultCheck.Count > 0)
            //    {
            //        resultCheck.ForEach(x => x.username = "asy");

            //        using (var transaction = dbContext_share.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
            //        {
            //            try
            //            {
            //                // Lưu company
            //                dbContext_share.BulkUpdate(resultCheck);
            //                dbContext_share.BulkSaveChanges();
            //                transaction.Commit(); // Commit;
            //            }
            //            catch (Exception ex)
            //            {
            //                transaction.Rollback();// Rollback nếu lỗi
            //                throw ex;
            //            }
            //            accountReadModel.codeUser = resultCheck[0].usercode;
            //            accountReadModel.userName = resultCheck[0].username;
            //        }
            //    }
            //    return accountReadModel;


            //    //Result = (from a in dbContext.sysAccounts.AsNoTracking().Where(x => x.active == 1 && x.usercode == i_Code)
            //    //          //join b in dbContext.sysusers.AsNoTracking().Where(x => x.siterf == i_Siterf && x.active == 1) on a.codeuser equals b.code
            //    //      orderby a.username
            //    //      select new SysAccountReadModel
            //    //      {
            //    //          codeUser = a.usercode,
            //    //          fullName = a.fullname,
            //    //          userName = a.username
            //    //      }).FirstOrDefault();

            //    //  lstResult.Add(lst);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            return Result;
        }

        public InfoReturnAfterLoginModel Login(int i_Siterf, string username, string password)
        {
            try
            {
                var account = dbContext.sysAccounts.AsNoTracking().Where(x => x.siterf == 1 && x.active == 1 && x.username == username && x.password == password && x.status == 1).FirstOrDefault();

                if (account != null)
                {
                    InfoReturnAfterLoginModel infoReturn = (from acc in dbContext.sysAccounts.AsNoTracking().Where(x => x.siterf == 1 && x.active == 1 && x.username == username && x.password == password)
                                                                //join u in dbContext.sysusers.AsNoTracking().Where(x => x.siterf == i_Siterf && x.active == 1) on acc.codeuser equals u.code
                                                            select new InfoReturnAfterLoginModel
                                                            {
                                                                //userId = u.idline, /*Id người dùng*/
                                                                userCode = acc.usercode, /*Mã người dùng*/
                                                                userName = acc.username,
                                                                userFullname = acc.fullname, /*Họ tên người dùng*/
                                                                //userGenderID = u.idgender, /*id gender, id giới tính, bảng catesharel, code: gender*/
                                                                //typeUserId = u.idtypeuser, /*id typeuser, id loại user, bảng catesharel, code: typeuser*/
                                                                //userMedexahId = u.idmedexah, /*id chuyên khoa, nhân viên thuộc khoa phòng nào*/
                                                                token = ""
                                                            }
                             ).FirstOrDefault();
                    return infoReturn;
                }
                else
                    throw new LogicException("Login fail");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public InfoReturnAfterLoginModel LoginHash(int i_Siterf, string i_Username, string i_Password)
        //{
        //    try
        //    {
        //        using (var dbContextReadOnly = new MydbContext())
        //        {
        //            sysaccount account = dbContextReadOnly.sysAccounts.AsNoTracking().Where(x => x.siterf == i_Siterf && x.active == 1 && x.username == i_Username && x.status == 1).FirstOrDefault();

        //            if (account != null)
        //            {
        //                if (CheckPasswordHash(i_Password, account) == true)
        //                {


        //                    InfoReturnAfterLoginModel infoReturn = (from u in dbContextReadOnly.sysusers.AsNoTracking().Where(x => x.siterf == i_Siterf && x.active == 1)
        //                                                            join catel in dbContextReadOnly.catesharels.AsNoTracking().Where(x => x.siterf == i_Siterf && x.active == 1) on u.idtypeuser equals catel.idline
        //                                                            where u.code == account.codeuser
        //                                                            select new InfoReturnAfterLoginModel
        //                                                            {
        //                                                                userId = u.idline, /*Id người dùng*/
        //                                                                userCode = u.code, /*Mã người dùng*/
        //                                                                userName = account.username,
        //                                                                userFullname = u.fullname, /*Họ tên người dùng*/
        //                                                                userGenderID = u.idgender, /*id gender, id giới tính, bảng catesharel, code: gender*/
        //                                                                typeUserId = u.idtypeuser, /*id typeuser, id loại user, bảng catesharel, code: typeuser*/
        //                                                                typeUserCode = catel.codeline,
        //                                                                userMedexahId = u.idmedexah /*id chuyên khoa, nhân viên thuộc khoa phòng nào*/

        //                                                            }
        //                             ).FirstOrDefault();
        //                    if (infoReturn != null)
        //                    {
        //                        infoReturn.token = Common.GenerateTokenForClient();
        //                        return infoReturn;
        //                    }
        //                    else
        //                        throw new LogicException("Login fail");
        //                }
        //                else
        //                    throw new LogicException("Login fail");
        //            }
        //            else
        //                throw new LogicException("Login fail");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public List<SysMenuReadModel> GetMenuByUsernameAndAppName_BK(int i_Siterf, string i_UserName, string i_TypeUserCode, string i_AppName)
        {
            List<SysMenuReadModel> lstMenuByUserName = new List<SysMenuReadModel>();

            if (i_TypeUserCode.ToLower().Equals("admin") == true)
            {
                var abc = dbContext.sysmenus.AsNoTracking().ToList();

                lstMenuByUserName = (from smenu in dbContext.sysmenus.AsNoTracking()
                                         //  join lnkmodulemenu in dbContext.syslnkmodulemenus.AsNoTracking().Where(x => x.siterf == i_Siterf && x.active == 1) on smenu.id equals lnkmodulemenu.menuid
                                     join smodule in dbContext.sysmodules.AsNoTracking() on smenu.moduleid equals smodule.id
                                     where smenu.appname.Equals(i_AppName) == true
                                     select new SysMenuReadModel()
                                     {
                                         //   siterf = i_Siterf,
                                         id = smenu.id,
                                         name = smenu.name,
                                         code = smenu.code,
                                         descr = smenu.descr,
                                         iconstring = smenu.iconstring,
                                         order = smenu.orders,
                                         moduleId = smodule.id,
                                         moduleName = smodule.name,
                                         moduleIconString = smodule.iconstring,
                                         moduleOrder = smodule.orders,
                                         active = smenu.active
                                     }).DistinctBy(d => d.moduleId).ToList();
                //.OrderBy(x => x.moduleOrder).ThenBy(x => x.moduleName).ThenBy(x => x.order).ThenBy(x => x.name).ToList();
            }
            //else
            //{
            //    lstMenuByUserName = (from lnkAccGroup in dbContext.sysaulnkgroupaccounts.AsNoTracking().Where(x => x.siterf == i_Siterf && x.active == 1)
            //                         join lnkGroupRole in dbContext.sysaulnkrolegroups.AsNoTracking().Where(x => x.siterf == i_Siterf && x.active == 1) on lnkAccGroup.groupid equals lnkGroupRole.groupid
            //                         join lnkRolePer in dbContext.sysaulnkpermissionroles.AsNoTracking().Where(x => x.siterf == i_Siterf && x.active == 1) on lnkGroupRole.roleid equals lnkRolePer.roleid
            //                         join lnkPerMenu in dbContext.sysaulnkpermissionmenus.AsNoTracking().Where(x => x.siterf == i_Siterf && x.active == 1) on lnkRolePer.permissionid equals lnkPerMenu.permissionid
            //                         join smenu in dbContext.sysmenus.AsNoTracking().Where(x => x.siterf == i_Siterf && x.active == 1) on lnkPerMenu.menuid equals smenu.id
            //                         join lnkmodulemenu in dbContext.syslnkmodulemenus.AsNoTracking().Where(x => x.siterf == i_Siterf && x.active == 1) on smenu.id equals lnkmodulemenu.menuid
            //                         join smodule in dbContext.sysmodules.AsNoTracking().Where(x => x.siterf == i_Siterf && x.active == 1) on lnkmodulemenu.moduleid equals smodule.id
            //                         where lnkAccGroup.username == i_UserName
            //                         && smenu.appname.Equals(i_AppName) == true
            //                         select new SysMenuReadModel()
            //                         {
            //                             siterf = i_Siterf,
            //                             id = smenu.id,
            //                             name = smenu.name,
            //                             code = smenu.code,
            //                             descr = smenu.descr,
            //                             iconstring = smenu.iconstring,
            //                             order = smenu.order,
            //                             moduleId = smodule.id,
            //                             moduleName = smodule.name,
            //                             moduleIconString = smodule.iconstring,
            //                             moduleOrder = smodule.order,
            //                             active = smenu.active
            //                         }).OrderBy(x => x.moduleOrder).ThenBy(x => x.moduleName).ThenBy(x => x.order).ThenBy(x => x.name).ToList();
            //}

            //add module, view
            //foreach (var item in lstMenuByUserName)
            //{
            //    List<sysview> lstViewByMenu = (from lnkviewmenu in dbContext.syslnkviewmenus.AsNoTracking().Where(x => x.siterf == i_Siterf && x.active == 1)
            //                                   join view in dbContext.sysviews.AsNoTracking().Where(x => x.siterf == i_Siterf && x.active == 1) on lnkviewmenu.viewid equals view.id
            //                                   where lnkviewmenu.menuid == item.id
            //                                   select view
            //                                          ).ToList();

            //    item.lstView = mapper.MapperListSysViewEntityToReadModel(lstViewByMenu);
            //}

            foreach (var item in lstMenuByUserName)
            {
                var viewTest = dbContext.sysviews.AsNoTracking().ToList();

                List<sysview> lstViewByMenu = (from view in dbContext.sysviews.AsNoTracking()
                                               where view.menuid == item.id
                                               select view
                                                      ).ToList();

                //item.lstView = mapper.MapperSysViewsEntityToReadModel(lstViewByMenu);
            }


            return lstMenuByUserName;
        }

        public List<SysModuleModel> GetMenuByUsernameAndAppName(int i_Siterf, string i_UserName, string i_TypeUserCode, string i_AppName)
        {
            List<SysModuleModel> lstModuleByUserName = new List<SysModuleModel>();

            if (i_TypeUserCode.ToLower().Equals("admin") == true)
            {


                lstModuleByUserName = (from smodule in dbContext.sysmodules.AsNoTracking()
                                       select new SysModuleModel()
                                       {
                                           id = smodule.id,
                                           code = smodule.code,
                                           name = smodule.name,
                                           descr = smodule.descr,
                                           iconstring = smodule.iconstring,
                                           active = smodule.active,
                                           order = smodule.orders,
                                       }).OrderBy(o => o.order).ToList();

                if (lstModuleByUserName.Count > 0)
                {
                    lstModuleByUserName
                        .ForEach(f => f.lstMenu = dbContext.sysmenus.AsNoTracking()
                        .Where(x => x.siterf == 1 && x.active == 1 && x.moduleid == f.id)
                        .Select(s => new SysMenuModel
                        {
                            moduleId = f.id,
                            modulecode = f.code,
                            moduleName = f.name,
                            moduleIconString = f.iconstring,
                            moduleOrder = f.order,

                            id = s.id,
                            code = s.code,
                            name = s.name,
                            nameview = s.nameview,
                            appname = s.appname,
                            descr = s.descr,
                            iconstring = s.iconstring,
                            order = s.orders,
                        }).OrderBy(o => o.order).ToList());
                }
            }
            //else
            //{
            //    lstMenuByUserName = (from lnkAccGroup in dbContext.sysaulnkgroupaccounts.AsNoTracking().Where(x => x.siterf == i_Siterf && x.active == 1)
            //                         join lnkGroupRole in dbContext.sysaulnkrolegroups.AsNoTracking().Where(x => x.siterf == i_Siterf && x.active == 1) on lnkAccGroup.groupid equals lnkGroupRole.groupid
            //                         join lnkRolePer in dbContext.sysaulnkpermissionroles.AsNoTracking().Where(x => x.siterf == i_Siterf && x.active == 1) on lnkGroupRole.roleid equals lnkRolePer.roleid
            //                         join lnkPerMenu in dbContext.sysaulnkpermissionmenus.AsNoTracking().Where(x => x.siterf == i_Siterf && x.active == 1) on lnkRolePer.permissionid equals lnkPerMenu.permissionid
            //                         join smenu in dbContext.sysmenus.AsNoTracking().Where(x => x.siterf == i_Siterf && x.active == 1) on lnkPerMenu.menuid equals smenu.id
            //                         join lnkmodulemenu in dbContext.syslnkmodulemenus.AsNoTracking().Where(x => x.siterf == i_Siterf && x.active == 1) on smenu.id equals lnkmodulemenu.menuid
            //                         join smodule in dbContext.sysmodules.AsNoTracking().Where(x => x.siterf == i_Siterf && x.active == 1) on lnkmodulemenu.moduleid equals smodule.id
            //                         where lnkAccGroup.username == i_UserName
            //                         && smenu.appname.Equals(i_AppName) == true
            //                         select new SysMenuReadModel()
            //                         {
            //                             siterf = i_Siterf,
            //                             id = smenu.id,
            //                             name = smenu.name,
            //                             code = smenu.code,
            //                             descr = smenu.descr,
            //                             iconstring = smenu.iconstring,
            //                             order = smenu.order,
            //                             moduleId = smodule.id,
            //                             moduleName = smodule.name,
            //                             moduleIconString = smodule.iconstring,
            //                             moduleOrder = smodule.order,
            //                             active = smenu.active
            //                         }).OrderBy(x => x.moduleOrder).ThenBy(x => x.moduleName).ThenBy(x => x.order).ThenBy(x => x.name).ToList();
            //}

            //add module, view
            //foreach (var item in lstMenuByUserName)
            //{
            //    List<sysview> lstViewByMenu = (from lnkviewmenu in dbContext.syslnkviewmenus.AsNoTracking().Where(x => x.siterf == i_Siterf && x.active == 1)
            //                                   join view in dbContext.sysviews.AsNoTracking().Where(x => x.siterf == i_Siterf && x.active == 1) on lnkviewmenu.viewid equals view.id
            //                                   where lnkviewmenu.menuid == item.id
            //                                   select view
            //                                          ).ToList();

            //    item.lstView = mapper.MapperListSysViewEntityToReadModel(lstViewByMenu);
            //}

            //foreach (var item in lstMenuByUserName)
            //{
            //    var viewTest = dbContext.sysviews.AsNoTracking().ToList();

            //    List<sysview> lstViewByMenu = (from view in dbContext.sysviews.AsNoTracking()
            //                                   where view.menuid == item.id
            //                                   select view
            //                                          ).ToList();

            //    //item.lstView = mapper.MapperSysViewsEntityToReadModel(lstViewByMenu);
            //}


            return lstModuleByUserName;
        }
        #endregion

        #region SysApi
        public List<SysApiConfigReadModel> GetApiAll(int i_Offset, int i_Limit)
        {
            List<SysApiConfigReadModel> lstResult = new List<SysApiConfigReadModel>();
            try
            {
                List<SysApiConfigReadModel> lstSYSApiConfig = new List<SysApiConfigReadModel>();
                List<SysApiReadModel> lstApiValueObject = new List<SysApiReadModel>();
                List<sysserver> _lstsysserver = new List<sysserver>();
                if (i_Limit == 0)
                {
                    _lstsysserver = dbContext.sysServers.AsNoTracking().Where(x => x.active == 1).ToList();
                }
                else
                {
                    i_Offset = Library.CalculateOffsetIndex(i_Offset, i_Limit);

                    _lstsysserver = dbContext.sysServers.AsNoTracking().Where(x => x.active == 1).OrderBy(x => x.code)
                        .Skip(i_Offset).Take(i_Limit).ToList();
                }
                //lstSYSApiConfig = mapper.iMapperconfigApiToReadModel.Map<List<sysserver>, List<SysApiConfigReadModel>>(_lstsysserver);
                lstSYSApiConfig = mapper.MapServerEntityToReadmodel(_lstsysserver);

                foreach (SysApiConfigReadModel item in lstSYSApiConfig)
                {
                    var lstSysApi = dbContext.sysapis.AsNoTracking().Where(x => x.servercode == item.code && x.active == 1).ToList();
                    item.lstApiValueObject = mapper.MapperApiValueObjectToReadModel(lstSysApi, item);
                    lstResult.Add(item);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstResult;
        }
        public List<SysServerModel> GetServices()
        {
            List<SysServerModel> _lstResult = new List<SysServerModel>();
            // List<SysServicesModel> _lstResult = new List<SysServicesModel>();
            try
            {
                _lstResult = dbContext.sysServers

                    .Select(a => new SysServerModel
                    {
                        codeServer = a.code,
                        nameServer = a.name,
                        hostName = a.hostname,
                        active = a.active
                    }).ToList();
                _lstResult.ForEach(x =>
                x.lstSysServicesModel = dbContext.sysServices.Where(y => y.codeServer == x.codeServer)
                .Select(a => new SysServicesModel
                {
                    codeServices = a.codeServices,
                    nameServices = a.nameServices,
                    model = a.model,
                    url = a.url,
                    method = a.method,
                    server = a.codeServer,
                    hostName = a.hostName,
                    fullUrl = a.fullUrl,
                    active = a.active

                }).ToList()
                );
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _lstResult;
        }
        #endregion

        #region SysPrintTemplates

        public List<SysPrintTemplateReadModel> GetPrintTemplatebySiterf(int i_Siterf, int i_Offset, int i_Limit)
        {
            try
            {
                // i_Offset = Common.CalculateOffsetIndex(i_Offset, i_Limit);
                var lstitem = dbContext.sysprinttemplates.AsNoTracking().Where(a => a.active == 1)
                    .OrderByDescending(t => t.timecr).ToList();
                return mapper.MapperLstSysPrintTemplateEntityToReadModel(i_Siterf, lstitem);
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
                var item = dbContext.sysprinttemplates.Where(a => a.active == 1 && a.id == i_Id).FirstOrDefault();
                dbContext.Entry(item).ReloadAsync();
                return mapper.MapperSysPrintTemplateEntityToReadModel(i_Siterf, item);
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
                var item = dbContext.sysprinttemplates.Where(a => a.active == 1 && a.code == code).FirstOrDefault();
                dbContext.Entry(item).ReloadAsync();
                return mapper.MapperSysPrintTemplateEntityToReadModel(i_Siterf, item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string CreatePrintTemplate(int i_Siterf, SysPrintTemplateModel i_SysPrintTemplateModel)
        {
            try
            {
                var checkExist = dbContext.sysprinttemplates.Where(t => t.code == i_SysPrintTemplateModel.code).ToList();
                if (checkExist.Count > 0)
                {
                    UpdatePrintTemplate(i_Siterf, i_SysPrintTemplateModel);
                    //throw new LogicException(ConstantMessage.MaDaTonTai);
                }
                else
                {
                    //int? idmax = dbContext.sysprinttemplates.Max(x => (int?)x.id);
                    //if (idmax != null) { idmax++; } else { idmax = 1; }
                    //i_SysPrintTemplateModel.id = (int)idmax;
                    //i_SysPrintTemplateModel.active = 1;

                    var item = mapper.MapperSysPrintTemplateModelToEntity(i_Siterf, i_SysPrintTemplateModel);
                    item.timecr = DateTime.Now;
                    item.timeup = DateTime.Now;

                    List<sysprinttemplate> lstItem = new List<sysprinttemplate>();
                    lstItem.Add(item);
                    dbContext.BulkInsert(lstItem);
                }

                return i_SysPrintTemplateModel.code.ToString();
                //return (int)i_SysPrintTemplateModel.id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UpdatePrintTemplate(int i_Siterf, SysPrintTemplateModel i_SysPrintTemplateModel)
        {
            try
            {
                var item = mapper.MapperSysPrintTemplateModelToEntity(i_Siterf, i_SysPrintTemplateModel);
                item.active = 1;
                List<sysprinttemplate> lstRate = new List<sysprinttemplate>();
                lstRate.Add(item);
                dbContext.BulkUpdate(lstRate);
                return item.code;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeletePrintTemplate(int i_Siterf, int i_Id)
        {
            bool result = false;
            try
            {
                var item = dbContext.sysprinttemplates.Where(t => t.id == i_Id && t.siterf == i_Siterf && t.active == 1).FirstOrDefault();
                if (item != null)
                {
                    item.active = 0;
                    List<sysprinttemplate> lstItem = new List<sysprinttemplate>();
                    lstItem.Add(item);
                    dbContext.BulkUpdate(lstItem);
                    result = true;
                }
                else
                    throw new LogicException("Không tìm thấy trong sysprinttemplate có id: " + i_Id.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        #endregion

        #region SYS config
        public List<SysconfigReadModel> GetSysConfigByCode(int i_Siterf, string i_Code)
        {
            try
            {
                //List<SYS_config> sysConfigEntity = dbContext.SYS_configs.AsNoTracking().Where(t => t.siterf == i_Siterf  && t.active == 1).OrderBy(x => x.sort).ToList();
                List<SYS_configslipexam> sysConfigEntity = dbContext.SYS_configslipexams.AsNoTracking().Where(t => t.siterf == i_Siterf && t.active == 1).OrderBy(x => x.sort).ToList();
                if (sysConfigEntity != null)
                {
                    return mapper.MapperLstSysConfigEntityToReadModel(1, sysConfigEntity);
                }
                else
                    throw new LogicException("Không tìm thấy trong sysconfig có code: " + i_Code);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region SYSStructureData
        public bool CreateStructureDataNew_BK(string i_mmyy)
        {
            bool bResult = false;
            try
            {
                //01.Kiểm tra đồng bộ dữ liệu chưa

                //02.Tạo Schema tháng năm hiện tại

                //03.Coppy cấu trúc table 

                //04.Cật nhật dữ liệu tồn kho tháng mới

                string Schemaname = "mmyy";
                string SchemaNewValue = Schemaname + i_mmyy;

                var sysSchemaSelect = dbContext.sysschemas.AsNoTracking().Where(x => x.siterf == 1 && x.active == 1).FirstOrDefault();
                //var sysSchemaNewCheck = sysSchemaSelect.mmyy;

                if (sysSchemaSelect != null)
                {
                    var lstParaSchema = new SqlParameter[]
                    {
                            new SqlParameter()
                            {
                                ParameterName = "@SchemaCurent",
                                SqlDbType = System.Data.SqlDbType.NVarChar,
                                Value = sysSchemaSelect.name
                            },
                            new SqlParameter()
                            {
                                ParameterName = "@SchemaNew",
                                SqlDbType = System.Data.SqlDbType.NVarChar,
                                Value = SchemaNewValue
                            }
                    };
                    var resultExecCreateSchema = dbContext.Database.ExecuteSqlRaw($"EXEC  dbo.sp_create_schema_mmyy @SchemaCurent,@SchemaNew", lstParaSchema);

                    if (resultExecCreateSchema != null)
                    {
                        var lstPara = new SqlParameter[]
                                {
                                new SqlParameter()
                                {
                                    ParameterName = "@mmyycurent",
                                    SqlDbType = System.Data.SqlDbType.NVarChar,
                                    Value =  sysSchemaSelect.mmyy
                                },
                                 new SqlParameter()
                                {
                                    ParameterName = "@mmyynew",
                                    SqlDbType = System.Data.SqlDbType.NVarChar,
                                    Value = i_mmyy
                                },
                                };
                        var resultExecCreateStructoreTable = dbContext.Database.ExecuteSqlRaw($"EXEC  dbo.sp_create_structure_table_final @mmyycurent,@mmyynew ", lstPara);

                        if (resultExecCreateStructoreTable != null)
                        {
                            var lstTableNew = dbContext.systables.AsNoTracking().Where(x => x.active == 1 && x.mmyy == i_mmyy).ToList();
                        }


                        ////Create cấu trúc table từng dòng
                        //List<systables> lstTableCurent = new List<systables>();
                        //lstTableCurent = dbContext.systables.Where(x => x.active == 1).ToList();

                        //if (lstTableCurent.Count > 0)
                        //{
                        //    string lstTableSuccse = string.Empty;
                        //    string lstTableError = string.Empty;
                        //    foreach (systables item in lstTableCurent)
                        //    {

                        //        var lstPara = new SqlParameter[]
                        //        {
                        //        new SqlParameter()
                        //        {
                        //            ParameterName = "@schemaole",
                        //            SqlDbType = System.Data.SqlDbType.NVarChar,
                        //            Value = Schemaname +item.mmyy
                        //        },
                        //         new SqlParameter()
                        //        {
                        //            ParameterName = "@schemanew",
                        //            SqlDbType = System.Data.SqlDbType.NVarChar,
                        //            Value = Schemaname +i_mmyy
                        //        },
                        //        new SqlParameter()
                        //        {
                        //            ParameterName = "@mmyynew",
                        //            SqlDbType = System.Data.SqlDbType.NVarChar,
                        //            Value = i_mmyy
                        //        },
                        //        new SqlParameter()
                        //        {
                        //            ParameterName = "@tblname",
                        //            SqlDbType = System.Data.SqlDbType.NVarChar,
                        //            Value = item.code
                        //        },
                        //        };
                        //        var resultExecCreateStructoreTable = dbContext.Database.ExecuteSqlRaw($"EXEC  dbo.sp_create_structure_table @schemaole,@schemanew,@mmyynew,@tblname ", lstPara);
                        //        if (resultExecCreateStructoreTable == -1)
                        //        {
                        //            lstTableSuccse += item.code + '\n';
                        //        }
                        //        else
                        //        {
                        //            lstTableError += item.code + "\n";
                        //        }
                        //    }
                        //}
                        ////End Create cấu trúc table từng dòng
                    }
                    bResult = true;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return bResult;
        }

        public sysStructureDataReadModel CreateStructureDataNew(string i_mmyy)
        {
            //bool bResult = false;
            sysStructureDataReadModel Result = new sysStructureDataReadModel();
            try
            {
                //01.Kiểm tra đồng bộ dữ liệu chưa

                //02.Tạo Schema tháng năm hiện tại

                //03.Coppy cấu trúc table 

                //04.Cật nhật dữ liệu tồn kho tháng mới

                string Schemaname = "mmyy";
                string SchemaNewValue = Schemaname + i_mmyy;
                sysschema sysSchemaCheck = new sysschema();
                sysschema sysSchemaCurent = new sysschema();
                sysschema sysSchemaSelect = new sysschema();

                List<sysTableReadModel> lstSysTables = new List<sysTableReadModel>();

                sysSchemaCheck = dbContext.sysschemas.AsNoTracking().Where(x => x.siterf == 1 && x.active == 1).FirstOrDefault();

                sysSchemaSelect = sysSchemaCheck == null ? new sysschema { mmyy = "mmyy", name = "mmyymmyy" } : sysSchemaCheck;

                if (sysSchemaSelect != null)
                {
                    sysSchemaCurent = dbContext.sysschemas.AsNoTracking().Where(x => x.siterf == 1 && x.active == 1).FirstOrDefault();

                    var lstParaSchema = new SqlParameter[]
                    {
                            new SqlParameter()
                            {
                                ParameterName = "@SchemaCurent",
                                SqlDbType = System.Data.SqlDbType.NVarChar,
                                Value = sysSchemaSelect.name
                            },
                            new SqlParameter()
                            {
                                ParameterName = "@SchemaNew",
                                SqlDbType = System.Data.SqlDbType.NVarChar,
                                Value = SchemaNewValue
                            }
                    };
                    var resultExecCreateSchema = dbContext.Database.ExecuteSqlRaw($"EXEC  dbo.sp_create_schema_mmyy @SchemaCurent,@SchemaNew", lstParaSchema);

                    if (resultExecCreateSchema != null)
                    {
                        Result.mmyy = i_mmyy;
                        Result.name = SchemaNewValue;

                        var lstPara = new SqlParameter[]
                                {
                                new SqlParameter()
                                {
                                    ParameterName = "@mmyycurent",
                                    SqlDbType = System.Data.SqlDbType.NVarChar,
                                    Value =  sysSchemaSelect.mmyy
                                },
                                 new SqlParameter()
                                {
                                    ParameterName = "@mmyynew",
                                    SqlDbType = System.Data.SqlDbType.NVarChar,
                                    Value = i_mmyy
                                },
                                };
                        var resultExecCreateStructoreTable = dbContext.Database.ExecuteSqlRaw($"EXEC  dbo.sp_create_structure_table_final @mmyycurent,@mmyynew ", lstPara);

                        if (resultExecCreateStructoreTable != null)
                        {
                            lstSysTables = dbContext.systables.AsNoTracking().Where(x => x.active == 1 && x.mmyy == i_mmyy).ToList().Select(s=>new sysTableReadModel 
                            {
                                code = s.code,
                                name = s.name,
                            }).ToList();

                            if(lstSysTables.Count > 0)
                            {
                                Result.lsttables = lstSysTables;    
                                Result.count = lstSysTables.Count;    
                            }
                        }
                    }
                    //bResult = true;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Result;
        }
        #endregion

    }
}
