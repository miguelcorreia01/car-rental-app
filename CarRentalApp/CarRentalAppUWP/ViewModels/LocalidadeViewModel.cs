using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalApp.Domain;
using CarRentalApp.Domain.Models;
using CarRentalApp.Infrastructure;
using CarRentalAppUWP.ViewModels;

namespace CarRentalAppUWP.ViewModels
{
    public class LocalidadeViewModel : BindableBase
    {
        public ObservableCollection<Localidade> Localidades { get; set; }

        private Localidade _codPostal;

        public Localidade Localidade
        {
            get { return _codPostal; }
            set
            {
                _codPostal = value;
                LocalidadeName = _codPostal?.CodPostal;
            }
        }
        public string _localidadeName;
        public string LocalidadeName
        {
            get { return _localidadeName; }
            set
            {
                Set(ref _localidadeName, value);
                OnPropertyChanged(nameof(Valid));
                OnPropertyChanged(nameof(InValid));
            }
        }

        public string FormTitle
        {
            get
            {
                return Localidade.Id == 0 ? "Adicionar Localidade" : $"Editar Localidade {LocalidadeName}";
            }
        }

        public bool Valid
        {
            get
            {
                return !string.IsNullOrWhiteSpace(LocalidadeName);
            }
        }

        public bool InValid
        {
            get
            {
                return !Valid;
            }
        }

        public LocalidadeViewModel()
        {
            Localidades = new ObservableCollection<Localidade>();
            Localidade = new Localidade();
        }

        public void LoadAll()
        {
            using (var uow = new UnitOfWork())
            {
                var list = uow.LocalidadeRepository.FindAll();

                Localidades.Clear();

                foreach (var localidade in list)
                {
                    Localidades.Add(localidade);
                }
            }
        }

        internal void Delete(Localidade e)
        {
            using (var uow = new UnitOfWork())
            {
                uow.LocalidadeRepository.Delete(e);
                Localidades.Remove(e);
                uow.Save();
            }
        }

        public bool CreateLocalidade()
        {
            Localidade.CodPostal = LocalidadeName;
            using (var uow = new UnitOfWork())
            {
                //
                if (uow.LocalidadeRepository.FindByCodigoPostal(LocalidadeName) != null)
                {
                    return false;
                }
                Localidade.Local = LocalidadeName;
                uow.LocalidadeRepository.Create(Localidade);
                Localidades.Add(Localidade);
                uow.Save();
            }
            return Localidade.Id != 0;
        }

        internal void UpdateLocalidade()
        {
            Localidade.CodPostal = LocalidadeName;
            using (var uow = new UnitOfWork())
            {
                uow.LocalidadeRepository.Update(Localidade);
                Localidades.Single(x => x.Id == Localidade.Id).CodPostal = LocalidadeName;
                uow.Save();
            }
        }

    }
}
