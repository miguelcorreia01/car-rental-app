using CarRentalApp.Domain.Models;
using CarRentalApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalApp.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User FindByUserName(string username);

        User FindByUserNameAndPassword(string username, string password);

        User FindByNif(string nif);

        User FindByEmail(string e);

        List<User> FindByUserNameStartWith(string s);

        List<User> FindByUserNameEndWith(string s);
    }
}
