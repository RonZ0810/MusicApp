using MusicApp.Application.Albums.Dtos;
using MusicApp.Cqrs.Interfaces;

namespace MusicApp.Application.Albums.Queries;

public record GetAlbumQuery(Guid Id) : IQuery<AlbumDto?>;

