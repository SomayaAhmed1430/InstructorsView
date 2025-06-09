using WebApplication2.Models;

namespace WebApplication2.ViewModels
{
    public class TraineeCourseResult
    {
        public int TraineeId { get; set; }
        public string TraineeName { get; set; }
        public string CourseName { get; set; }
        public int Degree { get; set; }
        public int MinDegree { get; set; }

        public bool IsPassed => Degree >= MinDegree;


        public string DeptName { get; set; }
        public string ImgUrl { get; set; }
        public int Address { get; set; }









        //// trainee
        //public int Id { get; set; }
        //public string TraineeName { get; set; }
        //public string img { get; set; }
        //public string Addres { get; set; }
        //public int Grade { get; set; }
        //public int DeptId { get; set; }

        //public List<CrsResult> CrsResults { get; set; }
        //public List<Department> Departments { get; set; }

        //// course
        //public string CourseName { get; set; }
        //public int Degree { get; set; }
        //public int MinDegree { get; set; }

        //public bool IsPassed => Degree >= MinDegree;
    }
}
