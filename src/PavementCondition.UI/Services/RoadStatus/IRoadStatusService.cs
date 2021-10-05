using PavementCondition.UI.Models.RoadStatus;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace PavementCondition.UI.Services.RoadStatus
{
    public interface IRoadStatusService
    {
        Task<List<RoadStatusTableModel>> GetAsync();
    }
}
