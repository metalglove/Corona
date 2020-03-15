using Glovali.Common.Domain;
using System;

namespace Corona.Api.Domain
{
    public class CoronaTimeSeriesRecord : TimeSeriesRecord, IEntity
    {
        public string Region { get; set; } = null!;
        public int Confirmed { get; set; }
        public int Deaths { get; set; }
        public int Recoverd { get; set; }

        // we don't use this
        Guid IEntity.Id => throw new NotSupportedException();
    }
}
