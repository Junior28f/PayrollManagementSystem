namespace ClassLibrary1.Dtos.DtoMetodos;

public record UpdateEmpleadoAsalariadoPorComisionDto
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public decimal SalarioBase { get; set; }
    public decimal VentasBrutas { get; set; }
    public decimal PorcentajeComision { get; set; }
}