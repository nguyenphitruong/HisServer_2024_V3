using AutoMapper;
using Emr.Domain.Entities.Emr.Outclinic;
using Emr.Domain.Entities.Emr.ServiceOrder;
using Emr.Domain.Model.Emr.Clinics;
using Emr.Domain.Model.Pha.Prescription;
using Emr.Domain.Model.Share;
using Emr.Domain.ReadModel.Emr.Clinic;
using Emr.Domain.ReadModel.Share;
//using PTEntity.Emr.Outclinic;
using System;
using System.Collections.Generic;

namespace Emr.Infrastructure.RepoMapper.Emr.Outclinic
{
    public class OutclinicEntityMapper
    {
        internal MapperConfiguration cfgMap;
        internal IMapper iMapper;

        //public OutclinicEntityMapper()
        //{
        //    //.Registry
        //    cfgemrregister = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<RegisterModel, emrregister>()
        //        //.ForMember(x => x.mavv, opt => opt.MapFrom(z => z.mavv == Guid.Empty ? Guid.NewGuid() : z.mavv))
        //        // .ForMember(m => m.code , d => d.MapFrom(z => z.code ))
        //        // .ForMember(m => m.fullname, d => d.MapFrom(z => z.fullname ))
        //        .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
        //    });
        //    iemrregister = cfgemrregister.CreateMapper();
        //    //.ServicesOrder
        //    cfgPayServices = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<RegisterModel, emrregister>()
        //        //.ForMember(x => x.mavv, opt => opt.MapFrom(z => z.mavv == Guid.Empty ? Guid.NewGuid() : z.mavv))
        //        // .ForMember(m => m.code , d => d.MapFrom(z => z.code ))
        //        // .ForMember(m => m.fullname, d => d.MapFrom(z => z.fullname ))
        //        .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
        //    });
        //    iPayServices = cfgPayServices.CreateMapper();
        //    //.Patient
        //    cfgemrpatient = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<PatientModel, emrpatient>()
        //        // .ForMember(m => m.code , d => d.MapFrom(z => z.code ))
        //        // .ForMember(m => m.fullname, d => d.MapFrom(z => z.fullname ))
        //        .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
        //    });
        //    iemrpatient = cfgemrpatient.CreateMapper();
        //    //.BHYT
        //    cfgMediBHYT = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<PatientHiModel, emrpatienthi>()
        //        // .ForMember(m => m.code , d => d.MapFrom(z => z.code ))
        //        // .ForMember(m => m.fullname, d => d.MapFrom(z => z.fullname ))
        //        .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
        //    });
        //    iMediBHYT = cfgMediBHYT.CreateMapper();
        //    //.Survira
        //    cfgMediSurvira = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<PatientSuvivalModel, emrpatientsurvival>()
        //        // .ForMember(m => m.code , d => d.MapFrom(z => z.code ))
        //        // .ForMember(m => m.fullname, d => d.MapFrom(z => z.fullname ))
        //        .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
        //    });
        //    iMediSurvira = cfgMediSurvira.CreateMapper();
        //    //.Relation
        //    cfgemrpatientelation = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<PatientSuvivalModel, emrpatientsurvival>()
        //        // .ForMember(m => m.code , d => d.MapFrom(z => z.code ))
        //        // .ForMember(m => m.fullname, d => d.MapFrom(z => z.fullname ))
        //        .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
        //    });
        //    iemrpatientelation = cfgemrpatientelation.CreateMapper();

        //}
        //Registry
        internal EMR_medioutclinic MapFromModelToEntityOutclinic(OutclinicModel i_OutclinicModel)
        {
            cfgMap = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OutclinicModel, EMR_medioutclinic>()
                 .ForMember(m => m.timecr, d => d.MapFrom(z => DateTime.Now))
                 .ForMember(m => m.idline, d => d.MapFrom(z => string.IsNullOrEmpty(z.idline) ? Guid.NewGuid().ToString() : z.idline))
                .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            });
            iMapper = cfgMap.CreateMapper();
            return iMapper.Map<OutclinicModel, EMR_medioutclinic>(i_OutclinicModel);
        }
        internal OutclinicReadModel MapFromEntityToReadModelModelOutclinic(EMR_medioutclinic i_emroutclinic)
        {
            cfgMap = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EMR_medioutclinic, OutclinicReadModel>()
                .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            });
            iMapper = cfgMap.CreateMapper();
            return iMapper.Map<EMR_medioutclinic, OutclinicReadModel>(i_emroutclinic);
        }
        internal List<OutclinicHisReadModel> MapFromEntityToReadModelLisOutclinic(List<EMR_medioutclinic> i_lstemroutclinic)
        {
            cfgMap = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EMR_medioutclinic, OutclinicHisReadModel>()
                .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            });
            iMapper = cfgMap.CreateMapper();
            return iMapper.Map<List<EMR_medioutclinic>, List<OutclinicHisReadModel>>(i_lstemroutclinic);
        }
        internal List<OutclinicReadModel> MapFromEntityToReadModelModelListOutclinic(List<EMR_medioutclinic> i_emroutclinic)
        {
            cfgMap = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<emroutclinic, OutclinicReadModel>()
                .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            });
            iMapper = cfgMap.CreateMapper();
            return iMapper.Map<List<EMR_medioutclinic>, List<OutclinicReadModel>>(i_emroutclinic);
        }

        internal List<EMR_serviceorder> MapFromModelToEntityListOutServicesOrder(List<EmrServicesOrderModel> i_LstServicesOrderModel, EMR_medioutclinic i_emroutclinic)
        {
            cfgMap = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmrServicesOrderModel, EMR_serviceorder>()
                 .ForMember(m => m.timecr, d => d.MapFrom(z => DateTime.Now))
               
                 .ForMember(m => m.placordercode, d => d.MapFrom(z => 2))
                 .ForMember(m => m.typepatcode, d => d.MapFrom(z => 1))
                 //.ForMember(m => m.managecode, d => d.MapFrom(z => i_emroutclinic.managecode))
                 .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            });
            iMapper = cfgMap.CreateMapper();
            return iMapper.Map<List<EmrServicesOrderModel>, List<EMR_serviceorder>>(i_LstServicesOrderModel);
        }

        internal List<EmrServicesOrderReadModel> MapFromEntityToReadModelListOutServicesOrder(List<EMR_serviceorder> i_emrservicesorder)
        {
            cfgMap = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EMR_serviceorder, EmrServicesOrderReadModel>()

                 .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            });
            iMapper = cfgMap.CreateMapper();
            return iMapper.Map<List<EMR_serviceorder>, List<EmrServicesOrderReadModel>>(i_emrservicesorder);
        }

        internal List<EmrDrugsOrderReadModel> MapFromEntityToReadModelListOutDrugsOrder(List<EMR_drugorder> i_emrdrugsorder)
        {
            cfgMap = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EMR_drugorder, EmrDrugsOrderReadModel>()
                 .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            });
            iMapper = cfgMap.CreateMapper();
            return iMapper.Map<List<EMR_drugorder>, List<EmrDrugsOrderReadModel>>(i_emrdrugsorder);
        }

        internal List<EMR_drugorder> MapFromModelToEntityListOutDrugsOrder(List<EmrDrugsOrderModel> i_EmrDrugsOrderModel, EMR_medioutclinic i_emroutclinic)
        {
            cfgMap = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmrDrugsOrderModel, EMR_drugorder>()
                .ForMember(m => m.timecr, d => d.MapFrom(z => DateTime.Now))
                .ForMember(des => des.idline, sr => sr.MapFrom(z => string.IsNullOrEmpty(z.idline) ? Guid.NewGuid().ToString() : z.idline))
                .ForMember(m => m.placordercode, d => d.MapFrom(z => "02"))
                .ForMember(m => m.typepatcode, d => d.MapFrom(z => "1"))
                .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            });
            iMapper = cfgMap.CreateMapper();
            return iMapper.Map<List<EmrDrugsOrderModel>, List<EMR_drugorder>>(i_EmrDrugsOrderModel);
        }

        //internal PHA_prescriptionhModel MapEmrDrugorderToPrescriptionhModel(EMR_medioutclinic i_EMR_medioutclinicl)
        //{
        //    cfgMap = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<EMR_medioutclinic, PHA_prescriptionlModel>()
        //        .ForMember(des => des.idline, sr => sr.MapFrom(z => z.idline))
        //        .ForMember(des => des.timeup, sr => sr.MapFrom(z => DateTime.Now))
        //        .ForMember(des => des.active, sr => sr.MapFrom(z => z.active == 0 ? 1 : z.active))
        //        .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
        //    });
        //    iMapper = cfgMap.CreateMapper();
        //    return iMapper.Map<EMR_medioutclinic, PHA_prescriptionhModel>(i_EMR_medioutclinicl);
        //}


        internal PHA_prescriptionhModel MapPrescriptionhToModel(EMR_medioutclinic i_Outclinic)
        {
            cfgMap = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EMR_medioutclinic, PHA_prescriptionhModel>()
                .ForMember(des => des.idline, sr => sr.MapFrom(z => string.IsNullOrEmpty(z.idline) ? Guid.NewGuid().ToString() : z.idline))

                .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            });
            iMapper = cfgMap.CreateMapper();
            return iMapper.Map<EMR_medioutclinic, PHA_prescriptionhModel>(i_Outclinic);
        }
        internal List<PHA_prescriptionlModel> MaplstPrescriptionlToModel(List<EMR_drugorder> i_lstEMR_drugorder)
        {
            cfgMap = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EMR_drugorder, PHA_prescriptionlModel>()
                .ForMember(des => des.idline, sr => sr.MapFrom(z => string.IsNullOrEmpty(z.idline) ? Guid.NewGuid().ToString() : z.idline))
                .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            });
            iMapper = cfgMap.CreateMapper();
            return iMapper.Map<List<EMR_drugorder>, List<PHA_prescriptionlModel>>(i_lstEMR_drugorder);
        }
    }
}
