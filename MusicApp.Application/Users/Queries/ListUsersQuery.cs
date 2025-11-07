using MusicApp.Application.Users.Dtos;
using MusicApp.Cqrs.Interfaces;

namespace MusicApp.Application.Users.Queries;


public record ListUsersQuery() : IQuery<IEnumerable<UserDto>>;
