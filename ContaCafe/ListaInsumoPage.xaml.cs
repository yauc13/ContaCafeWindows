using ContaCafe.Models;
using ContaCafe.Parse;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class ListaInsumoPage : Page
    {

        Frame rootFrame = Window.Current.Content as Frame;
        InsumoParse insumoParse;
        int ok;

        private ObservableCollection<Insumo> listInsumo;

        public ObservableCollection<Insumo> ListInsumo
        {
            get
            {
                if (listInsumo == null)
                    listInsumo = new ObservableCollection<Insumo>();
                return listInsumo;
            }
            set
            {
                listInsumo = value;
            }
        }


        public ListaInsumoPage()
        {
            this.InitializeComponent();
            insumoParse = new InsumoParse();
            mostrarListaInsumo();
        }

        public async void mostrarListaInsumo()
        {
            ObservableCollection<Insumo> InsumoTask = await insumoParse.getAllInsumo();
            foreach (var p in InsumoTask)
            {
                listInsumo.Add(p);
            }
        }

       

        private void edtInsumo(object sender, RoutedEventArgs e)
        {
            ok = 1;
        }

        private void selectInsumo(object sender, SelectionChangedEventArgs e)
        {
           
            if (ok == 1)
            {
                ok = 0;
                rootFrame.Navigate(typeof(AgregarInsumoPage), ListInsumo.ElementAt(listaInsumo.SelectedIndex));

                //listaInsumo.SelectedIndex = -1;
            }
            else
            {
                rootFrame.Navigate(typeof(ListaInsumoPage), listaInsumo);
            }
        }

        private void addInsumo(object sender, RoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(AgregarInsumoPage));
        }
    }
}
