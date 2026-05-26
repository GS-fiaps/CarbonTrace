using CarbonTrace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarbonTrace.Infrastructure.Persistence.Configurations;

/// <summary>
/// Configuração EF para a entidade Analise
/// </summary>
public sealed class AnaliseConfiguration : IEntityTypeConfiguration<Analise>
{
    public void Configure(EntityTypeBuilder<Analise> builder)
    {
        builder.ToTable("CT_ANALISE");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .HasColumnName("ID_ANALISE")
            .ValueGeneratedOnAdd();

        builder.Property(a => a.DataAnalise)
            .HasColumnName("DATA_ANALISE")
            .IsRequired();

        builder.Property(a => a.AreaDesmatadaKm2)
            .HasColumnName("AREA_DESMATADA_KM2")
            .IsRequired();

        builder.Property(a => a.PercentualVariacao)
            .HasColumnName("PERCENTUAL_VARIACAO")
            .IsRequired();

        builder.Property(a => a.StatusAlerta)
            .HasColumnName("STATUS_ALERTA")
            .HasConversion<string>()
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(a => a.IdImagem)
            .HasColumnName("ID_IMAGEM")
            .IsRequired();

        builder.Property(a => a.Active)
            .HasColumnName("ACTIVE");

        builder.Property(a => a.CreatedAt)
            .HasColumnName("CREATED_AT");

        // N:1 com ImagemSatelital
        builder.HasOne(a => a.ImagemSatelital)
            .WithMany(i => i.Analises)
            .HasForeignKey(a => a.IdImagem)
            .OnDelete(DeleteBehavior.Cascade);

        // 1:N com Alerta
        builder.HasMany(a => a.Alertas)
            .WithOne(al => al.Analise)
            .HasForeignKey(al => al.IdAnalise)
            .OnDelete(DeleteBehavior.Cascade);
    }
}