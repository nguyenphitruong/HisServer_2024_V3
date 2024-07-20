using System.Globalization;
using Emr.Application.Dto;
using CsvHelper.Configuration;

namespace Emr.Infrastructure.Files.Maps
{
    public sealed class DistrictMap : ClassMap<DistrictDto>
    {
        public DistrictMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.Villages).Convert(_ => "");
        }
    }
}
