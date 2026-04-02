namespace Shared.Repository.Models;

public interface IBaseEntity<T>
{
    public T Id { get; init; }  
}