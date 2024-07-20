namespace Emr.Domain.Entities.Share.Patient
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("emrpatientsurvival")]
    public partial class emrpatientsurvival
    {
        [Key]
        public int rowsid { get; set; }

        [StringLength(50)]
        public string circuit { get; set; }

        [StringLength(50)]
        public string heat { get; set; }

        [StringLength(50)]
        public string pressure { get; set; }

        [StringLength(50)]
        public string breathing { get; set; }

        [StringLength(50)]
        public string height { get; set; }

        [StringLength(50)]
        public string weight { get; set; }

        [StringLength(8)]
        public string patcode { get; set; }

        [StringLength(25)]
        public string recordscode { get; set; }

        public int? type { get; set; }

        public int? active { get; set; }

        [StringLength(50)]
        public string ucr { get; set; }

        [StringLength(50)]
        public string uup { get; set; }

        public DateTime? timecr { get; set; }

        public DateTime? timeup { get; set; }

        [StringLength(50)]
        public string com { get; set; }

        [StringLength(50)]
        public string mac { get; set; }

        [StringLength(50)]
        public string ip { get; set; }

        public DateTime? mmyy { get; set; }
    }
}
