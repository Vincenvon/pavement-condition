using AutoMapper;

using PavementCondition.API.Contracts.RoadDefects;
using PavementCondition.UI.Constants;
using PavementCondition.UI.Infrastructure;
using PavementCondition.UI.Models.RoadDefect;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace PavementCondition.UI.Services.RoadDefect
{
    public class RoadDefectService : IRoadDefectService
    {
        private readonly IApiClient _apiClient;
        private readonly IMapper _mapper;

        public RoadDefectService(IApiClient apiClient, IMapper mapper)
        {
            _apiClient = apiClient;
            _mapper = mapper;
        }

        public async Task<RoadDefectModel> CreateAsync(RoadDefectModel model)
        {
            var request = new CreateRoadDefectRequest(model.RoadInspectionId, model.DefectTypeId, model.DefectStartPoint, model.DefectDistance);
            var response = await _apiClient.PostAsync<CreateRoadDefectRequest, RoadDefectResponse>(request, ApiControllerNameConstants.RoadDefects);

            return _mapper.Map<RoadDefectModel>(response);
        }

        public async Task DeleteAsync(int id)
        {
            await _apiClient.DeleteAsync(id, $"/{ ApiControllerNameConstants.RoadDefects}/{id}");
        }

        public async Task<RoadDefectModel> EditAsync(RoadDefectModel model)
        {
            var request = new EditRoadDefectRequest(model.Id, model.RoadInspectionId, model.DefectTypeId, model.DefectStartPoint, model.DefectDistance);
            var response = await _apiClient.PutAsync<EditRoadDefectRequest, RoadDefectResponse>(request, ApiControllerNameConstants.RoadDefects);

            return _mapper.Map<RoadDefectModel>(response);
        }

        public async Task<List<RoadDefectTableModel>> GetAsync(int roadInspectionId)
        {
            var responses = await _apiClient.GetAsync<List<RoadDefectTableResponse>>($"/{ApiControllerNameConstants.RoadDefects}/inspections/{roadInspectionId}");
            return _mapper.Map<List<RoadDefectTableModel>>(responses);
        }

        public async Task<RoadDefectModel> GetByIdAsync(int id)
        {
            var responses = await _apiClient.GetAsync<RoadDefectResponse>($"/{ApiControllerNameConstants.RoadDefects}/{id}");
            return _mapper.Map<RoadDefectModel>(responses);
        }
    }
}
