using MusicApp.Application.Users.Dtos;
using MusicApp.Application.Users.Extensions;
using MusicApp.Application.Users.Interfaces;
using MusicApp.Application.Users.Queries;
using MusicApp.Cqrs.Core;
using MusicApp.Cqrs.Interfaces;

namespace MusicApp.Application.Users.Handlers;

public sealed class ListUsersHandler(IUserRepository userRepository) : IQueryHandler<ListUsersQuery, IEnumerable<UserDto>> {
    private readonly IUserRepository _userRepository = userRepository;
    public async Task<Result<IEnumerable<UserDto>>> Handle(ListUsersQuery request, CancellationToken cancellationToken) {
        var users = await _userRepository.ListUsersAsync();
        var userDtos = users.Select(user => user.ToDto()).ToList();
        return userDtos;
    }
}
