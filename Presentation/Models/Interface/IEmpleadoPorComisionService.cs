
using PayrollManagementSystem.Models.EmpleadoPorComision;

namespace PayrollManagementSystem.Models.Interface;

public interface IEmpleadoPorComisionService
{
    Task<List<EmpleadoPorComisionModel>> GetAllEmpleadoPorComision();
    Task<DetaisEmpleadoPorComisionModel?> GetEmpleadoPorComisionById(int numeroDeSeguro);
    Task<bool> UpdateEmpleadoPorComision(int numeroDeSeguro, EditEmpleadoPorComisionModel model);
    Task<bool> DisableEmpleadoPorComision(int numeroDeSeguro);
    Task<bool> CreateEmpleadoPorComision(CreateEmpleadoPorComisionModel model);


  
}