using MusicApp.Application.Songs.Commands;
using MusicApp.Application.Songs.Dtos;
using MusicApp.Application.Songs.Extensions;
using MusicApp.Application.Songs.Interfaces;
using MusicApp.Cqrs.Core;
using MusicApp.Cqrs.Interfaces;
using MusicApp.Domain.Entities;

namespace MusicApp.Application.Songs.Handlers;

public class CreateSongHandler(ISongRepository songRepository) : ICommandHandler<CreateSongCommand, SongDto> {
    private readonly ISongRepository _songRepository = songRepository;
    public async Task<Result<SongDto>> Handle(CreateSongCommand request, CancellationToken cancellationToken) {
        try {
            var dto = request.CreateSongDto;
            if (string.IsNullOrWhiteSpace(dto.Title)) {
                return Result.Failure<SongDto>(Error.Validation("Song.Validation", "Title is required."));
            }
            var song = Song.Create(dto.Title, dto.Genre, new List<ArtistProfile>(), dto.FileUrl, dto.CoverImageUrl, dto.SpotifyId, dto.Duration, dto.ReleaseDate);
            _songRepository.Add(song);
            await _songRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success(song.ToDto());
        }
        catch (Exception ex) {
            return Result.Failure<SongDto>(Error.Failure("Song.Failure", ex.Message));
        }
    }
}

