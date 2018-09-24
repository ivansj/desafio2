using GConta.Application.Interfaces;
using GConta.Application.Response;
using GConta.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GConta.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Transacao")]
    public class TransacaoController : ApiBaseController
    {
        private readonly ITransacaoAppService _transacaoApp;

        public TransacaoController(ITransacaoAppService transacaoApp)
        {
            _transacaoApp = transacaoApp;
        }

        /// <summary>
        /// Efetua um depósito
        /// </summary>
        /// <param name="deposito">transação de depósito</param>
        /// <returns></returns>
        [HttpPost]
        [Route("~/api/Deposito")]
        [ProducesResponseType(200, Type = typeof(ResponseApi))]
        [ProducesResponseType(400, Type = typeof(ResponseErro))]
        public async Task<IActionResult> DepositoAsync([FromBody]TransacaoViewModel deposito)
        {
            if (!ModelState.IsValid)
            {
                return ResponseErro();
            }
            await _transacaoApp.DepositoAsync(deposito);
            return ResponseSucesso();
        }

        /// <summary>
        /// Efetua um saque
        /// </summary>
        /// <param name="saque">transação de saque</param>
        /// <returns></returns>
        [HttpPost]
        [Route("~/api/Saque")]
        [ProducesResponseType(200, Type = typeof(ResponseApi))]
        [ProducesResponseType(400, Type = typeof(ResponseErro))]
        public async Task<IActionResult> Sacar([FromBody]TransacaoViewModel saque)
        {
            if (!ModelState.IsValid)
            {
                return ResponseErro();
            }
            await _transacaoApp.SaqueAsync(saque);
            return ResponseSucesso();
        }

        /// <summary>
        /// Obtem o Extrato da conta
        /// </summary>
        /// <param name="id">id da Conta</param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/Extrato/{id}")]
        [ProducesResponseType(200, Type = typeof(ResponseExtrato))]
        [ProducesResponseType(400, Type = typeof(ResponseErro))]
        public async Task<IActionResult> ObterExtrato(int id)
        {
            if (!ModelState.IsValid)
            {
                return ResponseErro();
            }
            var extrato = await _transacaoApp.ObterExtratoAsync(id, null);
            var retorno = new ResponseExtrato { extrato = extrato };
            return Ok(retorno);

        }


        /// <summary>
        /// Obtem o Extrato da conta por período
        /// </summary>
        /// <param name="id">id da Conta</param>
        /// <param name="periodo">Período</param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/ExtratoPeriodo/{id}")]
        [ProducesResponseType(200, Type = typeof(ResponseExtrato))]
        [ProducesResponseType(400, Type = typeof(ResponseErro))]
        public async Task<IActionResult> ObterExtratoPeriodo(int id, [FromBody]Periodo periodo)
        {
            if (!ModelState.IsValid)
            {
                return ResponseErro();
            }
            var extrato = await _transacaoApp.ObterExtratoAsync(id, periodo);
            var retorno = new ResponseExtrato { extrato = extrato };
            return Ok(retorno);

        }

        
    }
}