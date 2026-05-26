using CarbonTrace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarbonTrace.Infrastructure.Persistence.Configurations;

public sealed class OcorrenciaConfiguration : IEntityTypeConfiguration<Ocorrencia>
{
    public void Configure(EntityTypeBuilder<Ocorrencia> builder)
    {
        builder.ToTable("CT_OCORRENCIA");

        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id)
            .HasColumnName("ID_OCORRENCIA")
            .HasColumnType("VARCHAR2(36)")
            .ValueGeneratedOnAdd();

        builder.Property(o => o.DataOcorrencia)
            .HasColumnName("DATA_OCORRENCIA")
            .IsRequired();

        builder.Property(o => o.Descricao)
            .HasColumnName("DESCRICAO")
            .HasColumnType("VARCHAR2(500)")
            .IsRequired();

        builder.Property(o => o.AreaEstimadaKm2)
            .HasColumnName("AREA_ESTIMADA_KM2")
            .IsRequired();

        builder.Property(o => o.IdRegiao)
            .HasColumnName("ID_REGIAO")
            .HasColumnType("VARCHAR2(36)")
            .IsRequired();

        builder.Property(o => o.IdUsuario)
            .HasColumnName("ID_USUARIO")
            .HasColumnType("VARCHAR2(36)")
            .IsRequired();

        builder.Property(o => o.Active)
            .HasColumnName("ACTIVE")
            .HasColumnType("NUMBER(1)");

        builder.Property(o => o.CreatedAt)
            .HasColumnName("CREATED_AT");

        builder.HasOne(o => o.Regiao)
            .WithMany(r => r.Ocorrencias)
            .HasForeignKey(o => o.IdRegiao)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(o => o.Usuario)
            .WithMany(u => u.Ocorrencias)
            .HasForeignKey(o => o.IdUsuario)
            .OnDelete(DeleteBehavior.Restrict);
    }
}