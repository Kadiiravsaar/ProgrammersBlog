using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Entities.Concrete;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Mappings
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


            builder.HasData(
            new Category
            {
                Id = 1,
                Name = "C#",
                Description = "C# Programlama Dili ile İlgili En Güncel Bilgiler",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "C# Blog Kategorisi",
            },
            new Category
            {
                Id = 2,
                Name = "C++",
                Description = "C++ Programlama Dili ile İlgili En Güncel Bilgiler",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "C++ Blog Kategorisi",
            },

            new Category
            {
                Id = 3,
                Name = "JavaScript",
                Description = "JavaScript Programlama Dili ile İlgili En Güncel Bilgiler",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "JavaScript Blog Kategorisi",
            }
        );
        }
    }
}
