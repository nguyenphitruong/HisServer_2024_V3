using AutoMapper;

namespace Emr.Infrastructure.RepoMapper.Result
{
    public class ResultEntityMapper
    {
        internal MapperConfiguration cfgResultEntity;
        internal IMapper impResultEntity;

        //public ResultEntityMapper()
        //{
        //    //.Result
        //    cfgResultEntity = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<ResultModel, cdha_ketqua>()
        //        //.ForMember(x => x.mavv, opt => opt.MapFrom(z => z.mavv == Guid.Empty ? Guid.NewGuid() : z.mavv))
        //        // .ForMember(m => m.code , d => d.MapFrom(z => z.code ))
        //        // .ForMember(m => m.fullname, d => d.MapFrom(z => z.fullname ))
        //        .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
        //    });
        //    impResultEntity = cfgResultEntity.CreateMapper();
        //}
        //internal cdha_ketqua MapFromResultModelToTestEntity(ResultModel i_ResultModel)
        //{
        //    return impResultEntity.Map<ResultModel, cdha_ketqua>(i_ResultModel);
        //}
    }
}
