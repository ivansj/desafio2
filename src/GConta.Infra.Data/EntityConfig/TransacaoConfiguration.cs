using GConta.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GConta.Infra.Data.EntityConfig
{
    public class TransacaoConfiguration : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.ToTable("Transacao");
            builder.HasKey(p => p.idTransacao);

            builder.Property(p => p.idTransacao)
                .UseSqlServerIdentityColumn();

            builder.Property(p => p.dataTransacao)
                .IsRequired();

            builder.Property(p => p.valor)
                .IsRequired()
                .HasColumnType("decimal(19, 2)");
        }
    }
}
