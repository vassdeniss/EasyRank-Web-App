using EasyRank.Infrastructure.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyRank.Infrastructure.Data.Configurations
{
    /// <summary>
    /// The fluent API configuration for the 'Comment' model.
    /// </summary>
    public class CommentEntityTypeConfiguration : IEntityTypeConfiguration<Comment>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasOne(c => c.RankPage)
                .WithMany(r => r.Comments)
                .HasForeignKey(c => c.RankPageId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
