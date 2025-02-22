using CarRentalApp.Domain.SeedWork;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalApp.Infrastructure.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly CarRentalDbContext _dbContext;
        public Repository(CarRentalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public List<T> FindAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public T FindById(int Id)
        {
            return _dbContext.Set<T>().Find(Id);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }
        public abstract T FindOrCreate(T entity);
    }
}
