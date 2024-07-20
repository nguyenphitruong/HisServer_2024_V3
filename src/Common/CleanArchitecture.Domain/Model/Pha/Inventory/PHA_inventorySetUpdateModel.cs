using Emr.Domain.Common;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Emr.Domain.Model.Pha.Inventory
{
    public class PHA_inventorySetUpdateModel : BaseModel
    {
        public DateTime dateinput { get; set; }
        public int storecode { get; set; }
        public string typecode { get; set; }
        public int? typestatuscode { get; set; }

        public string drugcode { get; set; }

        [DefaultValue(0)]
        public decimal qtyT { get; set; } //quantity export, nếu không cập nhật số lượng tồn đầu có thì phải gán = 0

        [DefaultValue(0)]
        public int actionT { get; set; } //1: tăng số lượng tồn đầu, -1: giảm số lượng tồn đầu. Nếu không cập nhật số lượng tồn đầu có thì phải gán = 0

        [DefaultValue(0)]
        public decimal qtyImp { get; set; } //quantity export, nếu không cập nhật số lượng nhập có thì phải gán = 0

        [DefaultValue(0)]
        public int actionImp { get; set; } //1: tăng số lượng nhập, -1: giảm số lượng nhập. Nếu không cập nhật số lượng nhập có thì phải gán = 0

        [DefaultValue(0)]
        public decimal qtyExp { get; set; } //quantity export, nếu không cập nhật số lượng exp có thì phải gán = 0

        [DefaultValue(0)]
        public int actionExp { get; set; } //1: tăng số lượng exp, -1: giảm số lượng exp. Nếu không cập nhật số lượng exp có thì phải gán = 0

        [DefaultValue(0)]
        public decimal qtyReq { get; set; } //quantity request, nếu không cập nhật số lượng req có thì phải gán = 0

        [DefaultValue(0)]
        public int actionReq { get; set; } //1: tăng số lượng req, -1: giảm số lượng req. Nếu không cập nhật số lượng req có thì phải gán = 0
        
        public string followid { get; set; }
        public string lotnumber { get; set; }
        public DateTime? expirydate { get; set; }
        public DateTime? ofmanudate { get; set; }
        public decimal? price { get; set; }
        public decimal? amount { get; set; }
        public string note { get; set; }
        public string attributes { get; set; }
        public string datalog { get; set; }
        public string mmyy { get; set; }
        public string yyyy { get; set; }
        public int? siterf { get; set; }
        public int? active { get; set; }

    }
}
