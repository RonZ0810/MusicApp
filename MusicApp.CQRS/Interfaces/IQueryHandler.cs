using MusicApp.Cqrs.Core;

namespace MusicApp.Cqrs.Interfaces;

public interface IQueryHandler<in TQuery, TResponse> where TQuery : IQuery<TResponse> {
    Task<Result<TResponse>> Handle(TQuery query, CancellationToken cancellationToken);
}
