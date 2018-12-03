using GestionProductosMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionProductosMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Email"] == null)
            {
                return RedirectToAction("Login", "Usuarios");
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult DatosCargados()
        {
            return View();
        }

        public ActionResult CargarProductos()
        {

            if (Session["Email"] == null && Session["UsuLogeado"] == null)
            {
                return RedirectToAction("Login", "Usuarios");
            }
            if ((int)Session["UsuLogeado"] == 0)
            {


                MiContextoContext db = new MiContextoContext();

                if (db.Productoes.Count() != 0)
                {
                    return RedirectToAction("DatosCargados", "Home");
                }

                if (db.Productoes.Count() == 0)
                {


                    List<String> listaTemp = new List<String>();
                    string ruta = AppDomain.CurrentDomain.BaseDirectory + "\\Archivo\\Productos.txt";
                    StreamReader sr = new StreamReader(ruta);
                    string linea = null;
                    linea = sr.ReadLine();

                    while ((linea != null))
                    {
                        listaTemp.Add(linea);
                        linea = sr.ReadLine();
                    }

                    for (int i = 0; i < listaTemp.Count; i++)
                    {
                        string cadena = listaTemp[i];
                        string[] vec1 = cadena.Split('|');


                        if (vec1 != null)
                        {

                            if (vec1[5] == "Importado")
                            {
                                Producto pi = new Producto
                                {
                                    NombreProducto = vec1[1],
                                    Descripcion = vec1[2],
                                    Costo = int.Parse(vec1[3]),
                                    PrecioVenta = int.Parse(vec1[4]),
                                    PaisOrigen = vec1[6],

                                    PrecioVentaSugerido = int.Parse(vec1[4]),
                                    tipoProducto = vec1[5],
                                    CantMinimaAPedir = int.Parse(vec1[7])


                                };
                                db.Productoes.Add(pi);

                            }
                            if (vec1[5] == "Fabricado")
                            {
                                Producto pf = new Producto
                                {
                                    NombreProducto = vec1[1],
                                    Descripcion = vec1[2],
                                    Costo = int.Parse(vec1[3]),
                                    PrecioVenta = int.Parse(vec1[4]),
                                    PrecioVentaSugerido = int.Parse(vec1[4]),
                                    tipoProducto = vec1[5],
                                    TiempoPreviso = int.Parse(vec1[7])


                                };
                                db.Productoes.Add(pf);
                            }


                            db.SaveChanges();
                        }

                    }
                    return RedirectToAction("CargarProductos", "Home");
                }

            }
            return RedirectToAction("AvisoUsuIncorrecto", "Home");


        }


    }
}