using CarRentalApp.Domain.Models;
using CarRentalApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRentalApp.Infrastructure.Repositories
{
    public class LocalidadeRepository : Repository<Localidade>, ILocalidadeRepository
    {
        public LocalidadeRepository(CarRentalDbContext dbContext) : base(dbContext)
        {
        }

        public Localidade FindByCodigoPostal(string codPostal)
        {
            return _dbContext.Localidades.SingleOrDefault(cp => cp.CodPostal == codPostal); //retorna o único elemento que satisfaz a condição
        }  

        public Localidade FindByName(string local)
        {
            return _dbContext.Localidades.SingleOrDefault(l => l.Local == local);  
        }

        public List<Localidade> FindByNameEndWith(string s)
        {
            return _dbContext.Localidades.Where(l => l.Local.EndsWith(s)).OrderBy(l => l.Local).ToList();
        }

        public List<Localidade> FindByNameStartWith(string s)
        {
            return _dbContext.Localidades.Where(l => l.Local.StartsWith(s)).OrderBy(l => l.Local).ToList();
        }

        public override Localidade FindOrCreate(Localidade entity)
        {
            var l = FindByCodigoPostal(entity.CodPostal);
            if (l == null)
            {
                Create(entity);
                l = entity;
            }
            return l;
        }
    }
}
