using CarbonTrace.Domain.Entities;
using CarbonTrace.Domain.Enum;

namespace CarbonTrace.Application.DTOs;

/// <summary>
/// DTO de resposta para órgão ambiental.
/// </summary>
public record OrgaoAmbientalResponse(Guid Id, string Nome, TipoOrgaoEnum Tipo, string EmailContato, Guid IdEstado)
{
    /// <summary>
    /// Mapeia <see cref="OrgaoAmbiental"/> para DTO.
    /// </summary>
    public static OrgaoAmbientalResponse FromDomain(OrgaoAmbiental orgao) =>
        new(orgao.Id, orgao.Nome, orgao.Tipo, orgao.EmailContato, orgao.IdEstado);
}