using MusicApp.Application.Albums.Dtos;
using MusicApp.Cqrs.Interfaces;

namespace MusicApp.Application.Albums.Queries;

public record ListAlbumsQuery() : IQuery<IEnumerable<AlbumDto>>;

