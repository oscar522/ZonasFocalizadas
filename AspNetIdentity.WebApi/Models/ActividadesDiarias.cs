//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AspNetIdentity.WebApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ActividadesDiarias
    {
        public long Id { get; set; }
        public string IdApsNetUser { get; set; }
        public Nullable<int> IdProceso { get; set; }
        public Nullable<int> IdModalidad { get; set; }
        public string IdRol { get; set; }
        public Nullable<System.DateTime> FechaActividad { get; set; }
        public Nullable<int> IdActividad { get; set; }
        public Nullable<int> Cantidad { get; set; }
        public string Observacion { get; set; }
        public Nullable<bool> Estado { get; set; }
        public Nullable<System.DateTime> FInsercion { get; set; }
        public Nullable<int> IdDepto { get; set; }
        public Nullable<int> IdMuni { get; set; }
    }
}
