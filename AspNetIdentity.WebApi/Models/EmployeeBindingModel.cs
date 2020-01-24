using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.WebApi.Models
{
    public class TechicalTestBindingModel
    {
        [Required]
        public int Id_UserTest { get; set; }

        [Required]
        public string Answers { get; set; }
    }
}