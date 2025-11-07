using MusicApp.Application.Users.Dtos;
using MusicApp.Cqrs.Interfaces;

namespace MusicApp.Application.Users.Queries;


public record GetUserQuery(Guid Id) : IQuery<UserDto?>;
