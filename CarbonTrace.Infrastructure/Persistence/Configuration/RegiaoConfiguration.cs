using CarbonTrace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarbonTrace.Infrastructure.Persistence.Configurations;

public sealed class RegiaoConfiguration : IEntityTypeConfiguration<Regiao>
{
    public void Configure(EntityTypeBuilder<Regiao> builder)
    {
        builder.ToTable("CT_REGIAO");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
            .HasColumnName("ID_REGIAO")
            .HasColumnType("VARCHAR2(36)")
            .ValueGeneratedOnAdd();

        builder.Property(r => r.Nome)
            .HasColumnName("NOME")
            .HasColumnType("VARCHAR2(150)")
            .IsRequired();

        builder.Property(r => r.Latitude)
            .HasColumnName("LATITUDE")
            .IsRequired();

        builder.Property(r => r.Longitude)
            .HasColumnName("LONGITUDE")
            .IsRequired();

        builder.Property(r => r.AreaKm2)
            .HasColumnName("AREA_KM2")
            .IsRequired();

        builder.Property(r => r.IdEstado)
            .HasColumnName("ID_ESTADO")
            .HasColumnType("VARCHAR2(36)")
            .IsRequired();

        builder.Property(r => r.Active)
            .HasColumnName("ACTIVE")
            .HasColumnType("NUMBER(1)");

        builder.Property(r => r.CreatedAt)
            .HasColumnName("CREATED_AT");

        builder.HasOne(r => r.Estado)
            .WithMany(e => e.Regioes)
            .HasForeignKey(r => r.IdEstado)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(r => r.ImagensSatelitais)
            .WithOne(i => i.Regiao)
            .HasForeignKey(i => i.IdRegiao)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(r => r.Ocorrencias)
            .WithOne(o => o.Regiao)
            .HasForeignKey(o => o.IdRegiao)
            .OnDelete(DeleteBehavior.Cascade);
    }
}