using Domain.Base;

namespace Domain.entities;


public class EmpleadoPorComision : Empleado
{
    public decimal VentaBruta { get; set; }
    public int TarifaPorComision { get; set; }
   
     

    public EmpleadoPorComision(string tipoDeEmpleado,string nombre, string apellido, int numeroDeSeguro,
        int tarifaPorComision, decimal ventaBruta )
        : base(tipoDeEmpleado,nombre, apellido, numeroDeSeguro,true)
    {
        
        this.TarifaPorComision = tarifaPorComision;
        this.VentaBruta = ventaBruta;
    }

    public override decimal Calcularpago()
    {
        return VentaBruta * TarifaPorComision;
    }
    
}