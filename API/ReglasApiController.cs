using Microsoft.AspNetCore.Mvc;
using coreBasicNet5.Entities;
using System.Linq;
using coreBasicNet5.Business;

namespace coreBasicNet5.API
{
    [Route("/api/reglas")]
    [ApiController]
    public class ReglasApiController : ControllerBase
    {
        private readonly IAdminService adminService;

        public ReglasApiController(IAdminService adminService)
        {
            this.adminService = adminService;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var obj = adminService.GetOneRegla(id);

            if (obj == null)
            {
                return NotFound();
            }

            return Ok(obj);
        }
        [HttpGet]
        public IActionResult Get()
        {
            if (!string.IsNullOrEmpty( HttpContext.Request.Query["modo"]))
            {
                return Ok(adminService.GetAllReglaPorNivel());
            }
            return Ok(adminService.GetAllRegla());
        }

        [HttpPost]
        public IActionResult Create([FromBody]cRegla regla)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            regla = adminService.AddRegla(regla);

            return CreatedAtAction(nameof(Create), new { id = regla.id }, regla);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody]cRegla regla)
        {

            if (id != regla.id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var current = adminService.EditRegla(id, regla);

            if (current == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            adminService.DeleteRegla(id);
            return NoContent();
        }
    }
}