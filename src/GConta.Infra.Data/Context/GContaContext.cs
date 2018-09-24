using GConta.Domain.Entities;
using GConta.Infra.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GConta.Infra.Data.Context
{
    

    public class GContaContext : DbContext
    {
        public IConfigurationRoot Configuration { get; set; }

        public GContaContext(DbContextOptions<GContaContext> option)
            : base(option)
        {
            Database.EnsureCreated();
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            //var config = new ConfigurationBuilder().
            //.SetBasePath(Directory.GetCurrentDirectory())
            // .AddJsonFile("appsettings.json")
            //   .Build();

            //// define the database to use
            //optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterUrlConection());
            }
        }

        /// <summary>
        /// Obter a string de conexao
        /// </summary>
        /// <returns></returns>
        public string ObterUrlConection()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory());


            Configuration = config.Build();

            return Configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new PessoaConfiguration());
            modelBuilder.ApplyConfiguration(new ContaConfiguration());
            modelBuilder.ApplyConfiguration(new TransacaoConfiguration());

            base.OnModelCreating(modelBuilder);

        }

        //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("dataCriacao") != null))
        //    {
        //        if(entry.State == EntityState.Added)
        //        {
        //            entry.Property("dataCriacao").CurrentValue = System.DateTime.Now;
        //        }
        //        else if(entry.State == EntityState.Modified)
        //        {
        //            entry.Property("dataCriacao").IsModified = false;
        //        }
        //    }

        //    return await base.SaveChangesAsync(cancellationToken);
        //}
    }
}
