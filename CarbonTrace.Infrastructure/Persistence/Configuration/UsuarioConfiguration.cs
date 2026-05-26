using CarbonTrace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarbonTrace.Infrastructure.Persistence.Configurations;

/// <summary>
/// Configuração EF para a entidade Usuario
/// </summary>
public sealed class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("CT_USUARIO");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .HasColumnName("ID_USUARIO")
            .ValueGeneratedOnAdd();

        builder.Property(u => u.Nome)
            .HasColumnName("NOME")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(u => u.Email)
            .HasColumnName("EMAIL")
            .HasMaxLength(200)
            .IsRequired();

        builder.HasIndex(u => u.Email)
            .IsUnique();

        builder.Property(u => u.Senha)
            .HasColumnName("SENHA")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(u => u.TipoUsuario)
            .HasColumnName("TIPO_USUARIO")
            .HasConversion<string>()
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(u => u.DataCadastro)
            .HasColumnName("DATA_CADASTRO")
            .IsRequired();

        builder.Property(u => u.Active)
            .HasColumnName("ACTIVE");

        builder.Property(u => u.CreatedAt)
            .HasColumnName("CREATED_AT");

        // 1:N com Ocorrencia
        builder.HasMany(u => u.Ocorrencias)
            .WithOne(o => o.Usuario)
            .HasForeignKey(o => o.IdUsuario)
            .OnDelete(DeleteBehavior.Cascade);

        // 1:N com Relatorio
        builder.HasMany(u => u.Relatorios)
            .WithOne(r => r.Usuario)
            .HasForeignKey(r => r.IdUsuario)
            .OnDelete(DeleteBehavior.Cascade);
    }
}