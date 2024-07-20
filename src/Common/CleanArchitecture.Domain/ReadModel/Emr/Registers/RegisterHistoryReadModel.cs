using System;
using System.Collections.Generic;

namespace Emr.Domain.ReadModel.Emr.Registers
{
    public class RegisterHistoryReadModel
    {
        public RegisterHistoryReadModel()
        {
            ManageHistory = new List<ManageHistoryReadModel>();
        }
        public string patcode { get; set; }
        public string code { get; set; }
        public string medexacode { get; set; }

        public string name { get; set; }
        public string mmyy { get; set; }

        public List<ManageHistoryReadModel> ManageHistory;

    }
}
