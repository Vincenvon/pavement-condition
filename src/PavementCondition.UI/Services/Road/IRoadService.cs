using PavementCondition.UI.Models.Road;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace PavementCondition.UI.Services.Road
{
    public interface IRoadService
    {
        Task<List<RoadModel>> GetAsync();

        Task<RoadModel> CreateAsync(RoadModel model);

        Task<RoadModel> EditAsync(RoadModel model);

        Task<RoadModel> GetByIdAsync(int id);

        Task DeleteAsync(int id);
    }
}
