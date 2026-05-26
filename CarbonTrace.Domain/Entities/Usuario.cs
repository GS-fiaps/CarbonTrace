using CarbonTrace.Domain.Commom;
using CarbonTrace.Domain.Enum;

namespace CarbonTrace.Domain.Entities;

public sealed class Usuario(string nome, string email, string senha, TipoUsuarioEnum tipoUsuario) : BaseEntity()
{
    public string Nome { get; private set; } = nome;
    public string Email { get; private set; } = email;
    public string Senha { get; private set; } = senha;
    public TipoUsuarioEnum TipoUsuario { get; private set; } = tipoUsuario;
    public DateTime DataCadastro { get; private set; } = DateTime.UtcNow;

    // 1:N
    public List<Ocorrencia> Ocorrencias { get; set; } = [];
    public List<Relatorio> Relatorios { get; set; } = [];

    private Usuario() : this(string.Empty, string.Empty, string.Empty,TipoUsuarioEnum.FISCAL) { }
}