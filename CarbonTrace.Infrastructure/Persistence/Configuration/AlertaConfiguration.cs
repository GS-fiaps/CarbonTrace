using CarbonTrace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarbonTrace.Infrastructure.Persistence.Configurations;

public sealed class AlertaConfiguration : IEntityTypeConfiguration<Alerta>
{
    public void Configure(EntityTypeBuilder<Alerta> builder)
    {
        builder.ToTable("CT_ALERTA");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .HasColumnName("ID_ALERTA")
            .HasColumnType("VARCHAR2(36)")
            .ValueGeneratedOnAdd();

        builder.Property(a => a.DataEmissao)
            .HasColumnName("DATA_EMISSAO")
            .IsRequired();

        builder.Property(a => a.NivelCriticidade)
            .HasColumnName("NIVEL_CRITICIDADE")
            .HasColumnType("VARCHAR2(20)")
            .HasConversion<string>()
            .IsRequired();

        builder.Property(a => a.Descricao)
            .HasColumnName("DESCRICAO")
            .HasColumnType("VARCHAR2(500)")
            .IsRequired();

        builder.Property(a => a.IdAnalise)
            .HasColumnName("ID_ANALISE")
            .HasColumnType("VARCHAR2(36)")
            .IsRequired();

        builder.Property(a => a.Active)
            .HasColumnName("ACTIVE")
            .HasColumnType("NUMBER(1)");

        builder.Property(a => a.CreatedAt)
            .HasColumnName("CREATED_AT");

        builder.HasOne(a => a.Analise)
            .WithMany(an => an.Alertas)
            .HasForeignKey(a => a.IdAnalise)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(a => a.AlertasOrgaos)
            .WithOne(ao => ao.Alerta)
            .HasForeignKey(ao => ao.IdAlerta)
            .OnDelete(DeleteBehavior.Restrict);
    }
}