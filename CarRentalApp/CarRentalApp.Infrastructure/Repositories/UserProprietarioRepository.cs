using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarRentalApp.Domain.Models;
using CarRentalApp.Domain.Repositories;

namespace CarRentalApp.Infrastructure.Repositories
{
    public class UserProprietarioRepository : Repository<UserProprietario>, IUserProprietarioRepository
    {
        public UserProprietarioRepository(CarRentalDbContext dbContext) : base(dbContext)
        {
        }

        public UserProprietario FindByName(string name)
        {
            return _dbContext.Proprietarios.SingleOrDefault(u => u.Name == name);
        }

        public List<UserProprietario> FindByNameStartWith(string s)
        {
            return _dbContext.Proprietarios
               .Where(u => u.Name.StartsWith(s))
               .OrderBy(u=> u.Name)
               .ToList();
        }
        public override UserProprietario FindOrCreate(UserProprietario entity)
        {
            var u = FindByName(entity.Name);
            if (u == null)
            {
                Create(entity);
                u = entity;
            }
            return u;
        }
    }
}
