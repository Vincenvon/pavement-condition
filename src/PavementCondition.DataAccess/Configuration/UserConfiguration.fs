namespace PavementCondition.DataAccess.Configuration

open Microsoft.EntityFrameworkCore
open Microsoft.EntityFrameworkCore.Metadata.Builders
open PavementCondition.Entity


type UserConfiguration = 
    interface IEntityTypeConfiguration<User> with
        member this.Configure(builder: EntityTypeBuilder<User>): unit = 
            builder.HasKey("Id")
            |> ignore

