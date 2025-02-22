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
    public class ProprietarioViewModel : BindableBase
    {

        public ObservableCollection<UserProprietario> Proprietarios { get; set; }

        private UserProprietario _proprietario;

        public UserProprietario UserProprietario
        {
            get { return _proprietario; }
            set
            {
                _proprietario = value;
                ProprietarioName = _proprietario?.Name;
            }
        }
        private string _proprietarioName;

        public string ProprietarioName
        {
            get { return _proprietarioName; }
            set
            {
                Set(ref _proprietarioName, value);
                //trigger ke perrmite atualizar props se não for atualizada
                OnPropertyChanged(nameof(Valid));
                OnPropertyChanged(nameof(InValid));
            }
        }

        public string _proprietarioId;
        public string ProprietarioId
        {
            get { return _proprietarioId; }
            set { 
                Set(ref _proprietarioId, value);
                OnPropertyChanged(nameof(ValidId));
                OnPropertyChanged(nameof(InValidId));
            }
        }

        public bool ValidId
        {
            get{ return !string.IsNullOrWhiteSpace(ProprietarioId); }
        }

        public bool InValidId{ get { return !ValidId; }}

        public string FormTitle
        {
            get
            {
                return UserProprietario.Id == 0 ? "Adicionar Usuário" : $"Edite UserProprietario {ProprietarioName}";
            }
        }
        public bool Valid
        {
            get
            {
                return !string.IsNullOrWhiteSpace(ProprietarioName);
            }
        }
        public bool InValid
        {
            get
            {
                return !Valid;
            }
        }

        public ProprietarioViewModel()
        {
            Proprietarios = new ObservableCollection<UserProprietario>();
            UserProprietario = new UserProprietario();
        }
        public void LoadAll()
        {
            using (var uow = new UnitOfWork())
            {
                var list = uow.UserProprietarioRepository.FindAll();

                Proprietarios.Clear();

                foreach (var proprietario in list)
                {
                    Proprietarios.Add(proprietario);
                }
            }
        }

        internal void Delete(UserProprietario e)
        {
            using (var uow = new UnitOfWork())
            {
                uow.UserProprietarioRepository.Delete(e);
                Proprietarios.Remove(e);
                uow.Save();
            }
        }

        internal bool CreateProprietario()
        {
            UserProprietario.Name = ProprietarioName;
            using(var uow = new UnitOfWork())
            {
                if(uow.UserProprietarioRepository.FindByName(ProprietarioName) != null)
                {
                    return false;
                }
                uow.UserProprietarioRepository.Create(UserProprietario);
                Proprietarios.Add(UserProprietario);
                uow.Save();
            }
            return UserProprietario.Id != 0;
        }

        internal void UpdateProprietario()
        {
            UserProprietario.Name = ProprietarioName;
            using (var uow = new UnitOfWork())
            {
                uow.UserProprietarioRepository.Update(UserProprietario);
                Proprietarios.Single(x => x.Id == UserProprietario.Id).Name = ProprietarioName;
                uow.Save();
            }
        }
    }
}
