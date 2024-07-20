using Emr.Domain.Entities.Share.Patient;
using Emr.Domain.Model.Share.Patient;
using Emr.Domain.ReadModel.Share.Patients.ValuesObject;
using Emr.Domain.ReadModel.Share.Patients;
using Emr.Infrastructure.Persistence;
using Emr.Infrastructure.RepoMapper.Share.Patient;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emr.Domain.Model.StoreProduce;
using Microsoft.EntityFrameworkCore;
using Emr.Domain.ReadModel.Pha;
using Emr.Domain.Model.Share;
using Microsoft.Data.SqlClient;
using Emr.Domain.Entities.Pha;

namespace Emr.Infrastructure.Repositories.StoreProduce
{
    public class StoreProduceRepository : IStoreProduceRepository
    {
        private readonly IPatientRepository CateRepo;
        private PatientEntityMapper _mapper;
        private readonly IMemoryCache caching;
        private MyDbShareContext dbContext;

        public StoreProduceRepository(MyDbShareContext i_dbContext)
        {
            dbContext = i_dbContext;
            _mapper = new PatientEntityMapper();
        }

        public string Constanst { get; private set; }
        #region GetRepository
        public List<PHA_inventorylReadModel> GetSP_InventoryBySchema(List<SchemasMMYYModel> i_Schemas)
        {
            List<PHA_inventorylReadModel> results = new List<PHA_inventorylReadModel>();
            List<PHA_inventoryl> results1 = new List<PHA_inventoryl>();
            try
            {
                var lstParaSchema = new SqlParameter[]
                    {
                            new SqlParameter()
                            {
                                ParameterName = "@mmyynames",
                                SqlDbType = System.Data.SqlDbType.VarChar,
                                Value = "0124",
                                //Value = i_Schemas.Select(s=>s.mmyyName).ToList().ToString(),
                            }
                            //new SqlParameter()
                            //{
                            //    ParameterName = "@SchemaNew",
                            //    SqlDbType = System.Data.SqlDbType.NVarChar,
                            //    Value = SchemaNewValue
                            //}
                    };
                     results1 = dbContext.PHA_inventoryl.FromSqlRaw($"EXEC  dbo.GetSP_InventoryBySchemaFinal @mmyynames", lstParaSchema).ToList();


                //results = dbContext.Database.ExecuteSqlRaw($"EXEC  dbo.sp_create_schema_mmyy @SchemaCurent,@SchemaNew", lstParaSchema);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return results;
        }

        //public bool CreateStructureDataNew(string i_mmyy)
        //{
        //    bool bResult = false;
        //    try
        //    {
        //        //01.Kiểm tra đồng bộ dữ liệu chưa

        //        //02.Tạo Schema tháng năm hiện tại

        //        //03.Coppy cấu trúc table 

        //        //04.Cật nhật dữ liệu tồn kho tháng mới

        //        string Schemaname = "mmyy";
        //        string SchemaNewValue = Schemaname + i_mmyy;

        //        var sysSchemaSelect = dbContext.sysschemas.AsNoTracking().Where(x => x.siterf == 1 && x.active == 1).FirstOrDefault();
        //        //var sysSchemaNewCheck = sysSchemaSelect.mmyy;

        //        if (sysSchemaSelect != null)
        //        {
        //            var lstParaSchema = new SqlParameter[]
        //            {
        //                    new SqlParameter()
        //                    {
        //                        ParameterName = "@SchemaCurent",
        //                        SqlDbType = System.Data.SqlDbType.NVarChar,
        //                        Value = sysSchemaSelect.name
        //                    },
        //                    new SqlParameter()
        //                    {
        //                        ParameterName = "@SchemaNew",
        //                        SqlDbType = System.Data.SqlDbType.NVarChar,
        //                        Value = SchemaNewValue
        //                    }
        //            };
        //            var resultExecCreateSchema = dbContext.Database.ExecuteSqlRaw($"EXEC  dbo.sp_create_schema_mmyy @SchemaCurent,@SchemaNew", lstParaSchema);

        //            if (resultExecCreateSchema != null)
        //            {
        //                var lstPara = new SqlParameter[]
        //                        {
        //                        new SqlParameter()
        //                        {
        //                            ParameterName = "@mmyycurent",
        //                            SqlDbType = System.Data.SqlDbType.NVarChar,
        //                            Value =  sysSchemaSelect.mmyy
        //                        },
        //                         new SqlParameter()
        //                        {
        //                            ParameterName = "@mmyynew",
        //                            SqlDbType = System.Data.SqlDbType.NVarChar,
        //                            Value = i_mmyy
        //                        },
        //                        };
        //                var resultExecCreateStructoreTable = dbContext.Database.ExecuteSqlRaw($"EXEC  dbo.sp_create_structure_table_final @mmyycurent,@mmyynew ", lstPara);

        //                if (resultExecCreateStructoreTable != null)
        //                {
        //                    var lstTableNew = dbContext.systables.AsNoTracking().Where(x => x.active == 1 && x.mmyy == i_mmyy).ToList();
        //                }


        //            }
        //            bResult = true;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return bResult;
        //}

        //public List<PatientReadModel> GetListPatientByListPatCode(List<string> i_Lstpatcode)
        //{
        //    List<PatientReadModel> LstPatientReadModel = null;
        //    try
        //    {
        //        List<emrpatient> LstPatientEntity = new List<emrpatient>();
        //        LstPatientEntity = dbContext.emrpatients.AsNoTracking().Where(x => i_Lstpatcode.Contains(x.patcode)).ToList();

        //        if (LstPatientEntity == null)
        //        {
        //            return LstPatientReadModel;
        //        }
        //        else
        //        {
        //            // LstPatientReadModel = _mapper.MapFromEntityToReadModelListPatient(LstPatientEntity);
        //            //if (LstPatientReadModel != null)
        //            //{
        //            //    PatientHiReadModel PatientHi = new PatientHiReadModel();
        //            //    PatientRelationReadModel PatientRelation = new PatientRelationReadModel();
        //            //    PatientSuvivalReadModel PatientSuvival = new PatientSuvivalReadModel();

        //            //    emrpatienthi emrpatienthiEntity = new emrpatienthi();
        //            //    emrpatienthiEntity = dbContext.EMR_patienthi.AsNoTracking().Where(x => x.active == 1 && x.patcode == PatientReadmodel.patcode).FirstOrDefault();
        //            //    if (emrpatienthiEntity != null)
        //            //    {
        //            //        PatientHi = _mapper.MapFromEntityToReadModelPatientHi(emrpatienthiEntity);
        //            //        PatientReadmodel.PatientHi = PatientHi;
        //            //    }
        //            //    emrpatientsurvival emrpatientsurvivalEntity = new emrpatientsurvival();
        //            //    emrpatientsurvivalEntity = dbContext.emrpatientsurvivals.AsNoTracking().Where(x => x.patcode == PatientReadmodel.patcode && x.active == 1).FirstOrDefault();
        //            //    if (emrpatientsurvivalEntity != null)
        //            //    {
        //            //        PatientSuvival = _mapper.MapFromEntityToReadModelPatientSuvival(emrpatientsurvivalEntity);
        //            //        PatientReadmodel.PatientSuvival = PatientSuvival;
        //            //    }
        //            //    //Get RegisterHistory
        //            //    //var checkRegisterHistory = dbContext.emrregisters.Where(x => x.patcode == i_patcode).ToList();
        //            //    //if (checkRegisterHistory.Count > 0)
        //            //    //{
        //            //    //    PatientReadmodel.RegisterHistory = GetRegisterHistory(i_patcode);
        //            //    //}
        //            //}
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return LstPatientReadModel;
        //}
        //public List<PatientReadModel> GetPatientByFindContent(string i_findcontent)
        //{
        //    List<PatientReadModel> _result = new List<PatientReadModel>();
        //    try
        //    {
        //        List<emrpatient> lstPatientEntity = new List<emrpatient>();
        //        lstPatientEntity = dbContext.emrpatients.Where(x => x.findcontent.Trim() == i_findcontent).ToList();
        //        if (lstPatientEntity.Count > 0)
        //        {
        //            _result = _mapper.MapFromEntityToReadModelListPatient(lstPatientEntity);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return _result;
        //}
        //#endregion
        //#region SaveRepository
        //public PatientReadModel SavePatient(PatientModel i_PatientModel)

        //{
        //    PatientReadModel result = new PatientReadModel();
        //    try
        //    {

        //        emrpatient patientEntity = _mapper.MapFromModelToEntityemrpatient(i_PatientModel);
        //        List<emrpatient> lstPatientEntity = new List<emrpatient>();
        //        lstPatientEntity.Add(patientEntity);
        //        if (lstPatientEntity.Count > 0)
        //        {
        //            lstPatientEntity[0].timecr = DateTime.Now;
        //            dbContext.BulkMerge(lstPatientEntity);
        //        }

        //        if (i_PatientModel != null)
        //        {
        //            //1.2.1.BHYT
        //            if (i_PatientModel.PatientHi != null)
        //            {
        //                List<emrpatienthi> lstPatientHiEntity = new List<emrpatienthi>();
        //                i_PatientModel.PatientHi.patcode = i_PatientModel.patcode;
        //                lstPatientHiEntity.Add(_mapper.MapFromModelToEntityMediBHYT(i_PatientModel.PatientHi));
        //                if (lstPatientHiEntity.Count > 0)
        //                {
        //                    dbContext.BulkMerge(lstPatientHiEntity);
        //                }
        //            }
        //            //1.2.2.Survival
        //            if (i_PatientModel.PatientSuvival != null)
        //            {
        //                List<emrpatientsurvival> lstPatientsurvivalEntity = new List<emrpatientsurvival>();
        //                i_PatientModel.PatientSuvival.patcode = i_PatientModel.patcode;
        //                lstPatientsurvivalEntity.Add(_mapper.MapFromModelToEntityemrpatientsurvival(i_PatientModel.PatientSuvival, patientEntity));
        //                if (lstPatientsurvivalEntity.Count > 0)
        //                {
        //                    dbContext.BulkInsert(lstPatientsurvivalEntity);
        //                }
        //            }

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return result;
        //}
        #endregion
    }
}
