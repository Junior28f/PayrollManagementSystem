namespace PayrollManagementSystem.Models.EmpleadoAsalariado;

public class DisableEmpleadoAsalariado : EmpleadoAsalariadoModel
{
    public DisableEmpleadoAsalariado(string tipoDeEmpleado, string nombre, string apellido, int numeroDeSeguro,
        bool activo, decimal salarioSemanal, decimal pagoSemanal)
        : base(tipoDeEmpleado, nombre, apellido, numeroDeSeguro, activo, salarioSemanal, pagoSemanal)
    {
    }
    public decimal Salariosemanal1 { get; set; }

    public DisableEmpleadoAsalariado()
    {
    }
}