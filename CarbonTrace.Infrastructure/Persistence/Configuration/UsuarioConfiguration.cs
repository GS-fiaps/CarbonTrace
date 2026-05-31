using CarbonTrace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarbonTrace.Infrastructure.Persistence.Configurations;

public sealed class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("CT_USUARIO");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .HasColumnName("ID_USUARIO")
            .HasColumnType("VARCHAR2(36)")
            .ValueGeneratedOnAdd();

        builder.Property(u => u.Nome)
            .HasColumnName("NOME")
            .HasColumnType("VARCHAR2(150)")
            .IsRequired();

        builder.Property(u => u.Email)
            .HasColumnName("EMAIL")
            .HasColumnType("VARCHAR2(200)")
            .IsRequired();

        builder.HasIndex(u => u.Email)
            .IsUnique();

        builder.Property(u => u.Senha)
            .HasColumnName("SENHA")
            .HasColumnType("VARCHAR2(255)")
            .IsRequired();

        builder.Property(u => u.TipoUsuario)
            .HasColumnName("TIPO_USUARIO")
            .HasColumnType("VARCHAR2(20)")
            .HasConversion<string>()
            .IsRequired();

        builder.Property(u => u.DataCadastro)
            .HasColumnName("DATA_CADASTRO")
            .IsRequired();

        builder.Property(u => u.Active)
            .HasColumnName("ACTIVE")
            .HasColumnType("NUMBER(1)");

        builder.Property(u => u.CreatedAt)
            .HasColumnName("CREATED_AT");

        builder.HasMany(u => u.Ocorrencias)
            .WithOne(o => o.Usuario)
            .HasForeignKey(o => o.IdUsuario)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.Relatorios)
            .WithOne(r => r.Usuario)
            .HasForeignKey(r => r.IdUsuario)
            .OnDelete(DeleteBehavior.Cascade);
    }
}