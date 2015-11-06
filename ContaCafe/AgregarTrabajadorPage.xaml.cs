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
    public sealed partial class AgregarTrabajadorPage : Page
    {
        TrabajadorParse trabajadorParse;
        Trabajador trabajador;
        bool nuevo = false;
        Frame rootFrame = Window.Current.Content as Frame;
        string idTraNov;

        public AgregarTrabajadorPage()
        {
            this.InitializeComponent();
            trabajadorParse = new TrabajadorParse();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += AgregarTrabajadorPage_BackRequested;

        }

        private void AgregarTrabajadorPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (e.Handled == false)
            {
                e.Handled = true;
                rootFrame.GoBack();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           
            trabajador = e.Parameter as Trabajador;
            if (trabajador != null)
            {
                nuevo = true;
                txtNombreTrabajador.Text = trabajador.NombreTrabajador;
                txtKlu.Text = trabajador.Klu.ToString();
                txtKma.Text = trabajador.Kma.ToString();
                txtKmi.Text = trabajador.Kmi.ToString();
                txtKju.Text = trabajador.Kju.ToString();
                txtKvi.Text = trabajador.Kvi.ToString();
                txtKsa.Text = trabajador.Ksa.ToString();
                txtKdo.Text = trabajador.Kdo.ToString();
            }
            else
            {
                nuevo = false;
                idTraNov = e.Parameter as string;
            }
        }

        private void insertTrabajador(object sender, RoutedEventArgs e)
        {
            string nombreTrabajador = txtNombreTrabajador.Text;
            int klu = Convert.ToInt16(txtKlu.Text);
            int kma = Convert.ToInt16(txtKma.Text);
            int kmi = Convert.ToInt16(txtKmi.Text);
            int kju = Convert.ToInt16(txtKju.Text);
            int kvi = Convert.ToInt16(txtKvi.Text);
            int ksa = Convert.ToInt16(txtKsa.Text);
            int kdo = Convert.ToInt16(txtKdo.Text);

            

            if (nuevo == false)
            {
                Trabajador trabajadornuevo = new Trabajador(nombreTrabajador, klu, kma, kmi, kju, kvi, ksa, kdo, idTraNov);
                trabajadorParse.insertTrabajador(trabajadornuevo);
            }
            else
            {
                trabajador.IdTrabajador = trabajador.IdTrabajador;
                trabajador.NombreTrabajador = nombreTrabajador;

                trabajadorParse.updateTrabajador(trabajador);
                nuevo = false;
            }
            rootFrame.Navigate(typeof(ListaTrabajadorPage), idTraNov);


        }
    }
}
