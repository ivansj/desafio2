using GConta.Application;
using GConta.Application.Interfaces;
using GConta.Domain.Interfaces;
using GConta.Domain.Interfaces.Repositories;
using GConta.Domain.Interfaces.Services;
using GConta.Domain.Services;
using GConta.Infra.Data.Context;
using GConta.Infra.Data.Repositories;
using GConta.Infra.Data.UoW;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using GConta.Application.AutoMapper;

namespace GConta.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            //services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
            //services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>(); ;

            // Application
            //services.AddSingleton(Mapper.Configuration);
            services.AddSingleton<AutoMapper.IConfigurationProvider>(AutoMapperConfig.RegisterMappings());
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));
            services.AddScoped<IContaAppService, ContaAppService>();
            services.AddScoped<ITransacaoAppService, TransacaoAppService>();

            // Infra - Service
            services.AddScoped<IContaService, ContaService>();
            services.AddScoped<ITransacaoService, TransacaoService>();


            // Infra - Data
            services.AddScoped<IContaRepository, ContaRepository>();
            services.AddScoped<ITransacaoRepository, TransacaoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<GContaContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


          

            
        }
    }
}
