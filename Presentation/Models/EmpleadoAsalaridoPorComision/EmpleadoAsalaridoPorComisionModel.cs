using System.ComponentModel.DataAnnotations;
using PayrollManagementSystem.Models.Base;

namespace PayrollManagementSystem.Models.EmpleadoAsalaridoPorComision
{
    public class EmpleadoAsalaridoPorComisionModel : EmpleadoBaseModel
    {
        public EmpleadoAsalaridoPorComisionModel(
            string tipoDeEmpleado,
            string nombre,
            string apellido,
            int numeroDeSeguro,
            bool activo,
            int salarioBase,
            decimal ventaBruta,
            decimal tarifaPorComision,
            decimal pagoSemanal)
            : base(tipoDeEmpleado, nombre, apellido, numeroDeSeguro, activo, pagoSemanal)
        {
            SalarioBase = salarioBase;
            VentaBruta = ventaBruta;
            TarifaPorComision = (int)tarifaPorComision;
        }

        public EmpleadoAsalaridoPorComisionModel()
        {
        }

        public int SalarioBase { get; set; }
        public decimal VentaBruta { get; set; }
        public int TarifaPorComision { get; set; }

        public decimal CalcularPago()
        {
            return SalarioBase + (VentaBruta * TarifaPorComision);
        }

       
    }
}