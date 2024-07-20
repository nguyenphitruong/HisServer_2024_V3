namespace Emr.Domain.Entities.Pha
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PHA_pricedrugbidl")]
    public partial class PHA_pricedrugbidl
    {

        [Key]
        [StringLength(36)]
        public string idline { get; set; }

        [StringLength(36)]
        public string idh { get; set; }

        public int? stt { get; set; }

        [StringLength(50)]
        public string active_code { get; set; }

        [StringLength(255)]
        public string active_code_map { get; set; }

        [StringLength(255)]
        public string active_string { get; set; }

        [StringLength(255)]
        public string active_string_map { get; set; }

        [StringLength(255)]
        public string drug_route_code { get; set; }

        [StringLength(255)]
        public string drug_route_code_map { get; set; }

        [StringLength(255)]
        public string drug_route_name { get; set; }

        [StringLength(255)]
        public string drug_route_name_map { get; set; }

        [StringLength(255)]
        public string drug_content { get; set; }

        [StringLength(255)]
        public string drug_content_map { get; set; }

        [StringLength(255)]
        public string item_name { get; set; }

        [StringLength(255)]
        public string item_name_map { get; set; }

        [StringLength(255)]
        public string registration_number { get; set; }

        [StringLength(255)]
        public string registration_number_map { get; set; }

        [StringLength(255)]
        public string specifications { get; set; }

        [StringLength(10)]
        public string unit { get; set; }

        public decimal? unitprice { get; set; }

        public decimal? payment_unit_price { get; set; }

        public int? quantity { get; set; }

        [StringLength(20)]
        public string hospcode { get; set; }

        [StringLength(255)]
        public string manufacturer { get; set; }

        [StringLength(255)]
        public string country_of_manufacture { get; set; }

        [StringLength(255)]
        public string contractors { get; set; }

        [StringLength(255)]
        public string decision { get; set; }

        [StringLength(255)]
        public string date_of_publication { get; set; }

        [StringLength(20)]
        public string hosp_item_code { get; set; }

        [StringLength(255)]
        public string hosp_item_name { get; set; }

        public int? item_type { get; set; }

        public int? bid_package { get; set; }

        public int? bid_type { get; set; }

        public int? bid_group { get; set; }

        public int? group_code { get; set; }

        public int? group_decision { get; set; }

        [StringLength(500)]
        public string note { get; set; }

        [Column(TypeName = "text")]
        public string attributes { get; set; }

        [Column(TypeName = "text")]
        public string datalog { get; set; }

        [Required]
        [StringLength(4)]
        public string mmyy { get; set; }

        [Required]
        [StringLength(4)]
        public string yyyy { get; set; }

        public int? siterf { get; set; }

        public int? active { get; set; }

        [StringLength(150)]
        public string usercr { get; set; }

        public DateTime? timecr { get; set; }

        [StringLength(150)]
        public string userup { get; set; }

        public DateTime? timeup { get; set; }

        [StringLength(150)]
        public string computer { get; set; }

        [StringLength(150)]
        public string mac { get; set; }
    }
}
