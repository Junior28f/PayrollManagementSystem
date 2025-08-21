using Domain.Base;

namespace Domain.entities;


public class EmpleadoPorComision : Empleado
{
    public decimal VentaBruta { get; set; }
    public int TarifaPorComision { get; set; }
   


    public EmpleadoPorComision() : base() { }
    public EmpleadoPorComision(string tipoDeEmpleado,string nombre, string apellido, int numeroDeSeguro,
        int tarifaPorComision, decimal ventaBruta, decimal pagoSemanal )
        : base(tipoDeEmpleado,nombre, apellido, numeroDeSeguro,true,  pagoSemanal)
    {
        
        this.TarifaPorComision = tarifaPorComision;
        this.VentaBruta = ventaBruta;
    }

    public override decimal Calcularpago()
    {
        return VentaBruta * TarifaPorComision;
    }
    
}