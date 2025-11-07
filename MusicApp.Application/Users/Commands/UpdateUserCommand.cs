using MusicApp.Application.Users.Dtos;
using MusicApp.Cqrs.Interfaces;

namespace MusicApp.Application.Users.Commands;
public record UpdateUserCommand(UpdateUserDto UpdateUserDto) : ICommand<UserDto>;
