using MusicApp.Application.Playlists.Dtos;
using MusicApp.Cqrs.Interfaces;

namespace MusicApp.Application.Playlists.Queries;

public record GetPlaylistQuery(Guid Id) : IQuery<PlaylistDto?>;

