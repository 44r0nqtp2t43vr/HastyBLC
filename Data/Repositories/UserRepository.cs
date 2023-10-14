using Data.Interfaces;
using Data.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public IQueryable<User> GetUsers()
        {
            return this.GetDbSet<User>();
        }

        public bool UserExists(string userId)
        {
            return this.GetDbSet<User>().Any(x => x.Email == userId);
        }

        public void AddUser(User user)
        {
            this.GetDbSet<User>().Add(user);
            UnitOfWork.SaveChanges();
        }

    }
}
