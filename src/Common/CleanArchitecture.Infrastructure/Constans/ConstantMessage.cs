
namespace Emr.Infrastructure.Constans
{
  
    public static class ConstantMessage
    {
        public const string KhongDuocRongVuiLongKiemTraLai = "{0} không được rỗng. Vui lòng kiểm tra lại!";
        public const string VuiLongChon= "Vui lòng chọn {0}.";
        public const string KhongDuocNhieuHonKyTu= "{0} không được nhiều hơn {1} ký tự.";
        public const string LoiHeThong = "Lỗi hệ thống: ";
        public const string EmailValidator = "'{PropertyName}' không phải là địa chỉ email hợp lệ.";
        public const string GreaterThanOrEqualValidator = "'{PropertyName}' phải là lớn hơn hoặc bằng bằng '{ComparisonValue}'.";
        public const string GreaterThanValidator = "'{PropertyName}' phải lớn hơn '{ComparisonValue}'.";
        public const string LengthValidator = "'{PropertyName}' phải nằm giữa các ký tự {MinLength} và {MaxLength}. Bạn đã nhập {TotalLength} ký tự.";
        public const string MinimumLengthValidator = "Độ dài của '{PropertyName}' phải có ít nhất {MinLength} ký tự. Bạn đã nhập {TotalLength} ký tự.";
		public const string MaximumLengthValidator = "Độ dài của '{PropertyName}' phải là {MaxLength} ký tự trở xuống. Bạn đã nhập {TotalLength} ký tự.";
		public const string LessThanOrEqualValidator = "'{PropertyName}' phải nhỏ hơn hoặc bằng '{ComparValue}'.";
		public const string LessThanValidator = "'{PropertyName}' phải nhỏ hơn '{ComparValue}'.";
		public const string NotEmptyValidator = "'{PropertyName}' không được để trống.";
		public const string NotEqualValidator = "'{PropertyName}' không được bằng '{ComparValue}'.";
		public const string NotNullValidator = "'{PropertyName}' không được để trống.";
		public const string PredicateValidator = "Điều kiện đã chỉ định không được đáp ứng cho '{PropertyName}'.";
		public const string AsyncPredicateValidator = "Điều kiện đã chỉ định không được đáp ứng cho '{PropertyName}'.";
		public const string RegularExpressionValidator = "'{PropertyName}' không có định dạng đúng.";
		public const string EqualValidator = "'{PropertyName}' phải bằng '{ComparValue}'.";
		public const string ExactLengthValidator = "'{PropertyName}' phải dài {MaxLength} ký tự. Bạn đã nhập {TotalLength} ký tự.";
		public const string InclusiveBetweenValidator = "'{PropertyName}' phải nằm trong khoảng từ {From} đến {To}. Bạn đã nhập {Value}.";
		public const string ExclusiveBetweenValidator = "'{PropertyName}' phải nằm trong khoảng từ {From} đến {To} (độc quyền). Bạn đã nhập {Value}.";
		public const string CreditCardValidator = "'{PropertyName}' không phải là số thẻ tín dụng hợp lệ.";
		public const string ScalePrecisionValidator = "'{PropertyName}' không được nhiều hơn {expectedPrecision} chữ số, với phụ cấp cho số thập phân {expectedScale}. Đã tìm thấy {digit} chữ số và {actualScale} số thập phân.";
		public const string EmptyValidator = "'{PropertyName}' phải trống.";
		public const string NullValidator = "'{PropertyName}' phải trống.";
		public const string EnumValidator = "'{PropertyName}' có một loạt các giá trị không bao gồm '{PropertyValue}'.";
        public const string UserNameExists = "Username đã tồn tại.";
        public const string BenhNhanDaKham = "Bệnh nhân đã khám tại một phòng khám khác.";

        public const string KhoKhongDuTonDeXuat = "Kho không đủ tồn để xuất.";
        public const string KhoKhongDuTonDeDuyet = "Kho không đủ tồn để duyệt.";
        public const string SL = "SL:";
        public const string Ton = "Tồn:";
        public const string CacThuocKhongDuTon = "Các thuốc không đủ tồn: ";
        public const string VuiLongKiemTraLai = "Vui lòng kiểm tra lại.";
        public const string PhieuDaNhanThuocKhongThehuy = "Phiếu đã nhận thuốc. Không thể hủy!";
        public const string PhieuDaDuocDuyetKhongThehuy = "Phiếu đã được duyệt. Không thể hủy!";
        public const string PhieuDaDuocDuyetKhongTheSua = "Phiếu đã được duyệt. Không thể sửa!";
        public const string PhieuDaNhanThuocKhongThehuyDuyet = "Phiếu đã nhận thuốc. Không thể hủy duyệt!";
        public const string PhieuDaNhanThuocKhongTheSua = "Phiếu đã nhận thuốc. Không thể sửa!";
        public const string PhieuKhongTonTaiVuiLongKiemTraLai = "Phiếu không tồn tại. Vui lòng kiểm tra lại!";
        public const string KhongTheXacDinhQuiTrinhWorkFlowVuiLongKiemTraLai = "Không thể xác định qui trình WorkFlow. Vui lòng kiểm tra lại!";
        public const string KhongTheXacDinhTrangThaiHienTaiCuaWorkFlowVuiLongKiemTraLai = "Không thể xác định trạng thái hiện tại của WorkFlow. Vui lòng kiểm tra lại!";
        public const string ChuaHoanTat = "Chưa hoàn tất ca khám. Vui lòng kiểm tra lại!";

        public const string DangTrongKhoa = "Bệnh nhân đang trong khoa. Vui lòng kiểm tra lại!!!";
        public const string DangChuyenKhoa = "Bệnh nhân đang chuyển khoa. Vui lòng kiểm tra lại!!!";
        public const string DangChoNhanKhoa = "Bệnh nhân đang chờ nhận khoa. Vui lòng kiểm tra lại!!!";
        public const string SoLuongHoanTraKhongDuocLonHonThu = "Số lượng hoàn trả không được hơn số lượng thu. Vui lòng kiểm tra lại!!!";
        public const string SoLuongPhaiLonHon0 = "Số lượng phải lớn hơn 0";
        public const string HoSoDangKyDaKham = "Hồ sơ đăng ký đã khám.";
    }
}
