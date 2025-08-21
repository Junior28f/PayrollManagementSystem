using PayrollManagementSystem.Models.EmpleadoPorHoras;
using PayrollManagementSystem.Models.Interface;
using Infrastructure.Context;
using Domain.entities;
using Microsoft.EntityFrameworkCore;

namespace PayrollManagementSystem.Models.Service;

public class EmpleadoPorHorasService : IEmpleadoPorHorasService
{
    private readonly AppDbContext _context;

    public EmpleadoPorHorasService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<EmpleadoPorHoraModel>> GetAllEmpleadoPorHoraModel()
    {
        var empleados = await _context.EmpleadoPorHoras.ToListAsync();

        return empleados.Select(e => new EmpleadoPorHoraModel
        {
            TipoDeEmpleado = e.TipoDeEmpleado,
            Nombre = e.Nombre,
            Apellido = e.Apellido,
            NumeroDeSeguro = e.NumeroDeSeguro,
            Activo = e.Activo,
            SueldoPorhora = e.SueldoPorhora,
            HorasTrabajadas = e.HorasTrabajadas,
            PagoSemanal = CalcularPago(e.SueldoPorhora, e.HorasTrabajadas)
        }).ToList();
    }

    public async Task<DetaisEmpleadoPorHoraModel?> GetEmpleadoPorHoraModelById(int numeroDeSeguro)
    {
        var empleado = await _context.EmpleadoPorHoras
            .FirstOrDefaultAsync(e => e.NumeroDeSeguro == numeroDeSeguro);

        if (empleado == null) return null;

        return new DetaisEmpleadoPorHoraModel
        {
            TipoDeEmpleado = empleado.TipoDeEmpleado,
            Nombre = empleado.Nombre,
            Apellido = empleado.Apellido,
            NumeroDeSeguro = empleado.NumeroDeSeguro,
            Activo = empleado.Activo,
            SueldoPorhora = empleado.SueldoPorhora,
            HorasTrabajadas = empleado.HorasTrabajadas,
            PagoSemanal = CalcularPago(empleado.SueldoPorhora, empleado.HorasTrabajadas)
        };
    }

    public async Task<bool> CreateEmpleadoPorHoraModel(CreateEmpleadoPorHoraModel model)
    {
        var entity = new EmpleadoPorhoras
        {
            TipoDeEmpleado = model.TipoDeEmpleado,
            Nombre = model.Nombre,
            Apellido = model.Apellido,
            NumeroDeSeguro = model.NumeroDeSeguro,
            Activo = model.Activo,
            SueldoPorhora = model.SueldoPorhora,
            HorasTrabajadas = model.HorasTrabajadas,
            PagoSemanal = CalcularPago(model.SueldoPorhora, model.HorasTrabajadas)
        };

        _context.EmpleadoPorHoras.Add(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateEmpleadoPorHoraModel(int numeroDeSeguro, EditEmpleadoPorHoraModel model)
    {
        var entity = await _context.EmpleadoPorHoras.FindAsync(numeroDeSeguro);
        if (entity == null) return false;

        entity.TipoDeEmpleado = model.TipoDeEmpleado;
        entity.Nombre = model.Nombre;
        entity.Apellido = model.Apellido;
        entity.Activo = model.Activo;
        entity.SueldoPorhora = model.SueldoPorhora;
        entity.HorasTrabajadas = model.HorasTrabajadas;
        entity.PagoSemanal = CalcularPago(model.SueldoPorhora, model.HorasTrabajadas);

        _context.Update(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DisableEmpleadoPorHoraModel(int numeroDeSeguro, DisableEmpleadoPorHoraModel model)
    {
        var entity = await _context.EmpleadoPorHoras.FindAsync(numeroDeSeguro);
        if (entity == null) return false;

        entity.Activo = false;

        _context.Update(entity);
        await _context.SaveChangesAsync();
        return true;
    }

  
    private decimal CalcularPago(decimal sueldoPorHora, int horasTrabajadas)
    {
        if (horasTrabajadas <= 40)
        {
            return sueldoPorHora * horasTrabajadas;
        }
        else
        {
            var horasExtras = horasTrabajadas - 40;
            var pagoRegular = sueldoPorHora * 40;
            var pagoExtra = sueldoPorHora * 1.5m * horasExtras;
            return pagoRegular + pagoExtra;
        }
    }
}
