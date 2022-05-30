using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Arcaim.CQRS.Queries;

internal sealed class QueryDispatcher : IQueryDispatcher
{
  private readonly IServiceScopeFactory _serviceFactory;

  public QueryDispatcher(IServiceScopeFactory serviceFactory)
  {
    _serviceFactory = serviceFactory;
  }

  public async Task<TResult> DispatchAsync<TResult>(IQuery<TResult> query)
    where TResult : new()
  {
    using var scope = _serviceFactory.CreateScope();
    var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
    dynamic handler = scope.ServiceProvider.GetRequiredService(handlerType);
    return await handler.HandleAsync((dynamic)query);
  }

  public async Task<TResult> DispatchAsync<TQuery, TResult>(TQuery query)
    where TQuery : IQuery<TResult>, new()
    where TResult : new()
  {
    using var scope = _serviceFactory.CreateScope();
    var handler = scope.ServiceProvider.GetRequiredService<IQueryHandler<TQuery, TResult>>();
    return await handler.HandleAsync(query);
  }
}