using BookManagement.Entities.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManagement.DAL.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.UserName).IsRequired();
            builder.Property(b => b.Email).IsRequired().HasMaxLength(100);
        }
    }
}
