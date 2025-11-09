using Microsoft.EntityFrameworkCore;
using MusicApp.Application.Interfaces;
using MusicApp.Application.Users.Interfaces;
using MusicApp.Domain.Entities;

namespace MusicApp.Infrastructure.Persistence.Repositories;

public class UserRepository(ApplicationDbContext context) : IUserRepository {
    public IUnitOfWork UnitOfWork => context;
    public async Task<User?> GetUserAsync(Guid id) => await context.Users.FindAsync(id);
    public async Task<IEnumerable<User>> ListUsersAsync() => await context.Users.AsNoTracking().ToListAsync();
    public void Add(User user) => context.Users.Add(user);
    public void Update(User user) => context.Users.Update(user);
}
