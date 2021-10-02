namespace PavementCondition.Entity

[<CLIMutable>]
type Road = {
    Id: int
    Number: string
    StartPoint: string
    EndPoint: string
    Distance: decimal
    ServiceOrganization: string
}