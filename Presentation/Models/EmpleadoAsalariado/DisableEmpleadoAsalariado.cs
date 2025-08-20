﻿namespace PayrollManagementSystem.Models.EmpleadoAsalariado;

public class DisableEmpleadoAsalariado : EmpleadoAsalariadoModel
{
    public DisableEmpleadoAsalariado(string tipoDeEmpleado, string nombre, string apellido, int numeroDeSeguro,
        bool activo, decimal salarioSemanal)
        : base(tipoDeEmpleado, nombre, apellido, numeroDeSeguro, activo, salarioSemanal)
    {
    }
    public decimal Salariosemanal1 { get; set; }

    public DisableEmpleadoAsalariado()
    {
    }
}