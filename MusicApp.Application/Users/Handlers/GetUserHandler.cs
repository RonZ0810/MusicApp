using MusicApp.Application.Users.Queries;
using MusicApp.Application.Users.Dtos;
using MusicApp.Application.Users.Extensions;
using MusicApp.Application.Users.Interfaces;
using MusicApp.Cqrs.Interfaces;
using MusicApp.Cqrs.Core;
namespace MusicApp.Application.Users.Handlers;

public class GetUserHandler(IUserRepository userRepository) : IQueryHandler<GetUserQuery, UserDto?> {
    private readonly IUserRepository _userRepository = userRepository;
    public async Task<Result<UserDto?>> Handle(GetUserQuery request, CancellationToken cancellationToken) {
        try {
            var user = await _userRepository.GetUserAsync(request.Id);
            if (user == null) {
                return Result.Failure<UserDto?>(Error.NotFound("User.NotFound", $"User not found with Id: {request.Id}"));
            }
            return Result.Success<UserDto?>(user.ToDto());
        }
        catch (Exception ex) {
            return Result.Failure<UserDto?>(Error.Failure("User.Failure", ex.Message));
        }
    }
}
