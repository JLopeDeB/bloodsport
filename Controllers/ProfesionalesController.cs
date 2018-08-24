using Microsoft.AspNetCore.Mvc;
using BloodsportApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;

//Agregar validaciones para existencia de IdUsuario y IdEspecialidad. O tal vez se haga en el front-end?
namespace BloodsportApi.Controllers
{
    [Route("api/profesionales")]
    [ApiController]
    public class ProfesionalesController : Controller
    {
        private readonly BloodsportContext _context;

        public ProfesionalesController(BloodsportContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(await _context.Profesional.ToListAsync());
        }

        [HttpGet("{id_profesional}", Name = "GetProfesional")]
        public async Task<IActionResult> GetById(int id_profesional)
        {
            var profesional = await _context.Profesional.FindAsync(id_profesional);
            if (profesional == null)
            {
                return NotFound();
            }   
        return Json(profesional);
        }  

        [HttpPost]
        public async Task<IActionResult> Create(Profesional profesional)
        {
            _context.Profesional.Add(profesional);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetProfesional", new { id_profesional = profesional.IdProfesional }, profesional);
        }
        
        [HttpPatch("{id_profesional}")]
        public async Task<IActionResult> Patch(int id_profesional, [FromBody]JsonPatchDocument<Profesional> prfPatch)
        {
            var prf = await _context.Profesional.SingleOrDefaultAsync(p => p.IdProfesional == id_profesional);
            if (prf == null)
            {
                return NotFound();
            }
            prfPatch.ApplyTo(prf);
            await TryUpdateModelAsync((Profesional)prf, "", p => p.IdEspecialidad,
                                                            p => p.Matricula);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id_profesional}")]
        public async Task<IActionResult> Delete(int id_profesional)
        {
            var prf = await _context.Profesional.FindAsync(id_profesional);
            if (prf == null)
            {
                return NotFound();
            }

            _context.Profesional.Remove(prf);
            await _context.SaveChangesAsync();
            return NoContent();
        }   
    }
}