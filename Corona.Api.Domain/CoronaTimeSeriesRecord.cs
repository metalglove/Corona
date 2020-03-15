using Glovali.Common.Domain;
using System;

namespace Corona.Api.Domain
{
    public class CoronaTimeSeriesRecord : TimeSeriesRecord, IEntity<string>
    {
        string IEntity<string>.Id => Region;
        public string Region { get; set; } = null!;
        public int Confirmed { get; set; }
        public int Deaths { get; set; }
        public int Recoverd { get; set; }
    }
}
