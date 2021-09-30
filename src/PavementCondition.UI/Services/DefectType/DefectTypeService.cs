using PavementCondition.API.Contracts.DefectTypes;
using PavementCondition.UI.Infrastructure;
using PavementCondition.UI.Models.DefectType;

using System;
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

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DefectTypeModel> EditAsync(DefectTypeModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DefectTypeModel>> GetAsync()
        {
            var responses = await _apiClient.GetAsync<List<DefectTypeResponse>>("/defecttypes");
            var models = responses.Select(r => new DefectTypeModel { Id = r.Id, CreatedDate = r.CreatedDate, Name = r.Name }).ToList();
            return models;
        }

        public Task<DefectTypeModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
