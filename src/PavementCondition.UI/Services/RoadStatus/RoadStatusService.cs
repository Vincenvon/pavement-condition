using AutoMapper;

using PavementCondition.API.Contracts.RoadStatus;
using PavementCondition.UI.Constants;
using PavementCondition.UI.Infrastructure;
using PavementCondition.UI.Models.RoadStatus;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace PavementCondition.UI.Services.RoadStatus
{
    public class RoadStatusService : IRoadStatusService
    {
        private readonly IApiClient _apiClient;
        private readonly IMapper _mapper;

        public RoadStatusService(IApiClient apiClient, IMapper mapper)
        {
            _apiClient = apiClient;
            _mapper = mapper;
        }

        public async Task<List<RoadStatusTableModel>> GetAsync()
        {
            var responses = await _apiClient.GetAsync<List<RoadStatusTableResponse>>($"/{ApiControllerNameConstants.RoadStatuses}");
            return _mapper.Map<List<RoadStatusTableModel>>(responses);
        }
    }
}
