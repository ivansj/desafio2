using GConta.Application.Interfaces;
using GConta.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GConta.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Saque")]
    public class SaqueController : Controller
    {
        private readonly ITransacaoAppService _transacaoApp;

        public SaqueController(ITransacaoAppService transacaoApp)
        {
            _transacaoApp = transacaoApp;
        }

        /// <summary>
        /// Efetua um saque na conta
        /// </summary>
        /// <param name="deposito">transação de deposito</param>
        /// <returns></returns>
        // POST: api/Saque
        [HttpPost]
        public async Task Post([FromBody]Transacao deposito)
        {
            await _transacaoApp.AddAsync(deposito);
        }
    }
}