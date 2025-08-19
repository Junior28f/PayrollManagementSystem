using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1.Dtos;

public record GetActiveEmpleadoAsalariadoDto : BaseDto
{
    public string TipoDeEmpleado { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }

    [Key]
    public int NumeroDeSeguro { get; set; }

    public bool Activo { get; set; }
    
}