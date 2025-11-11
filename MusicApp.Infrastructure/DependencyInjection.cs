using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicApp.Infrastructure.Persistence;
using MusicApp.Application.Security;
using MusicApp.Infrastructure.Security;

namespace MusicApp.Infrastructure;

public static class DependencyInjection {
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration) {
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<IPasswordHasher, PasswordHasher>();

        return services;
    }
}
