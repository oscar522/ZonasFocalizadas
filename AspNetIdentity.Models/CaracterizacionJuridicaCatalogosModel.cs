using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetIdentity.Models
{
    public class CaracterizacionJuridicaCatalogosModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> Tipo { get; set; }
        public Nullable<bool> Estado { get; set; }
    }
}
