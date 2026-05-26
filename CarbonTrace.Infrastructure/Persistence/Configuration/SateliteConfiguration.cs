using CarbonTrace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarbonTrace.Infrastructure.Persistence.Configurations;

public sealed class SateliteConfiguration : IEntityTypeConfiguration<Satelite>
{
    public void Configure(EntityTypeBuilder<Satelite> builder)
    {
        builder.ToTable("CT_SATELITE");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id)
            .HasColumnName("ID_SATELITE")
            .HasColumnType("VARCHAR2(36)")
            .ValueGeneratedOnAdd();

        builder.Property(s => s.Nome)
            .HasColumnName("NOME")
            .HasColumnType("VARCHAR2(100)")
            .IsRequired();

        builder.Property(s => s.Agencia)
            .HasColumnName("AGENCIA")
            .HasColumnType("VARCHAR2(100)")
            .IsRequired();

        builder.Property(s => s.AltitudeKm)
            .HasColumnName("ALTITUDE_KM")
            .IsRequired();

        builder.Property(s => s.AnoLancamento)
            .HasColumnName("ANO_LANCAMENTO")
            .IsRequired();

        builder.Property(s => s.Active)
            .HasColumnName("ACTIVE")
            .HasColumnType("NUMBER(1)");

        builder.Property(s => s.CreatedAt)
            .HasColumnName("CREATED_AT");

        builder.HasMany(s => s.ImagensSatelitais)
            .WithOne(i => i.Satelite)
            .HasForeignKey(i => i.IdSatelite)
            .OnDelete(DeleteBehavior.Restrict);
    }
}