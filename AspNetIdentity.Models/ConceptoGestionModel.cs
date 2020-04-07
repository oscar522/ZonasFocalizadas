using System;
using System.Collections.Generic;

namespace AspNetIdentity.Models
{
    public partial class ConceptoGestionModel
    {
        public int Id { get; set; }
        public Nullable<int> IdConcepto { get; set; }
        public Nullable<int> IdEstado { get; set; }
        public string NombreIdEstado { get; set; }
        public Nullable<int> IdSoporte { get; set; }
        public string NombreIdSoporte { get; set; }
        public string IdAspNetUserGestion { get; set; }
        public string NombreUser { get; set; }
        public string IdRolUser { get; set; }
        public string RolUser { get; set; }
        public string Observacion { get; set; }
        public string Archivo { get; set; }
        public string FCreacion { get; set; }
        public Nullable<bool> Estado { get; set; }
    }
}
