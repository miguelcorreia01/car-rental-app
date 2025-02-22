using CarRentalApp.Domain.Models;
using CarRentalApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalApp.Domain.Repositories
{
    public interface ILocalidadeRepository : IRepository<Localidade>{

        Localidade FindByName(string Local);

        Localidade FindByCodigoPostal(string CodPostal);

        List<Localidade> FindByNameStartWith(string s);

        List<Localidade> FindByNameEndWith(string s);
    }
}
