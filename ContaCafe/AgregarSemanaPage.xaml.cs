using ContaCafe.Models;
using ContaCafe.Parse;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ContaCafe
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AgregarSemanaPage : Page
    {
        SemanaParse semanaParse;
        Semana semana;
        bool nuevo = false;
        Frame rootFrame = Window.Current.Content as Frame;

        public AgregarSemanaPage()
        {
            this.InitializeComponent();
            semanaParse = new SemanaParse();
            //semana = new Semana();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += AgregarSemanaPage_BackRequested;
        }

        private void AgregarSemanaPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (e.Handled == false)
            {
                e.Handled = true;
                rootFrame.GoBack();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            semana = e.Parameter as Semana;
            if (semana != null)
            {
                nuevo = true;
                txtNombreSemana.Text = semana.NombreSemana;
                
            }
            else
            {
                nuevo = false;
            }
        }


        private void insertSemana(object sender, RoutedEventArgs e)
        {
            string nombreSemana = txtNombreSemana.Text;

            if (nuevo == false)
            {
                Semana semananuevo = new Semana(nombreSemana);
                semanaParse.insertSemana(semananuevo);
            }
            else
            {
                semana.IdSemana = semana.IdSemana;
                semana.NombreSemana = nombreSemana;

                semanaParse.updateSemana(semana);
                nuevo = false;
            }
            rootFrame.Navigate(typeof(ListaSemanaPage));

        }


    }
}
