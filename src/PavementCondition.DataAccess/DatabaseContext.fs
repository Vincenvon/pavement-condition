namespace PavementCondition.DataAccess

open Microsoft.EntityFrameworkCore
open PavementCondition.Entity
open System.Reflection

type DatabaseContext(options: DbContextOptions<DatabaseContext>) =
    inherit DbContext(options)

    [<DefaultValue>]
    val mutable users : DbSet<User>

    member public this.Users with get() = this.users
                               and set p = this.users <- p
    
    override __.OnModelCreating(modelBuilder : ModelBuilder) =
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof<DatabaseContext>))
        |> ignore
