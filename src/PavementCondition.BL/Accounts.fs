module Accounts

open PavementCondition.DataAccess
open PavementCondition.BL.Contracts.Accounts

let create (db: DatabaseContext) (dto: CreateDto) :UserDto = 
    let existingUser = db.Users.AsQueryable().Where(fun u -> u.)