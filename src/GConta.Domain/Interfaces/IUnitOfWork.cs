using System;
using System.Threading.Tasks;

namespace GConta.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        Task SaveAsync();
    }
}
