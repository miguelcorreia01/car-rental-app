using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalApp.Domain.SeedWork
{
    public interface IRepository<T> where T : Entity
    {
        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        T FindById(int id);

        List<T> FindAll();
    }
}
