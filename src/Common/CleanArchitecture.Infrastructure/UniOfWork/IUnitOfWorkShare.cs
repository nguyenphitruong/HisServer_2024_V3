using Emr.Domain.Model.Cache;
using Emr.Domain.Model.Share;
using Emr.Domain.Model.Share.Patient;
using Emr.Domain.Model.StoreProduce;
using Emr.Domain.Model.Sys;

namespace Emr.Infrastructure.UniOfWork
{
    public interface IUnitOfWorkShare
    {
        ITestShareRepository TestShareRepo { get; }
        ICacheRepository CacheRepo { get; }
        ISysRepository SysRepository { get; }
        IPatientRepository PatientRepo { get; }
        IStoreProduceRepository StoreProduceRepo { get; }

        

        void InitTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        void Save();

    }
}
