using PayrollManagementSystem.Models.EmpleadoPorHoras;

namespace PayrollManagementSystem.Models.Interface;

public interface IEmpleadoPorHorasService
{
    Task<List<EmpleadoPorHoraModel>> GetAllEmpleadoPorHoraModel();
    Task<DetaisEmpleadoPorHoraModel?> GetEmpleadoPorHoraModelById(int numeroDeSeguro);
    Task<bool> UpdateEmpleadoPorHoraModel(int numeroDeSeguro, EditEmpleadoPorHoraModel model);
    Task<bool> DisableEmpleadoPorHoraModel(int numeroDeSeguro, DisableEmpleadoPorHoraModel model);
    Task<bool> CreateEmpleadoPorHoraModel(CreateEmpleadoPorHoraModel model);
}