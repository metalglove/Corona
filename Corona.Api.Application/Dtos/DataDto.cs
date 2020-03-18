using System;

namespace Corona.Api.Application.Dtos
{
    public class DataDto
    {
        public DateTime Date { get; set; }
        public int Confirmed { get; set; }
        public int Deaths { get; set; }
        public int Recovered { get; set; }
    }
}
