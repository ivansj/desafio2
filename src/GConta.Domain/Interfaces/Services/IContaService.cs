using GConta.Domain.Entities;
using System.Threading.Tasks;

namespace GConta.Domain.Interfaces.Services
{
    public interface IContaService : IServiceBase<Conta>
    {
        decimal ObterSaldo(int idConta);
        Task<decimal> ObterSaldoAsync(int idConta);
    }
}
