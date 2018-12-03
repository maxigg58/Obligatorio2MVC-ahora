using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestionProductosMVC.Models
{
    public class Carrito
    {
        [Key]
        public virtual int idSolicitud { get; set; }
        [Required]
        public virtual Cliente cliente { get; set; }
        [Required]
        public virtual Producto producto { get; set; }
        [Required]
        public int OrdenDeCompra { get; set; }
        /*
        [Required]
        public virtual string nomProd { get; set; }
       
        [Required]
        public virtual int precio { get; set; }
       

    */

        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "Debe de ingresar una cantidad.")]
        [Range(0, 100, ErrorMessage = "El valor {0} debe ser mayor a 0.")]
        [RegularExpression("^\\d+$", ErrorMessage = "El campo debe contener sólo números.")]

        public virtual int cantidad { get; set; }


        [Required]
        public virtual DateTime fechaRegistro { get; set; }
        [Required]
        public virtual bool Venta { get; set; }




        //  [NotMapped]
        //public List<Carrito> ListadeCarrito { get; set; }
    }
}