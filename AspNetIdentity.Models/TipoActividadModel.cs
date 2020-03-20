using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class TipoActividadModel
    {
        public int Id { get; set; }
        public string Actividad { get; set; }
        public bool Activa { get; set; }
    }
}
