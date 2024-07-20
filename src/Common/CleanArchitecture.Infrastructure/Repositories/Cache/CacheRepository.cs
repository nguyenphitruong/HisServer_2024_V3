using Emr.Domain.Entities.Cate;
using Emr.Domain.Model.Cache;
using Emr.Domain.Model.Cates;
using Emr.Domain.ReadModel.Cates.Depart;
using Emr.Domain.ReadModel.Cates.Icd10;
using Emr.Domain.ReadModel.Cates.ValueObject;
using Emr.Domain.ReadModel.Pay.Services;
using Emr.Domain.ReadModel.Sys.Api;
using Emr.Domain.ReadModel.Sys.Modules;
using Emr.Infrastructure.Constans;
using Emr.Infrastructure.Persistence;
using Emr.Infrastructure.Repositories.Cates;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;

namespace Emr.Infrastructure.Repositories.Cache
{
    public class CacheRepository : ICacheRepository
    {
        private readonly ICateRepository CateRepo;
        private readonly IMemoryCache caching;
        private MyDbShareContext dbContext;
        public CacheRepository(ICateRepository i_CateRepo, IMemoryCache i_caching, MyDbShareContext i_dbContext)
        {
            dbContext = i_dbContext;
            caching = i_caching;
            CateRepo = new CateRepository(dbContext);
        }
        public CacheRepository()
        {

        }
        public CateCachingReadModel GetCateCaching()
        {
            CateCachingReadModel lstResult = new CateCachingReadModel();
            try
            {
                CateCachingReadModel lstCateICD10Entity = new CateCachingReadModel();

                //switch (key)
                //{
                //    case :ContantsCache.CateShare.ToString()

                //    default:
                //}
                string key = ContantsCache.CateShare.ToString();
                lstCateICD10Entity = caching.GetOrCreate(key, entry =>
                {
                    entry.SetAbsoluteExpiration(TimeSpan.FromHours(24));
                    return CateRepo.GetCateCaching();
                });
                lstResult = lstCateICD10Entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstResult;
        }

        public List<SysApiConfigReadModel> GetApiAll()
        {
            List<SysApiConfigReadModel> lstResult = new List<SysApiConfigReadModel>();
            try
            {
                string key = ContantsCache.CateApi.ToString();
                lstResult = caching.GetOrCreate(key, entry =>
                {
                    entry.SetAbsoluteExpiration(TimeSpan.FromHours(24));
                    return CateRepo.GetApiAll();
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstResult;
        }

        public PayGroupCatePriceServiceReadModel GetCachingCateServiceCate()
        {
            PayGroupCatePriceServiceReadModel lstGetCachingCateServiceCate = new PayGroupCatePriceServiceReadModel();
            try
            {
                string key = ContantsCache.CateService.ToString();
                lstGetCachingCateServiceCate = caching.GetOrCreate(key, entry =>
                {
                    entry.SetAbsoluteExpiration(TimeSpan.FromHours(24));
                    return CateRepo.GetCachingCateServiceCate();
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstGetCachingCateServiceCate;
        }

        public List<CateMedexaLReadModel> GetCateMedexaLAllCaching()
        {
            List<CateMedexaLReadModel> lstResult = new List<CateMedexaLReadModel>();
            try
            {
                string key = ContantsCache.CateMedexa.ToString();

                lstResult = caching.GetOrCreate(key, entry =>
                {
                    entry.SetAbsoluteExpiration(TimeSpan.FromHours(24));
                    return CateRepo.GetCateMedexaLAll(1);
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstResult;
        }

        public List<SYS_ModuleReadModel> GetMenuAll(int i_Siterf)
        {
            List<SYS_ModuleReadModel> lstResult = new List<SYS_ModuleReadModel>();
            try
            {
                string key = ContantsCache.SYS_Menu.ToString();
                lstResult = caching.GetOrCreate(key, entry =>
                {
                    entry.SetAbsoluteExpiration(TimeSpan.FromHours(24));
                    return CateRepo.GetMenuAll(i_Siterf);
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstResult;

            
        }
    }
}
