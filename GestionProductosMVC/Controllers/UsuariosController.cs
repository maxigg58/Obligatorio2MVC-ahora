using GestionProductosMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionProductosMVC.Controllers
{
    public class UsuariosController : Controller
    {
        private MiContextoContext db = new MiContextoContext();

        
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //prueba
        
            
        // GET: Usuarios
        [HttpPost]
        public ActionResult Login(string EmailLogin, string PasswordLogin)
        {
            
            try
            {
                using (MiContextoContext db = new MiContextoContext())
                {



               //     var buscado = db.Empleadoes.Where(e => e.Email == EmailLogin).Where(e => e.Password == PasswordLogin).Select(e => e.Email);

                    var usu = db.Empleadoes.SingleOrDefault
                       (u => u.Email.ToUpper() == EmailLogin.ToUpper()
                       && u.Password == PasswordLogin);

                    int contador = 0;


                    if (usu != null)
                    {

                        foreach (var item in db.Carritos.ToList())
                        {
                            if (item.cliente.idUsuario == usu.idUsuario && item.Venta == false)
                            {
                                contador = contador + 1;
                            }
                           
                        }

                        Session["CountElementosCarrito"] = contador;


                        var carritoUsu = db.Carritos.FirstOrDefault
                      (u => u.cliente.idUsuario == usu.idUsuario && u.Venta == false);

                        Session["UsuLogeado"] = 0;
                        Session["Email"] = usu.Email;
                        Session["Usuario"] = usu.idUsuario;

                        if (carritoUsu!=null)
                        {
                            Session["Carrito"] = carritoUsu.OrdenDeCompra;
                        }
                        else
                        {
                            Session["Carrito"] = 0;
                        }


                        return RedirectToAction("Index", "Home");
                    }
                   // var buscado2 = db.Clientes.Where(e => e.Email == EmailLogin).Where(e => e.Password == PasswordLogin).Select(e => e.Email);


                    var usu2 = db.Clientes.SingleOrDefault
                       (u => u.Email.ToUpper() == EmailLogin.ToUpper()
                       && u.Password == PasswordLogin);

                  // sintaxis fefi  var buscado2 = db.Usuarios.OfType<Cliente>().Where(e => e.Email == EmailLogin).Where(e => e.Password == PasswordLogin).Select(e => e.Email);

                    // Otra sintaxis var buscado2 = from e in db.Clientes where e.Email == Email where e.Password == Password select e;
                    if (usu2 != null)
                    {



                        foreach (var item in db.Carritos.ToList())
                        {
                            if (item.cliente.idUsuario == usu2.idUsuario && item.Venta == false)
                            {
                                contador = contador + 1;
                            }

                        }

                        Session["CountElementosCarrito"] = contador;
                    

                        var carritoUsu2 = db.Carritos.FirstOrDefault
                     (u => u.cliente.idUsuario == usu2.idUsuario && u.Venta == false);

                        Session["UsuLogeado"] = 1;
                        Session["Email"] = usu2.Email;
                        Session["Usuario"] = usu2.idUsuario;
                        if (carritoUsu2!=null)
                        {
                            Session["Carrito"] = carritoUsu2.OrdenDeCompra;
                        }
                        else
                        {
                            Session["Carrito"] = 0;
                        }

                        return RedirectToAction("Index", "Home");
                    }
                   

                }


            }

            catch
            {
                return RedirectToAction("Login", "Usuarios");
            }
            
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Logout()
        {
            Session["Email"] = null;
            Session["CountElementosCarrito"] = null;
            Session["UsuLogeado"] = 2;
            Session["Usuario"] = null;
            Session["Carrito"] = 0;
     

                return RedirectToAction("Index", "Home");
        }
        


    }
}