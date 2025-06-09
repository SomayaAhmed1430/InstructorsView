using WebApplication2.Models;

namespace WebApplication2.ViewModels
{
    public class AddResultViewModel
    {
        public int TraineeId { get; set; }
        public int CrsId { get; set; }
        public int Degree { get; set; }

        public List<Trainee> TraineeList { get; set; }
        public List<Course> CourseList { get; set; }
    }
}
