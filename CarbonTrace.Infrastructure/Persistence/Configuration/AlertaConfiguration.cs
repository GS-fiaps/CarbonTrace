using CarbonTrace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarbonTrace.Infrastructure.Persistence.Configurations;

/// <summary>
/// Configuração EF para a entidade Alerta
/// </summary>
public sealed class AlertaConfiguration : IEntityTypeConfiguration<Alerta>
{
    public void Configure(EntityTypeBuilder<Alerta> builder)
    {
        builder.ToTable("DT_ALERTA");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .HasColumnName("ID_ALERTA")
            .ValueGeneratedOnAdd();

        builder.Property(a => a.DataEmissao)
            .HasColumnName("DATA_EMISSAO")
            .IsRequired();

        builder.Property(a => a.NivelCriticidade)
            .HasColumnName("NIVEL_CRITICIDADE")
            .HasConversion<string>()
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(a => a.Descricao)
            .HasColumnName("DESCRICAO")
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(a => a.IdAnalise)
            .HasColumnName("ID_ANALISE")
            .IsRequired();

        builder.Property(a => a.Active)
            .HasColumnName("ACTIVE");

        builder.Property(a => a.CreatedAt)
            .HasColumnName("CREATED_AT");

        // N:1 com Analise
        builder.HasOne(a => a.Analise)
            .WithMany(an => an.Alertas)
            .HasForeignKey(a => a.IdAnalise)
            .OnDelete(DeleteBehavior.Restrict);

        // 1:N com AlertaOrgao
        builder.HasMany(a => a.AlertasOrgaos)
            .WithOne(ao => ao.Alerta)
            .HasForeignKey(ao => ao.IdAlerta)
            .OnDelete(DeleteBehavior.Cascade);
    }
}