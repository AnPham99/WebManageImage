using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>

    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.Image).WithMany(i => i.Comments).HasForeignKey(c => c.ImageId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(c => c.User).WithMany(i => i.Comments).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.Cascade);

        }

    }
}
