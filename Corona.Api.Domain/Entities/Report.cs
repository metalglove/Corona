using Glovali.Common.Domain;
using System.Collections.Generic;

namespace Corona.Api.Domain.Entities
{
    public class Report : IEntity<string>
    {
        public string Id { get; set; }
        public virtual List<Record> Records { get; set; }
    }
}
