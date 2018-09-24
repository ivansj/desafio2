using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GConta.Domain.Entities;
using GConta.Domain.Interfaces.Repositories;
using GConta.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GConta.Infra.Data.Repositories
{
    public class TransacaoRepository : RepositoryBase<Transacao>, ITransacaoRepository
    {
        public TransacaoRepository(GContaContext context) : base(context)
        {

        }

        public IEnumerable<Transacao> ObterExtrato(int idConta)
        {
            return _context.Set<Transacao>().AsNoTracking().Where(t => t.idConta == idConta);
        }

        public IEnumerable<Transacao> ObterExtrato(int idConta, DateTime dtInicial, DateTime dtFinal)
        {
            return _context.Set<Transacao>().AsNoTracking().Where(t => t.idConta == idConta && t.dataTransacao.Date >= dtInicial.Date && t.dataTransacao.Date >= dtFinal.Date);
        }

        

        public async Task<IEnumerable<Transacao>> ObterExtratoAsync(int idConta, DateTime dtInicial, DateTime dtFinal)
        {
            return await _context.Set<Transacao>().AsNoTracking().Where(t => t.idConta == idConta && t.dataTransacao.Date >= dtInicial.Date && t.dataTransacao.Date >= dtFinal.Date).ToListAsync();
    }

        public async Task<IEnumerable<Transacao>> ObterExtratoAsync(int idConta)
        {
            return await _context.Set<Transacao>().AsNoTracking().Where(t => t.idConta == idConta).ToListAsync();
        }

        public decimal ObterTotalSaqueDia(int idConta)
        {
            return _context.Set<Transacao>().AsNoTracking().Where(t => t.idConta == idConta && t.dataTransacao.Date == DateTime.Today && t.valor < 0).Sum(t => Math.Abs(t.valor));
        }

        public async Task<decimal> ObterTotalSaqueDiaAsync(int idConta)
        {
            return await _context.Set<Transacao>().AsNoTracking().Where(t => t.idConta == idConta && t.dataTransacao.Date == DateTime.Today && t.valor < 0).SumAsync(t => Math.Abs(t.valor));
        }
    }
}
