namespace Clima.Domain.Responses;

public class EventoClimaticoResponse
{
    public DateTime DataHora { get; set; }
    public string Localidade { get; set; }
    public double Temperatura { get; set; }
    public double Umidade { get; set; }
    public double Precipitacao { get; set; }
    public double VelocidadeVento { get; set; }
    public string Condicao { get; set; }
    public string Alerta { get; set; } // ← Aqui é onde entra o alerta
}

