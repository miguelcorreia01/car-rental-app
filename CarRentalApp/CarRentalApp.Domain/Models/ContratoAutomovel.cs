using System;
using System.Collections.Generic;
using System.Text;
using CarRentalApp.Domain.SeedWork;

namespace CarRentalApp.Domain.Models
{
    public class ContratoAutomovel: Entity
    {
        public int ContratoId  { get; set; }
        public Contrato Contrato  { get; set; }
        public Automovel Automovel { get; set; }
        public int AutomovelId { get; set; }
    }
}
