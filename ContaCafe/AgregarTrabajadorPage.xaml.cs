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
    public sealed partial class AgregarTrabajadorPage : Page
    {
        TrabajadorParse trabajadorParse;
        Trabajador trabajador;

        public AgregarTrabajadorPage()
        {
            this.InitializeComponent();
            trabajadorParse = new TrabajadorParse();
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

            trabajador = new Trabajador(nombreTrabajador, klu, kma, kmi, kju, kvi, ksa, kdo);
            trabajadorParse.insertTrabajador(trabajador);
        }
    }
}
