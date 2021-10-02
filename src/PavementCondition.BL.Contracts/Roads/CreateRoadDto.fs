namespace PavementCondition.BL.Contracts.Roads

type CreateRoadDto = {
    Number: string
    StartPoint: string
    EndPoint: string
    Distance: decimal
    ServiceOrganization: string
}