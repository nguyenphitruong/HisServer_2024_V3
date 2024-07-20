using AutoMapper;
using Emr.Domain.Entities.Share.Patient;
using Emr.Domain.Model.Share.Patient;
using Emr.Domain.Model.Share.Patient.ValuesObject;
using Emr.Domain.ReadModel.Share.Patients;
using Emr.Domain.ReadModel.Share.Patients.ValuesObject;
using System;
using System.Collections.Generic;

namespace Emr.Infrastructure.RepoMapper.Share.Patient
{
    public class PatientEntityMapper
    {
        internal MapperConfiguration configMap;
        internal IMapper iMapper;
        internal PatientReadModel MapFromEntityToReadModelPatient(EMR_patient i_PatientEntity)
        {
            configMap = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EMR_patient, PatientReadModel>()
                 .ForMember(m => m.timecr, d => d.MapFrom(z => DateTime.Now))
                .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            });
            iMapper = configMap.CreateMapper();
            return iMapper.Map<EMR_patient, PatientReadModel>(i_PatientEntity);
        }
        internal List<PatientReadModel> MapFromEntityToReadModelListPatient(List<EMR_patient> i_LstPatientEntity)
        {
            configMap = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EMR_patient, PatientReadModel>()
                 .ForMember(m => m.timecr, d => d.MapFrom(z => DateTime.Now))
                .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            });
            iMapper = configMap.CreateMapper();
            return iMapper.Map<List<EMR_patient>, List<PatientReadModel>>(i_LstPatientEntity);
        }
        internal PatientHiReadModel MapFromEntityToReadModelPatientHi(EMR_patienthi i_emrpatienthiEntity)
        {
            configMap = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EMR_patienthi, PatientHiReadModel>()
                .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            });
            iMapper = configMap.CreateMapper();
            return iMapper.Map<EMR_patienthi, PatientHiReadModel>(i_emrpatienthiEntity);
        }
        internal PatientSuvivalReadModel MapFromEntityToReadModelPatientSuvival(emrpatientsurvival i_emrpatientsurvival)
        {
            configMap = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<emrpatientsurvival, PatientSuvivalReadModel>()
                .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            });
            iMapper = configMap.CreateMapper();
            return iMapper.Map<emrpatientsurvival, PatientSuvivalReadModel>(i_emrpatientsurvival);
        }
        //internal List<PatientReadModel> MapFromEntityToReadModelListPatient(List<emrpatient> i_LstPatientEntity)
        //{
        //    configMap = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<emrpatient, PatientReadModel>()
        //        // .ForMember(m => m.timecr, d => d.MapFrom(z => DateTime.Now))
        //        .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
        //    });
        //    iMapper = configMap.CreateMapper();
        //    return iMapper.Map<List<emrpatient>, List<PatientReadModel>>(i_LstPatientEntity);
        //}
        internal EMR_patient MapFromModelToEntityemrpatient(PatientModel i_emrpatientModel)
        {
            configMap = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PatientModel, EMR_patient>()
                 .ForMember(m => m.timecr, d => d.MapFrom(z => DateTime.Now))
                 .ForMember(m => m.patid, d => d.MapFrom(z => string.IsNullOrEmpty(z.patid) ? Guid.NewGuid().ToString() : z.patid))
                .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            });
            iMapper = configMap.CreateMapper();
            return iMapper.Map<PatientModel, EMR_patient>(i_emrpatientModel);
        }
        internal emrpatientsurvival MapFromModelToEntityemrpatientsurvival(PatientSuvivalModel i_emrpatientsurvivalModel, EMR_patient i_emrpatient)
        {
            configMap = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PatientSuvivalModel, emrpatientsurvival>()
                 .ForMember(m => m.timecr, d => d.MapFrom(z => DateTime.Now))
                 .ForMember(m => m.mmyy, d => d.MapFrom(z => DateTime.Now))

                 //   .ForMember(m => m.cod, d => d.MapFrom(z => z.relationcode == null || z.relationcode == Guid.Empty ? Guid.NewGuid() : z.relationcode))
                 .ForMember(m => m.patcode, d => d.MapFrom(z => i_emrpatient.patcode))
                .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            });
            iMapper = configMap.CreateMapper();
            return iMapper.Map<PatientSuvivalModel, emrpatientsurvival>(i_emrpatientsurvivalModel);
        }
        //Relation
        internal emrpatientelation MapFromModelToEntityemrpatientelation(PatientRelationModel i_emrpatientelationModel, EMR_patient i_emrpatient)
        {
            configMap = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PatientRelationModel, emrpatientelation>()
                 //.ForMember(m => m.timecr, d => d.MapFrom(z => DateTime.Now))
                 //.ForMember(m => m.relationcode, d => d.MapFrom(z => z.relationcode == null || z.relationcode == Guid.Empty ? Guid.NewGuid() : z.relationcode))
                 .ForMember(m => m.patcode, d => d.MapFrom(z => i_emrpatient.patcode))
                .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            });
            iMapper = configMap.CreateMapper();
            return iMapper.Map<PatientRelationModel, emrpatientelation>(i_emrpatientelationModel);
        }
        internal EMR_patienthi MapFromModelToEntityMediBHYT(PatientHiModel i_MediBHYTModel)
        {
            return iMapper.Map<PatientHiModel, EMR_patienthi>(i_MediBHYTModel);
        }
    }
}
