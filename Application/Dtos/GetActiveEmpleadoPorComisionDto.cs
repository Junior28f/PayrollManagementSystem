namespace ClassLibrary1.Dtos;

public record GetActiveEmpleadoPorComisionDto  : BaseDto
{

    public int VentaBruta { get; set; }
    public int TarifaPorComision { get; set; }

}