using BookManagement.Entities.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookManagement.DAL.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            builder.HasKey(b => b.CateId);
            builder.Property(b => b.CateName).IsRequired().HasMaxLength(100);
            builder.Property(b => b.Description).HasMaxLength(500);
        }
    }
}
