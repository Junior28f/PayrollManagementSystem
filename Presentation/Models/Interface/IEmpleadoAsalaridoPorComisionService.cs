using PayrollManagementSystem.Models.EmpleadoAsalaridoPorComision;

namespace PayrollManagementSystem.Models.Interface
{
    public interface IEmpleadoAsalariadoPorComisionService
    {

        Task<List<EmpleadoAsalaridoPorComisionModel>> GetAllEmpleadoAsalariadoPorComision();
        Task<DetaisEmpleadoAsalaridoPorComisionModel?> GetEmpleadoAsalariadoPorComisionById(int numeroDeSeguro);
        Task<bool> UpdateEmpleadoAsalariadoPorComision(int numeroDeSeguro, EditEmpleadoAsalaridoPorComisionModel model);
        Task<DisableEmpleadoAsalaridoPorComisionModel?> GetDisableModelAsync(int numeroDeSeguro);
        Task<bool> DisableEmpleadoAsalariadoPorComision(int numeroDeSeguro, DisableEmpleadoAsalaridoPorComisionModel model);
        Task<bool> CreateEmpleadoAsalariadoPorComision(CreateEmpleadoAsalaridoPorComisionModel model);
    }
}

       