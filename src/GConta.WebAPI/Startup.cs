using AutoMapper;
using GConta.Infra.CrossCutting.IoC;
using GConta.WebAPI.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;

namespace GConta.WebAPI
{
    public class Startup
    {
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<GContaContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper();
            //services.AddSingleton<AutoMapper.IConfigurationProvider>(AutoMapperConfig.RegisterMappings());

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "GConta API",
                    Description = "Gestão de Conta",
                    Contact = new Contact { Name = "Ivan", Email = "ivansjesus.ti@gmail.com", Url = "https://www.linkedin.com/in/ivan-santos-de-jesus-3790493a" }//,
                    
                });

                s.IncludeXmlComments(ObterCaminhoXmlDoc());
            });



            services.AddMvc();

            RegisterServices(services, Configuration);
        }

        private string ObterCaminhoXmlDoc()
        {
            var caminhoXmlDoc = string.Empty;
            try
            {
                string caminhoAplicacao = PlatformServices.Default.Application.ApplicationBasePath;
                string nomeAplicacao = PlatformServices.Default.Application.ApplicationName;
                caminhoXmlDoc = Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");
            }
            catch(Exception)
            {
                return string.Empty;
            }
            return caminhoXmlDoc;
        }

       

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //    app.UseDeveloperExceptionPage();
            //else
            app.UseMiddleware<ExceptionHandler>();



            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "GConta API v1");
            });
        }

        private static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            NativeInjectorBootStrapper.RegisterServices(services, configuration);
        }
    }
}
