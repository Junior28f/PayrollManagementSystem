namespace ClassLibrary1.Dtos.DtoMetodos
{
    public record CreateEmpleadoPorhorasDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public decimal SueldoPorhora { get; set; }
        public int HorasTrabajadas { get; set; }
        public bool Activo { get; set; }
        public int NumeroDeSeguro { get; set; }
    }
}