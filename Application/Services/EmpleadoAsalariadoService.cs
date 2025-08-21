using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Dtos;
using ClassLibrary1.Dtos.DtoMetodos;
using ClassLibrary1.Interfaces.Repositories;
using Domain.entities;
using Microsoft.Extensions.Logging;

namespace ClassLibrary1.Services
{
    public class EmpleadoAsalariadoService : Service<EmpleadoAsalariado>
    {
        private readonly IRepository<EmpleadoAsalariado> _repository;

        public EmpleadoAsalariadoService(
            IRepository<EmpleadoAsalariado> repository,
            ILogger<EmpleadoAsalariadoService> logger)
            : base(repository, logger)
        {
            _repository = repository;
        }

       
        public async Task CreateEmpleadoAsalariado(CreateEmpleadoAsalariadoDto dto)
        {
            if (dto is null) throw new ArgumentNullException(nameof(dto));

            var entity = new EmpleadoAsalariado(
                tipoDeEmpleado1: "Empleado Asalariado",
                nombre: dto.Nombre,
                apellido: dto.Apellido,
                numeroDeSeguro: dto.NumeroDeSeguro,
                salarioSemanal:dto.SalarioSemanal
            );


            await AddAsync(entity);
            LogInformation("Empleado asalariado creado: NSS {nss}", entity.NumeroDeSeguro);
        }
        
        public async Task UpdateEmpleadoAsalariado(int id, UpdateEmpleadoAsalariadoDto dto)
        {
            if (dto is null) throw new ArgumentNullException(nameof(dto));

            var entity = await GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Empleado con id {id} no encontrado");

            entity.NumeroDeSeguro = dto.NumeroDeSeguro;
            entity.SalarioSemanal = Convert.ToDecimal(dto.SalarioSemanal);

            await UpdateAsync(entity);
            LogInformation("Empleado asalariado actualizado: Id {id}", id);
        }

       
        public async Task DisableEmpleadoAsalariado(int id, DisableEmpleadoAsalariadoDto dto)
        {
            await Disable(id);
            LogInformation("Empleado asalariado deshabilitado: Id {id}", id);
        }

        
        public async Task<IEnumerable<EmpleadoAsalariado>> GetAllEmpleadoAsalariado(GetActiveEmpleadoAsalariadoDto dto)
        {
            var empleados = await GetAllAsync();
            LogInformation("Se obtuvieron {count} empleados asalariados", empleados.Count());
            return empleados;
        }

        // Obtener por id
        public async Task<EmpleadoAsalariado?> ObtenerPorIdAsync(int id)
        {
            var empleado = await GetByIdAsync(id);
            LogInformation(empleado == null
                ? "Empleado asalariado con Id {id} no encontrado"
                : "Empleado asalariado obtenido: Id {id}", id);
            return empleado;
        }
        
        public decimal CalcularPago(EmpleadoAsalariado empleado)
        {
            try
            {
                if (empleado == null)
                {
                    LogWarning("Intento de cálculo con empleado nulo");
                    throw new ArgumentNullException(nameof(empleado));
                }

                if (empleado.SalarioSemanal <= 0)
                {
                    LogWarning("Salario inválido ({salario}) para empleado {nss}",
                        empleado.SalarioSemanal,
                        empleado.NumeroDeSeguro);
                    throw new ArgumentException(
                        "El salario semanal debe ser mayor que cero.",
                        nameof(empleado.SalarioSemanal));
                }

                LogInformation("Calculando pago para NSS: {nss}", empleado.NumeroDeSeguro);

                var pago = empleado.SalarioSemanal; 

                LogInformation("Pago calculado para NSS: {nss} = {pago}",
                    empleado.NumeroDeSeguro, pago);

                return pago;
            }
            catch (Exception ex)
            {
                LogError(ex, "Error calculando pago para NSS: {nss}", empleado?.NumeroDeSeguro);
                throw;
            }
        }

        
        public async Task<decimal> CalcularPagoPorId(int id)
        {
            var empleado = await GetByIdAsync(id);
            if (empleado == null)
            {
                LogWarning("No se encontró empleado asalariado con Id {id}", id);
                throw new KeyNotFoundException($"Empleado con id {id} no encontrado");
            }

            return CalcularPago(empleado);
        }
    }
}
