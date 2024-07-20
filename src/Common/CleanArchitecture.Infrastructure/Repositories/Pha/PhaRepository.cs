using Emr.Domain.Entities.Pha;
using Emr.Domain.Model.Pha.Inventory;
using Emr.Domain.Model.Pha.Prescription;
using Emr.Domain.Model.Pha.StoreImport;
using Emr.Domain.Model.Share;
using Emr.Domain.ReadModel.Pha;
using Emr.Domain.ReadModel.Pha.StoreImport;
using Emr.Infrastructure.Constans;
using Emr.Infrastructure.Hepper.Exceptions;
using Emr.Infrastructure.Hepper.Lib;
using Emr.Infrastructure.Hepper.Provider;
using Emr.Infrastructure.Persistence;
using Emr.Infrastructure.RepoMapper.Pha;
using Emr.Infrastructure.Repositories.Share;
using Emr.Infrastructure.Repositories.StoreProduce;
using Microsoft.EntityFrameworkCore;
using PT.DomainLayer.AggregatesModel.Pha;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Emr.Infrastructure.Repositories.Pha
{
    public class PhaRepository : IPhaRepository
    {
        private string SchemasMMYY { get; set; }

        TestShareRepository testShareRepository;
        StoreProduceRepository storeProduceRepo;
        private MydbContext dbContext;
        private MyDbShareContext dbShareContext;
        PhaEntityMapper mapper;
        //public ConnectionStrings connectionStrings { get; set; }
        public PhaRepository(MydbContext i_Context)
        {
            dbContext = i_Context;
            //connectionStrings = dbContext.connectionStrings;
            mapper = new PhaEntityMapper();
            testShareRepository = new TestShareRepository(dbShareContext);
            // storeProduceRepo = new StoreProduceRepository(new MyDbShareContext(new DbContextOptionsBuilder<MyDbShareContext>().UseSqlServer(ConnectionStrings.DefaultConnection).Options));
        }

        #region Inventory
        public List<PHA_inventorylReadModel> GetDrugInventoryByStore()
        {
            List<SchemasMMYYModel> lstMMyy = new List<SchemasMMYYModel>();
            List<PHA_inventorylReadModel> result = new List<PHA_inventorylReadModel>();
            List<PHA_inventorylReadModel> result1 = new List<PHA_inventorylReadModel>();
            List<PHA_inventorylReadModel> result2 = new List<PHA_inventorylReadModel>();
            List<PHA_inventorylReadModel> result3 = new List<PHA_inventorylReadModel>();
            List<PHA_inventoryl> resultEntity = new List<PHA_inventoryl>();
            List<PHA_inventoryl> resultEntity1 = new List<PHA_inventoryl>();
            List<PHA_inventoryl> resultEntity2 = new List<PHA_inventoryl>();
            List<PHA_inventoryl> resultEntity3 = new List<PHA_inventoryl>();

            try
            {
                resultEntity1 = dbContext.PHA_inventoryl.AsNoTracking().Where(x => x.active == 1).ToList();
                result1 = mapper.MapFromEntityToReadModelDrugInventoryl(resultEntity1);
                result.AddRange(result1);

                lstMMyy = Library.GetSchemaNamesByFromToDate(DateTime.Parse("2024-01-01"), DateTime.Now);
                lstMMyy = lstMMyy.Where(x => x.mmyy != DateTime.Now.ToString("MMyy")).ToList();

                if (lstMMyy != null)
                {
                    foreach (var mmyy in lstMMyy)
                    {
                        SchemasMMYY = mmyy.mmyyName;
                        using (var transaction = dbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
                        {
                            try
                            {
                                using (var context = Library.GetSchemaChangeDbContext(SchemasMMYY))
                                {
                                    resultEntity.AddRange(context.PHA_inventoryls.AsNoTracking().ToList());
                                }
                                transaction.Commit();
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                            }
                        }
                    }
                    if (resultEntity != null)
                    {
                        result2 = mapper.MapFromEntityToReadModelDrugInventoryl(resultEntity);
                        result.AddRange(result2);
                    }
                }

                resultEntity3 = dbContext.PHA_inventoryl.AsNoTracking().Where(x => x.active == 1).ToList();
                result3 = mapper.MapFromEntityToReadModelDrugInventoryl(resultEntity1);

                result.AddRange(result3);
            }
            catch (Exception ex)
            {
                throw ex;

            }

            return result;
        }

        public List<PHA_inventorylReadModel> GetDrugInventoryByStoreTest()
        {

            List<PHA_inventorylReadModel> result = new List<PHA_inventorylReadModel>();
            List<PHA_inventoryl> resultEntity = new List<PHA_inventoryl>();

            try
            {
                var lstMMyy = Library.GetSchemaNamesByFromToDate(DateTime.Parse("2024-01-01"), DateTime.Now);
                if (lstMMyy != null)
                {
                    foreach (var mmyy in lstMMyy)
                    {
                        //schema.CurentSchema = mmyy.mmyyName;
                        // dbContext = new MydbContext(new DbContextOptionsBuilder<MydbContext>().UseSqlServer(strConnectionStrings.ToString()).Options, schema);
                        resultEntity.AddRange(dbContext.PHA_inventoryl.ToList());
                    }

                }

                resultEntity = dbContext.PHA_inventoryl.AsNoTracking().Where(x => x.active == 1).ToList();
                result = mapper.MapFromEntityToReadModelDrugInventoryl(resultEntity);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
        public List<PHA_inventorylReadModel> GetInventoryByConfig(int i_Siterf, string i_ObjectCode, string i_MedexalCode, int i_TypeExportCode, int i_TypeStoreCode)
        {
            List<PHA_inventorylReadModel> lstResult = new List<PHA_inventorylReadModel>();
            try
            {
                //var lstStoreEntityByConfig = dbContext.PHA_cfstorebydepart.Where(x => x.siterf == i_Siterf && x.medexalcode == i_MedexalCode.ToString() && x.typeexportcode == i_TypeExportCode && x.typestorecode == i_TypeStoreCode).ToList();
                var lstStoreEntityByConfig = dbContext.PHA_cfstorebydepart.ToList();
                if (lstStoreEntityByConfig.Count == 0)
                {
                    throw new LogicException("Kho thuốc chưa được cấu hình !Vui lòng kiểm tra lại");
                }
                List<int> lstStoreCheck = lstStoreEntityByConfig.Select(s => s.storecode).ToList();
                List<PHA_inventoryl> lstPHA_inventorylEntityCheck = new List<PHA_inventoryl>();
                var CurentDay = DateTime.Now.Date;
                //using (var MydbContextReadOnly = new MydbContext(null))
                //{
                //    lstPHA_inventorylEntityCheck = MydbContextReadOnly.PHA_inventoryl.Where(x => lstStoreCheck.Contains(x.storecode) && (x.qtyt + x.qtyimp - x.qtyexp - x.qtyrep) > 0 && x.expirydate.Value.Date >= CurentDay).ToList();
                //}

                lstPHA_inventorylEntityCheck = dbContext.PHA_inventoryl.Where(x => lstStoreCheck.Contains(x.storecode) && (x.qtyt + x.qtyimp - x.qtyexp - x.qtyrep) > 0 && x.expirydate.Value.Date >= CurentDay).OrderByDescending(o => o.expirydate).ToList();
                //Thể hiện chi tiết tồn kho theo option

                string option = "lotnumber";

                switch (option)
                {
                    case "lotnumber":
                        lstPHA_inventorylEntityCheck = lstPHA_inventorylEntityCheck.GroupBy(g => g.lotnumber).Select(s => new PHA_inventoryl
                        {
                            storecode = s.Select(x => x.storecode).FirstOrDefault(),
                            drugcode = s.Select(x => x.drugcode).FirstOrDefault(),
                            qtyt = s.Sum(su => su.qtyt),
                            qtyimp = s.Sum(su => su.qtyimp),
                            qtyexp = s.Sum(su => su.qtyexp),
                            qtyrep = s.Sum(su => su.qtyrep),
                            qtymi = s.Sum(su => su.qtymi),
                            followid = s.Select(x => x.followid).FirstOrDefault(),
                            lotnumber = s.Select(x => x.lotnumber).FirstOrDefault(),
                            expirydate = s.Select(x => x.expirydate).FirstOrDefault(),
                            ofmanudate = s.Select(x => x.ofmanudate).FirstOrDefault(),
                            price = s.Select(x => x.price).FirstOrDefault(),
                            note = s.Select(x => x.note).FirstOrDefault(),
                            mmyy = s.Select(x => x.mmyy).FirstOrDefault(),
                        }).ToList();
                        break;

                    default:
                        break;

                }



                if (lstPHA_inventorylEntityCheck.Count > 0)
                {
                    lstResult = mapper.MapFromEntityToReadModelDrugInventoryl(lstPHA_inventorylEntityCheck);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstResult;
        }
        #endregion Inventory

        #region StoreImport
        public string SaveStoreImport(int i_Siterf, PHA_storeimporthModel i_PHA_storeimporthModel, int i_Option)
        {
            string result = string.Empty;
            try
            {
                PHA_invoiceinput PHA_invoiceinputEntity = mapper.MapperInvoiceInputToEntity(i_Siterf, i_PHA_storeimporthModel.InvoiceInput);

                decimal vatamount = i_PHA_storeimporthModel.lstStoreImportl.Sum(x => x.vatamount).Value;
                decimal discountcash = i_PHA_storeimporthModel.lstStoreImportl.Sum(x => x.discountcash).Value;
                decimal totalamount = i_PHA_storeimporthModel.lstStoreImportl.Sum(x => x.total).Value;
                PHA_invoiceinputEntity.yyyy = DateTime.Now.Year.ToString();
                PHA_invoiceinputEntity.userup = null;
                PHA_invoiceinputEntity.vatamount = vatamount;
                PHA_invoiceinputEntity.discountamount = discountcash;
                PHA_invoiceinputEntity.totalamount = totalamount;
                PHA_invoiceinputEntity.reallyamount = totalamount + vatamount - discountcash;


                List<PHA_invoiceinput> lstInvoice = new List<PHA_invoiceinput>();
                lstInvoice.Add(PHA_invoiceinputEntity);
                PHA_storeimporth PHA_storeimporthEntity = mapper.MapperStoreImporthToEntity(i_Siterf, i_PHA_storeimporthModel, PHA_invoiceinputEntity);
                List<PHA_storeimporth> lstImportH = new List<PHA_storeimporth>();
                lstImportH.Add(PHA_storeimporthEntity);

                List<PHA_flstoreimport> lstFlstoreImportEntity = new List<PHA_flstoreimport>();
                PHA_flstoreimport FlstoreImportEntity = new PHA_flstoreimport();

                FlstoreImportEntity = mapper.MapperFlstoreImportToEntity(i_Siterf, PHA_storeimporthEntity, i_Option);
                lstFlstoreImportEntity.Add(FlstoreImportEntity);

                List<PHA_storeimportl> lstImportl = new List<PHA_storeimportl>();
                List<PHA_follow> lstFollow = new List<PHA_follow>();

                if (i_PHA_storeimporthModel.lstStoreImportl != null)
                {
                    lstImportl = mapper.MapperLstStoreImportlToEntity(i_Siterf, i_PHA_storeimporthModel.lstStoreImportl, PHA_storeimporthEntity);
                    if (lstImportl != null)
                    {
                        lstFollow = mapper.MapperLstfollowToEntity(i_Siterf, lstImportl, PHA_storeimporthEntity);
                    }
                }
                if (lstImportH.Count > 0)
                {
                    dbContext.BulkInsert(lstImportH);
                }
                if (lstFlstoreImportEntity.Count > 0)
                {
                    dbContext.BulkInsert(lstFlstoreImportEntity);
                }
                if (lstInvoice.Count > 0)
                {
                    dbContext.BulkInsert(lstInvoice);
                }
                if (lstImportl.Count > 0)
                {
                    dbContext.BulkInsert(lstImportl);
                }
                if (lstFollow.Count > 0)
                {
                    dbContext.BulkInsert(lstFollow);
                }
                i_Option = 1;
                if (i_Option == 1)//Tăng tồn kho => Không cần qua duyệt
                {
                    List<PHA_inventorySetUpdateModel> lstInvenLineUpdate = new List<PHA_inventorySetUpdateModel>();

                    lstInvenLineUpdate = mapper.MapperLstStoreImportlToInvenLineModel(i_Siterf, lstImportl, PHA_storeimporthEntity);

                    if (lstInvenLineUpdate.Count > 0)
                    {
                        UpdateInventoryWhenStoreImport(i_Siterf, lstInvenLineUpdate, "Import");
                    }
                }
                result = PHA_storeimporthEntity.idline.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        private void UpdateInventoryWhenStoreImport(int i_Siterf, List<PHA_inventorySetUpdateModel> lstInventoryLineUpdateReadModel, string i_Type)
        {
            try
            {
                if (lstInventoryLineUpdateReadModel.Count == 0)
                    return;

                if (lstInventoryLineUpdateReadModel.Select(x => x.siterf).Distinct().ToList().Count() > 1)
                    throw new LogicException("Trong danh sách thuốc cập nhật tồn kho, có nhiều hơn 1 siterf: C:PHAInventoryRepository_Partial, F_UpdateInventoryH_QtyExpReq, CP: 02");//CheckPoint: 01

                string mmyy = GetSchema(i_Siterf);
                if (mmyy.Length == 0)
                {
                    throw new LogicException("Không lấy được thông tin mmyy");
                }

                //Thuc hien lay danh sach drugid đã lọc trùng. Lấy ra danh sách để sử dụng join, ko sử dụng contain theo drugid, vì contain sẽ chậm hơn join
                List<PHA_inventorySetUpdateModel> lstInventoryLineUpdateReadModelDistinct = lstInventoryLineUpdateReadModel.DistinctBy(d => new
                {
                    d.siterf,
                    d.drugcode
                }).ToList();

                var DRUGITEM = dbContext.PHA_drugitem.ToList();

                List<PHA_drugitem> lstDrugById = (from lstILD in lstInventoryLineUpdateReadModelDistinct
                                                  join drug in dbContext.PHA_drugitem.AsNoTracking().Where(x => x.active == 1) on lstILD.drugcode.Trim() equals drug.code.Trim()
                                                  select drug).ToList();

                switch (i_Type)
                {
                    case "Import":
                        UpdateInventoryWhenStoreImportLine(i_Siterf, mmyy, lstInventoryLineUpdateReadModel, lstInventoryLineUpdateReadModelDistinct, lstDrugById, i_Type, false);
                        UpdateInventoryWhenStoreImportHeader(i_Siterf, mmyy, lstInventoryLineUpdateReadModel, lstInventoryLineUpdateReadModelDistinct, lstDrugById, i_Type, false);
                        break;
                    default:
                        UpdateInventoryWhenStoreImportLine(i_Siterf, mmyy, lstInventoryLineUpdateReadModel, lstInventoryLineUpdateReadModelDistinct, lstDrugById, i_Type, true);
                        UpdateInventoryWhenStoreImportHeader(i_Siterf, mmyy, lstInventoryLineUpdateReadModel, lstInventoryLineUpdateReadModelDistinct, lstDrugById, i_Type, true);
                        break;

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void UpdateInventoryWhenStoreImportLine(int i_siterf, string i_mmyy, List<PHA_inventorySetUpdateModel> lstInventoryLineUpdateReadModel, List<PHA_inventorySetUpdateModel> lstInventoryLineUpdateReadModelDistinct, List<PHA_drugitem> lstDrugById, string i_Type, bool i_HaveToData)
        {
            try
            {
                //Lay toan bo danh sach InventoryL theo siterf, mmyy, drugid => chap nhan dư thừa dữ liệu để query database 1 lần
                List<PHA_inventoryl> lstAllInventoryLineFromDB = (from lstILD in lstInventoryLineUpdateReadModelDistinct
                                                                  join invl in dbContext.PHA_inventoryl.AsNoTracking().Where(x => x.mmyy == i_mmyy) on lstILD.drugcode.Trim() equals invl.drugcode.Trim()
                                                                  select invl).ToList();

                List<PHA_inventoryl> lstInventoryLineInsert = new List<PHA_inventoryl>();

                foreach (PHA_inventorySetUpdateModel item in lstInventoryLineUpdateReadModel)
                {
                    PHA_drugitem drugInfo = lstDrugById.Where(x => x.code.Trim() == item.drugcode.Trim()).FirstOrDefault();
                    if (drugInfo == null)
                        throw new LogicException(string.Format("Không tìm thấy thuốc id: {0} trong danh mục", item.drugcode));

                    item.siterf = i_siterf;
                    item.drugcode = drugInfo.code;
                    item.mmyy = i_mmyy;

                    List<PHA_inventoryl> lstInventoryLFromDBCheck = (from invl in lstAllInventoryLineFromDB.Where(x => x.siterf == i_siterf && x.storecode == item.storecode && x.drugcode.Trim() == item.drugcode.Trim() && x.followid == item.followid && x.mmyy == i_mmyy)
                                                                     select invl).ToList();

                    if (lstInventoryLFromDBCheck.Count > 1)
                    {
                        throw new LogicException("lstInventoryLFromDBCheck tồn tại 2 dòng dữ liệu: C:PHAInventoryRepository_Partial, F_UpdateInventoryLineV2, CP: 02");
                    }
                    else if (lstInventoryLFromDBCheck.Count == 1) // ton tai du lieu trong inventoryline => ghi nhan tinh trang la Update
                    {
                        PHA_inventoryl inventoryLineFromDBUpdate = lstInventoryLFromDBCheck[0].CopyObject();

                        if ((inventoryLineFromDBUpdate.qtyt + inventoryLineFromDBUpdate.qtyimp - inventoryLineFromDBUpdate.qtyexp) - (item.qtyExp * item.actionExp) >= 0) //kiem tra cap nhat co lam sai so luong tồn kho không
                        {
                            item.typecode = "Update";
                        }
                        else
                        {
                            throw new LogicException(string.Format("Thuốc : {0} thuộc mã kho: {1}: {2}.", drugInfo.name, item.storecode, ConstantMessage.KhoKhongDuTonDeXuat));
                        }

                    }
                    else // lstInventoryLFromDBCheck.Count == 0
                    {

                        if (i_Type.Equals("Import") == true)
                        {

                            if ((item.qtyT + item.qtyImp) - item.qtyExp >= 0) //kiem tra cap nhat co lam sai so luong tồn kho không
                            {
                                PHA_inventoryl inventoryLineInsert = new PHA_inventoryl();
                                inventoryLineInsert.siterf = i_siterf;
                                inventoryLineInsert.mmyy = i_mmyy;
                                inventoryLineInsert.yyyy = DateTime.Now.Year.ToString();
                                inventoryLineInsert.storecode = item.storecode;
                                inventoryLineInsert.drugcode = item.drugcode;
                                //inventoryLineInsert.dateinput = DateTime.Now;
                                inventoryLineInsert.followid = item.followid;
                                inventoryLineInsert.qtyt = item.qtyT;
                                inventoryLineInsert.qtyimp = item.qtyImp;
                                inventoryLineInsert.qtyexp = item.qtyExp;
                                inventoryLineInsert.qtyrep = item.qtyReq;
                                inventoryLineInsert.price = item.price;

                                inventoryLineInsert.usercr = item.usercr;
                                inventoryLineInsert.timecr = item.timecr;
                                inventoryLineInsert.userup = item.userup;
                                inventoryLineInsert.timeup = item.timeup;
                                inventoryLineInsert.computer = item.computer;
                                inventoryLineInsert.active = item.active;

                                inventoryLineInsert.lotnumber = item.lotnumber;
                                inventoryLineInsert.expirydate = item.expirydate;
                                inventoryLineInsert.ofmanudate = item.ofmanudate;

                                lstInventoryLineInsert.Add(inventoryLineInsert);
                                item.typecode = "Insert"; //ko ton tai trong inventoryline => ghi nhan tinh trang la Insert => ko chay update qua inventory trong trigger
                            }
                            else
                            {
                                throw new LogicException(string.Format("Dữ liệu thêm mới vào lstInventoryLineInsert không hợp lệ: siterf: {0}, storeid: {1}, drugid: {2}, qtyt: {3}, qtyimp: {4}, qtyexp: {5}, qtyrep: {6}", i_siterf, item.storecode, item.drugcode, item.qtyT, item.qtyImp, item.qtyExp, item.qtyReq));
                            }
                        }
                        else if (i_HaveToData == true)
                        {
                            throw new LogicException(string.Format("Không tìm thấy dữ liệu để cập nhật phainventoryl: (siterf: {0}, storeid: {1}, drugid: {2}, followid: {3}, mmyy: {4}", i_siterf, item.storecode, item.drugcode, item.followid, i_mmyy));
                        }
                    }

                }

                List<PHA_inventorytransaction> lstInventoryTransactionInsert = mapper.MapperToInventoryTransactionEntity(i_siterf, lstInventoryLineUpdateReadModel);
                if (lstInventoryTransactionInsert.Count > 0)
                    dbContext.BulkInsert(lstInventoryTransactionInsert);

                if (lstInventoryLineInsert.Count > 0)
                    dbContext.BulkInsert(lstInventoryLineInsert);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void UpdateInventoryWhenStoreImportHeader(int i_siterf, string i_mmyy, List<PHA_inventorySetUpdateModel> lstInventoryLineUpdateReadModel, List<PHA_inventorySetUpdateModel> lstInventoryLineUpdateReadModelDistinct, List<PHA_drugitem> lstDrugById, string i_Type, bool i_HaveToData)
        {
            try
            {
                //Lay toan bo danh sach InventoryH theo siterf, mmyy, drugid => chap nhan dư thừa dữ liệu để query database 1 lần
                List<PHA_inventoryh> lstAllInventoryHeaderFromDB = (from lstILD in lstInventoryLineUpdateReadModelDistinct
                                                                    join invh in dbContext.PHA_inventoryh.AsNoTracking().Where(x => x.mmyy == i_mmyy) on lstILD.drugcode.Trim() equals invh.drugcode.Trim()
                                                                    select invh).ToList();

                List<PHA_inventoryh> lstInventoryHeaderInsert = new List<PHA_inventoryh>();

                foreach (PHA_inventorySetUpdateModel item in lstInventoryLineUpdateReadModel)
                {
                    PHA_drugitem drugInfo = lstDrugById.Where(x => x.code.Trim() == item.drugcode.Trim()).FirstOrDefault();
                    if (drugInfo == null)
                        throw new LogicException(string.Format("Không tìm thấy thuốc id: {0} trong danh mục", item.drugcode));

                    item.siterf = i_siterf;
                    item.drugcode = drugInfo.code;
                    item.mmyy = i_mmyy;

                    //kiem tra trong list lay len tu database
                    List<PHA_inventoryh> lstInventoryHeaderFromDBCheck = (from invl in lstAllInventoryHeaderFromDB.Where(x => x.storecode == item.storecode && x.drugcode.Trim() == item.drugcode.Trim() && x.mmyy == i_mmyy)
                                                                          select invl).ToList();

                    if (lstInventoryHeaderFromDBCheck.Count > 1) //kiem tra neu > 1 => loi du lieu, vi chi co = 0 hoac = 1
                    {
                        //CheckPoint: 02
                        throw new LogicException("Dữ liệu nhiều hơn 1 dòng khi thực hiện cập nhật tồn kho: C:PHAInventoryRepository_Partial, F_UpdateInventoryHeaderV2, CP: 02");

                    }
                    else if (lstInventoryHeaderFromDBCheck.Count == 1) // ton tai du lieu trong inventoryheader => ko can lam gi, trigger bang inventorytransaction se thuc hien update ton kho tren header va line khi gap tinh trang Type = Update (da ghi nhan khi cap nhat line)
                    {

                    }
                    else // lstInventoryHeaderFromDBCheck.Count == 0
                    {

                        if (i_Type.Equals("Import") == true) // nếu là lưu từ phiếu nhập kho thì tạo  dòng mới để insert vào db
                        {
                            if ((item.qtyT + item.qtyImp) - item.qtyExp >= 0) //kiem tra cap nhat co lam sai so luong tồn kho không
                            {
                                List<PHA_inventoryh> lstInventoryHInsertCheck = (from invl in lstInventoryHeaderInsert.Where(x => x.storecode == item.storecode && x.drugcode.Trim() == item.drugcode.Trim() && x.mmyy == i_mmyy)
                                                                                 select invl).ToList();

                                //Kiem tra de dam bao lstInventoryLCheck chỉ co 1 dòng, nếu khác thi throw exception
                                if (lstInventoryHInsertCheck.Count > 1) //kiem tra neu > 1 => loi du lieu, vi chi co = 0 hoac = 1
                                {
                                    //CheckPoint: 03
                                    throw new LogicException("lstInventoryHeaderInsert tồn tại 2 dòng của 1 item: C:PHAInventoryRepository_Partial, F_UpdateInventoryHeaderV2, CP: 03");
                                }
                                else if (lstInventoryHInsertCheck.Count == 1) // ton tai item trùng => cap nhat so luong, roi cap nhat lai vao trong list Insert
                                {
                                    PHA_inventoryh inventoryHInsertRemove = lstInventoryHInsertCheck[0].CopyObject();
                                    PHA_inventoryh inventoryHInsertNew = lstInventoryHInsertCheck[0].CopyObject();
                                    inventoryHInsertNew = SetQtyUpdateInventoryHeader(inventoryHInsertNew, item);

                                    if ((inventoryHInsertNew.qtyt + inventoryHInsertNew.qtyimp - inventoryHInsertNew.qtyexp - inventoryHInsertNew.qtyrep) >= 0) //kiem tra cap nhat co lam sao so luong tồn kho không
                                    {
                                        lstInventoryHeaderInsert = RemoveElementInventoryHeader(lstInventoryHeaderInsert, inventoryHInsertRemove);
                                        lstInventoryHeaderInsert.Add(inventoryHInsertNew);
                                    }
                                    else
                                    {
                                        throw new LogicException(string.Format("Dữ liệu thêm mới vào phainventoryh không hợp lệ: siterf: {0}, storeid: {1}, drugid: {2}, qtyt: {3}, qtyimp: {4}, qtyexp: {5}, qtyrep: {6}", inventoryHInsertNew.siterf, inventoryHInsertNew.storecode, inventoryHInsertNew.drugcode, inventoryHInsertNew.qtyt, inventoryHInsertNew.qtyimp, inventoryHInsertNew.qtyexp, inventoryHInsertNew.qtyrep));
                                    }

                                }
                                else // lstInventoryHInsertCheck.Count == 0
                                {
                                    PHA_inventoryh inventoryHeaderInsert = new PHA_inventoryh();
                                    inventoryHeaderInsert.siterf = i_siterf;
                                    inventoryHeaderInsert.mmyy = i_mmyy;
                                    inventoryHeaderInsert.yyyy = DateTime.Now.Year.ToString();
                                    inventoryHeaderInsert.storecode = item.storecode;
                                    inventoryHeaderInsert.drugcode = item.drugcode;
                                    inventoryHeaderInsert.qtyt = item.qtyT;
                                    inventoryHeaderInsert.qtyimp = item.qtyImp;
                                    inventoryHeaderInsert.qtyexp = item.qtyExp;
                                    inventoryHeaderInsert.qtyrep = item.qtyReq;
                                    inventoryHeaderInsert.usercr = item.usercr;
                                    inventoryHeaderInsert.timecr = item.timecr;
                                    inventoryHeaderInsert.userup = item.userup;
                                    inventoryHeaderInsert.timeup = item.timeup;
                                    inventoryHeaderInsert.computer = item.computer;
                                    inventoryHeaderInsert.active = item.active;

                                    inventoryHeaderInsert.lotnumber = item.lotnumber;
                                    inventoryHeaderInsert.expirydate = item.expirydate;
                                    inventoryHeaderInsert.ofmanudate = item.ofmanudate;

                                    lstInventoryHeaderInsert.Add(inventoryHeaderInsert);
                                }
                            }
                            else
                            {
                                throw new LogicException(string.Format("Dữ liệu thêm mới vào lstInventoryHeaderInsert không hợp lệ: siterf: {0}, storeid: {1}, drugid: {2}, qtyt: {3}, qtyimp: {4}, qtyexp: {5}, qtyrep: {6}", i_siterf, item.storecode, item.drugcode, item.qtyT, item.qtyImp, item.qtyExp, item.qtyReq));
                            }
                        }
                        else if (i_HaveToData == true)
                        {
                            throw new LogicException(string.Format("Không tìm thấy dữ liệu để cập nhật phainventoryh: (siterf: {0}, storeid: {1}, drugid: {2}, followid: {3}, mmyy: {4}", i_siterf, item.storecode, item.drugcode, item.followid, i_mmyy));
                        }
                    }
                }

                if (lstInventoryHeaderInsert.Count > 0)
                    dbContext.BulkInsert(lstInventoryHeaderInsert);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private PHA_inventoryh SetQtyUpdateInventoryHeader(PHA_inventoryh i_InventoryHeaderUpdate, PHA_inventorySetUpdateModel i_Item)
        {
            try
            {
                if (i_InventoryHeaderUpdate == null)
                    throw new Exception("i_InventoryHeaderUpdate is null: C:PHAInventoryRepository_Partial, F_SetQtyUpdateInventoryHeader, CP: 01"); //CheckPoint: 01                

                PHA_inventoryh inventoryHeaderReturn = i_InventoryHeaderUpdate;
                inventoryHeaderReturn.qtyt += i_Item.qtyT * i_Item.actionT;
                inventoryHeaderReturn.qtyt = inventoryHeaderReturn.qtyt < 0 ? 0 : inventoryHeaderReturn.qtyt;
                inventoryHeaderReturn.qtyimp += i_Item.qtyImp * i_Item.actionImp;
                inventoryHeaderReturn.qtyimp = inventoryHeaderReturn.qtyimp < 0 ? 0 : inventoryHeaderReturn.qtyimp;
                inventoryHeaderReturn.qtyexp += i_Item.qtyExp * i_Item.qtyExp;
                inventoryHeaderReturn.qtyexp = inventoryHeaderReturn.qtyexp < 0 ? 0 : inventoryHeaderReturn.qtyexp;
                inventoryHeaderReturn.qtyrep += i_Item.qtyReq * i_Item.actionReq;

                return inventoryHeaderReturn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private List<PHA_inventoryh> RemoveElementInventoryHeader(List<PHA_inventoryh> i_lstInventoryHeaderUpdate, PHA_inventoryh i_InventoryHeaderRemove)
        {
            try
            {
                List<PHA_inventoryh> lstInventoryHeaderReturn = new List<PHA_inventoryh>();
                foreach (PHA_inventoryh item in i_lstInventoryHeaderUpdate)
                {
                    if (item.siterf != i_InventoryHeaderRemove.siterf || item.storecode != i_InventoryHeaderRemove.storecode || item.drugcode != i_InventoryHeaderRemove.drugcode || item.mmyy != i_InventoryHeaderRemove.mmyy)
                    {
                        lstInventoryHeaderReturn.Add(item);
                    }
                }

                return lstInventoryHeaderReturn;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<PHA_storeimporthReadModel> GetStoreImport(int i_Siterf, string i_SlipCode, int? i_StatusCode, int i_Option)
        {
            List<PHA_storeimporthReadModel> lstResult = new List<PHA_storeimporthReadModel>();
            try
            {
                List<PHA_storeimporth> lstStoreImporthEntity = new List<PHA_storeimporth>();
                List<PHA_storeimportl> lstStoreImportlEntity = new List<PHA_storeimportl>();

                lstStoreImporthEntity = dbContext.PHA_storeimporth.AsNoTracking().Where(x => x.siterf == i_Siterf && x.active == 1 && x.code == i_SlipCode && x.statuscode == i_StatusCode).ToList();

                if (lstStoreImporthEntity != null)
                {
                    //PHA_invoiceinput PHA_invoiceinputEntity = mapper.MapperInvoiceInputToEntity(i_Siterf, i_PHA_storeimporthModel.InvoiceInput);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstResult;
        }

        #endregion StoreImport

        #region Lưu đơn thuốc => phân lô giữ tồn tạm
        private static object lockSaveOP = new object();
        public string SavePrecription(int i_Siterf, int i_ObjectCode, PHA_prescriptionhModel i_PrescriptionhModel, int i_Option)
        {
            string idline = string.Empty;
            try
            {
                lock (lockSaveOP)
                {
                    string Message = string.Empty;
                    List<PHA_fltemp> lstFlTempEntity = new List<PHA_fltemp>();
                    List<PHA_fltemp> lstFlTempEntitySave = new List<PHA_fltemp>();
                    PHA_prescriptionh PrescriptionhCheckEntity = new PHA_prescriptionh();
                    List<PHA_prescriptionh> lstPrescriptionhEntitySave = new List<PHA_prescriptionh>();
                    List<PHA_prescriptionl> lstPrescriptionlEntity = new List<PHA_prescriptionl>();
                    List<PHA_prescriptionl> lstPrescriptionlDBEntity = new List<PHA_prescriptionl>();
                    List<PHA_prescriptionl> lstPrescriptionlCheckDrugNewEntity = new List<PHA_prescriptionl>();
                    List<PHA_prescriptionl> lstPrescriptionlEntitySave = new List<PHA_prescriptionl>();

                    PHA_prescriptionh PrescriptionhEntity = new PHA_prescriptionh();
                    PrescriptionhEntity = mapper.MapperPrescriptionhToEntity(i_Siterf, i_PrescriptionhModel);

                    if (PrescriptionhEntity != null)
                    {
                        PrescriptionhCheckEntity = dbContext.PHA_prescriptionh.AsNoTracking().Where(x => x.siterf == i_Siterf && x.active == 1 && x.idlink == i_PrescriptionhModel.idlink && x.mediid == i_PrescriptionhModel.mediid).FirstOrDefault();
                        lstPrescriptionlEntity = mapper.MapperlstPrescriptionlToEntity(i_Siterf, i_PrescriptionhModel.lstPrescriptionl, PrescriptionhEntity);

                        //1.Thêm đơn mới (lần đầu)
                        if (PrescriptionhCheckEntity == null)
                        {
                            lstPrescriptionhEntitySave.Add(PrescriptionhEntity);
                            if (lstPrescriptionlEntity.Count > 0)
                            {
                                lstFlTempEntity = mapper.MapperlstFltempToEntity(i_Siterf, lstPrescriptionlEntity);
                                //Check lại tồn kho
                                CheckInventoryByfl(lstFlTempEntity, ref lstFlTempEntitySave, ref Message);
                                //----------
                                if (lstFlTempEntitySave.Count > 0)
                                {
                                    lstPrescriptionlEntitySave = mapper.MapperlstPrescriptionlFromFltempToEntity(i_Siterf, lstFlTempEntitySave);
                                }
                            }

                        }
                        //2.Lưu đơn cũ (lần 2 trở len)
                        else
                        {
                            lstPrescriptionlDBEntity = dbContext.PHA_prescriptionl.AsNoTracking().Where(x => x.siterf == i_Siterf && x.active == 1 && x.idh == PrescriptionhEntity.idline).ToList();
                            //Kiểm tra có thêm thuốc mới so với đơn cũ
                            lstPrescriptionlCheckDrugNewEntity = lstPrescriptionlEntity.Except(lstPrescriptionlDBEntity).ToList();
                            if (lstPrescriptionlCheckDrugNewEntity.Count > 0)
                            {
                                lstFlTempEntity = mapper.MapperlstFltempToEntity(i_Siterf, lstPrescriptionlEntity);
                                CheckInventoryByfl(lstFlTempEntity, ref lstFlTempEntitySave, ref Message);
                                if (lstFlTempEntitySave.Count > 0)
                                {
                                    lstPrescriptionlEntitySave = mapper.MapperlstPrescriptionlFromFltempToEntity(i_Siterf, lstFlTempEntitySave);
                                }
                            }
                            //Không có thuốc mới nhưng có thay đổi sô lượng
                            else
                            {
                                List<PHA_prescriptionl> lstPresCreaseEntitySave = new List<PHA_prescriptionl>();
                                List<PHA_prescriptionl> lstPresReduceEntitySave = new List<PHA_prescriptionl>();
                                List<PHA_fltemp> lstFlCreaseTempEntity = new List<PHA_fltemp>();
                                List<PHA_fltemp> lstFlReduceTempEntity = new List<PHA_fltemp>();
                                List<PHA_fltemp> lstFlCreaseTempEntitySave = new List<PHA_fltemp>();


                                foreach (var item in lstPrescriptionlEntity)
                                {
                                    var checkDrugQty = lstPrescriptionlDBEntity.Where(x => x.followid == item.followid).FirstOrDefault();

                                    if (checkDrugQty != null)
                                    {
                                        if (item.qtyreq < checkDrugQty.qtyreq)
                                        {
                                            lstPresReduceEntitySave.Add(item);
                                        }
                                        else if (item.qtyreq > checkDrugQty.qtyreq)
                                        {
                                            lstPresCreaseEntitySave.Add(item);
                                        }
                                    }
                                }
                                if (lstPresReduceEntitySave.Count > 0)
                                {
                                    lstPrescriptionlEntitySave.AddRange(lstPresReduceEntitySave);
                                    lstFlReduceTempEntity = mapper.MapperlstFltempToEntity(i_Siterf, lstPrescriptionlEntitySave);
                                    if (lstFlReduceTempEntity.Count > 0)
                                    {
                                        lstFlTempEntitySave.AddRange(lstFlTempEntitySave);
                                    }

                                }
                                else if (lstPresCreaseEntitySave.Count > 0)
                                {
                                    lstFlCreaseTempEntity = mapper.MapperlstFltempToEntity(i_Siterf, lstPresCreaseEntitySave);

                                    CheckInventoryByfl(lstFlCreaseTempEntity, ref lstFlCreaseTempEntitySave, ref Message);
                                    if (lstFlCreaseTempEntitySave.Count > 0)
                                    {
                                        lstPresCreaseEntitySave = mapper.MapperlstPrescriptionlFromFltempToEntity(i_Siterf, lstFlCreaseTempEntitySave);
                                    }
                                    if (lstPresCreaseEntitySave.Count > 0)
                                    {
                                        lstPrescriptionlEntitySave.AddRange(lstPresCreaseEntitySave);
                                    }
                                    if (lstFlCreaseTempEntitySave.Count > 0)
                                    {
                                        lstFlTempEntitySave.AddRange(lstFlCreaseTempEntitySave);
                                    }
                                }
                            }
                        }
                        //3.Cât nhật tồn kho
                        if (lstPrescriptionlEntitySave.Count > 0)
                        {
                            List<PHA_inventorySetUpdateModel> lstInvenLineUpdate = new List<PHA_inventorySetUpdateModel>();
                            lstInvenLineUpdate = mapper.MapperLstPrescriptionlToInvenLineModel(i_Siterf, lstPrescriptionlEntitySave);

                            if (lstInvenLineUpdate.Count > 0)
                            {
                                UpdateInventoryGenerel(i_Siterf, lstInvenLineUpdate, "Import");
                            }
                        }

                        //4.Lấy giá theo lô
                        //5.Lưu dữ liệu
                        if (lstPrescriptionhEntitySave.Count > 0)
                        {
                            dbContext.BulkMerge(lstPrescriptionhEntitySave);
                        }
                        if (lstPrescriptionlEntitySave.Count > 0)
                        {
                            dbContext.BulkMerge(lstPrescriptionlEntitySave);
                        }
                        if (lstFlTempEntitySave.Count > 0)
                        {
                            dbContext.BulkMerge(lstFlTempEntitySave);
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return idline;
        }
        private void UpdateInventoryGenerel(int i_Siterf, List<PHA_inventorySetUpdateModel> lstInventoryLineUpdateReadModel, string i_Type)
        {
            try
            {
                if (lstInventoryLineUpdateReadModel.Count == 0)
                    return;

                if (lstInventoryLineUpdateReadModel.Select(x => x.siterf).Distinct().ToList().Count() > 1)
                    throw new LogicException("Trong danh sách thuốc cập nhật tồn kho, có nhiều hơn 1 siterf: C:PHAInventoryRepository_Partial, F_UpdateInventoryH_QtyExpReq, CP: 02");//CheckPoint: 01

                string mmyy = GetSchema(i_Siterf);
                if (mmyy.Length == 0)
                {
                    throw new LogicException("Không lấy được thông tin mmyy");
                }

                //Thuc hien lay danh sach drugid đã lọc trùng. Lấy ra danh sách để sử dụng join, ko sử dụng contain theo drugid, vì contain sẽ chậm hơn join
                List<PHA_inventorySetUpdateModel> lstInventoryLineUpdateReadModelDistinct = lstInventoryLineUpdateReadModel.DistinctBy(d => new
                {
                    d.siterf,
                    d.drugcode
                }).ToList();

                var DRUGITEM = dbContext.PHA_drugitem.ToList();

                List<PHA_drugitem> lstDrugById = (from lstILD in lstInventoryLineUpdateReadModelDistinct
                                                  join drug in dbContext.PHA_drugitem.AsNoTracking().Where(x => x.active == 1) on lstILD.drugcode.Trim() equals drug.code.Trim()
                                                  select drug).ToList();

                switch (i_Type)
                {
                    case "Import":
                        UpdateInventoryLineGenerel(i_Siterf, mmyy, lstInventoryLineUpdateReadModel, lstInventoryLineUpdateReadModelDistinct, lstDrugById, i_Type, false);
                        UpdateInventoryHeaderGenerel(i_Siterf, mmyy, lstInventoryLineUpdateReadModel, lstInventoryLineUpdateReadModelDistinct, lstDrugById, i_Type, false);
                        break;
                    default:
                        UpdateInventoryLineGenerel(i_Siterf, mmyy, lstInventoryLineUpdateReadModel, lstInventoryLineUpdateReadModelDistinct, lstDrugById, i_Type, true);
                        UpdateInventoryHeaderGenerel(i_Siterf, mmyy, lstInventoryLineUpdateReadModel, lstInventoryLineUpdateReadModelDistinct, lstDrugById, i_Type, true);
                        break;

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void UpdateInventoryLineGenerel(int i_siterf, string i_mmyy, List<PHA_inventorySetUpdateModel> lstInventoryLineUpdateReadModel, List<PHA_inventorySetUpdateModel> lstInventoryLineUpdateReadModelDistinct, List<PHA_drugitem> lstDrugById, string i_Type, bool i_HaveToData)
        {
            try
            {
                //Lay toan bo danh sach InventoryL theo siterf, mmyy, drugid => chap nhan dư thừa dữ liệu để query database 1 lần
                List<PHA_inventoryl> lstAllInventoryLineFromDB = (from lstILD in lstInventoryLineUpdateReadModelDistinct
                                                                  join invl in dbContext.PHA_inventoryl.AsNoTracking().Where(x => x.mmyy == i_mmyy) on lstILD.drugcode.Trim() equals invl.drugcode.Trim()
                                                                  select invl).ToList();

                List<PHA_inventoryl> lstInventoryLineInsert = new List<PHA_inventoryl>();

                foreach (PHA_inventorySetUpdateModel item in lstInventoryLineUpdateReadModel)
                {
                    PHA_drugitem drugInfo = lstDrugById.Where(x => x.code.Trim() == item.drugcode.Trim()).FirstOrDefault();
                    if (drugInfo == null)
                        throw new LogicException(string.Format("Không tìm thấy thuốc id: {0} trong danh mục", item.drugcode));

                    item.siterf = i_siterf;
                    item.drugcode = drugInfo.code;
                    item.mmyy = i_mmyy;

                    List<PHA_inventoryl> lstInventoryLFromDBCheck = (from invl in lstAllInventoryLineFromDB.Where(x => x.siterf == i_siterf && x.storecode == item.storecode && x.drugcode.Trim() == item.drugcode.Trim() && x.followid == item.followid && x.mmyy == i_mmyy)
                                                                     select invl).ToList();

                    if (lstInventoryLFromDBCheck.Count > 1)
                    {
                        throw new LogicException("lstInventoryLFromDBCheck tồn tại 2 dòng dữ liệu: C:PHAInventoryRepository_Partial, F_UpdateInventoryLineV2, CP: 02");
                    }
                    else if (lstInventoryLFromDBCheck.Count == 1) // ton tai du lieu trong inventoryline => ghi nhan tinh trang la Update
                    {
                        PHA_inventoryl inventoryLineFromDBUpdate = lstInventoryLFromDBCheck[0].CopyObject();

                        if ((inventoryLineFromDBUpdate.qtyt + inventoryLineFromDBUpdate.qtyimp - inventoryLineFromDBUpdate.qtyexp) - (item.qtyExp * item.actionExp) >= 0) //kiem tra cap nhat co lam sai so luong tồn kho không
                        {
                            item.typecode = "Update";
                        }
                        else
                        {
                            throw new LogicException(string.Format("Thuốc : {0} thuộc mã kho: {1}: {2}.", drugInfo.name, item.storecode, ConstantMessage.KhoKhongDuTonDeXuat));
                        }

                    }

                    else // lstInventoryLFromDBCheck.Count == 0
                    {

                        if (i_Type.Equals("Import") == true)
                        {

                            if ((item.qtyT + item.qtyImp) - item.qtyExp >= 0) //kiem tra cap nhat co lam sai so luong tồn kho không
                            {
                                PHA_inventoryl inventoryLineInsert = new PHA_inventoryl();
                                inventoryLineInsert.siterf = i_siterf;
                                inventoryLineInsert.mmyy = i_mmyy;
                                inventoryLineInsert.yyyy = DateTime.Now.Year.ToString();
                                inventoryLineInsert.storecode = item.storecode;
                                inventoryLineInsert.drugcode = item.drugcode;
                                //inventoryLineInsert.dateinput = DateTime.Now;
                                inventoryLineInsert.followid = item.followid;
                                inventoryLineInsert.qtyt = item.qtyT;
                                inventoryLineInsert.qtyimp = item.qtyImp;
                                inventoryLineInsert.qtyexp = item.qtyExp;
                                inventoryLineInsert.qtyrep = item.qtyReq;
                                inventoryLineInsert.price = item.price;

                                inventoryLineInsert.usercr = item.usercr;
                                inventoryLineInsert.timecr = item.timecr;
                                inventoryLineInsert.userup = item.userup;
                                inventoryLineInsert.timeup = item.timeup;
                                inventoryLineInsert.computer = item.computer;
                                inventoryLineInsert.active = item.active;

                                inventoryLineInsert.lotnumber = item.lotnumber;
                                inventoryLineInsert.expirydate = item.expirydate;
                                inventoryLineInsert.ofmanudate = item.ofmanudate;

                                lstInventoryLineInsert.Add(inventoryLineInsert);
                                item.typecode = "Insert"; //ko ton tai trong inventoryline => ghi nhan tinh trang la Insert => ko chay update qua inventory trong trigger
                            }
                            else
                            {
                                throw new LogicException(string.Format("Dữ liệu thêm mới vào lstInventoryLineInsert không hợp lệ: siterf: {0}, storeid: {1}, drugid: {2}, qtyt: {3}, qtyimp: {4}, qtyexp: {5}, qtyrep: {6}", i_siterf, item.storecode, item.drugcode, item.qtyT, item.qtyImp, item.qtyExp, item.qtyReq));
                            }
                        }
                        else if (i_HaveToData == true)
                        {
                            throw new LogicException(string.Format("Không tìm thấy dữ liệu để cập nhật phainventoryl: (siterf: {0}, storeid: {1}, drugid: {2}, followid: {3}, mmyy: {4}", i_siterf, item.storecode, item.drugcode, item.followid, i_mmyy));
                        }
                    }

                }

                List<PHA_inventorytransaction> lstInventoryTransactionInsert = mapper.MapperToInventoryTransactionEntity(i_siterf, lstInventoryLineUpdateReadModel);
                if (lstInventoryTransactionInsert.Count > 0)
                    dbContext.BulkInsert(lstInventoryTransactionInsert);

                if (lstInventoryLineInsert.Count > 0)
                    dbContext.BulkInsert(lstInventoryLineInsert);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void UpdateInventoryHeaderGenerel(int i_siterf, string i_mmyy, List<PHA_inventorySetUpdateModel> lstInventoryLineUpdateReadModel, List<PHA_inventorySetUpdateModel> lstInventoryLineUpdateReadModelDistinct, List<PHA_drugitem> lstDrugById, string i_Type, bool i_HaveToData)
        {
            try
            {
                //Lay toan bo danh sach InventoryH theo siterf, mmyy, drugid => chap nhan dư thừa dữ liệu để query database 1 lần
                List<PHA_inventoryh> lstAllInventoryHeaderFromDB = (from lstILD in lstInventoryLineUpdateReadModelDistinct
                                                                    join invh in dbContext.PHA_inventoryh.AsNoTracking().Where(x => x.mmyy == i_mmyy) on lstILD.drugcode.Trim() equals invh.drugcode.Trim()
                                                                    select invh).ToList();

                List<PHA_inventoryh> lstInventoryHeaderInsert = new List<PHA_inventoryh>();

                foreach (PHA_inventorySetUpdateModel item in lstInventoryLineUpdateReadModel)
                {
                    PHA_drugitem drugInfo = lstDrugById.Where(x => x.code.Trim() == item.drugcode.Trim()).FirstOrDefault();
                    if (drugInfo == null)
                        throw new LogicException(string.Format("Không tìm thấy thuốc id: {0} trong danh mục", item.drugcode));

                    item.siterf = i_siterf;
                    item.drugcode = drugInfo.code;
                    item.mmyy = i_mmyy;

                    //kiem tra trong list lay len tu database
                    List<PHA_inventoryh> lstInventoryHeaderFromDBCheck = (from invl in lstAllInventoryHeaderFromDB.Where(x => x.storecode == item.storecode && x.drugcode.Trim() == item.drugcode.Trim() && x.mmyy == i_mmyy)
                                                                          select invl).ToList();

                    if (lstInventoryHeaderFromDBCheck.Count > 1) //kiem tra neu > 1 => loi du lieu, vi chi co = 0 hoac = 1
                    {
                        //CheckPoint: 02
                        throw new LogicException("Dữ liệu nhiều hơn 1 dòng khi thực hiện cập nhật tồn kho: C:PHAInventoryRepository_Partial, F_UpdateInventoryHeaderV2, CP: 02");

                    }
                    else if (lstInventoryHeaderFromDBCheck.Count == 1) // ton tai du lieu trong inventoryheader => ko can lam gi, trigger bang inventorytransaction se thuc hien update ton kho tren header va line khi gap tinh trang Type = Update (da ghi nhan khi cap nhat line)
                    {

                    }
                    else // lstInventoryHeaderFromDBCheck.Count == 0
                    {

                        if (i_Type.Equals("Import") == true) // nếu là lưu từ phiếu nhập kho thì tạo  dòng mới để insert vào db
                        {
                            if ((item.qtyT + item.qtyImp) - item.qtyExp >= 0) //kiem tra cap nhat co lam sai so luong tồn kho không
                            {
                                List<PHA_inventoryh> lstInventoryHInsertCheck = (from invl in lstInventoryHeaderInsert.Where(x => x.storecode == item.storecode && x.drugcode.Trim() == item.drugcode.Trim() && x.mmyy == i_mmyy)
                                                                                 select invl).ToList();

                                //Kiem tra de dam bao lstInventoryLCheck chỉ co 1 dòng, nếu khác thi throw exception
                                if (lstInventoryHInsertCheck.Count > 1) //kiem tra neu > 1 => loi du lieu, vi chi co = 0 hoac = 1
                                {
                                    //CheckPoint: 03
                                    throw new LogicException("lstInventoryHeaderInsert tồn tại 2 dòng của 1 item: C:PHAInventoryRepository_Partial, F_UpdateInventoryHeaderV2, CP: 03");
                                }
                                else if (lstInventoryHInsertCheck.Count == 1) // ton tai item trùng => cap nhat so luong, roi cap nhat lai vao trong list Insert
                                {
                                    PHA_inventoryh inventoryHInsertRemove = lstInventoryHInsertCheck[0].CopyObject();
                                    PHA_inventoryh inventoryHInsertNew = lstInventoryHInsertCheck[0].CopyObject();
                                    inventoryHInsertNew = SetQtyUpdateInventoryHeader(inventoryHInsertNew, item);

                                    if ((inventoryHInsertNew.qtyt + inventoryHInsertNew.qtyimp - inventoryHInsertNew.qtyexp - inventoryHInsertNew.qtyrep) >= 0) //kiem tra cap nhat co lam sao so luong tồn kho không
                                    {
                                        lstInventoryHeaderInsert = RemoveElementInventoryHeader(lstInventoryHeaderInsert, inventoryHInsertRemove);
                                        lstInventoryHeaderInsert.Add(inventoryHInsertNew);
                                    }
                                    else
                                    {
                                        throw new LogicException(string.Format("Dữ liệu thêm mới vào phainventoryh không hợp lệ: siterf: {0}, storeid: {1}, drugid: {2}, qtyt: {3}, qtyimp: {4}, qtyexp: {5}, qtyrep: {6}", inventoryHInsertNew.siterf, inventoryHInsertNew.storecode, inventoryHInsertNew.drugcode, inventoryHInsertNew.qtyt, inventoryHInsertNew.qtyimp, inventoryHInsertNew.qtyexp, inventoryHInsertNew.qtyrep));
                                    }

                                }
                                else // lstInventoryHInsertCheck.Count == 0
                                {
                                    PHA_inventoryh inventoryHeaderInsert = new PHA_inventoryh();
                                    inventoryHeaderInsert.siterf = i_siterf;
                                    inventoryHeaderInsert.mmyy = i_mmyy;
                                    inventoryHeaderInsert.yyyy = DateTime.Now.Year.ToString();
                                    inventoryHeaderInsert.storecode = item.storecode;
                                    inventoryHeaderInsert.drugcode = item.drugcode;
                                    inventoryHeaderInsert.qtyt = item.qtyT;
                                    inventoryHeaderInsert.qtyimp = item.qtyImp;
                                    inventoryHeaderInsert.qtyexp = item.qtyExp;
                                    inventoryHeaderInsert.qtyrep = item.qtyReq;
                                    inventoryHeaderInsert.usercr = item.usercr;
                                    inventoryHeaderInsert.timecr = item.timecr;
                                    inventoryHeaderInsert.userup = item.userup;
                                    inventoryHeaderInsert.timeup = item.timeup;
                                    inventoryHeaderInsert.computer = item.computer;
                                    inventoryHeaderInsert.active = item.active;

                                    inventoryHeaderInsert.lotnumber = item.lotnumber;
                                    inventoryHeaderInsert.expirydate = item.expirydate;
                                    inventoryHeaderInsert.ofmanudate = item.ofmanudate;

                                    lstInventoryHeaderInsert.Add(inventoryHeaderInsert);
                                }
                            }
                            else
                            {
                                throw new LogicException(string.Format("Dữ liệu thêm mới vào lstInventoryHeaderInsert không hợp lệ: siterf: {0}, storeid: {1}, drugid: {2}, qtyt: {3}, qtyimp: {4}, qtyexp: {5}, qtyrep: {6}", i_siterf, item.storecode, item.drugcode, item.qtyT, item.qtyImp, item.qtyExp, item.qtyReq));
                            }
                        }
                        else if (i_HaveToData == true)
                        {
                            throw new LogicException(string.Format("Không tìm thấy dữ liệu để cập nhật phainventoryh: (siterf: {0}, storeid: {1}, drugid: {2}, followid: {3}, mmyy: {4}", i_siterf, item.storecode, item.drugcode, item.followid, i_mmyy));
                        }
                    }
                }

                if (lstInventoryHeaderInsert.Count > 0)
                    dbContext.BulkInsert(lstInventoryHeaderInsert);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Lưu đơn thuốc => phân lô giữ tồn tạm

        public void CheckInventoryByfl(List<PHA_fltemp> lstFltempCheck, ref List<PHA_fltemp> lstFltempSelect, ref string i_Message)
        {
            try
            {
                List<string> lstfollowid = lstFltempCheck.Select(s => s.followid).ToList();
                List<string> lstdrugcode = lstFltempCheck.Select(s => s.drugcode).ToList();
                var lstCheckInvenDB = dbContext.PHA_inventoryl.Where(x => lstdrugcode.Contains(x.drugcode)).ToList();

                if (lstCheckInvenDB.Count > 0)
                {
                    if (lstFltempCheck.Count() == lstCheckInvenDB.Where(x => lstfollowid.Contains(x.followid)).Count())
                    {
                        foreach (var item in lstFltempCheck)
                        {
                            foreach (var itemDB in lstCheckInvenDB)
                            {
                                decimal CheckInvenByItem = (itemDB.qtyt + itemDB.qtyimp - itemDB.qtyexp - itemDB.qtyrep);
                                if (CheckInvenByItem == 0)
                                {
                                    //Tìm lô khác để bổ sung cho đủ số lợng yêu cầu
                                    var flOrther = lstCheckInvenDB.Where(x => x.drugcode == item.drugcode && (x.qtyt + x.qtyimp - x.qtyexp - x.qtyrep) >= item.qtyreq).FirstOrDefault();
                                    if (flOrther != null)
                                    {
                                        PHA_fltemp itemNew = item.CopyObject();
                                        itemNew.followid = flOrther.followid;
                                        itemNew.qtyreq = (int)flOrther.qtyrep;
                                        lstFltempSelect.Add(item);
                                    }
                                    else
                                    {
                                        i_Message += item.drugcode + "+";
                                    }
                                }
                                else
                                {
                                    decimal qtyReqCheck = 0;
                                    //Tồn kho không đủ
                                    qtyReqCheck = (decimal)(item.qtyreq) - (decimal)CheckInvenByItem;

                                    if (qtyReqCheck > 0)
                                    {
                                        if (CheckInvenByItem > 0)
                                        {
                                            item.qtyreq = (int)CheckInvenByItem;
                                            lstFltempSelect.Add(item);
                                        }
                                        //Tìm lô khác để bổ sung cho đủ số lợng yêu cầu
                                        var flOrther = lstCheckInvenDB.Where(x => x.drugcode == item.drugcode && (x.qtyt + x.qtyimp - x.qtyexp - x.qtyrep) >= item.qtyreq).FirstOrDefault();
                                        if (flOrther != null)
                                        {
                                            PHA_fltemp itemNew = item.CopyObject();
                                            itemNew.followid = flOrther.followid;
                                            itemNew.qtyreq = (int)flOrther.qtyrep - (decimal)qtyReqCheck;
                                            lstFltempSelect.Add(item);
                                        }
                                        else
                                        {
                                            i_Message += item.drugcode + "+";
                                        }
                                    }
                                    else
                                    {
                                        lstFltempSelect.Add(item);
                                    }

                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetSchema(int i_Siterf)
        {
            var result = "";
            try
            {
                result = dbContext.sysschemas.AsNoTracking().Where(x => x.active == 1 && x.siterf == i_Siterf).Select(x => x.mmyy).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;
        }
    }
}
