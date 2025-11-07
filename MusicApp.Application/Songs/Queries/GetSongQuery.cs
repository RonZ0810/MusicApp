using MusicApp.Application.Songs.Dtos;
using MusicApp.Cqrs.Interfaces;

namespace MusicApp.Application.Songs.Queries;

public record GetSongQuery(Guid Id) : IQuery<SongDto?>;

