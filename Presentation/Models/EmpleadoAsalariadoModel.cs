using System.ComponentModel.DataAnnotations;

namespace PayrollManagementSystem.Models;
public class EmpleadoAsalariadoModel
{
    public string? TipoDeEmpleado { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }

    [Key]
    public int NumeroDeSeguro { get; set; }

    public bool Activo { get; set; }
    public decimal Salariosemanal1 { get; set; }  
    public EmpleadoAsalariadoModel() { } 

    public EmpleadoAsalariadoModel(string tipoDeEmpleado, string nombre, string apellido, int numeroDeSeguro, bool activo, decimal salariosemanal1)
    {
        TipoDeEmpleado = tipoDeEmpleado;
        Nombre = nombre;
        Apellido = apellido;
        NumeroDeSeguro = numeroDeSeguro;
        Activo = activo;
        Salariosemanal1 = salariosemanal1;
    }
}