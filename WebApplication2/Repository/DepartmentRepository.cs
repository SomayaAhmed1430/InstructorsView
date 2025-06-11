using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class DepartmentRepository : IDepartmentRepository //IRepository<Department>
    {
        Context context;
        public DepartmentRepository()
        {
            context = new Context();
        }
        public void Add(Department entity)
        {
            context.Departments.Add(entity);
        }

        public void Delete(int id)
        {
            Department deptFromDB = GetByID(id);
            context.Departments.Remove(deptFromDB);
        }

        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }

        public Department GetByID(int id)
        {
            return context.Departments.FirstOrDefault(d => d.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Department entity)
        {
            Department deptFromDB = GetByID(entity.Id);
            deptFromDB.Name = entity.Name;
            deptFromDB.Manager = entity.Manager;
        }
    }
}
