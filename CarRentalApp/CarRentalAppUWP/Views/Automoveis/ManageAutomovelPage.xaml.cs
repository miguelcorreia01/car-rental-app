using CarRentalApp.Domain.Models;
using CarRentalAppUWP.ViewModels;
using CarRentalAppUWP.Views.Categorias;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CarRentalAppUWP.Views.Automoveis
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ManageAutomovelPage : Page
    {
        public AutomovelViewModel AutomovelViewModel { get; set; }

        public ManageAutomovelPage()
        {
            this.InitializeComponent();
            AutomovelViewModel = new AutomovelViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            AutomovelViewModel.LoadAll();
            base.OnNavigatedTo(e);
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AutomovelFormPage));
        }

        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement fe && fe.DataContext is Automovel c)
            {
                AutomovelViewModel.Automovel = c;
                Frame.Navigate(typeof(AutomovelFormPage), AutomovelViewModel);
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
