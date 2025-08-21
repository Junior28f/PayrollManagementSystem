using PayrollManagementSystem.Models.EmpleadoAsalaridoPorComision;
using PayrollManagementSystem.Models.Interface;
using Infrastructure.Context;
using Domain.entities;
using Microsoft.EntityFrameworkCore;

namespace PayrollManagementSystem.Models.Service;

public class EmpleadoAsalaridoPorComisionService : IEmpleadoAsalariadoPorComisionService
{
    private readonly AppDbContext _context;

    public EmpleadoAsalaridoPorComisionService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<EmpleadoAsalaridoPorComisionModel>> GetAllEmpleadoAsalariadoPorComision()
    {
        var empleados = await _context.EmpleadoAsalaridoPorComision.ToListAsync();

        return empleados.Select(e => new EmpleadoAsalaridoPorComisionModel
        {
            TipoDeEmpleado = e.TipoDeEmpleado,
            Nombre = e.Nombre,
            Apellido = e.Apellido,
            NumeroDeSeguro = e.NumeroDeSeguro,
            Activo = e.Activo,
            SalarioBase = e.SalarioBase,
            VentaBruta = e.VentaBruta,
            TarifaPorComision = e.TarifaPorComision
        }).ToList();
    }

    public async Task<DetaisEmpleadoAsalaridoPorComisionModel?> GetEmpleadoAsalariadoPorComisionById(int numeroDeSeguro)
    {
        var empleado = await _context.EmpleadoAsalaridoPorComision
            .FirstOrDefaultAsync(e => e.NumeroDeSeguro == numeroDeSeguro);

        if (empleado == null) return null;

        return new DetaisEmpleadoAsalaridoPorComisionModel
        {
            TipoDeEmpleado = empleado.TipoDeEmpleado,
            Nombre = empleado.Nombre,
            Apellido = empleado.Apellido,
            NumeroDeSeguro = empleado.NumeroDeSeguro,
            Activo = empleado.Activo,
            SalarioBase = empleado.SalarioBase,
            VentaBruta = empleado.VentaBruta,
            TarifaPorComision = empleado.TarifaPorComision
        };
    }

    public async Task<bool> CreateEmpleadoAsalariadoPorComision(CreateEmpleadoAsalaridoPorComisionModel model)
    {
        var entity = new Domain.entities.EmpleadoAsalaridoPorComision
        {
            TipoDeEmpleado = model.TipoDeEmpleado,
            Nombre = model.Nombre,
            Apellido = model.Apellido,
            NumeroDeSeguro = model.NumeroDeSeguro,
            Activo = model.Activo,
            SalarioBase = model.SalarioBase,
            VentaBruta = model.VentaBruta,
            TarifaPorComision = model.TarifaPorComision
        };

        _context.EmpleadoAsalaridoPorComision.Add(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateEmpleadoAsalariadoPorComision(int numeroDeSeguro, EditEmpleadoAsalaridoPorComisionModel model)
    {
        var entity = await _context.EmpleadoAsalaridoPorComision.FindAsync(numeroDeSeguro);
        if (entity == null) return false;

        entity.TipoDeEmpleado = model.TipoDeEmpleado;
        entity.Nombre = model.Nombre;
        entity.Apellido = model.Apellido;
        entity.Activo = model.Activo;
        entity.SalarioBase = model.SalarioBase;
        entity.VentaBruta = model.VentaBruta;
        entity.TarifaPorComision = model.TarifaPorComision;

        _context.Update(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<DisableEmpleadoAsalaridoPorComisionModel?> GetDisableModelAsync(int numeroDeSeguro)
    {
        var empleado = await _context.EmpleadoAsalaridoPorComision
            .FirstOrDefaultAsync(e => e.NumeroDeSeguro == numeroDeSeguro);

        if (empleado == null) return null;

        return new DisableEmpleadoAsalaridoPorComisionModel
        {
            TipoDeEmpleado = empleado.TipoDeEmpleado,
            Nombre = empleado.Nombre,
            Apellido = empleado.Apellido,
            NumeroDeSeguro = empleado.NumeroDeSeguro,
            Activo = empleado.Activo,
            SalarioBase = empleado.SalarioBase,
            VentaBruta = empleado.VentaBruta,
            TarifaPorComision = empleado.TarifaPorComision
        };
    }

    public async Task<bool> DisableEmpleadoAsalariadoPorComision(int numeroDeSeguro, DisableEmpleadoAsalaridoPorComisionModel model)
    {
        var entity = await _context.EmpleadoAsalaridoPorComision.FindAsync(numeroDeSeguro);
        if (entity == null) return false;

        entity.Activo = false;
        _context.Update(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}
