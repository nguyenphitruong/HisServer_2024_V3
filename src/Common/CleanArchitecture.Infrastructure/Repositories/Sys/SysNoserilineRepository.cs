using Emr.Domain.Entities.Sys;
using Emr.Infrastructure.Constans;
using Emr.Infrastructure.Hepper.Exceptions;
using Emr.Infrastructure.Persistence;
using Emr.Infrastructure.RepoMapper.Sys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emr.Infrastructure.Repositories.Sys
{
    public class SysNoserilineRepository
    {
        private static object lockCreateHospCode = new object();
        private static object lockCreateCodeCommon = new object();
        SysRepoMapper mapper;
        public MyDbShareContext dbContext;
        //private MydbContext dbContext_share;
        public SysNoserilineRepository(MyDbShareContext i_Context)
        {
            dbContext = i_Context;
            mapper = new SysRepoMapper();
        }
        public string CreateHospCodeForCommon(int i_Siterf, string i_strCode)
        {
            string codeResult = string.Empty;
            lock (lockCreateHospCode)
            {
                SYS_noseriline noserilineInfo = new SYS_noseriline();

                //using (var transaction = dbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
                //{
                try
                {
                    noserilineInfo = dbContext.SYS_noserilines.AsNoTracking().Where(x => x.siterf == i_Siterf && x.code == i_strCode).FirstOrDefault();

                    if (noserilineInfo != null)
                    {

                        bool returnInit = false;
                        string strTypeChar = string.Empty;

                        switch (noserilineInfo.typechar)
                        {
                            case "Y":
                                if (noserilineInfo.yearused != DateTime.Now.Year.ToString())
                                {
                                    returnInit = true;
                                }

                                strTypeChar = noserilineInfo.dateused.Value.ToString("yy");
                                break;
                            case "M":
                                if (noserilineInfo.yearused != DateTime.Now.Year.ToString() && noserilineInfo.dateused.Value.Month != DateTime.Now.Month)
                                {
                                    returnInit = true;
                                }

                                strTypeChar = noserilineInfo.dateused.Value.ToString("MM");
                                break;
                            case "D":
                                if (noserilineInfo.yearused != DateTime.Now.Year.ToString() && noserilineInfo.dateused.Value.Month != DateTime.Now.Month && noserilineInfo.dateused.Value.Day != DateTime.Now.Day)
                                {
                                    returnInit = true;
                                }
                                strTypeChar = noserilineInfo.dateused.Value.ToString("dd");
                                break;
                            case "H":
                                if (noserilineInfo.yearused != DateTime.Now.Year.ToString() && noserilineInfo.dateused.Value.Month != DateTime.Now.Month && noserilineInfo.dateused.Value.Day != DateTime.Now.Day && noserilineInfo.dateused.Value.Hour != DateTime.Now.Hour)
                                {
                                    returnInit = true;
                                }
                                strTypeChar = noserilineInfo.dateused.Value.ToString("HH");
                                break;
                            default:
                                break;
                        }

                        if (returnInit == true)
                        {
                            noserilineInfo.lastnum = noserilineInfo.valueinit.Value;
                            noserilineInfo.yearused = DateTime.Now.Year.ToString();
                            noserilineInfo.dateused = DateTime.Now;
                        }

                        int dem = 0;

                        noserilineInfo.lastnum += noserilineInfo.step.Value;
                        codeResult = strTypeChar + noserilineInfo.prefix + noserilineInfo.lastnum.ToString(noserilineInfo.lennum);
                        dem++;
                        if (dem > 2)
                        {
                            throw new LogicException("Không tạo được mã bệnh nhân. Hãy thực hiện lưu lại");
                        }

                        //do
                        //{
                        //    noserilineInfo.lastnum += noserilineInfo.step.Value;
                        //    codeResult = strTypeChar + noserilineInfo.prefix + noserilineInfo.lastnum.ToString(noserilineInfo.lennum);
                        //    dem++;
                        //    if (dem > 2)
                        //    {
                        //        throw new LogicException("Không tạo được mã bệnh nhân. Hãy thực hiện lưu lại");
                        //    }
                        //} 
                        //while (CheckCodeExists(i_Siterf, codeResult) == false);

                        List<SYS_noseriline> sysnoserilines = new List<SYS_noseriline>();
                        sysnoserilines.Add(noserilineInfo);
                        dbContext.BulkUpdate(sysnoserilines);
                        //dbContext.BulkSaveChanges();
                        //transaction.Commit(); // Commit;
                    }
                }
                catch (Exception ex)
                {
                    //transaction.Rollback();// Rollback nếu lỗi
                    throw ex;
                }
                //}
            }
            return codeResult;
        }

    }

}
