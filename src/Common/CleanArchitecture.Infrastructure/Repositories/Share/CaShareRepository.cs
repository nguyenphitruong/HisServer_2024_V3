using Emr.Domain.Model.Share;
using Emr.Domain.ReadModel.Share;
using Emr.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Emr.Infrastructure.Repositories.Share
{
    public class CaShareRepository : ICaShareRepository
    {
        private MydbContext dbContext;
        public CaShareRepository(MydbContext i_Context)
        {
            dbContext = i_Context;
        }
        public List<CaShareModel> GetAll()
        {
            var _lstResult = new List<CaShareModel>();
            try
            {
                _lstResult = dbContext.CATE_sharels
                    .Select(y => new CaShareModel
                    {
                        //code = y.code,
                        //codeh = y.codeh,
                        //parent = y.parent,
                        //acro = y.acro,
                        //name = y.name,
                        //des = y.des,
                        //active = y.active,
                        //ucr = y.ucr,
                        //uup = y.uup,
                        //timecr = y.timecr,
                        //timeup = y.timeup,
                        //com = y.com,
                        //mac = y.mac,
                        //ip = y.ip,
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _lstResult;
        }
        public List<CaShareModel> GetIdH(string _id)
        {
            var _lstResult = new List<CaShareModel>();
            try
            {
                _lstResult = dbContext.CATE_sharels.Where(x => x.codeh == _id)
                    .Select(y => new CaShareModel
                    {
                        //code = y.code,
                        //codeh = y.codeh,
                        //parent = y.parent,
                        //acro = y.acro,
                        //name = y.name,
                        //des = y.des,
                        //active = y.active,
                        //ucr = y.ucr,
                        //uup = y.uup,
                        //timecr = y.timecr,
                        //timeup = y.timeup,
                        //com = y.com,
                        //mac = y.mac,
                        //ip = y.ip,
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _lstResult;
        }
        //GetCode
        //public string GetCode(string _codeget, int i_action)
        //{
        //    string _codeset = "";
        //    try
        //    {
        //        if (_codeget != null || _codeget == "")
        //        {
        //            CaGetCodeReadModel _result = new CaGetCodeReadModel();
        //            _result = dbContext.CaShareGetCodes.Where(x => x.code == _codeget)
        //               .Select(x => new CaGetCodeReadModel
        //               {
        //                   code = x.code,
        //                   model = x.model,
        //                   name = x.name,
        //                   begin = x.begin,
        //                   end = x.end,
        //                   year = x.year,
        //                   step = x.step,
        //                   values = x.values,
        //                   maxValues = x.maxValues,
        //               }).FirstOrDefault();
        //            if (_result != null)
        //            {
        //                _result.values += _result.values + _result.step;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return _codeset;
        //}
    }
}
