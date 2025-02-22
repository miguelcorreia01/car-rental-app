using System;
using CarRentalApp.Domain.Models;
using CarRentalApp.Infrastructure;

namespace CarRentalAppConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(var uow = new UnitOfWork())
            {

                var prop1 = new UserProprietario("João", 30);

                var auto1 = new Automovel
                {
                    Matricula = "82-OM-21",
                    Thumb = new byte[0],
                    Modelo = "Corsa",
                    Marca = "Opel",
                    Ano_Fabrico = DateTime.Now,
                    Proprietario=prop1
                };
                var auto2 = new Automovel
                {
                    Matricula = "22-UN-10",
                    Thumb = new byte[1],
                    Modelo = "Dase",
                    Marca = "Auto",
                    Ano_Fabrico = DateTime.Now,
                    Proprietario = prop1
                };

                var us1 = new User
                {
                    UserName = "Santos",
                    Password = "Nada",
                    Nif = " 2514572135",
                    Email = "Joaosantos@gmail.com",
                    Proprietario=prop1
                };
                var us2 = new User
                {
                    UserName= "Gomes",
                    Password="Boas",
                    Nif="289876521",
                    Email= "Ricardogomes@gmail.com"
                };
                var cont1 = new Contrato
                {
                    NrDias = 4,
                    NumContrato = 1,
                    PrecoDia=20,
                    ValSeguro=1,
                };
                var cont2 = new Contrato
                {
                    NrDias = 1,
                    NumContrato = 2,
                    PrecoDia = 5,
                    ValSeguro = 1,
                };


                var cat1= new Categoria("Desportivo!");

                var loc1 = new Localidade("4123-193", "Viseu");

                
                loc1.Users.Add(us1);
                loc1.Users.Add(us2);
                cat1.Automoveis.Add(auto1);
                cat1.Automoveis.Add(auto2);
                us1.Contratos.Add(cont1);
                us1.Contratos.Add(cont2);

                uow.LocalidadeRepository.Create(loc1);
                uow.CategoriaRepository.Create(cat1);
                uow.UserRepository.Create(us1);

                uow.Save();

                var proprietario = uow.UserRepository.FindByUserName("Joao");
                var localidadeList = uow.LocalidadeRepository.FindAll();
                var categoriaList = uow.CategoriaRepository.FindAll();
                var userList = uow.UserRepository.FindAll();
                var userfind = uow.UserRepository.FindByNif("289876521");


                foreach (var user in userList)
                {
                    Console.WriteLine($"{user.Email} - Nif: {user.Nif}");
                    foreach (var contratos in user.Contratos)
                    {
                        Console.WriteLine($"{contratos.Id}ºContrato - Automoveis(preco): {contratos.PrecoDia} ");
                    }
                }

                foreach (var categoria in categoriaList)
                {
                    Console.WriteLine($"{categoria.Id} - Categoria: {categoria.Name}");
                    foreach (var automoveis in categoria.Automoveis)
                    {
                        Console.WriteLine($"{automoveis.Id} - Automoveis: {automoveis.Matricula} ");
                    }
                }


                foreach (var localidade in localidadeList)
                {
                    Console.WriteLine($"{localidade.Id} - Localidade: {localidade.Local}");
                    foreach (var user in localidade.Users)
                    {
                        Console.WriteLine($"{user.Id} - User: {user.UserName} ");
                    }
                }
                Console.WriteLine($"{proprietario.Id}: Proprietario:{proprietario.UserName} ");
                Console.WriteLine($"{userfind.Id}: Proprietario:{userfind.Nif} ");

                uow.ContratoRepository.Delete(cont1);
                uow.ContratoRepository.Delete(cont2);
                uow.AutomovelRepository.Delete(auto1);
                uow.AutomovelRepository.Delete(auto2);
                uow.CategoriaRepository.Delete(cat1);
                uow.UserRepository.Delete(us1);
                uow.UserRepository.Delete(us2);
                uow.LocalidadeRepository.Delete(loc1);


            }
        }
    }
}
