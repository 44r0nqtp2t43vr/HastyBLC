using Data.Models;
using Microsoft.AspNetCore.Identity;
using Services.ServiceModels;
using static Resources.Constants.Enums;

namespace Services.Interfaces
{
    public interface IUserService
    {
        LoginResult AuthenticateUser(string userid, string password, ref User user);
        void AddUser(UserViewModel model);
        IdentityUser FindUser(string userName);
        Task<IdentityUser> FindUserAsync(string userName, string password);
        Task<IdentityResult> CreateRole(string roleName);
    }
}
