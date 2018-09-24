using GConta.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GConta.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/BloqueioConta")]
    public class BloqueioContaController : Controller
    {
        private readonly IContaAppService _contaApp;

        public BloqueioContaController(IContaAppService contaApp)
        {
            _contaApp = contaApp;
        }

        /// <summary>
        /// Bloqueia uma conta
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task Put(int id)
        {
            await _contaApp.BloquearAsync(id);
        }
    }
}