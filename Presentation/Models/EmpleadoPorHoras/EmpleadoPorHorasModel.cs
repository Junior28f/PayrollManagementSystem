using PayrollManagementSystem.Models.Base;

namespace PayrollManagementSystem.Models.EmpleadoPorHoras
{
    public class EmpleadoPorHoraModel : EmpleadoBaseModel
    {
      
        public int HorasTrabajadas { get; set; }
        public decimal SueldoPorhora { get; set; }
        

        public EmpleadoPorHoraModel(
            string tipoDeEmpleado,
            string nombre,
            string apellido,
            int numeroDeSeguro,
            bool activo,
            int horasTrabajadas,
            decimal sueldoPorhora,
            decimal pagoSemanal)
            : base(tipoDeEmpleado, nombre, apellido, numeroDeSeguro, activo, pagoSemanal)
        {
          HorasTrabajadas = horasTrabajadas;
          SueldoPorhora = SueldoPorhora;
          
        }

        public EmpleadoPorHoraModel()
        {
          
        }
        public decimal CalcularPago()
        {
            if (HorasTrabajadas <= 40)
            {
                return SueldoPorhora * HorasTrabajadas;
            }
            else
            {
                var horasExtras = HorasTrabajadas - 40;
                var pagoRegular = SueldoPorhora * 40;
                var pagoExtra = SueldoPorhora * 1.5m * horasExtras;
                return pagoRegular + pagoExtra;
            }
        }

        }
       
       
    }
 

