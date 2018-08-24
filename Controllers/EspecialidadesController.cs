using Microsoft.AspNetCore.Mvc;
using BloodsportApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;

namespace BloodsportApi.Controllers
{
    [Route("api/especialidades")]
    [ApiController]
    public class EspecialidadesController : Controller
    {
        private readonly BloodsportContext _context;

        public EspecialidadesController(BloodsportContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(await _context.Especialidad.ToListAsync());
        }

        [HttpGet("{id_especialidad}", Name = "GetEspecialidad")]
        public async Task<IActionResult> GetById(short id_especialidad)
        {
            var especialidad = await _context.Especialidad.FindAsync(id_especialidad);
            if (especialidad == null)
            {
                return NotFound();
            }   
        return Json(especialidad);
        }  

        [HttpPost]
        public async Task<IActionResult> Create(Especialidad especialidad)
        {
            _context.Especialidad.Add(especialidad);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetEspecialidad", new { id_especialidad = especialidad.IdEspecialidad }, especialidad);
        }
        
        [HttpPatch("{id_especialidad}")]
        public async Task<IActionResult> Patch(short id_especialidad, [FromBody]JsonPatchDocument<Especialidad> espPatch)
        {
            var esp = await _context.Especialidad.SingleOrDefaultAsync(e => e.IdEspecialidad == id_especialidad);
            if (esp == null)
            {
                return NotFound();
            }
            espPatch.ApplyTo(esp);
            await TryUpdateModelAsync((Especialidad)esp, "", e => e.NombreEspecialidad);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id_especialidad}")]
        public async Task<IActionResult> Delete(short id_especialidad)
        {
            var esp = await _context.Especialidad.FindAsync(id_especialidad);
            if (esp == null)
            {
                return NotFound();
            }

            _context.Especialidad.Remove(esp);
            await _context.SaveChangesAsync();
            return NoContent();
        }   
    }
}