using PavementCondition.UI.Models.RoadInspection;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace PavementCondition.UI.Services.RoadInspection
{
    public interface IRoadInspectionService
    {
        Task<List<RoadInspectionTableModel>> GetAsync();

        Task<RoadInspectionModel> CreateAsync(RoadInspectionModel model);

        Task<RoadInspectionModel> EditAsync(RoadInspectionModel model);

        Task<RoadInspectionModel> GetByIdAsync(int id);

        Task DeleteAsync(int id);
    }
}
