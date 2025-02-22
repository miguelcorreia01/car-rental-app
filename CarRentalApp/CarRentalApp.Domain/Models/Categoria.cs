using CarRentalApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace CarRentalApp.Domain.Models
{
    public class Categoria : Entity
    {
        public string Name { get; set; }

        public List<Automovel> Automoveis { get; set; }

        public Categoria(string name)
        {
            Name = name;
            Automoveis = new List<Automovel>();
        }

        public Categoria() { Automoveis = new List<Automovel>(); }
        public override string ToString()
        {
            return Name;
        }
    }

   
}
