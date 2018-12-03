using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestionProductosMVC.Models
{
    public class Pedido
    {
        [Key]
        public int idPedido { get; set; }
        [Required]
   

        public int idOrdenCompra { get; set; }
        [Required]
        public int idCliente { get; set; }
        [Required]
        public DateTime fecha { get; set; }
        public int totalPedido { get; set; }

     

    }
}