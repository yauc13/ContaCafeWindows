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
    public sealed partial class ListaTrabajadorPage : Page
    {

        TrabajadorParse trabajadorParse;
        Frame rootFrame = Window.Current.Content as Frame;
        int ok;
        Semana semana;
        string idSemanaNoti;
        string idTraNov;


        private ObservableCollection<Trabajador> listTrabajador;

        public ObservableCollection<Trabajador>  ListTrabajador
        {
            get
            {
                if (listTrabajador == null)
                    listTrabajador = new ObservableCollection<Trabajador>();
                return listTrabajador;
            }
            set
            {
                listTrabajador = value;
            }
        }

        public ListaTrabajadorPage()
        {
            this.InitializeComponent();
            trabajadorParse = new TrabajadorParse();
            //mostrarListaTrabajador();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += ListaTrabajadorPage_BackRequested;

        }

        private void ListaTrabajadorPage_BackRequested(object sender, BackRequestedEventArgs e)
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
                idSemanaNoti = semana.IdSemana;
                mostrarListaTrabajador();

            }
            else
            {
                //mostrarListaTrabajador();
            }

            idTraNov = e.Parameter as string;
            if (idTraNov != null)
            {
                
                idSemanaNoti = idTraNov;
               mostrarListaTrabajador();

            }
            else
            {

            }
        }


        public async void mostrarListaTrabajador()
        {
            ObservableCollection<Trabajador> TrabajadorTask = await trabajadorParse.getAllTrabajador(idSemanaNoti);
            foreach (var p in TrabajadorTask)
            {
                listTrabajador.Add(p);
            }
        }

        private void selectTrabajador(object sender, SelectionChangedEventArgs e)
        {
            if (ok == 1)
            {
                ok = 0;
                rootFrame.Navigate(typeof(AgregarTrabajadorPage), listTrabajador.ElementAt(listaTrabajador.SelectedIndex));

                //listaInsumo.SelectedIndex es el nombre del Lisbox del xaml;
            }
            else
            {
                //rootFrame.Navigate(typeof(ListaTrabajadorPage), listTrabajador);
            }
        }

        private void editTrabajador(object sender, RoutedEventArgs e)
        {
            ok = 1;
        }

        private void addTrabajador(object sender, RoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(AgregarTrabajadorPage), idSemanaNoti);
        }
    }
}
