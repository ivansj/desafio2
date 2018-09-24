using System.Collections.Generic;
using System.ComponentModel;

namespace GConta.Application.Response
{
    public class ResponseErro
    {
        /// <summary>
        /// sucesso (false)
        /// </summary>
        /// <value>false</value>
        [DefaultValue(false)]
        public bool sucess => false;

        /// <summary>
        /// lista de erros
        /// </summary>
        public IEnumerable<string> errors { get; set; }
    }
}
