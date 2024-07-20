using Emr.Domain.Common;
using Emr.Domain.Entities.Pha;
using System;
using System.Collections.Generic;

namespace Emr.Domain.Model.Pha.StoreImport
{
    public class PHA_storeimporthModel : BaseModel
    {
        public string idline { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public int? sliptypecode { get; set; }
        public int? actioncode { get; set; }
        public int? statuscode { get; set; }
        public int? storecode { get; set; }
        public DateTime? datecreate { get; set; }
        public string usercreate { get; set; }
        public DateTime? dateapprove { get; set; }
        public string userapprove { get; set; }
        public string invoiceid { get; set; }
        public string invoicetempid { get; set; }
        public DateTime? invoicedate { get; set; }
        public string numdeliverycode { get; set; }
        public string note { get; set; }
        public string attributes { get; set; }
        public string datalog { get; set; }
        public string mmyy { get; set; }
        public string yyyy { get; set; }
        public int? siterf { get; set; }
        public int? active { get; set; }
        public PHA_invoiceinputModel InvoiceInput { get; set; }
        public List<PHA_storeimportlModel> lstStoreImportl { get; set; }
    }
}
