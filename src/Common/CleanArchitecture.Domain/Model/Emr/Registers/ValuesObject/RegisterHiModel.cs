using System;

namespace Emr.Domain.Model.Emr.Registers.ValuesObject
{
    public class RegisterHiModel
    {
        public int siterf { get; set; }
        public int rowsid { get; set; }
        public string linkid { get; set; }
        public string exemptions { get; set; }
        public int ratehi { get; set; }
        public int ratepay { get; set; }
        public int rateother { get; set; }
        public int level { get; set; }
        public int reason { get; set; }
        public decimal minpay { get; set; }
        public decimal maxpay { get; set; }
        public decimal salary { get; set; }
        public bool isusing { get; set; }
        public string files { get; set; }
        public string filename { get; set; }
        public bool approved { get; set; }
        public int active { get; set; }
        public string ucr { get; set; }
        public DateTime timecr { get; set; }
        public string uup { get; set; }
        public DateTime timeup { get; set; }
        public string computer { get; set; }
        public int typerouteexamid { get; set; }
        public bool avepapertransfer { get; set; }
    }
}
