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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CarRentalAppUWP.Views.Categorias
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CategoriaFormPage : Page
    {
        public CategoriaViewModel CategoriaViewModel { get; set; }

        public CategoriaFormPage()
        {
            this.InitializeComponent();
            CategoriaViewModel = new CategoriaViewModel();  
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                CategoriaViewModel = (CategoriaViewModel)e.Parameter;
            }
            base.OnNavigatedTo(e);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (CategoriaViewModel.Categoria.Id == 0)
            {
                if (CategoriaViewModel.CreateCategoria())
                {
                    Frame.GoBack();
                }
                else
                {
                    FlyoutBase.ShowAttachedFlyout(sender as FrameworkElement);

                }

            }
            else
            {
                CategoriaViewModel.UpdateCategoria();
                Frame.GoBack();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
