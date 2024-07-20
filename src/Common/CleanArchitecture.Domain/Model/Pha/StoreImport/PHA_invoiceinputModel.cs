using Emr.Domain.Common;
using System;

namespace Emr.Domain.Model.Pha.StoreImport
{
    public class PHA_invoiceinputModel : BaseModel
    {
        public string idline { get; set; }
        public string form { get; set; }
        public string serial { get; set; }
        public string no { get; set; }
        public DateTime? date { get; set; }
        public string voucher { get; set; }
        public DateTime? voucherdate { get; set; }
        public string suppliercode { get; set; }
        public bool? isinvoice { get; set; }
        public int? vat { get; set; }
        public decimal? vatamount { get; set; }
        public decimal? discountamount { get; set; }
        public int? discountrate { get; set; }
        public decimal? totalamount { get; set; }
        public decimal? reallyamount { get; set; }
        public string note { get; set; }
        public string attributes { get; set; }
        public string datalog { get; set; }
        public string mmyy { get; set; }
        public string yyyy { get; set; }
        public int? siterf { get; set; }
    }
}
