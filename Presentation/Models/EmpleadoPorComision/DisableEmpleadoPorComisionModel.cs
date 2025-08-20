namespace PayrollManagementSystem.Models.EmpleadoPorComision;

public class DisableEmpleadoPorComisionModel : EmpleadoPorComisionModel
{
    public DisableEmpleadoPorComisionModel(string tipoDeEmpleado, string nombre, string apellido, int numeroDeSeguro, bool activo, decimal ventasBrutas, int tarifaPorComision) 
        : base(tipoDeEmpleado, nombre, apellido, numeroDeSeguro, activo, ventasBrutas, tarifaPorComision)
    {
    }

    public DisableEmpleadoPorComisionModel()
    {
      
    }
}