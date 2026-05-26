using CarbonTrace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarbonTrace.Infrastructure.Persistence.Configurations;

public sealed class ImagemSatelitalConfiguration : IEntityTypeConfiguration<ImagemSatelital>
{
    public void Configure(EntityTypeBuilder<ImagemSatelital> builder)
    {
        builder.ToTable("CT_IMAGEM_SATELITAL");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Id)
            .HasColumnName("ID_IMAGEM")
            .HasColumnType("VARCHAR2(36)")
            .ValueGeneratedOnAdd();

        builder.Property(i => i.DataCaptura)
            .HasColumnName("DATA_CAPTURA")
            .IsRequired();

        builder.Property(i => i.ResolucaoMetros)
            .HasColumnName("RESOLUCAO_METROS")
            .IsRequired();

        builder.Property(i => i.UrlImagem)
            .HasColumnName("URL_IMAGEM")
            .HasColumnType("VARCHAR2(500)")
            .IsRequired();

        builder.Property(i => i.IdRegiao)
            .HasColumnName("ID_REGIAO")
            .HasColumnType("VARCHAR2(36)")
            .IsRequired();

        builder.Property(i => i.IdSatelite)
            .HasColumnName("ID_SATELITE")
            .HasColumnType("VARCHAR2(36)")
            .IsRequired();

        builder.Property(i => i.Active)
            .HasColumnName("ACTIVE")
            .HasColumnType("NUMBER(1)");

        builder.Property(i => i.CreatedAt)
            .HasColumnName("CREATED_AT");

        builder.HasOne(i => i.Regiao)
            .WithMany(r => r.ImagensSatelitais)
            .HasForeignKey(i => i.IdRegiao)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(i => i.Satelite)
            .WithMany(s => s.ImagensSatelitais)
            .HasForeignKey(i => i.IdSatelite)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(i => i.Analises)
            .WithOne(a => a.ImagemSatelital)
            .HasForeignKey(a => a.IdImagem)
            .OnDelete(DeleteBehavior.Restrict);
    }
}