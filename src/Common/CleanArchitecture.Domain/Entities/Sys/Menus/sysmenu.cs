﻿namespace Emr.Domain.Entities.Sys.Menus
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("sysmenu")]
    public partial class sysmenu
    {
        public int id { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int siterf { get; set; }
        public int moduleid { get; set; }

        [Required]
        [StringLength(30)]
        public string code { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string descr { get; set; }

        [StringLength(255)]
        public string iconstring { get; set; }


        [Required]
        [StringLength(255)]
        public string appname { get; set; }

        [Required]
        public int orders { get; set; }

        [Required]
        public int active { get; set; }

        [StringLength(20)]
        public string usercr { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime timecr { get; set; }

        [StringLength(20)]
        public string userup { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime timeup { get; set; }

        [StringLength(255)]
        public string computer { get; set; }

        [StringLength(255)]
        public string nameview { get; set; }

    }
}
