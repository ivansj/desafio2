using GConta.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GConta.Infra.Data.EntityConfig
{
    public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoa");
            builder.HasKey(p => p.idPessoa);

            builder.Property(p => p.nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.cpf)
                .IsRequired()
                .HasColumnType("char(11)");

            builder
                .HasMany(p => p.Contas)
                .WithOne(c => c.Pessoa)
                .HasForeignKey(p => p.idPessoa)
                .IsRequired();
        }
    }
}
