using System;

namespace Emr.Domain.Model.Share.BHYT
{
    public class ApiKeyReadModel
    {
        public string access_token { get; set; }
        public string id_token { get; set; }
        public string token_type { get; set; }
        public string username { get; set; }
        public DateTime expires_in { get; set; }
    }
}
