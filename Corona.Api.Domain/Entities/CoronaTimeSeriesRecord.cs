using Glovali.Common.Domain;

namespace Corona.Api.Domain.Entities
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
