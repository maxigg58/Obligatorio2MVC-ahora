using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace GestionProductosMVC.Models
{
    public class Producto
        
    {
        //EL NOMBRE DEL PRODUCTO TIENE QUE SER UNICO. CONTROLAR.
        [Key]
        public int idProducto { get; set; }
        [Required(ErrorMessage = "El campo no puede estar vacio")]
      
        public string NombreProducto { get; set; }
        [Required(ErrorMessage = "El campo no puede estar vacio")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El campo no puede estar vacio")]
        public int Costo { get; set; }
        [Required(ErrorMessage = "El campo no puede estar vacio")]

        public int PrecioVenta { get; set; }
        [Required(ErrorMessage = "El campo no puede estar vacio")]

        public int PrecioVentaSugerido { get; set; }
        [Required(ErrorMessage = "El campo no puede estar vacio")]
        public string tipoProducto { get; set; }

        public string PaisOrigen { get; set; }
        [Required(ErrorMessage = "El campo no puede estar vacio")]
        public int CantMinimaAPedir { get; set; }
     
        public int TiempoPreviso { get; set; }




    }



}
