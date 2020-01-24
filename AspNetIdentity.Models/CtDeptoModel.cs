using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class CtDeptoModel
    {
        public int ID_CT_DEPTO { get; set; }
        [Required(ErrorMessage = "Debe ingresar el Pais ")]

        public int ID_CT_PAIS { get; set; }
        [Display(Name = "PAIS")]
        public string NOMBRE_PAIS { get; set; }
        [Required(ErrorMessage = "Debe ingresar el Nombre ")]

        public string NOMBRE { get; set; }
    }
}
