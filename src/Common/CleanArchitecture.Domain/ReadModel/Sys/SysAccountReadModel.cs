﻿namespace Emr.Domain.ReadModel.Sys
{
    public class SysAccountReadModel
    {
        public string codeUser { get; set; }
        public string userName { get; set; }
        public string passWord { get; set; }
        public string fullName { get; set; }
        public string codeDep { get; set; }
        public string codeEmp { get; set; }
        public int? codePer { get; set; }
        public int? active { get; set; }

    }
}