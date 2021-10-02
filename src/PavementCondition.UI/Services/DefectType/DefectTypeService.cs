using PavementCondition.API.Contracts.DefectTypes;
using PavementCondition.UI.Infrastructure;
using PavementCondition.UI.Models.DefectType;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PavementCondition.UI.Services.DefectType
{
    public class DefectTypeService : IDefectTypeService
    {
        private readonly IApiClient _apiClient;

        public DefectTypeService(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<DefectTypeModel> CreateAsync(DefectTypeModel model)
        {
            var request = new CreateDefectTypeRequest(model.Name);
            var response = await _apiClient.PostAsync<CreateDefectTypeRequest, DefectTypeResponse>(request, "/defecttypes");

            return new DefectTypeModel
            {
                CreatedDate = response.CreatedDate,
                Name = response.Name,
                Id = response.Id
            };
        }

        public async Task DeleteAsync(int id)
        {
            await _apiClient.DeleteAsync(id, $"/defecttypes/{id}");
        }

        public async Task<DefectTypeModel> EditAsync(DefectTypeModel model)
        {
            var request = new EditDefectTypeRequest(model.Id, model.Name, model.CreatedDate);
            var response = await _apiClient.PutAsync<EditDefectTypeRequest, DefectTypeResponse>(request, "/defecttypes");

            return new DefectTypeModel
            {
                CreatedDate = response.CreatedDate,
                Name = response.Name,
                Id = response.Id
            };
        }

        public async Task<List<DefectTypeModel>> GetAsync()
        {
            var responses = await _apiClient.GetAsync<List<DefectTypeResponse>>("/defecttypes");
            var models = responses.Select(r => new DefectTypeModel { Id = r.Id, CreatedDate = r.CreatedDate, Name = r.Name }).ToList();
            return models;
        }

        public async Task<DefectTypeModel> GetByIdAsync(int id)
        {
            var response = await _apiClient.GetAsync<DefectTypeResponse>($"/defecttypes/{id}");
            return new DefectTypeModel
            {
                Id = response.Id,
                Name = response.Name,
                CreatedDate = response.CreatedDate
            };
        }
    }
}
