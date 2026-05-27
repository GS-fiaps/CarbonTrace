namespace CarbonTrace.Domain.Commom;

public abstract class BaseEntity
{
    public Guid Id { get; private set; } = Guid.NewGuid(); 
    
    public bool Active { get; set; } = true;
    
    public DateTime CreatedAt{ get; set; } = DateTime.UtcNow;
}