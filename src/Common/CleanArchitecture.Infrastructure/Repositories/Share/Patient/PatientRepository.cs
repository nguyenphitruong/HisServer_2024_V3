using Emr.Domain.Entities.Share.Patient;
using Emr.Domain.Model.Cates;
using Emr.Domain.Model.Share.Patient;
using Emr.Domain.ReadModel.Share.Patients;
using Emr.Domain.ReadModel.Share.Patients.ValuesObject;
using Emr.Infrastructure.Persistence;
using Emr.Infrastructure.RepoMapper.Share.Patient;
using Emr.Infrastructure.Repositories.Cates;
using Emr.Infrastructure.Repositories.Sys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Emr.Infrastructure.Repositories.Share.Patient
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IPatientRepository CateRepo;
        private PatientEntityMapper _mapper;
        private readonly IMemoryCache caching;
        private MyDbShareContext dbContext;
        private SysNoserilineRepository sysNoserilineRepo;

        public PatientRepository(MyDbShareContext i_dbContext)
        {
            dbContext = i_dbContext;
            _mapper = new PatientEntityMapper();
            sysNoserilineRepo = new SysNoserilineRepository(dbContext);
        }

        //public PatientRepository()
        //{
        //    _mapper = new PatientEntityMapper();
        //}

        //public PatientRepository(MydbContextFactory i_dbContext)
        //{
        //    dbContext = i_dbContext;
        //}
        public string Constanst { get; private set; }
        #region GetRepository
        public PatientReadModel GetPatientBypatcode(string i_patcode)
        {
            PatientReadModel PatientReadmodel = null;
            try
            {
                EMR_patient PatientEntity = new EMR_patient();
                PatientEntity = dbContext.EMR_patients.AsNoTracking().Where(x => x.patcode.Trim() == i_patcode).FirstOrDefault();
                if (PatientEntity == null)
                {
                    return PatientReadmodel;
                }
                else
                {
                    PatientReadmodel = _mapper.MapFromEntityToReadModelPatient(PatientEntity);
                    if (PatientReadmodel != null)
                    {
                        //PatientHiReadModel PatientHi = new PatientHiReadModel();
                        //PatientRelationReadModel PatientRelation = new PatientRelationReadModel();
                        //PatientSuvivalReadModel PatientSuvival = new PatientSuvivalReadModel();

                        //EMR_patienthi emrpatienthiEntity = new EMR_patienthi();
                        //emrpatienthiEntity = dbContext.EMR_patienthis.AsNoTracking().Where(x => x.active == 1 && x.patcode == PatientReadmodel.patcode).FirstOrDefault();
                        //if (emrpatienthiEntity != null)
                        //{
                        //    PatientHi = _mapper.MapFromEntityToReadModelPatientHi(emrpatienthiEntity);
                        //    PatientReadmodel.PatientHi = PatientHi;
                        //}
                        //emrpatientsurvival emrpatientsurvivalEntity = new emrpatientsurvival();
                        //emrpatientsurvivalEntity = dbContext.emrpatientsurvivals.AsNoTracking().Where(x => x.patcode == PatientReadmodel.patcode && x.active == 1).FirstOrDefault();
                        //if (emrpatientsurvivalEntity != null)
                        //{
                        //    PatientSuvival = _mapper.MapFromEntityToReadModelPatientSuvival(emrpatientsurvivalEntity);
                        //    PatientReadmodel.PatientSuvival = PatientSuvival;
                        //}
                        //Get RegisterHistory
                        //var checkRegisterHistory = dbContext.emrregisters.Where(x => x.patcode == i_patcode).ToList();
                        //if (checkRegisterHistory.Count > 0)
                        //{
                        //    PatientReadmodel.RegisterHistory = GetRegisterHistory(i_patcode);
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return PatientReadmodel;
        }
        public List<PatientReadModel> GetListPatientByListPatCode(List<string> i_Lstpatcode)
        {
            List<PatientReadModel> LstPatientReadModel = null;
            try
            {
                List<EMR_patient> LstPatientEntity = new List<EMR_patient>();
                LstPatientEntity = dbContext.EMR_patients.AsNoTracking().Where(x => i_Lstpatcode.Contains(x.patcode)).ToList();

                if (LstPatientEntity == null)
                {
                    return LstPatientReadModel;
                }
                else
                {
                    // LstPatientReadModel = _mapper.MapFromEntityToReadModelListPatient(LstPatientEntity);
                    //if (LstPatientReadModel != null)
                    //{
                    //    PatientHiReadModel PatientHi = new PatientHiReadModel();
                    //    PatientRelationReadModel PatientRelation = new PatientRelationReadModel();
                    //    PatientSuvivalReadModel PatientSuvival = new PatientSuvivalReadModel();

                    //    emrpatienthi emrpatienthiEntity = new emrpatienthi();
                    //    emrpatienthiEntity = dbContext.EMR_patienthi.AsNoTracking().Where(x => x.active == 1 && x.patcode == PatientReadmodel.patcode).FirstOrDefault();
                    //    if (emrpatienthiEntity != null)
                    //    {
                    //        PatientHi = _mapper.MapFromEntityToReadModelPatientHi(emrpatienthiEntity);
                    //        PatientReadmodel.PatientHi = PatientHi;
                    //    }
                    //    emrpatientsurvival emrpatientsurvivalEntity = new emrpatientsurvival();
                    //    emrpatientsurvivalEntity = dbContext.emrpatientsurvivals.AsNoTracking().Where(x => x.patcode == PatientReadmodel.patcode && x.active == 1).FirstOrDefault();
                    //    if (emrpatientsurvivalEntity != null)
                    //    {
                    //        PatientSuvival = _mapper.MapFromEntityToReadModelPatientSuvival(emrpatientsurvivalEntity);
                    //        PatientReadmodel.PatientSuvival = PatientSuvival;
                    //    }
                    //    //Get RegisterHistory
                    //    //var checkRegisterHistory = dbContext.emrregisters.Where(x => x.patcode == i_patcode).ToList();
                    //    //if (checkRegisterHistory.Count > 0)
                    //    //{
                    //    //    PatientReadmodel.RegisterHistory = GetRegisterHistory(i_patcode);
                    //    //}
                    //}
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return LstPatientReadModel;
        }
        public List<PatientReadModel> GetPatientByFindContent(string i_findcontent)
        {
            List<PatientReadModel> _result = new List<PatientReadModel>();
            try
            {
                List<EMR_patient> lstPatientEntity = new List<EMR_patient>();
                lstPatientEntity = dbContext.EMR_patients.Where(x => x.findcontent.Trim() == i_findcontent).ToList();
                if (lstPatientEntity.Count > 0)
                {
                    _result = _mapper.MapFromEntityToReadModelListPatient(lstPatientEntity);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _result;
        }
        #endregion
        #region SaveRepository
        public PatientReadModel SavePatient(PatientModel i_PatientModel)
        {
            PatientReadModel result = new PatientReadModel();
            try
            {
                string mabn = sysNoserilineRepo.CreateHospCodeForCommon(1, "HOSPCODE");

                EMR_patient patientEntity = _mapper.MapFromModelToEntityemrpatient(i_PatientModel);

                patientEntity.patcode = string.IsNullOrEmpty(patientEntity.patcode) ? sysNoserilineRepo.CreateHospCodeForCommon(1, "HOSPCODE") : patientEntity.patcode;

                patientEntity.patid = Guid.NewGuid().ToString();
                patientEntity.mmyys = DateTime.Now.Month.ToString();
                patientEntity.yyyy = DateTime.Now.Year.ToString(); ;
                patientEntity.timecr = DateTime.Now;
                patientEntity.timeup = DateTime.Now;


                List<EMR_patient> lstPatientEntity = new List<EMR_patient>();
                lstPatientEntity.Add(patientEntity);
                if (lstPatientEntity.Count > 0)
                {
                    lstPatientEntity[0].timecr = DateTime.Now;
                    dbContext.BulkMerge(lstPatientEntity);

                    result = _mapper.MapFromEntityToReadModelPatient(patientEntity);
                }

                //if (i_PatientModel != null)
                //{
                //    //1.2.1.BHYT
                //    if (i_PatientModel.PatientHi != null)
                //    {
                //        List<emrpatienthi> lstPatientHiEntity = new List<emrpatienthi>();
                //        i_PatientModel.PatientHi.patcode = i_PatientModel.patcode;
                //        lstPatientHiEntity.Add(_mapper.MapFromModelToEntityMediBHYT(i_PatientModel.PatientHi));
                //        if (lstPatientHiEntity.Count > 0)
                //        {
                //            dbContext.BulkMerge(lstPatientHiEntity);
                //        }
                //    }
                //    //1.2.2.Survival
                //    if (i_PatientModel.PatientSuvival != null)
                //    {
                //        List<emrpatientsurvival> lstPatientsurvivalEntity = new List<emrpatientsurvival>();
                //        i_PatientModel.PatientSuvival.patcode = i_PatientModel.patcode;
                //        lstPatientsurvivalEntity.Add(_mapper.MapFromModelToEntityemrpatientsurvival(i_PatientModel.PatientSuvival, patientEntity));
                //        if (lstPatientsurvivalEntity.Count > 0)
                //        {
                //            dbContext.BulkInsert(lstPatientsurvivalEntity);
                //        }
                //    }
                //    //1.2.3.Relation
                //    //if (i_PatientModel.PatientRelation != null)
                //    //{

                //    //    List<emrpatientelation> lstPatientelationEntity = new List<emrpatientelation>();
                //    //    i_PatientModel.PatientRelation.patcode = i_PatientModel.patcode;
                //    //    lstPatientelationEntity.Add(_mapper.MapFromModelToEntityemrpatientelation(i_PatientModel.PatientRelation, patientEntity));
                //    //    if (lstPatientelationEntity.Count > 0)
                //    //    {
                //    //        dbContext.BulkMerge(lstPatientelationEntity);
                //    //    }
                //    //}

                //}

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        #endregion
    }
}
