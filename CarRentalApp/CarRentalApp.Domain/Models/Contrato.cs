using System;
using System.Collections.Generic;
using System.Text;
using CarRentalApp.Domain.SeedWork;

namespace CarRentalApp.Domain.Models
{
    public class Contrato : Entity
    {
        public int NrDias { get; set; }

        public int NumContrato { get; set; }

        public float PrecoDia { get; set; }

        public float ValSeguro { get; set; }

        public Contrato() { ContratoAutomoveis = new List<ContratoAutomovel>(); }
        public int UserId { get; set; }

        public Contrato(int nr,float pr,float vls, int num)
        {
            NrDias = nr;
            PrecoDia = pr;
            ValSeguro = vls;
            ContratoAutomoveis = new List<ContratoAutomovel>();
            NumContrato = num;
        }

        public List<ContratoAutomovel> ContratoAutomoveis { get; set; }

        public User User { get; set; }
    }
}
