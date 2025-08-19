namespace ClassLibrary1.Dtos;

public record GetActiveEmpleadoAsalaridoPorComisionDto  : BaseDto
{
   
    public int SalarioBase { get; set; }
    public decimal VentaBruta { get; set; }
    public int TarifaPorComision { get; set; }
}