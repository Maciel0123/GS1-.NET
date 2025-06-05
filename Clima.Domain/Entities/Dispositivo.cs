using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clima.Domain.Entities;

[Table("DISPOSITIVO")]
public class Dispositivo
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("IDENTIFICADOR")]
    public string Identificador { get; set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    [Column("LOCALIZACAO")]
    public string Localizacao { get; set; } = string.Empty;

    [Column("LATITUDE")]
    public double? Latitude { get; set; }

    [Column("LONGITUDE")]
    public double? Longitude { get; set; }

    [Required]
    [MaxLength(20)]
    [Column("STATUS")]
    public string Status { get; set; } = "ATIVO";

    [Column("ULTIMA_CONEXAO")]
    public DateTime? UltimaConexao { get; set; }

    public ICollection<DadoClimatico> DadosClimaticos { get; set; } = new List<DadoClimatico>();
}
