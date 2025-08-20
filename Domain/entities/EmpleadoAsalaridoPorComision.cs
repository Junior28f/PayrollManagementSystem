using Domain.Base;

namespace Domain.entities;
public class EmpleadoAsalaridoPorComision : Empleado
{
    public int SalarioBase { get; set; }
    public decimal VentaBruta { get; set; }
    public int TarifaPorComision { get; set; }
    
    
   
    public EmpleadoAsalaridoPorComision() : base() { }
   
    public EmpleadoAsalaridoPorComision(string tipoDeEmpleado, string nombre, string apellido, int numeroDeSeguro, int salarioBase, decimal ventaBruta, int tarifaPorComision)
        : base(tipoDeEmpleado, nombre, apellido, numeroDeSeguro, true)
    {
        this.SalarioBase = salarioBase;
        this.VentaBruta = ventaBruta;
        this.TarifaPorComision = tarifaPorComision;
    }

    public override decimal Calcularpago()
    {
        return (decimal)((VentaBruta * TarifaPorComision) + SalarioBase + (decimal)(SalarioBase * 0.10));
    }
}
