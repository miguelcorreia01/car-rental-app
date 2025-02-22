using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using CarRentalAppUWP.ViewModels;
using CarRentalAppUWP.Views.Automoveis;
using CarRentalAppUWP.Views.Categorias;
using CarRentalAppUWP.Views.Proprietario;
using CarRentalAppUWP.Views.User;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CarRentalAppUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public UserViewModel UserViewModel { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            UserViewModel = new UserViewModel();
        }
        public Frame AppFrame => MainFrame;

        public Frame MainFrame { get; private set; }

        private async void MainNavigation_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var selectedItem = args.InvokedItemContainer as NavigationViewItem;

            if (selectedItem != null)
            {
                switch (selectedItem.Tag)
                {
                    case "NavCategoria":
                        AppFrame.Navigate(typeof(ManageCategoriaPage));
                        break;
                    case "NavProprietario":
                        AppFrame.Navigate(typeof(ManageProprietarioPage));
                        break ;
                    case "NavAutomoveis":
                        AppFrame.Navigate(typeof(ManageAutomovelPage));
                        break;
                }
            }

        }



        private async void NavLogin_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var dialog = new LoginDialog();
            var res = await dialog.ShowAsync();
            if (res == ContentDialogResult.Primary)
            {
                if (App.UserViewModel.IsLogged)
                {
                    AppFrame.Navigate(typeof(ManageCategoriaPage));
                }
            }
        }

        private async void NavRegister_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var dialog = new RegisterDialog();
            var res = await dialog.ShowAsync();
            if (res == ContentDialogResult.Primary)
            {
                if (App.UserViewModel.IsLogged)
                {
                    AppFrame.Navigate(typeof(ManageCategoriaPage));
                }
            }
        }

        private void NavLogout_Tapped(object sender, TappedRoutedEventArgs e)
        {
            UserViewModel.DoLogout();
            AppFrame.BackStack.Clear();
            AppFrame.Content = null;
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
