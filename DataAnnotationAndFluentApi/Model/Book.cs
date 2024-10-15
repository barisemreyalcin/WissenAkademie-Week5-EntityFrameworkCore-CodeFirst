using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnnotationAndFluentApi.Model
{
    [Table("BookTable")] // Tablomun adı
    public class Book
    {
        [Key]
        [Column("BookID")]
        public int BookKey { get; set; }

        [Required]
        [StringLength(150)]
        [Column("BookTitle")]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string ISBN { get; set; }

        [Required]
        [Column("BookPrice", TypeName = "decimal(18, 4)")]
        public decimal Price { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime PublishDate { get; set; }

        public int PublishCount { get; set; }

        [ForeignKey("Author")]
        public int AuthorFK { get; set; }
        public Author Author { get; set; } // bire çok ilişki
    }
}
