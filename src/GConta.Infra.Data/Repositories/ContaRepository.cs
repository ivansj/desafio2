using GConta.Domain.Entities;
using GConta.Domain.Interfaces.Repositories;
using GConta.Infra.Data.Context;

namespace GConta.Infra.Data.Repositories
{
    public class ContaRepository : RepositoryBase<Conta>, IContaRepository
    {
        public ContaRepository(GContaContext context) : base(context)
        {
           
        }

        
    }
}
