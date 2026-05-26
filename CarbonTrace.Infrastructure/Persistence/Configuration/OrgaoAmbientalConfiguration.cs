using CarbonTrace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarbonTrace.Infrastructure.Persistence.Configurations;

/// <summary>
/// Configuração EF para a entidade OrgaoAmbiental
/// </summary>
public sealed class OrgaoAmbientalConfiguration : IEntityTypeConfiguration<OrgaoAmbiental>
{
    public void Configure(EntityTypeBuilder<OrgaoAmbiental> builder)
    {
        builder.ToTable("CT_ORGAO_AMBIENTAL");

        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id)
            .HasColumnName("ID_ORGAO")
            .ValueGeneratedOnAdd();

        builder.Property(o => o.Nome)
            .HasColumnName("NOME")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(o => o.Tipo)
            .HasColumnName("TIPO")
            .HasConversion<string>()
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(o => o.EmailContato)
            .HasColumnName("EMAIL_CONTATO")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(o => o.IdEstado)
            .HasColumnName("ID_ESTADO")
            .IsRequired();

        builder.Property(o => o.Active)
            .HasColumnName("ACTIVE");

        builder.Property(o => o.CreatedAt)
            .HasColumnName("CREATED_AT");

        // N:1 com Estado
        builder.HasOne(o => o.Estado)
            .WithMany(e => e.OrgaosAmbientais)
            .HasForeignKey(o => o.IdEstado)
            .OnDelete(DeleteBehavior.Cascade);

        // 1:N com AlertaOrgao
        builder.HasMany(o => o.AlertasOrgaos)
            .WithOne(ao => ao.OrgaoAmbiental)
            .HasForeignKey(ao => ao.IdOrgao)
            .OnDelete(DeleteBehavior.Cascade);
    }
}