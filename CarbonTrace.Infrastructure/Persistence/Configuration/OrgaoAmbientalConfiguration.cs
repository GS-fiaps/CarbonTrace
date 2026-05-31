using CarbonTrace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarbonTrace.Infrastructure.Persistence.Configurations;

public sealed class OrgaoAmbientalConfiguration : IEntityTypeConfiguration<OrgaoAmbiental>
{
    public void Configure(EntityTypeBuilder<OrgaoAmbiental> builder)
    {
        builder.ToTable("CT_ORGAO_AMBIENTAL");

        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id)
            .HasColumnName("ID_ORGAO")
            .HasColumnType("VARCHAR2(36)")
            .ValueGeneratedOnAdd();

        builder.Property(o => o.Nome)
            .HasColumnName("NOME")
            .HasColumnType("VARCHAR2(200)")
            .IsRequired();

        builder.Property(o => o.Tipo)
            .HasColumnName("TIPO")
            .HasColumnType("VARCHAR2(50)")
            .HasConversion<string>()
            .IsRequired();

        builder.Property(o => o.EmailContato)
            .HasColumnName("EMAIL_CONTATO")
            .HasColumnType("VARCHAR2(200)")
            .IsRequired();

        builder.Property(o => o.IdEstado)
            .HasColumnName("ID_ESTADO")
            .HasColumnType("VARCHAR2(36)")
            .IsRequired();

        builder.Property(o => o.Active)
            .HasColumnName("ACTIVE")
            .HasColumnType("NUMBER(1)");

        builder.Property(o => o.CreatedAt)
            .HasColumnName("CREATED_AT");

        builder.HasOne(o => o.Estado)
            .WithMany(e => e.OrgaosAmbientais)
            .HasForeignKey(o => o.IdEstado)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(o => o.AlertasOrgaos)
            .WithOne(ao => ao.OrgaoAmbiental)
            .HasForeignKey(ao => ao.IdOrgao)
            .OnDelete(DeleteBehavior.Cascade);
    }
}