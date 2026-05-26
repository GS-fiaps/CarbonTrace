using CarbonTrace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarbonTrace.Infrastructure.Persistence.Configurations;

/// <summary>
/// Configuração EF para a entidade ImagemSatelital
/// </summary>
public sealed class ImagemSatelitalConfiguration : IEntityTypeConfiguration<ImagemSatelital>
{
    public void Configure(EntityTypeBuilder<ImagemSatelital> builder)
    {
        builder.ToTable("CT_IMAGEM_SATELITAL");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Id)
            .HasColumnName("ID_IMAGEM")
            .ValueGeneratedOnAdd();

        builder.Property(i => i.DataCaptura)
            .HasColumnName("DATA_CAPTURA")
            .IsRequired();

        builder.Property(i => i.ResolucaoMetros)
            .HasColumnName("RESOLUCAO_METROS")
            .IsRequired();

        builder.Property(i => i.UrlImagem)
            .HasColumnName("URL_IMAGEM")
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(i => i.IdRegiao)
            .HasColumnName("ID_REGIAO")
            .IsRequired();

        builder.Property(i => i.IdSatelite)
            .HasColumnName("ID_SATELITE")
            .IsRequired();

        builder.Property(i => i.Active)
            .HasColumnName("ACTIVE");

        builder.Property(i => i.CreatedAt)
            .HasColumnName("CREATED_AT");

        // N:1 com Regiao
        builder.HasOne(i => i.Regiao)
            .WithMany(r => r.ImagensSatelitais)
            .HasForeignKey(i => i.IdRegiao)
            .OnDelete(DeleteBehavior.Cascade);

        // N:1 com Satelite
        builder.HasOne(i => i.Satelite)
            .WithMany(s => s.ImagensSatelitais)
            .HasForeignKey(i => i.IdSatelite)
            .OnDelete(DeleteBehavior.Cascade);

        // 1:N com Analise
        builder.HasMany(i => i.Analises)
            .WithOne(a => a.ImagemSatelital)
            .HasForeignKey(a => a.IdImagem)
            .OnDelete(DeleteBehavior.Cascade);
    }
}