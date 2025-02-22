using CarRentalApp.Domain;
using CarRentalApp.Domain.Models;
using CarRentalApp.Infrastructure;
using CarRentalAppUWP.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalAppUWP.ViewModels
{
    public class CategoriaViewModel : BindableBase
    {
        public ObservableCollection<Categoria> Categorias { get; set; }

        private Categoria _categoria;
        public Categoria Categoria
        {
            get { return _categoria; }
            set
            { 
                _categoria = value;
                CategoriaName = _categoria?.Name;
            }
        }

        private string _categoriaName;
        public string CategoriaName
        {
            get { return _categoriaName; }
            set
            {
                Set(ref _categoriaName, value);
                OnPropertyChanged(nameof(Valid));
                OnPropertyChanged(nameof(InValid));
            }
        }

        public string FormTitle
        {
            get
            {
                return Categoria.Id == 0 ? "Adicionar Categoria" : $"Editar Categoria {CategoriaName}";
            }
        }

        //criar atre
        public bool Valid
        {
            get
            {
                return !string.IsNullOrWhiteSpace(CategoriaName);
            }
        }

        public bool InValid
        {
            get
            {
                return !Valid;
            }
        }

        public CategoriaViewModel()
        {
            Categorias = new ObservableCollection<Categoria>();
            Categoria = new Categoria();
        }

        public void LoadAll()
        {
            using(var uow = new UnitOfWork())
            {
                var list = uow.CategoriaRepository.FindAll();

                Categorias.Clear();

                foreach (var categoria in list)
                {
                    Categorias.Add(categoria);
                }
            }
        }

        //eliminamos a BD
        internal void Delete(Categoria e)
        {
            using (var uow = new UnitOfWork())
            {
                uow.CategoriaRepository.Delete(e);
                Categorias.Remove(e);
                uow.Save();
            }
        }

        internal bool CreateCategoria()
        {
            Categoria.Name = CategoriaName;
            using(var uow = new UnitOfWork())
            {
                //
                if(uow.CategoriaRepository.FindByName(CategoriaName) != null)
                {
                    return false;
                }
                uow.CategoriaRepository.Create(Categoria);
                Categorias.Add(Categoria);
                uow.Save();
            }
            return Categoria.Id!=0;
        }

        internal void UpdateCategoria()
        {
            Categoria.Name = CategoriaName;
            using(var uow = new UnitOfWork())
            {
                uow.CategoriaRepository.Update(Categoria);
                Categorias.Single(x => x.Id == Categoria.Id).Name = CategoriaName;
                uow.Save();
            }
        }
    }
}
