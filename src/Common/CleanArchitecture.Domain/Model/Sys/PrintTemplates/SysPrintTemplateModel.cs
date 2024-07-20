using Emr.Domain.Common;

namespace Emr.Domain.Model.Sys.PrintTemplates
{
    public class SysPrintTemplateModel : BaseModel
    {
        public int? id { get; set; } /*idline*/
        public string code { get; set; } /*Mã report*/
        public string descrip { get; set; } /*Mô tả*/
        public byte[] tempdata { get; set; } /*Nội dung file report*/
        public int? active { get; set; } /*Đang sử dụng*/

    }
}
