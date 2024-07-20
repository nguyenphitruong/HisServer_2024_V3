namespace Emr.Domain.Model.Sys.Accounts
{
    public class InfoReturnAfterLoginModel
    {
        public int userId { get; set; } /*Id người dùng*/
        public string userCode { get; set; } /*Mã người dùng*/
        public string userName { get; set; }
        public string userFullname { get; set; } /*Họ tên người dùng*/
        public int userGenderID { get; set; } /*id gender, id giới tính, bảng catesharel, code: gender*/
        public int typeUserId { get; set; } /*id typeuser, id loại user, bảng catesharel, code: typeuser*/
        public string typeUserCode { get; set; }
        public int userMedexahId { get; set; } /*id chuyên khoa, nhân viên thuộc khoa phòng nào*/
        public string token { get; set; }
    }
}
