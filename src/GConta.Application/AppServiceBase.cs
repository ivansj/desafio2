using GConta.Application.Interfaces;
using GConta.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GConta.Application
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _service;

        public AppServiceBase(IServiceBase<TEntity> service)
        {
            _service = service;
        }

        public void Add(TEntity obj)
        {
            _service.Add(obj);
        }

        public async Task AddAsync(TEntity obj)
        {
            await _service.AddAsync(obj);
        }
              

        public IEnumerable<TEntity> GetAll()
        {
            return _service.GetAll();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _service.GetAllAsync();
        }

        public TEntity GetById(int id)
        {
            return _service.GetById(id);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _service.GetByIdAsync(id);
        }

        public void Remove(TEntity obj)
        {
            _service.Remove(obj);
        }

        public async Task RemoveAsync(TEntity obj)
        {
            await _service.RemoveAsync(obj);
        }

        public void Update(TEntity obj)
        {
            _service.Update(obj);
        }

        public async Task UpdateAsync(TEntity obj)
        {
            await _service.UpdateAsync(obj);
        }

        public void Dispose()
        {
            _service.Dispose();
        }
    }
}
