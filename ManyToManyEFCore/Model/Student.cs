using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyToManyEFCore.Model
{
    public class Student
    {
        public Student()
        {
            Courses = new HashSet<Course>(); 
        }
        public int StudentID { get; set; }
        public string StudentName{ get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string StudentNumber { get; set; }
        public string Class { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
