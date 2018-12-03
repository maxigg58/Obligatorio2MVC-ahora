using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionProductosMVC.Models
{
    public class Cliente:Usuario
    {
        [Required]
        public string Nombre { get; set; }
     
    }
}