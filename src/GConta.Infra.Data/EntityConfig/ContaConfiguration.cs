using GConta.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GConta.Infra.Data.EntityConfig
{
    public class ContaConfiguration : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.ToTable("Conta");

            builder.HasKey(p => p.idConta);

            builder.Property(p => p.idConta)
                .UseSqlServerIdentityColumn();

            builder.Property(p => p.saldo)
                .IsRequired()
                .HasColumnType("decimal(19, 2)");

            builder.Property(p => p.limiteSaqueDiario)
                .IsRequired()
                .HasColumnType("decimal(19, 2)");

            builder
                .HasMany(c => c.Transacoes)
                .WithOne(t => t.Conta)
                .HasForeignKey(c => c.idConta)
                .IsRequired();

            
        }
    }
}
