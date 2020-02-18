using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class ResumenTipificacionModel
    {
        public int Id { get; set; }
        public int IdExpediente { get; set; }
        public string IdAspNetUser { get; set; }
        public string Grupo { get; set; }
        public Nullable<int> Plano { get; set; }
        public Nullable<int> Orden { get; set; }
        public string Municipio { get; set; }
        public int IdMunicipio { get; set; }
        public string Depto { get; set; }
        public int IdDepto { get; set; }

    }
}
