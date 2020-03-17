using Corona.Api.Application.Dtos;
using Glovali.Common.Application.Interfaces;
using Glovali.Common.Rest;
using Microsoft.AspNetCore.Mvc;

namespace Corona.Api.Rest.Controllers
{
    [Route("corona")]
    public class CoronaTimeSeriesRestController : RestController<ReportDto, string>
    {
        public CoronaTimeSeriesRestController(IService<ReportDto, string> service) : base(service)
        {
        }
    }
}
