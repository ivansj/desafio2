using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GConta.Application.Interfaces;
using GConta.Application.ViewModel;
using GConta.Domain.Entities;
using GConta.Domain.Interfaces.Services;

namespace GConta.Application
{
    /// <summary>
    /// Serviço de aplicação de Transacao
    /// </summary>
    public class TransacaoAppService : AppServiceBase<Transacao>, ITransacaoAppService
    {
        private readonly ITransacaoService _transacaoService;
        private readonly IContaService _contaService;
        private readonly IMapper _mapper;
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="service"></param>
        /// <param name="contaService"></param>
        /// <param name="mapper"></param>
        public TransacaoAppService(ITransacaoService service, IContaService contaService, IMapper mapper) : base(service)
        {
            _transacaoService = service;
            _contaService = contaService;
            _mapper = mapper;
        }

        /// <summary>
        /// Depósito
        /// </summary>
        /// <param name="obj"></param>
        public void Deposito(TransacaoViewModel obj)
        {
            var transacao = _mapper.Map<Transacao>(obj);
            _transacaoService.Deposito(transacao);
        }
        
        /// <summary>
        /// Depósito
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task DepositoAsync(TransacaoViewModel obj)
        {
            var transacao = _mapper.Map<Transacao>(obj);
             await _transacaoService.DepositoAsync(transacao);   
        }      

        /// <summary>
        /// Obter Extrato
        /// </summary>
        /// <param name="idConta"></param>
        /// <param name="periodo"></param>
        /// <returns></returns>
        public IEnumerable<ExtratoViewModel> ObterExtrato(int idConta, Periodo periodo = null)
        {
            IEnumerable<Transacao> extrato;
            if (periodo == null)
                extrato = _transacaoService.ObterExtrato(idConta);
            else
                extrato = _transacaoService.ObterExtrato(idConta, periodo.DtInicial, periodo.DtFinal);

            return extrato.Select(e => _mapper.Map<ExtratoViewModel>(e));
        }
               
        /// <summary>
        /// Obter extra
        /// </summary>
        /// <param name="idConta"></param>
        /// <param name="periodo"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ExtratoViewModel>> ObterExtratoAsync(int idConta, Periodo periodo = null)
        {
            IEnumerable<Transacao> extrato;
            if (periodo == null)
                extrato = await _transacaoService.ObterExtratoAsync(idConta);
            else
                extrato = await _transacaoService.ObterExtratoAsync(idConta, periodo.DtInicial, periodo.DtFinal);

            return extrato.Select(e => _mapper.Map<ExtratoViewModel>(e));
        }

        /// <summary>
        /// Efetua Saque
        /// </summary>
        /// <param name="obj"></param>
        public void Saque(TransacaoViewModel obj)
        {
            var transacao = _mapper.Map<Transacao>(obj);
            _transacaoService.Saque(transacao);
        }

        /// <summary>
        /// Efetua Saque
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task SaqueAsync(TransacaoViewModel obj)
        {
            var transacao = _mapper.Map<Transacao>(obj);
            await _transacaoService.SaqueAsync(transacao);
        }
    }
}
