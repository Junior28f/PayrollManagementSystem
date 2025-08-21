using System.ComponentModel.DataAnnotations;

namespace Domain.Base
{
    public abstract class Empleado
    {
        private int tipoDeEmpleado;
 

        public string TipoDeEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        [Key]
        public int NumeroDeSeguro { get; set; }

        public bool Activo { get; set; }
        public decimal PagoSemanal { get; set; }
        
        public Empleado(){}

        // Constructor
        protected Empleado(string tipoDeEmpleado, string nombre, string apellido, int numeroDeSeguro, bool activo, decimal pagoSemanal )
        {
            TipoDeEmpleado = tipoDeEmpleado;
            Nombre = nombre;
            Apellido = apellido;
            NumeroDeSeguro = numeroDeSeguro;
            Activo = activo;
            PagoSemanal = pagoSemanal;
  
        }

        protected Empleado(int tipoDeEmpleado, string nombre, string apellido, int numeroDeSeguro, bool v)
        {
            this.tipoDeEmpleado = tipoDeEmpleado;
            Nombre = nombre;
            Apellido = apellido;
            NumeroDeSeguro = numeroDeSeguro;
           
        }

        public abstract decimal Calcularpago();
    }
}