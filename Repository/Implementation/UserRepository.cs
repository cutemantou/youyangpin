using System;
using System.Collections.Generic;
using System.Data;
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
	        Database.Execute("dbo.Usp_T_Sys_User_Insert",
	            new
	            {
	                entity.GUID,
	                entity.Account,
	                entity.Pwd,
	                entity.UserState,
	                entity.UserType,
	                entity.TrueName,
	                entity.DepartmentGuid,
	                entity.PositionGuid,
	                entity.CreatePerson,
	                entity.CreateTime,
                    entity.ExpirationDate,
	                entity.QQ,
	                entity.IsAdmin,
	                entity.TelPhone,
	                entity.QQGroup,
	                entity.ReturnInfo,
	                entity.CityName,
	                entity.ProvinceName,
	                entity.Email,
	                entity.Gender,
	                entity.ZFBAccount
	            }, commandType: CommandType.StoredProcedure);
	        return entity.GUID;
	    }

        public override void Update(User entity)
        {
            entity.UpdateTime = DateTime.Now;
            Database.Execute("dbo.Usp_T_Sys_User_Update",
                new
                {
                    entity.GUID,
                    entity.Account,
                    entity.Pwd,
                    entity.UserState,
                    entity.UserType,
                    entity.TrueName,
                    entity.DepartmentGuid,
                    entity.PositionGuid,
                    entity.LastLoginTime,
                    entity.LastLoginIP,
                    entity.LoginTimes,
                    entity.LoginErrorTimes,
                    entity.ExpirationDate,
                    entity.QQ,
                    entity.IsAdmin,
                    entity.TelPhone,
                    entity.QQGroup,
                    entity.ReturnInfo,
                    entity.CityName,
                    entity.ProvinceName,
                    entity.Email,
                    entity.Gender,
                    entity.ZFBAccount,
                    entity.UpdateTime
                }, commandType: CommandType.StoredProcedure);
        }

        public override User GetById(string id)
        {
            return Database.QueryFirstOrDefault<User>("dbo.Usp_T_Sys_User_Select", new { GUID = id }, commandType: CommandType.StoredProcedure);
        }

        public override IEnumerable<User> GetAll()
	    {
	        return Database.Query<User>("dbo.Usp_T_Sys_User_SelectAll", commandType: CommandType.StoredProcedure);
	    }
	}
}

