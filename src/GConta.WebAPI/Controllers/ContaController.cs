using GConta.Application.Interfaces;
using GConta.Application.Response;
using GConta.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GConta.WebAPI.Controllers
{
    /// <summary>
    /// API de nova conta
    /// </summary>
    [Produces("application/json")]
    [Route("api/Conta")]
    public class ContaController : ApiBaseController
    {
        private readonly IContaAppService _contaApp;

        /// <summary>
        /// Construtor Contreole
        /// </summary>
        /// <param name="contaApp"></param>
        public ContaController(IContaAppService contaApp)
        {
            _contaApp = contaApp;
        }
        
        /// <summary>
        /// Cria uma nova conta
        /// </summary>
        /// <param name="conta"></param>
        /// <returns>id da conta</returns>
        // POST: api/Conta
        [HttpPost]
        [Route("~/api/CriarConta")]
        [ProducesResponseType(200, Type = typeof(ResponseConta))]
        [ProducesResponseType(400, Type = typeof(ResponseErro))]
        public async Task<IActionResult> CriarContaAsync([FromBody]ContaViewModel conta)
        {
            if (!ModelState.IsValid)
            {
                return ResponseErro();
            }

            await _contaApp.AddAsync(conta);

            var respone = new ResponseConta() {  conta = conta };            

            return Ok(respone);
        }

        /// <summary>
        /// Bloqueia uma conta
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("~/api/BloquearConta/{id}")]
        [ProducesResponseType(200, Type = typeof(ResponseApi))]
        [ProducesResponseType(400, Type = typeof(ResponseErro))]
        public async Task<IActionResult> BloquearAsync(int id)
        {
            await _contaApp.BloquearAsync(id);
            return ResponseSucesso();
        }

        /// <summary>
        /// Consulta o saldo da conta
        /// </summary>
        /// <param name="id"></param>
        /// <returns>retorna o saldo</returns>
        //[HttpGet("{id}", Name = "Get")]
        [HttpGet]
        [Route("~/api/Saldo/{id}")]
        [ProducesResponseType(200, Type = typeof(ResponseApi))]
        [ProducesResponseType(400, Type = typeof(ResponseErro))]
        public async Task<IActionResult> GetSaldoAsync(int id)
        {
            var saldo =  await _contaApp.ObterSaldoAsync(id);
            return Ok(new ResponseSaldo {  saldo = saldo });
        }

    }
}
