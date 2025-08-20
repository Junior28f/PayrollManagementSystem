namespace PayrollManagementSystem.Models.EmpleadoAsalariado;

public class DetailsEmpleadoAsalariadoModel : EmpleadoAsalariadoModel
{
    public DetailsEmpleadoAsalariadoModel(string tipoDeEmpleado, string nombre, string apellido, int numeroDeSeguro, bool activo, decimal salarioSemanal)
        : base(tipoDeEmpleado, nombre, apellido, numeroDeSeguro, activo, salarioSemanal)
    {
    }
   
    public decimal SueldoPorhora { get; set; }
    public int HorasTrabajadas { get; set; }

    public DetailsEmpleadoAsalariadoModel()
    {
    }
}