using Glovali.Common.Domain;
using System;

namespace Corona.Api.Domain.Entities
{
    public class Data : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int Confirmed { get; set; }
        public int Deaths { get; set; }
        public int Recovered { get; set; }
    }
}
