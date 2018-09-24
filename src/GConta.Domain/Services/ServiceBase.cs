using GConta.Domain.Interfaces;
using GConta.Domain.Interfaces.Repositories;
using GConta.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GConta.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;
        protected readonly IUnitOfWork _unitOfWork;

        public ServiceBase(IRepositoryBase<TEntity> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }


        public void Add(TEntity obj)
        {
            _repository.Add(obj);
            _unitOfWork.Save();
        }

        public async Task AddAsync(TEntity obj)
        {
            await _repository.AddAsync(obj);
            await _unitOfWork.SaveAsync();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public void Remove(TEntity obj)
        {
            _repository.Remove(obj);
            _unitOfWork.Save();
        }

        public async Task RemoveAsync(TEntity obj)
        {
            _repository.Remove(obj);
            await _unitOfWork.SaveAsync();
        }

        public void Update(TEntity obj)
        {
            _repository.Update(obj);
            _unitOfWork.Save();
        }

        public async Task UpdateAsync(TEntity obj)
        {
            _repository.Update(obj);
            await _unitOfWork.SaveAsync();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
