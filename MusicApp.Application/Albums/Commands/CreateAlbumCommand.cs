using MusicApp.Application.Albums.Dtos;
using MusicApp.Cqrs.Interfaces;

namespace MusicApp.Application.Albums.Commands;

public record CreateAlbumCommand(CreateAlbumDto CreateAlbumDto) : ICommand<AlbumDto>;

