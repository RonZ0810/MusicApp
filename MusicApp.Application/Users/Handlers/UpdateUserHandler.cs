using MusicApp.Application.Users.Commands;
using MusicApp.Application.Users.Dtos;
using MusicApp.Application.Users.Extensions;
using MusicApp.Application.Users.Interfaces;
using MusicApp.Cqrs.Core;
using MusicApp.Cqrs.Interfaces;
using MusicApp.Domain.Entities;
namespace MusicApp.Application.Users.Handlers;

public class UpdateUserHandler(IUserRepository userRepository) : ICommandHandler<UpdateUserCommand, UserDto> {
    private readonly IUserRepository _userRepository = userRepository;
    public async Task<Result<UserDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken) {
        try {
            var updateUserDto = request.UpdateUserDto;

            var user = await _userRepository.GetUserAsync(updateUserDto.Id);
            if (user == null) {
                return Result.Failure<UserDto>(Error.NotFound("User.NotFound", $"User not found with Id: {updateUserDto.Id}"));
            }

            var changed = false;

            var emailChanged = !string.IsNullOrWhiteSpace(updateUserDto.Email) && updateUserDto.Email != user.Email;
            var displayNameChanged = !string.IsNullOrWhiteSpace(updateUserDto.DisplayName) && updateUserDto.DisplayName != user.DisplayName;
            if (emailChanged || displayNameChanged) {
                user.Update(updateUserDto.Email, updateUserDto.DisplayName);
                changed = true;
            }

            if (!string.IsNullOrWhiteSpace(updateUserDto.ProfileImageUrl) && updateUserDto.ProfileImageUrl != user.ProfileImageUrl) {
                user.UpdateProfileImageUrl(updateUserDto.ProfileImageUrl);
                changed = true;
            }

            if (updateUserDto.Role.HasValue && updateUserDto.Role.Value != user.Role) {
                user.ChangeRole(updateUserDto.Role.Value);
                changed = true;
            }

            if (!string.IsNullOrWhiteSpace(updateUserDto.SpotifyId) && updateUserDto.SpotifyId != user.SpotifyId) {
                user.ChangeSpotifyReference(updateUserDto.SpotifyId);
                changed = true;
            }

            if (changed) {
                user.UpdatedAtTimestamp();
            }

            _userRepository.Update(user);
            await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success(user.ToDto());
        }
        catch (Exception ex) {
            return Result.Failure<UserDto>(Error.Failure("User.Failure", ex.Message));
        }
    }
}
