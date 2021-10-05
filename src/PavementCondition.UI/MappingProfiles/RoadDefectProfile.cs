using AutoMapper;

using PavementCondition.API.Contracts.RoadDefects;
using PavementCondition.UI.Models.RoadDefect;

namespace PavementCondition.UI.MappingProfiles
{
    public class RoadDefectProfile : Profile
    {
        public RoadDefectProfile()
        {
            this.CreateMap<RoadDefectResponse, RoadDefectModel>();

            this.CreateMap<RoadDefectTableResponse, RoadDefectTableModel>();
        }
    }
}
