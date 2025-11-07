using MusicApp.Application.Songs.Dtos;
using MusicApp.Cqrs.Interfaces;

namespace MusicApp.Application.Songs.Commands;

public record CreateSongCommand(CreateSongDto CreateSongDto) : ICommand<SongDto>;

