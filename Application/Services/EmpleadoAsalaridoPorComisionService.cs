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
    public class EmpleadoAsalaridoPorComisionService : Service<EmpleadoAsalaridoPorComision>
    {
        private readonly IRepository<EmpleadoAsalaridoPorComision> _repository;

        public EmpleadoAsalaridoPorComisionService(
            IRepository<EmpleadoAsalaridoPorComision> repository,
            ILogger<EmpleadoAsalaridoPorComisionService> logger)
            : base(repository, logger)
        {
            _repository = repository;
        }

        public async Task CreateEmpleadoPorComision(CreateEmpleadoPorComisionDto dto)
        {
            if (dto is null) throw new ArgumentNullException(nameof(dto));

            var entity = new EmpleadoAsalaridoPorComision(
                tipoDeEmpleado: "Empleado Por Comisión",
                nombre: dto.Nombre,
                apellido: dto.Apellido,
                numeroDeSeguro: dto.NumeroDeSeguro,
                salarioBase: dto.SalarioBase,
                ventaBruta: dto.VentaBruta,
                tarifaPorComision: dto.TarifaPorComision,
                pagoSemanal:dto.PagoSemanal
            );

            await AddAsync(entity);
            LogInformation("Empleado por comisión creado: NSS {nss}", entity.NumeroDeSeguro);
        }

        public async Task UpdateEmpleadoPorComision(int id, UpdateEmpleadoPorComisionDto dto)
        {
            if (dto is null) throw new ArgumentNullException(nameof(dto));

            var entity = await GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Empleado con id {id} no encontrado");

            entity.NumeroDeSeguro = dto.NumeroDeSeguro;
            entity.SalarioBase = dto.SalarioBase;
            entity.VentaBruta = dto.VentaBruta;
            entity.TarifaPorComision = dto.TarifaPorComision;

            await UpdateAsync(entity);
            LogInformation("Empleado por comisión actualizado: Id {id}", id);
        }

        public async Task DisableEmpleadoPorComision(int id, DisableEmpleadoPorComisionDto dto)
        {
            await Disable(id);
            LogInformation("Empleado por comisión deshabilitado: Id {id}", id);
        }

        public async Task<IEnumerable<EmpleadoAsalaridoPorComision>> GetAllEmpleadoPorComision(GetActiveEmpleadoPorComisionDto dto)
        {
            var empleados = await GetAllAsync();
            LogInformation("Se obtuvieron {count} empleados por comisión", empleados.Count());
            return empleados;
        }

        public async Task<EmpleadoAsalaridoPorComision?> ObtenerPorIdAsync(int id)
        {
            var empleado = await GetByIdAsync(id);
            LogInformation(empleado == null
                ? "Empleado por comisión con Id {id} no encontrado"
                : "Empleado por comisión obtenido: Id {id}", id);
            return empleado;
        }

        public decimal CalcularPago(EmpleadoAsalaridoPorComision empleado)
        {
            try
            {
                if (empleado == null)
                {
                    LogWarning("Intento de cálculo con empleado nulo");
                    throw new ArgumentNullException(nameof(empleado));
                }

                if (empleado.SalarioBase < 0 || empleado.VentaBruta < 0 || empleado.TarifaPorComision < 0)
                {
                    LogWarning("Datos inválidos para NSS {nss}: salarioBase={salario}, ventas={ventas}, comision={comision}",
                        empleado.NumeroDeSeguro,
                        empleado.SalarioBase,
                        empleado.VentaBruta,
                        empleado.TarifaPorComision);

                    throw new ArgumentException("Los valores deben ser mayores o iguales a cero.");
                }

                LogInformation("Calculando pago para NSS: {nss}", empleado.NumeroDeSeguro);

                var pago = empleado.SalarioBase + (empleado.VentaBruta * empleado.TarifaPorComision);

                LogInformation("Pago calculado para NSS: {nss} = {pago}", empleado.NumeroDeSeguro, pago);

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
                LogWarning("No se encontró empleado por comisión con Id {id}", id);
                throw new KeyNotFoundException($"Empleado con id {id} no encontrado");
            }

            return CalcularPago(empleado);
        }
    }
}
