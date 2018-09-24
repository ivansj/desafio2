using GConta.Domain.Interfaces;
using GConta.Infra.Data.Context;
using System.Threading.Tasks;

namespace GConta.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GContaContext _context;

        public UnitOfWork(GContaContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
