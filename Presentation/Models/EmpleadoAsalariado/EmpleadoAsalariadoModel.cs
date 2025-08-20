using PayrollManagementSystem.Models.Base;

namespace PayrollManagementSystem.Models.EmpleadoAsalariado
{
    public class EmpleadoAsalariadoModel : EmpleadoBaseModel
    {
        public EmpleadoAsalariadoModel(
            string tipoDeEmpleado,
            string nombre,
            string apellido,
            int numeroDeSeguro,
            bool activo,
            decimal salarioSemanal)
            : base(tipoDeEmpleado, nombre, apellido, numeroDeSeguro, activo)
        {
            SalarioSemanal = salarioSemanal;
        }
        
        public EmpleadoAsalariadoModel() : base() { } 

        public decimal SalarioSemanal { get; set; }
        
    }
}