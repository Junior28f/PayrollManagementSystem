using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1.Dtos
{
    public record UpdateEmpleadoPorComisionDto
    {
        
        [Key]
        public int NumeroDeSeguro { get; set; }
        
        public string? TipoDeEmpleado { get; set; }
        
        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public bool? Activo { get; set; }
        public int SalarioBase { get; set; }
        public decimal VentaBruta { get; set; }
        public int TarifaPorComision { get; set; }
    }
}