using Emr.Infrastructure.Persistence;
using Emr.Infrastructure.RepoMapper.Result;
using PT.DomainLayer.AggregatesModel.Result;

namespace Emr.Infrastructure.Repositories.Result
{
    /// <summary>
    /// Creator Nguyễn Phi Trường
    /// Date 30/09/2109
    /// </summary>
    public class ResultRepository : IResultRepository
    {
        private MydbContext dbContext;
        private ResultEntityMapper _mapper;

        public ResultRepository(MydbContext i_Context)
        {
            dbContext = i_Context;
        }
        //public List<ResultReadModel> GetAll() 
        //{
        //    var _ResultReadModel = new List<ResultReadModel>();
        //    try
        //    {
        //        _ResultReadModel = PTEntity.cdha_ketqua
        //            .Select(rs => new ResultReadModel
        //            { 
        //                id_cdha = rs.id_cdha,
        //                maql = rs.maql,
        //                mavv = rs.mavv,
        //                mavk = rs.mavk,
        //                mapk = rs.mapk,
        //                madoituong = rs.madoituong,
        //                mabn = rs.mabn,
        //                ngay_cd = rs.ngay_cd,
        //                ngay_kq = rs.ngay_kq,
        //                bscd = rs.bscd,
        //                bskq = rs.bskq,
        //                icd10 = rs.icd10,
        //                tenicd10 = rs.tenicd10,
        //                h1 = rs.h1,
        //                h2 = rs.h2,
        //                idchidinh = rs.idchidinh,
        //                idloai = rs.idloai,
        //                loaibn = rs.loaibn,
        //                userid = rs.userid,
        //                mmyy = rs.mmyy,
        //                ngayhientai = rs.ngayhientai,
        //                computer = rs.computer,
        //                noidung = rs.noidung,
        //                denghi = rs.denghi,
        //                ketluan = rs.ketluan,
        //                id_gia = rs.id_gia,
        //            }).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return _ResultReadModel;
        //}

        //public List<ResultReadModel> GetID(PTParaModel i_Param)
        //{
        //    //ImageToBase64
        //    bool _imgbool = true;

        //    string _idResult = i_Param.lstPara[0].value.ToString();
        //    var _ResultReadModel = new List<ResultReadModel>();
        //    try
        //    {
        //        _ResultReadModel = dbContext.cdha_ketqua.Where(x=>x.id_cdha == _idResult)
        //            .Select(rs => new ResultReadModel
        //            {
        //                id_cdha = rs.id_cdha,
        //                maql = rs.maql,
        //                mavv = rs.mavv,
        //                mavk = rs.mavk,
        //                mapk = rs.mapk,
        //                madoituong = rs.madoituong,
        //                mabn = rs.mabn,
        //                ngay_cd = rs.ngay_cd,
        //                ngay_kq = rs.ngay_kq,
        //                bscd = rs.bscd,
        //                bskq = rs.bskq,
        //                icd10 = rs.icd10,
        //                tenicd10 = rs.tenicd10,
        //                h1 = rs.h1,
        //                h2 = rs.h2,
        //                idchidinh = rs.idchidinh,
        //                idloai = rs.idloai,
        //                loaibn = rs.loaibn,
        //                userid = rs.userid,
        //                mmyy = rs.mmyy,
        //                ngayhientai = rs.ngayhientai,
        //                computer = rs.computer,
        //                noidung = rs.noidung,
        //                denghi = rs.denghi,
        //                ketluan = rs.ketluan,
        //                id_gia = rs.id_gia,
        //            }).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return _ResultReadModel;
        //}

        //public bool Save(ResultModel i_ResultReadModel)
        //{
        //    try
        //    {
        //        _mapper = new ResultEntityMapper();
        //        cdha_ketqua _cdha_ketqua = _mapper.MapFromResultModelToTestEntity(i_ResultReadModel);
        //        List<cdha_ketqua> _lstcdha_ketqua = new List<cdha_ketqua>();
        //        _lstcdha_ketqua.Add(_cdha_ketqua);
        //        //if (_cdha_ketqua != null)
        //        //{
        //        //    PatientObject _PatientObject = i_RegisterModel.patient;
        //        //    btdbn _btdbn = _mapper.MapFromPatientObjectToTestEntity(_PatientObject);
        //        //    List<btdbn> _lstbtdbn = new List<btdbn>();
        //        //    _lstbtdbn.Add(_btdbn);
        //        //    if(_lstbtdbn !=null)
        //        //    {
        //        //        dbContext.BulkMerge(_lstbtdbn);
        //        //    }

        //        //    Library.SaveFile("", "imgname", "fother", i_RegisterModel.diachi.ToString());
        //       // }
        //        dbContext.BulkMerge(_lstcdha_ketqua);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return true;
        //}
    }
}
