using MusicApp.Application.Songs.Dtos;
using MusicApp.Cqrs.Interfaces;

namespace MusicApp.Application.Songs.Commands;

public record UpdateSongCommand(UpdateSongDto UpdateSongDto) : ICommand<SongDto>;

