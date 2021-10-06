using AutoMapper;

using Microsoft.FSharp.Core;

using PavementCondition.API.Contracts.RoadStatus;
using PavementCondition.UI.Models.RoadStatus;

using System;

namespace PavementCondition.UI.MappingProfiles
{
    public class RoadStatusProfile: Profile
    {
        public RoadStatusProfile()
        {
            this.CreateMap<RoadStatusTableResponse, RoadStatusTableModel>()
                .ForMember(r => r.RoadNumber, x => x.MapFrom(r => r.RoadNumber))
                .ForMember(r => r.LastInspectionId, x => x.MapFrom(r => (int?)(FSharpOption<int>.get_IsNone(r.LastInspectionId) ? null: r.LastInspectionId.Value)))
                .ForMember(r => r.LastInspectionNumber, x => x.MapFrom(r => (string)(FSharpOption<string>.get_IsNone(r.LastInspectionNumber) ? null: r.LastInspectionNumber.Value)))
                .ForMember(r => r.LastInspectionDate, x => x.MapFrom(r => (DateTime?)(FSharpOption<DateTime>.get_IsNone(r.LastInspectionDate) ? null : r.LastInspectionDate.Value)))
                .ForMember(r => r.DefectPercent, x => x.MapFrom(r => (decimal?)(FSharpOption<decimal>.get_IsNone(r.DefectPercent) ? null : r.DefectPercent.Value)));
        }
    }
}