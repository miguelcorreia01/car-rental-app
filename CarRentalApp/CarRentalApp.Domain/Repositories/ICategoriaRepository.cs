using CarRentalApp.Domain.Models;
using CarRentalApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalApp.Domain.Repositories
{
    public interface ICategoriaRepository : IRepository<Categoria>    {
      
        Categoria  FindByName(string name);     

        List<Categoria> FindByNameStartWith(string s);   
   
        
    }
}
