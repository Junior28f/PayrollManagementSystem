namespace  ClassLibrary1.Dtos;

public record GetActiveEmpleadoPorhorasDto  : BaseDto
{
   
    public decimal SueldoPorhora { get; set; }
    public int HorasTrabajadas { get; set; }

}