using AutoMapper;

using PavementCondition.API.Contracts.Roads;
using PavementCondition.UI.Models.Road;

namespace PavementCondition.UI.MappingProfiles
{
    public class RoadProfile : Profile
    {
        public RoadProfile()
        {
            CreateMap<RoadResponse, RoadModel>();
        }
    }
}
