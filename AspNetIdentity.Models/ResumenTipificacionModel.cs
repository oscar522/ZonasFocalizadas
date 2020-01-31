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
    }
}
