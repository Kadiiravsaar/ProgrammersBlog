using ProgBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgBlog.Entites.Concrete
{
    public class Article: EntityBase, IEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Thumbnail { get; set; }
        public DateTime Date { get; set; }
        public int ViewsCount { get; set; } // Okunma sayısı
        public int CommentCount { get; set; } // Yorum sayısı
        public string SeoAuthor { get; set; } // kim yazdı
        public string SeoDescription { get; set; } 
        public string SeoTags { get; set; } // Etiketler

        public int CategoryId { get; set; } 
        public Category Category { get; set; } // navigation prop => kategoriye ulaşmak için bu şart

        public int UserId { get; set; }
        public User User { get; set; } // bir makalede bir yazar

        public ICollection<Comment> Comments { get; set; }

    }
}
