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
    public class AutomovelViewModel : BindableBase
    {
        public ObservableCollection<Automovel> Automoveis { get; set; }

        private Automovel _automovel;
        public Automovel Automovel
        {
            get { return _automovel; }
            set
            {
                _automovel = value;
                AutomovelMatricula = _automovel?.Matricula;
            }
        }

        private string _automovelMatricula;
        public string AutomovelMatricula
        {
            get { return _automovelMatricula; }
            set
            {
                Set(ref _automovelMatricula, value);
                OnPropertyChanged(nameof(Valid));
                OnPropertyChanged(nameof(InValid));
            }
        }

        public string FormTitle
        {
            get
            {
                return Automovel.Id == 0 ? "Adicionar Automovel" : $"Editar Automovel {AutomovelMatricula}";
            }
        }

        public bool Valid {
            get { return !string.IsNullOrWhiteSpace(AutomovelMatricula); }
        }

        public bool InValid {
            get { return !Valid; }
        }

        public AutomovelViewModel()
        {
            Automoveis = new ObservableCollection<Automovel>();
            Automovel = new Automovel();
        }

        public void LoadAll()
        {
            using (var uow = new UnitOfWork())
            {
                var list = uow.AutomovelRepository.FindAll();

                Automoveis.Clear();

                foreach (var automovel in list)
                {
                    Automoveis.Add(automovel);
                }
            }
        }

        internal void Delete(Automovel e)
        {
            using (var uow = new UnitOfWork())
            {
                uow.AutomovelRepository.Delete(e);
                Automoveis.Remove(e);
                uow.Save();
            }
        }

        internal bool CreateAutomovel()
        {
            Automovel.Matricula = AutomovelMatricula;
            using (var uow = new UnitOfWork())
            {
                //
                if (uow.CategoriaRepository.FindByName(AutomovelMatricula) != null)
                {
                    return false;
                }
                uow.AutomovelRepository.Create(Automovel);
                Automoveis.Add(Automovel);
                uow.Save();
            }
            return Automovel.Id != 0;
        }

        internal void UpdateAutomovel()
        {
            Automovel.Matricula = AutomovelMatricula;
            using (var uow = new UnitOfWork())
            {
                uow.AutomovelRepository.Update(Automovel);
                Automoveis.Single(x => x.Id == Automovel.Id).Matricula = AutomovelMatricula;
                uow.Save();
            }
        }
    }
}
