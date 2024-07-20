using Emr.Domain.Entities.Pha;
using Emr.Domain.Model.Share;
using Emr.Domain.ReadModel.Pha;
using Emr.Infrastructure.Persistence;
using Emr.Infrastructure.RepoMapper.Pha;
using System;
using System.Collections.Generic;

namespace Emr.Infrastructure.Repositories.Share
{
    public class TestShareRepository : ITestShareRepository
    {
        public MyDbShareContext dbContext;
        PhaEntityMapper mapper;
        public TestShareRepository(MyDbShareContext i_Context)
        {
            dbContext = i_Context;
            mapper = new PhaEntityMapper();


        }
        public List<PHA_inventorylReadModel> GetDrugInventoryByStoreTest()
        {

            List<PHA_inventorylReadModel> result = new List<PHA_inventorylReadModel>();
            List<PHA_inventoryl> resultEntity = new List<PHA_inventoryl>();
            try
            {
                //var sp = dbContext.sp_create_schema_mmyy("mmyy0102");
                //schema.CurentSchema = "mmyy0124";
                //dbContext = new MyDbShareContext(new DbContextOptionsBuilder<MyDbShareContext>().UseSqlServer("Server=TRUONGNP\\TRUONGSQL; Database=DB_TRUONG_HOSP; uid = sa; pwd=links1920 ; MultipleActiveResultSets=true; ").Options, schema);

                //var pPms = "1";
                //var pType = "2";
                //resultEntity = dbContext.paypriceservices.FromSqlInterpolated("EXEC dbo.EEPayableExtract @p_PMS = {0}, @p_Type = {1}", pPms, pType) .ToList();
                //var resultEntitytest = dbContext.paypriceservices.FromSqlRaw("EXEC dbo.EEPayableExtract").ToList();

                //resultEntity = dbContext.PHA_inventoryls.ToList();
                //result = mapper.MapFromEntityToReadModelDrugInventoryl(resultEntity);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
    }
}
