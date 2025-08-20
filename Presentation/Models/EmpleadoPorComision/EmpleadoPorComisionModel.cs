using PayrollManagementSystem.Models.Base;

namespace PayrollManagementSystem.Models.EmpleadoPorComision
{
    public class EmpleadoPorComisionModel : EmpleadoBaseModel
    {
        public EmpleadoPorComisionModel(
            string tipoDeEmpleado,
            string nombre,
            string apellido,
            int numeroDeSeguro,
            bool activo,
            decimal ventasBrutas,
           int tarifaPorComision )
            : base(tipoDeEmpleado, nombre, apellido, numeroDeSeguro, activo)
        {
            VentasBrutas = ventasBrutas;
            TarifaPorComision = tarifaPorComision;
        }

        public EmpleadoPorComisionModel()
        {
           
        }


        public decimal VentasBrutas { get; set; }
        
        public int TarifaPorComision { get; set; }
       

        public decimal CalcularPago()
        {
            return VentasBrutas * TarifaPorComision ;
        }
    }
}