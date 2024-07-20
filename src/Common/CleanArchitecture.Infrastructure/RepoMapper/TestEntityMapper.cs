using AutoMapper;

namespace Emr.Infrastructure.RepoMapper.Sys
{
    public class TestEntityMapper
    {
        internal MapperConfiguration cfgTestEntity;
        internal IMapper impTestEntity;

        //internal DM_DAN_TOC MapFromTestModelToTestEntity(TestModel i_TestModel)
        //{
        //    cfgTestEntity = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<TestModel, DM_DAN_TOC>()
        //       // .ForMember(m => m.code , d => d.MapFrom(z => z.code ))
        //       // .ForMember(m => m.fullname, d => d.MapFrom(z => z.fullname ))
        //        .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
        //    });
        //    impTestEntity = cfgTestEntity.CreateMapper();
        //    return impTestEntity.Map<TestModel, DM_DAN_TOC>(i_TestModel);
        //}
    }
}
