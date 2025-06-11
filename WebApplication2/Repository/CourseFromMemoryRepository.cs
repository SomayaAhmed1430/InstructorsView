using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class CourseFromMemoryRepository : ICourseRepository
    {
        List<Course> Courses;
        public CourseFromMemoryRepository()
        {
            Courses = new List<Course>()
            {
                new(){Id = 1, Name = "Ahmed1"},
                new(){Id = 2, Name = "Ahmed2"}
            };
        }
        public List<Course> GetAll()
        {
            return Courses;
        }


        public void Add(Course entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }


        public Course GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Course entity)
        {
            throw new NotImplementedException();
        }
    }
}
