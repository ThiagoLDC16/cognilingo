namespace Cognilingo.Application.Common.Interfaces.Persistence;

public interface IAppDbContext
{
    DbSet<User> Users { get; }
    DbSet<RefreshToken> RefreshTokens { get; }
    DbSet<Category> Categories { get; }
    DbSet<Situation> Situations { get; }
    DbSet<SituationVariant> SituationVariants { get; }
    DbSet<Simulation> Simulations { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}