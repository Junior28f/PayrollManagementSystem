namespace ClassLibrary1.Dtos;

public class PagoEmpleadoDto
{
    public string NombreCompleto { get; set; } = string.Empty;
    public string TipoDeEmpleado { get; set; } = string.Empty;
    public int NumeroDeSeguro { get; set; }
    public decimal Pago { get; set; }
}
