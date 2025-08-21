using PayrollManagementSystem.Models.EmpleadoPorComision;
using PayrollManagementSystem.Models.Interface;
using Infrastructure.Context;
using Domain.entities;
using Microsoft.EntityFrameworkCore;

namespace PayrollManagementSystem.Models.Service;

public class EmpleadoPorComisionService : IEmpleadoPorComisionService
{
    private readonly AppDbContext _context;

    public EmpleadoPorComisionService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<EmpleadoPorComisionModel>> GetAllEmpleadoPorComision()
    {
        var empleados = await _context.EmpleadoPorComision.ToListAsync();

        return empleados.Select(e => new EmpleadoPorComisionModel
        {
            TipoDeEmpleado = e.TipoDeEmpleado,
            Nombre = e.Nombre,
            Apellido = e.Apellido,
            NumeroDeSeguro = e.NumeroDeSeguro,
            Activo = e.Activo,
            VentasBrutas = e.VentaBruta,
            TarifaPorComision = e.TarifaPorComision,
            PagoSemanal = e.VentaBruta * e.TarifaPorComision
        }).ToList();
    }

    public async Task<DetaisEmpleadoPorComisionModel?> GetEmpleadoPorComisionById(int numeroDeSeguro)
    {
        var empleado = await _context.EmpleadoPorComision
            .FirstOrDefaultAsync(e => e.NumeroDeSeguro == numeroDeSeguro);

        if (empleado == null) return null;

        return new DetaisEmpleadoPorComisionModel
        {
            TipoDeEmpleado = empleado.TipoDeEmpleado,
            Nombre = empleado.Nombre,
            Apellido = empleado.Apellido,
            NumeroDeSeguro = empleado.NumeroDeSeguro,
            Activo = empleado.Activo,
            VentasBrutas = empleado.VentaBruta,
            TarifaPorComision = empleado.TarifaPorComision,
            PagoSemanal = empleado.VentaBruta * empleado.TarifaPorComision
        };
    }

    public async Task<bool> CreateEmpleadoPorComision(CreateEmpleadoPorComisionModel model)
    {
        var pago = model.VentasBrutas * model.TarifaPorComision;

        var entity = new Domain.entities.EmpleadoPorComision
        {
            TipoDeEmpleado = model.TipoDeEmpleado,
            Nombre = model.Nombre,
            Apellido = model.Apellido,
            NumeroDeSeguro = model.NumeroDeSeguro,
            Activo = model.Activo,
            VentaBruta = model.VentasBrutas,
            TarifaPorComision = model.TarifaPorComision,
            PagoSemanal = pago
        };

        _context.EmpleadoPorComision.Add(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateEmpleadoPorComision(int numeroDeSeguro, EditEmpleadoPorComisionModel model)
    {
        var entity = await _context.EmpleadoPorComision.FindAsync(numeroDeSeguro);
        if (entity == null) return false;

        entity.TipoDeEmpleado = model.TipoDeEmpleado;
        entity.Nombre = model.Nombre;
        entity.Apellido = model.Apellido;
        entity.Activo = model.Activo;
        entity.VentaBruta = model.VentasBrutas;
        entity.TarifaPorComision = model.TarifaPorComision;
        entity.PagoSemanal = model.VentasBrutas * model.TarifaPorComision;

        _context.Update(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DisableEmpleadoPorComision(int numeroDeSeguro)
    {
        var entity = await _context.EmpleadoPorComision.FindAsync(numeroDeSeguro);
        if (entity == null) return false;


        entity.Activo = false;

        _context.Update(entity);
        await _context.SaveChangesAsync();
        return true;
    }

}
