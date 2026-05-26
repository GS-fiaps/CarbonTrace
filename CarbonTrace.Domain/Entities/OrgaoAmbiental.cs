using CarbonTrace.Domain.Commom;
using CarbonTrace.Domain.Enum;

namespace CarbonTrace.Domain.Entities;

public sealed class OrgaoAmbiental(string nome, TipoOrgaoEnum tipo, string emailContato, Guid idEstado) : BaseEntity()
{
    public string Nome { get; private set; } = nome;
    public TipoOrgaoEnum Tipo { get; private set; } = tipo;
    public string EmailContato { get; private set; } = emailContato;

    // N:1
    public Guid IdEstado { get; private set; } = idEstado;
    public Estado Estado { get; private set; } = null!;

    // N:N
    public List<AlertaOrgao> AlertasOrgaos { get; set; } = [];

    private OrgaoAmbiental() : this(string.Empty, TipoOrgaoEnum.FEDERAL, string.Empty, Guid.Empty) { }
}