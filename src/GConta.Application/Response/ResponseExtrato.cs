using GConta.Application.ViewModel;
using System.Collections.Generic;

namespace GConta.Application.Response
{
    public class ResponseExtrato 
    {
        public bool success { get { return true; } }
        public IEnumerable<ExtratoViewModel> extrato { get; set; }
    }
}
