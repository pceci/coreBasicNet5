using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace coreBasicNet5.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            //coreBasicNet5.Codigo.Criptografía.cPasosSeguridad.test_2();
            return View();
        }
    }
}