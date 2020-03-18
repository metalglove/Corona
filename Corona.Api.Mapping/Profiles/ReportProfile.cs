using AutoMapper;
using Corona.Api.Application.Dtos;
using Corona.Api.Domain.Entities;

namespace Corona.Api.Mapping.Profiles
{
    /// <summary>
    /// Represents the <see cref="ReportProfile"/> class.
    /// </summary>
    public class ReportProfile : Profile
    {
        /// <summary>
        /// Maps the profile.
        /// </summary>
        public ReportProfile()
        {
            CreateMap<Report, ReportDto>();
            CreateMap<ReportDto, Report>();
        }
    }
}
