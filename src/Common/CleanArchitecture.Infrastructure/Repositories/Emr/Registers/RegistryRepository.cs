using Emr.Domain.Entities.Emr.Registers;
using Emr.Domain.Entities.Emr.ServiceOrder;
using Emr.Domain.Entities.Pha;
using Emr.Domain.Model.Emr.Register;
using Emr.Domain.Model.Emr.Registers;
using Emr.Domain.Model.Share;
using Emr.Domain.ReadModel.Emr.BHYT;
using Emr.Domain.ReadModel.Emr.Registers;
using Emr.Domain.ReadModel.Share.Patients;
using Emr.Infrastructure.Constans;
using Emr.Infrastructure.Hepper.Lib;
using Emr.Infrastructure.Hepper.Provider;
using Emr.Infrastructure.Persistence;
using Emr.Infrastructure.RepoMapper.Emr.Registers;
using Emr.Infrastructure.Repositories.BHYT;
using Emr.Infrastructure.Repositories.Cache;
using Emr.Infrastructure.Repositories.Share;
using Emr.Infrastructure.Repositories.Share.Patient;
using Microsoft.EntityFrameworkCore;
using PT.DomainLayer.ReadModel._01.Medical.BHYT;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Emr.Infrastructure.Repositories.Emr.Registers

{

    public class RegistryRepository : IRegistryRepository
    {
        CaGetCodeRepository caRepo;
        CacheRepository caRepoCaching;
        private RegistryEntityMapper _mapper;
        private MydbContext dbContext;
        private PatientRepository patienRepo;
        private MyDbShareContext myDbShareContext;
        BHYTRepository bHYTRepository;
        public RegistryRepository(MydbContext i_Context)
        {
            dbContext = i_Context;
            _mapper = new RegistryEntityMapper();
            patienRepo = new PatientRepository(new MyDbShareContext(new DbContextOptionsBuilder<MyDbShareContext>().UseSqlServer(ConnectionStrings.DefaultConnection).Options));
            caRepoCaching = new CacheRepository();
            bHYTRepository = new BHYTRepository(myDbShareContext);
        }
        public string Constanst { get; private set; }
        #region GetRepository
        public List<RegisterReadModel> GetRegistryListByDate(string i_FromDate, string i_ToDate)
        {
            List<RegisterReadModel> lstResult = new List<RegisterReadModel>();
            try
            {
                List<SchemasMMYYModel> lstmmyys = new List<SchemasMMYYModel>();

                lstmmyys = Library.GetSchemaNamesByFromToDate(Library.GetFomatDate(i_FromDate), Library.GetFomatDate(i_ToDate).AddDays(1));
                lstmmyys = lstmmyys.Where(x => x.mmyy != DateTime.Now.ToString("MMyy")).ToList();

                if (lstmmyys.Count > 0)
                {
                    foreach (var mmyy in lstmmyys)
                    {
                        using (var context = Library.GetSchemaChangeDbContext(mmyy.mmyyName))
                        {
                            lstResult.AddRange(context.emrregisters.AsNoTracking().Select(s => new RegisterReadModel
                            {
                                rowsid = s.rowsid,
                                managecode = s.managecode,
                                indepartmentid = s.indepartmentid,
                                medexacode = s.medexacode,
                                patcode = s.patcode,
                                doctorcode = s.doctorcode,
                                registerdate = s.registerdate,
                                objectcode = s.objectcode,
                                addressfull = s.addressfull,
                                phonenumber = s.phonenumber,
                                done = s.done,
                                ispatientnew = s.ispatientnew,
                                patienttype = s.patienttype,
                                placetransfercode = s.placetransfercode,
                                placeIntrocode = s.placeIntrocode,
                                reson = s.reson,
                                active = s.active,
                                ucr = s.ucr,
                                uup = s.uup,
                                timecr = s.timecr,
                                timeup = s.timeup,
                                com = s.com,
                                mac = s.mac,
                                ip = s.ip,
                            }).ToList());
                        }
                    }
                }
                lstResult.AddRange(dbContext.emrregisters.Where(x => x.active == 1 && x.registerdate > Library.GetFomatDate(i_FromDate) && x.registerdate < Library.GetFomatDate(i_ToDate))
                    .Select(a => new RegisterReadModel
                    {
                        rowsid = a.rowsid,
                        managecode = a.managecode,
                        indepartmentid = a.indepartmentid,
                        medexacode = a.medexacode,
                        patcode = a.patcode,
                        doctorcode = a.doctorcode,
                        registerdate = a.registerdate,
                        objectcode = a.objectcode,
                        addressfull = a.addressfull,
                        phonenumber = a.phonenumber,
                        done = a.done,
                        ispatientnew = a.ispatientnew,
                        patienttype = a.patienttype,
                        placetransfercode = a.placetransfercode,
                        placeIntrocode = a.placeIntrocode,
                        reson = a.reson,
                        active = a.active,
                        ucr = a.ucr,
                        uup = a.uup,
                        timecr = a.timecr,
                        timeup = a.timeup,
                        com = a.com,
                        mac = a.mac,
                        ip = a.ip,
                    }).ToList());

                if (lstResult.Count > 0)
                {
                    lstResult.OrderBy(o => o.registerdate).ToList();

                    lstResult.ForEach(f =>
                    {
                        f.lstServicesOrderModel = dbContext.PayServices.Where(x => x.patcode == f.patcode)
                    .Select(x => new EmrServicesOrderModel
                    {
                        patcode = x.patcode,
                    }).ToList();
                        f.patient = patienRepo.GetPatientBypatcode(f.patcode);
                    }
                );
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstResult;
        }
        public RegisterReadModel GetRegistryByCodeAdmission(string i_CodeAdmission)
        {
            RegisterReadModel _result = new RegisterReadModel();
            try
            {
                _result = dbContext.emrregisters.Where(x => x.managecode == i_CodeAdmission)
                    .Select(a => new RegisterReadModel
                    {
                        rowsid = a.rowsid,
                        managecode = a.managecode,
                        indepartmentid = a.indepartmentid,
                        medexacode = a.medexacode,
                        patcode = a.patcode,
                        doctorcode = a.doctorcode,
                        registerdate = a.registerdate,
                        objectcode = a.objectcode,
                        addressfull = a.addressfull,
                        phonenumber = a.phonenumber,
                        done = a.done,
                        ispatientnew = a.ispatientnew,
                        paceregistercode = a.paceregistercode,
                        patienttype = a.patienttype,
                        placetransfercode = a.placetransfercode,
                        placeIntrocode = a.placeIntrocode,
                        reson = a.reson,
                        objectname = a.objectname,
                        medexaname = a.medexaname,
                        active = a.active,
                        ucr = a.ucr,
                        uup = a.uup,
                        timecr = a.timecr,
                        timeup = a.timeup,
                        com = a.com,
                        mac = a.mac,
                        ip = a.ip,
                    }).FirstOrDefault();
                if (_result != null)
                {
                    var _lstPayServicesOrderModel = dbContext.EMR_serviceorder.Where(x => x.patcode == _result.patcode)
                    .Select(x => new EmrServicesOrderModel
                    {
                        patcode = x.patcode,
                    }).ToList();
                    _result.lstServicesOrderModel = _lstPayServicesOrderModel;
                    _result.patient = patienRepo.GetPatientBypatcode(_result.patcode);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _result;
        }
        public List<RegisterHistoryReadModel> GetRegisterHistory(string i_patcode)
        {
            List<RegisterHistoryReadModel> results = new List<RegisterHistoryReadModel>();
            List<emrregister> lstEmrregisterEntity = new List<emrregister>();

            PatientReadModel patient = new PatientReadModel();
            try
            {
                patient = patienRepo.GetPatientBypatcode(i_patcode);

                if (patient != null)
                {
                    List<SchemasMMYYModel> lstmmyys = new List<SchemasMMYYModel>();
                    lstmmyys = Library.GetSchemaNamesByPatient(patient);
                    lstmmyys = lstmmyys.Where(x => x.mmyy != DateTime.Now.ToString("MMyy")).ToList();

                    if (lstmmyys.Count > 0)
                    {
                        foreach (var mmyy in lstmmyys)
                        {
                            using (var context = Library.GetSchemaChangeDbContext(mmyy.mmyyName))
                            {
                                results.AddRange(context.emrregisters.AsNoTracking().Where(x => x.patcode == i_patcode).Select(s => new RegisterHistoryReadModel
                                {
                                    name = s.registerdate.ToString(),
                                    code = s.managecode,
                                    medexacode = s.medexacode.Trim(),
                                    patcode = s.patcode,
                                    mmyy = s.mmyy,
                                }).ToList());
                            }
                        }
                    }
                    results = (from s in dbContext.emrregisters.Where(x => x.patcode == i_patcode)

                               select new RegisterHistoryReadModel
                               {
                                   name = s.registerdate.ToString(),
                                   code = s.managecode,
                                   medexacode = s.medexacode.Trim(),
                                   patcode = s.patcode,
                                   mmyy = s.mmyy,
                               }).ToList();

                    results.OrderBy(o => o.name).ToList();

                    if (results.Count > 0)
                    {
                        List<ManageHistoryReadModel> lstTemp = new List<ManageHistoryReadModel>();
                        ManageHistoryReadModel temp = null;

                        var cateMedexaL = caRepoCaching.GetCateMedexaLAllCaching();

                        foreach (var item in results)
                        {
                            temp = new ManageHistoryReadModel();
                            temp.codeh = item.code;
                            temp.code = item.medexacode;
                            lstTemp.Add(temp);
                        }
                        if (lstTemp.Count > 0)
                        {
                            results.ForEach(f =>
                            {
                                f.ManageHistory = (from a in lstTemp.Where(x => x.codeh == f.code)
                                                   join b in dbContext.camedexals.AsNoTracking()
                                                     .Where(x => x.siterf == 1 && x.active == 1 && x.ismedexa == true)
                                                     on a.code.Trim() equals b.code.Trim()
                                                   select new
                                                    ManageHistoryReadModel
                                                   {
                                                       codeh = a.codeh,
                                                       code = b.code.Trim(),
                                                       name = b.name,
                                                   }).DistinctBy(d => d.code.Trim()).ToList();
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return results;
        }
        #endregion
        #region SaveRepository
        public RegisterSlipReadModel SaveRegister(RegisterModel i_MediRegisterModel)

        {
            RegisterSlipReadModel result = new RegisterSlipReadModel();
            try
            {
                //i_MediRegisterModel.patcode = "2274721KXD8711";
                //Creat Code -------------------------------------------------------------------
                if (i_MediRegisterModel.patcode == null || i_MediRegisterModel.patcode == "")
                {
                    i_MediRegisterModel.patcode = caRepo.GetCode(code.patcode, 1);
                }
                //---------------------------------------------------------------------------------
                //1.Registry

                emrregister _emrregister = _mapper.MapFromModelToEntityemrregister(i_MediRegisterModel);
                _emrregister.managecode = Guid.NewGuid().ToString();

                //      _emrregister.linkid = "2206282274721KXD8711";
                List<emrregister> _lstemrregister = new List<emrregister>();
                _lstemrregister.Add(_emrregister);
                _lstemrregister[0].timecr = DateTime.Now;
                dbContext.BulkMerge(_lstemrregister);

                int STT = 0;
                if (_emrregister != null)
                {
                    ////1.1 ServicesOrder
                    if (i_MediRegisterModel.ServicesOrder.Count > 0)
                    {
                        List<emrservicesorder> lstemrservicesorderEntity = new List<emrservicesorder>();

                        lstemrservicesorderEntity = _mapper.MapFromModelToEntityLstPayService(i_MediRegisterModel.ServicesOrder, _emrregister);

                        if (lstemrservicesorderEntity.Count > 0)
                        {
                            dbContext.BulkInsert(lstemrservicesorderEntity);
                        }
                        //    //Luu phân phòng
                        STT = SaveClinicQue(_emrregister, lstemrservicesorderEntity[0]);
                    }
                    if (i_MediRegisterModel.RegisterHi != null)
                    {
                        List<emrregisterhi> lstemrregisterhiEntity = new List<emrregisterhi>();

                        lstemrregisterhiEntity.Add(_mapper.MapFromModelToEntityLstRegisterHi(i_MediRegisterModel.RegisterHi, _emrregister));

                        if (lstemrregisterhiEntity.Count > 0)
                        {
                            dbContext.BulkInsert(lstemrregisterhiEntity);
                        }
                    }
                    //if (patientModel.PatientRelation != null)
                    //{

                    //    List<emrpatientelation> lstPatientelationEntity = new List<emrpatientelation>();
                    //    patientModel.PatientRelation.patcode = i_MediRegisterModel.patcode;
                    //    lstPatientelationEntity.Add(_mapper.MapFromModelToEntityemrpatientelation(patientModel.PatientRelation, patientEntity));
                    //    if (lstPatientelationEntity.Count > 0)
                    //    {
                    //        dbContext.BulkMerge(lstPatientelationEntity);
                    //    }
                    //}

                    ////1.2 Patient
                }

                result.ordinalnumber = STT;
                result.patcode = _emrregister.patcode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //_Result = GetAll();
            return result;
        }
        public int SaveClinicQue(emrregister i_emrregister, emrservicesorder emrservicesorderEntity)
        {
            int STT = 0;
            try
            {
                STT = caRepo.GetSTT(i_emrregister.objectcode, emrservicesorderEntity.medexal, null);

                string SevicesName = dbContext.CATE_priceservicess.Where(x => x.code == emrservicesorderEntity.servicecode).Select(s => s.name).FirstOrDefault();
                string MedexaName = dbContext.camedexals.Where(x => x.code == emrservicesorderEntity.medexal).Select(s => s.name).FirstOrDefault();

                List<emrclinicqueue> lstemrclinicqueueEntity = new List<emrclinicqueue>();
                ClinicQueueModel ClinicQueue = new ClinicQueueModel();

                ClinicQueue.siterf = 1;
                ClinicQueue.patcode = i_emrregister.patcode;
                ClinicQueue.managercode = i_emrregister.managecode;
                ClinicQueue.serviceidline = emrservicesorderEntity.code;
                ClinicQueue.servicecode = emrservicesorderEntity.servicecode;
                ClinicQueue.servicename = SevicesName;
                ClinicQueue.medexacode = emrservicesorderEntity.medexal;
                ClinicQueue.medexaname = MedexaName;
                ClinicQueue.ordinal = STT;
                ClinicQueue.status = 1;
                ClinicQueue.active = 1;
                ClinicQueue.timecr = DateTime.Now;
                ClinicQueue.timeup = DateTime.Now;

                // ClinicQueue.areacode =null;
                // ClinicQueue.priobcode = emrservicesorderEntity.servicecode;
                // ClinicQueue.beginwait = emrservicesorderEntity.servicecode;
                //ClinicQueue.endwait = emrservicesorderEntity.servicecode;
                //ClinicQueue.overdate = emrservicesorderEntity.servicecode;
                //ClinicQueue.usercr = emrservicesorderEntity.servicecode;
                //ClinicQueue.userup = emrservicesorderEntity.servicecode;
                //ClinicQueue.computer = emrservicesorderEntity.servicecode;
                lstemrclinicqueueEntity.Add(_mapper.MapFromModelToEntityEmrClinicQueue(ClinicQueue));
                if (lstemrclinicqueueEntity.Count > 0)
                {
                    dbContext.BulkInsert(lstemrclinicqueueEntity);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return STT;

        }
        public BHYTReadModel CheckExpertiseBHYT(int i_Siterf, BHYTGet i_CarePara)
        {
            BHYTReadModel bHYTBVReadModel = new BHYTReadModel();
            try
            {
                //List<PHA_catestore> lststoreEntity = new List<PHA_catestore>();
                //PHA_catestore storeEntity = new PHA_catestore();

                ////storeEntity.code = "0001";
                ////storeEntity.name = "Name 01";

                //storeEntity.id = 1;
                //storeEntity.code = "KHOCHAN";
                //storeEntity.name = "KHO CHẴN";
                //storeEntity.statuscode = 1;
                //storeEntity.typestorecode = 1;
                //storeEntity.active = 1;
                //storeEntity.siterf = 1;
                //storeEntity.mmyy = "0124";
                //storeEntity.yyyy = "2014";

                //lststoreEntity.Add(storeEntity);

                //if (lststoreEntity.Count > 0)
                //{
                //    dbContext.BulkInsert(lststoreEntity);
                //}

                bHYTBVReadModel = bHYTRepository.BHYTResponse(i_Siterf, i_CarePara);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return bHYTBVReadModel;
        }
        #endregion
    }
}
