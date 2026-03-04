namespace AccountService.Infrastructure.Models;

public interface IBaseEntity<T>
{
    public T Id { get; init; }  
}