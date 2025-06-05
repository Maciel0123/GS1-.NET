namespace Clima.Domain.Entities;

public class DadoClimatico
{
    public int Id { get; set; }  // id_dado
    public int DispositivoId { get; set; }
    public Dispositivo Dispositivo { get; set; } = null!;

    public DateTime DataColeta { get; set; }
    public double? Temperatura { get; set; }
    public double? Umidade { get; set; }
    public double? Chuva1h { get; set; }
    public double? Chuva3h { get; set; }
    public double? VentoVelocidade { get; set; }
    public string? DescricaoClima { get; set; }
    public string? Cidade { get; set; }
    public double? LatApi { get; set; }
    public double? LonApi { get; set; }
}
