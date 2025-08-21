using PayrollManagementSystem.Models.EmpleadoAsalariado;
using PayrollManagementSystem.Models.Interface;
using Infrastructure.Context;
using Domain.entities;
using Microsoft.EntityFrameworkCore;

namespace PayrollManagementSystem.Models.Service;

public class EmpleadoAsalariadoService : IEmpleadoAsalariadoService
{
    private readonly AppDbContext _context;

    public EmpleadoAsalariadoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<EmpleadoAsalariadoModel>> GetAllAEmpleadoAsalariado()
    {
        var empleados = await _context.EmpleadoAsalariados.ToListAsync();

        return empleados.Select(e => new EmpleadoAsalariadoModel
        {
            TipoDeEmpleado = e.TipoDeEmpleado,
            Nombre = e.Nombre,
            Apellido = e.Apellido,
            NumeroDeSeguro = e.NumeroDeSeguro,
            Activo = e.Activo,
            SalarioSemanal = e.SalarioSemanal,
            PagoSemanal = e.PagoSemanal
        }).ToList();
    }

    public async Task<DetailsEmpleadoAsalariadoModel?> GetEmpleadoAsalariadoById(int numeroDeSeguro)
    {
        var empleado = await _context.EmpleadoAsalariados
            .FirstOrDefaultAsync(e => e.NumeroDeSeguro == numeroDeSeguro);

        if (empleado == null) return null;

        return new DetailsEmpleadoAsalariadoModel(
            empleado.TipoDeEmpleado,
            empleado.Nombre,
            empleado.Apellido,
            empleado.NumeroDeSeguro,
            empleado.Activo,
            empleado.SalarioSemanal,
            empleado.PagoSemanal
        );
    }

    public async Task<bool> UpdateEmpleadoAsalariado(int numeroDeSeguro, EditEmpleadoAsalariadoModel model)
    {
        var entity = await _context.EmpleadoAsalariados.FindAsync(numeroDeSeguro);
        if (entity == null) return false;

        entity.TipoDeEmpleado = model.TipoDeEmpleado;
        entity.Nombre = model.Nombre;
        entity.Apellido = model.Apellido;
        entity.Activo = model.Activo;
        entity.SalarioSemanal = model.Salariosemanal1;
        entity.PagoSemanal = model.PagoSemanal;

        _context.Update(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DisableEmpleadoAsalariado(int numeroDeSeguro, DisableEmpleadoAsalariado model)
    {
        var entity = await _context.EmpleadoAsalariados.FindAsync(numeroDeSeguro);
        if (entity == null) return false;

        _context.EmpleadoAsalariados.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> CreateEmpleadoAsalariado(CreateEmpleadoAsalariadoModel model)
    {
        var entity = new Domain.entities.EmpleadoAsalariado
        {
            TipoDeEmpleado = model.TipoDeEmpleado,
            Nombre = model.Nombre,
            Apellido = model.Apellido,
            NumeroDeSeguro = model.NumeroDeSeguro,
            Activo = model.Activo,
            SalarioSemanal = model.Salariosemanal1,
            PagoSemanal = model.PagoSemanal
        };

        _context.EmpleadoAsalariados.Add(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}
