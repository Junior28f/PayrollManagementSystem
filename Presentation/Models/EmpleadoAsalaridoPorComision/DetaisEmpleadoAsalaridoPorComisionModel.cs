﻿

namespace PayrollManagementSystem.Models.EmpleadoAsalaridoPorComision;

public class DetaisEmpleadoAsalaridoPorComisionModel: EmpleadoAsalaridoPorComisionModel
{
    public DetaisEmpleadoAsalaridoPorComisionModel(string tipoDeEmpleado, string nombre, string apellido, int numeroDeSeguro, bool activo, int salarioBase, decimal ventaBruta, decimal tarifaPorComision, decimal pagoSemanal) 
        : base(tipoDeEmpleado, nombre, apellido, numeroDeSeguro, activo, salarioBase, ventaBruta, tarifaPorComision,  pagoSemanal)
    {
    }

    public DetaisEmpleadoAsalaridoPorComisionModel()
    {
        
    }
}