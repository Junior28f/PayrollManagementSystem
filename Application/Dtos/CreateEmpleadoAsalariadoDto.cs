namespace ClassLibrary1.Dtos;

public record CreateEmpleadoAsalariadoDto
{
    public string Nombre { get; set; }
    public string Apellido { get; set; } 
    public int NumeroDeSeguro { get; set; } 
    public decimal SalarioSemanal { get; set; }
   
}