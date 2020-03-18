using AutoMapper;
using Corona.Api.Application.Dtos;
using Corona.Api.Domain.Entities;

namespace Corona.Api.Mapping.Profiles
{
    /// <summary>
    /// Represents the <see cref="RecordProfile"/> class.
    /// </summary>
    public class RecordProfile : Profile
    {
        /// <summary>
        /// Maps the profile.
        /// </summary>
        public RecordProfile()
        {
            CreateMap<Record, RecordDto>();
            CreateMap<RecordDto, Record>();
        }
    }
}
