namespace PayrollManagementSystem.Models.EmpleadoAsalariado;

public class DetailsEmpleadoAsalariadoModel : EmpleadoAsalariadoModel
{
    public DetailsEmpleadoAsalariadoModel(string tipoDeEmpleado, string nombre, string apellido, int numeroDeSeguro, bool activo, decimal salarioSemanal, decimal pagoSemanal)
        : base(tipoDeEmpleado, nombre, apellido, numeroDeSeguro, activo, salarioSemanal, pagoSemanal)
    {
    }
   
    public decimal SueldoPorhora { get; set; }
    public int HorasTrabajadas { get; set; }

    public DetailsEmpleadoAsalariadoModel()
    {
    }
}