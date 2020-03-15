using System.Collections.Generic;

namespace Corona.Api.Application.Dtos
{
    public class CoronaTimeSeriesRegionDto
    {
        public string Region { get; set; } = null!;
        public string Latitude { get; set; } = null!;
        public string Longitude { get; set; } = null!;
        public IEnumerable<CoronaTimeSeriesRecordDto> Records { get; set; } = null!;
    }
}
