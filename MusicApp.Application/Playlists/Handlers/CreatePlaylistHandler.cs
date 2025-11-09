using MusicApp.Application.Playlists.Commands;
using MusicApp.Application.Playlists.Dtos;
using MusicApp.Application.Playlists.Extensions;
using MusicApp.Application.Playlists.Interfaces;
using MusicApp.Application.Users.Interfaces;
using MusicApp.Cqrs.Core;
using MusicApp.Cqrs.Interfaces;
using MusicApp.Domain.Entities;

namespace MusicApp.Application.Playlists.Handlers;

public class CreatePlaylistHandler(IPlaylistRepository playlistRepository, IUserRepository userRepository) : ICommandHandler<CreatePlaylistCommand, PlaylistDto> {
    private readonly IPlaylistRepository _playlistRepository = playlistRepository;
    private readonly IUserRepository _userRepository = userRepository;
    public async Task<Result<PlaylistDto>> Handle(CreatePlaylistCommand request, CancellationToken cancellationToken) {
        try {
            var dto = request.CreatePlaylistDto;
            if (string.IsNullOrWhiteSpace(dto.Name)) {
                return Result.Failure<PlaylistDto>(Error.Validation("Playlist.Validation", "Name is required."));
            }
            var user = await _userRepository.GetUserAsync(dto.UserId);
            if (user == null) {
                return Result.Failure<PlaylistDto>(Error.NotFound("User.NotFound", $"User not found with Id: {dto.UserId}"));
            }
            var playlist = Playlist.Create(dto.Name, user, dto.SpotifyId);
            _playlistRepository.Add(playlist);
            await _playlistRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success(playlist.ToDto());
        }
        catch (Exception ex) {
            return Result.Failure<PlaylistDto>(Error.Failure("Playlist.Failure", ex.Message));
        }
    }
}

