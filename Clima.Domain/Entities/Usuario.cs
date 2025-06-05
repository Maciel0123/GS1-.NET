using System.ComponentModel.DataAnnotations;

namespace Clima.Domain.Entities;

public class Usuario
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo Email é obrigatório")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo Nome é obrigatório")]
    public string Nome { get; set; } = string.Empty;
}
