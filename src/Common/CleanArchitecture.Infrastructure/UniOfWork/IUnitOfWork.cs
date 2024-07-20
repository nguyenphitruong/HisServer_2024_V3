using Emr.Domain.Model;
using Emr.Domain.Model.Emr.Clinics;
using Emr.Domain.Model.Emr.Registers;
using Emr.Domain.Model.Pay.Services;
using Emr.Domain.Model.Share;
using Emr.Domain.Model.Sys;
using PT.DomainLayer.AggregatesModel.Pha;
using PT.DomainLayer.AggregatesModel.Result;

namespace Emr.Infrastructure.UniOfWork
{
    public interface IUnitOfWork
    {
        IHomeRepository HomeRepo { get; }
        IRegistryRepository RegisterRepo { get; }

        ICaShareRepository CaShareRepository { get; }
        IMediClinicRepository ClinicRepository { get; }
        IResultRepository ResultRepository { get; }
        //ISysRepository SysRepository { get; }
        //ICateRepository CateRepo { get; }
        //ICacheRepository CacheRepo { get; }
        IServicesRepository ServicesRepo { get; }
        IPhaRepository PhaRepo { get; }

        //public UnitOfWork_Context(ICache i_Caching);
        void InitTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        void Save();



    }
}
