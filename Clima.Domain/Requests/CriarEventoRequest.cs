namespace Clima.Domain.Requests;

public class CriarEventoRequest
{
    public string Localidade { get; set; } = string.Empty;
    public DateTime DataHora { get; set; }
    public double Temperatura { get; set; }
    public double Umidade { get; set; }
    public double VelocidadeVento { get; set; }
    public double Precipitacao { get; set; }
}
