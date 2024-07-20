namespace Emr.Domain.Entities.Pha
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PHA_storeexporth")]
    public partial class PHA_storeexporth
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHA_storeexporth()
        {
            PHA_storeexportl = new HashSet<PHA_storeexportl>();
        }

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

        public DateTime? datecreate { get; set; }

        [StringLength(10)]
        public string usercreate { get; set; }

        public DateTime? dateapprove { get; set; }

        [StringLength(10)]
        public string userapprove { get; set; }

        public int? storeexpcode { get; set; }

        public int? storeimpcode { get; set; }

        public int? status { get; set; }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHA_storeexportl> PHA_storeexportl { get; set; }
    }
}
