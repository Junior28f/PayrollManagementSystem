using ClassLibrary1.Dtos;
using Domain.Base;
using ClassLibrary1.Services.Base;
using Microsoft.Extensions.Logging;

namespace ClassLibrary1.Services
{
    public class GestorPagos : LoggerService
    {
        private readonly List<Empleado> empleados;

        public GestorPagos(ILogger<GestorPagos> logger) : base(logger)
        {
            empleados = new List<Empleado>();
        }

        public void AgregarEmpleado(Empleado empleado)
        {
            if (empleado == null)
                throw new ArgumentNullException(nameof(empleado));

            empleados.Add(empleado);
        }

        public decimal CalcularPagoTotal()
        {
            decimal total = 0;

            foreach (var e in empleados)
            {
                try
                {
                    total += e.Calcularpago();
                }
                catch (Exception ex)
                {
                    LogError(ex, "Error al calcular el pago para el empleado NSS {nss}", e.NumeroDeSeguro);
                }
            }

            return total;
        }

        public List<PagoEmpleadoDto> ObtenerPagosIndividuales()
        {
            var pagos = new List<PagoEmpleadoDto>();

            foreach (var e in empleados)
            {
                try
                {
                    pagos.Add(new PagoEmpleadoDto
                    {
                        NombreCompleto = $"{e.Nombre} {e.Apellido}",
                        TipoDeEmpleado = e.TipoDeEmpleado,
                        NumeroDeSeguro = e.NumeroDeSeguro,
                        Pago = e.Calcularpago()
                    });
                }
                catch (Exception ex)
                {
                    LogError(ex, "Error al generar el DTO de pago para el empleado NSS {nss}", e.NumeroDeSeguro);
                }
            }

            return pagos;
        }

        public void LimpiarEmpleados()
        {
            empleados.Clear();
        }
    }
}