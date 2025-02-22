using CarRentalApp.Domain.Models;
using CarRentalApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalApp.Domain.Repositories
{
    public interface IContratoRepository : IRepository<Contrato>
    {
        Contrato FindbyPrecoDia(float price);

        Contrato FindByNrDia(int nrDia);

        Contrato FindByVlrSeguro(float vlrSeguro);

        Contrato FindByNumContrato(int numContrato);
    }
}
