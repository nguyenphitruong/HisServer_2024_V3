using System.Collections.Generic;

namespace Emr.Domain.ReadModel.Pay.Services
{
    public class PayGroupCatePriceServiceReadModel
    {
        public PayGroupCatePriceServiceReadModel()
        {
            GroupService = new List<PayGroupServiceReadModel>();
        }
        public List<PayGroupServiceReadModel> GroupService { get; set; }
    }
}
