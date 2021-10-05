using AutoMapper;

using PavementCondition.API.Contracts.RoadStatus;
using PavementCondition.UI.Models.RoadStatus;

namespace PavementCondition.UI.MappingProfiles
{
    public class RoadStatusProfile: Profile
    {
        public RoadStatusProfile()
        {
            this.CreateMap<RoadStatusTableResponse, RoadStatusTableModel>();
        }
    }
}
