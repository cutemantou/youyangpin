using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Services;
using Microsoft.Extensions.Logging;
using NETCore.Encrypt;
using WebAPI.Common;
using WebAPI.Entities;
using WebAPI.Repository;

namespace WebAPI.Services
{
	public class UserService : ServiceBase<User>, IUserService
	{
		private readonly ILogger _logger;
		private readonly IUserRepository _userRepository;
		
		public UserService(IUserRepository userRepository, ILogger<UserService> logger)
            :base(logger)
		{
			this._userRepository = userRepository;
			this._logger = logger;
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
	            inUser.Pwd = EncryptProvider.Md5(inUser.Pwd);
	            inUser.IsAdmin = false;
	            inUser.UserState = (byte)UserState.Enabled;
	            _userRepository.Add(inUser);
	            return new UserServiceResult(inUser);
	        });
	    }

        #region CRUD

        /// <summary>
        /// Update User 
        /// </summary>
        /// <param name="inUser"></param>
        /// <returns></returns>
        public UserServiceResult Update(User inUser)
		{
            return ExecuteCommand ( () =>
                                        {
                                            _userRepository.Update(inUser);                                            
                                            return new UserServiceResult();
                                        });
		}
        
		/// <summary>
		/// select all User
		/// </summary>
		/// <returns></returns>
		public IEnumerable<User> GetAll()
		{
			try
			{
				return _userRepository.GetAll();
			}
			catch(Exception ex)
			{
				_logger.LogError(ex.ToString());
			}
			return Enumerable.Empty<User>();
		}

        #endregion


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

    }
}

