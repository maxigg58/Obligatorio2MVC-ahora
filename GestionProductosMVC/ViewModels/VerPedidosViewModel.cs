using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestionProductosMVC.Models;

namespace GestionProductosMVC.ViewModels
{
    public class VerPedidosViewModel
    {
       

        public DateTime Fecha { get; set; }

        public int OC { get; set; }
        public int Total { get; set; }
        public int CodProd { get; set; }
        public string NombreProd { get; set; }
        public int PrecioProd { get; set; }
        public int Unidades { get; set; }
        public List<VerPedidosViewModel> pedidos{ get; set; }

        public VerPedidosViewModel() { }
    }
}