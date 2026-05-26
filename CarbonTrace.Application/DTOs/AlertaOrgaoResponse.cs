using CarbonTrace.Domain.Entities;
using CarbonTrace.Domain.Enum;

namespace CarbonTrace.Application.DTOs;

/// <summary>
/// DTO de resposta para notificação alerta-órgão.
/// </summary>
public record AlertaOrgaoResponse(Guid Id, Guid IdAlerta, Guid IdOrgao, DateTime DataNotificacao, StatusNotificacaoEnum StatusNotificacao)
{
    /// <summary>
    /// Mapeia <see cref="AlertaOrgao"/> para DTO.
    /// </summary>
    public static AlertaOrgaoResponse FromDomain(AlertaOrgao alertaOrgao) =>
        new(alertaOrgao.Id, alertaOrgao.IdAlerta, alertaOrgao.IdOrgao, alertaOrgao.DataNotificacao, alertaOrgao.StatusNotificacao);
}