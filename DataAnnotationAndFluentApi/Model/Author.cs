using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnnotationAndFluentApi.Model
{
    [Table("AuthorTable")] // Tablomun adı
    public class Author
    {
        [Key]
        [Column("AuthorID", TypeName = "int", Order = 1)] // column name, veri tipim ve column sıram
        public int AuthorKey { get; set; }

        [Column(Order = 2)]
        [Required] // Not nullable
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Column(Order = 3, TypeName = "nvarchar(100)")]
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [NotMapped] // db'de olmasın, modelde olsun diyorum
        public string AuthorName => $"{FirstName} {LastName}";

        [Column(Order = 5)]
        [MaxLength(1000)]
        public string Biography { get; set; }

        [Column("DoB", Order = 4, TypeName = "datetime2")]
        public DateTime BirthDate { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
