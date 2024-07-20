namespace Emr.Domain.Entities.Pha
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PHA_storeimporth")]
    public partial class PHA_storeimporth
    {
        [Key]
        [StringLength(36)]
        public string idline { get; set; }

        [StringLength(30)]
        public string code { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        public int? sliptypecode { get; set; }

        public int? actioncode { get; set; }

        public int? statuscode { get; set; }

        public int? storecode { get; set; }


        public DateTime? datecreate { get; set; }

        [StringLength(20)]
        public string usercreate { get; set; }

        public DateTime? dateapprove { get; set; }

        [StringLength(20)]
        public string userapprove { get; set; }

        [StringLength(36)]
        public string invoiceid { get; set; }

        [StringLength(36)]
        public string invoicetempid { get; set; }

        public DateTime? invoicedate { get; set; }

        [StringLength(30)]
        public string numdeliverycode { get; set; }

        [StringLength(500)]
        public string note { get; set; }

        [Column(TypeName = "text")]
        public string attributes { get; set; }

        [Column(TypeName = "text")]
        public string datalog { get; set; }

        [Required]
        [StringLength(4)]
        public string mmyy { get; set; }

        [Required]
        [StringLength(4)]
        public string yyyy { get; set; }

        public int? siterf { get; set; }

        public int? active { get; set; }

        [StringLength(150)]
        public string usercr { get; set; }

        public DateTime? timecr { get; set; }

        [StringLength(150)]
        public string userup { get; set; }

        public DateTime? timeup { get; set; }

        [StringLength(150)]
        public string computer { get; set; }

        [StringLength(150)]
        public string mac { get; set; }
    }
}
