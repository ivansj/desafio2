using GConta.Application.ViewModel;
using GConta.Domain.Entities;
using System.Threading.Tasks;

namespace GConta.Application.Interfaces
{
    public interface IContaAppService : IAppServiceBase<Conta>
    {
        decimal ObterSaldo(int idConta);
        Task<decimal> ObterSaldoAsync(int idConta);
        void Bloquear(int idConta);
        Task BloquearAsync  (int idConta);
        int Add(ContaViewModel obj);
        Task<int> AddAsync(ContaViewModel obj);
    }
}
