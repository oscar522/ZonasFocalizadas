using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetIdentity.Models
{
    public class CtPaisModel
    {

        public int ID_CT_PAIS { get; set; }
        [Required(ErrorMessage = "Debe ingresar el Nombre del Pais")]

        public string NOMBRE { get; set; }
        public int ESTADO { get; set; }
    }
}
