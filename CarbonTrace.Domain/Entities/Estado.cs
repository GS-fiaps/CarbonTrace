using CarbonTrace.Domain.Commom;

namespace CarbonTrace.Domain.Entities;

public class Estado(string nome, string sigla)  : BaseEntity
{
    public string Nome { get; set; }
    public string Sigla { get; set; }
    
    
    // 1:N
    public List<Regiao> Regioes { get; set; } = [];
    public List<OrgaoAmbiental> OrgaosAmbientais { get; set; } = [];

    private Estado() : this(string.Empty, string.Empty) { }
    
}