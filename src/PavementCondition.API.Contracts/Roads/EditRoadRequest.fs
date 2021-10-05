namespace PavementCondition.API.Contracts.Roads

type EditRoadRequest = {
   Id: int
   Number: string
   StartPoint: string
   EndPoint: string
   Distance: decimal
   ServiceOrganization: string
}

