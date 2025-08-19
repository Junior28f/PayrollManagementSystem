namespace ClassLibrary1.Dtos
{
    public record UpdateEmpleadoPorhorasDto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public decimal? SueldoPorHora { get; set; }
        public int? HorasTrabajadas { get; set; }
        public bool? Activo { get; set; }
        public int NumeroDeSeguro { get; set; }
    }
}
