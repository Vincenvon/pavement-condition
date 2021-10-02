namespace PavementCondition.API.Controllers

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open PavementCondition.API.Contracts.Accounts
open PavementCondition.BL.Accounts
open PavementCondition.BL.Contracts.Accounts
open PavementCondition.DataAccess
open PavementCondition.BL.Contracts
open Microsoft.Extensions.Options

[<ApiController>]
[<Route("[controller]")>]
type AccountsController (logger : ILogger<AccountsController>, ctx : DatabaseContext, jwtSettings: IOptions<JwtTokenSettings>) =
    inherit ControllerBase()

    [<HttpPost>]
    member _.Register([<FromBody>]model: RegisterRequest) =
        let createDto: CreateDto = {
            Email = model.Email
            FirstName = model.FirstName
            LastName = model.LastName
            Username = model.Username
            Password = model.Password
        }
        let mapToResponse (dto: UserDto) : RegisterResponse =
            let response: RegisterResponse = {
                Id= dto.Id
                Email= dto.Email
                FirstName= dto.FirstName
                LastName= dto.LastName
                Username= dto.Username
            }
            response
        create ctx createDto
        |> mapToResponse

    [<HttpPost("login")>]
    member _.Login([<FromBody>]model: LoginRequest) =
        let loginDto: LoginDto = {
            Email = model.Email
            Password = model.Password
        }
        let mapToResponse (dto: TokenDto) : LoginResponse =
            let response: LoginResponse = {
                Token = dto.AccessToke
            }
            response
        login ctx loginDto jwtSettings.Value
        |> mapToResponse
        