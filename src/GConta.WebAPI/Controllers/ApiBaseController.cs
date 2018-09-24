using GConta.Application.Response;
using GConta.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GConta.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/ApiBase")]
    public class ApiBaseController : Controller
    {
        //protected new IActionResult Response(object result = null)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        return Ok(new
        //        {
        //            success = true,
        //            data = result
        //        });
        //    }

        //    return BadRequest(new ResponseErro
        //    {
        //        success = false,
        //        errors = ObterErros()
        //    });
        //}

        protected new IActionResult ResponseErro()
        {
            return BadRequest(new ResponseErro
            {
                //success = false,
                errors = ObterErros()
            });
        }

        protected new IActionResult ResponseSucesso()
        {
            return Ok(new ResponseApi
            {
                success = true
            });
        }



        protected IEnumerable<string> ObterErros()
        {
            var retorno = new List<string>();
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                retorno.Add(erroMsg);
            }
            return retorno;
        }
    }
}