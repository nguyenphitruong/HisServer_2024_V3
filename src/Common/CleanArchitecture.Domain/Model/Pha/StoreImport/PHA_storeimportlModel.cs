using Emr.Domain.Common;
using System;

namespace Emr.Domain.Model.Pha.StoreImport
{
    public class PHA_storeimportlModel : BaseModel
    {
        public string idline { get; set; }
        public string drugcode { get; set; }
        public string followid { get; set; }
        public string idh { get; set; }
        public string lotnumber { get; set; }
        public DateTime? expirydate { get; set; }
        public DateTime? ofmanudate { get; set; }
        public string bidcontractid { get; set; }
        public int? sort { get; set; }
        public decimal? invoiceqty { get; set; }
        public decimal? convertqty { get; set; }
        public decimal? total { get; set; }
        public int? vatrate { get; set; }
        public decimal? vatamount { get; set; }
        public int? discounttypecode { get; set; }
        public decimal? discountcash { get; set; }
        public int? discountrate { get; set; }
        public bool? isdiscount { get; set; }
        public int? purchaseformcode { get; set; }
        public string note { get; set; }
        public string attributes { get; set; }
        public string datalog { get; set; }
        public string mmyy { get; set; }
        public string yyyy { get; set; }
        public int? siterf { get; set; }

    }
}
