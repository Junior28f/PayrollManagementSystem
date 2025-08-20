namespace PayrollManagementSystem.Models.EmpleadoPorComision;

public class EditEmpleadoPorComisionModel: EmpleadoPorComisionModel
{
    public EditEmpleadoPorComisionModel(string tipoDeEmpleado, string nombre, string apellido, int numeroDeSeguro, bool activo, decimal ventasBrutas, int tarifaPorComision) : base(tipoDeEmpleado, nombre, apellido, numeroDeSeguro, activo, ventasBrutas, tarifaPorComision)
    {
    }

    public EditEmpleadoPorComisionModel()
    {
       
    }
}