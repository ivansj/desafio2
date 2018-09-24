using AutoMoqCore;
using FluentAssertions;
using GConta.Domain.Entities;
using GConta.Domain.Interfaces;
using GConta.Domain.Interfaces.Repositories;
using GConta.Domain.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace GConta.Tests
{
    public class TransacaoServiceTests
    {
        private Mock<ITransacaoRepository> _transacaoRepositoryMock { get; set; }
        private Mock<IContaRepository> _contaRepositoryMock { get; set; }
        private Mock<IUnitOfWork> _unitOfWorkMock { get; set; }

        private TransacaoService GetTransacaoService()
        {
            var mocker = new AutoMoqer();
            mocker.Create<TransacaoService>();

            var contaService = mocker.Resolve<TransacaoService>();

            _transacaoRepositoryMock = mocker.GetMock<ITransacaoRepository>();
            _contaRepositoryMock = mocker.GetMock<IContaRepository>();
            _unitOfWorkMock = mocker.GetMock<IUnitOfWork>();

            return contaService;
        }

        private Conta GetContaValida()
        {
            var conta = new Conta {
                idConta = 1,
                idPessoa = 1,
                limiteSaqueDiario = 1000,
                tipoConta = 0,
                flagAtivo = true,
                dataCriacao = DateTime.Now,
                saldo = 2000
            };
            return conta;
        }

        private Transacao ObterTransacao()
        {
            var transacao = new Transacao
            {
                idConta = 1,
                dataTransacao = DateTime.Now,
                valor = 100
            };
            return transacao;
        }

        [Fact]
        public async Task TestarSaqueAsync()
        {
            var transacaoService = GetTransacaoService();

            var conta = GetContaValida();
            _contaRepositoryMock.Setup(c => c.GetByIdAsync(conta.idConta)).ReturnsAsync(conta);

            var transacao = ObterTransacao();

            await transacaoService.SaqueAsync(transacao);
        }

        [Fact]
        public async Task TestarSaqueSemSaldoAsync()
        {
            var transacaoService = GetTransacaoService();

            var conta = GetContaValida();
            conta.saldo = 0;
            _contaRepositoryMock.Setup(c => c.GetByIdAsync(conta.idConta)).ReturnsAsync(conta);

            var transacao = ObterTransacao();

            await Assert.ThrowsAsync<ArgumentException>(() => transacaoService.SaqueAsync(transacao));
        }

        [Fact]
        public async Task TestarDepositoAsync()
        {
            var transacaoService = GetTransacaoService();

            var conta = GetContaValida();
            _contaRepositoryMock.Setup(c => c.GetByIdAsync(conta.idConta)).ReturnsAsync(conta);

            var transacao = ObterTransacao();

            await transacaoService.DepositoAsync(transacao);
        }

        [Fact]
        public async Task TestarDepositoContaInativaAsync()
        {
            var transacaoService = GetTransacaoService();

            var conta = GetContaValida();
            conta.flagAtivo = false;
            _contaRepositoryMock.Setup(c => c.GetByIdAsync(conta.idConta)).ReturnsAsync(conta);

            var transacao = ObterTransacao();

            await Assert.ThrowsAsync<ArgumentException>(() => transacaoService.DepositoAsync(transacao));
        }

        private IEnumerable<Transacao> GetListaTransacoes()
        {
            var lista = new List<Transacao>();


            var transacao = new Transacao
            {
                idTransacao = 1,
                idConta = 1,
                valor = 100,
                dataTransacao = DateTime.Now.AddDays(-1)
            };
            lista.Add(transacao);

            transacao = new Transacao
            {
                idTransacao = 2,
                idConta = 1,
                valor = -50,
                dataTransacao = DateTime.Now.AddDays(-1)
            };
            lista.Add(transacao);


            transacao = new Transacao
            {
                idTransacao = 3,
                idConta = 1,
                valor = -30,
                dataTransacao = DateTime.Now
            };


            transacao = new Transacao
            {
                idTransacao = 4,
                idConta = 1,
                valor = 60,
                dataTransacao = DateTime.Now
            };
            lista.Add(transacao);

            return lista;
        }

        [Fact]
        public async Task TestarExtratoAsync()
        {
            var transacaoService = GetTransacaoService();

            var conta = GetContaValida();
            _contaRepositoryMock.Setup(c => c.GetByIdAsync(conta.idConta)).ReturnsAsync(conta);

            _transacaoRepositoryMock.Setup(t => t.ObterExtratoAsync(conta.idConta)).ReturnsAsync(GetListaTransacoes());

            var extrato = await transacaoService.ObterExtratoAsync(conta.idConta);

            extrato.Should().HaveCount(t => t > 1);
        }


        [Fact]
        public async Task TestarExtratoPeriodoComDadosAsync()
        {
            var transacaoService = GetTransacaoService();

            var conta = GetContaValida();
            _contaRepositoryMock.Setup(c => c.GetByIdAsync(conta.idConta)).ReturnsAsync(conta);

            _transacaoRepositoryMock.Setup(t => t.ObterExtratoAsync(conta.idConta, DateTime.Today, DateTime.Today.AddDays(1)))
                .ReturnsAsync(GetListaTransacoes());

            var extrato = await transacaoService.ObterExtratoAsync(conta.idConta, DateTime.Today, DateTime.Today.AddDays(1));

            extrato.Should().HaveCount(t => t > 1);
        }

        [Fact]
        public async Task TestarExtratoPeriodoSemDadosAsync()
        {
            var transacaoService = GetTransacaoService();

            var conta = GetContaValida();
            _contaRepositoryMock.Setup(c => c.GetByIdAsync(conta.idConta)).ReturnsAsync(conta);

            _transacaoRepositoryMock.Setup(t => t.ObterExtratoAsync(conta.idConta, DateTime.Today, DateTime.Today.AddDays(1)))
               .ReturnsAsync(GetListaTransacoes());

            var extrato = await transacaoService.ObterExtratoAsync(conta.idConta, DateTime.Today.AddYears(-1), DateTime.Today.AddYears(-11));

            extrato.Should().BeEmpty();
        }
    }
}
