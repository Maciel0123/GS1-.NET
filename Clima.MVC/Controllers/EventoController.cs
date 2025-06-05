using Clima.Domain.Entities;
using Clima.Domain.Responses;
using Clima.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace Clima.MVC.Controllers;

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

        Console.WriteLine($"🔎 Quantidade de dados climáticos retornados: {dados.Count}");

        // Log os dados no console para validar
        foreach (var d in dados)
        {
            Console.WriteLine($"➡ {d.DataColeta} | {d.Cidade} | {d.Temperatura}");
        }

        var eventos = dados.Select(e => new EventoClimaticoResponse
        {
            DataHora = e.DataColeta,
            Localidade = e.Cidade ?? e.Dispositivo?.Localizacao ?? "Desconhecida",
            Temperatura = e.Temperatura ?? 0,
            Umidade = e.Umidade ?? 0,
            Precipitacao = (e.Chuva1h ?? 0) + (e.Chuva3h ?? 0),
            VelocidadeVento = e.VentoVelocidade ?? 0,
            Condicao = e.DescricaoClima ?? "Sem descrição"
        }).ToList();

        return View(eventos);
    }
}

