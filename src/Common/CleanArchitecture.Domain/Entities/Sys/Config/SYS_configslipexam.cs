using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emr.Domain.Entities.Sys.Config
{
    [Table("SYS_configslipexam")]
    public class SYS_configslipexam
    {
        [Key]
        public string idline { get; set; }
      
        public string code { get; set; }
        public string name { get; set; }

        public string objcode1 { get; set; }
        public string objname1 { get; set; }
        public string objvalue1 { get; set; }
        public string objhiden1 { get; set; }
        
        public string objcode2 { get; set; }
        public string objname2 { get; set; }
        public string objvalue2 { get; set; }
        public string objhiden2 { get; set; }

        public string objcode3 { get; set; }
        public string objname3 { get; set; }
        public string objvalue3 { get; set; }
        public string objhiden3 { get; set; }

        public string objcode4 { get; set; }
        public string objname4 { get; set; }
        public string objvalue4 { get; set; }
        public string objhiden4 { get; set; }

        public string objcode5 { get; set; }
        public string objname5 { get; set; }
        public string objvalue5 { get; set; }
        public string objhiden5 { get; set; }

        public string objcode6 { get; set; }
        public string objname6 { get; set; }
        public string objvalue6 { get; set; }
        public string objhiden6 { get; set; }

        public string objcode7 { get; set; }
        public string objname7 { get; set; }
        public string objvalue7 { get; set; }
        public string objhiden7 { get; set; }

        public string objcode8 { get; set; }
        public string objname8 { get; set; }
        public string objvalue8 { get; set; }
        public string objhiden8 { get; set; }

        public int sort { get; set; }
        public int siterf { get; set; }
        public int active { get; set; }
    }
}
