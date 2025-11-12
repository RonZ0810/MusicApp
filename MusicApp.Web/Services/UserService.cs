using System.Security.Claims;
using MusicApp.Cqrs.Interfaces;
using MusicApp.Application.Users.Queries;
using MusicApp.Application.Users.Dtos;

namespace MusicApp.Web.Services;

public class UserService(IQueryHandler<GetUserQuery, UserDto?> handler, IHttpContextAccessor httpContextAccessor) : IUserService
{
    public async Task<UserDto?> GetCurrentUserAsync()
    {
        var principal = httpContextAccessor.HttpContext?.User;
        if (principal?.Identity?.IsAuthenticated != true)
            return null;

        var id = GetUserId(principal);
        if (id is null)
            return null;

        var ct = httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
        var result = await handler.Handle(new GetUserQuery(id.Value), ct);
        return result.IsFailure ? null : result.Value;
    }

    public async Task<string> GetUserRoleAsync()
    {
        var user = await GetCurrentUserAsync();
        return user?.Role.ToString() ?? string.Empty;
    }

    private static Guid? GetUserId(ClaimsPrincipal principal)
    {
        var claim = principal.FindFirst(ClaimTypes.NameIdentifier)
                    ?? principal.FindFirst("sub")
                    ?? principal.FindFirst("oid");

        return Guid.TryParse(claim?.Value, out var id) ? id : null;
    }
}
