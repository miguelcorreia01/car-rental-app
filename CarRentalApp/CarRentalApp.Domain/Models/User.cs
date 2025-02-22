using CarRentalApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CarRentalApp.Domain.Models
{
    public class User: Entity
    {
        public string UserName { get; set; }

        private string _password;

        public string Email { get; set; }

        public string Nif { get; set; }

        public bool IsAdmin { get; set; }

        public int LocalidadeId { get; set; }

        public Localidade Localidade { get; set; }

        public UserProprietario Proprietario { get; set; }

        public List<Contrato> Contratos { get; set; }
        public User() { Contratos = new List<Contrato>(); }

        public User(string us,string ni, string em)
        {
            UserName = us;
            Nif = ni;
            Email = em;
            Contratos = new List<Contrato>();
        }
        public string Password
        {
            get { return _password; }
            set
            {
                var data = Encoding.UTF8.GetBytes(value);
                var hasData = new SHA1Managed().ComputeHash(data);
                _password = BitConverter.ToString(hasData)
                    .Replace("-", "").ToUpper();
            }
        }
        public override string ToString()
        {
            return UserName;
        }
    }
}