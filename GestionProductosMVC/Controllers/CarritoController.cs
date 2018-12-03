using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestionProductosMVC.Models;
using GestionProductosMVC.ViewModels;

namespace GestionProductosMVC.Controllers
{
    public class CarritoController : Controller
    {
        private MiContextoContext db = new MiContextoContext();

        // GET: Carrito
        public ActionResult Index()
        {
            int usuariologueado = ((int)Session["Usuario"]);
            MiContextoContext db = new MiContextoContext();


            List<Carrito> ordenes = new List<Carrito>();



            foreach (Carrito unaO in db.Carritos.ToList())
            {

                if (unaO.cliente.idUsuario == usuariologueado && unaO.Venta == false)
                {
                    ordenes.Add(unaO);
                }
            }




            return View(ordenes.ToList());
        }

        // GET: Carrito/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Carrito orden = db.Carritos.Find(id);

            if (orden == null)
            {
                return HttpNotFound();
            }

            return View(orden);
        }


        // GET: Carrito/Create
        [HttpGet]
        public ActionResult Create()
        {
            Carrito orden = new Carrito();
            List<Producto> productos;

            using (MiContextoContext db = new MiContextoContext())
            {
                productos = db.Productoes.ToList();
            }

            CarritoCrearViewModel vm = new CarritoCrearViewModel(orden, productos);


            return View(vm);
        }

        // POST: Carrito/Create
        [HttpPost]
        public ActionResult Create(CarritoCrearViewModel vm)
        {
            int usuariologueado = ((int)Session["Usuario"]);
            int ocvariableSession = ((int)Session["Carrito"]);
            int ItemsenCarrito = ((int)Session["CountElementosCarrito"]);


            DateTime fecha = DateTime.Now;

            try
            {
                using (MiContextoContext db = new MiContextoContext())
                {




                    Producto prodSeleccionado = new Producto();
                    Cliente unc = new Cliente();
                    prodSeleccionado = db.Productoes.Find(vm.IdProductoSeleccionado);
                    unc = db.Clientes.Find(usuariologueado);

                    if (ocvariableSession == 0 && prodSeleccionado != null && unc != null)
                    {
                        if (vm.Orden.cantidad > 0)
                        {

                            var random = new Random();
                            int OrdenCompra = random.Next(1000, 9999);

                            vm.Orden.cliente = unc;
                            vm.Orden.producto = prodSeleccionado;

                            // vm.Orden.producto.idProducto = prodSeleccionado.idProducto;
                            //  vm.Orden.cliente.idUsuario = usuariologueado;
                            //   vm.Orden.producto.Costo = prodSeleccionado.PrecioVenta;
                            vm.Orden.fechaRegistro = fecha;
                            // vm.Orden.producto.NombreProducto = prodSeleccionado.NombreProducto;
                            vm.Orden.OrdenDeCompra = OrdenCompra;
                            vm.Orden.Venta = false;
                            Session["Carrito"] = OrdenCompra;

                            if (vm.Orden.OrdenDeCompra != 0 && vm.Orden.cliente.idUsuario != 0)
                            {


                                db.Carritos.Add(vm.Orden);
                                db.SaveChanges();

                                Session["CountElementosCarrito"] = ItemsenCarrito + 1;
                                vm.Productos = new SelectList(db.Productoes.ToList(), "idProducto", "NombreProducto");
                                return RedirectToAction("AccionExitosa");
                            }

                        }
                        else
                        {
                            ViewBag.Error = "La cantidad debe ser mayor a 0";
                        }
                    }


                    else if (prodSeleccionado != null)
                    {

                        var existeProducto = db.Carritos.Where(x => x.Venta == false && x.producto.idProducto == vm.IdProductoSeleccionado && x.cliente.idUsuario == usuariologueado).ToList();

                        if (existeProducto.Count() == 0)
                        {
                            if (vm.Orden.cantidad > 0)
                            {

                                vm.Orden.cliente = unc;
                                vm.Orden.producto = prodSeleccionado;

                                // vm.Orden.producto.idProducto = prodSeleccionado.idProducto;
                                //  vm.Orden.cliente.idUsuario = usuariologueado;
                                //  vm.Orden.producto.Costo = prodSeleccionado.PrecioVenta;
                                vm.Orden.fechaRegistro = fecha;
                                //  vm.Orden.producto.NombreProducto = prodSeleccionado.NombreProducto;
                                vm.Orden.Venta = false;
                                vm.Orden.OrdenDeCompra = ocvariableSession;


                                db.Carritos.Add(vm.Orden);
                                db.SaveChanges();
                                vm.Productos = new SelectList(db.Productoes.ToList(), "idProducto", "NombreProducto");
                                Session["CountElementosCarrito"] = ItemsenCarrito + 1;

                                return RedirectToAction("AccionExitosa");

                            }
                            else
                                ViewBag.Error = "prueba";

                        }
                        else
                        {
                            return RedirectToAction("ErrorProducto");
                        }

                    }

                }
            }
            catch
            {

                return RedirectToAction("Error");
            }

            return View(vm);

        }


        public ActionResult CantidadError()
        {

            return View();
        }

        public ActionResult Error()
        {

            return View();
        }

        public ActionResult AccionExitosa()
        {

            return View();
        }

        public ActionResult ErrorProducto()
        {

            return View();
        }



        // GET: Carrito/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //busco el id pasado con el find en la base de datos

            Carrito orden = db.Carritos.Find(id);

            if (orden == null)
            {
                return HttpNotFound();
            }
            return View(orden);
        }

        // POST: Carrito/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Carrito orden)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orden).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orden);
        }

        // GET: Carrito/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //busco id con el find en la base de datos
            Carrito orden = db.Carritos.Find(id);

            if (orden == null)
            {
                return HttpNotFound();
            }
            return View(orden);
        }

        // POST: Carrito/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Carrito orden = db.Carritos.Find(id);
            db.Carritos.Remove(orden);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult CarritoVacio()
        {
            return View();
        }

        public ActionResult ConfirmarCompra(int? id)
        {



            int usuariologueado = ((int)Session["Usuario"]);

            if (id == null || id == 0)
            {
                return RedirectToAction("CarritoVacio");
            }
            else
            {
                List<Carrito> MiCarrito = db.Carritos.ToList();
                Pedido nuevoP = new Pedido();
                int monto = 0;

                foreach (var OcCarrito in MiCarrito)
                {
                    if (OcCarrito.OrdenDeCompra == id && OcCarrito.Venta == false && OcCarrito.cliente.idUsuario == usuariologueado)
                    {
                        monto = monto + (OcCarrito.producto.Costo * OcCarrito.cantidad);
                        nuevoP.idCliente = OcCarrito.cliente.idUsuario;
                        nuevoP.idOrdenCompra = OcCarrito.OrdenDeCompra;
                        nuevoP.fecha = OcCarrito.fechaRegistro;
                        nuevoP.totalPedido = monto;
                        //   db.Carritos.Remove(OcCarrito);
                        //  db.SaveChanges();
                        OcCarrito.Venta = true;
                        db.Entry(OcCarrito).State = EntityState.Modified;
                        //  db.Carritos.Add(OcCarrito);
                        db.SaveChanges();
                    }
                }
                db.Pedidos.Add(nuevoP);
                db.SaveChanges();
                Session["Carrito"] = 0;
                Session["CountElementosCarrito"] = 0;

            }

            return RedirectToAction("Index");

        }


        public ActionResult VisualizarPedidos(int? id)
        {

            int usuariologueado = ((int)Session["Usuario"]);


            try
            {
                using (MiContextoContext db = new MiContextoContext())
                {


                    /*   var JoinCarritoPedidos = from carrito in db.Carritos
                                                join ped in db.Pedidos on carrito.idCliente equals ped.idCliente
                                                where ped.idCliente == usuariologueado && carrito.Venta == false
                                                select ped.idOrdenCompra;
                       // select new { Fecha = ped.fecha, OC = ped.idOrdenCompra, Total = ped.totalPedido, Codigo = carrito.idProducto, Nombre = carrito.nomProd, Precio = carrito.precio, Unidades = carrito.cantidad };
                       */
                    var consulta = (from carr in db.Carritos
                                    join pedi in db.Pedidos
                                    on carr.cliente.idUsuario equals pedi.idCliente
                                    where carr.cliente.idUsuario == usuariologueado && carr.Venta == true && carr.OrdenDeCompra == pedi.idOrdenCompra
                                    select new { Fecha = pedi.fecha, OC = pedi.idOrdenCompra, Total = pedi.totalPedido, Codigo = carr.producto.idProducto, Nombre = carr.producto.NombreProducto, Precio = carr.producto.PrecioVenta, Unidades = carr.cantidad }


                        );

                    List<VerPedidosViewModel> ListPedidos = new List<VerPedidosViewModel>();

                    foreach (var unP in consulta)
                    {
                        VerPedidosViewModel p = new VerPedidosViewModel();
                        p.CodProd = unP.Codigo;

                        p.Fecha = unP.Fecha;
                        p.OC = unP.OC;
                        p.Total = unP.Total;
                        p.NombreProd = unP.Nombre;
                        p.PrecioProd = unP.Precio;
                        p.Unidades = unP.Unidades;

                        ListPedidos.Add(p);

                    }


                    return View(ListPedidos.ToList());

                }
            }
            catch
            {

                return RedirectToAction("Index");
            }

        }
    }




}
