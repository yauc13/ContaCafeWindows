using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaCafe.Models
{
   public class Trabajador
    {

        public string IdTrabajador { get; set; }
        public string NombreTrabajador { get; set; }
        public int Klu { get; set; }
        public int Kma { get; set; }
        public int Kmi { get; set; }
        public int Kju { get; set; }
        public int Kvi { get; set; }
        public int Ksa { get; set; }
        public int Kdo { get; set; }


        public Trabajador()
        {

        }

        public Trabajador(string NombreTrabajador, int Klu, int Kma, int Kmi, int Kju, int Kvi, int Ksa, int Kdo)
        {
            this.NombreTrabajador = NombreTrabajador;
            this.Klu = Klu;
            this.Kma = Kma;
            this.Kmi = Kmi;
            this.Kju = Kju;
            this.Kvi = Kvi;
            this.Ksa = Ksa;
            this.Kdo = Kdo;

        }



    }
}
