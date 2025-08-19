using ClassLibrary1.Interfaces.Repositories;
using Domain.entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories;

public class EmpleadoPorHoraRepository : Repository<EmpleadoPorhoras>, IRepository<EmpleadoPorhoras>
{
    private readonly AppDbContext _context;

    public EmpleadoPorHoraRepository(
        AppDbContext context, 
        ILogger<EmpleadoPorHoraRepository> logger) 
        : base(context, logger)
    {
        _context = context;
    }

    public async Task<EmpleadoPorhoras?> GetEmpleadoPorhoraById(int id)
    {
        if (id <= 0)
        {
            LogWarning("ID inválido para Empleado Por Horas: {Id}", id);
            return null;
        }

        try
        {
            LogInformation("Consultando Empleado Por Horas con ID {Id}", id);
            var empleado = await _context.EmpleadoPorHoras.FindAsync(id);

            if (empleado == null)
            {
                LogWarning("Empleado Por Horas no encontrado {Id}", id);
                return null;
            }

            LogInformation("Empleado Por Horas obtenido correctamente {Id}", id);
            return empleado;
        }
        catch (Exception ex)
        {
            LogError(ex, "Error al obtener Empleado Por Horas con ID {Id}", id);
            return null;
        }
    }

    public async Task<IEnumerable<EmpleadoPorhoras>> GetAllEmpleadoPorHoras()
    {
        try
        {
            LogInformation("Obteniendo listado de Empleado Por Horas");
            return await _context.EmpleadoPorHoras
                .AsNoTracking()
                .ToListAsync();
        }
        catch (Exception e)
        {
            LogError(e, "Error al obtener listado de Empleado Por Horas");
            return Enumerable.Empty<EmpleadoPorhoras>();
        }
    }

    public async Task<EmpleadoPorhoras?> CreateEmpleadoPorHoras(EmpleadoPorhoras empleadoPorHoras)
    {
        if (empleadoPorHoras == null)
        {
            LogWarning("El Empleado no puede ser nulo");
            return null;
        }

        if (empleadoPorHoras.NumeroDeSeguro <= 0)
        {
            LogWarning("El Número de Seguro debe ser mayor que cero");
            return null;
        }

        var existe = await _context.EmpleadoPorHoras
            .AnyAsync(e => e.NumeroDeSeguro == empleadoPorHoras.NumeroDeSeguro);

        if (existe)
        {
            LogWarning("Ya existe un Empleado con el Número de Seguro {NumeroDeSeguro}", empleadoPorHoras.NumeroDeSeguro);
            return null;
        }

        try
        {
            LogInformation("Agregando Empleado Por Horas con Número de Seguro {NumeroDeSeguro}", empleadoPorHoras.NumeroDeSeguro);

            await _context.EmpleadoPorHoras.AddAsync(empleadoPorHoras);
            await _context.SaveChangesAsync();

            LogInformation("Empleado Por Horas agregado correctamente con Número de Seguro {NumeroDeSeguro}", empleadoPorHoras.NumeroDeSeguro);

            return empleadoPorHoras;
        }
        catch (Exception ex)
        {
            LogError(ex, "Error al crear Empleado Por Horas con Número de Seguro {NumeroDeSeguro}", empleadoPorHoras.NumeroDeSeguro);
            throw;
        }
    }

    public async Task<EmpleadoPorhoras?> UpdateEmpleadoPorHoras(EmpleadoPorhoras empleadoPorHoras)
    {
        if (empleadoPorHoras == null)
        {
            LogWarning("El Empleado no puede ser nulo");
            return null;
        }

        if (empleadoPorHoras.NumeroDeSeguro <= 0)
        {
            LogWarning("El Número de Seguro debe ser mayor que cero");
            return null;
        }

        var existente = await _context.EmpleadoPorHoras
            .FirstOrDefaultAsync(e => e.NumeroDeSeguro == empleadoPorHoras.NumeroDeSeguro);

        if (existente == null)
        {
            LogWarning("No existe un empleado con el Número de Seguro {NumeroDeSeguro}", empleadoPorHoras.NumeroDeSeguro);
            return null;
        }

        try
        {
            existente.Nombre = empleadoPorHoras.Nombre;
            existente.Apellido = empleadoPorHoras.Apellido;
            existente.NumeroDeSeguro = empleadoPorHoras.NumeroDeSeguro;
            existente.Activo = empleadoPorHoras.Activo;
            existente.TipoDeEmpleado = empleadoPorHoras.TipoDeEmpleado;
            existente.SueldoPorhora = empleadoPorHoras.SueldoPorhora;
            existente.HorasTrabajadas = empleadoPorHoras.HorasTrabajadas;
            
            _context.EmpleadoPorHoras.Update(existente);
            await _context.SaveChangesAsync();

            LogInformation("Empleado Por Horas con Número de Seguro {NumeroDeSeguro} actualizado correctamente", empleadoPorHoras.NumeroDeSeguro);

            return existente;
        }
        catch (Exception ex)
        {
            LogError(ex, "Error al actualizar Empleado Por Horas con Número de Seguro {NumeroDeSeguro}", empleadoPorHoras.NumeroDeSeguro);
            throw;
        }
    }
    public async Task DisableEmpleadoPorHoras(int id)
    {
        if (id <= 0)
        {
            LogWarning("ID inválido para deshabilitar Empleado Por Horas: {Id}", id);
            return;
        }

        try
        {
            var empleado = await _context.EmpleadoPorHoras.FindAsync(id);
            if (empleado == null)
            {
                LogWarning("No se encontró Empleado Por Horas con ID {Id} para deshabilitar", id);
                return;
            }

            empleado.Activo = false;
            _context.EmpleadoPorHoras.Update(empleado);
            await _context.SaveChangesAsync();

            LogInformation("Empleado Por Horas deshabilitado (inactivado) con ID {Id}", id);
        }
        catch (Exception ex)
        {
            LogError(ex, "Error al deshabilitar Empleado Por Horas con ID {Id}", id);
        }
    }

}
