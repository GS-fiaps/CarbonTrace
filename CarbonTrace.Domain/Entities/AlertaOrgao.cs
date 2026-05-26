using CarbonTrace.Domain.Commom;
using CarbonTrace.Domain.Enum;

namespace CarbonTrace.Domain.Entities;

public sealed class AlertaOrgao(Guid idAlerta, Guid idOrgao, StatusNotificacaoEnum statusNotificacao) : BaseEntity()
{
    public DateTime DataNotificacao { get; private set; } = DateTime.UtcNow;
    public StatusNotificacaoEnum StatusNotificacao { get; private set; } = statusNotificacao;

    // N:1
    public Guid IdAlerta { get; private set; } = idAlerta;
    public Alerta Alerta { get; private set; } = null!;

    public Guid IdOrgao { get; private set; } = idOrgao;
    public OrgaoAmbiental OrgaoAmbiental { get; private set; } = null!;

    private AlertaOrgao() : this(Guid.Empty, Guid.Empty, StatusNotificacaoEnum.PENDENTE) { }
}