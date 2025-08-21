using System.ComponentModel.DataAnnotations;

namespace PayrollManagementSystem.Models.Base;

public abstract class EmpleadoBaseModel
{
    public string TipoDeEmpleado { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }

    [Key]
    public int NumeroDeSeguro { get; set; }

    public bool Activo { get; set; }
    public decimal PagoSemanal { get; set; }
    protected EmpleadoBaseModel(string tipoDeEmpleado, string nombre, string apellido,
        int numeroDeSeguro, bool activo, decimal pagoSemanal)
    {
        TipoDeEmpleado = tipoDeEmpleado;
        Nombre = nombre;
        Apellido = apellido;
        NumeroDeSeguro = numeroDeSeguro;
        Activo = activo;
        PagoSemanal = pagoSemanal;
    }

    protected EmpleadoBaseModel()
    {
       
    }

    
}