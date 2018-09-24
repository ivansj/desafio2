using GConta.Application.Interfaces;
using GConta.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GConta.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Deposito")]
    public class DepositoController : Controller
    {
        private readonly ITransacaoAppService _transacaoApp;

        public DepositoController(ITransacaoAppService transacaoApp)
        {
            _transacaoApp = transacaoApp;
        }

        /// <summary>
        /// Efetua um depósito
        /// </summary>
        /// <param name="deposito">transação de depósito</param>
        /// <returns></returns>
        // POST: api/Deposito
        [HttpPost]
        public async Task Post([FromBody]Transacao deposito)
        {
            await _transacaoApp.AddAsync(deposito);
        }
    }
}