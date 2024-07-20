using Emr.Domain.Model.Share;
using Emr.Infrastructure.UniOfWork;
using System;
using System.Collections.Generic;

namespace Emr.Infrastructure.Services.Share
{
    public class CaShareServices : ICaShareServices
    {
        private IUnitOfWork unitOfWork;
        public CaShareServices(IUnitOfWork i_UnitOfWork)
        {
            unitOfWork = i_UnitOfWork;
        }

        public List<CaShareModel> GetAll()
        {
            try
            {
                return unitOfWork.CaShareRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
