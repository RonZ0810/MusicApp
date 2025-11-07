using MusicApp.Application.Albums.Dtos;
using MusicApp.Cqrs.Interfaces;

namespace MusicApp.Application.Albums.Commands;

public record UpdateAlbumCommand(UpdateAlbumDto UpdateAlbumDto) : ICommand<AlbumDto>;

