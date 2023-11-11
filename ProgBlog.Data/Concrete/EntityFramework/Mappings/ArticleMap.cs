using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgBlog.Entites.Concrete;

namespace ProgBlog.Data.Concrete.EntityFramework.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(a => a.Id); // primary key alanı varsa belirt
            builder.Property(a => a.Id).ValueGeneratedOnAdd(); // ıdentity alanı

            builder.Property(a => a.Title).HasMaxLength(200);
            builder.Property(a => a.Title).IsRequired();

            builder.Property(a => a.Content).IsRequired();
            builder.Property(a => a.Content).HasColumnType("NVARCHAR(MAX)"); // column tipi verilecek

            builder.Property(a => a.Date).IsRequired();

            builder.Property(a => a.SeoAuthor).IsRequired(); // paylaşan kişi
            builder.Property(a => a.SeoAuthor).HasMaxLength(50); // paylaşan kişi

            builder.Property(a => a.SeoDescription).HasMaxLength(150); // paylaşan kişi
            builder.Property(a => a.SeoDescription).IsRequired(); // paylaşan kişi

            builder.Property(a => a.SeoTags).IsRequired(); // paylaşan kişi
            builder.Property(a => a.SeoTags).HasMaxLength(70); // paylaşan kişi

            builder.Property(a => a.ViewsCount).IsRequired(); 

            builder.Property(a => a.CommentCount).IsRequired(); 

            builder.Property(a => a.Thumbnail).IsRequired(); // resim değeri
            builder.Property(a => a.Thumbnail).HasMaxLength(250); // resim değeri

            builder.Property(a => a.CreatedByName).IsRequired();
            builder.Property(a => a.CreatedByName).HasMaxLength(50);

            builder.Property(a => a.ModifiedByName).IsRequired();
            builder.Property(a => a.ModifiedByName).HasMaxLength(50);

            builder.Property(a => a.CreatedDate).IsRequired();

            builder.Property(a => a.ModifiedDate).IsRequired();

            builder.Property(a => a.IsActive).IsRequired();

            builder.Property(a => a.IsDeleted).IsRequired();

            builder.Property(a => a.Note).HasMaxLength(500); // nul geçilebilir


            builder.HasOne<Category>(a => a.Category).WithMany(c=>c.Articles).HasForeignKey(a=>a.CategoryId);
            // yani bir tane kategorisi var. yani bir kategoride birden fazla makale var


            builder.HasOne<User>(a => a.User).WithMany(u => u.Articles).HasForeignKey(a => a.UserId);

            builder.ToTable("Articles"); // tablo adı

        }
    }
}
