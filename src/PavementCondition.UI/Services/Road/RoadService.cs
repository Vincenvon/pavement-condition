using AutoMapper;

using PavementCondition.API.Contracts.Roads;
using PavementCondition.UI.Infrastructure;
using PavementCondition.UI.Models.Road;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace PavementCondition.UI.Services.Road
{
    public class RoadService : IRoadService
    {
        private readonly IApiClient _apiClient;
        private readonly IMapper _mapper;

        public RoadService(IApiClient apiClient, IMapper mapper)
        {
            _apiClient = apiClient;
            _mapper = mapper;
        }

        public async Task<RoadModel> CreateAsync(RoadModel model)
        {
            var request = new CreateRoadRequest(model.Number, model.StartPoint, model.EndPoint, model.Distance, model.ServiceOrganization);
            var response = await _apiClient.PostAsync<CreateRoadRequest, RoadResponse>(request, "/roads");

            return _mapper.Map<RoadModel>(response);
        }

        public async Task DeleteAsync(int id)
        {
            await _apiClient.DeleteAsync(id, $"/roads/{id}");
        }

        public async Task<RoadModel> EditAsync(RoadModel model)
        {
            var request = new EditRoadRequest(model.Id, model.Number, model.StartPoint, model.EndPoint, model.Distance, model.ServiceOrganization);
            var response = await _apiClient.PutAsync<EditRoadRequest, RoadResponse>(request, "/roads");

            return _mapper.Map<RoadModel>(response);
        }

        public async Task<List<RoadModel>> GetAsync()
        {
            var responses = await _apiClient.GetAsync<List<RoadResponse>>("/roads");
            return _mapper.Map<List<RoadModel>>(responses);
        }

        public async Task<RoadModel> GetByIdAsync(int id)
        {
            var responses = await _apiClient.GetAsync<RoadResponse>($"/roads/{id}");
            return _mapper.Map<RoadModel>(responses);
        }
    }
}
