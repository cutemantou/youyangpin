using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.DomainModel;
using Infrastructure.Services;
using Microsoft.Extensions.Logging;
using NETCore.Encrypt;
using YYP.ComLib;
using YYP.ComLib.Services;
using YYP.Entities;
using YYP.Repository;

namespace YYP.Services
{
	public class UserService : ServiceBase<User>, IUserService
	{
		private readonly ILogger _logger;
		private readonly IUserRepository _userRepository;
	    private readonly IWorkContext _workContext;


        public UserService(IUserRepository userRepository, ILogger<UserService> logger, IWorkContext workContext)
            :base(logger)
		{
			this._userRepository = userRepository;
			this._logger = logger;
		    this._workContext = workContext;

		}

	    /// <summary>
	    /// Add a new User
	    /// </summary>
	    /// <param name="inUser"></param>
	    /// <returns></returns>
	    public UserServiceResult Register(User inUser)
	    {
	        return ExecuteCommand(() =>
	        {
	            var existUserResult = GetUser(inUser.Account);
	            if (existUserResult.User != null)
	            {
                    var result = new UserServiceResult();
	                result.ViolationType = ViolationType.Validation;
                    result.RuleViolations.Add(new RuleViolation("account", "用户已存在"));
	                return result;
	            }

	            inUser.Pwd = EncryptProvider.Md5(inUser.Pwd);
	            inUser.IsAdmin = false;
	            inUser.UserState = (byte)UserState.Enabled;
	            inUser.CreatePerson = _workContext.AccountName;
	            _userRepository.Add(inUser);
	            return new UserServiceResult(inUser);
	        });
	    }

	    public UserServiceResult GetUser(string accountName, string password)
	    {
	        return ExecuteCommand(() =>
	        {
	            var encryptPassword = EncryptProvider.Md5(password);
	            var users = _userRepository.GetAll();
	            var user = users.FirstOrDefault(u => u.Account == accountName && u.Pwd == encryptPassword && u.UserState == (byte)UserState.Enabled);
                return new UserServiceResult(user);
	        });
	    }

	    private UserServiceResult GetUser(string accountName)
	    {
	        return ExecuteCommand(() =>
	        {
	            var users = _userRepository.GetAll();
	            var user = users.FirstOrDefault(u => u.Account == accountName && u.UserState == (byte)UserState.Enabled);
	            return new UserServiceResult(user);
	        });
        }

    }
}

