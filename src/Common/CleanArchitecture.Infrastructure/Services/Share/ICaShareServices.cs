using Emr.Domain.Model.Share;
using System.Collections.Generic;

namespace Emr.Infrastructure.Services.Share
{
    public interface ICaShareServices
    {
        List<CaShareModel> GetAll();
    }
}
