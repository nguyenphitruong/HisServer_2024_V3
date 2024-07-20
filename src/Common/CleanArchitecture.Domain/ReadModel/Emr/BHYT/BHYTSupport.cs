using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PT.DomainLayer.ReadModel._01.Medical.BHYT
{
    public class BHYTSupport
    {
        public class ApiToken
        {
            [DataMember]
            public string username { get; set; }
            [DataMember]
            public string password { get; set; }
        }
        public class KQPhienLamViec
        {
            public string maKetQua { get; set; }
            public ApiKey APIKey { get; set; }
        }
        public class ApiKey
        {
            [DataMember]
            public string access_token { get; set; }
            [DataMember]
            public string id_token { get; set; }
            [DataMember]
            public string token_type { get; set; }
            [DataMember]
            public string username { get; set; }
            [DataMember]
            public DateTime expires_in { get; set; }
        }
        public class ApiTheBHYT2018
        {
            [DataMember]
            public string maThe { get; set; }
            [DataMember]
            public string hoTen { get; set; }
            [DataMember]
            public string ngaySinh { get; set; }
        }
        public class KQNhanLichSuKCBBS
        {
            public string maKetQua { get; set; }
            public string ghiChu { get; set; }
            public string maThe { get; set; }
            public string hoTen { get; set; }
            public string ngaySinh { get; set; }
            public string gioiTinh { get; set; }
            public string diaChi { get; set; }
            public string maDKBD { get; set; }
            public string cqBHXH { get; set; }
            public string gtTheTu { get; set; }
            public string gtTheDen { get; set; }
            public string maKV { get; set; }
            public string ngayDuSNam { get; set; }
            public string maSOBHXH { get; set; }
            public string maTheCu { get; set; }
            public string maTheMoi { get; set; }
            public string gtTheTuMoi { get; set; }
            public string gtTheDenMoi { get; set; }
            public List<LichSuKCB2018> dSLichSuKCB2018 { get; set; }
            public List<LichSuKT2018> dSLichSuKT2018 { get; set; }

            public class LichSuKCB2018
            {
                public string maHoSo { get; set; }
                public string maCSKCB { get; set; }
                public string ngayVao { get; set; }
                public string ngayRa { get; set; }
                public string tenBenh { get; set; }
                public string tinhTrang { get; set; }
                public string kqDieuTri { get; set; }
            }
            public class LichSuKT2018
            {
                public string userKT { get; set; }
                public string thoiGianKT { get; set; }
                public string thongBao { get; set; }
                public string maLoi { get; set; }
            }
        }
    }
}
