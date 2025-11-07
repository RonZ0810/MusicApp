using MusicApp.Application.Playlists.Dtos;
using MusicApp.Cqrs.Interfaces;

namespace MusicApp.Application.Playlists.Commands;

public sealed record DeletePlaylistCommand(Guid Id) : ICommand<bool>;
