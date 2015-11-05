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
    public sealed partial class MenuOpcionesPage : Page
    {

        Frame rootFrame = Window.Current.Content as Frame;
        public MenuOpcionesPage()
        {
            this.InitializeComponent();
        }

        private void goToSemana(object sender, RoutedEventArgs e)
        {
            
            rootFrame.Navigate(typeof(ListaSemanaPage));
        }

        private void goToInsumos(object sender, RoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(ListaInsumoPage));
        }
    }
}
