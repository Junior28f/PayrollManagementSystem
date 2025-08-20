namespace PayrollManagementSystem.Models.EmpleadoPorHoras;

public class DisableEmpleadoPorHoraModel: EmpleadoPorHoraModel
{
    public DisableEmpleadoPorHoraModel(string tipoDeEmpleado, string nombre, string apellido, int numeroDeSeguro, bool activo, decimal tarifaPorHora, int horasTrabajadas) 
        : base(tipoDeEmpleado, nombre, apellido, numeroDeSeguro, activo, tarifaPorHora, horasTrabajadas)
    {
    }

    public DisableEmpleadoPorHoraModel()
    {
        
    }
}