using Cognilingo.Domain.Identity.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cognilingo.Application.Common.Interfaces.Persistence;

public interface IAppDbContext
{
    DbSet<User> Users { get; }
    DbSet<RefreshToken> RefreshTokens { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}