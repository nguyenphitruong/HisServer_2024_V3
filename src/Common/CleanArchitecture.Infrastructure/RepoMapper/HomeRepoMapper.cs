using AutoMapper;
using Emr.Domain.Entities.Cate;
using Emr.Domain.Model;
using System.Collections.Generic;

namespace Emr.Infrastructure.RepoMapper
{
    public class HomeRepoMapper
    {
        public HomeRepoMapper() { }

        internal MapperConfiguration cfgToEntity;
        internal IMapper imapperHome;
        //public List<District> MapperListHomeModelToEntity(List<DistrictModel> i_DistrictModel)
        //{
        //    cfgToEntity = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<DistrictModel, District>()
        //        //.ForMember(x => x.timeup, opt => opt.MapFrom(z => z.timeup == null ? DateTime.Now : z.timeup))
        //        //.ForMember(x => x.timecr, opt => opt.MapFrom(z => z.timecr == null ? DateTime.Now : z.timecr))
        //        //.ForMember(des => des.siterf, sr => sr.MapFrom(z => i_Siterf))
        //        .ReverseMap().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
        //    });
        //    imapperHome = cfgToEntity.CreateMapper();
        //    return imapperHome.Map<List<DistrictModel>, List<District>>(i_DistrictModel);
        //}

        public List<CateshareLineModel> MapperListHomeEntityToModel(List<CATE_sharel> i_cateicdxModel)
        {
            cfgToEntity = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CATE_sharel, CateshareLineModel>()
                //.ForMember(x => x.timeup, opt => opt.MapFrom(z => z.timeup == null ? DateTime.Now : z.timeup))
                //.ForMember(x => x.timecr, opt => opt.MapFrom(z => z.timecr == null ? DateTime.Now : z.timecr))
                //.ForMember(des => des.siterf, sr => sr.MapFrom(z => i_Siterf))
                .ReverseMap().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            });
            imapperHome = cfgToEntity.CreateMapper();
            return imapperHome.Map<List<CATE_sharel>, List<CateshareLineModel>>(i_cateicdxModel);
        }
    }
}
