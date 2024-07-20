using AutoMapper;
using Emr.Domain.Entities.Emr.Registers;
using Emr.Domain.Entities.Emr.ServiceOrder;
using Emr.Domain.Model.Emr.Register;
using Emr.Domain.Model.Emr.Registers;
using Emr.Domain.Model.Emr.Registers.ValuesObject;
using Emr.Domain.Model.Share;
using System;
using System.Collections.Generic;

namespace Emr.Infrastructure.RepoMapper.Emr.Registers
{
    public class RegistryEntityMapper
    {
        internal MapperConfiguration cfgemrregister;
        internal IMapper iemrregister;

        internal MapperConfiguration cfgPayServices;
        internal IMapper iPayServices;

        internal MapperConfiguration cfgemrpatient;
        internal IMapper iemrpatient;

        internal MapperConfiguration cfgMediBHYT;
        internal IMapper iMediBHYT;

        internal MapperConfiguration cfgMediSurvira;
        internal IMapper iMediSurvira;

        internal MapperConfiguration cfgemrpatientelation;
        internal IMapper iemrpatientelation;

        public RegistryEntityMapper()
        {
            //.Registry
            cfgemrregister = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RegisterModel, emrregister>()
                //.ForMember(x => x.mavv, opt => opt.MapFrom(z => z.mavv == Guid.Empty ? Guid.NewGuid() : z.mavv))
                // .ForMember(m => m.code , d => d.MapFrom(z => z.code ))
                // .ForMember(m => m.fullname, d => d.MapFrom(z => z.fullname ))
                .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            });
            iemrregister = cfgemrregister.CreateMapper();
            //.ServicesOrder
            cfgPayServices = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RegisterModel, emrregister>()
                //.ForMember(x => x.mavv, opt => opt.MapFrom(z => z.mavv == Guid.Empty ? Guid.NewGuid() : z.mavv))
                // .ForMember(m => m.code , d => d.MapFrom(z => z.code ))
                // .ForMember(m => m.fullname, d => d.MapFrom(z => z.fullname ))
                .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            });
            iPayServices = cfgPayServices.CreateMapper();
            ////.Patient
            //cfgemrpatient = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<PatientModel, emrpatient>()
            //    // .ForMember(m => m.code , d => d.MapFrom(z => z.code ))
            //    // .ForMember(m => m.fullname, d => d.MapFrom(z => z.fullname ))
            //    .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            //});
            //iemrpatient = cfgemrpatient.CreateMapper();
            ////.BHYT
            //cfgMediBHYT = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<PatientHiModel, emrpatienthi>()
            //    // .ForMember(m => m.code , d => d.MapFrom(z => z.code ))
            //    // .ForMember(m => m.fullname, d => d.MapFrom(z => z.fullname ))
            //    .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            //});
            //iMediBHYT = cfgMediBHYT.CreateMapper();
            ////.Survira
            //cfgMediSurvira = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<PatientSuvivalModel, emrpatientsurvival>()
            //    // .ForMember(m => m.code , d => d.MapFrom(z => z.code ))
            //    // .ForMember(m => m.fullname, d => d.MapFrom(z => z.fullname ))
            //    .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            //});
            //iMediSurvira = cfgMediSurvira.CreateMapper();
            ////.Relation
            //cfgemrpatientelation = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<PatientSuvivalModel, emrpatientsurvival>()
            //    // .ForMember(m => m.code , d => d.MapFrom(z => z.code ))
            //    // .ForMember(m => m.fullname, d => d.MapFrom(z => z.fullname ))
            //    .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            //});
            //iemrpatientelation = cfgemrpatientelation.CreateMapper();

        }
        //Registry
        internal emrregister MapFromModelToEntityemrregister(RegisterModel i_MediRegisterModel)
        {
            cfgPayServices = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RegisterModel, emrregister>()
                 .ForMember(m => m.timecr, d => d.MapFrom(z => DateTime.Now))
                 .ForMember(m => m.patcode, d => d.MapFrom(z => i_MediRegisterModel.patcode))
                 .ForMember(m => m.patienttype, d => d.MapFrom(z => i_MediRegisterModel.patienttype))
                 .ForMember(m => m.objectcode, d => d.MapFrom(z => i_MediRegisterModel.objectcode))


                .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            });
            iemrregister = cfgPayServices.CreateMapper();
            return iemrregister.Map<RegisterModel, emrregister>(i_MediRegisterModel);
        }
        // ServicesOrder
        internal List<emrservicesorder> MapFromModelToEntityLstPayService(List<EmrServicesOrderModel> i_LstEmrServicesOrderModel, emrregister i_MediRegisterModel)
        {
            cfgPayServices = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmrServicesOrderModel, emrservicesorder>()
                 .ForMember(m => m.timecr, d => d.MapFrom(z => DateTime.Now))
                 //.ForMember(m => m.code, d => d.MapFrom(z => z.code == null || z.code == Guid.Empty ? Guid.NewGuid() : z.code))
                 .ForMember(m => m.patcode, d => d.MapFrom(z => i_MediRegisterModel.patcode))
                 .ForMember(m => m.managecode, d => d.MapFrom(z => i_MediRegisterModel.managecode))
                 .ForMember(m => m.depcode, d => d.MapFrom(z => i_MediRegisterModel.managecode))
                 .ForMember(m => m.placepoint, d => d.MapFrom(z => "1"))
                 .ForMember(m => m.patienttype, d => d.MapFrom(z => "1"))

                 .ForMember(m => m.patienttype, d => d.MapFrom(z => i_MediRegisterModel.patienttype))
                 .ForMember(m => m.objectcode, d => d.MapFrom(z => i_MediRegisterModel.objectcode))


                .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            });
            iPayServices = cfgPayServices.CreateMapper();
            return iPayServices.Map<List<EmrServicesOrderModel>, List<emrservicesorder>>(i_LstEmrServicesOrderModel);
        }
        //RegisterHi
        internal emrregisterhi MapFromModelToEntityLstRegisterHi(RegisterHiModel i_RegisterHiReadModel, emrregister i_MediRegisterModel)
        {
            cfgPayServices = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RegisterHiModel, emrregisterhi>()
                 .ForMember(m => m.timecr, d => d.MapFrom(z => DateTime.Now))
                 //.ForMember(m => m.code, d => d.MapFrom(z => z.code == null || z.code == Guid.Empty ? Guid.NewGuid() : z.code))
                 .ForMember(m => m.patcode, d => d.MapFrom(z => i_MediRegisterModel.patcode))
                 .ForMember(m => m.managecode, d => d.MapFrom(z => i_MediRegisterModel.managecode))
                .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            });
            iPayServices = cfgPayServices.CreateMapper();
            return iPayServices.Map<RegisterHiModel, emrregisterhi>(i_RegisterHiReadModel);
        }
        internal emrclinicqueue MapFromModelToEntityEmrClinicQueue(ClinicQueueModel i_ClinicQueueModel)
        {
            cfgPayServices = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClinicQueueModel, emrclinicqueue>()
                 .ForMember(m => m.timecr, d => d.MapFrom(z => DateTime.Now))
                 .ForMember(m => m.timeup, d => d.MapFrom(z => DateTime.Now))
                 .ForMember(m => m.patcode, d => d.MapFrom(z => i_ClinicQueueModel.patcode))
                .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            });
            iemrregister = cfgPayServices.CreateMapper();
            return iemrregister.Map<ClinicQueueModel, emrclinicqueue>(i_ClinicQueueModel);
        }
        //Patient
        //internal emrpatient MapFromModelToEntityemrpatient(PatientModel i_emrpatientModel)
        //{
        //    cfgPayServices = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<PatientModel, emrpatient>()
        //         .ForMember(m => m.timecr, d => d.MapFrom(z => DateTime.Now))
        //        .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
        //    });
        //    iemrpatient = cfgPayServices.CreateMapper();
        //    return iemrpatient.Map<PatientModel, emrpatient>(i_emrpatientModel);
        //}
        //internal PatientReadModel MapFromEntityToReadModelPatient(emrpatient i_PatientEntity)
        //{
        //    cfgPayServices = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<emrpatient, PatientReadModel>()
        //         .ForMember(m => m.timecr, d => d.MapFrom(z => DateTime.Now))
        //        .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
        //    });
        //    iemrpatient = cfgPayServices.CreateMapper();
        //    return iemrpatient.Map<emrpatient, PatientReadModel>(i_PatientEntity);
        //}
        //internal List<PatientReadModel> MapFromEntityToReadModelListPatient(List<emrpatient> i_LstPatientEntity)
        //{
        //    cfgPayServices = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<emrpatient, PatientReadModel>()
        //        // .ForMember(m => m.timecr, d => d.MapFrom(z => DateTime.Now))
        //        .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
        //    });
        //    iemrpatient = cfgPayServices.CreateMapper();
        //    return iemrpatient.Map<List<emrpatient>, List<PatientReadModel>>(i_LstPatientEntity);
        //}
        //BHYT
        //internal emrpatienthi MapFromModelToEntityMediBHYT(PatientHiModel i_MediBHYTModel)
        //{
        //    return iMediBHYT.Map<PatientHiModel, emrpatienthi>(i_MediBHYTModel);
        //}
        //Survival
        //internal emrpatientsurvival MapFromModelToEntityemrpatientsurvival(PatientSuvivalModel i_emrpatientsurvivalModel, emrpatient i_emrpatient)
        //{
        //    cfgemrpatientelation = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<PatientSuvivalModel, emrpatientsurvival>()
        //         .ForMember(m => m.timecr, d => d.MapFrom(z => DateTime.Now))
        //         .ForMember(m => m.mmyy, d => d.MapFrom(z => DateTime.Now))

        //         //   .ForMember(m => m.cod, d => d.MapFrom(z => z.relationcode == null || z.relationcode == Guid.Empty ? Guid.NewGuid() : z.relationcode))
        //         .ForMember(m => m.patcode, d => d.MapFrom(z => i_emrpatient.patcode))
        //        .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
        //    });
        //    iMediSurvira = cfgemrpatientelation.CreateMapper();
        //    return iMediSurvira.Map<PatientSuvivalModel, emrpatientsurvival>(i_emrpatientsurvivalModel);
        //}
        ////Relation
        //internal emrpatientelation MapFromModelToEntityemrpatientelation(PatientRelationModel i_emrpatientelationModel, emrpatient i_emrpatient)
        //{
        //    cfgemrpatientelation = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<PatientRelationModel, emrpatientelation>()
        //         //.ForMember(m => m.timecr, d => d.MapFrom(z => DateTime.Now))
        //         //.ForMember(m => m.relationcode, d => d.MapFrom(z => z.relationcode == null || z.relationcode == Guid.Empty ? Guid.NewGuid() : z.relationcode))
        //         .ForMember(m => m.patcode, d => d.MapFrom(z => i_emrpatient.patcode))
        //        .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
        //    });
        //    iemrpatientelation = cfgemrpatientelation.CreateMapper();
        //    return iemrpatientelation.Map<PatientRelationModel, emrpatientelation>(i_emrpatientelationModel);
        //}

        //internal PatientHiReadModel MapFromEntityToReadModelPatientHi(emrpatienthi i_emrpatienthiEntity)
        //{
        //    cfgemrpatient = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<emrpatienthi, PatientHiReadModel>()
        //        .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
        //    });
        //    iemrpatient = cfgemrpatient.CreateMapper();
        //    return iemrpatient.Map<emrpatienthi, PatientHiReadModel>(i_emrpatienthiEntity);
        //}
        //internal PatientSuvivalReadModel MapFromEntityToReadModelPatientSuvival(emrpatientsurvival i_emrpatientsurvival)
        //{
        //    cfgemrpatient = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<emrpatientsurvival, PatientSuvivalReadModel>()
        //        .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
        //    });
        //    iemrpatient = cfgemrpatient.CreateMapper();
        //    return iemrpatient.Map<emrpatientsurvival, PatientSuvivalReadModel>(i_emrpatientsurvival);
        //}
        //internal PatientRelationReadModel MapFromEntityToReadModelPatientRelation(emrPatientRelation i_emrpatienthiEntity)
        //{
        //    cfgemrpatient = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<emrpatienthi, PatientHiModel>()
        //        .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
        //    });
        //    iemrpatient = cfgemrpatient.CreateMapper();
        //    return iemrpatient.Map<emrpatienthi, PatientHiModel>(i_emrpatienthiEntity);
        //}
    }
}
