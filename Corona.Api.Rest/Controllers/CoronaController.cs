using Corona.Api.Application.Dtos;
using Glovali.Common.Application.Interfaces;
using Glovali.Common.Rest;
using Microsoft.AspNetCore.Mvc;

namespace Corona.Api.Rest.Controllers
{
    [Route("corona")]
    public class CoronaTimeSeriesRestController : RestController<CoronaTimeSeriesRegionDto, string>
    {
        public CoronaTimeSeriesRestController(IService<CoronaTimeSeriesRegionDto, string> service) : base(service)
        {
        }
    }
}
