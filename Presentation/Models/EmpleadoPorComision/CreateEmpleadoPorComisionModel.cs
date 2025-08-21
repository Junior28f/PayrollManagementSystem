using PayrollManagementSystem.Models.Base;

namespace PayrollManagementSystem.Models.EmpleadoPorComision;

public class CreateEmpleadoPorComisionModel: EmpleadoPorComisionModel
{
    public CreateEmpleadoPorComisionModel(string tipoDeEmpleado, string nombre, string apellido, 
        int numeroDeSeguro, bool activo, decimal ventasBrutas, int tarifaPorComision, decimal pagoSemanal) 
        : base(tipoDeEmpleado, nombre, apellido, numeroDeSeguro, activo, ventasBrutas,tarifaPorComision, pagoSemanal)
    {
    }

    public CreateEmpleadoPorComisionModel()
    {
     
    }

    public decimal VentaBruta { get; set; }
}