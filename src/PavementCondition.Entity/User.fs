namespace PavementCondition.Entity

[<CLIMutable>]
type User = {    
    Id: int
    Email: string
    FirstName: string
    LastName: string
    Username: string
    PasswordHash: string
}