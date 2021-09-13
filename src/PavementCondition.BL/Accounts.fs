module PavementCondition.BL.Accounts

open PavementCondition.DataAccess
open PavementCondition.Entity
open PavementCondition.BL.Contracts.Accounts
open System.Linq
open BCrypt.Net

let create (db: DatabaseContext) (dto: CreateDto) :UserDto = 
    let existingUser = db.Users.AsQueryable().Where(fun u -> u.Email = dto.Email)
    let newUser: User = {
        Id = 0
        Email = dto.Email
        FirstName = dto.FirstName
        LastName = dto.LastName
        Username = dto.Username
        PasswordHash = BCrypt.HashPassword(dto.Password)
    }
    let addedUser = db.Users.Add(newUser)
    db.SaveChanges() |> ignore
    let createdDto = {
       Id = addedUser.Entity.Id
       Email = addedUser.Entity.Email
       FirstName = addedUser.Entity.FirstName
       LastName = addedUser.Entity.LastName
       Username = addedUser.Entity.Username
    }
    createdDto
