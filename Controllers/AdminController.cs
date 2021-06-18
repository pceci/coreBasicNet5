using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using coreBasicNet5.Business;
using coreBasicNet5.Entities;
using Microsoft.AspNetCore.Authorization;

namespace coreBasicNet5.Controllers
{
    // [Authorize]
    public class AdminController : Controller
    {
        private readonly IAdminService adminService;

        public AdminController(IAdminService pAdminService)
        {
            this.adminService = pAdminService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RolIndex()
        {
            return View(adminService.GetAllRol());
        }

        [HttpGet]
        public IActionResult RolDetails(int id)
        {
            var oRol = adminService.GetOneRol(id);

            if (oRol == null)
            {
                return NotFound();
            }

            return View(oRol);
        }

        [HttpGet]
        public IActionResult RolCreate()
        {
            return View(new cRol());
        }

        [HttpPost]
        public IActionResult RolCreate(cRol pRol)
        {
            if (ModelState.IsValid)
            {
                adminService.AddRol(pRol);

                return RedirectToAction("RolIndex");
            }

            return View(pRol);
        }


        [HttpGet]
        public IActionResult RolEdit(int id)
        {
            var oRol = adminService.GetOneRol(id);

            if (oRol == null)
            {
                return NotFound();
            }

            return View(oRol);
        }

        [HttpPost]
        public IActionResult RolEdit(int id, cRol pRol)
        {
            if (ModelState.IsValid)
            {
                var updatedRol = adminService.EditRol(id, pRol);

                if (updatedRol == null)
                {
                    return NotFound();
                }

                return RedirectToAction("RolIndex");
            }

            return View(pRol);
        }


        [HttpGet]
        public IActionResult RolDelete(int id)
        {
            var oRol = adminService.GetOneRol(id);

            if (oRol == null)
            {
                return NotFound();
            }

            return View(oRol);
        }

        [HttpPost]//, ActionName("Delete")
        public IActionResult RolDeleteConfirmed(int id)
        {
            adminService.DeleteRol(id);

            return RedirectToAction("RolIndex");
        }
        [HttpGet]
        public IActionResult ReglaIndex()
        {
            ViewBag.ListaTodasReglasPorNivel = CargarArbolCombo();
            return View();
        }

        public string CargarArbolCombo()
        {
            return coreBasicNet5.Codigo.Serializador.SerializarAJson(adminService.GetAllReglaPorNivel());
        }
        public List<bool> IsNombreOPalabraNoSeRepite(int pIdRegla, string pNombre, string pPalabra)
        {
            List<bool> resultado = new List<bool>();
            List<cRegla> listaRegla = adminService.GetAllRegla();
            resultado.Add(listaRegla.Where(x => x.rgl_Descripcion == pNombre && x.rgl_codRegla != pIdRegla).Count() > 0 ? false : true);
            resultado.Add(listaRegla.Where(x => x.rgl_PalabraClave == pPalabra.ToLower() && x.rgl_codRegla != pIdRegla).Count() > 0 ? false : true);
            return resultado;
        }
        public bool InsertarRegla(string pDescripcion, string pPalabra, bool pAgregar, bool pEditar, bool pEliminar, int pIdReglaPadre)
        {
            cRegla oRegla = new cRegla();
            oRegla.id = 0;
            oRegla.rgl_Descripcion = pDescripcion;
            oRegla.rgl_PalabraClave = pPalabra;
            oRegla.rgl_IsAgregarSoporta = pAgregar;
            oRegla.rgl_IsEditarSoporta = pEditar;
            oRegla.rgl_IsEliminarSoporta = pEliminar;
            oRegla.rgl_codReglaPadre = pIdReglaPadre;
            oRegla = adminService.AddRegla(oRegla);
            return oRegla.id > 0;
        }
        public bool ActualizarRegla(int pIdRegla, string pDescripcion, string pPalabra, bool pAgregar, bool pEditar, bool pEliminar, int pIdReglaPadre)
        {
            cRegla oRegla = new cRegla();
            oRegla.id = pIdRegla;
            oRegla.rgl_Descripcion = pDescripcion;
            oRegla.rgl_PalabraClave = pPalabra;
            oRegla.rgl_IsAgregarSoporta = pAgregar;
            oRegla.rgl_IsEditarSoporta = pEditar;
            oRegla.rgl_IsEliminarSoporta = pEliminar;
            oRegla.rgl_codReglaPadre = pIdReglaPadre;
            if (pIdRegla == 0)
            {
                oRegla = adminService.AddRegla(oRegla);
            }
            else
            {
                oRegla = adminService.EditRegla(pIdRegla, oRegla);
            }
            return oRegla.id > 0;
        }
        public cListaCheck RecuperarReglaRaiz()
        {
            cListaCheck resultado = null;
            List<cRegla> listaRegla = adminService.GetAllRegla().Where(x => x.rgl_codReglaPadre == null).ToList();
            if (listaRegla.Count > 0)
            {
                return ConvertToListaCheck(listaRegla[0]);
            }
            return resultado;
        }

        public cListaCheck RecuperarReglaPorId(int pIdRegla)
        {
            cListaCheck resultado = null;
            cRegla regla = adminService.GetOneRegla(pIdRegla);
            if (regla != null)
            {
                return ConvertToListaCheck(regla);
            }
            return resultado;
        }
        public bool EliminarRegla(int pIdRegla)
        {
            bool resultado = false;
            try
            {
                adminService.DeleteRegla(pIdRegla);
                resultado = true;
            }
            catch
            {
                resultado = false;
            }
            return resultado;
        }
        private cListaCheck ConvertToListaCheck(cRegla pRegla)
        {
            cListaCheck resultado = new cListaCheck();
            resultado.id = pRegla.rgl_codRegla;
            resultado.descripcion = pRegla.rgl_Descripcion;
            resultado.palabra = pRegla.rgl_PalabraClave;
            resultado.idPadreRegla = pRegla.rgl_codReglaPadre;
            if ((bool)pRegla.rgl_IsAgregarSoporta)
            {
                resultado.checkAgregar = 1;
            }
            else
            {
                resultado.checkAgregar = 0;
            }
            if ((bool)pRegla.rgl_IsEditarSoporta)
            {
                resultado.checkEditar = 1;
            }
            else
            {
                resultado.checkEditar = 0;
            }
            if ((bool)pRegla.rgl_IsEliminarSoporta)
            {
                resultado.checkEliminar = 1;
            }
            else
            {
                resultado.checkEliminar = 0;
            }
            List<cRegla> listaReglaParametro = adminService.GetAllRegla();
            resultado.listaIdHijas = adminService.GetAllIdReglasHijas(pRegla.rgl_codRegla, listaReglaParametro);
            return resultado;
        }
        [HttpGet]
        public IActionResult UsuarioIndex()
        {
            return View(adminService.GetAllUsuario());
        }
        [HttpGet]
        public IActionResult UsuarioDetails(int id)
        {
            ViewBag.comboRoles = adminService.GetAllRol().Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = x.rol_Nombre,
                Value = x.rol_codRol.ToString()
            });
            var o = adminService.GetOneUsuario(id);
            if (o == null)
            {
                return NotFound();
            }
            return View(o);
        }
        [HttpGet]
        public IActionResult UsuarioCreate()
        {
            ViewBag.comboRoles = adminService.GetAllRol().Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = x.rol_Nombre,
                Value = x.rol_codRol.ToString()
            });
            return View(new cUsuario());
        }
        [HttpPost]
        public IActionResult UsuarioCreate(cUsuario pUsuario)
        {
            if (ModelState.IsValid)
            {
                //pUsuario.usu_login = pUsuario.usu_mail;
                adminService.AddUsuario(pUsuario);
                return RedirectToAction("UsuarioIndex");
            }
            return View(pUsuario);
        }
        [HttpGet]
        public IActionResult UsuarioEdit(int id)
        {
            ViewBag.comboRoles = adminService.GetAllRol().Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = x.rol_Nombre,
                Value = x.rol_codRol.ToString()
            });
            var o = adminService.GetOneUsuario(id);
            if (o == null)
            {
                return NotFound();
            }
            return View(o);
        }
        [HttpPost]
        public IActionResult UsuarioEdit(int id, cUsuario pUsuario)
        {
            if (ModelState.IsValid)
            {
                //pUsuario.usu_login = pUsuario.usu_mail;
                var updated = adminService.EditUsuario(id, pUsuario);
                if (updated == null)
                {
                    return NotFound();
                }
                return RedirectToAction("UsuarioIndex");
            }
            return View(pUsuario);
        }
        [HttpGet]
        public IActionResult UsuarioDelete(int id)
        {
            ViewBag.comboRoles = adminService.GetAllRol().Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = x.rol_Nombre,
                Value = x.rol_codRol.ToString()
            });
            var o = adminService.GetOneUsuario(id);
            if (o == null)
            {
                return NotFound();
            }
            return View(o);
        }
        [HttpPost]
        public IActionResult UsuarioDeleteConfirmed(int id)
        {
            adminService.DeleteUsuario(id);
            return RedirectToAction("UsuarioIndex");
        }
        [HttpGet]
        public IActionResult ReglasRolIndex()
        {
            //  var ddd =   adminService.GetAllReglasRol (1);
            ViewBag.comboRoles = coreBasicNet5.Codigo.Serializador.SerializarAJson(adminService.GetAllRol().Select(x => new cCombo
            {
                nombre = x.rol_Nombre,
                id = x.rol_codRol
            }).ToList());
            ViewBag.ListaTodasReglasPorNivel = coreBasicNet5.Codigo.Serializador.SerializarAJson(adminService.GetAllReglaPorNivel());
            return View();//adminService.GetAllReglaPorNivel()
        }
    }
}