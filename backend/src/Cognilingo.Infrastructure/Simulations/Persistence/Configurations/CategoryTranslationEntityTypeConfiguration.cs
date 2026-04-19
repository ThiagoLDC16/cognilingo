using Cognilingo.Domain.Simulations.Entities;
using Cognilingo.Infrastructure.Common.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cognilingo.Infrastructure.Simulations.Persistence.Configurations;

public sealed class CategoryTranslationEntityTypeConfiguration : IEntityTypeConfiguration<CategoryTranslation>
{
    public void Configure(EntityTypeBuilder<CategoryTranslation> builder)
    {
        builder.ToTable("category_translations");
        
        builder.ConfigureCommonEntities();
        
        builder.Property(ct => ct.Name)
            .IsRequired();
    }
}