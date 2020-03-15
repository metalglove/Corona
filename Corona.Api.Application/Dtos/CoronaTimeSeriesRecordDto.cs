namespace Corona.Api.Application.Dtos
{
    public class CoronaTimeSeriesRecordDto : TimeSeriesRecordDto
    {
        public string Region { get; set; } = null!;
        public int Confirmed { get; set; }
        public int Deaths { get; set; }
        public int Recoverd { get; set; }
    }
}
