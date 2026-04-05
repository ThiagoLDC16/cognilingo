using Cognilingo.Domain.Identity.Entities;
using Cognilingo.Infrastructure.Common.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cognilingo.Infrastructure.Identity.Persistence.Configurations;

public sealed class RefreshTokenEntityTypeConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable("refresh_tokens");

        builder.ConfigureCommonEntities();

        builder
            .Property(rt => rt.UserId)
            .IsRequired();

        builder
            .Property(rt => rt.Token)
            .IsRequired();

        builder
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(rt => rt.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}