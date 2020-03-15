using AutoMapper;
using Corona.Api.Application.Dtos;
using Corona.Api.Domain;
using Glovali.Common.Application.Abstractions;
using Glovali.Common.Application.Interfaces;

namespace Corona.Api.Application.Services
{
    public class CoronaTimeSeriesRegionService : BaseService<CoronaTimeSeriesRegion, CoronaTimeSeriesRegionDto>
    {
        public CoronaTimeSeriesRegionService(IRepository<CoronaTimeSeriesRegion> entityRepository, IMapper mapper) : base(entityRepository, mapper)
        {
        }
    }
}
