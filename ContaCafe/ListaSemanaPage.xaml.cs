using ContaCafe.Models;
using ContaCafe.Parse;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public sealed partial class ListaSemanaPage : Page { 
        SemanaParse semanaParse;
        
        private ObservableCollection<Semana> listSemana;

        public ObservableCollection<Semana> ListSemana
        {
            get {
                if (listSemana == null)
                    listSemana = new ObservableCollection<Semana>();
                return listSemana; }
            set {

                listSemana = value;
              


            }
        }



        public ListaSemanaPage()
        {
            this.InitializeComponent();

            semanaParse = new SemanaParse();
            mostrarListaSemana();
        }

        public async void mostrarListaSemana()
        {
            ObservableCollection<Semana> SemanaTask = await semanaParse.getAllSemana();
            foreach (var p in SemanaTask) {
                listSemana.Add(p);
            }
        }


    }
}
