using AutoMapper;
using Emr.Domain.Entities.Pha;
using Emr.Domain.Model.Pha.Inventory;
using Emr.Domain.Model.Pha.Prescription;
using Emr.Domain.Model.Pha.StoreImport;
using Emr.Domain.ReadModel.Pha;
using System;
using System.Collections.Generic;

namespace Emr.Infrastructure.RepoMapper.Pha
{
    public class PhaEntityMapper
    {
        internal MapperConfiguration icfg;
        internal IMapper iMap;

        internal List<PHA_inventorylReadModel> MapFromEntityToReadModelDrugInventoryl(List<PHA_inventoryl> i_phainventoryl)
        {
            icfg = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PHA_inventoryl, PHA_inventorylReadModel>()
                //.ForMember(m => m.timecr, d => d.MapFrom(z => DateTime.Now))
                //.ForMember(m => m.patcode, d => d.MapFrom(z => i_MediRegisterModel.patcode))
                //.ForMember(m => m.patienttype, d => d.MapFrom(z => i_MediRegisterModel.patienttype))
                //.ForMember(m => m.objectcode, d => d.MapFrom(z => i_MediRegisterModel.objectcode))
                .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            });
            iMap = icfg.CreateMapper();
            return iMap.Map<List<PHA_inventoryl>, List<PHA_inventorylReadModel>>(i_phainventoryl);
        }

        internal PHA_storeimporth MapperStoreImporthToEntity(int i_Siterf, PHA_storeimporthModel i_PHA_storeimporthModel, PHA_invoiceinput i_PHA_invoiceinput)
        {
            icfg = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PHA_storeimporthModel, PHA_storeimporth>()
                .ForMember(des => des.siterf, sr => sr.MapFrom(z => i_Siterf))
                .ForMember(des => des.active, sr => sr.MapFrom(z => z.active == 0 ? 1 : z.active))
                .ForMember(des => des.timeup, sr => sr.MapFrom(z => DateTime.Now))
                .ForMember(des => des.timecr, sr => sr.MapFrom(z => z.timecr == null ? DateTime.Now : z.timecr))

                .ForMember(des => des.invoiceid, sr => sr.MapFrom(z => i_PHA_invoiceinput.idline))
                //.ForMember(des => des.invoicetempid, sr => sr.MapFrom(z => i_PHA_invoiceinput.idline))
                .ForMember(des => des.idline, sr => sr.MapFrom(z => string.IsNullOrEmpty(z.idline) ? Guid.NewGuid().ToString() : z.idline))
                ;
            });
            iMap = icfg.CreateMapper();
            return iMap.Map<PHA_storeimporthModel, PHA_storeimporth>(i_PHA_storeimporthModel);
        }
        internal PHA_flstoreimport MapperFlstoreImportToEntity(int i_Siterf, PHA_storeimporth i_PHA_storeimporth, int i_Option)
        {
            icfg = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PHA_storeimporth, PHA_flstoreimport>()
                .ForMember(des => des.siterf, sr => sr.MapFrom(z => i_Siterf))
                .ForMember(des => des.active, sr => sr.MapFrom(z => z.active == 0 ? 1 : z.active))
                .ForMember(des => des.timeup, sr => sr.MapFrom(z => DateTime.Now))
                .ForMember(des => des.timecr, sr => sr.MapFrom(z => z.timecr == null ? DateTime.Now : z.timecr))

                .ForMember(des => des.idline, sr => sr.MapFrom(z => string.IsNullOrEmpty(z.idline) ? Guid.NewGuid().ToString() : z.idline))
                .ForMember(des => des.slipid, sr => sr.MapFrom(z => z.idline))
                .ForMember(des => des.slipcode, sr => sr.MapFrom(z => z.code))
                .ForMember(des => des.sliptypecode, sr => sr.MapFrom(z => z.sliptypecode))
                .ForMember(des => des.status, sr => sr.MapFrom(z => z.statuscode));
            });
            iMap = icfg.CreateMapper();
            return iMap.Map<PHA_storeimporth, PHA_flstoreimport>(i_PHA_storeimporth);
        }

        internal PHA_invoiceinput MapperInvoiceInputToEntity(int i_Siterf, PHA_invoiceinputModel i_PHA_invoiceinputModel)
        {
            icfg = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PHA_invoiceinputModel, PHA_invoiceinput>()
                .ForMember(des => des.siterf, sr => sr.MapFrom(z => i_Siterf))
                .ForMember(des => des.active, sr => sr.MapFrom(z => z.active == 0 ? 1 : z.active))
                .ForMember(des => des.timeup, sr => sr.MapFrom(z => DateTime.Now))
                .ForMember(des => des.timecr, sr => sr.MapFrom(z => z.timecr == null ? DateTime.Now : z.timecr))
                //.ForMember(des => des.year, sr => sr.MapFrom(z => z.year == 0 ? DateTime.Now.Year : z.year))
                .ForMember(des => des.idline, sr => sr.MapFrom(z => string.IsNullOrEmpty(z.idline) ? Guid.NewGuid().ToString() : z.idline))
                ;
            });
            iMap = icfg.CreateMapper();
            return iMap.Map<PHA_invoiceinputModel, PHA_invoiceinput>(i_PHA_invoiceinputModel);
        }
        internal PHA_storeimportl MapperStoreImportlToEntity(int i_Siterf, PHA_storeimportlModel i_PHA_storeimportlModel)
        {
            icfg = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PHA_storeimporthModel, PHA_storeimportl>()
                .ForMember(des => des.siterf, sr => sr.MapFrom(z => i_Siterf))
                .ForMember(des => des.active, sr => sr.MapFrom(z => z.active == 0 ? 1 : z.active))
                .ForMember(des => des.timeup, sr => sr.MapFrom(z => DateTime.Now))
                .ForMember(des => des.timecr, sr => sr.MapFrom(z => z.timecr == null ? DateTime.Now : z.timecr))
                //.ForMember(des => des.year, sr => sr.MapFrom(z => z.year == 0 ? DateTime.Now.Year : z.year))
                //.ForMember(des => des.idline, sr => sr.MapFrom(z => z.idline == null || z.idline == Guid.Empty ? Guid.NewGuid() : z.idline))
                ;
            });
            iMap = icfg.CreateMapper();
            return iMap.Map<PHA_storeimportlModel, PHA_storeimportl>(i_PHA_storeimportlModel);
        }
        internal List<PHA_storeimportl> MapperLstStoreImportlToEntity(int i_Siterf, List<PHA_storeimportlModel> i_lstStoreImportlModel, PHA_storeimporth i_StoreImporthEntity)
        {
            icfg = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PHA_storeimportlModel, PHA_storeimportl>()
                .ForMember(des => des.idline, sr => sr.MapFrom(z => string.IsNullOrEmpty(z.idline) ? Guid.NewGuid().ToString() : z.idline))
                .ForMember(des => des.drugcode, sr => sr.MapFrom(z => z.drugcode))
                .ForMember(des => des.followid, sr => sr.MapFrom(z => string.IsNullOrEmpty(z.followid) ? Guid.NewGuid().ToString() : z.followid))
                .ForMember(des => des.siterf, sr => sr.MapFrom(z => i_Siterf))
                .ForMember(des => des.active, sr => sr.MapFrom(z => z.active == 0 ? 1 : z.active))
                .ForMember(des => des.timeup, sr => sr.MapFrom(z => DateTime.Now))
                .ForMember(des => des.timecr, sr => sr.MapFrom(z => z.timecr == null ? DateTime.Now : z.timecr))
                .ForMember(des => des.idh, sr => sr.MapFrom(z => i_StoreImporthEntity.idline))
                .ForMember(des => des.yyyy, sr => sr.MapFrom(z => i_StoreImporthEntity.yyyy))
                .ForMember(des => des.mmyy, sr => sr.MapFrom(z => i_StoreImporthEntity.mmyy));

            });
            iMap = icfg.CreateMapper();
            return iMap.Map<List<PHA_storeimportlModel>, List<PHA_storeimportl>>(i_lstStoreImportlModel);
        }
        internal List<PHA_follow> MapperLstfollowToEntity(int i_Siterf, List<PHA_storeimportl> i_lstStoreImportlEntity, PHA_storeimporth i_StoreImporthEntity)
        {
            icfg = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PHA_storeimportl, PHA_follow>()
                .ForMember(des => des.idline, sr => sr.MapFrom(z => z.idline))

                .ForMember(des => des.siterf, sr => sr.MapFrom(z => i_Siterf))
                .ForMember(des => des.active, sr => sr.MapFrom(z => z.active == 0 ? 1 : z.active))
                .ForMember(des => des.timeup, sr => sr.MapFrom(z => DateTime.Now))
                .ForMember(des => des.timecr, sr => sr.MapFrom(z => z.timecr == null ? DateTime.Now : z.timecr))
                .ForMember(des => des.idl, sr => sr.MapFrom(z => z.idline))

                .ForMember(des => des.pricecost, sr => sr.MapFrom(z => z.total.Value / z.convertqty.Value))

                .ForMember(des => des.idh, sr => sr.MapFrom(z => i_StoreImporthEntity.idline))
                .ForMember(des => des.yyyy, sr => sr.MapFrom(z => i_StoreImporthEntity.yyyy))
                .ForMember(des => des.mmyy, sr => sr.MapFrom(z => i_StoreImporthEntity.mmyy))
                .ForMember(des => des.inputtypecode, sr => sr.MapFrom(z => i_StoreImporthEntity.sliptypecode));

            });
            iMap = icfg.CreateMapper();
            return iMap.Map<List<PHA_storeimportl>, List<PHA_follow>>(i_lstStoreImportlEntity);
        }

        internal List<PHA_inventorySetUpdateModel> MapperLstStoreImportlToInvenLineModel(int i_Siterf, List<PHA_storeimportl> i_lstStoreImportlEntity, PHA_storeimporth i_StoreImporthEntity)
        {
            icfg = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PHA_storeimportl, PHA_inventorySetUpdateModel>()


                .ForMember(des => des.siterf, sr => sr.MapFrom(z => i_Siterf))
                .ForMember(des => des.active, sr => sr.MapFrom(z => z.active == 0 ? 1 : z.active))
                .ForMember(des => des.timeup, sr => sr.MapFrom(z => DateTime.Now))
                .ForMember(des => des.timecr, sr => sr.MapFrom(z => z.timecr == null ? DateTime.Now : z.timecr))

                .ForMember(des => des.followid, sr => sr.MapFrom(z => z.idline))
                .ForMember(des => des.yyyy, sr => sr.MapFrom(z => i_StoreImporthEntity.yyyy))
                .ForMember(des => des.mmyy, sr => sr.MapFrom(z => i_StoreImporthEntity.mmyy))
                .ForMember(des => des.storecode, sr => sr.MapFrom(z => i_StoreImporthEntity.storecode))
                .ForMember(des => des.dateinput, sr => sr.MapFrom(z => DateTime.Now))

                .ForMember(des => des.qtyImp, sr => sr.MapFrom(z => z.convertqty))
                .ForMember(des => des.price, sr => sr.MapFrom(z => z.total.Value / z.convertqty.Value))
                .ForMember(des => des.amount, sr => sr.MapFrom(z => z.total))
                .ForMember(des => des.lotnumber, sr => sr.MapFrom(z => z.lotnumber))
                .ForMember(des => des.expirydate, sr => sr.MapFrom(z => z.expirydate))
                .ForMember(des => des.ofmanudate, sr => sr.MapFrom(z => z.ofmanudate));

            });
            iMap = icfg.CreateMapper();
            return iMap.Map<List<PHA_storeimportl>, List<PHA_inventorySetUpdateModel>>(i_lstStoreImportlEntity);
        }

        internal List<PHA_inventorySetUpdateModel> MapperLstPrescriptionlToInvenLineModel(int i_Siterf, List<PHA_prescriptionl> i_lstPHA_prescriptionl)
        {
            icfg = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PHA_prescriptionl, PHA_inventorySetUpdateModel>()

                .ForMember(des => des.siterf, sr => sr.MapFrom(z => i_Siterf))
                .ForMember(des => des.active, sr => sr.MapFrom(z => z.active == 0 ? 1 : z.active))
                .ForMember(des => des.timeup, sr => sr.MapFrom(z => DateTime.Now))
                .ForMember(des => des.timecr, sr => sr.MapFrom(z => z.timecr == null ? DateTime.Now : z.timecr))
                .ForMember(des => des.followid, sr => sr.MapFrom(z => z.idline))
                .ForMember(des => des.storecode, sr => sr.MapFrom(z => z.storecode))
                .ForMember(des => des.qtyReq, sr => sr.MapFrom(z => z.qtyreq))
                .ForMember(des => des.lotnumber, sr => sr.MapFrom(z => z.lotnumber))
                .ForMember(des => des.expirydate, sr => sr.MapFrom(z => z.expirydate))
                .ForMember(des => des.ofmanudate, sr => sr.MapFrom(z => z.ofmanudate));

            });
            iMap = icfg.CreateMapper();
            return iMap.Map<List<PHA_prescriptionl>, List<PHA_inventorySetUpdateModel>>(i_lstPHA_prescriptionl);
        }
        internal List<PHA_inventorytransaction> MapperToInventoryTransactionEntity(int i_Siterf, List<PHA_inventorySetUpdateModel> i_lstinventorySetUpdateModel)
        {
            icfg = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PHA_inventorySetUpdateModel, PHA_inventorytransaction>()

                .ForMember(des => des.siterf, sr => sr.MapFrom(z => z.siterf))
                .ForMember(des => des.idline, sr => sr.MapFrom(z => Guid.NewGuid().ToString()))

                .ForMember(des => des.mmyy, sr => sr.MapFrom(z => z.mmyy))
                .ForMember(des => des.drugcode, sr => sr.MapFrom(z => z.drugcode))
                .ForMember(des => des.followid, sr => sr.MapFrom(z => z.followid))
                .ForMember(des => des.qtyt, sr => sr.MapFrom(z => z.qtyT * z.actionT))
                .ForMember(des => des.qtyimp, sr => sr.MapFrom(z => z.qtyImp * z.actionImp))
                .ForMember(des => des.qtyexp, sr => sr.MapFrom(z => z.qtyExp * z.actionExp))
                .ForMember(des => des.qtyrep, sr => sr.MapFrom(z => z.qtyReq * z.actionReq))
                .ForMember(des => des.datalog, sr => sr.MapFrom(z => z.datalog))
                .ForMember(des => des.typestatuscode, sr => sr.MapFrom(z => z.typestatuscode))
                //.ForMember(des => des.status, sr => sr.MapFrom(z => z.status))
                .ForMember(des => des.usercr, sr => sr.MapFrom(z => z.usercr))
                .ForMember(des => des.userup, sr => sr.MapFrom(z => z.userup))
                .ForMember(des => des.computer, sr => sr.MapFrom(z => z.computer));
            });
            iMap = icfg.CreateMapper();
            return iMap.Map<List<PHA_inventorySetUpdateModel>, List<PHA_inventorytransaction>>(i_lstinventorySetUpdateModel);
        }

        internal PHA_prescriptionh MapperPrescriptionhToEntity(int i_Siterf, PHA_prescriptionhModel i_PrescriptionhModel)
        {
            icfg = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PHA_prescriptionhModel, PHA_prescriptionh>()
                .ForMember(des => des.idline, sr => sr.MapFrom(z => string.IsNullOrEmpty(z.idline) ? Guid.NewGuid().ToString() : z.idline))
                .ForMember(des => des.siterf, sr => sr.MapFrom(z => i_Siterf))
                .ForMember(des => des.active, sr => sr.MapFrom(z => z.active == 0 ? 1 : z.active))
                .ForMember(des => des.timeup, sr => sr.MapFrom(z => DateTime.Now));
            });
            iMap = icfg.CreateMapper();
            return iMap.Map<PHA_prescriptionhModel, PHA_prescriptionh>(i_PrescriptionhModel);
        }
        internal List<PHA_prescriptionl> MapperlstPrescriptionlToEntity(int i_Siterf, List<PHA_prescriptionlModel> i_lstPrescriptionlModel, PHA_prescriptionh i_Prescriptionh)
        {
            icfg = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PHA_prescriptionlModel, PHA_prescriptionl>()
                .ForMember(des => des.idline, sr => sr.MapFrom(z => string.IsNullOrEmpty(z.idline) ? Guid.NewGuid().ToString() : z.idline))
                .ForMember(des => des.codeh, sr => sr.MapFrom(z => z.codeh))
                .ForMember(des => des.siterf, sr => sr.MapFrom(z => i_Siterf))
                .ForMember(des => des.active, sr => sr.MapFrom(z => z.active == 0 ? 1 : z.active))
                .ForMember(des => des.timeup, sr => sr.MapFrom(z => DateTime.Now))
                .ForMember(des => des.timecr, sr => sr.MapFrom(z => z.timecr == null ? DateTime.Now : z.timecr))

                .ForMember(des => des.idh, sr => sr.MapFrom(z => i_Prescriptionh.idline))
                .ForMember(des => des.yyyy, sr => sr.MapFrom(z => i_Prescriptionh.yyyy))
                .ForMember(des => des.mmyy, sr => sr.MapFrom(z => i_Prescriptionh.mmyy));

            });
            iMap = icfg.CreateMapper();
            return iMap.Map<List<PHA_prescriptionlModel>, List<PHA_prescriptionl>>(i_lstPrescriptionlModel);
        }

        internal List<PHA_fltemp> MapperlstFltempToEntity(int i_Siterf, List<PHA_prescriptionl> i_PHA_prescriptionl)
        {
            icfg = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PHA_prescriptionl, PHA_fltemp>()
                .ForMember(des => des.idline, sr => sr.MapFrom(z => string.IsNullOrEmpty(z.idline) ? Guid.NewGuid().ToString() : z.idline))
                .ForMember(des => des.idh, sr => sr.MapFrom(z => z.idh))
                .ForMember(des => des.codeh, sr => sr.MapFrom(z => z.codeh))
                .ForMember(des => des.followid, sr => sr.MapFrom(z => z.followid))
                .ForMember(des => des.siterf, sr => sr.MapFrom(z => i_Siterf))
                .ForMember(des => des.active, sr => sr.MapFrom(z => z.active == 0 ? 1 : z.active))
                .ForMember(des => des.timeup, sr => sr.MapFrom(z => DateTime.Now))
                .ForMember(des => des.timecr, sr => sr.MapFrom(z => z.timecr == null ? DateTime.Now : z.timecr));
            });
            iMap = icfg.CreateMapper();
            return iMap.Map<List<PHA_prescriptionl>, List<PHA_fltemp>>(i_PHA_prescriptionl);
        }
        internal List<PHA_prescriptionl> MapperlstPrescriptionlFromFltempToEntity(int i_Siterf, List<PHA_fltemp> i_PHA_fltemp)
        {
            icfg = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PHA_fltemp, PHA_prescriptionl>()
                .ForMember(des => des.idline, sr => sr.MapFrom(z => string.IsNullOrEmpty(z.idline) ? Guid.NewGuid().ToString() : z.idline))

                .ForMember(des => des.idh, sr => sr.MapFrom(z => z.idh))
                .ForMember(des => des.codeh, sr => sr.MapFrom(z => z.codeh))
                .ForMember(des => des.followid, sr => sr.MapFrom(z => z.followid))

                .ForMember(des => des.siterf, sr => sr.MapFrom(z => i_Siterf))
                .ForMember(des => des.active, sr => sr.MapFrom(z => z.active == 0 ? 1 : z.active))
                .ForMember(des => des.timeup, sr => sr.MapFrom(z => DateTime.Now))
                .ForMember(des => des.timecr, sr => sr.MapFrom(z => z.timecr == null ? DateTime.Now : z.timecr));
            });
            iMap = icfg.CreateMapper();
            return iMap.Map<List<PHA_fltemp>, List<PHA_prescriptionl>>(i_PHA_fltemp);
        }

        internal List<PHA_prescriptionl> MapperlstPrescriptionlToEntity(int i_Siterf, List<PHA_fltemp> i_PHA_fltemp)
        {
            icfg = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PHA_fltemp, PHA_prescriptionl>()
                .ForMember(des => des.idline, sr => sr.MapFrom(z => string.IsNullOrEmpty(z.idline) ? Guid.NewGuid().ToString() : z.idline))

                .ForMember(des => des.idh, sr => sr.MapFrom(z => z.idh))
                .ForMember(des => des.codeh, sr => sr.MapFrom(z => z.codeh))
                .ForMember(des => des.followid, sr => sr.MapFrom(z => z.followid))

                .ForMember(des => des.siterf, sr => sr.MapFrom(z => i_Siterf))
                .ForMember(des => des.active, sr => sr.MapFrom(z => z.active == 0 ? 1 : z.active))
                .ForMember(des => des.timeup, sr => sr.MapFrom(z => DateTime.Now))
                .ForMember(des => des.timecr, sr => sr.MapFrom(z => z.timecr == null ? DateTime.Now : z.timecr));
            });
            iMap = icfg.CreateMapper();
            return iMap.Map<List<PHA_fltemp>, List<PHA_prescriptionl>>(i_PHA_fltemp);
        }
    }
}
