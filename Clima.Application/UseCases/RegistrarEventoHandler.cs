using Clima.Domain.Entities;
using Clima.Infrastructure.Persistence;
using Clima.Service;

namespace Clima.Application.UseCases;

public class RegistrarEventoHandler
{
    private readonly AppDbContext _context;
    private readonly DadoClimaticoService _service;

    public RegistrarEventoHandler(AppDbContext context)
    {
        _context = context;
        _service = new DadoClimaticoService();
    }

    public DadoClimatico Execute(DadoClimatico request)
    {
        _context.DadosClimaticos.Add(request);
        _context.SaveChanges();

        return request;
    }

    public IEnumerable<DadoClimatico> ListarEventos()
    {
        return _context.DadosClimaticos
            .OrderByDescending(e => e.DataColeta)
            .ToList();
    }
}
