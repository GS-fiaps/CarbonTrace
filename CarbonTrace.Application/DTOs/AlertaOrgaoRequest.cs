using System.ComponentModel.DataAnnotations;
using CarbonTrace.Domain.Entities;
using CarbonTrace.Domain.Enum;

namespace CarbonTrace.Application.DTOs;

/// <summary>
/// DTO de requisição para criação de notificação alerta-órgão.
/// </summary>
public record AlertaOrgaoRequest(
    [param: Required(ErrorMessage = "O alerta é obrigatório")]
    Guid IdAlerta,

    [param: Required(ErrorMessage = "O órgão ambiental é obrigatório")]
    Guid IdOrgao,

    [param: Required(ErrorMessage = "O status de notificação é obrigatório")]
    StatusNotificacaoEnum StatusNotificacao
)
{
    /// <summary>
    /// Constrói a entidade <see cref="AlertaOrgao"/>.
    /// </summary>
    public AlertaOrgao ToDomain() => new(IdAlerta, IdOrgao, StatusNotificacao);
}