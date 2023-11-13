using Data;
using Data.Interfaces;
using Data.Models;
using Services.Interfaces;
using Services.Manager;
using Services.ServiceModels;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.IO;
using System.Linq;
using static Resources.Constants.Enums;


namespace Services.Services
{
    public class UserService : IUserService
    {
        private readonly HastyDBContext _dbContext;
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper, HastyDBContext dbContext)
        {
            _mapper = mapper;
            _repository = repository;
            _dbContext = dbContext;
        }

        public LoginResult AuthenticateUser(string userId, string password, ref User user)
        {
            user = new User();
            var passwordKey = PasswordManager.EncryptPassword(password);
            user = _repository.GetUsers().Where(x => x.Email == userId &&
                                                     x.Password == passwordKey).FirstOrDefault()!;

            return user != null ? LoginResult.Success : LoginResult.Failed;
        }

        public void AddUser(UserViewModel model)
        {
            var user = new User();
            if (!_repository.UserExists(model.Email!))
            {
                _mapper.Map(model, user);
                /*user.Password = PasswordManager.EncryptPassword(model.Password!);*/
                user.CreatedTime = DateTime.Now;
                user.UpdatedTime = DateTime.Now;
                user.CreatedBy = System.Environment.UserName;
                user.UpdatedBy = System.Environment.UserName;

                _repository.AddUser(user);
            }
            else
            {
                throw new InvalidDataException(Resources.Messages.Errors.UserExists);
            }
        }

        public Task<IdentityUser> FindUserAsync(string userName, string password)
        {
            return _repository.FindUserAsync(userName, password);
        }

        public IdentityUser FindUser(string userName)
        {
            return _repository.FindUser(userName);
        }

        public IdentityUser FindUserByEmail(string email)
        {
            return _repository.FindUserByEmail(email);
        }

        public async Task<IdentityResult> CreateRole(string roleName)
        {
            return await _repository.CreateRole(roleName);
        }
    }
}
