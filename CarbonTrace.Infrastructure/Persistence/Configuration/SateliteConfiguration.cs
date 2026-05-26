using CarbonTrace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarbonTrace.Infrastructure.Persistence.Configurations;

/// <summary>
/// Configuração EF para a entidade Satelite
/// </summary>
public sealed class SateliteConfiguration : IEntityTypeConfiguration<Satelite>
{
    public void Configure(EntityTypeBuilder<Satelite> builder)
    {
        builder.ToTable("CT_SATELITE");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id)
            .HasColumnName("ID_SATELITE")
            .ValueGeneratedOnAdd();

        builder.Property(s => s.Nome)
            .HasColumnName("NOME")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(s => s.Agencia)
            .HasColumnName("AGENCIA")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(s => s.AltitudeKm)
            .HasColumnName("ALTITUDE_KM")
            .IsRequired();

        builder.Property(s => s.AnoLancamento)
            .HasColumnName("ANO_LANCAMENTO")
            .IsRequired();

        builder.Property(s => s.Active)
            .HasColumnName("ACTIVE");

        builder.Property(s => s.CreatedAt)
            .HasColumnName("CREATED_AT");

        // 1:N com ImagemSatelital
        builder.HasMany(s => s.ImagensSatelitais)
            .WithOne(i => i.Satelite)
            .HasForeignKey(i => i.IdSatelite)
            .OnDelete(DeleteBehavior.Cascade);
    }
}