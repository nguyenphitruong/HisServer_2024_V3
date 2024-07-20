namespace Emr.Domain.Entities.Share.Patient
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EMR_patient")]
    public partial class EMR_patient
    {
        //[Required]
        [StringLength(36)]
        public string patid { get; set; }

        [Key]
        [Required]
        [StringLength(8)]
        public string patcode { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string nameunsiger { get; set; }

        //[Column(TypeName = "date")]
        //public DateTime? birthday { get; set; }

        [StringLength(10)]
        public string birthday { get; set; }

        [StringLength(4)]
        public string birthyear { get; set; }

        public int? age { get; set; }

        public int? phonenumber { get; set; }

        public string email { get; set; }

        public int? agecode { get; set; }

        public int sexcode { get; set; }
        [StringLength(10)]
        public string sexname { get; set; }
        public int jobcode { get; set; }

        public int nationcode { get; set; }

        public int nationNatycode { get; set; }

        public int religioncode { get; set; }

        [StringLength(50)]
        public string village { get; set; }

        [Required]
        [StringLength(2)]
        public string citycode { get; set; }

        [Required]
        [StringLength(3)]
        public string districtcode { get; set; }

        [Required]
        [StringLength(5)]
        public string wardscode { get; set; }

        public string addresworkplace { get; set; }

        public string barcode { get; set; }

        public string relationcode { get; set; }

        public int? Ischildren { get; set; }

        public int? active { get; set; }

        [StringLength(50)]
        public string usercr { get; set; }

        [StringLength(50)]
        public string userup { get; set; }

        public DateTime? timecr { get; set; }

        public DateTime? timeup { get; set; }

        [StringLength(50)]
        public string computer { get; set; }

        [StringLength(50)]
        public string mac { get; set; }
        public string mmyys { get; set; }
        public string yyyy { get; set; }

        [StringLength(50)]
        public string findcontent { get; set; }
       

    }
}
