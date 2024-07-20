using Emr.Domain.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Emr.Domain.Model.Share
{
    public class EmrServicesOrderModel : BaseModel
    {
        public string idline { get; set; }
        public string idlink { get; set; }
        public string patid { get; set; }
        public string patcode { get; set; }
        public string mediid { get; set; }
        public string departid { get; set; }
        public string happeid { get; set; }
        public int? typepatcode { get; set; }
        public int? placordercode { get; set; }
        public int? medexahcode { get; set; }
        public int? medexalcode { get; set; }
        public string docordercode { get; set; }
        public DateTime? dateorder { get; set; }
        public string icdorder { get; set; }
        public string groupcode { get; set; }
        public string typecode { get; set; }
        public string groupprintcode { get; set; }
        public int? pricelistcode { get; set; }
        public string servicecode { get; set; }
        public string servicename { get; set; }
        public string servicenameeng { get; set; }
        public string servicenamehi { get; set; }
        public string unitcode { get; set; }
        public decimal? qty { get; set; }
        public decimal? price { get; set; }
        public decimal? priceovertime { get; set; }
        public decimal? priceforeign { get; set; }
        public decimal? pricehi { get; set; }
        public decimal? difference { get; set; }
        public decimal? total { get; set; }
        public string reghiid { get; set; }
        public int? ratehi { get; set; }
        public int? serpayrate { get; set; }
        public int? ratepay { get; set; }
        public int? rateother { get; set; }
        public int? ishi { get; set; }
        public bool? removehi { get; set; }
        public bool? isnoresult { get; set; }
        public bool? ispackage { get; set; }
        public bool? isfree { get; set; }
        public int? times { get; set; }
        public bool? sameteam { get; set; }
        public int? sort { get; set; }
        public int? paid { get; set; }
        public int? done { get; set; }
        public string note { get; set; }
        public string attributes { get; set; }
        public string datalog { get; set; }
        public string mmyy { get; set; }
        public string yyyy { get; set; }
    }
}
