using CarbonTrace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarbonTrace.Infrastructure.Persistence.Configurations;

/// <summary>
/// Configuração EF para a entidade Ocorrencia
/// </summary>
public sealed class OcorrenciaConfiguration : IEntityTypeConfiguration<Ocorrencia>
{
    public void Configure(EntityTypeBuilder<Ocorrencia> builder)
    {
        builder.ToTable("CT_OCORRENCIA");

        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id)
            .HasColumnName("ID_OCORRENCIA")
            .ValueGeneratedOnAdd();

        builder.Property(o => o.DataOcorrencia)
            .HasColumnName("DATA_OCORRENCIA")
            .IsRequired();

        builder.Property(o => o.Descricao)
            .HasColumnName("DESCRICAO")
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(o => o.AreaEstimadaKm2)
            .HasColumnName("AREA_ESTIMADA_KM2")
            .IsRequired();

        builder.Property(o => o.IdRegiao)
            .HasColumnName("ID_REGIAO")
            .IsRequired();

        builder.Property(o => o.IdUsuario)
            .HasColumnName("ID_USUARIO")
            .IsRequired();

        builder.Property(o => o.Active)
            .HasColumnName("ACTIVE");

        builder.Property(o => o.CreatedAt)
            .HasColumnName("CREATED_AT");

        // N:1 com Regiao
        builder.HasOne(o => o.Regiao)
            .WithMany(r => r.Ocorrencias)
            .HasForeignKey(o => o.IdRegiao)
            .OnDelete(DeleteBehavior.Cascade);

        // N:1 com Usuario
        builder.HasOne(o => o.Usuario)
            .WithMany(u => u.Ocorrencias)
            .HasForeignKey(o => o.IdUsuario)
            .OnDelete(DeleteBehavior.Cascade);
    }
}