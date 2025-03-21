namespace FoodRescue.Domain.Interfaces;

public interface IRepositoryManager : IDisposable
{
    Task Save();
}
