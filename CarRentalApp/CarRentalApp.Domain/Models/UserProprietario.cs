using System;
using System.Collections.Generic;
using System.Text;
using CarRentalApp.Domain.SeedWork;

namespace CarRentalApp.Domain.Models
{
    public class UserProprietario: Entity
    {
        public string Name { get; set; } 
        public float Cota { get; set; }
        public User User { get; set; }
        public List<Automovel> Automoveis { get; set; }
        public UserProprietario(string n,float c )
        {
            Name = n;
            Cota = c;
            Automoveis = new List<Automovel>();

        }
        public UserProprietario(){ Automoveis = new List<Automovel>(); }
        public override string ToString()
        {
            return Name;
        }
        public int UserId { get; set; }


    }
}
