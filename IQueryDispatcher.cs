using System.Threading.Tasks;

namespace Arcaim.CQRS.Queries
{
    public interface IQueryDispatcher
    {
        Task<TResult> DispatchAsync<TResult>(IQuery<TResult> query);
        Task<TResult> DispatchAsync<TQuery, TResult>(TQuery query) where TQuery : class, IQuery<TResult>;
    }
}