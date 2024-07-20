using Emr.Domain.ReadModel.Pay.Services;

namespace Emr.Domain.Model.Pay.Services
{
    public interface IServicesRepository
    {
        PayGroupCatePriceServiceReadModel GetServiceCateAll();
    }
}
