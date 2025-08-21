using ClassLibrary1.Interfaces.Repositories;
using Domain.entities;
using Infrastructure.Context;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class EmpleadoAsalariadoRepository
        : Repository<EmpleadoAsalariado>, IRepository<EmpleadoAsalariado>
    {
        private readonly AppDbContext _context;

        public EmpleadoAsalariadoRepository(
            AppDbContext context,
            ILogger<EmpleadoAsalariadoRepository> logger)
            : base(context, logger)
        {
            _context = context;
        }

        public async Task<EmpleadoAsalariado?> GetEmpleadoAsalariadoById(int id)
        {
            if (id <= 0)
            {
                LogWarning("ID inválido para EmpleadoAsalariado: {Id}", id);
                return null;
            }

            try
            {
                LogInformation("Consultando EmpleadoAsalariado con ID {Id}", id);
                var empleadoAsalariado = await _context.EmpleadoAsalariados.FindAsync(id);

                if (empleadoAsalariado == null)
                    LogWarning("No se encontró EmpleadoAsalariado con ID {Id}", id);

                return empleadoAsalariado;
            }
            catch (Exception ex)
            {
                LogError(ex, "Error al obtener EmpleadoAsalariado con ID {Id}", id);
                return null;
            }
        }

        public async Task<IEnumerable<EmpleadoAsalariado>> GetAllEmpleadoAsalariado()
        {
            try
            {
                LogInformation("Obteniendo todos los Empleados Asalariados");
                return await _context.EmpleadoAsalariados.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                LogError(ex, "Error al obtener todos los Empleados Asalariados");
                return Enumerable.Empty<EmpleadoAsalariado>();
            }
        }

        public async Task CreateEmpleadoAsalariado(EmpleadoAsalariado empleadoAsalariado)
        {
            if (empleadoAsalariado == null)
            {
                LogWarning("Intento de agregar un EmpleadoAsalariado nulo");
                return;
            }

            if (empleadoAsalariado.NumeroDeSeguro <= 0)
            {
                LogWarning("El Número de Seguro debe ser mayor que cero");
                return;
            }

            // esta es una validacion para consultar en la base de dato si existe un empleado con esta numero de seguro
            bool existe = await _context.EmpleadoAsalariados
                .AnyAsync(e => e.NumeroDeSeguro == empleadoAsalariado.NumeroDeSeguro);

            if (existe)
            {
                LogWarning("Ya existe un Empleado Asalariado con el Número de Seguro {NumeroDeSeguro}",
                    empleadoAsalariado.NumeroDeSeguro);
                return;
            }
            
            // var empleado = new EmpleadoAsalariado()
            // { debo crear el Dto
            //    
            // };

            try
            {
                
                LogInformation("Agregando Empleado Asalariado con Número de Seguro {NumeroDeSeguro}",
                    empleadoAsalariado.NumeroDeSeguro);

                await _context.EmpleadoAsalariados.AddAsync(empleadoAsalariado);
                await _context.SaveChangesAsync();

                LogInformation("EmpleadoAsalariado agregado correctamente con Número de Seguro {NumeroDeSeguro}",
                    empleadoAsalariado.NumeroDeSeguro);
            }
            catch (Exception ex)
            {
                LogError(ex, "Error al crear Empleado Asalariado con Número de Seguro {NumeroDeSeguro}",
                    empleadoAsalariado.NumeroDeSeguro);
                throw;
            }
        }

        public async Task<EmpleadoAsalaridoPorComision?> UpdateEmpleadoAsalariadoAsync(EmpleadoAsalariado empleadoAsalariado)
        {
            if (empleadoAsalariado == null)
            {
                LogWarning("Intento de actualizar un Empleado Asalariado nulo");
                return null;
            }

            if (empleadoAsalariado.NumeroDeSeguro <= 0)
            {
                LogWarning("El Número de Seguro debe ser mayor que cero");
                return null;
            }

            var existente = await _context.EmpleadoAsalariados
                .FirstOrDefaultAsync(e => e.NumeroDeSeguro == empleadoAsalariado.NumeroDeSeguro);

            if (existente == null)
            {
                LogWarning("No existe EmpleadoAsalariado con Número de Seguro {NumeroDeSeguro}", 
                    empleadoAsalariado.NumeroDeSeguro);
                return null;
            }
            

            try
            {
               
                existente.Nombre = empleadoAsalariado.Nombre;
                existente.Apellido = empleadoAsalariado.Apellido;
                existente.SalarioSemanal = empleadoAsalariado.SalarioSemanal ;
                existente.NumeroDeSeguro = empleadoAsalariado.NumeroDeSeguro;
                existente.TipoDeEmpleado = empleadoAsalariado.TipoDeEmpleado;
                existente.Activo = empleadoAsalariado.Activo;
                
                await _context.SaveChangesAsync();

                LogInformation("EmpleadoAsalariado actualizado con Número de Seguro {NumeroDeSeguro}", 
                    empleadoAsalariado.NumeroDeSeguro);

                return null;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                LogError(ex, "Conflicto de concurrencia al actualizar EmpleadoAsalariado {NumeroDeSeguro}", 
                    empleadoAsalariado.NumeroDeSeguro);
                throw;
            }
            catch (Exception ex)
            {
                LogError(ex, "Error al actualizar EmpleadoAsalariado {NumeroDeSeguro}", 
                    empleadoAsalariado.NumeroDeSeguro);
                throw;
            }
        }


        public async Task DisableEmpleadoAsalariado(int id)
        {
            if (id <= 0)
            {
                LogWarning("ID inválido para deshabilitar EmpleadoAsalariado: {Id}", id);
                return;
            }

            try
            {
                var empleadoAsalariado = await _context.EmpleadoAsalariados.FindAsync(id);
                if (empleadoAsalariado == null)
                {
                    LogWarning("No se encontró Empleado Asalariado con ID {Id} para deshabilitar", id);
                    return;
                }

                empleadoAsalariado.Activo = false;
                _context.EmpleadoAsalariados.Update(empleadoAsalariado);
                await _context.SaveChangesAsync();

                LogInformation("Empleado Asalariado deshabilitado (inactivado) con ID {Id}", id);
            }
            catch (Exception ex)
            {
                LogError(ex, "Error al deshabilitar Empleado Asalariado con ID {Id}", id);

            }
        }

    }
}

