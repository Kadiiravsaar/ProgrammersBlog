using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgBlog.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgBlog.Data.Concrete.EntityFramework.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id); // primary key alanı varsa belirt
            builder.Property(c => c.Id).ValueGeneratedOnAdd(); // ıdentity alanı

            builder.Property(c => c.Name).HasMaxLength(70);
            builder.Property(c => c.Name).IsRequired();

            builder.Property(c => c.Description).HasMaxLength(450);



            builder.Property(c => c.CreatedByName).IsRequired();
            builder.Property(c => c.CreatedByName).HasMaxLength(50);
                                  
            builder.Property(c => c.ModifiedByName).IsRequired();
            builder.Property(c => c.ModifiedByName).HasMaxLength(50);
                                  
            builder.Property(c => c.CreatedDate).IsRequired();
                                  
            builder.Property(c => c.ModifiedDate).IsRequired();
                                  
            builder.Property(c => c.IsActive).IsRequired();
                                  
            builder.Property(c => c.IsDeleted).IsRequired();
                                  
            builder.Property(c => c.Note).HasMaxLength(500); // nul geçilebilir

            // içeride bir yabancı ıd olmadığı için bir ilişki yok

            builder.ToTable("Categories");
        }
    }
}
