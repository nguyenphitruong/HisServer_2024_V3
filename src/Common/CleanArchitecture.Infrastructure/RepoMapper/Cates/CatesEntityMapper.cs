using AutoMapper;
using Emr.Domain.Entities.Cate;
using Emr.Domain.Entities.Cate.Hospital;
using Emr.Domain.Entities.Cate.Icd10;
using Emr.Domain.Entities.Sys.Api;
using Emr.Domain.Entities.Sys.Menus;
using Emr.Domain.ReadModel.Cates.Hospital;
using Emr.Domain.ReadModel.Cates.Icd10;
using Emr.Domain.ReadModel.Cates.ValueObject;
using Emr.Domain.ReadModel.Sys.Api;
using Emr.Domain.ReadModel.Sys.Menu;
using System.Collections.Generic;

namespace Emr.Infrastructure.RepoMapper.Cates
{
    public class CatesEntityMapper
    {
        internal MapperConfiguration cfmapper;
        internal IMapper imapper;

        internal List<CateLineReadModel> MapFromEntityToReadModelCateShareCaching(List<CATE_sharel> i_casharel)
        {
            cfmapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CATE_sharel, CateLineReadModel>()
                .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            });
            imapper = cfmapper.CreateMapper();
            return imapper.Map<List<CATE_sharel>, List<CateLineReadModel>>(i_casharel);
        }

        internal List<CateICD10ReadModel> MapFromEntityToReadModelCateICD10Caching(List<CATE_icd10> i_caicd10)
        {
            cfmapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CATE_icd10, CateICD10ReadModel>()
                .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            });
            imapper = cfmapper.CreateMapper();
            return imapper.Map<List<CATE_icd10>, List<CateICD10ReadModel>>(i_caicd10);
        }

        internal List<CateHospitalReadModel> MapFromEntityToReadModelCateHospitalCaching(List<CATE_hospital> i_cahospital)
        {
            cfmapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CATE_hospital, CateHospitalReadModel>()
                .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            });
            imapper = cfmapper.CreateMapper();
            return imapper.Map<List<CATE_hospital>, List<CateHospitalReadModel>>(i_cahospital);
        }
        internal List<SysApiConfigReadModel> MapServerEntityToReadmodel(List<sysserver> i_lstsysserver)
        {
            cfmapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<sysserver, SysApiConfigReadModel>()
                //.ForMember(x => x.fullpath, opt => opt.MapFrom(x => x.url != "" ? i_SYSApiConfig.hostname + "/" + x.url : i_SYSApiConfig.hostname))
                ;
            });
            imapper = cfmapper.CreateMapper();
            return imapper.Map<List<sysserver>, List<SysApiConfigReadModel>>(i_lstsysserver);
        }
        internal List<SysApiReadModel> MapperApiValueObjectToReadModel(List<sysapi> _lstsysapis, SysApiConfigReadModel i_SYSApiConfig)
        {
            cfmapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<sysapi, SysApiReadModel>()
                .ForMember(x => x.fullurl, opt => opt.MapFrom(x => x.url != "" ? i_SYSApiConfig.hostname + "/" + x.url : i_SYSApiConfig.hostname))
                ;
            });
            imapper = cfmapper.CreateMapper();
            return imapper.Map<List<sysapi>, List<SysApiReadModel>>(_lstsysapis);
        }

        internal List<SYS_MenuReadModel> MapFromEntityToReadModelListMenu(List<SYS_menu> i_casharel)
        {
            cfmapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SYS_menu, SYS_MenuReadModel>()
                .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            });
            imapper = cfmapper.CreateMapper();
            return imapper.Map<List<SYS_menu>, List<SYS_MenuReadModel>>(i_casharel);
        }
    }
}
