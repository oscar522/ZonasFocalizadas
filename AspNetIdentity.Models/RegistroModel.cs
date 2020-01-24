using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AspNetIdentity.Models
{
    public class RegistroModel
    {
        public long Id { get; set; }
        public Nullable<long> IdExpediente { get; set; }

        [Display(Name = "Expediente")]
        public string NumeroExpediente { get; set; }
        public string IdAspNetUser { get; set; }

        [Display(Name = "F.Verifica")]
        public string FVerificacion { get; set; }
        public Nullable<bool> Estado { get; set; }
        public string Matricula { get; set; }

        [Display(Name = "F. Apertura")]
        public string Fapertura { get; set; }

        [Display(Name = "T.Documento")]
        public string TipoDocumento { get; set; }

        [Display(Name = "Num.Documento")]
        public Nullable<long> NumDocumento { get; set; }
        [Display(Name = "F.Documento")]
        public string FDocumento { get; set; }
        public Nullable<int> IdDepto { get; set; }

        [Display(Name = "Depto")]
        public string NombreIdDepto { get; set; }
        public Nullable<int> IdMunicipio { get; set; }

        [Display(Name = "Municipio")]
        public string NombreIdMunicipio { get; set; }
        public Nullable<int> Area { get; set; }

        [Display(Name = "Cedula Solicitante")]
        public Nullable<long> CcSolicitante { get; set; }

        [Display(Name = "Cedula Conyugue")]
        public Nullable<long> CcConyugue { get; set; }
        public string Conyuge { get; set; }
        public Nullable<bool> EstadoRegistro { get; set; }
        public string UsuarioModifica { get; set; }
        public string UsuarioActualiza { get; set; }
    }
}
