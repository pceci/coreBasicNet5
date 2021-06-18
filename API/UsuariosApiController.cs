using Microsoft.AspNetCore.Mvc;
using coreBasicNet5.Entities;
using System.Linq;
using coreBasicNet5.Business;

namespace coreBasicNet5.API
{
    [Route("/api/usuarios")]
    [ApiController]
    public class UsuariosApiController : ControllerBase
    {
        private readonly IAdminService adminService;
        public UsuariosApiController(IAdminService adminService)
        {
            this.adminService = adminService;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var obj = adminService.GetOneUsuario(id);
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }
        [HttpGet]
        public IActionResult Get() => Ok(adminService.GetAllUsuario());
        [HttpPost]
        public IActionResult Create([FromBody]cUsuario pObj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            pObj = adminService.AddUsuario(pObj);
            return CreatedAtAction(nameof(Create), new { id = pObj.id }, pObj);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody]cUsuario pObj)
        {
            if (id != pObj.id)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var current = adminService.EditUsuario( id, pObj);
            if (current == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            adminService.DeleteUsuario(id);
            return NoContent();
        }
    }
}