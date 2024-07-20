using Emr.Domain.Common;
using Emr.Domain.Entities.Emr.Outclinic;
using Emr.Domain.Entities.Emr.ServiceOrder;
using Emr.Domain.Model.Emr.Clinics;
using Emr.Domain.Model.Pha.Prescription;
using Emr.Domain.ReadModel.Emr.Clinic;
using Emr.Domain.ReadModel.Share.Patients.ValuesObject;
using Emr.Infrastructure.Constans;
using Emr.Infrastructure.Hepper.Exceptions;
using Emr.Infrastructure.Persistence;
using Emr.Infrastructure.RepoMapper.Emr.Outclinic;
using Emr.Infrastructure.Repositories.Pha;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Xml.Linq;
using Emr.Infrastructure.Repositories.Share.Patient;
using Emr.Infrastructure.Hepper.Provider;
using Emr.Infrastructure.Hepper.Lib;
using Emr.Domain.Model.Share;

namespace Emr.Infrastructure.Repositories.Clinic
{
    public class MediClinicRepository : IMediClinicRepository
    {
        private MydbContext dbContext;
 
        OutclinicEntityMapper mapper;
        PhaRepository PhaRepo;
        PatientRepository patienRepo;
        public MediClinicRepository(MydbContext i_Context)
        {
            dbContext = i_Context;
            mapper = new OutclinicEntityMapper();
            patienRepo = new PatientRepository(new MyDbShareContext(new DbContextOptionsBuilder<MyDbShareContext>().UseSqlServer(ConnectionStrings.DefaultConnection).Options));
        }
        public List<MediClinicModel> GetAll()
        {
            var i_lstsysuser = new List<MediClinicModel>();
            try
            {
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return i_lstsysuser;
        }
        public OutclinicReadModel GetOutClinicByCode(string i_code)
        {
            OutclinicReadModel result = new OutclinicReadModel();

            try
            {
                var OutEntity = dbContext.EMR_medioutclinics.AsNoTracking()
                        .Where(x => x.active == 1 && x.idline == i_code && x.statuscode == 3).FirstOrDefault();
                if (OutEntity != null)
                {
                    result = mapper.MapFromEntityToReadModelModelOutclinic(OutEntity);
                    if (result != null)
                    {
                        var lstServiceOrderEntity = dbContext.EMR_serviceorder.AsNoTracking()
                        .Where(x => x.active == 1 && x.idline == i_code).ToList();
                        if (lstServiceOrderEntity != null)
                        {
                            result.LstServicesOrder = mapper.MapFromEntityToReadModelListOutServicesOrder(lstServiceOrderEntity);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public List<OutClinicPatientExamReadModel> GetListPatientWaitExamsBydate(IPara i_jsonICarePara)
        {
            List<OutClinicPatientExamReadModel> result = new List<OutClinicPatientExamReadModel>();

            try
            {
                //List<SchemasMMYYModel> lstmmyys = new List<SchemasMMYYModel>();

                //lstmmyys = Library.GetSchemaNamesByFromToDate(Library.GetFomatDate(i_FromDate), Library.GetFomatDate(i_ToDate).AddDays(1));
                //lstmmyys = lstmmyys.Where(x => x.mmyy != DateTime.Now.ToString("MMyy")).ToList();

                DateTime dateFrom = DateTime.Now;
                DateTime dateTo = DateTime.Now;
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.LongDatePattern = "yyyy/MM/dd HH:mm:ss";
                format.DateSeparator = "/";

                dateFrom = Convert.ToDateTime(i_jsonICarePara.lstPara.Where(x => x.fieldname.Equals(nameof(dateFrom))).FirstOrDefault().value.ToString(), format);
                dateTo = Convert.ToDateTime(i_jsonICarePara.lstPara.Where(x => x.fieldname.Equals(nameof(dateTo))).FirstOrDefault().value.ToString(), format);
                dateTo = dateTo.AddDays(1);

                var lstRegisterBydate = dbContext.emrregisters.AsNoTracking()
                    .Where(x => x.active == 1
                    && x.registerdate >= dateFrom
                    && x.registerdate < dateTo).ToList();

                if (lstRegisterBydate.Count > 0)
                {
                    var lstpatcode = lstRegisterBydate.Select(s => s.patcode).ToList();
                    //var lstPatientInfoBypatcode = dbContext.emrpatients.AsNoTracking()
                    //    .Where(x => x.active == 1 && lstpatcode.Contains(x.patcode)).ToList();

                    var lstPatientInfoBypatcode = patienRepo.GetListPatientByListPatCode(lstpatcode);


                   // var lstPatientHiInfoBypatcode = dbContext.EMR_patienthi.AsNoTracking()
                   //.Where(x => x.active == 1 && lstpatcode.Contains(x.patcode)).ToList();


                    var lstManagerCode = lstRegisterBydate.Select(s => s.managecode).ToList();
                    var lstRegisterHiByManagerCode = dbContext.emrregisterhis.AsNoTracking()
                        .Where(x => x.active == 1 && lstManagerCode.Contains(x.managecode)).ToList();

                    var lstClinicQueByManagerCode = dbContext.emrclinicqueues.AsNoTracking()
                    .Where(x => x.active == 1 && lstManagerCode.Contains(x.managercode)
                    && x.timecr >= dateFrom
                 && x.timecr < dateTo
                 ).ToList();

                    //var lstServiceOrderByManagerCode = dbContext.EMR_serviceorders.AsNoTracking()
                    //   .Where(x => x.active == 1 && lstManagerCode.Contains(x.managecode)
                    //   && x.servicesorderdate >= dateFrom
                    //&& x.servicesorderdate < dateTo
                    //&& x.placepoint == "1").ToList();

                    result = (from reg in lstRegisterBydate
                              join ser in lstClinicQueByManagerCode on reg.managecode.Trim() equals ser.managercode.Trim()
                              //join ser in lstServiceOrderByManagerCode on reg.managecode.Trim() equals ser.managecode.Trim()
                              join pat in lstPatientInfoBypatcode on reg.patcode.Trim() equals pat.patcode.Trim()
                              select new OutClinicPatientExamReadModel
                              {
                                  managercode = reg.managecode.Trim(),
                                  patcode = reg.patcode,
                                  name = pat.name,
                                  //sexname = pat.sexname,
                                  birthday = pat.birthday,
                                  birthyear = pat.birthyear,
                                  //age = pat.age,
                                  phonenumber = pat.phonenumber,
                                  address = pat.addresworkplace,
                                  objectcode = reg.objectcode.Trim(),
                                  objectname = reg.objectname,

                                  //nohi = reghi == null ? null : reghi.nohi,
                                  //live = reghi == null ? null : reghi.level,
                                  //ratehi = reg == null ? null : reghi.ratehi,
                                  // strday = pathi == null ? null : pathi.fromdate,
                                  //endday = pathi == null ? null : pathi.totate,

                                  servicecode = ser.servicecode.Trim(),
                                  servicename = ser.servicename,
                                  medexacode = reg.medexacode.Trim(),
                                  medexaname = reg.medexaname,
                                  registerdate = reg.registerdate,
                                  examdate = DateTime.Now,
                                  examfinishdate = null,
                                  status = 0,
                                  active = 1,
                                  reson = reg.reson,
                              }
                              ).ToList();

                    if (result.Count > 0)
                    {
                        //result.ForEach(f => f.Suvival = dbContext.emrpatientsurvivals.AsNoTracking()
                        //.Where(x => x.active == 1 && x.patcode == f.patcode)
                        //.Select(s => new PatientSuvivalReadModel
                        //{
                        //    circuit = s.circuit,
                        //    pressure = s.pressure,
                        //    breathing = s.breathing,
                        //    height = s.height,
                        //    weight = s.weight,
                        //    patcode = s.patcode,
                        //    recordscode = s.recordscode,
                        //    type = s.type,
                        //    active = s.active,
                        //}).FirstOrDefault());

                        //----Lấy lịch sử CLS thuốc
                        //----Cls------
                        //result.ForEach(f => f.LstOutclinicHis = dbContext.emroutclinics.AsNoTracking()
                        //.Where(x => x.active == 1 && x.patcode == f.patcode && x.status == 3)
                        //.Select(s => new OutclinicHisReadModel
                        //{
                        //    code = s.code,
                        //    examdate = s.examdate,
                        //    patcode = f.patcode,
                        //    managecode = s.managecode,
                        //    icd10maincode = s.icd10maincode,
                        //    icd10mainname = s.icd10mainname,


                        //    //lstDrugsOrder = mapper.MapFromEntityToReadModelListOutServicesOrder(dbContext.EMR_serviceorders.AsNoTracking().Where(x => x.active == 1 && x.managecode == f.managercode).ToList()),
                        //}).ToList());

                        result.ForEach(f => f.OutclinicCurent = mapper.MapFromEntityToReadModelModelOutclinic(dbContext.EMR_medioutclinics.AsNoTracking()
                        .Where(x => x.active == 1 && x.idlink == f.managercode).FirstOrDefault())
                        );
                        result.ForEach(f => f.status = f.OutclinicCurent == null ? 0 : f.OutclinicCurent.status);

                        foreach (var item in result)
                        {
                            if (item.OutclinicCurent != null)
                            {
                                item.OutclinicCurent.LstServicesOrder = mapper.MapFromEntityToReadModelListOutServicesOrder(dbContext.EMR_serviceorder.AsNoTracking()
                                .Where(x => x.active == 1 && x.medexalcode == item.OutclinicCurent.medexalcode).ToList());

                                item.OutclinicCurent.LstDrugsOrder = mapper.MapFromEntityToReadModelListOutDrugsOrder(dbContext.EMR_drugorder.AsNoTracking()
                                .Where(x => x.active == 1 && x.medexalcode == item.OutclinicCurent.medexalcode).ToList());
                            }
                            //if (item.LstOutclinicHis.Count > 0)
                            //{
                            //    foreach (var itemH in item.LstOutclinicHis)
                            //    {
                            //        itemH.lstServicesOrder =  mapper.MapFromEntityToReadModelListOutServicesOrder(dbContext.EMR_serviceorders.AsNoTracking()
                            //            .Where(x => x.active == 1 && x.depcode == itemH.code).ToList());

                            //        itemH.lstDrugsOrder =  mapper.MapFromEntityToReadModelListOutDrugsOrder(dbContext.emrdrugsorders.AsNoTracking()
                            //           .Where(x => x.active == 1 && x.depcode == itemH.code).ToList());
                            //    }
                            //}
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public List<OutclinicHisReadModel> GetListOutHisBypatcode(string i_patcode)
        {
            List<OutclinicHisReadModel> result = new List<OutclinicHisReadModel>();

            try
            {
                result = mapper.MapFromEntityToReadModelLisOutclinic(dbContext.EMR_medioutclinics.AsNoTracking()
                        .Where(x => x.active == 1 && x.patcode == i_patcode && x.statuscode == 3).ToList());
                if (result.Count > 0)
                {
                    result.ForEach(f => f.lstServicesOrder = mapper.MapFromEntityToReadModelListOutServicesOrder(dbContext.EMR_serviceorder.AsNoTracking()
                                        .Where(x => x.active == 1 && x.idlink == f.idlink && x.placordercode == 2).ToList()));

                    result.ForEach(f => f.lstDrugsOrder = mapper.MapFromEntityToReadModelListOutDrugsOrder(dbContext.EMR_drugorder.AsNoTracking()
                                       .Where(x => x.active == 1 && x.idlink == f.idlink && x.placordercode == 0).ToList()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public bool SaveOutClinic(OutclinicModel i_ClinicModel)
        {
            try
            {
                if (i_ClinicModel != null)
                {
                    List<EMR_medioutclinic> LstOutclinicEntity = new List<EMR_medioutclinic>();
                    LstOutclinicEntity.Add(mapper.MapFromModelToEntityOutclinic(i_ClinicModel));
                    if (LstOutclinicEntity.Count > 0)
                    {
                        dbContext.BulkMerge(LstOutclinicEntity);
                    }
                    if (i_ClinicModel.LstServicesOrder != null)
                    {
                        List<EMR_serviceorder> LstServicesOrderEntity = new List<EMR_serviceorder>();
                        LstServicesOrderEntity = mapper.MapFromModelToEntityListOutServicesOrder(i_ClinicModel.LstServicesOrder, LstOutclinicEntity[0]);

                        if (LstServicesOrderEntity.Count > 0)
                        {
                            dbContext.BulkMerge(LstServicesOrderEntity);
                        }
                    }
                    if (i_ClinicModel.LstDrugsOrder != null)
                    {

                        List<EMR_drugorder> LstDrugsOrderEntity = new List<EMR_drugorder>();
                        LstDrugsOrderEntity = mapper.MapFromModelToEntityListOutDrugsOrder(i_ClinicModel.LstDrugsOrder, LstOutclinicEntity[0]);

                        //Gọi repo phân lo dữ tồn
                        PHA_prescriptionhModel Prescriptionh = new PHA_prescriptionhModel();
                        List<PHA_prescriptionlModel> lstPHA_prescriptionlModel = new List<PHA_prescriptionlModel>();

                        Prescriptionh = (from a in LstOutclinicEntity
                                         select new PHA_prescriptionhModel
                                         {
                                             code = a.patcode,
                                             statuscode = a.statuscode,
                                             patid = a.patid,
                                             patcode = a.patcode,
                                             idlink = a.idlink,
                                             mediid = a.idline,
                                             datecreate = DateTime.Now,
                                             usercreate = a.usercr,
                                             isfinish = a.statuscode == 3 ? true : false,
                                             medexacode = a.medexalcode,
                                             medexaname = a.medexalname,
                                             doccode = a.docexamcode,
                                             docname = a.docexamname,
                                             objectcode = a.objectcode,

                                         }).FirstOrDefault();

                        lstPHA_prescriptionlModel = mapper.MaplstPrescriptionlToModel(LstDrugsOrderEntity);
                        Prescriptionh.lstPrescriptionl = lstPHA_prescriptionlModel;

                        PhaRepo.SavePrecription(1, i_ClinicModel.objectcode, Prescriptionh, 0);
                        //----------------------
                        if (LstDrugsOrderEntity.Count > 0)
                        {
                            dbContext.BulkMerge(LstDrugsOrderEntity);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public bool DeleteOutServicesOrder(string i_code, string i_uup)
        {
            try
            {
                if (!string.IsNullOrEmpty(i_code))
                {
                    List<EMR_serviceorder> LstServicesOrderEntity = new List<EMR_serviceorder>();

                    LstServicesOrderEntity = dbContext.EMR_serviceorder.AsNoTracking()
                        .Where(x => x.active == 1 && x.idline == i_code).ToList();

                    if (LstServicesOrderEntity.Count > 0)
                    {
                        bool bCheck = CheckDeleteOutServicesOrder(LstServicesOrderEntity);
                        if (bCheck)
                        {
                            foreach (EMR_serviceorder item in LstServicesOrderEntity)
                            {
                                item.active = 0;
                                item.timeup = DateTime.Now;
                                item.userup = i_uup;
                            }

                            dbContext.BulkInsert(LstServicesOrderEntity);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        bool OptionPaymentAfterValue = false;
        public bool CheckDeleteOutServicesOrder(List<EMR_serviceorder> i_LstServicesOrderCheck)
        {
            bool bResult = false;
            try
            {
                if (i_LstServicesOrderCheck != null | i_LstServicesOrderCheck.Count > 0)
                {
                    foreach (EMR_serviceorder item in i_LstServicesOrderCheck)
                    {
                        int? i_patienttype = item.typepatcode;
                        switch (i_patienttype)
                        {
                            //Ngoại trú
                            case 1:
                                if (OptionPaymentAfterValue)
                                {
                                    if (item.done == 1)
                                    {
                                        throw new LogicException("Dịch vụ :" + item.servicename + " đã có kết quả, không được phép xoá, Vui lòng kiểm tra lại!");
                                        bResult = false;
                                    }
                                }
                                else
                                {
                                    if (item.paid == 1)
                                    {
                                        throw new LogicException("Dịch vụ :" + item.servicename + " đã thu tiền, không được phép xoá, Vui lòng kiểm tra lại!");
                                        bResult = false;
                                    }
                                    if (item.done == 1)
                                    {
                                        throw new LogicException("Dịch vụ :" + item.servicename + " đã có kết quả, không được phép xoá, Vui lòng kiểm tra lại!");
                                        bResult = false;
                                    }
                                }
                                break;
                            //Nội trú
                            case 2:
                                if (item.done == 1)
                                {
                                    throw new LogicException("Dịch vụ :" + item.servicename + " đã có kết quả, không được phép xoá, Vui lòng kiểm tra lại!");
                                    bResult = false;
                                }
                                break;
                            default:
                                break;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return bResult;
        }
    }
}
