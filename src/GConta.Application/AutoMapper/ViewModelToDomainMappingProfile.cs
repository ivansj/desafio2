using AutoMapper;
using GConta.Application.ViewModel;
using GConta.Domain.Entities;
using System;

namespace GConta.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ContaViewModel, Conta>()
                .ForMember(x => x.saldo, opt => opt.Ignore())
                .ForMember(x => x.flagAtivo, opt => opt.MapFrom(src => true))
                .ForMember(x => x.Transacoes, opt => opt.Ignore())
                .ForMember(x => x.Pessoa, opt => opt.Ignore())
                .ForMember(x => x.dataCriacao, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<TransacaoViewModel, Transacao>()
                .ForMember(x => x.Conta, opt => opt.Ignore())
                .ForMember(x => x.dataTransacao, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(x => x.idTransacao, opt => opt.Ignore());

            CreateMap<ExtratoViewModel, Transacao>()
                .ForMember(x => x.Conta, opt => opt.Ignore())
                .ForMember(x => x.idConta, opt => opt.Ignore());
        }
    }
}
