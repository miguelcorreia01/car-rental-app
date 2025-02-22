using System;
using System.Collections.Generic;
using System.Text;
using CarRentalApp.Domain.Models;
using CarRentalApp.Domain.SeedWork;

namespace CarRentalApp.Domain.Repositories
{
    public interface IUserProprietarioRepository : IRepository<UserProprietario>
    {
        UserProprietario FindByName(string name);
        List<UserProprietario> FindByNameStartWith(string s);
    }
}
