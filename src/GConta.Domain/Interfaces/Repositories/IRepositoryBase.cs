using System.Collections.Generic;
using System.Threading.Tasks;

namespace GConta.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        Task AddAsync(TEntity obj);
        TEntity GetById(int id);
        Task<TEntity> GetByIdAsync(int id);
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
        void Update(TEntity obj);
        //Task UpdateAsync(TEntity obj);
        void Remove(TEntity obj);
        //Task RemoveAsync(TEntity obj);
        void Dispose();
    }
}
