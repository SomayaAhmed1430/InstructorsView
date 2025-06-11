namespace WebApplication2.Repository
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T GetByID(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        void Save();

        //pagination
        List<T> GetPaged(int page, int pageSize);
        int GetCount();

    }
}
