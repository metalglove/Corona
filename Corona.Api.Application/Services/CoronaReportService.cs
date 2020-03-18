using AutoMapper;
using Corona.Api.Application.Dtos;
using Corona.Api.Domain.Entities;
using Glovali.Common.Application.Abstractions;
using Glovali.Common.Application.Interfaces;

namespace Corona.Api.Application.Services
{
    public class CoronaReportService : BaseService<Report, ReportDto, string>
    {
        public CoronaReportService(IRepository<Report, string> entityRepository, IMapper mapper) : base(entityRepository, mapper)
        {
        }
    }
}
