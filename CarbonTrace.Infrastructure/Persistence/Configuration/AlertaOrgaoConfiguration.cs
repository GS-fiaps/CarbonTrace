using CarbonTrace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarbonTrace.Infrastructure.Persistence.Configurations;

public sealed class AlertaOrgaoConfiguration : IEntityTypeConfiguration<AlertaOrgao>
{
    public void Configure(EntityTypeBuilder<AlertaOrgao> builder)
    {
        builder.ToTable("CT_ALERTA_ORGAO");

        builder.HasKey(ao => ao.Id);

        builder.Property(ao => ao.Id)
            .HasColumnName("ID_ALERTA_ORGAO")
            .HasColumnType("VARCHAR2(36)")
            .ValueGeneratedOnAdd();

        builder.Property(ao => ao.DataNotificacao)
            .HasColumnName("DATA_NOTIFICACAO")
            .IsRequired();

        builder.Property(ao => ao.StatusNotificacao)
            .HasColumnName("STATUS_NOTIFICACAO")
            .HasColumnType("VARCHAR2(20)")
            .HasConversion<string>()
            .IsRequired();

        builder.Property(ao => ao.IdAlerta)
            .HasColumnName("ID_ALERTA")
            .HasColumnType("VARCHAR2(36)")
            .IsRequired();

        builder.Property(ao => ao.IdOrgao)
            .HasColumnName("ID_ORGAO")
            .HasColumnType("VARCHAR2(36)")
            .IsRequired();

        builder.Property(ao => ao.Active)
            .HasColumnName("ACTIVE")
            .HasColumnType("NUMBER(1)");

        builder.Property(ao => ao.CreatedAt)
            .HasColumnName("CREATED_AT");

        builder.HasOne(ao => ao.Alerta)
            .WithMany(a => a.AlertasOrgaos)
            .HasForeignKey(ao => ao.IdAlerta)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ao => ao.OrgaoAmbiental)
            .WithMany(o => o.AlertasOrgaos)
            .HasForeignKey(ao => ao.IdOrgao)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(ao => new { ao.IdAlerta, ao.IdOrgao })
            .IsUnique();
    }
}