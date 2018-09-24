using GConta.Domain.Entities;
using GConta.Domain.Interfaces;
using GConta.Domain.Interfaces.Repositories;
using GConta.Domain.Interfaces.Services;
using GConta.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GConta.Domain.Services
{
    public class TransacaoService : ServiceBase<Transacao>, ITransacaoService
    {
        private readonly ITransacaoRepository _transacaoRepository;
        private readonly IContaRepository _contaRepository;
        public TransacaoService(ITransacaoRepository repository, IContaRepository contaRepository, IUnitOfWork unitOfWork) : 
            base(repository, unitOfWork)
        {
            _transacaoRepository = repository;
            _contaRepository = contaRepository;
        }

        public IEnumerable<Transacao> ObterExtrato(int idConta, DateTime dtInicial, DateTime dtFinal)
        {
            var conta = _contaRepository.GetById(idConta);
            conta.ValidarContaAtiva();
            return _transacaoRepository.ObterExtrato(idConta, dtInicial, dtFinal);   
        }

        public async Task<IEnumerable<Transacao>> ObterExtratoAsync(int idConta, DateTime dtInicial, DateTime dtFinal)
        {
            var conta = await _contaRepository.GetByIdAsync(idConta);
            conta.ValidarContaAtiva();
            return await _transacaoRepository.ObterExtratoAsync(idConta, dtInicial, dtFinal);
        }

        public IEnumerable<Transacao> ObterExtrato(int idConta)
        {
            var conta = _contaRepository.GetById(idConta);
            conta.ValidarContaAtiva();
            return _transacaoRepository.ObterExtrato(idConta);
        }      

        public async Task<IEnumerable<Transacao>> ObterExtratoAsync(int idConta)
        {
            var conta = await _contaRepository.GetByIdAsync(idConta);
            conta.ValidarContaAtiva();
            return await _transacaoRepository.ObterExtratoAsync(idConta);
        }

        private static void TratarSaque(Transacao obj)
        {
            obj.dataTransacao = DateTime.Now;
            if (obj.valor > 0)
                obj.valor *= -1;
        }
      
        private void ValidarContaAtiva(Transacao obj, Conta conta)
        {
            conta.ValidarContaAtiva();

            if (Math.Abs(obj.valor) > conta.saldo)
                throw new ArgumentException(string.Format("Valor solicitado maior que o saldo atual: {0:N2}.", conta.saldo));
        }

        

        public void Saque(Transacao obj)
        {
            TratarSaque(obj);

            var conta = _contaRepository.GetById(obj.idConta);

            ValidarContaAtiva(obj, conta);
            
            if(conta.limiteSaqueDiario > 0)
            {
                var total = _transacaoRepository.ObterTotalSaqueDia(obj.idConta);
                var disponivel = conta.limiteSaqueDiario - total;
                if (Math.Abs(obj.valor) > disponivel)
                {

                    throw new ArgumentException(string.Format("Saque acima do limite diário dispónivel: Limite total diário {0:N2} Limite utilizado {1:N2}.", conta.limiteSaqueDiario, total));
                }
            }

            _transacaoRepository.Add(obj);

            conta.saldo -= obj.valor;
            _contaRepository.Update(conta);
            _unitOfWork.Save();
        }

        public async Task SaqueAsync(Transacao obj)
        {
            TratarSaque(obj);

            var conta = await _contaRepository.GetByIdAsync(obj.idConta);

            ValidarContaAtiva(obj, conta);

            if (conta.limiteSaqueDiario > 0)
            {
                var total = await _transacaoRepository.ObterTotalSaqueDiaAsync(obj.idConta);
                var disponivel = conta.limiteSaqueDiario - total;
                if (Math.Abs(obj.valor) > disponivel)
                {

                    throw new ArgumentException(string.Format("Saque acima do limite diário dispónivel: Limite total diário {0:N2} Limite utilizado {1:N2}.", conta.limiteSaqueDiario, total));
                }
            }

            await _transacaoRepository.AddAsync(obj);
            
            conta.saldo -= obj.valor;
            _contaRepository.Update(conta);
            await _unitOfWork.SaveAsync();

        }

        private static void TratarDeposito(Transacao obj)
        {
            obj.dataTransacao = DateTime.Now;
            if (obj.valor < 0)
                obj.valor = Math.Abs(obj.valor);
        }

        public void Deposito(Transacao obj)
        {
            var conta = _contaRepository.GetById(obj.idConta);

            conta.ValidarContaAtiva();

            _transacaoRepository.Add(obj);

            conta.saldo += obj.valor;
            _contaRepository.Update(conta);
            _unitOfWork.Save();
        }

        public async Task DepositoAsync(Transacao obj)
        {
            var conta = await _contaRepository.GetByIdAsync(obj.idConta);

            conta.ValidarContaAtiva();

            await _transacaoRepository.AddAsync(obj);

            conta.saldo += obj.valor;
            _contaRepository.Update(conta);
            await _unitOfWork.SaveAsync();
        }
    }
}
