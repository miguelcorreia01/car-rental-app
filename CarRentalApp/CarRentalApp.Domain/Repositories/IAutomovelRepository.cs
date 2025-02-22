using CarRentalApp.Domain.Models;
using CarRentalApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalApp.Domain.Repositories
{
    public interface IAutomovelRepository : IRepository <Automovel>
    {
        Automovel FindByMatricula(string matricula);

        Automovel FindByMarca(string marca);

    }
}
