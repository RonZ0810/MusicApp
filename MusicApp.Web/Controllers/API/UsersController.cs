using System.Text.Json;
using MusicApp.Cqrs.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Application.Users.Commands;
using MusicApp.Application.Users.Dtos;
using MusicApp.Domain.Enums;
using MusicApp.Web.Services;
using MusicApp.Application.Users.Queries;

namespace MusicApp.Web.Controllers.Api;

[ApiController]
[Route("api/users")]
public class UsersController(IQueryHandler<ListUsersQuery, IEnumerable<UserDto>> listUsersHandler, IUserService userService) : ControllerBase {
    private readonly IQueryHandler<ListUsersQuery, IEnumerable<UserDto>> _listUsersHandler = listUsersHandler;
    // private readonly IUserService _userService = userService;

    [HttpGet]
    public async Task<IActionResult> ListUsers(CancellationToken cancellationToken) {
        var result = await _listUsersHandler.Handle(new ListUsersQuery(), cancellationToken);
        var users = result.Value ?? Enumerable.Empty<UserDto>();
        return Ok(users);
    }

}
