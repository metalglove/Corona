using System.Collections.Generic;

namespace Corona.Api.Application.Dtos
{
    public class ReportDto
    {
        public string Id { get; set; }
        public List<RecordDto> Records { get; set; }
    }
}
