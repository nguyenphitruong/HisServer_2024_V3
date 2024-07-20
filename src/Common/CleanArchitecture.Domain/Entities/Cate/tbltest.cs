using System;
using System.Collections.Generic;
using System.Text;

namespace Emr.Domain.Entities.Cate
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("tbltest")]
    public partial class tbltest
    {
        [Key]
        public string code { get; set; }

        [StringLength(255)]
        public string name { get; set; }
    }
}
