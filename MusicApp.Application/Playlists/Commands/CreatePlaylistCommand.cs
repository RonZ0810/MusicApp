using MusicApp.Application.Playlists.Dtos;
using MusicApp.Cqrs.Interfaces;

namespace MusicApp.Application.Playlists.Commands;

public record CreatePlaylistCommand(CreatePlaylistDto CreatePlaylistDto) : ICommand<PlaylistDto>;

