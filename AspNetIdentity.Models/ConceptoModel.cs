//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AspNetIdentity.Models

{
    using System;
    using System.Collections.Generic;
    
    public partial class ConceptoModel
    {
        public int Id { get; set; }
        public string IdAspNetUsers { get; set; }
        public string UserAsociado { get; set; }
        public string Rol { get; set; }
        public string NombreAspNetUsers { get; set; }
        public Nullable<int> IdCausa { get; set; }
        public string NombreCausa { get; set; }
        public Nullable<int> IdExpediente { get; set; }
        public string RutaExpediente { get; set; }
        public string Soporte { get; set; }
        public string Anexo { get; set; }
        public string IdOrfeo { get; set; }
        public Nullable<bool> Estado { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }

    }
}
