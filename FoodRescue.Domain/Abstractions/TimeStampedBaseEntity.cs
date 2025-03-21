namespace FoodRescue.Domain.Abstractions;

public abstract class TimeStampedModel : BaseModel
{
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
}

public abstract class E0tendedTimeStampedModel : TimeStampedModel
{
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
