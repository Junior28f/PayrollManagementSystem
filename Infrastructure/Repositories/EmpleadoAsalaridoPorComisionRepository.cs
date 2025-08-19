using ClassLibrary1.Interfaces.Repositories;
using Domain.entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories;

public class EmpleadoAsalariadoPorComisionRepository : Repository<EmpleadoAsalaridoPorComision>,
    IRepository<EmpleadoAsalaridoPorComision>
{
    private readonly AppDbContext _context;

    public EmpleadoAsalariadoPorComisionRepository(
        AppDbContext context,
        ILogger<EmpleadoAsalariadoPorComisionRepository> logger)
        : base(context, logger)
    {
        _context = context;
    }

    public async Task<EmpleadoAsalaridoPorComision?> GetEmpleadoAsalariadoPorComisionById(int id)
    {
        if (id <= 0)
        {
            LogWarning("ID inválido para Empleado Asalariado Por Comision: {Id}", id);
            return null;
        }

        try
        {
            LogInformation("Consultando Empleado Asalariado Por Comision con ID {Id}", id);

            var empleadoAsalaridoPorComision = await _context.EmpleadoAsalaridoPorComision.FindAsync(id);

            if (empleadoAsalaridoPorComision == null)
            {
                LogWarning("Empleado Asalariado Por Comision no encontrado {Id}", id);
                return null;
            }

            LogInformation("Empleado Asalariado Por Comision obtenido correctamente {Id}", id);
            return empleadoAsalaridoPorComision;
        }
        catch (Exception ex)
        {
            LogError(ex, "Error al obtener Empleado Asalariado Por Comision con ID {Id}", id);
            return null;
        }
    }

    public async Task<IEnumerable<EmpleadoAsalaridoPorComision>> GetAllEmpleadoAsalariadoPorComisionByEmpleado()
    {
        try
        {
            LogInformation("Obteniendo listado de Empleado Asalariado por Comisión");
            return await _context.EmpleadoAsalaridoPorComision
                .AsNoTracking()
                .ToListAsync();
        }
        catch (Exception e)
        {

            LogError(e, "Error al obtener listado de Empleado Asalariado por Comisión");
            return Enumerable.Empty<EmpleadoAsalaridoPorComision>();
        }
    }

    public async Task<EmpleadoAsalaridoPorComision> CreateEmpleadoAsalaridoPorComision(
        EmpleadoAsalaridoPorComision empleadoAsalaridoPorComision)
    {
        if (empleadoAsalaridoPorComision == null)
        {
            LogWarning("El Empleado no puede ser nulo");
            return null;
        }

        if (empleadoAsalaridoPorComision.NumeroDeSeguro <= 0)
        {
            LogWarning("El Número de Seguro debe ser mayor que cero");
            return null;
        }

        var existe = await _context.EmpleadoAsalaridoPorComision
            .AnyAsync(e => e.NumeroDeSeguro == empleadoAsalaridoPorComision.NumeroDeSeguro);

        if (existe)
        {
            LogWarning("Ya existe un Empleado con el Número de Seguro {NumeroDeSeguro}", empleadoAsalaridoPorComision.NumeroDeSeguro);
            return null;
        }

        try
        {
            LogInformation("Agregando Empleado Asalariado Por Comisión con Número de Seguro {NumeroDeSeguro}", 
                empleadoAsalaridoPorComision.NumeroDeSeguro);

            await _context.EmpleadoAsalaridoPorComision.AddAsync(empleadoAsalaridoPorComision);
            await _context.SaveChangesAsync();

            LogInformation("Empleado Asalariado Por Comisión agregado correctamente con Número de Seguro {NumeroDeSeguro}",
                empleadoAsalaridoPorComision.NumeroDeSeguro);

            return empleadoAsalaridoPorComision;
        }
        catch (Exception ex)
        {
            LogError(ex, "Error al crear Empleado Asalariado Por Comisión con Número de Seguro {NumeroDeSeguro}", 
                empleadoAsalaridoPorComision.NumeroDeSeguro);
            throw;
        }
    }

    public async Task<EmpleadoAsalaridoPorComision> UpdateEmpleadoAsalaridoPorComision(
        EmpleadoAsalaridoPorComision empleadoAsalaridoPorComision)
    {
        if (empleadoAsalaridoPorComision == null)
        {
            LogWarning("El Empleado no puede ser nulo");
            return null;
        }

        if (empleadoAsalaridoPorComision.NumeroDeSeguro <= 0)
        {
            LogWarning("El Número de Seguro debe ser mayor que cero");
            return null;
        }

        var existente = await _context.EmpleadoAsalaridoPorComision
            .FirstOrDefaultAsync(e => e.NumeroDeSeguro == empleadoAsalaridoPorComision.NumeroDeSeguro);

        if (existente == null)
        {
            LogWarning("No existe un empleado con el Número de Seguro {NumeroDeSeguro}", 
                empleadoAsalaridoPorComision.NumeroDeSeguro);
            return null;
        }

        try
        {
          
            existente.Nombre = empleadoAsalaridoPorComision.Nombre;
            existente.Apellido = empleadoAsalaridoPorComision.Apellido;
            existente.SalarioBase = empleadoAsalaridoPorComision.SalarioBase;
            existente.NumeroDeSeguro = empleadoAsalaridoPorComision.NumeroDeSeguro;
            existente.VentaBruta = empleadoAsalaridoPorComision.VentaBruta;
            existente.TarifaPorComision =empleadoAsalaridoPorComision.TarifaPorComision;
            existente.Activo = empleadoAsalaridoPorComision.Activo;
            existente.TipoDeEmpleado = empleadoAsalaridoPorComision.TipoDeEmpleado;
            
            _context.EmpleadoAsalaridoPorComision.Update(existente);
            await _context.SaveChangesAsync();

            LogInformation("Empleado Asalariado Por Comisión con Número de Seguro {NumeroDeSeguro} actualizado correctamente", 
                empleadoAsalaridoPorComision.NumeroDeSeguro);

            return existente;
        }
        catch (Exception ex)
        {
            LogError(ex, "Error al actualizar Empleado Asalariado Por Comisión con Número de Seguro {NumeroDeSeguro}", 
                empleadoAsalaridoPorComision.NumeroDeSeguro);
            throw;
        }
    }
    public async Task DisableEmpleadoAsalariadoPorComision(int id)
    {
        if (id <= 0)
        {
            LogWarning("ID inválido para deshabilitar Empleado Asalariado Por Comisión: {Id}", id);
            return;
        }

        try
        {
            var empleado = await _context.EmpleadoAsalaridoPorComision.FindAsync(id);
            if (empleado == null)
            {
                LogWarning("No se encontró Empleado Asalariado Por Comisión con ID {Id} para deshabilitar", id);
                return;
            }

            empleado.Activo = false;
            _context.EmpleadoAsalaridoPorComision.Update(empleado);
            await _context.SaveChangesAsync();

            LogInformation("Empleado Asalariado Por Comisión deshabilitado (inactivado) con ID {Id}", id);
        }
        catch (Exception ex)
        {
            LogError(ex, "Error al deshabilitar Empleado Asalariado Por Comisión con ID {Id}", id);
        }
    }


}