using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProgrammersBlog.Entities.Concrete
{
    public class Article : EntityBase, IEntity
    {
        public int CategoryId { get; set; }
        public int UserId { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Thumbnail { get; set; }
        public DateTime Date { get; set; }
        public int ViewsCount { get; set; } = 0; // Okunma sayısı
        public int CommentCount { get; set; } = 0; // Yorum sayısı
        public string SeoAuthor { get; set; } // Kim yazdı
        public string SeoDescription { get; set; }
        public string SeoTags { get; set; } // Etiketler

        public Category Category { get; set; } // Navigation prop => kategoriye ulaşmak için bu şart
        public User User { get; set; } // Bir makalede bir yazar
        public ICollection<Comment> Comments { get; set; }

    }
}
