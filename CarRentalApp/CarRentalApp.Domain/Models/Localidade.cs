using CarRentalApp.Domain.SeedWork;
using System.Collections.Generic;


namespace CarRentalApp.Domain.Models
{
    public class Localidade : Entity
    {
        public string CodPostal { get; set; }

        public string Local { get; set; }

        public List<User> Users { get; set; }

        public Localidade(string codPostal, string local)
        {
            CodPostal = codPostal;
            Local = local;
            Users = new List<User>();
        }

        public Localidade() { Users = new List<User>(); }

        public override string ToString()
        {
            return CodPostal;
        }
        

    }
}
