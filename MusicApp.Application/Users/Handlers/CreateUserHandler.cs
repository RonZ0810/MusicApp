using MusicApp.Application.Users.Commands;
using MusicApp.Application.Users.Dtos;
using MusicApp.Application.Users.Extensions;
using MusicApp.Application.Users.Interfaces;
using MusicApp.Cqrs.Core;
using MusicApp.Cqrs.Interfaces;
using MusicApp.Domain.Entities;
namespace MusicApp.Application.Users.Handlers;

public class CreateUserHandler(IUserRepository userRepository) : ICommandHandler<CreateUserCommand, UserDto> {
    private readonly IUserRepository _userRepository = userRepository;
    public async Task<Result<UserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken) {
        try {

            var createUserDto = request.CreateUserDto;
            // Basic validation
            if (string.IsNullOrWhiteSpace(createUserDto.Email)) {
                return Result.Failure<UserDto>(Error.Validation("User.Validation", "Email is required."));
            }
            if (string.IsNullOrWhiteSpace(createUserDto.DisplayName)) {
                return Result.Failure<UserDto>(Error.Validation("User.Validation", "Display Name is required."));
            }
            if (string.IsNullOrWhiteSpace(createUserDto.PasswordHash)) {
                return Result.Failure<UserDto>(Error.Validation("User.Validation", "Password Hash cannot be empty."));
            }
            if (string.IsNullOrWhiteSpace(createUserDto.PasswordSalt)) {
                return Result.Failure<UserDto>(Error.Validation("User.Validation", "Password Salt cannot be empty."));
            }

            // To-Do: PASSWORD HASH + SALT IMPLEMENTATION HERE !!!

            var user = User.Create(createUserDto.Email, createUserDto.DisplayName, createUserDto.PasswordHash, createUserDto.PasswordSalt, createUserDto.SpotifyId);

            _userRepository.Add(user);

            await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success(user.ToDto());
        }
        catch (Exception ex) {
            return Result.Failure<UserDto>(Error.Failure("User.Failure", ex.Message));
        }
    }
}
