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
    
    public partial class Accounts_AdditionalInformation
    {
        public int Id_AdditionalInformation { get; set; }
        public int Id_Account { get; set; }
        public System.DateTime LastChangeDate { get; set; }
        public int LastChangeUser { get; set; }
        public bool AboutActive { get; set; }
        public string AboutTitle { get; set; }
        public string AboutDescription { get; set; }
        public bool PrivPoliActive { get; set; }
        public string PrivPoliTitle { get; set; }
        public string PrivPoliDescription { get; set; }
        public string PrivPoliButton { get; set; }
    }
}
