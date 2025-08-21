using Domain.Base;

namespace Domain.entities
{
    public class EmpleadoAsalariado : Empleado
    {
        public decimal SalarioSemanal { get; set; }
        


        public EmpleadoAsalariado() : base() 
        {
            TipoDeEmpleado = "Empleado Asalariado";
        }

        public EmpleadoAsalariado(string tipoDeEmpleado1, string nombre, string apellido, int numeroDeSeguro,
            decimal salarioSemanal)
            : base("Empleado Asalariado", nombre, apellido, numeroDeSeguro, true, salarioSemanal)
        {
            SalarioSemanal = salarioSemanal;
        }

        public override decimal Calcularpago()
        {
            return SalarioSemanal;
        }
    }
}