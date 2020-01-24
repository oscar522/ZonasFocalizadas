using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class AccountTableModel
    {
        public int Id_Account { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Pais")]
        public int Id_Country { get; set; }
        public string NombreCountry { get; set; }
        public string Id_Code { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Nombre")]
        public string Name { get; set; }
        public System.DateTime CreationDate { get; set; }
        [Required(ErrorMessage = "Debe ingresar una Imagen")]
        public string ImageName { get; set; }
        public bool Active { get; set; }
        public Nullable<System.DateTime> LastChangeDate { get; set; }
        public Nullable<int> LastChangeUser { get; set; }

    }
}
