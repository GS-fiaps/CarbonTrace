using CarbonTrace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarbonTrace.Infrastructure.Persistence.Configurations;

public sealed class EstadoConfiguration : IEntityTypeConfiguration<Estado>
{
    public void Configure(EntityTypeBuilder<Estado> builder)
    {
        builder.ToTable("CT_ESTADO");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("ID_ESTADO")
            .HasColumnType("VARCHAR2(36)")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Nome)
            .HasColumnName("NOME")
            .HasColumnType("VARCHAR2(100)")
            .IsRequired();

        builder.Property(e => e.Sigla)
            .HasColumnName("SIGLA")
            .HasColumnType("VARCHAR2(2)")
            .IsRequired();

        builder.HasIndex(e => e.Sigla)
            .IsUnique();

        builder.Property(e => e.Active)
            .HasColumnName("ACTIVE")
            .HasColumnType("NUMBER(1)");

        builder.Property(e => e.CreatedAt)
            .HasColumnName("CREATED_AT");

        builder.HasMany(e => e.Regioes)
            .WithOne(r => r.Estado)
            .HasForeignKey(r => r.IdEstado)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(e => e.OrgaosAmbientais)
            .WithOne(o => o.Estado)
            .HasForeignKey(o => o.IdEstado)
            .OnDelete(DeleteBehavior.Restrict);
    }
}