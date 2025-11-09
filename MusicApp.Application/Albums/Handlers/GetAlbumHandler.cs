using MusicApp.Application.Albums.Dtos;
using MusicApp.Application.Albums.Extensions;
using MusicApp.Application.Albums.Interfaces;
using MusicApp.Application.Albums.Queries;
using MusicApp.Cqrs.Core;
using MusicApp.Cqrs.Interfaces;

namespace MusicApp.Application.Albums.Handlers;

public class GetAlbumHandler(IAlbumRepository albumRepository) : IQueryHandler<GetAlbumQuery, AlbumDto?> {
    private readonly IAlbumRepository _albumRepository = albumRepository;
    public async Task<Result<AlbumDto?>> Handle(GetAlbumQuery request, CancellationToken cancellationToken) {
        try {
            var album = await _albumRepository.GetAlbumAsync(request.Id);
            if (album == null) {
                return Result.Failure<AlbumDto?>(Error.NotFound("Album.NotFound", $"Album not found with Id: {request.Id}"));
            }
            return Result.Success<AlbumDto?>(album.ToDto());
        }
        catch (Exception ex) {
            return Result.Failure<AlbumDto?>(Error.Failure("Album.Failure", ex.Message));
        }
    }
}

