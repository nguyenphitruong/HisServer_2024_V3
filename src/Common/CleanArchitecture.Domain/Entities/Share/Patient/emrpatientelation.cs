namespace Emr.Domain.Entities.Share.Patient
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("emrpatientelation")]
    public partial class emrpatientelation
    {
        [Key]
        public int rowsid { get; set; }

        [Required]
        [StringLength(8)]
        public string patcode { get; set; }

        [StringLength(50)]
        public string relationcode { get; set; }

        [StringLength(50)]
        public string relationname { get; set; }

        [StringLength(50)]
        public string relationcultural { get; set; }
    }
}
