using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class UserDataModel
    {
        public int Id { get; set; }
        public String Id_Hash { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public bool Active { get; set; }
        public int Completed { get; set; }
        public int Existe { get; set; }
        [Display(Name = "F. Creacion")]
        public DateTime FechaCreo  { get; set; }
        public int UsuarioCreo  { get; set; }
        [Display(Name = "Nombre Usuario")]
        public string UsuarioCreoNombre  { get; set; }
        [Display(Name = "Contraseña")]
        public string PasswordHash { get; set; }
        [Display(Name = "Contraseña")]
        public string PasswordHashConfir { get; set; }
        [Display(Name = "NombreUsuario")]
        public string NombreUsuario { get; set; }
    }
}
