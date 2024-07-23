using Emr.Domain.Entities.Sys;
using Emr.Domain.Entities.Sys.Api;
using Emr.Domain.Model.Cache;
using Emr.Domain.Model.Cates;
using Emr.Domain.ReadModel.Cates.Depart;
using Emr.Domain.ReadModel.Cates.Hospital;
using Emr.Domain.ReadModel.Cates.Icd10;
using Emr.Domain.ReadModel.Cates.ValueObject;
using Emr.Domain.ReadModel.Pay.Services;
using Emr.Domain.ReadModel.Sys.Api;
using Emr.Domain.ReadModel.Sys.Menu;
using Emr.Domain.ReadModel.Sys.Modules;
using Emr.Infrastructure.Constans;
using Emr.Infrastructure.Persistence;
using Emr.Infrastructure.RepoMapper.Cates;
using Emr.Infrastructure.Repositories.Share;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace Emr.Infrastructure.Repositories.Cates
{
    public class CateRepository : ICateRepository
    {
        CaGetCodeRepository caRepo;
        private CatesEntityMapper mapper;
        private readonly IMemoryCache caching;
        //private ICache caching;
        private MyDbShareContext dbContext;
        //private CatesEntityMapper mapper;

        //public CateRepository(MydbContext i_Context, ICache i_Cache)
        //public CateRepository(MydbContext i_Context)
        //{
        //    dbContext = i_Context;
        //    //caching = i_Cache;
        //    mapper = new CatesEntityMapper();
        //}

        public CateRepository(MyDbShareContext i_Context)
        {
            dbContext = i_Context;
            //   caching = i_caching;
            mapper = new CatesEntityMapper();
        }

        public CateCachingReadModel GetCateCaching()
        {
            CateCachingReadModel Result = new CateCachingReadModel();
            try
            {
                Result.LstCachingCateShareHeader = GetAllCachingCateShareHeader();
                Result.LstCachingCateShareLine = GetAllCachingCateShareLine();
                Result.LstCachingCateICD10 = GetAllCachingCateICD10();
                Result.LstCachingCateHopital = GetAllCachingCateHopital();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Result;
        }

        public List<CateLineReadModel> GetAllCachingCateShareHeader()
        {
            List<CateLineReadModel> lstResult = new List<CateLineReadModel>();

            try
            {
                lstResult = (from cateL in dbContext.CATE_sharehs.AsNoTracking().Where(x => x.active == 1)
                             select new CateLineReadModel
                             {
                                 id = cateL.id,
                                 codeh = cateL.model.Trim(), 
                                 code = cateL.code.Trim(), 
                                 name = cateL.name, 
                                 active = cateL.active, 
                                 des = cateL.des,                 
                             }).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstResult;
        }
        public List<CateLineReadModel> GetAllCachingCateShareLine()
        {
            List<CateLineReadModel> lstResult = new List<CateLineReadModel>();

            try
            {
                lstResult = (from cateL in dbContext.CATE_sharels.AsNoTracking().Where(x => x.active == 1)
                             select new CateLineReadModel
                             {
                                 //siterf = cateL.siterf,
                                 id = cateL.id,
                                 codeh = cateL.codeh.Trim(), //Mã danh mục (header)
                                 code = cateL.code.Trim(), //Mã line
                                 name = cateL.name, //Tên line
                                 parent = cateL.parent == cateL.parent != null ? cateL.parent.Trim() : cateL.parent, //code line cấp trên
                                 acro = cateL.acro == cateL.acro != null ? cateL.acro.Trim() : cateL.acro, //code line cấp trên
                                                                                                           //acro = cateL.acro,
                                 active = cateL.active, //Đang sử dụng
                                 des = cateL.des, //Mô tả thêm 1
                                                  //ismodify = cateL.ismodify,
                             }).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstResult;
        }
        public PayGroupCatePriceServiceReadModel GetCachingCateServiceCate()
        {

            PayGroupCatePriceServiceReadModel GroupCatePriceService = new PayGroupCatePriceServiceReadModel();

            List<PayGroupServiceReadModel> lstGroupService = new List<PayGroupServiceReadModel>();
            List<PayCateServiceReadModel> lstCateService = new List<PayCateServiceReadModel>();
            List<PayPriceServiceReadModel> lstPriceService = new List<PayPriceServiceReadModel>();

            try
            {
                //var abc = dbContext.CATE_groupservicess.AsNoTracking()
                //    .ToList();


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
        //-----------------//-------------------------------------
        public List<CateICD10ReadModel> GetAllCachingCateICD10()
        {
            List<CateICD10ReadModel> lstResult = new List<CateICD10ReadModel>();
            try
            {
                lstResult = dbContext.CATE_icd10s.AsNoTracking().ToList()
                  .Select(s => new CateICD10ReadModel
                  {
                      id = s.id,
                      code = s.code.Trim(),
                      name = s.name,
                      nameen = s.nameen,
                  })
                  .ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstResult;
        }

        public List<CateHospitalReadModel> GetAllCachingCateHopital()
        {
            List<CateHospitalReadModel> lstResult = new List<CateHospitalReadModel>();
            try
            {
                lstResult = dbContext.CATE_hospitals.AsNoTracking()
               .Select(s => new CateHospitalReadModel
               {
                   id = s.id,
                   code = s.code.Trim(),
                   name = s.name,
                   decrp = s.decrp,
               })
               .ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstResult;
        }

        public List<SysApiConfigReadModel> GetApiAll()
        {
            List<SysApiConfigReadModel> lstResult = new List<SysApiConfigReadModel>();
            try
            {
                List<SysApiConfigReadModel> lstSYSApiConfig = new List<SysApiConfigReadModel>();
                List<SysApiReadModel> lstApiValueObject = new List<SysApiReadModel>();
                List<sysserver> _lstsysserver = new List<sysserver>();


                _lstsysserver = dbContext.sysServers.AsNoTracking().Where(x => x.active == 1).OrderBy(x => x.code)
                    .ToList();

                lstSYSApiConfig = mapper.MapServerEntityToReadmodel(_lstsysserver);

                foreach (SysApiConfigReadModel item in lstSYSApiConfig)
                {
                    var lstSysApi = dbContext.sysapis.AsNoTracking().Where(x => x.servercode == item.code && x.active == 1).ToList();
                    item.lstApiValueObject = mapper.MapperApiValueObjectToReadModel(lstSysApi, item);
                    lstResult.Add(item);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstResult;
        }

        //---Cateshare
        //public List<CateLineReadModel> GetLstCateLineByListCode(int i_Siterf, IPara i_CarePara)
        //{
        //    List<CateLineReadModel> lstResult = new List<CateLineReadModel>();
        //    try
        //    {

        //        //int offset = 0;
        //        //offset = Library.CalculateOffsetIndex(i_CarePara.offset, i_CarePara.limit);
        //        var lstCode = new List<string>();
        //        foreach (var item in i_CarePara.lstPara)
        //        {
        //            lstCode.Add(item.value.ToString().ToUpper());
        //        }

        //        List<CateLineReadModel> lstAllCategoryShare = GetAllCatesFromMemCache();

        //        if (lstAllCategoryShare.Count > 0)
        //        {
        //            lstResult = lstAllCategoryShare.Where(x => lstCode.Contains(x.codeh.Trim()))
        //           .Select(s => new CateLineReadModel
        //           {
        //               id = s.id,
        //               codeh = s.codeh.Trim(), //Mã danh mục (header)
        //               code = s.code.Trim(), //Mã line
        //               name = s.name.Trim(), //Tên line
        //               parent = s.parent == null ? null : s.parent.Trim(), //code line cấp trên
        //               acro = s.acro == null ? null : s.acro.Trim(), //code line cấp trên
        //               active = s.active, //Đang sử dụng
        //               des = s.des, //Mô tả thêm
        //                            //                       
        //           })
        //           .ToList();
        //        }
        //        else
        //        {
        //            lstResult = dbContext.CaShareLs.Where(x => lstCode.Contains(x.codeh.Trim()))
        //           .Select(s => new CateLineReadModel
        //           {
        //               id = s.id,
        //               codeh = s.codeh.Trim(), //Mã danh mục (header)
        //               code = s.code.Trim(), //Mã line
        //               name = s.name.Trim(), //Tên line
        //               parent = s.parent == null ? null : s.parent.Trim(), //code line cấp trên
        //               acro = s.acro == null ? null : s.acro.Trim(), //code line cấp trên
        //               active = s.active, //Đang sử dụng
        //               des = s.des, //Mô tả thêm
        //                            //                       
        //           })
        //           .ToList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return lstResult;


        //}

        //public List<CateLineReadModel> GetAllCatesFromMemCache(bool i_ResetCache = false)
        //{
        //    List<CateLineReadModel> lstResult = new List<CateLineReadModel>();

        //    try
        //    {
        //        if (i_ResetCache == false)
        //        {
        //            string key = ContantsCache.CateShare;
        //            List<casharel> listCateCaching = new List<casharel>();
        //            //listCateCaching = caching.GetCacheItem<List<casharel>>(ContantsCache.CateShare);
        //            listCateCaching = caching.GetOrCreateAsync(key, entry =>
        //            {
        //                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));

        //                return listCateCaching;
        //            });

        //            if (listCateCaching != null)
        //            {
        //                lstResult = mapper.MapFromEntityToReadModelCateShareCaching(listCateCaching);

        //                //lstResult =  listCateCaching
        //                //             select new CateLineReadModel
        //                //             {
        //                //                 //siterf = cateL.siterf,
        //                //                 id = cateL.id,
        //                //                 codeh = cateL.codeh.Trim(), //Mã danh mục (header)
        //                //                 code = cateL.code.Trim(), //Mã line
        //                //                 name = cateL.name, //Tên line
        //                //                 parent = cateL.parent == cateL.parent != null ? cateL.parent.Trim() : cateL.parent, //code line cấp trên
        //                //                 acro = cateL.acro == cateL.acro != null ? cateL.acro.Trim() : cateL.acro, //code line cấp trên
        //                //                                                                                           //acro = cateL.acro,
        //                //                 active = cateL.active, //Đang sử dụng
        //                //                 des = cateL.des, //Mô tả thêm 1
        //                //                 //ismodify = cateL.ismodify,
        //                //             }).ToList();


        //                //lstResult = (from cateL in listCateCaching
        //                //             select new CateLineReadModel
        //                //             {
        //                //                 //siterf = cateL.siterf,
        //                //                 id = cateL.id,
        //                //                 codeh = cateL.codeh.Trim(), //Mã danh mục (header)
        //                //                 code = cateL.code.Trim(), //Mã line
        //                //                 name = cateL.name, //Tên line
        //                //                 parent = cateL.parent == cateL.parent != null ? cateL.parent.Trim() : cateL.parent, //code line cấp trên
        //                //                 acro = cateL.acro == cateL.acro != null ? cateL.acro.Trim() : cateL.acro, //code line cấp trên
        //                //                                                                                           //acro = cateL.acro,
        //                //                 active = cateL.active, //Đang sử dụng
        //                //                 des = cateL.des, //Mô tả thêm 1
        //                //                 //ismodify = cateL.ismodify,
        //                //             }).ToList();
        //            }
        //            //if (listAllCateShareDetailCaching != null)
        //            //{
        //            //    if (listAllCateShareDetailCaching.Count > 0)
        //            //    {
        //            //        return listAllCateShareDetailCaching;
        //            //    }
        //            //}
        //        }
        //        else
        //        {
        //            //List<CateLineReadModel> listAllCateShareDetailCaching = caching.GetCacheItem<List<CateLineReadModel>>(ContantsCache.CateShare);
        //            //if (listAllCateShareDetailCaching != null)
        //            //    caching.RemoveCacheItem(ContantsCache.CateShare);

        //            //caching.RemoveCacheItem(ContantsCache.CateShare);

        //            lstResult = (from cateL in dbContext.CaShareLs.AsNoTracking().Where(x => x.active == 1)
        //                         select new CateLineReadModel
        //                         {
        //                             //siterf = cateL.siterf,
        //                             id = cateL.id,
        //                             codeh = cateL.codeh.Trim(), //Mã danh mục (header)
        //                             code = cateL.code.Trim(), //Mã line
        //                             name = cateL.name, //Tên line
        //                             parent = cateL.parent == cateL.parent != null ? cateL.parent.Trim() : cateL.parent, //code line cấp trên
        //                             acro = cateL.acro == cateL.acro != null ? cateL.acro.Trim() : cateL.acro, //code line cấp trên
        //                                                                                                       //acro = cateL.acro,
        //                             active = cateL.active, //Đang sử dụng
        //                             des = cateL.des, //Mô tả thêm 1
        //                                              //ismodify = cateL.ismodify,
        //                         }).ToList();

        //            //thuc hien cache data lai, se het han tai thoi diem 24h
        //            int minuteAdd = (24 * 60) - ((DateTime.Now.Hour * 60) + DateTime.Now.Minute + 1);
        //            //caching.AddWithDateTimeExpiration(ContantsCache.CateShare, lstResult, DateTimeOffset.Now.AddMinutes(minuteAdd));


        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return lstResult;
        //}

        //public void GetCateCach()
        //{

        //    try
        //    {
        //        //caching.RemoveCacheItem(ContantsCache.CateShare);

        //        List<casharel> lstResult = dbContext.CaShareLs.AsNoTracking().Where(x => x.active == 1).ToList();

        //        if (lstResult.Count > 0)
        //        {
        //            // thuc hien cache data lai, se het han tai thoi diem 24h
        //            int minuteAdd = (24 * 60) - ((DateTime.Now.Hour * 60) + DateTime.Now.Minute + 1);
        //          //  caching.AddWithDateTimeExpiration(ContantsCache.CateShare, lstResult, DateTimeOffset.Now.AddMinutes(minuteAdd));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        ////---CateICD10
        //public void GetCateIcd10Caching()
        //{
        //    try
        //    {
        //        //caching.RemoveCacheItem(ContantsCache.CateShare);

        //        List<caicd10> lstResult = dbContext.caicd10s.AsNoTracking().ToList();

        //        if (lstResult.Count > 0)
        //        {
        //            // thuc hien cache data lai, se het han tai thoi diem 24h
        //            int minuteAdd = (24 * 60) - ((DateTime.Now.Hour * 60) + DateTime.Now.Minute + 1);
        //          //  caching.AddWithDateTimeExpiration(ContantsCache.CateIc10, lstResult, DateTimeOffset.Now.AddMinutes(minuteAdd));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public List<CateICD10ReadModel> GetCateICD10FromMemCache(bool i_ResetCache = false)
        //{
        //    List<CateICD10ReadModel> lstResult = new List<CateICD10ReadModel>();

        //    try
        //    {
        //        if (i_ResetCache == false)
        //        {
        //            List<caicd10> listCateCaching = new List<caicd10>();
        //            //listCateCaching = caching.GetCacheItem<List<caicd10>>(ContantsCache.CateIc10);

        //            if (listCateCaching != null)
        //            {
        //                lstResult = mapper.MapFromEntityToReadModelCateICD10Caching(listCateCaching);
        //            }
        //        }
        //        else
        //        {


        //            lstResult = (from cateL in dbContext.caicd10s.AsNoTracking()
        //                         select new CateICD10ReadModel
        //                         {
        //                             id = cateL.id,
        //                             code = cateL.code.Trim(), //Mã line
        //                             name = cateL.name, //Tên line
        //                             nameen = cateL.nameen,
        //                         }).ToList();

        //            //thuc hien cache data lai, se het han tai thoi diem 24h
        //            int minuteAdd = (24 * 60) - ((DateTime.Now.Hour * 60) + DateTime.Now.Minute + 1);
        //           // caching.AddWithDateTimeExpiration(ContantsCache.CateIc10, lstResult, DateTimeOffset.Now.AddMinutes(minuteAdd));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return lstResult;
        //}



        //public List<CateICD10ReadModel> GetCateICD10All()
        //{
        //    List<CateICD10ReadModel> lstResult = new List<CateICD10ReadModel>();
        //    try
        //    {
        //        lstResult = dbContext.caicd10s.AsNoTracking().ToList()
        //          .Select(s => new CateICD10ReadModel
        //          {
        //              id = s.id,
        //              code = s.code.Trim(),
        //              name = s.name,
        //              nameen = s.nameen,
        //          })
        //          .Take(1000).ToList();

        //        //List<CateICD10ReadModel> lstCateICD10Entity = GetCateICD10FromMemCache();

        //        //if (lstCateICD10Entity.Count > 0)
        //        //{
        //        //    lstResult = lstCateICD10Entity
        //        //   .Select(s => new CateICD10ReadModel
        //        //   {
        //        //       id = s.id,
        //        //       code = s.code.Trim(),
        //        //       name = s.name,
        //        //       nameen = s.nameen,
        //        //   })
        //        //   .ToList();
        //        //}
        //        //else
        //        //{
        //        //    lstResult = dbContext.caicd10s.AsNoTracking().ToList()
        //        //   .Select(s => new CateICD10ReadModel
        //        //   {
        //        //       id = s.id,
        //        //       code = s.code.Trim(),
        //        //       name = s.name,
        //        //       nameen = s.nameen,
        //        //   })
        //        //   .ToList();
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return lstResult;
        //}

        //---CateHospital
        //        public void GetCateHospitalCaching()
        //        {
        //            try
        //            {
        ////                caching.RemoveCacheItem(ContantsCache.CateShare);

        //                List<cahospital> lstResult = dbContext.cahospitals.AsNoTracking().ToList();

        //                if (lstResult.Count > 0)
        //                {
        //                    // thuc hien cache data lai, se het han tai thoi diem 24h
        //                    int minuteAdd = (24 * 60) - ((DateTime.Now.Hour * 60) + DateTime.Now.Minute + 1);
        //  //                  caching.AddWithDateTimeExpiration(ContantsCache.CateHopital, lstResult, DateTimeOffset.Now.AddMinutes(minuteAdd));
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                throw ex;
        //            }
        //        }

        //        public List<CateHospitalReadModel> GetCateHospitalFromMemCache(bool i_ResetCache = false)
        //        {
        //            List<CateHospitalReadModel> lstResult = new List<CateHospitalReadModel>();

        //            try
        //            {
        //                if (i_ResetCache == false)
        //                {
        //                    List<cahospital> listCateCaching = new List<cahospital>();
        //                //    listCateCaching = caching.GetCacheItem<List<cahospital>>(ContantsCache.CateHopital);

        //                    if (listCateCaching != null)
        //                    {
        //                        lstResult = mapper.MapFromEntityToReadModelCateHospitalCaching(listCateCaching);
        //                    }
        //                }
        //                else
        //                {


        //                    lstResult = (from cateL in dbContext.cahospitals.AsNoTracking()
        //                                 select new CateHospitalReadModel
        //                                 {
        //                                     id = cateL.id,
        //                                     code = cateL.code.Trim(), //Mã line
        //                                     name = cateL.name, //Tên line
        //                                     decrp = cateL.decrp,
        //                                 }).ToList();

        //                    //thuc hien cache data lai, se het han tai thoi diem 24h
        //                    int minuteAdd = (24 * 60) - ((DateTime.Now.Hour * 60) + DateTime.Now.Minute + 1);
        //             //       caching.AddWithDateTimeExpiration(ContantsCache.CateHopital, lstResult, DateTimeOffset.Now.AddMinutes(minuteAdd));
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                throw ex;
        //            }
        //            return lstResult;
        //        }

        //        public List<CateHospitalReadModel> GetCateHospitalAll()
        //        {
        //            List<CateHospitalReadModel> lstResult = new List<CateHospitalReadModel>();
        //            try
        //            {
        //                List<CateHospitalReadModel> lstCateHospitalEntity = GetCateHospitalFromMemCache(true);

        //                if (lstCateHospitalEntity.Count > 0)
        //                {
        //                    lstResult = lstCateHospitalEntity
        //                   .Select(s => new CateHospitalReadModel
        //                   {
        //                       id = s.id,
        //                       code = s.code.Trim(),
        //                       name = s.name,
        //                       decrp = s.decrp,
        //                   })
        //                   .ToList();
        //                }
        //                else
        //                {
        //                    if (lstCateHospitalEntity.Count > 0)
        //                    {
        //                        lstResult = dbContext.cahospitals.AsNoTracking()
        //                       .Select(s => new CateHospitalReadModel
        //                       {
        //                           id = s.id,
        //                           code = s.code.Trim(),
        //                           name = s.name,
        //                           decrp = s.decrp,
        //                       })
        //                       .ToList();
        //                    }
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                throw ex;
        //            }
        //            return lstResult;
        //        }
        //        //Depart
        //        public CateDepartMedexaHLReadModel GetCateDepartMedexaHLAll(int i_Siterf)
        //        {

        //            CateDepartMedexaHLReadModel CateDepartMedexaHL = new CateDepartMedexaHLReadModel();

        //            List<CateDepartReadModel> lstCateDepart = new List<CateDepartReadModel>();

        //            try
        //            {


        //                lstCateDepart = dbContext.cadepartments.AsNoTracking()
        //                    .Where(x => x.active == 1 && x.siterf == i_Siterf)
        //                    .Select(s => new CateDepartReadModel
        //                    {
        //                        siterf = s.siterf,
        //                        rowsid = s.rowsid,
        //                        code = s.code,
        //                        name = s.name,
        //                        istreament = s.istreament,
        //                        active = s.active,
        //                    }).ToList();


        //                if (lstCateDepart.Count > 0)
        //                {
        //                    lstCateDepart.ForEach(f =>
        //                    {
        //                        f.LstCateMedexaH = dbContext.camedexahs.AsNoTracking()
        //                        .Where(x => x.departcode == f.code && x.active == 1 && x.siterf == i_Siterf)
        //                        .Select(s => new CateMedexaHReadModel
        //                        {
        //                            siterf = s.siterf,
        //                            rowsid = s.rowsid,
        //                            code = s.code,
        //                            departcode = s.departcode,
        //                            name = s.name,
        //                            active = s.active,
        //                        }).ToList();

        //                        if (f.LstCateMedexaH.Count > 0)
        //                        {
        //                            f.LstCateMedexaH.ForEach(ff =>
        //                            {
        //                                ff.LstCateMedexaL = dbContext.camedexals.AsNoTracking()
        //                                .Where(x => x.codeh == ff.code && x.active == 1 && x.siterf == i_Siterf)
        //                                .Select(s => new CateMedexaLReadModel
        //                                {
        //                                    siterf = s.siterf,
        //                                    rowsid = s.rowsid,
        //                                    code = s.code,
        //                                    codeh = s.codeh,
        //                                    name = s.name,
        //                                    servicevalues = s.servicevalues,
        //                                    active = s.active,

        //                                }).ToList();
        //                            });
        //                        }
        //                    });
        //                }

        //                CateDepartMedexaHL.LstCateDepart = lstCateDepart;
        //            }
        //            catch (Exception ex)
        //            {
        //                throw ex;
        //            }

        //            return CateDepartMedexaHL;
        //        }

        public List<CateMedexaLReadModel> GetCateMedexaLAll(int i_Siterf)
        {
            List<CateMedexaLReadModel> LstCateMedexaL = new List<CateMedexaLReadModel>();
            try
            {
                LstCateMedexaL = dbContext.camedexals.AsNoTracking()
                                .Where(x => x.active == 1 && x.siterf == 1)
                                .Select(s => new CateMedexaLReadModel
                                {
                                    siterf = s.siterf,
                                    rowsid = s.rowsid,
                                    code = s.code,
                                    codeh = s.codeh,
                                    name = s.name,
                                    servicevalues = s.servicevalues,
                                    active = s.active,

                                }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return LstCateMedexaL;
        }

        //ICD10

        //SYS menu

        public List<SYS_ModuleReadModel> GetMenuAll(int i_Siterf)
        {
            List<SYS_ModuleReadModel> LstCateMedexaL = new List<SYS_ModuleReadModel>();
            try
            {
                LstCateMedexaL = dbContext.SYS_modules.AsNoTracking()
                                .Where(x => x.active == 1 && x.siterf == 1)
                                .Select(s => new SYS_ModuleReadModel
                                {
                                    id = s.id,
                                    modulecode = s.code,
                                    modulename = s.name,
                                    modulepath = s.path,
                                    moduleicon = s.icon,
                                    note = s.note,
                                    siterf = s.siterf,
                                    active = s.active,
                                    usercr = s.usercr,
                                    timecr = s.timecr,
                                    userup = s.userup,
                                    computer = s.computer,
                                    mac = s.mac,
                                    chilren = dbContext.SYS_menus.AsNoTracking()
                                .Where(x => x.active == 1 && x.siterf == 1 && x.modulecode == s.code).Select(ss => new SYS_MenuReadModel
                                {
                                    id = ss.id,
                                    modulecode = ss.modulecode,
                                    code = ss.code,
                                    name = ss.name,
                                    path = ss.path,
                                    icon = ss.icon,
                                    component = ss.component,
                                    layout = ss.layout,
                                    modulepath = ss.modulepath,
                                    note = s.note,
                                    siterf = ss.siterf,
                                    active = ss.active,
                                    usercr = ss.usercr,
                                    timecr = ss.timecr,
                                    userup = ss.userup,
                                    computer = ss.computer,
                                    mac = ss.mac,
                                }).ToList()
                                }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return LstCateMedexaL;
        }

    }
}
