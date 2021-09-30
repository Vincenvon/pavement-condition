module PavementCondition.BL.Accounts

open PavementCondition.DataAccess
open PavementCondition.Entity
open PavementCondition.BL.Contracts.Accounts
open System.Linq
open BCrypt.Net
open System.IdentityModel.Tokens.Jwt;
open System.IdentityModel.Tokens 

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

let login (db: DatabaseContext) (dto: LoginDto): TokenDto = 
    let existingUser = db.Users.AsQueryable().FirstOrDefault(fun u -> u.Email = dto.Email)
    match existingUser with
    | null -> null
    |_ -> 
        let isPasswordValid = BCrypt.Verify(dto.Password, existingUser.PasswordHash)
        match isPasswordValid with
        | true -> 
            let tokenHandler = new JwtSecurityTokenHandler()
            let accessTokenDescriptor = new SecurityTokenDescriptor()
            accessTokenDescriptor.Subject = new ClaimsIdentity(new[] { new Claim("id", accountId.ToString()) })
            accessTokenDescriptor.Expires = DateTime.UtcNow.AddDays(7)
            accessTokenDescriptor.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            let tokenDto: TokenDto = {
               AccessToke = 
            }
    