using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CarRentalApp.Domain.Models;
using CarRentalApp.Domain.Repositories;
using System.Linq;


namespace CarRentalApp.Infrastructure.Repositories
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(CarRentalDbContext dbContext) : base(dbContext)
        {

        }

        public Categoria FindByName(string n)
        {
            return _dbContext.Categorias.SingleOrDefault(c => c.Name == n);
        }

        public List<Categoria> FindByNameStartWith(string s)
        {
            return _dbContext.Categorias.Where(c => c.Name.StartsWith(s)).OrderBy(c => c.Name).ToList();
        }

        public override Categoria FindOrCreate(Categoria entity)
        {
            var c = FindByName(entity.Name);
            if(c == null)
            {
                Create(entity);
                c = entity;
            }
            return c;
        }
    }
}
