using ClassLibrary1.Interfaces.Repositories;
using ClassLibrary1.Interfeces.Services;
using ClassLibrary1.Services.Base;
using Microsoft.Extensions.Logging;

namespace ClassLibrary1.Services
{
    public class Service<T> : LoggerService, IService<T> where T : class
    {
        protected readonly IRepository<T> _repository;

        protected Service(IRepository<T> repository, ILogger<Service<T>> logger)
            : base(logger)
        {
            _repository = repository;
        }

        public Task<IEnumerable<T>> GetAllAsync() => _repository.GetAllAsync();
        public Task<T?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task AddAsync(T entity) => _repository.AddAsync(entity);
        public Task UpdateAsync(T entity) => _repository.UpdateAsync(entity);
        public Task Disable(int id) => _repository.Disable(id);
    }
}