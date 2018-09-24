using GConta.Domain.Entities;
using GConta.Domain.Interfaces;
using GConta.Domain.Interfaces.Repositories;
using GConta.Domain.Interfaces.Services;
using GConta.Domain.Validation;
using System.Threading.Tasks;

namespace GConta.Domain.Services
{
    public class ContaService : ServiceBase<Conta>, IContaService
    {
        private readonly IContaRepository _contaRepository;
        public ContaService(IContaRepository repository, IUnitOfWork unitOfWork) 
            : base(repository, unitOfWork)
        {
            _contaRepository = repository;
        }

        public decimal ObterSaldo(int idConta)
        {
            var saldo = 0m;
            var conta = GetById(idConta);

            if (conta != null)
            {
                conta.ValidarContaAtiva();
                saldo = conta.saldo;
            }
            return saldo;
        }

        public async Task<decimal> ObterSaldoAsync(int idConta)
        {
            var saldo = 0m;
            var conta = await GetByIdAsync(idConta);
            if (conta != null)
            {
                conta.ValidarContaAtiva();
                saldo = conta.saldo;
            }
            return saldo;
        }
    }
}
