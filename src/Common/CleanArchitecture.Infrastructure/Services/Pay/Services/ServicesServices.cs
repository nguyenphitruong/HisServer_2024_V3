using Emr.Domain.ReadModel.Pay.Services;
using Emr.Infrastructure.UniOfWork;
using System;

namespace Emr.Infrastructure.Services.Pay.Services
{
    public class ServicesServices : IServicesServices
    {
        private IUnitOfWork unitOfWork;
        public ServicesServices(IUnitOfWork i_UnitOfWork)
        {
            unitOfWork = i_UnitOfWork;
        }
        public PayGroupCatePriceServiceReadModel GetServiceCateAll()
        {
            try
            {
                return unitOfWork.ServicesRepo.GetServiceCateAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
