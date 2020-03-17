using AutoMapper;
using Corona.Api.Application.Dtos;
using Corona.Api.Domain.Entities;

namespace Corona.Api.Mapping.Profiles
{
    /// <summary>
    /// Represents the <see cref="DataProfile"/> class.
    /// </summary>
    public class DataProfile : Profile
    {
        /// <summary>
        /// Maps the profile.
        /// </summary>
        public DataProfile()
        {
            CreateMap<Data, DataDto>();
            CreateMap<DataDto, Data>();
        }
    }
}
