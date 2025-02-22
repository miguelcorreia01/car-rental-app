using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalApp.Domain.Models;
using CarRentalApp.Domain.Repositories;
using CarRentalApp.Infrastructure;

namespace CarRentalAppUWP.ViewModels
{
    public class UserViewModel : BindableBase
    {
        public User User { get; set; }
        
        public Localidade Localidades { get ; set; }

        private User _loggedUser;
        public User LoggedUser
        {
            get { return _loggedUser; }
            set
            {
                _loggedUser = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(IsLogged));
                OnPropertyChanged(nameof(isNotLogged));
                OnPropertyChanged(nameof(IsAdmin));

            }
        }
        public bool IsLogged
        {
            get => _loggedUser != null;
        }

        public bool isNotLogged
        {
            get => !IsLogged;
        }
        public bool IsAdmin
        {
            get => LoggedUser != null && LoggedUser.IsAdmin;
        }

        private bool _showError;

        public bool ShowError
        {
            get { return _showError; }
            set
            {
                _showError = value;
                OnPropertyChanged();
            }
        }

        public UserViewModel()
        {
            User = new User();
        }
        internal bool DoLogin()
        {
            using (var uow = new UnitOfWork())
            {
                var user = uow.UserRepository
                    .FindByUserNameAndPassword(User.UserName, User.Password);

                LoggedUser = user;
                ShowError = user == null;
                return user != null;
            }
        }
        internal void DoLogout()
        {
            LoggedUser = null;
        }
        public string _localidadeCod;
        public string LocalidadeCod
        {
            get { return _localidadeCod; }
            set
            {
                Set(ref _localidadeCod, value);
            }
        }

        internal bool Register()
        {
            //us1.Contratos.Add(cont2);
   
            var res = false;
            using (var uow = new UnitOfWork())
            {
                var localidade = uow.LocalidadeRepository.FindByName(LocalidadeCod);
                var user = uow.UserRepository.FindByUserName(User.UserName);
                if (user == null)
                {
                    uow.UserRepository.Create(User);
                    localidade.Users.Add(User);
                    
                    uow.Save();
                    LoggedUser = User;
                    res = true;
                }
                return res;
            }
        }
  

    }
}
