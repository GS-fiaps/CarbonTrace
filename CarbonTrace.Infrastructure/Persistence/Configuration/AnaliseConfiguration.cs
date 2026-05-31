using CarbonTrace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarbonTrace.Infrastructure.Persistence.Configurations;

public sealed class AnaliseConfiguration : IEntityTypeConfiguration<Analise>
{
    public void Configure(EntityTypeBuilder<Analise> builder)
    {
        builder.ToTable("CT_ANALISE");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .HasColumnName("ID_ANALISE")
            .HasColumnType("VARCHAR2(36)")
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
            .HasColumnType("VARCHAR2(20)")
            .HasConversion<string>()
            .IsRequired();

        builder.Property(a => a.IdImagem)
            .HasColumnName("ID_IMAGEM")
            .HasColumnType("VARCHAR2(36)")
            .IsRequired();

        builder.Property(a => a.Active)
            .HasColumnName("ACTIVE")
            .HasColumnType("NUMBER(1)");

        builder.Property(a => a.CreatedAt)
            .HasColumnName("CREATED_AT");

        builder.HasOne(a => a.ImagemSatelital)
            .WithMany(i => i.Analises)
            .HasForeignKey(a => a.IdImagem)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(a => a.Alertas)
            .WithOne(al => al.Analise)
            .HasForeignKey(al => al.IdAnalise)
            .OnDelete(DeleteBehavior.Cascade);
    }
}