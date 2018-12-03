using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionProductosMVC.Models
{
    public class Login
    {
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "El campo no puede ser vacio")]
        [Key]
        public string EmailLogin { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "El campo no puede ser vacio")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Minimo 6 caracteres")]
        public string PasswordLogin { get; set; }
    }
}