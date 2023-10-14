using Data.Models;
using Services.ServiceModels;
using static Resources.Constants.Enums;

namespace Services.Interfaces
{
    public interface IUserService
    {
        LoginResult AuthenticateUser(string userid, string password, ref User user);
        void AddUser(UserViewModel model);
    }
}
