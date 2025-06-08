using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Validation;

namespace WebApplication2.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        [UniqueCourseNamePerDept]
        public string Name { get; set; }

        [Range(50, 100)]
        public int Degree { get; set; }

        [Remote("CheckMinDegree", "Course", AdditionalFields = "Degree", ErrorMessage = "MinDegree must be less than Degree")]
        public int MinDegree { get; set; }

        [Required]
        [CustomHoursValidation]
        public int Hours { get; set; }

        public List<Instructor> Instructors { get; set; }
        public List<CrsResult> CrsResults { get; set; }

        [ForeignKey("Dept")]
        public int DeptId { get; set; }
        public Department Dept { get; set; }


    }
}
