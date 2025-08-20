using Domain.Base;

namespace Domain.entities;

public class EmpleadoAsalariado : Empleado
{
    public decimal Salariosemanal1 { get; set; }

    public EmpleadoAsalariado() : base() { } 

    public EmpleadoAsalariado(string tipoDeEmpleado, string nombre, string apellido, int numeroDeSeguro, decimal salariosemanal1)
        : base(tipoDeEmpleado, nombre, apellido, numeroDeSeguro, true)
    {
        this.TipoDeEmpleado = "Empleado Asalariado";
        this.Salariosemanal1 = salariosemanal1;
    }

    public override decimal Calcularpago()
    {
        return Salariosemanal1;
    }
}
