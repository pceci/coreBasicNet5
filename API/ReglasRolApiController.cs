using System.Linq;
using coreBasicNet5.Business;
using coreBasicNet5.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace coreBasicNet5.API
{
    [Route("/api/reglasrol")]
    [ApiController]
    public class ReglasRolApiController : ControllerBase
    {
        private readonly IAdminService adminService;

        public ReglasRolApiController(IAdminService adminService)
        {
            this.adminService = adminService;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var obj = adminService.GetAllReglasRol(id);

            if (obj == null)
            {
                return NotFound();
            }

            return Ok(obj);
        }
        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody]List<cReglaPorRol> reglasRol)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (reglasRol != null && reglasRol.Count > 0)
            {
                var current = adminService.EditReglasRol(id, reglasRol);
                // if (!current)
                // {
                //     return NotFound();
                // }
            }
            return NoContent();
        }

    }
}