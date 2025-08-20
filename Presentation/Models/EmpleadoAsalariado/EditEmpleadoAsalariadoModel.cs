namespace PayrollManagementSystem.Models.EmpleadoAsalariado;

public class EditEmpleadoAsalariadoModel : EmpleadoAsalariadoModel
{
    public EditEmpleadoAsalariadoModel(string tipoDeEmpleado, string nombre, string apellido, int numeroDeSeguro, bool activo, decimal salarioSemanal)
        : base(tipoDeEmpleado, nombre, apellido, numeroDeSeguro, activo, salarioSemanal)
    {
    }

    public EditEmpleadoAsalariadoModel()
    {
    }

    public decimal Salariosemanal1 { get; set; }
}
