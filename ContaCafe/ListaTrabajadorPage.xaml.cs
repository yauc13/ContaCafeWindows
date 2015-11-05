﻿using ContaCafe.Models;
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
    public sealed partial class ListaTrabajadorPage : Page
    {

        TrabajadorParse trabajadorParse;

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
            mostrarListaTrabajador();
        }

        public async void mostrarListaTrabajador()
        {
            ObservableCollection<Trabajador> TrabajadorTask = await trabajadorParse.getAllTrabajador();
            foreach (var p in TrabajadorTask)
            {
                listTrabajador.Add(p);
            }
        }


    }
}