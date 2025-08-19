using ClassLibrary1.Dtos;
using ClassLibrary1.Interfaces.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using EmpleadoPorComision = Domain.entities.EmpleadoPorComision;

namespace Infrastructure.Repositories;

public class EmpleadoPorComisionRepository : Repository<EmpleadoPorComision>,
    IRepository<EmpleadoPorComision>
{
    private readonly AppDbContext _context;

    public EmpleadoPorComisionRepository(
        AppDbContext context,
        ILogger<EmpleadoPorComisionRepository> logger)
        : base(context, logger)
    {
        _context = context;
    }

    public async Task<EmpleadoPorComision?> GetEmpleadoPorComisionById(int id)
    {
        if (id <= 0)
        {
            LogWarning("ID inválido para Empleado Por Comisión: {Id}", id);
            return null;
        }

        try
        {
            LogInformation("Consultando Empleado Por Comisión con ID {Id}", id);

            var empleadoPorComision = await _context.EmpleadoPorComision.FindAsync(id);

            if (empleadoPorComision == null)
            {
                LogWarning("Empleado Por Comisión no encontrado {Id}", id);
                return null;
            }

            LogInformation("Empleado Por Comisión obtenido correctamente {Id}", id);
            return empleadoPorComision;
        }
        catch (Exception ex)
        {
            LogError(ex, "Error al obtener Empleado Por Comisión con ID {Id}", id);
            return null;
        }
    }

    public async Task<IEnumerable<EmpleadoPorComision>> GetAllEmpleadoPorComisionByEmpleado()
    {
        try
        {
            LogInformation("Obteniendo listado de Empleado Por Comisión");
            return await _context.EmpleadoPorComision
                .AsNoTracking()
                .ToListAsync();
        }
        catch (Exception e)
        {
            LogError(e, "Error al obtener listado de Empleado Por Comisión");
            return Enumerable.Empty<EmpleadoPorComision>();
        }
    }

    public async Task<EmpleadoPorComision> CreateEmpleadoPorComision(EmpleadoPorComision empleadoPorComision)
    {
        if (empleadoPorComision == null)
        {
            LogWarning("El Empleado no puede ser nulo");
            return null;
        }

        if (empleadoPorComision.NumeroDeSeguro <= 0)
        {
            LogWarning("El Número de Seguro debe ser mayor que cero");
            return null;
        }

        var existe = await _context.EmpleadoPorComision
            .AnyAsync(e => e.NumeroDeSeguro == empleadoPorComision.NumeroDeSeguro);

        if (existe)
        {
            LogWarning("Ya existe un Empleado con el Número de Seguro {NumeroDeSeguro}", empleadoPorComision.NumeroDeSeguro);
            return null;
        }

        try
        {
            LogInformation("Agregando Empleado Por Comisión con Número de Seguro {NumeroDeSeguro}",
                empleadoPorComision.NumeroDeSeguro);

            await _context.EmpleadoPorComision.AddAsync(empleadoPorComision);
            await _context.SaveChangesAsync();

            LogInformation("Empleado Por Comisión agregado correctamente con Número de Seguro {NumeroDeSeguro}",
                empleadoPorComision.NumeroDeSeguro);

            return empleadoPorComision;
        }
        catch (Exception ex)
        {
            LogError(ex, "Error al crear Empleado Por Comisión con Número de Seguro {NumeroDeSeguro}",
                empleadoPorComision.NumeroDeSeguro);
            throw;
        }
    }

    public async Task<EmpleadoPorComision> UpdateEmpleadoPorComision(EmpleadoPorComision empleadoPorComision )
    {
        if (empleadoPorComision == null)
        {
            LogWarning("El Empleado no puede ser nulo");
            return null;
        }

        if (empleadoPorComision.NumeroDeSeguro <= 0)
        {
            LogWarning("El Número de Seguro debe ser mayor que cero");
            return null;
        }

        var existente = await _context.EmpleadoPorComision
            .FirstOrDefaultAsync(e => e.NumeroDeSeguro == empleadoPorComision.NumeroDeSeguro);

        if (existente == null)
        {
            LogWarning("No existe un empleado con el Número de Seguro {NumeroDeSeguro}",
                empleadoPorComision.NumeroDeSeguro);
            return null;
        }

        try
        {
            existente.Nombre = empleadoPorComision.Nombre;
            existente.Apellido = empleadoPorComision.Apellido;
            existente.NumeroDeSeguro = empleadoPorComision.NumeroDeSeguro;
            existente.VentaBruta = empleadoPorComision.VentaBruta;
            existente.TarifaPorComision = empleadoPorComision.TarifaPorComision;
            existente.Activo = empleadoPorComision.Activo;
            existente.TipoDeEmpleado = empleadoPorComision.TipoDeEmpleado;
            
            _context.EmpleadoPorComision.Update(existente);
            await _context.SaveChangesAsync();

            LogInformation("Empleado Por Comisión con Número de Seguro {NumeroDeSeguro} actualizado correctamente",
                empleadoPorComision.NumeroDeSeguro);

            return existente;
        }
        catch (Exception ex)
        {
            LogError(ex, "Error al actualizar Empleado Por Comisión con Número de Seguro {NumeroDeSeguro}",
                empleadoPorComision.NumeroDeSeguro);
            throw;
        }
    }
    public async Task DisableEmpleadoPorComision(int id)
    {
        if (id <= 0)
        {
            LogWarning("ID inválido para deshabilitar Empleado Por Comisión: {Id}", id);
            return;
        }

        try
        {
            var empleado = await _context.EmpleadoPorComision.FindAsync(id);
            if (empleado == null)
            {
                LogWarning("No se encontró Empleado Por Comisión con ID {Id} para deshabilitar", id);
                return;
            }

            empleado.Activo = false;
            _context.EmpleadoPorComision.Update(empleado);
            await _context.SaveChangesAsync();

            LogInformation("Empleado Por Comisión deshabilitado (inactivado) con ID {Id}", id);
        }
        catch (Exception ex)
        {
            LogError(ex, "Error al deshabilitar Empleado Por Comisión con ID {Id}", id);
        }
    }
}
