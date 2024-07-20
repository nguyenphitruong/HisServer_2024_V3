using AutoMapper;
using Emr.Domain.Entities.Sys.Api;
using Emr.Domain.Entities.Sys.Config;
using Emr.Domain.Entities.Sys.PrintTemplates;
using Emr.Domain.Entities.Sys.Views;
using Emr.Domain.Model.Sys.Config;
using Emr.Domain.Model.Sys.PrintTemplates;
using Emr.Domain.ReadModel.Sys.Api;
using Emr.Domain.ReadModel.Sys.Config;
using Emr.Domain.ReadModel.Sys.PrintTemplates;
using Emr.Domain.ReadModel.Sys.Views;
using System;
using System.Collections.Generic;

namespace Emr.Infrastructure.RepoMapper.Sys
{
    public class SysRepoMapper
    {

        internal IMapper iMapperConfigSys;
        private MapperConfiguration configSys;

        internal IMapper iMapperconfigApiToReadModel;
        internal IMapper iMapperApiValueObjectToReadModel;
        internal IMapper iMapperServerToEntity;
        internal IMapper iMapperEntityServerToReadModel;

        private MapperConfiguration configApiValueObjectToReadModel;
        private MapperConfiguration configApiToReadModel;
        private MapperConfiguration configServerToEntity;

        private MapperConfiguration configMapServerEntityToReadmodel;

        public SysRepoMapper()
        {
            //configServerToEntity = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<SysApiConfigModel, sysserver>()
            //    .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter()
            //    ;
            //});
            //configApiToReadModel = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<sysserver, SysApiConfigReadModel>()
            //    .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter()
            //    ;
            //});
            //iMapperServerToEntity = configServerToEntity.CreateMapper();
            //iMapperconfigApiToReadModel = configApiToReadModel.CreateMapper();
        }

        internal List<SysApiConfigReadModel> MapServerEntityToReadmodel(List<sysserver> i_lstsysserver)
        {
            configMapServerEntityToReadmodel = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<sysserver, SysApiConfigReadModel>()
                //.ForMember(x => x.fullpath, opt => opt.MapFrom(x => x.url != "" ? i_SYSApiConfig.hostname + "/" + x.url : i_SYSApiConfig.hostname))
                ;
            });
            iMapperEntityServerToReadModel = configMapServerEntityToReadmodel.CreateMapper();
            return iMapperEntityServerToReadModel.Map<List<sysserver>, List<SysApiConfigReadModel>>(i_lstsysserver);
        }
        internal List<SysApiReadModel> MapperApiValueObjectToReadModel(List<sysapi> _lstsysapis, SysApiConfigReadModel i_SYSApiConfig)
        {
            configApiValueObjectToReadModel = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<sysapi, SysApiReadModel>()
                .ForMember(x => x.fullurl, opt => opt.MapFrom(x => x.url != "" ? i_SYSApiConfig.hostname + "/" + x.url : i_SYSApiConfig.hostname))
                ;
            });
            iMapperApiValueObjectToReadModel = configApiValueObjectToReadModel.CreateMapper();
            return iMapperApiValueObjectToReadModel.Map<List<sysapi>, List<SysApiReadModel>>(_lstsysapis);
        }

        internal List<SysViewReadModel> MapperSysViewsEntityToReadModel(List<sysview> lstViewEntity)
        {
            configApiValueObjectToReadModel = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<sysview, SysViewReadModel>()
                //.ForMember(x => x.fullurl, opt => opt.MapFrom(x => x.url != "" ? i_SYSApiConfig.hostname + "/" + x.url : i_SYSApiConfig.hostname))
                ;
            });
            iMapperApiValueObjectToReadModel = configApiValueObjectToReadModel.CreateMapper();
            return iMapperApiValueObjectToReadModel.Map<List<sysview>, List<SysViewReadModel>>(lstViewEntity);
        }
        public List<SysPrintTemplateReadModel> MapperLstSysPrintTemplateEntityToReadModel(int i_Siterf, List<sysprinttemplate> i_SysPrintTemplate)
        {
            configSys = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<sysprinttemplate, SysPrintTemplateReadModel>()
                .ReverseMap().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            });
            iMapperConfigSys = configSys.CreateMapper();
            return iMapperConfigSys.Map<List<sysprinttemplate>, List<SysPrintTemplateReadModel>>(i_SysPrintTemplate);

        }
        public SysPrintTemplateReadModel MapperSysPrintTemplateEntityToReadModel(int i_Siterf, sysprinttemplate i_SysPrintTemplate)
        {
            configSys = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<sysprinttemplate, SysPrintTemplateReadModel>()
                .ReverseMap().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            });
            iMapperConfigSys = configSys.CreateMapper();
            return iMapperConfigSys.Map<sysprinttemplate, SysPrintTemplateReadModel>(i_SysPrintTemplate);

        }
        public sysprinttemplate MapperSysPrintTemplateModelToEntity(int i_Siterf, SysPrintTemplateModel i_SysUser)
        {
            configSys = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SysPrintTemplateModel, sysprinttemplate>()
                .ForMember(x => x.timeup, opt => opt.MapFrom(z => z.timeup == null ? DateTime.Now : z.timeup))
                .ForMember(x => x.timecr, opt => opt.MapFrom(z => z.timecr == null ? DateTime.Now : z.timecr))
                .ForMember(des => des.siterf, sr => sr.MapFrom(z => i_Siterf))
                .ReverseMap().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            });
            iMapperConfigSys = configSys.CreateMapper();
            return iMapperConfigSys.Map<SysPrintTemplateModel, sysprinttemplate>(i_SysUser);

        }

        public List<SysconfigReadModel> MapperLstSysConfigEntityToReadModel(int i_Siterf, List<SYS_configslipexam> i_lstSYS_config)
        {
            configSys = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SYS_configslipexam, SysconfigReadModel>()
                .ReverseMap().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            });
            iMapperConfigSys = configSys.CreateMapper();
            return iMapperConfigSys.Map<List<SYS_configslipexam>, List<SysconfigReadModel>>(i_lstSYS_config);

        }
    }
}
