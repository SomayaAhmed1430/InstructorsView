using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string img { get; set; }
        public string Addres { get; set; }
        public int Grade { get; set; }

        public List<CrsResult> CrsResults { get; set; }

        [ForeignKey("Dept")]
        public int DeptId { get; set; }
        public Department Dept { get; set; }
    }
}
