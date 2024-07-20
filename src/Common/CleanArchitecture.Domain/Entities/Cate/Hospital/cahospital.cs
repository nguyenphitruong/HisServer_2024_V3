namespace Emr.Domain.Entities.Cate.Hospital
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CATE_hospital")]
    public partial class CATE_hospital
    {
        public int id { get; set; }

        [Required]
        [StringLength(10)]
        public string code { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        public string decrp { get; set; }
    }
}
