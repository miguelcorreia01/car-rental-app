using CarRentalApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CarRentalApp.Domain.Models
{
    public class Automovel : Entity
    {

        public string Matricula { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public byte[] Thumb { get; set; }

        public DateTime Ano_Fabrico { get; set; }

        public Categoria Categoria { get; set; }

        public UserProprietario Proprietario { get; set; }

        public int CategoriaId { get; set; }

        public int ProprietarioId { get; set; } 

        public Automovel() { ContratoAutomoveis = new List<ContratoAutomovel>(); }

        public List<ContratoAutomovel> ContratoAutomoveis { get; set; }

        public Automovel(string m, string mar,string mod, DateTime date,byte [] value)
        {
            Matricula = m;
            Marca = mar;
            Modelo = mod;
            Ano_Fabrico = date;
            Thumb = value;
            ContratoAutomoveis = new List<ContratoAutomovel>();
        }
   
       /* public Automovel(string matricula, string marca, string modelo, byte[] thumb, DateTime ano_Fabrico, Categoria categoria, UserProprietario proprietario, int categoriaId, int proprietarioId, List<ContratoAutomovel> contratoAutomoveis)
        {
            Matricula = matricula;
            Marca = marca;
            Modelo = modelo;
            Thumb = thumb;
            Ano_Fabrico = ano_Fabrico;
            Categoria = categoria;
            Proprietario = proprietario;
            CategoriaId = categoriaId;
            ProprietarioId = proprietarioId;
            ContratoAutomoveis = contratoAutomoveis;
        }*/

        public override string ToString()           
        {
            return Matricula;
        }

    }
}