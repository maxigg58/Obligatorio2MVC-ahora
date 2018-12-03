using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestionProductosMVC.Models;

namespace GestionProductosMVC.Controllers
{
    public class ProductoesController : Controller
    {
        private MiContextoContext db = new MiContextoContext();

        // GET: Productoes
        public ActionResult Index()
        {
            if (Session["Email"] == null)
            {
                return RedirectToAction("Login", "Usuarios");
            }
            return View();
        }

        // GET: Productoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productoes.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Productoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Productoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProducto,NombreProducto,Descripcion,Costo,PrecioVenta")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Productoes.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(producto);
        }

        // GET: Productoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productoes.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProducto,NombreProducto,Descripcion,Costo,PrecioVenta,PrecioVentaSugerido,tipoProducto,PaisOrigen,CantMinimaAPedir,TiempoPreviso")] Producto producto)
        {
            int tope = ((producto.PrecioVentaSugerido * 10) / 100) + producto.PrecioVentaSugerido;


            if (ModelState.IsValid)
            {
                if ((int)Session["UsuLogeado"] == 0)
                {
                    if (producto.PrecioVenta > producto.PrecioVentaSugerido && producto.PrecioVenta < tope)
                    {
                        db.Entry(producto).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("EdicionCorrecta", "Productoes");
                    }
                    return RedirectToAction("ErrorEnEditarPrecio", "Productoes");
                }
                else
                    return RedirectToAction("UsuNoHabilitado", "Productoes");
            }



            return View(producto);
        }

        // ver
        public ActionResult ErrorEnEditarPrecio()
        {
            return View();
        }
        public ActionResult EdicionCorrecta()
        {
            return View();
        }

        public ActionResult NoProductos()
        {
            return View();
        }
        public ActionResult UsuNoHabilitado()
        {
            return View();
        }

        // GET: Productoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productoes.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Productoes.Find(id);
            db.Productoes.Remove(producto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult Index(int? Codigo, string Nombre, string Descripcion, int? Rdesde, int? Rhasta, string Tipo)
        {

            var products = from e in db.Productoes.OrderBy(p => p.tipoProducto).ThenBy(p => p.NombreProducto) select e;

            if (Codigo != null)
            {
                //busco por id
                products = products.Where(s => s.idProducto == Codigo);
            }
            if (!String.IsNullOrEmpty(Nombre))
            {
                //busco por que contenga algo del nombre
                products = products
                    .Where(s => s.NombreProducto.Contains(Nombre));
            }
            if (!String.IsNullOrEmpty(Descripcion))
            {
                //busco por que contenga algo de la Descripcion
                products = products
                    .Where(s => s.Descripcion.Contains(Descripcion));
            }
            if (Rdesde != null && Rhasta != null)
            {
                //busca por rango de precios de venta
                products = products
                    .Where(s => s.PrecioVenta >= Rdesde).Where(s => s.PrecioVenta <= Rhasta);
            }
            if (!String.IsNullOrEmpty(Tipo))
            {
                //busco por tipo de producto
                products = products
                    .Where(s => s.tipoProducto == Tipo);
            }

            if (products.Count() == 0)
            {
                return RedirectToAction("NoProductos", "Productoes");
            }

            return View(products.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
