using AutoMapper;
using GConta.Application.ViewModel;
using GConta.Domain.Entities;

namespace GConta.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Conta, ContaViewModel>();
            CreateMap<Transacao, TransacaoViewModel>();
            CreateMap<Transacao, ExtratoViewModel>();
        }
    }
}
