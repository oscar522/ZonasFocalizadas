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
    
    public partial class Registro
    {
        public long Id { get; set; }
        public Nullable<long> IdExpediente { get; set; }
        public string IdAspNetUser { get; set; }
        public string FVerificacion { get; set; }
        public Nullable<bool> Estado { get; set; }
        public string Matricula { get; set; }
        public string Fapertura { get; set; }
        public string TipoDocumento { get; set; }
        public Nullable<long> NumDocumento { get; set; }
        public string FDocumento { get; set; }
        public Nullable<int> IdDepto { get; set; }
        public Nullable<int> IdMunicipio { get; set; }
        public Nullable<int> Area { get; set; }
        public Nullable<long> CcSolicitante { get; set; }
        public Nullable<long> CcConyugue { get; set; }
        public string Conyuge { get; set; }
        public Nullable<bool> EstadoRegistro { get; set; }
        public string UsuarioModifica { get; set; }
        public string UsuarioActualiza { get; set; }
    }
}