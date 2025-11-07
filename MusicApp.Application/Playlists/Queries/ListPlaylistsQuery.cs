using MusicApp.Application.Playlists.Dtos;
using MusicApp.Cqrs.Interfaces;

namespace MusicApp.Application.Playlists.Queries;

public record ListPlaylistsQuery() : IQuery<IEnumerable<PlaylistDto>>;

