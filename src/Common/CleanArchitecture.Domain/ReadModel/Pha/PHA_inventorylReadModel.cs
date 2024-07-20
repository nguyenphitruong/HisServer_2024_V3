using System;

namespace Emr.Domain.ReadModel.Pha
{
    public class PHA_inventorylReadModel
    {
        public string idline { get; set; }
        public int storecode { get; set; }
        public string drugcode { get; set; }
        public decimal? qtyt { get; set; }
        public decimal? qtyimp { get; set; }
        public decimal? qtyexp { get; set; }
        public decimal? qtyrep { get; set; }
        public decimal? qtymi { get; set; }
        public string followid { get; set; }
        public string lotnumber { get; set; }
        public DateTime? expirydate { get; set; }
        public DateTime? ofmanudate { get; set; }
        public decimal? price { get; set; }
        public decimal? amount { get; set; }
        public string note { get; set; }
        public string attributes { get; set; }
        public string datalog { get; set; }
        public string mmyy { get; set; }
        public string yyyy { get; set; }
        public int? siterf { get; set; }
        public int? active { get; set; }
        public string usercr { get; set; }
        public DateTime? timecr { get; set; }
        public string userup { get; set; }
        public DateTime? timeup { get; set; }
        public string computer { get; set; }
        public string mac { get; set; }

    }
}
