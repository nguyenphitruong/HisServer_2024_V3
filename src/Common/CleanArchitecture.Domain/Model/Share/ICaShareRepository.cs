using System.Collections.Generic;

namespace Emr.Domain.Model.Share
{
    public interface ICaShareRepository
    {

        List<CaShareModel> GetAll();
        //string GetCode(string _codeget, int i_action);
    }
}
