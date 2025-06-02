using System.ComponentModel.DataAnnotations.Schema;
using WebApplication2.Models;

namespace WebApplication2.ViewModels
{
    public class InstructorWithDeptAndCrsListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }

        public int DeptId { get; set; }
        public int CrsId { get; set; }


        public List<Department> DeptList { get; set; }
        public List<Course> CrsList { get; set; }
    }
}
