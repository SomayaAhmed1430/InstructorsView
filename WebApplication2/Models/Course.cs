using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Degree { get; set; }
        public int MinDegree { get; set; }
        public int Hours { get; set; }

        public List<Instructor> Instructors { get; set; }
        public List<CrsResult> CrsResults { get; set; }

        [ForeignKey("Dept")]
        public int DeptId { get; set; }
        public Department Dept { get; set; }


    }
}
