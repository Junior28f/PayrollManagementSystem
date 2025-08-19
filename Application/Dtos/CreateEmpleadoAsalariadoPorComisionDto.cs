namespace ClassLibrary1.Dtos;

public record CreateEmpleadoAsalariadoPorComisionDto
{
    public string Nombre { get; set; } 
    public string Apellido { get; set; } 
    public decimal SalarioBase { get; set; }
    public decimal VentasBrutas { get; set; }
    public decimal PorcentajeComision { get; set; }
}