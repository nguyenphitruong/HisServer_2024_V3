using Emr.Domain.Model.Cache;
using Emr.Domain.ReadModel.Cates.Depart;
using Emr.Domain.ReadModel.Pay.Services;
using Emr.Domain.ReadModel.Sys.Api;
using Emr.Domain.ReadModel.Sys.Modules;
using Emr.Infrastructure.UniOfWork;
using System;
using System.Collections.Generic;

namespace Emr.Infrastructure.Services
{
    public class CateServices : ICateServices
    {
        //private IUnitOfWork unitOfWork;
        //public CateServices(IUnitOfWork i_UnitOfWork)
        //{
        //    unitOfWork = i_UnitOfWork;
        //}

        private IUnitOfWorkShare unitOfWork;
        public CateServices(IUnitOfWorkShare i_UnitOfWork)
        {
            unitOfWork = i_UnitOfWork;
        }

        //public void GetCateCach()
        //{
        //    try
        //    {
        //        unitOfWork.CateRepo.GetCateCach();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public void GetCateIcd10Caching()
        //{
        //    try
        //    {
        //        unitOfWork.CateRepo.GetCateIcd10Caching();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public void GetCateHospitalCaching()
        //{
        //    try
        //    {
        //        unitOfWork.CateRepo.GetCateHospitalCaching();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public List<CateLineReadModel> GetLstCateLineByListCode(int i_Siterf, IPara i_CarePara)
        //{
        //    try
        //    {
        //        return unitOfWork.CateRepo.GetLstCateLineByListCode(i_Siterf, i_CarePara);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public List<CateHospitalReadModel> GetCateHospitalAll()
        //{
        //    try
        //    {
        //        return unitOfWork.CateRepo.GetCateHospitalAll();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}



        //public CateDepartMedexaHLReadModel GetCateDepartMedexaHLAll(int i_Siterf)
        //{
        //    try
        //    {
        //        return unitOfWork.CateRepo.GetCateDepartMedexaHLAll(i_Siterf);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public List<CateMedexaLReadModel> GetCateCateMedexaLAll(int i_Siterf)
        //{
        //    try
        //    {
        //        return unitOfWork.CacheRepo.GetCateCateMedexaLAll(i_Siterf);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public CateCachingReadModel GetCateCaching()
        {
            try
            {
                //return unitOfWork.CateRepo.GetCateICD10All();
                return unitOfWork.CacheRepo.GetCateCaching();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SysApiConfigReadModel> GetApiAll()
        {
            try
            {
                return unitOfWork.CacheRepo.GetApiAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public PayGroupCatePriceServiceReadModel GetCachingCateServiceCate()
        {
            try
            {
                return unitOfWork.CacheRepo.GetCachingCateServiceCate();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SYS_ModuleReadModel> GetMenuAll(int i_Siterf)
        {
            try
            {
                return unitOfWork.CacheRepo.GetMenuAll(i_Siterf);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
