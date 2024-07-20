using AutoMapper;
using Emr.Domain.Entities.Cate;
using Emr.Domain.ReadModel.Share;

namespace Emr.Infrastructure.RepoMapper.Share
{
    public class CaGetCodeRepoMapper
    {
        internal MapperConfiguration cfgMapModelToEntity;
        internal IMapper iMapModelToEntity;

        internal CaShareGetCode MapCaShareGetCodeFromModelToEntity(CaGetCodeReadModel i_CaGetCodeReadModel)
        {
            cfgMapModelToEntity = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CaGetCodeReadModel, CaShareGetCode>()
                // .ForMember(m => m.code , d => d.MapFrom(z => z.code ))
                // .ForMember(m => m.fullname, d => d.MapFrom(z => z.fullname ))
                .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            });
            iMapModelToEntity = cfgMapModelToEntity.CreateMapper();
            return iMapModelToEntity.Map<CaGetCodeReadModel, CaShareGetCode>(i_CaGetCodeReadModel);
        }


    }
}
