using System;

namespace Emr.Domain.Common
{
    public class BaseModel 
    {
    ////    public int? siterf { get; set; }//Mã đơn vị
    //    public int active { get; set; }//Sử dụng
    //    public int? ismodify { get; set; }//Cho phép sửa
    //    public string ucr { get; set; }//User tạo
    //    public string uup { get; set; }//User cật nhật
    //    public DateTime timecr { get; set; }// Thời gian tạo
    //    public DateTime timeup { get; set; }// Thời gian cật nhật
    //    public string com { get; set; }//Máy tính
    //    public string mac { get; set; }//Địa chỉ Mac
    //    public string ip { get; set; }//Địa chỉ IP


        public int siterf { get; set; }
        public int active { get; set; }
        public string usercr { get; set; }
        public DateTime timecr { get; set; }
        public string userup { get; set; }
        public DateTime timeup { get; set; }
        public string computer { get; set; }
        public string mac { get; set; }

    }
}
