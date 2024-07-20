using Emr.Domain.Model;
using Emr.Domain.Model.Emr.Clinics;
using Emr.Domain.Model.Emr.Registers;
using Emr.Domain.Model.Pay.Services;
using Emr.Domain.Model.Share;
using Emr.Infrastructure.Hepper.Provider;
using Emr.Infrastructure.Persistence;
using Emr.Infrastructure.Persistence.SchemaChange;
using Emr.Infrastructure.Repositories;
using Emr.Infrastructure.Repositories.Clinic;
using Emr.Infrastructure.Repositories.Emr.Registers;
using Emr.Infrastructure.Repositories.Pay.Services;
using Emr.Infrastructure.Repositories.Pha;
using Emr.Infrastructure.Repositories.Result;
using Emr.Infrastructure.Repositories.Share;
using Microsoft.Extensions.Caching.Memory;
using PT.DomainLayer.AggregatesModel.Pha;
using PT.DomainLayer.AggregatesModel.Result;
using System;
using System.Data.Entity.Validation;
//using Microsoft.EntityFrameworkCore.Storage;

namespace Emr.Infrastructure.UniOfWork
{
    public class UnitOfWork_Context : IUnitOfWork, IDisposable 
    {
        public readonly ConnectionStrings connectionStrings;
        private readonly SchemaCurent schemaCurent;
        private readonly MydbContext _context;
        private Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction? _DbContextTransaction;
        private bool _disposed;
        private string _errorMessage = string.Empty;

        private readonly IMemoryCache caching;
        public UnitOfWork_Context(MydbContext i_context, IMemoryCache i_caching, ConnectionStrings i_connectionStrings)
        {
           
            connectionStrings = i_connectionStrings;
            _context = i_context;
            caching = i_caching;
            _context.schemaCurent.Name = "mmyy" + DateTime.Now.ToString("MMyy");
            connectionStrings = _context.connectionStrings;
        }

        private IPhaRepository PhaRepository;
        public IPhaRepository PhaRepo
        {
            get
            {
                if (this.PhaRepository == null)
                {
                    this.PhaRepository = new PhaRepository(_context);
                }
                return PhaRepository;
            }
        }

        private IHomeRepository homeRepo;
        public IHomeRepository HomeRepo
        {
            get
            {
                if (this.homeRepo == null)
                    this.homeRepo = new HomeRepository(_context);
                return homeRepo;
            }
        }
        private IRegistryRepository registerRepo;
        public IRegistryRepository RegisterRepo
        {
            get
            {
                if (this.registerRepo == null)
                    this.registerRepo = new RegistryRepository(_context);
                return registerRepo;
            }
        }
        //public UnitOfWork_Context(ICache i_Caching)
        //{
        //    if (_context is null)
        //    {
        //        _context = new MydbContext(null);
        //    }
        //    caching = i_Caching;
        //}
        private ICaShareRepository _CaShareRepository;
        public ICaShareRepository CaShareRepository
        {
            get
            {
                if (this._CaShareRepository == null)
                {
                    this._CaShareRepository = new CaShareRepository(_context);
                }
                return _CaShareRepository;
            }
        }
        private IMediClinicRepository _ClinicRepository;
        public IMediClinicRepository ClinicRepository
        {
            get
            {
                if (this._ClinicRepository == null)
                {
                    this._ClinicRepository = new MediClinicRepository(_context);
                }
                return _ClinicRepository;
            }
        }
        private IResultRepository _ResultRepository;
        public IResultRepository ResultRepository
        {
            get
            {
                if (this._ResultRepository == null)
                {
                    this._ResultRepository = new ResultRepository(_context);
                }
                return _ResultRepository;
            }
        }
        //private ISysRepository _SysRepository;
        //public ISysRepository SysRepository
        //{
        //    get
        //    {
        //        if (this._SysRepository == null)
        //        {
        //            this._SysRepository = new SysRepository(_context);
        //        }
        //        return _SysRepository;
        //    }
        //}

        //---
        private IServicesRepository servicesRepository;
        public IServicesRepository ServicesRepo
        {
            get
            {
                if (this.servicesRepository == null)
                {
                    this.servicesRepository = new ServicesRepository(_context);
                }
                return servicesRepository;
            }
        }
        //---


        //Using the Constructor we are initializing the _context variable is nothing but
        //we are storing the DBContext (EmployeeDBContext) object in _context variable



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
