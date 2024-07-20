namespace Emr.Domain.Entities.Share.Patient
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EMR_patienthi")]
    public partial class EMR_patienthi
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int rowsid { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string numbercode { get; set; }

        [Required]
        [StringLength(36)]
        public string managecode { get; set; }

        [Required]
        [StringLength(16)]
        public string patcode { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fromdate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? totate { get; set; }

        public int gland { get; set; }

        public bool? isYear { get; set; }

        [Column(TypeName = "image")]
        public byte[] img { get; set; }

        [StringLength(300)]
        public string filePath { get; set; }

        public int? active { get; set; }

        [StringLength(50)]
        public string ucr { get; set; }

        [StringLength(50)]
        public string uup { get; set; }

        public DateTime? timecr { get; set; }

        public DateTime? timeup { get; set; }

        [StringLength(50)]
        public string com { get; set; }

        [StringLength(25)]
        public string mac { get; set; }

        [StringLength(25)]
        public string ip { get; set; }

        public bool? isusing { get; set; }
    }
}
