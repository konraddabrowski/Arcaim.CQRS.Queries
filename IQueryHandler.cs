using System.Threading.Tasks;

namespace Arcaim.CQRS.Queries;

public interface IQueryHandler<in TQuery, TResult>
  where TQuery : IQuery<TResult>, new()
  where TResult : new()
{
  Task<TResult> HandleAsync(TQuery query);
}