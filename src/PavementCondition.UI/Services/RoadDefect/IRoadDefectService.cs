using PavementCondition.UI.Models.RoadDefect;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace PavementCondition.UI.Services.RoadDefect
{
    public interface IRoadDefectService
    {
        Task<List<RoadDefectTableModel>> GetAsync(int roadInspectionId);

        Task<RoadDefectModel> CreateAsync(RoadDefectModel model);

        Task<RoadDefectModel> EditAsync(RoadDefectModel model);

        Task<RoadDefectModel> GetByIdAsync(int id);

        Task DeleteAsync(int id);
    }
}
