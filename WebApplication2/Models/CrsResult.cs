using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class CrsResult
    {
        public int Id { get; set; }
        public int Degree { get; set; }

        [ForeignKey("Crs")]
        public int CrsId { get; set; }
        public Course Crs { get; set; }

        [ForeignKey("Trainee")]
        public int TraineeId { get; set; }
        public Trainee Trainee { get; set; }
    }
}
