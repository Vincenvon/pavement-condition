namespace PavementCondition.API.Contracts.Roads

type CreateRoadRequest = {
    Number: string
    StartPoint: string
    EndPoint: string
    Distance: decimal
    ServiceOrganization: string
}