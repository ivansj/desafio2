using AutoMoqCore;
using GConta.Domain.Entities;
using GConta.Domain.Interfaces;
using GConta.Domain.Interfaces.Repositories;
using GConta.Domain.Services;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GConta.Tests
{
    public class ContaServiceTests
    {
        //private Mock<IContaAppService> mock;
        private Mock<IContaRepository>_contaRepositoryMock { get; set; }
        private Mock<IUnitOfWork> _unitOfWorkMock { get; set; }
        //private Mock<ContaService> ContaServiceMock { get; set; }
        //private ContaService _contaService;

        public ContaServiceTests()
        {
           
        }

        private ContaService GetContaService()
        {
            var mocker = new AutoMoqer();
            mocker.Create<ContaService>();

            var contaService = mocker.Resolve<ContaService>();

            _contaRepositoryMock = mocker.GetMock<IContaRepository>();
            _unitOfWorkMock = mocker.GetMock<IUnitOfWork>();

            return contaService;
        }

        [Fact]
        public async Task TestarCriarContaSucessoAsync()
        {
            var conta = GetContaValida();

            var contaService = GetContaService();

            //Act
            await contaService.AddAsync(conta);

            _contaRepositoryMock.Verify(r => r.AddAsync(It.IsAny<Conta>()),Times.Once);

        }

        //[Fact]
        //public async Task TestarCriarContaFalhaAsync()
        //{
        //    var conta = new Conta { idPessoa = 0, limiteSaqueDiario = 1000, tipoConta = 0, flagAtivo = true, dataCriacao = DateTime.Now };

        //    var contaService = GetContaService();

        //    //Act
        //    await contaService.AddAsync(conta);

        //    _contaRepositoryMock.Verify(r => r.AddAsync(It.IsAny<Conta>()), Times.Never);
        //}

        private Conta GetContaValida()
        {
            var conta = new Conta { idPessoa = 0, limiteSaqueDiario = 1000, tipoConta = 0, flagAtivo = true, dataCriacao = DateTime.Now };
            return conta;
        }

        

        [Fact]
        public async Task TestarObterSaldoSucessoAsync()
        {
            const int idConta = 1;

            var contaService = GetContaService();

            var conta = GetContaValida();
            conta.saldo = 1000;
            conta.idConta = idConta;
            _contaRepositoryMock.Setup(c => c.GetByIdAsync(1)).ReturnsAsync(conta);
                        
            //Act
            var saldo = await contaService.ObterSaldoAsync(idConta);    
        }

        [Fact]
        public async Task TestarObterSaldoInativoAsync()
        {
            const int idConta = 1;

            var contaService = GetContaService();


            var conta = GetContaValida();
            conta.saldo = 1000;
            conta.idConta = idConta;
            conta.flagAtivo = false;
            _contaRepositoryMock.Setup(c => c.GetByIdAsync(1)).ReturnsAsync(conta);


            //Act
            await Assert.ThrowsAsync<ArgumentException>(() => contaService.ObterSaldoAsync(idConta));
        }
    }
}
