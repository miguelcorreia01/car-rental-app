using CarRentalApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalApp.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoriaRepository CategoriaRepository { get; }
        IAutomovelRepository AutomovelRepository { get; }
        IContratoRepository ContratoRepository { get; }
        ILocalidadeRepository LocalidadeRepository { get; }
        IUserProprietarioRepository UserProprietarioRepository { get; }
        IUserRepository UserRepository { get; } 
    }
}
