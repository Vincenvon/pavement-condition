module PavementCondition.BL.Accounts

open PavementCondition.DataAccess
open PavementCondition.Entity
open PavementCondition.BL.Contracts.Accounts
open PavementCondition.BL.Contracts
open System.Linq
open BCrypt.Net
open System.IdentityModel.Tokens.Jwt;
open System.IdentityModel.Tokens 
open System.Security.Claims
open System
open Microsoft.IdentityModel.Tokens
open System.Text

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

let buildToken (settings: JwtTokenSettings) (email: string): string = 
    let now = DateTime.Now
    let token = new JwtSecurityToken(settings.Issuer, settings.Audience, [| new Claim(ClaimsIdentity.DefaultNameClaimType, email) |],now, now.AddMinutes(settings.AccessTokenLifeTimeMin), new SigningCredentials(SymmetricSecurityKey(Encoding.ASCII.GetBytes(settings.Secret)), SecurityAlgorithms.HmacSha256))
    let tokenHandler = new JwtSecurityTokenHandler()
    let encodedJwt = tokenHandler.WriteToken(token);
    encodedJwt;

let login (db: DatabaseContext) (dto: LoginDto) (settings: JwtTokenSettings): TokenDto = 
    let isUserExisting = db.Users.AsQueryable().Any(fun u -> u.Email = dto.Email)
    match isUserExisting with
    | false -> raise(Exception("Wrong email or password"))
    |true -> 
        let existingUser = db.Users.AsQueryable().First(fun u -> u.Email = dto.Email)
        let isPasswordValid = BCrypt.Verify(dto.Password, existingUser.PasswordHash)
        match isPasswordValid with
        | true -> 
            let token =  buildToken settings dto.Email
            let tokenDto: TokenDto = {
                AccessToke = token
                RefreshToken = token
            }
            tokenDto
        | false -> raise(Exception("Wrong email or password"))
            
    

