namespace ClassLibrary1.Dtos.DtoMetodos;

    public record UpdateEmpleadoAsalariadoDto
    {
        public int NumeroDeSeguro { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public decimal? SalarioSemanal { get; set; }
        public bool? Activo { get; set; }
    }
