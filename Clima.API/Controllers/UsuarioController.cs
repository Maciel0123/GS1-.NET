using Clima.Domain.Entities;
using Clima.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clima.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Usuario usuario)
        {
            if (id != usuario.Id) return BadRequest();

            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return NotFound();

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
