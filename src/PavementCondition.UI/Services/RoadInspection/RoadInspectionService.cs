using AutoMapper;

using PavementCondition.API.Contracts.RoadInspection;
using PavementCondition.UI.Constants;
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

        public async Task<RoadInspectionModel> CreateAsync(RoadInspectionModel model)
        {
            var request = new CreateRoadInspectionRequest(model.RoadId, model.Number, model.Engineer, model.InspectionDate);
            var response = await _apiClient.PostAsync<CreateRoadInspectionRequest, RoadInspectionReponse>(request, ApiControllerNameConstants.RoadInspections);

            return _mapper.Map<RoadInspectionModel>(response);
        }

        public async Task DeleteAsync(int id)
        {
            await _apiClient.DeleteAsync(id, $"/${ApiControllerNameConstants.RoadInspections}/{id}");
        }

        public async Task<RoadInspectionModel> EditAsync(RoadInspectionModel model)
        {
            var request = new EditRoadInspectionRequest(model.Id, model.RoadId, model.Number, model.Engineer, model.InspectionDate);
            var response = await _apiClient.PutAsync<EditRoadInspectionRequest, RoadInspectionReponse>(request, ApiControllerNameConstants.RoadInspections);

            return _mapper.Map<RoadInspectionModel>(response);
        }

        public async Task<List<RoadInspectionTableModel>> GetAsync()
        {
            var responses = await _apiClient.GetAsync<List<RoadInspectionTableResponse>>(ApiControllerNameConstants.RoadInspections);
            return _mapper.Map<List<RoadInspectionTableModel>>(responses);
        }

        public async Task<RoadInspectionModel> GetByIdAsync(int id)
        {
            var responses = await _apiClient.GetAsync<RoadInspectionReponse>($"/{ApiControllerNameConstants.RoadInspections}/{id}");
            return _mapper.Map<RoadInspectionModel>(responses);
        }
    }
}
