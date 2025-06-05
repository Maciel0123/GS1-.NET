using Clima.Domain.Entities;

namespace Clima.Service;

public class DadoClimaticoService
{
    public string CalcularCondicao(DadoClimatico dado)
    {
        if (dado.Temperatura > 40)
            return "Calor extremo";

        if (dado.Chuva1h > 50)
            return "Possibilidade de enchente";

        return "Clima estável";
    }
}
