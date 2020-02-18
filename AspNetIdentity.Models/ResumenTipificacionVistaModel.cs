using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class ResumenTipificacionVistaModel
    {
        public int Total { get; set; }
        public string Grupo { get; set; }
        public Nullable<int> Plano { get; set; }
        public Nullable<int> Orden { get; set; }
        public string Municipio { get; set; }
        public int IdMunicipio { get; set; }
        public string Depto { get; set; }
        public int IdDepto { get; set; }
    }
}
