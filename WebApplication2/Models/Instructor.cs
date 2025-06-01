using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public int Salary {  get; set; }
        public string Address {  get; set; }

        [ForeignKey("Dept")]
        public int DeptId { get; set; }
        public Department Dept { get; set; }

        [ForeignKey("Crs")]
        public int CrsId { get; set; }
        public Course Crs { get; set; }
    }
}
