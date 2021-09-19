using PavementCondition.UI.Models.DefectType;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace PavementCondition.UI.Services.DefectType
{
    public interface IDefectTypeService
    {
        Task<List<DefectTypeModel>> GetAsync();

        Task<DefectTypeModel> CreateAsync(DefectTypeModel model);

        Task<DefectTypeModel> EditAsync(DefectTypeModel model);

        Task<DefectTypeModel> GetByIdAsync(int id);

        Task DeleteAsync(int id);
    }
}
