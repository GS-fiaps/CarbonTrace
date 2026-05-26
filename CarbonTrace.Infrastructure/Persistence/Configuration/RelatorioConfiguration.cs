using CarbonTrace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarbonTrace.Infrastructure.Persistence.Configurations;

public sealed class RelatorioConfiguration : IEntityTypeConfiguration<Relatorio>
{
    public void Configure(EntityTypeBuilder<Relatorio> builder)
    {
        builder.ToTable("CT_RELATORIO");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
            .HasColumnName("ID_RELATORIO")
            .HasColumnType("VARCHAR2(36)")
            .ValueGeneratedOnAdd();

        builder.Property(r => r.Titulo)
            .HasColumnName("TITULO")
            .HasColumnType("VARCHAR2(300)")
            .IsRequired();

        builder.Property(r => r.DataGeracao)
            .HasColumnName("DATA_GERACAO")
            .IsRequired();

        builder.Property(r => r.PeriodoInicio)
            .HasColumnName("PERIODO_INICIO")
            .IsRequired();

        builder.Property(r => r.PeriodoFim)
            .HasColumnName("PERIODO_FIM")
            .IsRequired();

        builder.Property(r => r.IdUsuario)
            .HasColumnName("ID_USUARIO")
            .HasColumnType("VARCHAR2(36)")
            .IsRequired();

        builder.Property(r => r.Active)
            .HasColumnName("ACTIVE")
            .HasColumnType("NUMBER(1)");

        builder.Property(r => r.CreatedAt)
            .HasColumnName("CREATED_AT");

        builder.HasOne(r => r.Usuario)
            .WithMany(u => u.Relatorios)
            .HasForeignKey(r => r.IdUsuario)
            .OnDelete(DeleteBehavior.Restrict);
    }
}