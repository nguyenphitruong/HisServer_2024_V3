namespace Emr.Domain.Entities.Emr.Registers
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("emrregister")]
    public partial class emrregister
    {
        public int rowsid { get; set; }
        [Key]
        [StringLength(36)]
        public string managecode { get; set; }

        [StringLength(36)]
        public string indepartmentid { get; set; }
        [StringLength(5)]
        public string medexacode { get; set; }
        [StringLength(255)]
        public string medexaname { get; set; }

        [StringLength(8)]
        public string patcode { get; set; }

        public string doctorcode { get; set; }

        public DateTime registerdate { get; set; }
        [StringLength(5)]
        public string objectcode { get; set; }
        [StringLength(255)]
        public string objectname { get; set; }

        public string addressfull { get; set; }

        public int? phonenumber { get; set; }

        public int? done { get; set; }

        public bool? ispatientnew { get; set; }
        [StringLength(5)]
        public string paceregistercode { get; set; }
        [StringLength(5)]
        public string patienttype { get; set; }
        [StringLength(5)]
        public string placetransfercode { get; set; }
        [StringLength(5)]
        public string placeIntrocode { get; set; }

        [StringLength(50)]
        public string reson { get; set; }

        public int active { get; set; }

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
        public string mmyy { get; set; }

    }
}
