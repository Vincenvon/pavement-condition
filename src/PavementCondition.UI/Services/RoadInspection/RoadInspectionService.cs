using AutoMapper;

using PavementCondition.API.Contracts.RoadInspection;
using PavementCondition.UI.Infrastructure;
using PavementCondition.UI.Models.RoadInspection;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PavementCondition.UI.Services.RoadInspection
{
    public class RoadInspectionService : IRoadInspectionService
    {
        private readonly IApiClient _apiClient;
        private readonly IMapper _mapper;

        public RoadInspectionService(IApiClient apiClient, IMapper mapper)
        {
            _apiClient = apiClient;
            _mapper = mapper;
        }

        public Task<RoadInspectionModel> CreateAsync(RoadInspectionModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RoadInspectionModel> EditAsync(RoadInspectionModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RoadInspectionTableModel>> GetAsync()
        {
            var responses = await _apiClient.GetAsync<List<RoadInspectionTableResponse>>("/roads");
            return _mapper.Map<List<RoadInspectionTableModel>>(responses);
        }

        public Task<RoadInspectionModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
