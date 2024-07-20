using Emr.Domain.Model;
using Emr.Infrastructure.UniOfWork;
using System;
using System.Collections.Generic;

namespace Emr.Infrastructure.Services
{
    public class HomeService : IHomeService
    {
        private IUnitOfWork unitOfWork;


        public HomeService(IUnitOfWork i_UnitOfWork)
        {
            unitOfWork = i_UnitOfWork;
        }
        public List<CateshareLineModel> GetAllHome()
        {
            try
            {
                return unitOfWork.HomeRepo.GetAllHome();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //List<CityDto> result = new List<CityDto>();

            //return result;
        }

        public List<DistrictModel> Create(List<DistrictModel> i_DistrictModel)
        {
            List<DistrictModel> result = new List<DistrictModel>();
            try
            {
                //_CateICDModel = _mapper.MapperCateICDDTOToModel(i_intSiter, i_CateICDDTO);
                unitOfWork.InitTransaction();
                result = unitOfWork.HomeRepo.Create(i_DistrictModel);
                unitOfWork.Save();
                unitOfWork.CommitTransaction();
            }
            catch (Exception ex)
            {
                unitOfWork.RollbackTransaction();
                throw ex;
            }
            return result;
        }
    }
}
