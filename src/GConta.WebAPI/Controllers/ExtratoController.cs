using GConta.Application.Interfaces;
using GConta.Application.ViewModel;
using GConta.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GConta.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Extrato")]
    public class ExtratoController : Controller
    {
        private readonly ITransacaoAppService _transacaoApp;

        public ExtratoController(ITransacaoAppService transacaoApp)
        {
            _transacaoApp = transacaoApp;
        }

        /// <summary>
        /// Obtem o Extrato da conta
        /// </summary>
        /// <param name="id">id da Conta</param>
        /// <returns></returns>
        //[HttpGet("{id}", Name = "Extrato/Get")]
        [HttpGet]
        public async Task<IEnumerable<ExtratoViewModel>> GetAsync(int id)
        {
            return await _transacaoApp.ObterExtratoAsync(id);
        }

        //[HttpGet("{id}", Name = "Get")]
        //public async Task<IEnumerable<Transacao>> GetAsync(int id, DateTime dtInicial, DateTime dtFinal)
        //{
        //    return await _transacaoApp.ObterExtratoAsync(id, dtInicial, dtFinal);
        //}
    }
}