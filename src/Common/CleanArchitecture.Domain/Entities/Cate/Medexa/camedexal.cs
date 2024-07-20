namespace Emr.Domain.Entities.Cate.Medexa
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("camedexal")]
    public partial class camedexal
    {
        public int siterf { get; set; }

  
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int rowsid { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string code { get; set; }

        [StringLength(10)]
        public string codeh { get; set; }

        [StringLength(200)]
        public string name { get; set; }

        [Column(TypeName = "text")]
        public string servicevalues { get; set; }

        public int? active { get; set; }

        [StringLength(20)]
        public string usercr { get; set; }

        [Column(TypeName = "date")]
        public DateTime? timecr { get; set; }

        [StringLength(20)]
        public string userup { get; set; }

        [Column(TypeName = "date")]
        public DateTime? timeup { get; set; }

        [StringLength(255)]
        public string computer { get; set; }

        public bool? ismedexa { get; set; }
    }
}
