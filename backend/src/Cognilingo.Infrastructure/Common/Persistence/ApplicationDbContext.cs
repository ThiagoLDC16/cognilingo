namespace Cognilingo.Infrastructure.Common.Persistence;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options), IAppDbContext
{
    // Identity
    public DbSet<User> Users => Set<User>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

    // Simulations
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Situation> Situations => Set<Situation>();
    public DbSet<SituationVariant> SituationVariants => Set<SituationVariant>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}