using MusicApp.Application.Albums.Commands;
using MusicApp.Application.Albums.Dtos;
using MusicApp.Application.Albums.Extensions;
using MusicApp.Application.Albums.Interfaces;
using MusicApp.Domain.Entities;
using MusicApp.Cqrs.Interfaces;
using MusicApp.Cqrs.Core;

namespace MusicApp.Application.Albums.Handlers;

public class CreateAlbumHandler(IAlbumRepository albumRepository) : ICommandHandler<CreateAlbumCommand, AlbumDto> {
    private readonly IAlbumRepository _albumRepository = albumRepository;
    public async Task<Result<AlbumDto>> Handle(CreateAlbumCommand request, CancellationToken cancellationToken) {
        try {
            var dto = request.CreateAlbumDto;
            if (string.IsNullOrWhiteSpace(dto.Title)) {
                return Result.Failure<AlbumDto>(Error.Validation("Album.Validation", "Title is required."));
            }
            var album = Album.Create(dto.Title, dto.CoverImageUrl, dto.ReleaseDate, dto.SpotifyId, new List<ArtistProfile>(), new List<Song>());
            _albumRepository.Add(album);
            await _albumRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success(album.ToDto());
        }
        catch (Exception ex) {
            return Result.Failure<AlbumDto>(Error.Failure("Album.Failure", ex.Message));
        }
    }
}

