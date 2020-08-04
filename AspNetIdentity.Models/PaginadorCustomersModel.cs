using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class PaginadorCustomersModel
    {
        public int ID_GENERO { get; set; }
        public int RegistrosPorPagina { get; set; }
        public int TotalRegistros { get; set; }
        public int TotalPaginas { get; set; }
        public int PaginaActual { get; set; }
        public  List<ActividadesDiariasModel> Resultado { get; set; }
    }
}
