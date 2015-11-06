using ContaCafe.Models;
using ContaCafe.Parse;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ContaCafe
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AgregarInsumoPage : Page
    {
        InsumoParse insumoParse;
        Insumo insumo;
        bool nuevo= false;
        Frame rootFrame = Window.Current.Content as Frame;

        public AgregarInsumoPage()
        {
            this.InitializeComponent();
            insumoParse = new InsumoParse();
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
            insumo = e.Parameter as Insumo;
            if (insumo!=null)
            {
                nuevo = true;
                txtNombreInsumo.Text = insumo.NombreInsumo;
                txtPrecioInsumo.Text = insumo.PrecioInsumo.ToString();
            }
            else
            {
                nuevo = false;
            }

            

        }

        private void insertInsumo(object sender, RoutedEventArgs e)
        {
            string nombreInsumo = txtNombreInsumo.Text;
            double precioInsumo = Convert.ToDouble(txtPrecioInsumo.Text);

            if (nuevo==false) { 
            
            Insumo insumonuevo = new Insumo(nombreInsumo, precioInsumo);
            insumoParse.insertInsumo(insumonuevo);
            
            }
            else
            {
                insumo.IdInsumo = insumo.IdInsumo;
                insumo.NombreInsumo = nombreInsumo;
                insumo.PrecioInsumo = precioInsumo;
                insumoParse.updateInsumo(insumo);
                nuevo = false;
            }

            rootFrame.Navigate(typeof(ListaInsumoPage));

        }



    }

}
