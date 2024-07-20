using Emr.Domain.Common;
using System;
using System.Collections.Generic;

namespace Emr.Domain.Model.Pha.Prescription
{
    public class PHA_prescriptionhModel : BaseModel
    {
        public string idline { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public int? pattype { get; set; }
        public int? typecode { get; set; }
        public int? statuscode { get; set; }
        public string patid { get; set; }
        public string patcode { get; set; }
        public string idlink { get; set; }
        public string mediid { get; set; }
        public DateTime? datecreate { get; set; }
        public string usercreate { get; set; }
        public DateTime? dateapprove { get; set; }
        public string userapprove { get; set; }
        public DateTime? datepass { get; set; }
        public string userpass { get; set; }
        public bool? isfinish { get; set; }
        public DateTime? dateout { get; set; }
        public string icdcode { get; set; }
        public string icdname { get; set; }
        public string nohi { get; set; }
        public string medexacode { get; set; }
        public string medexaname { get; set; }
        public string doccode { get; set; }
        public string docname { get; set; }
        public decimal? total { get; set; }
        public decimal? patpay { get; set; }
        public decimal? payhi { get; set; }
        public string reason { get; set; }
        public int? objectcode { get; set; }
        public int? pricelistcode { get; set; }
        public int? ratepay { get; set; }
        public int? rateother { get; set; }
        public string idlinehi { get; set; }
        public string votes { get; set; }
        public string note { get; set; }
        public string attributes { get; set; }
        public string datalog { get; set; }
        public string mmyy { get; set; }
        public string yyyy { get; set; }
        public int? siterf { get; set; }
        public int? active { get; set; }
        public List<PHA_prescriptionlModel> lstPrescriptionl { get; set; }

    }
}
