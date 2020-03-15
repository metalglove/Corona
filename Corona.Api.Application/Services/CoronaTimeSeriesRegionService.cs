using AutoMapper;
using Corona.Api.Application.Dtos;
using Corona.Api.Domain.Entities;
using Glovali.Common.Application.Abstractions;
using Glovali.Common.Application.Interfaces;

namespace Corona.Api.Application.Services
{
    public class CoronaTimeSeriesRegionService : BaseService<CoronaTimeSeriesRegion, CoronaTimeSeriesRegionDto, string>
    {
        public CoronaTimeSeriesRegionService(IRepository<CoronaTimeSeriesRegion, string> entityRepository, IMapper mapper) : base(entityRepository, mapper)
        {
        }
    }
}
