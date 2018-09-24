using GConta.Domain.Interfaces.Repositories;
using GConta.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GConta.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected GContaContext _context;

        public RepositoryBase(GContaContext context)
        {
            _context = context;
        }

        public void Add(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
        }

        public async Task AddAsync(TEntity obj)
        {
           await _context.Set<TEntity>().AddAsync(obj);
        }       

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public void Remove(TEntity obj)
        {
            _context.Set<TEntity>().Remove(obj);
        }

        //public async Task RemoveAsync(TEntity obj)
        //{
        //    _context.Set<TEntity>().Remove(obj);
        //}

        public void Update(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
        }

        //public async Task UpdateAsync(TEntity obj)
        //{
        //    _context.Entry(obj).State = EntityState.Modified;
        //}

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
