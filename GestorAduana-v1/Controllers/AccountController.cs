// AccountController.cs
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using GestorAduana_v1.Context;
using GestorAduana_v1.Models;

namespace GestorAduana_v1.Controllers
{
    public class AccountController : Controller
    {
        private GestorAduanasContext db = new GestorAduanasContext();

        // GET: Account/Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Buscar el usuario en la base de datos
                var user = db.Usuarios.FirstOrDefault(u => u.Username == model.Username && u.Contrasena == model.Password);

                if (user != null)
                {
                    // Crear el ticket de autenticación con los roles
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                        1,                             // Versión del ticket
                        user.Username,                 // Nombre de usuario
                        DateTime.Now,                  // Fecha de emisión
                        DateTime.Now.AddMinutes(30),   // Fecha de expiración
                        model.RememberMe,              // Persistencia (Remember Me)
                        user.Rol                       // Datos de usuario (roles)
                    );

                    // Encriptar el ticket
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                    // Crear la cookie de autenticación
                    HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    Response.Cookies.Add(authCookie);

                    // Redirigir al usuario según su rol
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Agregar error si el usuario no existe
                    ModelState.AddModelError("", "Nombre de usuario o contraseña incorrectos.");
                }
            }

            // Retornar la vista con el modelo si hay errores
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Verificar si el nombre de usuario ya existe
                if (db.Usuarios.Any(u => u.Username == model.Username))
                {
                    ModelState.AddModelError("", "El nombre de usuario ya existe.");
                    return View(model);
                }

                // Crear el nuevo usuario
                var usuario = new Usuario
                {
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    Username = model.Username,
                    Contrasena = model.Password, // Considera encriptar la contraseña
                    Rol = model.Role
                };

                db.Usuarios.Add(usuario);
                db.SaveChanges();

                // Crear el ticket de autenticación con los roles
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                    1,                             // Versión del ticket
                    usuario.Username,              // Nombre de usuario
                    DateTime.Now,                  // Fecha de emisión
                    DateTime.Now.AddMinutes(30),   // Fecha de expiración
                    false,                         // Persistencia (Remember Me)
                    usuario.Rol                    // Datos de usuario (roles)
                );

                // Encriptar el ticket
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                // Crear la cookie de autenticación
                HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                Response.Cookies.Add(authCookie);

                // Redirigir al usuario según su rol
                return RedirectToAction("Index", "Home");
            }

            // Retornar la vista con el modelo si hay errores
            return View(model);
        }

        // GET: Account/Logout
        [Authorize]
        public ActionResult Logout()
        {
            // Cerrar la sesión del usuario
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        // GET: Account/AccessDenied
        [AllowAnonymous]
        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}
