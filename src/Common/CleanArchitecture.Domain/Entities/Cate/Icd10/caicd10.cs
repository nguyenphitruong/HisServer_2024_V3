namespace Emr.Domain.Entities.Cate.Icd10
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CATE_icd10")]
    public partial class CATE_icd10
    {
        public int id { get; set; }

        [Required]
        //[StringLength(5)]
        public string code { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string nameen { get; set; }
    }
}
