using GConta.Application.ViewModel;
using GConta.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GConta.Application.Interfaces
{
    public interface ITransacaoAppService : IAppServiceBase<Transacao>
    {
        IEnumerable<ExtratoViewModel> ObterExtrato(int idConta, Periodo periodo = null);
        Task<IEnumerable<ExtratoViewModel>> ObterExtratoAsync(int idConta, Periodo periodo = null);
        //IEnumerable<ExtratoViewModel> ObterExtrato(int idConta, DateTime dtInicial, DateTime dtFinal);
        //Task<IEnumerable<ExtratoViewModel>> ObterExtratoAsync(int idConta, DateTime dtInicial, DateTime dtFinal);

        void Saque(TransacaoViewModel obj);
        Task SaqueAsync(TransacaoViewModel obj);

        void Deposito(TransacaoViewModel obj);
        Task DepositoAsync(TransacaoViewModel obj);
    }
}
