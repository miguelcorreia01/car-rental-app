using System;
using System.Collections.Generic;
using System.Text;
using CarRentalApp.Domain.Models;
using CarRentalApp.Domain.Repositories;
using System.Linq;

namespace CarRentalApp.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(CarRentalDbContext dbContext) : base(dbContext)
        {
        }

        public User FindByEmail(string e)
        {
            return _dbContext.Users.SingleOrDefault(u => u.Email == e);
        }
        public List<User> FindByUserNameEndWith(string s)
        {
            return _dbContext.Users
                .Where(u => u.UserName.EndsWith(s))
                .OrderBy(u => u.UserName)
                .ToList();
        }

        public List<User> FindByUserNameStartWith(string s)
        {
            return _dbContext.Users
               .Where(u => u.UserName.StartsWith(s))
               .OrderBy(u => u.UserName)
               .ToList();
        }

        public User FindByNif(string nif)
        {
            return _dbContext.Users.SingleOrDefault(u => u.Nif == nif);
        }

        public User FindByUserName(string username)
        {
            return _dbContext.Users.SingleOrDefault(u => u.UserName == username);
        }

        public User FindByUserNameAndPassword(string username, string password)
        {
            return _dbContext.Users
                .SingleOrDefault(x => x.UserName == username && x.Password == password);
        }

        public override User FindOrCreate(User entity)
        {
            var u = FindByUserName(entity.UserName);
            if (u == null)
            {
                Create(entity);
                u = entity;
            }
            return u;
        }
    }
}
