using MusicApp.Application.Playlists.Dtos;
using MusicApp.Cqrs.Interfaces;

namespace MusicApp.Application.Playlists.Commands;

public record UpdatePlaylistCommand(UpdatePlaylistDto UpdatePlaylistDto) : ICommand<PlaylistDto>;

