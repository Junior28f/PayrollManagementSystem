namespace PayrollManagementSystem.Models.EmpleadoPorHoras;

public class CreateEmpleadoPorHoraModel: EmpleadoPorHoraModel
{
    public CreateEmpleadoPorHoraModel(string tipoDeEmpleado, string nombre, string apellido, int numeroDeSeguro, bool activo, decimal tarifaPorHora, int horasTrabajadas)
        : base(tipoDeEmpleado, nombre, apellido, numeroDeSeguro, activo, tarifaPorHora, horasTrabajadas)
    {
    }

    public CreateEmpleadoPorHoraModel()
    {
        
    }
}