using Clima.Domain.Entities;
using Clima.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clima.MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return View(usuarios);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            Console.WriteLine("🟡 Entrou no POST /usuario/create");
            if (!ModelState.IsValid)
            {
                Console.WriteLine("🔴 ModelState inválido");
                return View(usuario);
            }

            Console.WriteLine($"🔵 Criando usuário: {usuario.Nome}, {usuario.Email}");
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            Console.WriteLine("✅ Usuário salvo no banco");

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return NotFound();
            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Usuario usuario)
        {
            if (id != usuario.Id) return BadRequest();

            if (!ModelState.IsValid) return View(usuario);

            _context.Update(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return NotFound();
            return View(usuario);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return NotFound();

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
            if (usuario == null) return NotFound();
            return View(usuario);
        }
    }
}
