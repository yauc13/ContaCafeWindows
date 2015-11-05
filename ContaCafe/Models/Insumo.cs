using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaCafe.Models
{
   public class Insumo
    {
        public string IdInsumo { get; set; }
        public string NombreInsumo { get; set; }
        public double PrecioInsumo { get; set; }

        public Insumo()
        {

        }

        public Insumo(string NombreInsumo, double PrecioInsumo)
        {
            this.NombreInsumo = NombreInsumo;
            this.PrecioInsumo = PrecioInsumo;
        }

    }
}
