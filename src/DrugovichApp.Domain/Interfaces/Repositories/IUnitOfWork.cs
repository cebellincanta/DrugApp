namespace DrugovichApp.Domain.Interfaces.Repositories;

public interface IUnitOfWork
{
    Task CommitAsync();
}