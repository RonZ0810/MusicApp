using System.Text.Json;
using MusicApp.Cqrs.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Application.Users.Commands;
using MusicApp.Application.Users.Dtos;
using MusicApp.Domain.Enums;
using MusicApp.Web.Services;

namespace MusicApp.Web.Controllers.Api;
/*
[ApiController]
[Route("api/users")]
[Authorize]
public class UsersController : ControllerBase
{
    private static readonly JsonSerializerOptions RequestSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
    };

    private readonly ICommandHandler<ListUsersCommand, IEnumerable<UserDto>> _listUsersHandler;
    private readonly ICommandHandler<UpdateUserRoleCommand, UserDto> _updateRoleHandler;
    private readonly ICommandHandler<UpdateUserRegionCommand, UserDto> _updateRegionHandler;
    private readonly IUserService _userService;
    private readonly ILogger<UsersController> _logger;

    public UsersController(
        ICommandHandler<ListUsersCommand, IEnumerable<UserDto>> listUsersHandler,
        ICommandHandler<UpdateUserRoleCommand, UserDto> updateRoleHandler,
        ICommandHandler<UpdateUserRegionCommand, UserDto> updateRegionHandler,
        IUserService userService,
        ILogger<UsersController> logger)
    {
        _listUsersHandler = listUsersHandler;
        _updateRoleHandler = updateRoleHandler;
        _updateRegionHandler = updateRegionHandler;
        _userService = userService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> ListUsers(CancellationToken cancellationToken)
    {
        var user = await _userService.GetCurrentUserAsync();
        if (user is null || user.Role is not (UserRole.Admin or UserRole.Manager))
            return Forbid();
        _logger.LogInformation("ListUsers requested by {UserId}", user.Id);
        var result = await _listUsersHandler.Handle(new ListUsersCommand(), cancellationToken);
        if (result.IsFailure)
        {
            _logger.LogError("ListUsers failed: {Error}", result.Error);
            return BadRequest(result.Error);
        }

        var users = result.Value ?? Enumerable.Empty<UserDto>();
        _logger.LogInformation("ListUsers returned {Count} users", users.Count());
        return Ok(users);
    }

    [HttpPut("{userId:guid}/role")]
    public async Task<IActionResult> UpdateUserRole(Guid userId, [FromBody] JsonElement request, CancellationToken cancellationToken)
    {
        var user = await _userService.GetCurrentUserAsync();
        if (user is null || user.Role is not (UserRole.Admin or UserRole.Manager)) return Forbid();
        if (request.ValueKind == JsonValueKind.Undefined || request.ValueKind == JsonValueKind.Null)
            return BadRequest("Role payload is required.");

        UpdateUserRoleRequest? payload;
        try
        {
            payload = JsonSerializer.Deserialize<UpdateUserRoleRequest>(request.GetRawText(), RequestSerializerOptions);
        }
        catch (JsonException)
        {
            _logger.LogWarning("Invalid role payload for {TargetUserId}", userId);
            return BadRequest("Invalid role payload.");
        }

        if (payload is null)
            return BadRequest("Role payload is required.");

        if (!Enum.IsDefined(typeof(UserRole), payload.Role))
        {
            _logger.LogWarning("Invalid role value {Role} for {TargetUserId}", payload.Role, userId);
            return Forbid();
        }

        var result = await _updateRoleHandler.Handle(new UpdateUserRoleCommand(userId, payload.Role), cancellationToken);
        if (result.IsFailure)
        {
            _logger.LogError("UpdateUserRole failed for {TargetUserId}: {Error}", userId, result.Error);
            return BadRequest(result.Error);
        }

        _logger.LogInformation("Updated role for {TargetUserId} -> {Role}", userId, payload.Role);
        return Ok(result.Value);
    }

    [HttpPut("{userId:guid}/region")]
    public async Task<IActionResult> UpdateUserRegion(Guid userId, [FromBody] JsonElement request, CancellationToken cancellationToken)
    {
        var user = await _userService.GetCurrentUserAsync();
        if (user is null || user.Role is not (UserRole.Admin or UserRole.Manager))
            return Forbid();
        if (request.ValueKind == JsonValueKind.Undefined || request.ValueKind == JsonValueKind.Null)
            return BadRequest("Region payload is required.");


        UpdateUserRegionRequest? payload;
        try
        {
            payload = JsonSerializer.Deserialize<UpdateUserRegionRequest>(request.GetRawText(), RequestSerializerOptions);
        }
        catch (JsonException)
        {
            _logger.LogWarning("Invalid region payload for {TargetUserId}", userId);
            return BadRequest("Invalid region payload.");
        }

        if (payload is null)
            return BadRequest("Region payload is required.");

        if (!Enum.IsDefined(typeof(UserRegion), payload.Region))
        {
            _logger.LogWarning("Invalid region value {Region} for {TargetUserId}", payload.Region, userId);
            return BadRequest("Invalid region value.");
        }

        var result = await _updateRegionHandler.Handle(new UpdateUserRegionCommand(userId, payload.Region), cancellationToken);
        if (result.IsFailure)
        {
            _logger.LogError("UpdateUserRegion failed for {TargetUserId}: {Error}", userId, result.Error);
            return BadRequest(result.Error);
        }

        _logger.LogInformation("Updated region for {TargetUserId} -> {Region}", userId, payload.Region);
        return Ok(result.Value);
    }

    private sealed record UpdateUserRoleRequest(UserRole Role);
    private sealed record UpdateUserRegionRequest(UserRegion Region);
}
*/
