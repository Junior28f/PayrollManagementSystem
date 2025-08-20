using PayrollManagementSystem.Models.Base;

namespace PayrollManagementSystem.Models.EmpleadoPorComision;

public class CreateEmpleadoPorComisionModel: EmpleadoPorComisionModel
{
    public CreateEmpleadoPorComisionModel(string tipoDeEmpleado, string nombre, string apellido, int numeroDeSeguro, bool activo, decimal ventasBrutas, int tarifaPorComision) 
        : base(tipoDeEmpleado, nombre, apellido, numeroDeSeguro, activo, ventasBrutas,tarifaPorComision )
    {
    }

    public CreateEmpleadoPorComisionModel()
    {
     
    }

    public decimal VentaBruta { get; set; }
}