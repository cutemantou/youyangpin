using Infrastructure.Services;
using YYP.Entities;

namespace YYP.Services
{
    public interface IUserService : IService<User>
    {
        UserServiceResult Register(User inUser);

        UserServiceResult GetUser(string accountName, string password);
	}
}

