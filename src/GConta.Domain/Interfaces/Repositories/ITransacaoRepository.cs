using GConta.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GConta.Domain.Interfaces.Repositories
{
    public interface ITransacaoRepository : IRepositoryBase<Transacao>
    {
        IEnumerable<Transacao> ObterExtrato(int idConta);
        Task<IEnumerable<Transacao>> ObterExtratoAsync(int idConta);
        IEnumerable<Transacao> ObterExtrato(int idConta,DateTime dtInicial, DateTime dtFinal);
        Task<IEnumerable<Transacao>> ObterExtratoAsync(int idConta, DateTime dtInicial, DateTime dtFinal);
        decimal ObterTotalSaqueDia(int idConta);
        Task<decimal> ObterTotalSaqueDiaAsync(int idConta);
    }
}
