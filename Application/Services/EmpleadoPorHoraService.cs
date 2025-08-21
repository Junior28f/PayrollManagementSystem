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
    public class EmpleadoPorHoraService : Service<EmpleadoPorhoras>
    {
        private readonly IRepository<EmpleadoPorhoras> _repository;

        public EmpleadoPorHoraService(
            IRepository<EmpleadoPorhoras> repository,
            ILogger<EmpleadoPorHoraService> logger)
            : base(repository, logger)
        {
            _repository = repository;
        }

        public async Task CreateEmpleadoPorHora(CreateEmpleadoPorhorasDto dto)
        {
            if (dto is null) throw new ArgumentNullException(nameof(dto));

            var entity = new EmpleadoPorhoras(
                tipoDeEmpleado: "Empleado Por Hora",
                nombre: dto.Nombre,
                apellido: dto.Apellido,
                numeroDeSeguro: dto.NumeroDeSeguro,
                sueldoPorhora: dto.SueldoPorhora,
                horasTrabajadas: dto.HorasTrabajadas,
                pagoSemanal: dto.PagoSemanal
            );

            await AddAsync(entity);
            LogInformation("Empleado por hora creado: NSS {nss}", entity.NumeroDeSeguro);
        }

        public async Task UpdateEmpleadoPorHora(int id, UpdateEmpleadoPorhorasDto dto)
        {
            if (dto is null) throw new ArgumentNullException(nameof(dto));

            var entity = await GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Empleado con id {id} no encontrado");

            entity.NumeroDeSeguro = dto.NumeroDeSeguro;
            entity.SueldoPorhora = (decimal)dto.SueldoPorHora!;
            entity.HorasTrabajadas = (int)dto.HorasTrabajadas!;

            await UpdateAsync(entity);
            LogInformation("Empleado por hora actualizado: Id {id}", id);
        }

        public async Task DisableEmpleadoPorHora(int id, DisableEmpleadoPorhorasDto dto)
        {
            await Disable(id);
            LogInformation("Empleado por hora deshabilitado: Id {id}", id);
        }

        public async Task<IEnumerable<EmpleadoPorhoras>> GetAllEmpleadoPorHora(GetActiveEmpleadoPorhorasDto dto)
        {
            var empleados = await GetAllAsync();
            var allEmpleadoPorHora = empleados.ToList();
            LogInformation("Se obtuvieron {count} empleados por hora", allEmpleadoPorHora.Count);
            return allEmpleadoPorHora;
        }

        public async Task<EmpleadoPorhoras?> ObtenerPorIdAsync(int id)
        {
            var empleado = await GetByIdAsync(id);
            LogInformation(empleado == null
                ? "Empleado por hora con Id {id} no encontrado"
                : "Empleado por hora obtenido: Id {id}", id);
            return empleado;
        }

        public decimal CalcularPago(EmpleadoPorhoras empleado)
        {
            try
            {
                if (empleado == null)
                {
                    LogWarning("Intento de cálculo con empleado nulo");
                    throw new ArgumentNullException(nameof(empleado));
                }

                if (empleado.SueldoPorhora < 0 || empleado.HorasTrabajadas < 0)
                {
                    LogWarning("Datos inválidos para NSS {nss}: sueldoPorHora={sueldo}, horas={horas}",
                        empleado.NumeroDeSeguro,
                        empleado.SueldoPorhora,
                        empleado.HorasTrabajadas);

                    throw new ArgumentException("Los valores deben ser mayores o iguales a cero.");
                }

                LogInformation("Calculando pago para NSS: {nss}", empleado.NumeroDeSeguro);

                var pago = empleado.HorasTrabajadas <= 40
                    ? empleado.SueldoPorhora * empleado.HorasTrabajadas
                    : (40 * empleado.SueldoPorhora) + ((empleado.HorasTrabajadas - 40) * empleado.SueldoPorhora * 1.5m);

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
                LogWarning("No se encontró empleado por hora con Id {id}", id);
                throw new KeyNotFoundException($"Empleado con id {id} no encontrado");
            }

            return CalcularPago(empleado);
        }
    }
}
