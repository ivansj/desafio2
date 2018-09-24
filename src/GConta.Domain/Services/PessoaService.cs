using GConta.Domain.Entities;
using GConta.Domain.Interfaces;
using GConta.Domain.Interfaces.Repositories;
using GConta.Domain.Interfaces.Services;

namespace GConta.Domain.Services
{
    public class PessoaService : ServiceBase<Pessoa>, IPessoaService
    {
        private readonly IPessoaRepository _PessoaRepository;
        public PessoaService(IPessoaRepository repository, IUnitOfWork unitOfWork) 
            : base(repository, unitOfWork)
        {
            _PessoaRepository = repository;
        }
    }
}
