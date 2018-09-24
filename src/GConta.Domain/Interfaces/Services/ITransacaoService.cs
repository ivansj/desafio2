using GConta.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GConta.Domain.Interfaces.Services
{
    public interface ITransacaoService : IServiceBase<Transacao>
    {
        IEnumerable<Transacao> ObterExtrato(int idConta);
        Task<IEnumerable<Transacao>> ObterExtratoAsync(int idConta);
        IEnumerable<Transacao> ObterExtrato(int idConta, DateTime dtInicial, DateTime dtFinal);
        Task<IEnumerable<Transacao>> ObterExtratoAsync(int idConta, DateTime dtInicial, DateTime dtFinal);

        void Saque(Transacao obj);
        Task SaqueAsync(Transacao obj);

        void Deposito(Transacao obj);
        Task DepositoAsync(Transacao obj);
    }
}
