using System.ComponentModel.DataAnnotations;
using WebApplication2.Models;

namespace WebApplication2.Validation
{
    public class UniqueCourseNamePerDeptAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {
            Course CrsFromReq = (Course)validationContext.ObjectInstance;

            string name = value.ToString();
            Context context = new Context();
            Course crsFromDb = context.Courses.FirstOrDefault (c => c.Name == name && c.DeptId == CrsFromReq.DeptId);
            if (crsFromDb == null)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Course name must be unique within the same department.");

        }
        //{
        //    var course = (Course)validationContext.ObjectInstance;
        //    var _context = (Context)validationContext.GetService(typeof(Context));

        //    if (_context == null)
        //    {
        //        return new ValidationResult("Database context is not available.");
        //    }

        //    bool exists = _context.Courses
        //        .Any(c => c.Name == course.Name && c.DeptId == course.DeptId);

        //    if (exists)
        //    {
        //        return new ValidationResult("Course name must be unique within the same department.");
        //    }

        //    return ValidationResult.Success;
        //}
    }

}
