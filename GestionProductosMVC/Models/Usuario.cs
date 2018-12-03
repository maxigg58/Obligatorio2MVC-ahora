using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestionProductosMVC.Models
{
    public class Usuario
    {
        //WOW
        //hola pollo
        [Key]
        public int idUsuario { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "El campo no puede estar vacio")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El campo no puede estar vacio")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Minimo 8 caracteres")]
        public string Password { get; set; }
    
       
    }
}