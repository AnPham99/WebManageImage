using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>

    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData
                (
                new Category()
                {
                    Id = 1,
                    Name = "Ảnh thiên nhiên",
                  
                },
                new Category()
                {
                    Id = 2,
                    Name = "Ảnh chân dung",
                    
                },
                new Category()
                {
                    Id = 3,
                    Name = "Ảnh động vật",
                    
                },
                new Category()
                {
                    Id = 4,
                    Name = "Ảnh gợi cảm",
                    
                },
                new Category()
                {
                    Id = 5,
                    Name = "Ảnh học sinh",
                    
                },
                new Category()
                {
                    Id = 6,
                    Name = "Ảnh di sản",
                   
                }

                );
        }
    }
}
