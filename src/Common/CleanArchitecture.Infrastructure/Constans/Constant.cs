
namespace Emr.Infrastructure.Constans
{
    public static class Constant
    {
        //WFL
        public const string ConfigTagName_SysApiConfigUrl = "ConfigTagName_SysApiConfigUrl";
        public const string ConfigTagName_TimeOutCallICareApi = "ConfigTagName_TimeOutCallICareApi";
        
        public const string HospCode = "HospCode";
        public const string prefixPara = "@";
        public const string typeslip = "typeslip";
        public const string action = "action";
        //
        public const string Sites = "Sites";
        public const string Siterf = "Siterf";
        public const string Content = "Content";
        public const string Token = "Token";
        public const string Computer = "Computer";
        public const string ComputerIP = "ComputerIP";
        public const string UserName = "UserName";
        public const string UserID = "UserID";
        public const string TimesTamp = "TimesTamp";
        public const string ServiceProvider = "ServiceProvider";
        public const string ServiceName = "ServiceName";
        public const string ComServices = "ComServices";
        public const string BuildNo = "BuildNo";
        public const string upload = "upload";
        public const string ResourceFolder = "ResourceFolder";
        public const string jpg = ".jpg";
        public const string guiddefault = "00000000-0000-0000-0000-000000000000";
        public const string Data = "Data";
        public const string EMR = "EMR";
        public const string PAY = "PAY";
        public const string PHA = "PHA";
        public const string hospital = "hospital";
        public const string reason = "reason";
        public const string CreateNew = "CreateNew";
        public const string Paid = "Paid";
        public const string Approve = "Approve";
        public const string Done = "Done";
        public const string unit = "unit";
        public const string doctorexa = "doctorexa";
        public const string unitdrug = "unitdrug";
        public const string regobject = "regobject";
        public const string serdug = "serdug";
        public const string salary = "salary";
        public const string ratemin = "ratemin";
        public const string Exam = "Exam";
        public const string getimagehi = "getimagehi";

        public const string Authorization = "Authorization";
        public const string Basic = "Basic";
        public const string aut = "aut";
        public const int IdMedexaLIS = 13;
        public const string ALL = "Tất cả";

        public const string UpdateStatus = "Update Status";
        public const string RecordStatus = "Record Status";
        public const string AutoCloneForNextStatus = "Auto Clone For Next Status";
        public const string UpdateStatusActiveDeletePaid = "Update Status, Active Because Delete Paid";
        public const string UpdateStatusActiveReturnPaid = "Update Status, Active Because Return Paid";
        public const string UpdateStatusActiveDeleteOutServiceOrder = "Update Status, Active Because Delete OutServiceOrder";

        public const int ActiveStatusRecordNew = 3;
    }

    public class ContCache
    {
        public const string listAllPriceList = "listAllPriceList";
        public const string listAllMapPriceOfAllPackageDetails = "listAllMapPriceOfAllPackageDetails";
        public const string listAllCateShare = "listAllCateShare";
        public const string listAllClientSetting = "listAllClientSetting";
        public const string listAllClient = "listAllClient";
        public const string listAllHospital = "listAllHospital";
        public const string listCodeCheck = "listCodeCheck";
    }

    public class code
    {
        public const string patcode = "patcode";
        public const string codeAdmission = "codeAdmission";
        public const string codeManager = "codeManager";
        public const string codeIndepartment = "codeIndepartment";
    }

    public enum IdGroupTreeEnum
    {
        DV_KHAM = 250,
        DV_ThucHienTruoc = 260,
        NhomThuyTinhThe = 119,
        LaGoiKham = 262
    }

    public enum IdGroupEnum
    {
        ServiceLIS = 249
    }

    public enum CodeCategoryShareHeaderEnum
    {
        unit = 21,
        typeuser = 79,
        caterefractor = 84,
        regobject = 14,
        nation = 11, //quoc tich
        job = 8,
        ethnic = 4, //dan toc
    }

    public enum CodeCategoryShareLineEnum
    {
        BacSi = 26092
    }

    public enum ICareAction
    {
        Get = 0,
        GetFilter = 1,
        Save = 2,
        Delete = 3,
        PostFilter = 4,
        PutData = 5
    }
    public enum SqlErrorCode : int
    {
        SqlNoError = 0,
        SqlDuplicateIndex = 1,
        SqlZeroDevide = 2,
        SqlInvalidNumber = 3,
        SqlTimeout = 4,
        SqlLoginDenied = 5,
        SqlUnknownError = 999,
    }
    public enum Status
    {
        Waitting = 0,
        Examination = 1,
        Completed = 2,
    }
    public enum Specialist
    {
        Exainternal = 0, // Chuyên khoa nội
        Exaobstetric = 1 // Chuyên khoa sản
    }
    public enum StatusStore
    {//Phiếu nhập kho
        StoreInput = 0,
        Approve = 1,
        Inventory = 2,
        Refuse = 3,//Từ chối
    }
    public enum TypeSlip
    {//Loại phiếu
        StoreInputNew = 0,
        ExportMoveStore = 1,
        //TriLV phân biệt loại phiếu trong duyệt kê đơn BHYT hoặc ThuPhi
        Insurance = 2,
        Pay = 3,
        ReturnDrugPos = 4,
    }
    public enum TypeDrug
    {
        Drug = 0,
        Supplies = 1//Vật tư
    }
    public enum StatusApproveDrug
    {//Xuất thuốc
        CreateSlip = 0,//Tạo phiếu
        Approve = 1,//Duyệt
        Paid = 2,//Phát thuốc
        MedicalChart = 3, //TH y lệnh
        Cancel = 6,
    }
    /// <summary>
    /// Đối tượng
    /// </summary>
    public enum Object
    {
        idobjectdv = 25401,//DV
        idobjectbhyt = 25402,//BHYT
        idobjectbhtn = 25403//BHTN

    }
    public enum ManagStatus
    {
        NhapVien = 25419,
        ChuyenVien = 25418,
        RaVien = 25417,
        Servicepayment = 25500,
        Advancepayment = 25501,
        Return = 25502,

    }
    public enum Selection
    {
        Yes = 1,
        No = 0,
        MovedRoom = 2, // Chuyển phòng
        Finish = 3,
    }
    public enum HospitalizationType
    {
        NgoaiTru = 1,
        CapCuu = 2,
        NoiTru = 3,
    }

    public enum StatusPayment
    {
        Paid = 25503,
        Return = 25504,
        Cancel = 25505
    }

    public enum DianoseType
    {
        NgoaiTru = 1,
        CapCuu = 2,
        NoiTru = 3,
        DangKy = 4,
        YLenh = 5,
    }

    public enum InpatientStatus
    {
        ChoNhan = 0,
        DaNhan = 1,
        HuyChuyen = 2,
    }

    public enum InpatientAction
    {
        NhanKhoa = 0,
        DieuTri = 1,
        ChuyenKhoa = 2,
        HoSo = 3,
        HuyChuyen = 4,
        HuyNhan = 5,
        TrongKhoa = 6,
        DaChuyen = 7,
        ChoNhan = 8,
    }

    public enum LineSource
    {
        CapCuu = 1,
        NoiTru = 2,
    }

    public enum StatusProfile
    {
        DangNamVien = 1,
        DangXuatVien = 2,
        DaKhoaHoSo = 3,
        DaThanhToan = 4,
    }

    public enum ServiceGroup1
    {
        KB
    }
    public enum NoseriCodeType
    {
        SOVAOVIEN = 0, // Số vào viện
        PTHUTIENKCB = 1, //Số phiếu thu tiền KCB
        PHOANTIENKCB = 2, //Phiếu hoàn KCB
        PTHUTHUOC = 3, //Phiếu thu tiền thuốc
        PHOANTHUOC = 4, //Phiếu hoàn thuốc
        PTHANHTOANOP = 5, //Thanh toán BHYT ngoại trú
        PTHANHTOANIP = 6, //Thanh toán BHYT nội trú
        MABENHANOP = 7, //Bệnh án ngoại trú
        MABENHANIP = 8, //Bệnh án nội trú
        HOSPCODE = 9, //Mã bệnh nhân do BV tạo
        PTAMUNG = 10, //Phiếu tạm ứng
        NHAPDIEUCHINH = 11, //Nhập điều chỉnh
        XUATDIEUCHINH = 12, //Xuất điều chỉnh
        PHOANUNG = 13, //Phiếu hoàn trả tạm ứng
        SOPHIEUCD = 14, //Số phiếu chỉ định
        SPDUTRUMUAHANG = 15, //Số phiếu dự trù mua hàng
    }
    //Loai phieu Nhap - xuat dieu chinh
    public enum Adjustedsliph
    {
        AdjustedsliphExport = 25515, //Xuất điều chỉnh
        AdjustedsliphImport = 25516, //Nhập điều chỉnh
        ExportReturnSupplier = 25517, //xuất hoàn trả nhà cung cấp
    }

    public enum patientdeposit
    {
        NgoaiTru = 25547,
        CapCuu = 25548,
        Noitru = 25549,
        BHTN = 25550
    }

    public enum typemedicalchart
    {
        YLenhLinhDieuTri = 25468,
        YLenhToaRV = 25469,
        YLenhToaMuaNgoai = 25470,
        YLenhCanLamSang = 25553,
        YLenhHoanTra = 25554,
        YLenhHaoPhi = 25555,
        YLenhDuTruTTT = 26134
    }

    public enum statusslip // trạng thái phiếu
    {
        done = 1, // đã thực hiện
        canceled = 2 // đã hủy
    }
    public enum enumarea // trạng thái của đơn thuốc Pos
    {
        Pos = 1, // Bán Pos
        Register = 2, // Khu đăng ký
        Emergency = 3, // Khu cấp cứu
        Outclinic = 4, // Khu phòng khám
        Inpatient = 5, // Khu nội trú
        Refractometer = 6, // Phòng đo khúc xạ
        Laboratory = 7, //phòng xét nghiệm
        Cashier = 8 // Thu ngân
    }

    public enum enumtypeslip
    {
        Paid,
        Return,
        CreateNew,
        Cancel,
        CreateSlip,
    }

    //<<<<<<< HEAD
    public enum DocumentType // trạng thái của đơn thuốc Pos
    {
        KCB = 1, // tien KCB
        THUOC = 2
    }
    //=========
    public enum typesliprequire // id typesliprequire, bảng catesharel, code: typesliprequire
    {
        LinhChoBenhNhan = 25966,
        HoanTraChoBenhNhan = 25967,
        LoaiPDuTru = 26046,
        LoaiPDuTruTT = 26135
    }



    //Enum HDDT Create 30/07/2019
    public enum BuyerIDType
    {
        CMND = 1,//Số CMND
        GPKD = 2,//Giấy phép kinh doanh
        HC = 3, // Hộ chiếu
    }
    public enum AdjustmentType
    {
        HDGoc = 1,
        HDThayThe = 3,
        HDDieuChinh = 5,
    }

    public enum AdjustmentInvoiceType
    {
        DCTien = 1,
        DCThongTin = 2,
    }

    public enum InvoiceStatus
    {
        HoaDonMoi = 1,
        HoaDonDieuChinhThongTin = 2,
        HoaDonDieuChinhTien = 3,
        HoaDonBiHuy = 4,
    }

    public enum sellerInfo
    {
        NameHops = 15,
        AddHops = 16,
        PhoneHops = 17,
        LegalNameHops = 18,
        TaxCodeHops = 19,
        AddressLine = 20,
        FaxHops = 21,
        EmailHops = 22,
        BankNameHops = 23,
        BankAccountHops = 24,
    }


    public enum typegroup //
    {
        NhomBHYT = 25891,
        NhomDuocLy = 25892,
        NhomInKeDon = 25963,
        NhomInPhieuChiDinh = 25964,
        NhomDichVu = 26130

    }

    public enum idtypereceipt//định nghĩa hoàn trả Pos
    {
        ReturnDrugPos = 25556,
    }

    public enum typecard // danh mục loại thẻ
    {
        BHYT = 25968,
        BHTN = 25969
    }

    public enum enumstate // danh mục trạng thái trên recordstateitem
    {
        Registed = 1, // đã đăng ký
        Specified = 2, // đã chỉ định
        WaitDoing = 3, // chờ thực hiện        
        Paid = 4, // đã thanh toán
        WaitExam = 5, //chờ khám
        Finish = 6, // đã hoàn thành
        WaitApprove = 7, // Chờ duyệt phiếu (với thuốc, vật tư)
        //ReturnPaid = 8, // Hoàn trả thanh toán
        ReturnDrugPos = 9, // Hoàn trả tại POS
        WaitPay = 10, // chờ thanh toán
        Intended = 11, // Đã dự trù (với thuốc, vật tư)
        Done = 12, //Đã thực hiện
        //DeletePaid = 13, // xóa phiếu thu tiền
        WaitPayHI = 14, //chờ thanh toán BHYT
        WaitPayPHI = 15, // chờ bảo lãnh bảo hiểm tư nhân, Private health insurance 
        PaidHI = 16 // đã thanh toán BHYT

    }
    public enum methodName
    {
        GetlstGlassType = 1,
    }

    public enum typediainpat /*inpatdiagnoseinto.type; 0: chẩn đoán của nhập viện, 1: chẩn đoán khi nhập khoa, 2: chẩn đoán của diễn biến, 3: chẩn đoán trước phẫu thuật, 4: chẩn đoán sau phẫu thuật*/
    {
        NhapVien = 0,
        NhapKhoa = 1,
        DienBien = 2,
        ChanDoanTruocPhauThuat = 3,
        ChanDoanSauPhauThuat = 4,
    }

   
}
