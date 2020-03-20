using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class ActividadesDiariasModel
    {
        public long Id { get; set; }
        public string IdApsNetUser { get; set; }
        public string NombreUsuario { get; set; }
        public string RolUsuario { get; set; }
        public DateTime FechaActividad { get; set; }
        public string FechaActividadS { get; set; }
        public int IdActividad { get; set; }
        public string NombreActividad { get; set; }
        public string IdRol { get; set; }
        public int Cantidad { get; set; }
        public string Observacion { get; set; }
        public bool Estado { get; set; }
        public DateTime FInsercion { get; set; }

    }
}
