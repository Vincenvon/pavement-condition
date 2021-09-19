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
            var response = await _apiClient.PostAsync<CreateDefectTypeRequest, CreateDefectTypeResponse>(request);

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

        public Task<List<DefectTypeModel>> GetAsync()
        {
            return Task.FromResult(Enumerable.Range(0, 10).Select(i => new DefectTypeModel { Id = i, CreatedDate = DateTime.Now, Name = i.ToString() }).ToList());
        }

        public Task<DefectTypeModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
