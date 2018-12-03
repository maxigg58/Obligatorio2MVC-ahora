using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestionProductosMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace GestionProductosMVC.ViewModels
{
    public class CarritoCrearViewModel
    {

        public virtual Carrito Orden { get; set; }


        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "Debe de ingresar una cantidad.")]
        [Range(0, int.MaxValue, ErrorMessage = "El valor {0} debe ser mayor a 0.")]
        [RegularExpression("^\\d+$", ErrorMessage = "El campo debe contener sólo números.")]
        public SelectList Productos { get; set; }

        public int IdProductoSeleccionado { get; set; }//voy a guardar el valor seleccionado en la lista desplegable

        public CarritoCrearViewModel(Carrito orden, List<Producto> productos)
        {
            this.Orden = orden;
            this.Productos = new SelectList(productos, "idProducto", "NombreProducto");

        }

        public CarritoCrearViewModel()
        {
        }
    }
}