using System.Collections.Generic;
using Infrastructure.Services;
using WebAPI.Entities;

namespace WebAPI.Services
{
    public interface IUserService : IService<User>
    {
        UserServiceResult Register(User inUser);

        UserServiceResult GetUser(string accountName, string password);
	}
}

