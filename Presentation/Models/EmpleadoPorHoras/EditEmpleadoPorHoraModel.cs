namespace PayrollManagementSystem.Models.EmpleadoPorHoras;

public class EditEmpleadoPorHoraModel: EmpleadoPorHoraModel
{
    public EditEmpleadoPorHoraModel(string tipoDeEmpleado, string nombre, string apellido, int numeroDeSeguro, bool activo,  int horasTrabajadas,decimal sueldoPorhora, decimal pagoSemanal) 
        : base(tipoDeEmpleado, nombre, apellido, numeroDeSeguro, activo,horasTrabajadas,sueldoPorhora, pagoSemanal)
    {
    }

    public EditEmpleadoPorHoraModel()
    {
        
    }
}