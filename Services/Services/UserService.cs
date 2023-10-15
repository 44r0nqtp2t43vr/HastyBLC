using Data;
using Data.Interfaces;
using Data.Models;
using Services.Interfaces;
using Services.Manager;
using Services.ServiceModels;
using AutoMapper;
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
                var adminRole = _dbContext.Roles.FirstOrDefault(x => x.Name == "admin");
                if (adminRole == null)
                {
                    throw new InvalidDataException(Resources.Messages.Errors.ServerError);
                }

                _mapper.Map(model, user);
                user.Role = adminRole!;
                user.Password = PasswordManager.EncryptPassword(model.Password!);
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
    }
}
