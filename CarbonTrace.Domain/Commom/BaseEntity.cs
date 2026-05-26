namespace CarbonTrace.Domain.Commom;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    
    public bool active { get; set; } 
    
    public DateTime CreatedAt{ get; set; } = DateTime.UtcNow;
}