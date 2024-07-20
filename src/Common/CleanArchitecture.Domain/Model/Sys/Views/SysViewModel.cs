using System;

namespace Emr.Domain.Model.Sys.Views
{
    public class SysViewModel
    {
        public int siterf { get; set; } /*Mã đơn vị*/
        public Guid id { get; set; } /**/
        public string name { get; set; } /*tên view trong source*/
        public string title { get; set; } /*tiêu đề của view*/
        public string descr { get; set; } /**/
        public int active { get; set; } /*Đang sử dụng*/
        public string usercr { get; set; } /*User tạo*/
        public DateTime timecr { get; set; } /*Thời gian tạo*/
        public string userup { get; set; } /*User cập nhật*/
        public DateTime timeup { get; set; } /*Thời gian cập nhật*/
        public string computer { get; set; } /*Thông tin máy người dùng*/

    }
}
