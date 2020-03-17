using Glovali.Common.Domain;
using System;
using System.Collections.Generic;

namespace Corona.Api.Domain.Entities
{
    public class Record : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual List<Data> Data { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
