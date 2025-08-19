using Domain.Base;
namespace Domain.entities;

public class EmpleadoPorhoras : Empleado
{
    public decimal SueldoPorhora { get; set; }
    public int HorasTrabajadas { get; set; }
 


    public EmpleadoPorhoras(String tipoDeEmpleado,string nombre, string apellido, int numeroDeSeguro, decimal sueldoPorhora,int horasTrabajadas) 
        : base(tipoDeEmpleado,nombre, apellido, numeroDeSeguro, true)
    {
     
        this.SueldoPorhora = sueldoPorhora;
        this.HorasTrabajadas = horasTrabajadas;
    }

    public override decimal Calcularpago()
    {
        if (HorasTrabajadas <= 40)
        {
            return (decimal)(SueldoPorhora * HorasTrabajadas);
        }
        else
        {
            
            return (decimal)((SueldoPorhora * 40) + (SueldoPorhora * (decimal)1.5 * HorasTrabajadas -40));
        }

        
    }
}

