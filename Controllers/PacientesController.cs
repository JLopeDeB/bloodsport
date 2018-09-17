using Microsoft.AspNetCore.Mvc;
using BloodsportApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;

namespace BloodsportApi.Controllers
{
    [Route("api/pacientes")]
    [ApiController]
    public class PacientesController : Controller
    {
        private readonly BloodsportContext _context;

        public PacientesController(BloodsportContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(await _context.Paciente.ToListAsync());
        }

        [HttpGet("{id_paciente}", Name = "GetPaciente")]
        public async Task<IActionResult> GetById(int id_paciente)
        {
            var paciente = await _context.Paciente.FindAsync(id_paciente);
            if (paciente == null)
            {
                return NotFound();
            }   
        return Json(paciente);
        }  

        [HttpPost]
        public async Task<IActionResult> Create(Paciente paciente)
        {
            _context.Paciente.Add(paciente);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetPaciente", new { id_paciente = paciente.IdPaciente }, paciente);
        }
        
        [HttpPatch("{id_paciente}")]
        public async Task<IActionResult> Patch(int id_paciente, [FromBody]JsonPatchDocument<Paciente> ptePatch)
        {
            var pte = await _context.Paciente.SingleOrDefaultAsync(p => p.IdPaciente == id_paciente);
            if (pte == null)
            {
                return NotFound();
            }
            ptePatch.ApplyTo(pte);
            await TryUpdateModelAsync((Paciente)pte, "", p => p.Apellido,
                                                         p => p.Nombre,
                                                         p => p.Dni,
                                                         p => p.FechaNacimiento,
                                                         p => p.IdProfesionalCabecera);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id_paciente}")]
        public async Task<IActionResult> Delete(int id_paciente)
        {
            var pte = await _context.Paciente.FindAsync(id_paciente);
            if (pte == null)
            {
                return NotFound();
            }

            _context.Paciente.Remove(pte);
            await _context.SaveChangesAsync();
            return NoContent();
        }   
    }
}