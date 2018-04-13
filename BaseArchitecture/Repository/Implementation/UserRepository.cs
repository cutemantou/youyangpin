using System;
using System.Data;
using System.Collections.Generic;
using Architecture.Repository;
using Dapper;
using Infrastructure.Repository;
using WebAPI.Common;
using WebAPI.Entities;

namespace WebAPI.Repository
{
    /// <summary>
    /// Summary description for UserRepository.
    /// </summary>
    public class UserRepository : RepositoryBase<User>, IUserRepository
	{
        private readonly IWorkContext _workContext;

	    public UserRepository(IWorkContext workContext, IDatabaseFactory db) : base(db)
	    {
	        this._workContext = workContext;
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

