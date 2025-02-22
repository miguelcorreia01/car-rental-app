using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class LoginDialog : ContentDialog
    {
        public UserViewModel UserViewModel { get; set; }
        public LoginDialog()
        {
            this.InitializeComponent();
            UserViewModel = App.UserViewModel;
            UserViewModel.User = new CarRentalApp.Domain.Models.User();
            UserViewModel.ShowError = false;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            var deferral = args.GetDeferral();
            args.Cancel = !UserViewModel.DoLogin();
            deferral.Complete();
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
