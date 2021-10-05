namespace PavementCondition.Entity

[<CLIMutable>]
type Road = {
    Id: int
    mutable Number: string
    mutable StartPoint: string
    mutable EndPoint: string
    mutable Distance: decimal
    mutable ServiceOrganization: string
}