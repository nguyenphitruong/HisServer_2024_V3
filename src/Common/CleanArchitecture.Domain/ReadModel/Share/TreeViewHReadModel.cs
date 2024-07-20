using System;
using System.Collections.Generic;

namespace Emr.Domain.ReadModel.Share
{
    public class TreeViewHReadModel
    {
        public TreeViewHReadModel()
        {
            LstTreeViewL = new List<TreeViewLReadModel>();
        }
        public string code { get; set; }
        public String name { get; set; }
        public string codeline { get; set; }
        public String nameline { get; set; }

        public List<TreeViewLReadModel> LstTreeViewL;
    }
}
