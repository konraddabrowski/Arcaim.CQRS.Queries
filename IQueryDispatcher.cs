using System.Threading.Tasks;

namespace Arcaim.CQRS.Queries;

public interface IQueryDispatcher
{
  Task<TResult> DispatchAsync<TResult>(IQuery<TResult> query) where TResult : new();
  Task<TResult> DispatchAsync<TQuery, TResult>(TQuery query) 
    where TQuery : IQuery<TResult>, new()
    where TResult : new();
}