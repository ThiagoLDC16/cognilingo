using Cognilingo.Application.Common.Interfaces.Persistence;
using Cognilingo.Domain.Identity.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cognilingo.Infrastructure.Identity.Persistence;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IAppDbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}