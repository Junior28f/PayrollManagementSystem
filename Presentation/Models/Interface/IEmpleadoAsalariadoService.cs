using PayrollManagementSystem.Models.EmpleadoAsalariado;

namespace PayrollManagementSystem.Models.Interface
{
    public interface IEmpleadoAsalariadoService
    {
        Task<List<EmpleadoAsalariadoModel>> GetAllAEmpleadoAsalariado();
        Task<DetailsEmpleadoAsalariadoModel?> GetEmpleadoAsalariadoById(int numeroDeSeguro);
        Task<bool> UpdateEmpleadoAsalariado(int numeroDeSeguro, EditEmpleadoAsalariadoModel model);
        Task<bool> DisableEmpleadoAsalariado(int numeroDeSeguro, DisableEmpleadoAsalariado model);
        Task<bool> CreateEmpleadoAsalariado(CreateEmpleadoAsalariadoModel model);
      
    }
}