// HomeController.cs
using System.Web.Mvc;

namespace GestorAduana_v1.Controllers
{
    [Authorize] // Requiere autenticación para todas las acciones del controlador
    public class HomeController : Controller
    {
        // GET: Home/Index
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home/About
        [AllowAnonymous] // Permite acceso sin autenticación
        public ActionResult About()
        {
            ViewBag.Message = "Descripción de la aplicación.";

            return View();
        }

        // GET: Home/Contact
        [AllowAnonymous] // Permite acceso sin autenticación
        public ActionResult Contact()
        {
            ViewBag.Message = "Página de contacto.";

            return View();
        }
    }
}
