using Emr.Domain.Entities.Cate;
using Emr.Domain.Entities.Sys.Config;
using Emr.Domain.ReadModel.Share;
using Emr.Infrastructure.Persistence;
using Emr.Infrastructure.RepoMapper.Share;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Emr.Infrastructure.Repositories.Share
{
    public class CaGetCodeRepository
    {
        private MyDbShareContext dbContext;
        private CaGetCodeRepoMapper mapper;
        public CaGetCodeRepository(MyDbShareContext i_Context)
        {
            dbContext = i_Context;
            mapper = new CaGetCodeRepoMapper();
        }
        public string GetCode(string _codeget, int i_action)
        {
            string _codeset = "";
            try
            {
                if (_codeget != null || _codeget == "")
                {
                    CaGetCodeReadModel _result = new CaGetCodeReadModel();
                    _result = dbContext.CaShareGetCodes.AsNoTracking().Where(x => x.code == _codeget)
                       .Select(x => new CaGetCodeReadModel
                       {
                           code = x.code,
                           model = x.model,
                           name = x.name,
                           begin = x.begin,
                           end = x.end,
                           year = x.year,
                           step = x.step,
                           values = x.values,
                           maxValues = x.maxValues,
                       }).FirstOrDefault();
                    if (_result != null)
                    {


                        _result.values = _result.values + _result.step;
                        //    _result.values += _result.values + _result.step;
                        //_result.values += _result.values + _result.step;
                        List<CaShareGetCode> lstResult = new List<CaShareGetCode>();
                        lstResult.Add(mapper.MapCaShareGetCodeFromModelToEntity(_result));
                        if (lstResult.Count > 0)
                        {
                            dbContext.BulkMerge(lstResult);
                        }
                        string strYear = DateTime.Now.ToString("yy");
                        string valueTemm = strYear + _result.values.ToString().Trim();

                        _codeset = valueTemm;
                        //    _codeset = lstResult[0].values.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _codeset;
        }
        public int GetSTT(string i_object, string i_medexacode, string i_area)
        {
            int STT = 0;
            try
            {
                var lstconfigqueueorder = (from c in dbContext.configclinicqueues.AsNoTracking() where c.medexacode == i_medexacode && c.active == 1 select c).ToList();
                if (lstconfigqueueorder.Count > 0)
                {
                    int date1 = lstconfigqueueorder[0].dateused.Day;
                    int date2 = DateTime.Now.Day;

                    int numdayreset = lstconfigqueueorder[0].numdayreset;

                    if ((date2 - date1) != 0 && lstconfigqueueorder[0].lastnum != 1)
                    {
                        //using (var transaction = dbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
                        //{
                        List<configclinicqueue> lstconfigqueueorders = new List<configclinicqueue>();
                        configclinicqueue config = new configclinicqueue();
                        try
                        {
                            config.id = lstconfigqueueorder[0].id;
                            config.siterf = lstconfigqueueorder[0].siterf;
                            config.medexacode = lstconfigqueueorder[0].medexacode;
                            config.lastnum = int.Parse(lstconfigqueueorder[0].step.ToString());
                            config.dateused = DateTime.Now;
                            config.numdayreset = lstconfigqueueorder[0].numdayreset;
                            config.isodd = null;
                            config.step = lstconfigqueueorder[0].step;
                            config.valueinit = lstconfigqueueorder[0].valueinit;
                            config.descrp = lstconfigqueueorder[0].descrp;
                            config.active = 1;
                            config.usercr = lstconfigqueueorder[0].usercr;
                            config.timecr = lstconfigqueueorder[0].timecr;
                            config.userup = lstconfigqueueorder[0].userup;
                            config.timeup = lstconfigqueueorder[0].timeup;
                            config.computer = lstconfigqueueorder[0].computer;

                            lstconfigqueueorders.Add(config);
                            STT = config.lastnum;

                            //          lstconfigqueueorders.Add(config);
                            dbContext.BulkMerge(lstconfigqueueorders);
                            // dbContext.BulkSaveChanges(); //Lưu lại thay đổi
                            // transaction.Commit();  // Commit;  
                        }
                        catch (Exception ex)
                        {
                            //transaction.Rollback();  // Rollback nếu lỗi
                            throw ex;
                        }
                        //}
                    }
                    else
                    {
                        //         int numdayreset = int.Parse(lstconfigqueueorder[0].numdayreset.ToString());
                        List<configclinicqueue> lstconfigqueueorders = new List<configclinicqueue>();
                        configclinicqueue config = new configclinicqueue();

                        config.id = lstconfigqueueorder[0].id;
                        config.siterf = lstconfigqueueorder[0].siterf;
                        config.medexacode = lstconfigqueueorder[0].medexacode;
                        config.lastnum = (int.Parse(lstconfigqueueorder[0].step.ToString()) + int.Parse(lstconfigqueueorder[0].lastnum.ToString()));
                        config.dateused = lstconfigqueueorder[0].dateused;
                        config.numdayreset = lstconfigqueueorder[0].numdayreset;
                        config.isodd = null;
                        config.step = lstconfigqueueorder[0].step;
                        config.valueinit = lstconfigqueueorder[0].valueinit;
                        config.descrp = lstconfigqueueorder[0].descrp;
                        config.active = 1;
                        config.usercr = lstconfigqueueorder[0].usercr;
                        config.timecr = lstconfigqueueorder[0].timecr;
                        config.userup = lstconfigqueueorder[0].userup;
                        config.timeup = lstconfigqueueorder[0].timeup;
                        config.computer = lstconfigqueueorder[0].computer;
                        lstconfigqueueorders.Add(config);
                        STT = config.lastnum;

                        //using (var transaction = dbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
                        //{
                        try
                        {

                            dbContext.BulkMerge(lstconfigqueueorders);
                            // dbContext.BulkSaveChanges(); //Lưu lại thay đổi
                            // transaction.Commit();  // Commit;  
                        }
                        catch (Exception ex)
                        {
                            // transaction.Rollback();  // Rollback nếu lỗi                                
                            throw ex;
                        }
                        //}
                    }

                }
                else
                    STT = 0;
            }
            catch (Exception ex)
            {
                //LogManager.LogError(ex.ToString());  // Ghi log lỗi                    
                throw ex;
            }
            return STT;
        }
    }
}
