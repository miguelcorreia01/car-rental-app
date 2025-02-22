﻿using CarRentalApp.Domain.Models;
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

namespace CarRentalAppUWP.Views.Proprietario
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ManageProprietarioPage : Page
    {
        public ProprietarioViewModel ProprietarioViewModel{ get; set; }

        public ManageProprietarioPage()
        {
            this.InitializeComponent();
            ProprietarioViewModel = new ProprietarioViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ProprietarioViewModel.LoadAll();
            base.OnNavigatedTo(e);
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ProprietarioFormPage));
        }

        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement fe && fe.DataContext is UserProprietario c)
            {
               ProprietarioViewModel.UserProprietario = c;
                Frame.Navigate(typeof(ProprietarioFormPage), ProprietarioViewModel);
            }
        }

        private async void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog deleteDialog = new ContentDialog
            {
                Title = "Eliminar permanentemente",
                Content = "Se você excluir este Proprietário, não poderá recuperá-lo. Você quer elimina-lo?",
                PrimaryButtonText = "Eliminar",
                SecondaryButtonText = "Cancelar"
            };

            var result = await deleteDialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                if (sender is FrameworkElement fe && fe.DataContext is UserProprietario c)
                {
                    if (c.Automoveis.Count == 0)
                    {
                        //try to delete using CategoryViewModel Method Delete
                        ProprietarioViewModel.Delete(c);
                    }
                    else
                    {
                        //If not possible, alert whit flyout
                        Flyout.ShowAttachedFlyout(fe);
                    }
                }
            }

        }
    }
}
