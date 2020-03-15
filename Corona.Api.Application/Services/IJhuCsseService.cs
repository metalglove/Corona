using Corona.Api.Application.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Corona.Api.Application.Services
{
    public interface IJhuCsseService
    {
        Task<List<CoronaTimeSeriesRegionDto>> GetLatestDataAsync();
        Task<List<CoronaTimeSeriesRegionDto>> GetLatestDataAsync(CancellationToken cancellationToken);
    }
}
