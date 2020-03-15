using Corona.Api.Domain.Entities;
using Glovali.Common.Application.Interfaces;
using Glovali.Common.Rest;
using Microsoft.AspNetCore.Mvc;

namespace Corona.Api.Rest.Controllers
{
    [Route("corona")]
    public class CoronaTimeSeriesRestController : RestController<CoronaTimeSeriesRegion, string>
    {
        public CoronaTimeSeriesRestController(IService<CoronaTimeSeriesRegion, string> service) : base(service)
        {
        }
    }
}
