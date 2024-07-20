using System;
using System.Collections.Generic;
using System.Text;

namespace Emr.Domain.Model
{
    public class DistrictModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CityId { get; set; }
    }
}
