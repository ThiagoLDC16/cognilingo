using Cognilingo.Domain.Common;
using Cognilingo.Infrastructure.Common.Persistence.ValueGenerators;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cognilingo.Infrastructure.Common.Persistence.Extensions;

public static class EntityTypeBuilderExtensions
{
    public static EntityTypeBuilder<TEntity> ConfigureCommonEntities<TEntity>(
        this EntityTypeBuilder<TEntity> builder
    ) where TEntity : class
    {
        TryConfigureBaseEntity(builder);
        return builder;
    }

    private static void TryConfigureBaseEntity(EntityTypeBuilder builder)
    {
        if (!builder.Metadata.ClrType.IsAssignableTo(typeof(BaseEntity)))
            return;

        builder
            .HasKey(nameof(BaseEntity.Id));

        builder
            .Property(nameof(BaseEntity.Id))
            .HasValueGenerator<GuidV7Generator>();

        builder
            .Property(nameof(BaseEntity.CreatedAt))
            .IsRequired();

        builder
            .Property(nameof(BaseEntity.UpdatedAt))
            .IsRequired(false);
    }
}