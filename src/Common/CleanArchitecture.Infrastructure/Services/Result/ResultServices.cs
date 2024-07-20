using Emr.Infrastructure.UniOfWork;

namespace Emr.Infrastructure.Services.Result
{
    public class ResultServices : IResultServices
    {
        //Khởi tao IUnitOfWord 
        private IUnitOfWork unitOfWork;

        //Tạo Constructor Hứng i_UnitOfWord
        public ResultServices(IUnitOfWork i_UnitOfWork)
        {
            unitOfWork = i_UnitOfWork;
        }

        //public List<emrregister> GetAll()
        //{
        //    try
        //    {
        //        return _Context.ResultRepository.GetAll();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public List<ResultReadModel> GetID(PTParaModel i_Param)
        //{
        //    try
        //    {
        //        return _Context.ResultRepository.GetID(i_Param);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public bool Save(ResultModel i_RegisterModel)
        //{
        //    try
        //    {
        //        _Context.InitTransaction();
        //        _Context.ResultRepository.Save(i_RegisterModel);
        //        _Context.Save();
        //        _Context.CommitTransaction();
        //    }
        //    catch (Exception ex)
        //    {
        //        _Context.RollbackTransaction();
        //        throw ex;
        //    }
        //    return true;
        //}
    }
}
