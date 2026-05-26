using CarbonTrace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarbonTrace.Infrastructure.Persistence.Configurations;

/// <summary>
/// Configuração EF para a entidade AlertaOrgao
/// </summary>
public sealed class AlertaOrgaoConfiguration : IEntityTypeConfiguration<AlertaOrgao>
{
    public void Configure(EntityTypeBuilder<AlertaOrgao> builder)
    {
        builder.ToTable("CT_ALERTA_ORGAO");

        builder.HasKey(ao => ao.Id);

        builder.Property(ao => ao.Id)
            .HasColumnName("ID_ALERTA_ORGAO")
            .ValueGeneratedOnAdd();

        builder.Property(ao => ao.DataNotificacao)
            .HasColumnName("DATA_NOTIFICACAO")
            .IsRequired();

        builder.Property(ao => ao.StatusNotificacao)
            .HasColumnName("STATUS_NOTIFICACAO")
            .HasConversion<string>()
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(ao => ao.IdAlerta)
            .HasColumnName("ID_ALERTA")
            .IsRequired();

        builder.Property(ao => ao.IdOrgao)
            .HasColumnName("ID_ORGAO")
            .IsRequired();

        builder.Property(ao => ao.Active)
            .HasColumnName("ACTIVE");

        builder.Property(ao => ao.CreatedAt)
            .HasColumnName("CREATED_AT");

        // N:1 com Alerta
        builder.HasOne(ao => ao.Alerta)
            .WithMany(a => a.AlertasOrgaos)
            .HasForeignKey(ao => ao.IdAlerta)
            .OnDelete(DeleteBehavior.Cascade);

        // N:1 com OrgaoAmbiental
        builder.HasOne(ao => ao.OrgaoAmbiental)
            .WithMany(o => o.AlertasOrgaos)
            .HasForeignKey(ao => ao.IdOrgao)
            .OnDelete(DeleteBehavior.Cascade);

        // Índice único para evitar duplicidade de notificação
        builder.HasIndex(ao => new { ao.IdAlerta, ao.IdOrgao })
            .IsUnique();
    }
}