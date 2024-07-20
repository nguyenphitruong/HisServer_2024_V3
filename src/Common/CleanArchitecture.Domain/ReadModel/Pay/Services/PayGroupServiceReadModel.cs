using Emr.Domain.Model.Pay.Services;
using System.Collections.Generic;

namespace Emr.Domain.ReadModel.Pay.Services
{
    public class PayGroupServiceReadModel : PayGroupServiceModel
    {
        public PayGroupServiceReadModel()
        {
            //CateService = new List<PayCateServiceReadModel>();
            children = new List<PayCateServiceReadModel>();
        }
        public List<PayCateServiceReadModel> children { get; set; }
    }
}
