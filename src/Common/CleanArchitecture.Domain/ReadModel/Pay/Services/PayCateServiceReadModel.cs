using Emr.Domain.Model.Pay.Services;
using System.Collections.Generic;

namespace Emr.Domain.ReadModel.Pay.Services
{
    public class PayCateServiceReadModel : PayCateServiceModel
    {
        public PayCateServiceReadModel()
        {
            //PriceService = new List<PayPriceServiceReadModel>();
            children = new List<PayPriceServiceReadModel>();
        }
        public List<PayPriceServiceReadModel> children { get; set; }
    }
}
