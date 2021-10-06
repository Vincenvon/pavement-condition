using AutoMapper;

using PavementCondition.API.Contracts.RoadInspection;
using PavementCondition.API.Contracts.Roads;
using PavementCondition.UI.Models.RoadInspection;

namespace PavementCondition.UI.MappingProfiles
{
    public class RoadInspectionProfile : Profile
    {
        public RoadInspectionProfile()
        {
            this.CreateMap<RoadInspectionTableResponse, RoadInspectionTableModel>();

            this.CreateMap<RoadInspectionReponse, RoadInspectionModel>();
        }
    }
}
