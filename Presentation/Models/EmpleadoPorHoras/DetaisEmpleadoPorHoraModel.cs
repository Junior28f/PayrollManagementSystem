namespace PayrollManagementSystem.Models.EmpleadoPorHoras;

public class DetaisEmpleadoPorHoraModel: EmpleadoPorHoraModel
{
    public DetaisEmpleadoPorHoraModel(string tipoDeEmpleado, string nombre, string apellido, int numeroDeSeguro, bool activo, decimal tarifaPorHora, int horasTrabajadas) 
        : base(tipoDeEmpleado, nombre, apellido, numeroDeSeguro, activo, tarifaPorHora, horasTrabajadas)
    {
    }
}