using Corona.Api.Domain;
using Glovali.Common.Application.Interfaces;
using Glovali.Common.Rest;
using Microsoft.AspNetCore.Mvc;

namespace Corona.Api.Rest.Controllers
{
    [Route("corona")]
    public class CoronaTimeSeriesRestController : RestController<CoronaTimeSeriesRegion>
    {
        public CoronaTimeSeriesRestController(IService<CoronaTimeSeriesRegion> service) : base(service)
        {
        }
    }
}
