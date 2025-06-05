namespace Clima.MVC.Models.Responses;

public class EventoClimaticoViewModel
{
    public DateTime DataHora { get; set; }
    public string Localidade { get; set; } = string.Empty;
    public double Temperatura { get; set; }
    public double Umidade { get; set; }
    public double VelocidadeVento { get; set; }
    public double Precipitacao { get; set; }
    public string Condicao { get; set; } = string.Empty;
}
