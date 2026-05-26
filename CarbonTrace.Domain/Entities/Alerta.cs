using CarbonTrace.Domain.Commom;
using CarbonTrace.Domain.Enum;

namespace CarbonTrace.Domain.Entities;

public sealed class Alerta(DateTime dataEmissao, NivelCriticidadeEnum nivelCriticidade, string descricao, Guid idAnalise) : BaseEntity()
{
    public DateTime DataEmissao { get; private set; } = dataEmissao;
    public NivelCriticidadeEnum NivelCriticidade { get; private set; } = nivelCriticidade;
    public string Descricao { get; private set; } = descricao;

    // N:1
    public Guid IdAnalise { get; private set; } = idAnalise;
    public Analise Analise { get; private set; } = null!;

    // N:N
    public List<AlertaOrgao> AlertasOrgaos { get; set; } = [];

    private Alerta() : this(DateTime.UtcNow, NivelCriticidadeEnum.BAIXO, string.Empty, Guid.Empty) { }
    
    public void Update(NivelCriticidadeEnum nivelCriticidade, string descricao)
    {
        NivelCriticidade = nivelCriticidade;
        Descricao = descricao.Trim();
    }
}