using System;

namespace Emr.Domain.ReadModel.Share
{
    public class EmrDrugsOrderReadModel
    {
        public string code { get; set; }
        public string admincode { get; set; }
        public string managecode { get; set; }
        public string depcode { get; set; }
        public string medexal { get; set; }
        public string medexalname { get; set; }
        public string objectcode { get; set; }
        public string objectname { get; set; }
        public string patcode { get; set; }
        public string doctorcode { get; set; }
        public string docrorname { get; set; }
        public string patienttype { get; set; }
        public string drugcode { get; set; }
        public string drugname { get; set; }
        public string drugtypecode { get; set; }
        public int? done { get; set; }
        public int? finish { get; set; }
        public string icd10code { get; set; }
        public string icd10name { get; set; }
        public int? idstore { get; set; }
        public string stractiveingre { get; set; }
        public bool? multiactiveingre { get; set; }
        public decimal? ofprice { get; set; }
        public decimal? serprice { get; set; }
        public decimal? hiprice { get; set; }
        public decimal? difprice { get; set; }
        public decimal? serpayrate { get; set; }
        public int? qtymor { get; set; }
        public int? qtydin { get; set; }
        public int? qtyaft { get; set; }
        public int? qtynig { get; set; }
        public int? qtyday { get; set; }
        public decimal? qty { get; set; }
        public decimal? total { get; set; }
        public string usage { get; set; }
        public string unitcode { get; set; }
        public string unitname { get; set; }
        public string routecode { get; set; }
        public string routename { get; set; }
        public string usecode { get; set; }
        public string usename { get; set; }
        public int? ishi { get; set; }
        public bool? removehi { get; set; }
        public int? sort { get; set; }
        public string biddinglidline { get; set; }
        public int? priceid { get; set; }
        public int? ratehi { get; set; }
        public int? ratepay { get; set; }
        public int? rateother { get; set; }
        public int? content { get; set; }
        public int? active { get; set; }
        public string ucr { get; set; }
        public string uup { get; set; }
        public DateTime? timecr { get; set; }
        public DateTime? timeup { get; set; }
        public string com { get; set; }

        public string mac { get; set; }

        public string ip { get; set; }

        public string mmyy { get; set; }

        public string year { get; set; }
    }
}
