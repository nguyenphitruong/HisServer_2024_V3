using Emr.Domain.Model.Pay.Services;
using Emr.Domain.ReadModel.Pay.Services;
using Emr.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Emr.Infrastructure.Repositories.Pay.Services
{
    public class ServicesRepository : IServicesRepository
    {

        //private RegistryEntityMapper _mapper;

        private MydbContext dbContext;
        public ServicesRepository(MydbContext i_Context)
        {
            dbContext = i_Context;
        }

        public PayGroupCatePriceServiceReadModel GetServiceCateAll()
        {

            PayGroupCatePriceServiceReadModel GroupCatePriceService = new PayGroupCatePriceServiceReadModel();

            List<PayGroupServiceReadModel> lstGroupService = new List<PayGroupServiceReadModel>();
            //List<PayCateServiceReadModel> lstCateService = new List<PayCateServiceReadModel>();
            //List<PayPriceServiceReadModel> lstPriceService = new List<PayPriceServiceReadModel>();

            try
            {
                var abc = dbContext.CATE_groupservicess.AsNoTracking()
                    .ToList();


                lstGroupService = dbContext.CATE_groupservicess.AsNoTracking()
                    .Where(x => x.active == 1)
                    .Select(s => new PayGroupServiceReadModel
                    {
                        id = s.id,
                        code = s.code,
                        name = s.name,
                        active = s.active,
                    }).ToList();


                if (lstGroupService.Count > 0)
                {
                    lstGroupService.ForEach(f =>
                    {
                        //f.CateService = dbContext.CATE_cateservicess
                        f.children = dbContext.CATE_cateservicess
                        .Where(x => x.groupservicescode == f.code)
                        .Select(s => new PayCateServiceReadModel
                        {
                            id = s.id,
                            code = s.code,
                            groupservicescode = s.groupservicescode,
                            name = s.name,
                            active = s.active,
                        }).ToList();

                        if (f.children.Count > 0)
                        {
                            f.children.ForEach(ff =>
                            {
                               // ff.PriceService = dbContext.CATE_priceservicess
                                ff.children = dbContext.CATE_priceservicess
                                .Where(x => x.cateservicescode == ff.code)
                                .Select(s => new PayPriceServiceReadModel
                                {
                                    id = s.id,
                                    groupservicescode = s.groupservicescode,
                                    groupservicesname = s.groupservicesname,
                                    cateservicescode = s.cateservicescode,
                                    cateservicesname = s.cateservicesname,
                                    code = s.code,
                                    name = s.name,
                                    bhytcode = s.bhytcode,
                                    bhytname = s.bhytname,
                                    ischeck = s.ischeck,
                                    unitcode = s.unitcode,
                                    unitname = "Lần",
                                    ofprice = s.ofprice,
                                    hiprice = s.hiprice,
                                    serprice = s.serprice,
                                    difprice = s.difprice,
                                    ishi = s.ishi,
                                    vat = s.vat,
                                    active = s.active,
                                    qty = 1,

                                }).ToList();
                            });
                        }
                    });
                }

                GroupCatePriceService.GroupService = lstGroupService;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return GroupCatePriceService;
        }
    }
}
