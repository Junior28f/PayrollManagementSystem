namespace PayrollManagementSystem.Models.EmpleadoPorComision;

public class DetaisEmpleadoPorComisionModel: EmpleadoPorComisionModel
{
    public DetaisEmpleadoPorComisionModel(string tipoDeEmpleado, string nombre, string apellido, int numeroDeSeguro, bool activo, decimal ventasBrutas, int tarifaPorComision) : base(tipoDeEmpleado, nombre, apellido, numeroDeSeguro, activo, ventasBrutas, tarifaPorComision)
    {
    }
}