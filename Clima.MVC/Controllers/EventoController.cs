using Clima.Domain.Entities;
using Clima.Domain.Responses;
using Clima.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clima.MVC.Controllers
{
    public class EventoController : Controller
    {
        private readonly AppDbContext _context;

        public EventoController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var dados = _context.DadosClimaticos
                .Include(e => e.Dispositivo)
                .OrderByDescending(e => e.DataColeta)
                .ToList();

            var eventos = dados.Select(e => new EventoClimaticoResponse
            {
                DataHora = e.DataColeta,
                Localidade = e.Cidade ?? e.Dispositivo?.Localizacao ?? "Desconhecida",
                Temperatura = e.Temperatura ?? 0,
                Umidade = e.Umidade ?? 0,
                Precipitacao = (e.Chuva1h ?? 0) + (e.Chuva3h ?? 0),
                VelocidadeVento = e.VentoVelocidade ?? 0,
                Condicao = e.DescricaoClima ?? "Sem descrição",
                Alerta = (e.Temperatura > 30) ? "⚠️ Atenção: Calor extremo"
                        : ((e.DescricaoClima?.ToLower().Contains("chuva") ?? false) || ((e.Chuva1h ?? 0) > 5))
                            ? "🔴 Perigo: Chuva intensa"
                            : "🟢 Clima estável"
            }).ToList();

            return View(eventos);
        }
    }
}
