namespace PavementCondition.API.Contracts.Roads

type RoadResponse = {
    Id: int
    Number: string
    StartPoint: string
    EndPoint: string
    Distance: decimal
    ServiceOrganization: string
}