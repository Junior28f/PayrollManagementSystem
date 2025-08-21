using Domain.Base;
namespace Domain.entities;

public class EmpleadoPorhoras : Empleado
{
    public decimal SueldoPorhora { get; set; }
    public int HorasTrabajadas { get; set; }
 

public EmpleadoPorhoras(){}
    public EmpleadoPorhoras(String tipoDeEmpleado,string nombre, string apellido, int numeroDeSeguro, decimal sueldoPorhora,int horasTrabajadas, decimal pagoSemanal) 
        : base(tipoDeEmpleado,nombre, apellido, numeroDeSeguro, true, pagoSemanal)
    {
     
        this.SueldoPorhora = sueldoPorhora;
        this.HorasTrabajadas = horasTrabajadas;
    }

    public override decimal Calcularpago()
    {
        if (HorasTrabajadas <= 40)
        {
            return SueldoPorhora * HorasTrabajadas;
        }
        else
        {
            int horasExtras = HorasTrabajadas - 40;
            return (SueldoPorhora * 40) + (SueldoPorhora * 1.5m * horasExtras);
        }
    }

}

