using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1.Dtos;

public record CreateEmpleadoPorComisionDto
{
    public string TipoDeEmpleado { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }

    [Key]
    public int NumeroDeSeguro { get; set; }
    public int SalarioBase { get; set; }
    public int VentaBruta { get; set; }
    public int TarifaPorComision { get; set; }
    public decimal PagoSemanal { get; set; }
}