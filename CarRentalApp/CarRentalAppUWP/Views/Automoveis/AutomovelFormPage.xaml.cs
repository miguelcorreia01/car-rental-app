using CarRentalApp.Domain.Models;
using CarRentalAppUWP.ViewModels;
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
using static CarRentalApp.Domain.Models.Automovel;
using static System.Reflection.Metadata.BlobBuilder;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CarRentalAppUWP.Views.Automoveis
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AutomovelFormPage : Page
    {

        public AutomovelViewModel AutomovelViewModel { get; set; }
        public CategoriaViewModel CategoriaViewModel { get; set; }

        

        public AutomovelFormPage()
        {
            this.InitializeComponent();
            AutomovelViewModel = new AutomovelViewModel();
            AutomovelViewModel = App.AutomovelViewModel;
            CategoriaViewModel= new CategoriaViewModel();
            CategoriaViewModel = App.CategoriaViewModel;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                AutomovelViewModel = (AutomovelViewModel)e.Parameter;
            }
            base.OnNavigatedTo(e);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (AutomovelViewModel.Automovel.Id == 0)
            {
                if (AutomovelViewModel.CreateAutomovel()) 
                {
                    Frame.GoBack();
                }
                else
                {
                    FlyoutBase.ShowAttachedFlyout(sender as FrameworkElement);

                    //fazer tambem para o update nas nossas apps
                }

            }
            else
            {
                AutomovelViewModel.UpdateAutomovel();
                Frame.GoBack();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

    }
}
