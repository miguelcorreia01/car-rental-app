using CarRentalApp.Domain.Models;
using CarRentalApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace CarRentalApp.Infrastructure.Repositories
{
    public class ContratoRepository : Repository<Contrato>, IContratoRepository
    {
        public ContratoRepository(CarRentalDbContext dbContext) : base(dbContext)
        {
        }

        public Contrato FindByNrDia(int nrDia)
        {
            return _dbContext.Contratos.SingleOrDefault(nd => nd.NrDias == nrDia);
        }

        public Contrato FindByNumContrato(int numContrato)
        {
            return _dbContext.Contratos.SingleOrDefault(num => num.NumContrato == numContrato);
        }

        public Contrato FindbyPrecoDia(float price)
        {
            return _dbContext.Contratos.SingleOrDefault(p => p.PrecoDia == price);
        }

        public Contrato FindByVlrSeguro(float vlrSeguro)
        {
            return _dbContext.Contratos.SingleOrDefault(vlr => vlr.ValSeguro == vlrSeguro);
        }

        public override Contrato FindOrCreate(Contrato entity)
        {
            var c = FindById(entity.Id);
            if (c == null)
            {
                Create(entity);
                c = entity;
            }
            return c;
        }
    }
}
