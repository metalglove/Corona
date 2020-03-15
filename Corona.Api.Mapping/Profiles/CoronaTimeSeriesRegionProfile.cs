using AutoMapper;
using Corona.Api.Application.Dtos;
using Corona.Api.Domain.Entities;

namespace Corona.Api.Mapping.Profiles
{
    /// <summary>
    /// Represents the <see cref="CoronaTimeSeriesRegionProfile"/> class.
    /// </summary>
    public class CoronaTimeSeriesRegionProfile : Profile
    {
        /// <summary>
        /// Maps the profile.
        /// </summary>
        public CoronaTimeSeriesRegionProfile()
        {
            CreateMap<CoronaTimeSeriesRegion, CoronaTimeSeriesRegionDto>();
            CreateMap<CoronaTimeSeriesRegionDto, CoronaTimeSeriesRegion>();
        }
    }
}
