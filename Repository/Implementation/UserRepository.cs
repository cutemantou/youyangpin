using System;
using System.Collections.Generic;
using Infrastructure.Repository;
using Dapper;
using YYP.Entities;

namespace YYP.Repository
{
    /// <summary>
    /// Summary description for UserRepository.
    /// </summary>
    public class UserRepository : RepositoryBase<User>, IUserRepository
	{
	    public UserRepository(IDatabaseFactory db) : base(db)
	    {

	    }

	    public override string Add(User entity)
	    {
	        entity.GUID = Guid.NewGuid().ToString();
            entity.CreateTime = DateTime.Now;
	        Database.Execute(
                @"insert [dbo].[T_Sys_User](GUID, Account, Pwd, UserState, UserType, IsAdmin, CreateTime) 
                values (@GUID, @Account, @Pwd, @UserState, @UserType, @IsAdmin, @CreateTime)"
                , entity);
	        return entity.GUID;
	    }

	    public override IEnumerable<User> GetAll()
	    {
	        return Database.Query<User>("select * from [dbo].[T_Sys_User]");
	    }
	}
}

