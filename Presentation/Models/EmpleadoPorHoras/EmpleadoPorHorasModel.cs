using PayrollManagementSystem.Models.Base;

namespace PayrollManagementSystem.Models.EmpleadoPorHoras
{
    public class EmpleadoPorHoraModel : EmpleadoBaseModel
    {
        public EmpleadoPorHoraModel(
            string tipoDeEmpleado,
            string nombre,
            string apellido,
            int numeroDeSeguro,
            bool activo,
            decimal tarifaPorHora,
            int horasTrabajadas)
            : base(tipoDeEmpleado, nombre, apellido, numeroDeSeguro, activo)
        {
            TarifaPorHora = tarifaPorHora;
            HorasTrabajadas = horasTrabajadas;
        }

        public EmpleadoPorHoraModel()
        {
          
        }

        public decimal TarifaPorHora { get; set; }
        public int HorasTrabajadas { get; set; }
        public decimal SueldoPorhora { get; set; }
    }
}