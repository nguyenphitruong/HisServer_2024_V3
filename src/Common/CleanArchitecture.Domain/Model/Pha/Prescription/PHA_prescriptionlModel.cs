using Emr.Domain.Common;
using System;

namespace Emr.Domain.Model.Pha.Prescription
{
    public class PHA_prescriptionlModel : BaseModel
    {
        public string idline { get; set; }
        public string idh { get; set; }
        public string codeh { get; set; }
        public string storecode { get; set; }
        public string followid { get; set; }
        public string lotnumber { get; set; }
        public DateTime? expirydate { get; set; }
        public DateTime? ofmanudate { get; set; }
        public int? qtyreq { get; set; }
        public int? qtyapp { get; set; }
        public decimal? price { get; set; }
        public int? vatrate { get; set; }
        public decimal? vat { get; set; }
        public int? statuscode { get; set; }
        public bool? ishi { get; set; }
        public string biddinghidline { get; set; }
        public string biddinglidline { get; set; }
        public string note { get; set; }
        public string attributes { get; set; }
        public string datalog { get; set; }
        public string mmyy { get; set; }
        public string yyyy { get; set; }
        public int? siterf { get; set; }
        public int? active { get; set; }

    }
}
