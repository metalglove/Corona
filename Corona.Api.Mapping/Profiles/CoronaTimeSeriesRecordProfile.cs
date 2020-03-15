using AutoMapper;
using Corona.Api.Application.Dtos;
using Corona.Api.Domain.Entities;

namespace Corona.Api.Mapping.Profiles
{
    /// <summary>
    /// Represents the <see cref="CoronaTimeSeriesRecordProfile"/> class.
    /// </summary>
    public class CoronaTimeSeriesRecordProfile : Profile
    {
        /// <summary>
        /// Maps the profile.
        /// </summary>
        public CoronaTimeSeriesRecordProfile()
        {
            CreateMap<CoronaTimeSeriesRecord, CoronaTimeSeriesRecordDto>();
            CreateMap<CoronaTimeSeriesRecordDto, CoronaTimeSeriesRecord>();
        }
    }
}
