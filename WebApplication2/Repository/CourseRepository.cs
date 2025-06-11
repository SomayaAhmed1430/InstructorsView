using System.Drawing.Printing;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class CourseRepository : ICourseRepository //IRepository<Course>
    {
        Context context;
        public CourseRepository()
        {
            context = new Context();
        }
        public void Add(Course entity)
        {
            context.Courses.Add(entity);
        }

        public void Delete(int id)
        {
            Course crsFromDB = GetByID(id);
            context.Courses.Remove(crsFromDB);
        }

        public List<Course> GetAll()
        {
            return context.Courses.ToList();
        }

        public Course GetByID(int id)
        {
            return context.Courses.FirstOrDefault(c=>c.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Course entity)
        {
            Course crsFromDB = GetByID(entity.Id); 
            crsFromDB.Name = entity.Name;
            crsFromDB.Degree = entity.Degree;
            crsFromDB.MinDegree = entity.MinDegree;
            crsFromDB.Hours = entity.Hours;
            crsFromDB.DeptId = entity.DeptId;
        }

        // pagination
        public int GetCount()
        {
            return context.Courses.Count();
        }

        public List<Course> GetPaged(int page, int pageSize)
        {
            return context.Courses.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
