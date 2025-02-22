using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using CarRentalApp.Domain.Models;
using CarRentalAppUWP.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace CarRentalAppUWP.Views.User
{
    public sealed partial class RegisterDialog : ContentDialog
    {
        public UserViewModel UserViewModel { get; set; }

        public LocalidadeViewModel LocalidadeViewModel { get; set; }

        public RegisterDialog()
        {
            this.InitializeComponent();
            LocalidadeViewModel = App.LocalidadeViewModel;
            LocalidadeViewModel.Localidade = new Localidade();
            UserViewModel = App.UserViewModel;
            UserViewModel.User = new CarRentalApp.Domain.Models.User();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            var deferral = args.GetDeferral();
            args.Cancel = LocalidadeViewModel.CreateLocalidade() && !UserViewModel.Register();
            deferral.Complete();
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
