using Emr.Domain.Entities;
using Emr.Domain.Model;
using Emr.Infrastructure.Persistence;
using Emr.Infrastructure.RepoMapper;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Emr.Application.Common.Interfaces;
using IdentityModel;
using System.Data.Entity;
using System.Threading;
using Emr.Domain.Entities.Cate;

namespace Emr.Infrastructure.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        //private IApplicationDbContext dbContext;
        private MydbContext dbContext;
        HomeRepoMapper mapper;
        
        public HomeRepository(MydbContext _context)
        {
            dbContext = _context;
            mapper = new HomeRepoMapper();
        }
        public List<CateshareLineModel> GetAllHome()
        {
            List<CateshareLineModel> rerult = new List<CateshareLineModel>();
            List<CATE_sharel> abc = new List<CATE_sharel>();

            abc = dbContext.CATE_sharels.Take(2000).ToList();
            //abc = dbContext.CaShareLs.ToList();
            //var rerult1 = dbContext.Districts.ToList();
            rerult = mapper.MapperListHomeEntityToModel(abc);   
            return rerult;
        }
        public List<DistrictModel> Create(List<DistrictModel> i_DistrictModel)
        {
            //List<District> lstEntity = new List<District>();

            //lstEntity = mapper.MapperListHomeModelToEntity(i_DistrictModel);
          
            //if (lstEntity.Count > 0)
            //{
            //    CancellationToken cancellationToken;
            //    dbContext.BulkMerge(lstEntity);
            //    // dbContext.Districts.Add(lstEntity[0]);
            //    //dbContext.SaveChanges(cancellationToken);

            //    //await _context.SaveChangesAsync(cancellationToken);
            //}
            //return mapper.MapperListHomeEntityToModel(lstEntity);

            return null;
        }
    }
}
