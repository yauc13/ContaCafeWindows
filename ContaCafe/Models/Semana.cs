using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaCafe.Models
{
   public class Semana
    {
        public string IdSemana { get; set; }
        public string NombreSemana { get; set; }
       

        public Semana()
        {

        }

        public Semana(string NombreSemana)
        {
            this.NombreSemana = NombreSemana;
        }


    }
}
