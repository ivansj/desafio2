using AutoMapper;
using GConta.Application.Interfaces;
using GConta.Application.ViewModel;
using GConta.Domain.Entities;
using GConta.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace GConta.Application
{
    public class ContaAppService : AppServiceBase<Conta>, IContaAppService
    {
        private readonly IContaService _contaService;
        private readonly IMapper _mapper;
        public ContaAppService(IContaService service, IMapper mapper) : base(service)
        {
            _contaService = service;
            _mapper = mapper;
        }

        public int Add(ContaViewModel obj)
        {
            var conta = _mapper.Map<Conta>(obj);
            conta.dataCriacao = DateTime.Now;
            conta.flagAtivo = true;
            Add(conta);
            obj.idConta = conta.idConta;
            return conta.idConta;
        }

        public async Task<int> AddAsync(ContaViewModel obj)
        {
            var conta = _mapper.Map<Conta>(obj);
            conta.dataCriacao = DateTime.Now;
            conta.flagAtivo = true;
            await AddAsync(conta);
            obj.idConta = conta.idConta;
            return conta.idConta;
        }

        public void Bloquear(int idConta)
        {
            var conta = GetById(idConta);
            if(conta != null && conta.flagAtivo)
            {
                conta.flagAtivo = false;
                Update(conta);
            }
        }

        public async Task BloquearAsync(int idConta)
        {
            var conta = await GetByIdAsync(idConta);
            if (conta != null && conta.flagAtivo)
            {
                conta.flagAtivo = false;
                await UpdateAsync(conta);
            }
        }

        public decimal ObterSaldo(int idConta)
        {
            return _contaService.ObterSaldo(idConta);
        }

        public async Task<decimal> ObterSaldoAsync(int idConta)
        {
            return await _contaService.ObterSaldoAsync(idConta);
        }
    }
}
