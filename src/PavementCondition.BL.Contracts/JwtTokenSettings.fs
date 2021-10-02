namespace PavementCondition.BL.Contracts

[<CLIMutable>]
type JwtTokenSettings = {
    Secret: string
    AccessTokenLifeTimeMin: float
    RefreshTokenLifeTimeDays: float
    Issuer: string
    Audience: string
}



