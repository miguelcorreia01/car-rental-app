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

namespace CarRentalAppUWP.Views.Proprietario
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProprietarioFormPage : Page
    {
        public ProprietarioViewModel ProprietarioViewModel { get; set; }
        public UserViewModel UserViewModel { get; set; }

        public ProprietarioFormPage()
        {
            this.InitializeComponent();
            ProprietarioViewModel = App.ProprietarioViewModel;
            UserViewModel = App.UserViewModel;
            UserViewModel.User = new CarRentalApp.Domain.Models.User();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                ProprietarioViewModel = (ProprietarioViewModel)e.Parameter;
            }
            base.OnNavigatedTo(e);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ProprietarioViewModel.UserProprietario.Id== 0)
            {
                if (ProprietarioViewModel.CreateProprietario())
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
                ProprietarioViewModel.UpdateProprietario();
                Frame.GoBack();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
