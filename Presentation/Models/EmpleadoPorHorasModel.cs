using System.ComponentModel.DataAnnotations;

namespace PayrollManagementSystem.Models;

public class EmpleadoPorHorasModel
{
    public string? TipoDeEmpleado { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }

    [Key]
    public int NumeroDeSeguro { get; set; }

    public bool Activo { get; set; }
    public decimal SueldoPorhora { get; set; }
    public int HorasTrabajadas { get; set; }
}