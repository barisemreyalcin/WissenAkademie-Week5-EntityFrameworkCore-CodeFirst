using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbContextDbSet.Models
{
    public class Book
    {
        public int BookID { get; set; } // id olduğunu algılıyor
        public string Title { get; set; }
        public string ISBN { get; set; }
        public DateTime PublishDate { get; set; }
        // bire sonsuz ilişki alttaki ikisinden belli
        public int AuthorID { get; set; } // foreign key
        public Author Author { get; set; } // Author classına refere eden property

    }
}
