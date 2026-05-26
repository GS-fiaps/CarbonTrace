using CarbonTrace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarbonTrace.Infrastructure.Persistence.Configurations;

/// <summary>
/// Configuração EF para a entidade Estado
/// </summary>
public sealed class EstadoConfiguration : IEntityTypeConfiguration<Estado>
{
    public void Configure(EntityTypeBuilder<Estado> builder)
    {
        builder.ToTable("CT_ESTADO");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("ID_ESTADO")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Nome)
            .HasColumnName("NOME")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.Sigla)
            .HasColumnName("SIGLA")
            .HasMaxLength(2)
            .IsRequired();

        builder.HasIndex(e => e.Sigla)
            .IsUnique();

        builder.Property(e => e.Active)
            .HasColumnName("ACTIVE");

        builder.Property(e => e.CreatedAt)
            .HasColumnName("CREATED_AT");

        // 1:N com Regiao
        builder.HasMany(e => e.Regioes)
            .WithOne(r => r.Estado)
            .HasForeignKey(r => r.IdEstado)
            .OnDelete(DeleteBehavior.Restrict);

        // 1:N com OrgaoAmbiental
        builder.HasMany(e => e.OrgaosAmbientais)
            .WithOne(o => o.Estado)
            .HasForeignKey(o => o.IdEstado)
            .OnDelete(DeleteBehavior.Cascade);
    }
}