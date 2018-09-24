using GConta.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GConta.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Saldo")]
    public class SaldoController : Controller
    {
        private readonly IContaAppService _contaApp;

        public SaldoController(IContaAppService contaApp)
        {
            _contaApp = contaApp;
        }

        /// <summary>
        /// Consulta o saldo da conta
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[HttpGet("{id}", Name = "Get")]
        [HttpGet]
        public async Task<decimal> GetAsync(int id)
        {
            return await _contaApp.ObterSaldoAsync(id);
        }
    }
}