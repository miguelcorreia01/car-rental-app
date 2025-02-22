using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CarRentalApp.Domain.Models;
using CarRentalApp.Domain.Repositories;
using System.Linq;

namespace CarRentalApp.Infrastructure.Repositories
{
    class AutomovelRepository : Repository<Automovel>, IAutomovelRepository
    {
        public AutomovelRepository(CarRentalDbContext dbContext) : base(dbContext)
        {}

        public Automovel FindByMarca(string marca)
        {
            return _dbContext.Automoveis.SingleOrDefault(a => a.Marca == marca);  
        }

        public Automovel FindByMatricula(string matricula)
        {
            return _dbContext.Automoveis.SingleOrDefault(a => a.Matricula == matricula);
        }

        public override Automovel FindOrCreate(Automovel entity)
        {
            var a = FindByMatricula(entity.Matricula);
            if( a == null)
            {
                Create(entity);
                a = entity;
            }
            return a;
        }
    }
}
