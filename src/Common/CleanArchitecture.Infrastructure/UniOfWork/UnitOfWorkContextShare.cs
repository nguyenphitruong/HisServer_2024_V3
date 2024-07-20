using Emr.Domain.Model.Cache;
using Emr.Domain.Model.Cates;
using Emr.Domain.Model.Share;
using Emr.Domain.Model.Share.Patient;
using Emr.Domain.Model.StoreProduce;
using Emr.Domain.Model.Sys;
using Emr.Infrastructure.Persistence;
using Emr.Infrastructure.Persistence.SchemaChange;
using Emr.Infrastructure.Repositories.Cache;
using Emr.Infrastructure.Repositories.Share;
using Emr.Infrastructure.Repositories.Share.Patient;
using Emr.Infrastructure.Repositories.StoreProduce;
using Emr.Infrastructure.Repositories.Sys;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Data.Entity.Validation;

namespace Emr.Infrastructure.UniOfWork
{
    public class UnitOfWorkContextShare : IUnitOfWorkShare, IDisposable
    {
        private readonly MyDbShareContext _context;
        private Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction? _DbContextTransaction;
        private bool _disposed;
        private string _errorMessage = string.Empty;

        private readonly IMemoryCache caching;
        public UnitOfWorkContextShare(MyDbShareContext i_context, IMemoryCache i_caching)
        {
            _context = i_context;
            caching = i_caching;
        }

        private IStoreProduceRepository storeProduceRepo;
        public IStoreProduceRepository StoreProduceRepo
        {
            get
            {
                if (this.storeProduceRepo == null)
                {
                    this.storeProduceRepo = new StoreProduceRepository(_context);
                }
                return storeProduceRepo;
            }
        }

        private IPatientRepository patientRepo;
        public IPatientRepository PatientRepo
        {
            get
            {
                if (this.patientRepo == null)
                {
                    //this.patientRepo = new PatientRepository(patientRepo,caching, _context);
                    this.patientRepo = new PatientRepository(_context);
                }

                return patientRepo;
            }
        }

        private readonly ICateRepository i_CateRepo;

        private ICacheRepository CacheRepository;
        public ICacheRepository CacheRepo
        {
            get
            {
                if (this.CacheRepository == null)
                {
                    this.CacheRepository = new CacheRepository(i_CateRepo, caching, _context);
                }
                return CacheRepository;
            }
        }

        private ITestShareRepository TestShareRepository;
        public ITestShareRepository TestShareRepo
        {
            get
            {
                if (this.TestShareRepository == null)
                {
                    this.TestShareRepository = new TestShareRepository(_context);
                }
                return TestShareRepository;
            }
        }

        private ISysRepository _SysRepository;
        public ISysRepository SysRepository
        {
            get
            {
                if (this._SysRepository == null)
                {
                    this._SysRepository = new SysRepository(_context);
                }
                return _SysRepository;
            }
        }

        public void InitTransaction()
        {
            _DbContextTransaction = _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _DbContextTransaction?.Commit();
        }
        public void Save()
        {
            try
            {
                _context.BulkSaveChanges();
                //_context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        _errorMessage += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                throw new Exception(_errorMessage, dbEx);
            }
        }

        public void RollbackTransaction()
        {
            _DbContextTransaction?.Rollback();
            _DbContextTransaction?.Dispose();
        }

        public void Dispose()
        {
            _DbContextTransaction?.Dispose();
        }

    }
}
