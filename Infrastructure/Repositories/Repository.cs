using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassLibrary1.Interfaces.Repositories;
using Infrastructure.Base;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories
{
    public class Repository<T> : LoggerBase, IRepository<T> where T : class
    {
        protected readonly AppDbContext Context;
        protected readonly DbSet<T> DbSet;

        protected Repository(AppDbContext context, ILogger  logger)
            : base(logger)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            DbSet = Context.Set<T>();
        }

        public  async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                LogInformation("Obteniendo todos los registros de {Entity}", typeof(T).Name);
                return await DbSet.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                LogError(ex, "Error al obtener todos los registros de {Entity}", typeof(T).Name);
                return Array.Empty<T>();
            }
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                LogError(null, "ID inválido para {Entity}: {Id}", typeof(T).Name, id);
                return null;
            }

            try
            {
                return await DbSet.FindAsync(id);
            }
            catch (Exception ex)
            {
                LogError(ex, "Error al obtener {Entity} por ID {Id}", typeof(T).Name, id);
                return null;
            }
        }

        public async Task AddAsync(T entity)
        {
            if (entity is null)
            {
                LogError(null, "Entidad nula al intentar agregar {Entity}", typeof(T).Name);
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                await DbSet.AddAsync(entity);
                await Context.SaveChangesAsync();
                LogInformation("{Entity} agregado correctamente", typeof(T).Name);
            }
            catch (Exception ex)
            {
                LogError(ex, "Error al agregar {Entity}", typeof(T).Name);
                throw; 
            }
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity is null)
            {
                LogError(null, "Entidad nula al intentar actualizar {Entity}", typeof(T).Name);
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                DbSet.Update(entity);
                await Context.SaveChangesAsync();
                LogInformation("{Entity} actualizado correctamente", typeof(T).Name);
            }
            catch (Exception ex)
            {
                LogError(ex, "Error al actualizar {Entity}", typeof(T).Name);
                throw;
            }
        }

        public async Task Disable(int id)
        {
            if (id <= 0)
            {
                LogError(null, "ID inválido para eliminar {Entity}: {Id}", typeof(T).Name, id);
                return;
            }

            try
            {
                var entity = await DbSet.FindAsync(id);
                if (entity is null)
                {
                    LogInformation("{Entity} con ID {Id} no encontrado para eliminación", typeof(T).Name, id);
                    return;
                }

                DbSet.Remove(entity);
                await Context.SaveChangesAsync();
                LogInformation("{Entity} con ID {Id} eliminado correctamente", typeof(T).Name, id);
            }
            catch (Exception ex)
            {
                LogError(ex, "Error al eliminar {Entity} con ID {Id}", typeof(T).Name, id);
                throw;
            }
        }
    }
}
