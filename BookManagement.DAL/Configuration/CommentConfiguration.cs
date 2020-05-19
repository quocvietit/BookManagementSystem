using BookManagement.Entities.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManagement.DAL.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comment");
            builder.HasKey(b => b.CommentId);
            builder.Property(b => b.Content).IsRequired().HasMaxLength(100);
            builder.Property(b => b.IsActive).IsRequired();
        }
    }
}
