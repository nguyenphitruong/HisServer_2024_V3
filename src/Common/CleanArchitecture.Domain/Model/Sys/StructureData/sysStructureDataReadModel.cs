using System;
using System.Collections.Generic;
using System.Text;

namespace Emr.Domain.Model.Sys.StructureData
{
    public class sysStructureDataReadModel 
    {
        public sysStructureDataReadModel() 
        {
            lsttables = new List<sysTableReadModel>();
        }  
        public string mmyy { get; set; }  
        public string name { get; set; }  
        
        public int count { get; set; }
        public string error { get; set; }

        public List<sysTableReadModel> lsttables { get; set; }
    }
}
