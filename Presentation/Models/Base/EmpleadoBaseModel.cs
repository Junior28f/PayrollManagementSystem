using System.ComponentModel.DataAnnotations;

namespace PayrollManagementSystem.Models.Base;

public abstract class EmpleadoBaseModel
{
    protected EmpleadoBaseModel(string tipoDeEmpleado, string nombre, string apellido, int numeroDeSeguro, bool activo)
    {
        TipoDeEmpleado = tipoDeEmpleado;
        Nombre = nombre;
        Apellido = apellido;
        NumeroDeSeguro = numeroDeSeguro;
        Activo = activo;
    }

    protected EmpleadoBaseModel()
    {
       
    }

    public string TipoDeEmpleado { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }

    [Key]
    public int NumeroDeSeguro { get; set; }

    public bool Activo { get; set; }
}