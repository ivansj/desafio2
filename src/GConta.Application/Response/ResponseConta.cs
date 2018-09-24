using GConta.Application.ViewModel;

namespace GConta.Application.Response
{
    public class ResponseConta 
    {
        public bool success { get { return true; }  }
        public ContaViewModel conta { get; set; }
    }
}
