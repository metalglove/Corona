using System.Collections.Generic;

namespace Corona.Api.Application.Dtos
{
    public class RecordDto
    {
        public string Name { get; set; }
        public List<DataDto> Data { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
