using Microsoft.AspNetCore.Mvc;
using BloodsportApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;

namespace BloodsportApi.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private readonly BloodsportContext _context;

        public UsuariosController(BloodsportContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(await _context.Usuario.ToListAsync());
        }

        [HttpGet("{id_usuario}", Name = "GetUsuario")]
        public async Task<IActionResult> GetById(int id_usuario)
        {
            var usuario = await _context.Usuario.FindAsync(id_usuario);
            if (usuario == null)
            {
                return NotFound();
            }   
        return Json(usuario);
        }  

        [HttpPost]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetUsuario", new { id_usuario = usuario.IdUsuario }, usuario);
        }
        
        [HttpPatch("{id_usuario}")]
        public async Task<IActionResult> Patch(int id_usuario, [FromBody]JsonPatchDocument<Usuario> usrPatch)
        {
            var usr = await _context.Usuario.SingleOrDefaultAsync(u => u.IdUsuario == id_usuario);
            if (usr == null)
            {
                return NotFound();
            }
            usrPatch.ApplyTo(usr);
            await TryUpdateModelAsync<Usuario>(usr, "", u => u.Apellido,
                                                        u => u.Nombre,
                                                        u => u.Dni,
                                                        u => u.Email,
                                                        u => u.Celular);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id_usuario}")]
        public async Task<IActionResult> Delete(int id_usuario)
        {
            var usr = await _context.Usuario.FindAsync(id_usuario);
            if (usr == null)
            {
                return NotFound();
            }

            _context.Usuario.Remove(usr);
            await _context.SaveChangesAsync();
            return NoContent();
        }   
    }
}