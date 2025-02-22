using CarRentalApp.Domain.Repositories;
using CarRentalApp.Domain;
using CarRentalApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalApp.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private CarRentalDbContext _dbContext;

        public ICategoriaRepository CategoriaRepository => new CategoriaRepository(_dbContext);

        public IAutomovelRepository AutomovelRepository => new AutomovelRepository(_dbContext);

        public IContratoRepository ContratoRepository => new ContratoRepository(_dbContext);

        public ILocalidadeRepository LocalidadeRepository => new LocalidadeRepository(_dbContext);

        public IUserProprietarioRepository UserProprietarioRepository => new UserProprietarioRepository(_dbContext);

        public IUserRepository UserRepository => new UserRepository(_dbContext);

        public UnitOfWork()
        {
            _dbContext = new CarRentalDbContext();
            _dbContext.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

    }
}
