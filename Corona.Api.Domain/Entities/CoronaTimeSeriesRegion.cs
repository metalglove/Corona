using Glovali.Common.Domain;
using System.Collections.Generic;

namespace Corona.Api.Domain.Entities
{
    public class CoronaTimeSeriesRegion : IEntity<string>
    {
        string IEntity<string>.Id => Region;
        public string Region { get; set; } = null!;
        public string Latitude { get; set; } = null!;
        public string Longitude { get; set; } = null!;
        public virtual IEnumerable<CoronaTimeSeriesRecord> Records { get; set; } = null!;
    }
}