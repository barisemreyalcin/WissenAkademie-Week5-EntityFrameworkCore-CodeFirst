using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyToManyEFCore.Model
{
    public class Course
    {
        public Course()
        {
            Students = new HashSet<Student>(); // null reference exception almamak için instance alırız constructor'da
            // Course instance alınca boş da olsa bir list collection oluşturur. Yoksa biz listeyi oluşturmak ve bu özelliği set etmemiz gerekir.
        } 
        public int CourseID { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        // çoka çok olduğu için 2 class da collection'a sahip oldu
        // ara tabloyu oluşturmama gerek yok kendisi migration sırasına oluşturuyor.
    }
}
