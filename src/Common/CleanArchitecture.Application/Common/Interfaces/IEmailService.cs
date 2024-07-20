using System.Threading.Tasks;
using Emr.Application.Common.Models;

namespace Emr.Application.Common.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}
