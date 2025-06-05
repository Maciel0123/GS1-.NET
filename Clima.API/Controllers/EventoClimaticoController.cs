using Clima.Application.UseCases;
using Clima.Domain.Requests;
using Clima.Domain.Responses;
using Clima.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Clima.Domain.Entities;


namespace Clima.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoClimaticoController : ControllerBase
{
    private readonly RegistrarEventoHandler _handler;

    public EventoClimaticoController(AppDbContext context)
    {
        _handler = new RegistrarEventoHandler(context);
    }

    [HttpPost]
    public IActionResult Post([FromBody] DadoClimatico dado)
    {
        var resultado = _handler.Execute(dado);
        return CreatedAtAction(nameof(Post), resultado);
    }

    [HttpGet]
    public ActionResult<IEnumerable<EventoClimaticoResponse>> Get()
    {
        return Ok(_handler.ListarEventos());
    }
}
