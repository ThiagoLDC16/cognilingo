using Cognilingo.Domain.Simulations.Entities;
using Cognilingo.Infrastructure.Common.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cognilingo.Infrastructure.Simulations.Persistence.Configurations;

public sealed class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("categories");
        
        builder.ConfigureCommonEntities();

        builder.Property(c => c.ImageUrl)
            .IsRequired(false);
    }
}